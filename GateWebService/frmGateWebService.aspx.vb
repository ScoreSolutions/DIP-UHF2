Imports System.Data
Imports DIP_RFID.DAL.Common.Utilities
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.Data.Table
Imports System.Data.SqlClient

Partial Class frmGateWebService
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ReaderID As String = Request.QueryString("ReaderID") & ""
        Dim TagID As String = Request.QueryString("TagID") & ""
        Dim Type As String = Request.QueryString("Type") & ""
        Dim Location As String = Request.QueryString("Location") & ""
        Dim Method As String = Request.QueryString("Method") & ""
        Dim Serial_no As String = Request.QueryString("Serialno") & ""

        Select Case Method.ToLower
            Case "read"
                Response.Write(IsInsertDataToTemp(ReaderID, TagID, Type))
                'Case "checkborrow"
                '    Response.Write(IsBorrowData(TagID))
            Case "checkborrow"
                Response.Write(IsBorrowDataAndLocation(TagID, Location, ReaderID))
            Case "module"
                Response.Write(IsModule(ReaderID))
            Case "deletelog"
                Response.Write(IsDeleteDataTemp(ReaderID))
            Case "config"
                Response.Write(GetConfig(Serial_no))
            Case "alarm"
                Response.Write(IsAlarm(ReaderID))
        End Select

    End Sub

    Public Function IsInsertDataToTemp(ByVal ReaderID As String, ByVal TagID As String, ByVal Type As String) As Boolean
        Dim IsInsert As Boolean = True
        Try
            If Not IsNumeric(ReaderID) Then
                ReaderID = "1"
            End If
            Dim Trans As New SqlTransactionDB
            Trans.CreateTransaction()
            Dim tmp As New TmpGateReaderTagDAL
            tmp.READER_ID = ReaderID
            tmp.TAG_ID = TagID
            tmp.READ_TYPE = Type
            tmp.InsertData("BOX", Trans.Trans)
            Trans.CommitTransaction()
        Catch ex As Exception
            IsInsert = False
        End Try

        Return IsInsert
    End Function

    ''Public Function IsBorrowData(ByVal TagID As String) As String
    ''    Dim IsBorrow As String = "True"
    ''    Try
    ''        Dim Trans As New SqlTransactionDB
    ''        Trans.CreateTransaction()

    ''        Dim sql As String = "select top 1 app_no from Tmp_FileborrowItem where app_no ='" & TagID & "'"
    ''        Dim dt As New DataTable
    ''        Dim tbBorrow As New TbFileBorrowItemDAL
    ''        dt = tbBorrow.GetListBySql(sql, "", Trans.Trans)
    ''        If dt.Rows.Count = 0 Then
    ''            IsBorrow = "False"
    ''        End If

    ''        Dim para As New TbRequisitionData
    ''        Dim tbRequistion As New TbRequisitionDAL
    ''        para = tbRequistion.GetDataByAPP_NO(TagID, Trans.Trans)
    ''        If para.APP_NO = "" Then
    ''            IsBorrow = "True"
    ''        End If

    ''        Trans.CommitTransaction()
    ''    Catch ex As Exception
    ''    Finally
    ''        IsBorrow &= "##" & TagID
    ''    End Try

    ''    Return IsBorrow
    ''End Function

    'Check การยืม  และ Update Location
    Public Function IsBorrowDataAndLocation(ByVal TagID As String, ByVal Location As String, ByVal Reader_Id As String) As String
        Dim IsBorrow As String = "True"
        Dim IsNotAppNo As String = "True"
        Try
            Dim Trans As New SqlTransactionDB
            Trans.CreateTransaction()

            Dim sql As String = "select top 1 app_no from Tmp_FileborrowItem where app_no ='" & TagID & "'"
            Dim dt As New DataTable
            Dim tbBorrow As New TbFileBorrowItemDAL
            dt = tbBorrow.GetListBySql(sql, "", Trans.Trans)
            If dt.Rows.Count = 0 Then
                IsBorrow = "False"
            End If

            Dim para As New TbRequisitionData
            Dim tbRequistion As New TbRequisitionDAL
            para = tbRequistion.GetDataByAPP_NO(TagID, Trans.Trans)
            If para.APP_NO = "" Then
                IsBorrow = "True"
                IsNotAppNo = "False"
            End If

            If IsNotAppNo = "True" Then
                '###เพิ่ม Check และ Update Location###
                Dim sqlCheck As String = "SELECT  TOP 1 APP_NO FROM TB_REQUISTION WHERE APP_NO ='" & TagID & "' and STATUS='inprogress' and isnull(filelocation,0) <> (select id  from TB_FILELOCATION  where  Readerid=" & Reader_Id & ")"
                Dim dtLocation As New DataTable
                Dim tbRequisitio As New TbRequisitionDAL
                dtLocation = tbRequisitio.GetListBySql(sqlCheck, "", Trans.Trans)
                If dtLocation.Rows.Count > 0 Then
                    ' IsBorrow = "False"
                    'Else
                    Dim sqlUpdate As String
                    sqlUpdate = "UPDATE TB_REQUISTION SET updateon=getdate(), STATUS='complete',filelocation = (select id  from TB_FILELOCATION  where  Readerid=" & Reader_Id & ")" 'ชื่อ Location 
                    sqlUpdate &= " WHERE APP_NO='" & TagID & "' AND STATUS='inprogress'"
                    Dim sqlDB As New SqlDB
                    sqlDB.ExecuteNonQuery(sqlUpdate)

                    Dim sqlInnova As String = "exec UPDATEFILESTORE '" & TagID & "','" & GetFilelocation(Reader_Id) & "'"
                    sqlDB.ExecuteTable(sqlInnova)

                End If
                '#################################

                Trans.CommitTransaction()
                'Log Gate
                Dim trans2 As New SqlTransactionDB
                trans2.CreateTransaction()
                Dim isAlarm As Boolean = False
                Dim dal As New TbSetAlarmDAL
                If dal.ChkDataByid(Reader_Id, trans2.Trans) = True Then
                    'If dal.ChkDataByid(1, trans2.Trans) = True Then
                    'If dal.SETALARM = "N" Then
                    '    cbOnOff.Checked = False
                    'End If
                    Dim transLog As New SqlTransactionDB
                    transLog.CreateTransaction()
                    Dim ret As Boolean = True
                    Dim log As New TbGateConsoleLogDAL
                    Dim dtLog As DataTable = log.GetDataList("convert(varchar(10),timestamp,103)= convert(varchar(10),getdate(),103) and app_no = '" & TagID & "'", "", transLog.Trans)
                    If dtLog.Rows.Count > 0 Then
                        log.GetDataByid(dtLog.Rows(0)("id").ToString, transLog.Trans)
                        log.APP_NO = TagID
                        log.TIMESTAMP = DateTime.Now
                        log.ALARM_DISABLE_TIME = New Date(1, 1, 1)
                        log.ISALARM = "N"
                        log.READERID = Reader_Id
                        ret = log.UpdateByid("GATE_CONSOLE", transLog.Trans)
                    Else
                        log.APP_NO = TagID
                        log.TIMESTAMP = DateTime.Now
                        log.ISALARM = "N"
                        log.READERID = Reader_Id
                        ret = log.InsertData("GATE_CONSOLE", transLog.Trans)
                    End If

                    If ret = True Then
                        Dim tmp As New TmpFileborrowItemDAL
                        Dim chkAppNo As Boolean = True
                        chkAppNo = tmp.ChkDataByAPP_NO(TagID, transLog.Trans)
                        If chkAppNo = False And IsReaquestTransfer(TagID, Reader_Id) = False And IsCompletetTransfer(TagID, Reader_Id) = False Then   'ถ้ารายการใน Console เป็นรายการที่ไม่ได้ยืม
                            log.ISALARM = "Y"
                            log.UpdateByid("GATE_CONSOLE", transLog.Trans)
                            isAlarm = True

                        End If
                        transLog.CommitTransaction()
                    Else
                        transLog.RollbackTransaction()
                    End If

                    'Dim transalarm As New SqlTransactionDB
                    'transalarm.CreateTransaction()
                    If isAlarm = True Then
                        dal.SETALARM = "Y"
                        If dal.UpdateByid("GATE_CONSOLE", trans2.Trans) = True Then
                            trans2.CommitTransaction()
                        Else
                            trans2.RollbackTransaction()
                        End If
                    Else
                        trans2.RollbackTransaction()
                    End If

                End If


                'Lol Location
                Dim transLog2 As New SqlTransactionDB
                transLog2.CreateTransaction()
                Dim ret2 As Boolean = True
                Dim log2 As New TbLogLocationDAL
                Dim dtLog2 As DataTable = log2.GetDataList("convert(varchar(10),LOG_DATE,103)= convert(varchar(10),getdate(),103) and app_no = '" & TagID & "' and ReaderId='" & Reader_Id & "'", "", transLog2.Trans)
                If dtLog2.Rows.Count > 0 Then
                    log2.GetDataByPK(dtLog2.Rows(0)("id").ToString, transLog2.Trans)
                    log2.APP_NO = TagID
                    log2.LOG_DATE = DateTime.Now
                    log2.READERID = Reader_Id
                    ret2 = log2.UpdateByPK("GATE_CONSOLE", transLog2.Trans)
                Else
                    log2.APP_NO = TagID
                    log2.LOG_DATE = DateTime.Now
                    log2.READERID = Reader_Id
                    ret2 = log2.InsertData("GATE_CONSOLE", transLog2.Trans)
                End If

                If ret2 = True Then
                    transLog2.CommitTransaction()
                Else
                    transLog2.RollbackTransaction()
                End If
            End If

        Catch ex As Exception

        End Try

        Return IsBorrow
    End Function

    Public Function GetFilelocation(ByVal ReaderID As String) As String
        Dim ret As String = "0"
        Try
            Dim sqlDB As New SqlDB
            Dim dt As DataTable = sqlDB.ExecuteTable("SELECT  TOP 1 ID FROM TB_FILELOCATION Where ReaderID='" & ReaderID & "'")
            If dt.Rows.Count > 0 Then
                ret = dt.Rows(0)("ID")
            Else
                ret = "0"
            End If
            Return ret

        Catch ex As Exception

        End Try

        Return ret
    End Function

    '1 = ยืม,2 = คืน,3 ย้าย
    Public Function IsModule(ByVal ReaderID As String) As String
        Dim ret As String = "0"
        Try
            Dim sqlDB As New SqlDB
            Dim dt As DataTable = sqlDB.ExecuteTable("SELECT  TOP 1 SetAction FROM TB_SETMODULE Where ReaderID='" & ReaderID & "'")
            If dt.Rows.Count > 0 Then
                ret = dt.Rows(0)("SetAction")
            Else
                ret = "0"
            End If
            Return ret

        Catch ex As Exception

        End Try

        Return ret
    End Function


    'Delete Temp ที่อ่านได้จาก Speedway
    Public Function IsDeleteDataTemp(ByVal READER_ID As String) As Boolean
        Dim IsDelete As Boolean = True
        Try
            Dim sqlDB As New SqlDB
            sqlDB.ExecuteNonQuery("DELETE FROM TMP_GATE_READER_TAG WHERE createby='BOX' and  READER_ID='" & READER_ID & "'")
            IsDelete = True
        Catch ex As Exception
            IsDelete = False
        End Try

        Return IsDelete
    End Function
    'ดึง config  เพื่อใช้ในการ Insert ค่าลง Database 
    Public Function GetConfig(ByVal Serail_No As String) As String
        Dim ret As String = "0"
        Try
            Dim sqlDB As New SqlDB
            Dim dt As DataTable = sqlDB.ExecuteTable("SELECT  reader_id,Time,Type  FROM TB_CONFIG WHERE  serial_no='" & Serail_No & "'")

            If dt.Rows.Count > 0 Then
                ret = dt.Rows(0)("reader_id") & "," & dt.Rows(0)("Time") & "," & dt.Rows(0)("Type")
            Else
                ret = ""
            End If

            Return ret

        Catch ex As Exception
        End Try

        Return ret
    End Function

    'True = อยู่ระหว่างย้าย,False = ย้ายเรียบร้อย
    Public Function IsReaquestTransfer(ByVal App_no As String, ByVal ReaderId As String) As Boolean
        Dim ret As Boolean
        Try
            Dim sqlDB As New SqlDB
            Dim dt As DataTable = sqlDB.ExecuteTable("SELECT  * FROM TB_REQUISTION Where isnull(status,'complete')='inprogress' and  app_no='" & App_no & "' and location=" & ReaderId)
            If dt.Rows.Count > 0 Then
                ret = True
            Else
                ret = False
            End If
            Return ret

        Catch ex As Exception

        End Try

        Return ret
    End Function
    'Check  แฟ้ม ที่ย้าย complate แล้ว เวลาเกิน 1 นาทีจะแจ้งเตือน
    Public Function IsCompletetTransfer(ByVal App_no As String, ByVal ReaderId As String) As Boolean
        Dim ret As Boolean
        Try
            Dim sqlDB As New SqlDB
            Dim dt As DataTable = sqlDB.ExecuteTable("SELECT  * FROM TB_REQUISTION Where isnull(status,'complete')='complete' and  app_no='" & App_no & "' and location=" & ReaderId)
            If dt.Rows.Count > 0 Then
                If DateDiff(DateInterval.Minute, dt.Rows(0)("UpdateON"), Date.Now) < 2 Then
                    ret = True
                Else
                    ret = False
                End If
            Else
                ret = False
            End If
        Catch ex As Exception

        End Try

        Return ret
    End Function


    ' ''ใน กรณีย้าย เมื่อเดินผ่านประตูและประตูปิดลง จะ Update Status=complete
    ''Public Function IsUpdateLoction(ByVal TagID As String, ByVal Location As String) As String
    ''    Dim IsUpdate As Boolean = True
    ''    Try
    ''        Dim sqlUpdate As String
    ''        sqlUpdate = "UPDATE TB_REQUISTION SET STATUS='complete'"
    ''        sqlUpdate &= " WHERE APP_NO='" & TagID & "' AND STATUS='inprogrss' AND LOCATION='" & Location & "'"
    ''        Dim sqlDB As New SqlDB
    ''        sqlDB.ExecuteNonQuery(sqlUpdate)
    ''    Catch ex As Exception
    ''        IsUpdate = False
    ''    End Try

    ''    Return IsUpdate
    ''End Function
    ' ''ตรวจสอบสถานที่ก่อนเข้าประตูว่าย้ายถูก หรือ ไม่ถูก
    ''Public Function IsCheckLoction(ByVal TagID As String, ByVal Location As String) As String
    ''    Dim IsLocation As String
    ''    Try
    ''        Dim Trans As New SqlTransactionDB
    ''        Trans.CreateTransaction()

    ''        Dim sql As String = "SELECT  TOP 1 APP_NO FROM TB_REQUISTION WHERE APP_NO ='" & TagID & "' AND LOCATION <>'" & Location & "' and STATUS='inprogress'"
    ''        Dim dt As New DataTable
    ''        Dim tbRequisitio As New TbRequisitionDAL
    ''        dt = tbRequisitio.GetListBySql(sql, "", Trans.Trans)
    ''        If dt.Rows.Count > 0 Then
    ''            IsLocation = "False##" & TagID
    ''        Else
    ''            IsLocation = "True"
    ''        End If

    ''        Trans.CommitTransaction()
    ''    Catch ex As Exception
    ''    End Try

    ''    Return IsLocation
    ''End Function

    Public Function IsAlarm(ByVal ReaderID As String) As String
        Dim ret As Boolean = True
        Try
            Dim sqlDB As New SqlDB
            Dim dt As DataTable = sqlDB.ExecuteTable("SELECT   * FROM TB_SETALARM Where setalarm='Y' and  ReaderID='" & ReaderID & "'")
            If dt.Rows.Count > 0 Then
                ret = False
            Else
                ret = True
            End If
            Return ret

        Catch ex As Exception

        End Try

        Return ret
    End Function


End Class
