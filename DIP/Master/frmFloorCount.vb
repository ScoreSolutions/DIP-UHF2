Imports System.Data
Imports System.Data.SqlClient
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.Data.Table
Imports DIP_RFID.DAL.Common.Utilities
Imports OpenNETCF.Desktop.Communication
Imports System.IO
Imports System.Net.Sockets

Public Class frmFloorCount

    Dim dt_AppNo As New DataTable
    Dim sql As String = ""
    Dim qty As Int32 = 0

    Private Sub frmFloorCount_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

    End Sub


    Private Sub GridAppNo_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles GridAppNo.DataError
        MsgBox(e.Exception.Message)
    End Sub

    Public Sub ShowData()
        Dim ReadTextFile As New ReadBarcodeFromTextFile
        Dim dt_AppNo As DataTable = ReadTextFile.ReadTextFileCount(Application.StartupPath & "\HH_Count.txt")
        If dt_AppNo.Rows.Count = 0 Then
            MsgBox("ไม่สามารถอ่านไฟล์รายงานผลได้")
            lblCount.Text = "จำนวน " & 0 & " แฟ้ม"
            btnSave.Visible = True
        Else
            lblCount.Text = "จำนวน  " & FormatNumber(dt_AppNo.Rows.Count, 0) & " แฟ้ม"
            GridAppNo.DataSource = dt_AppNo
            GridAppNo.Columns.Item(4).Visible = False
            GridAppNo.Columns.Item(5).Visible = False
            btnSave.Visible = True
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim rapi As New RAPI
        If rapi.DevicePresent = False Then
            MsgBox("อุปกรณ์ต่อพ่วงไม่มีการเชื่อมต่อ")
            Exit Sub
        End If

        Dim frm As New frmMobile
        frm.SyncFor = frmMobile.TASK_TYPE.Import
        frm.ShowDialog()

        ShowData()
    End Sub

    

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim dt_AppNo As DataTable = GridAppNo.DataSource
            Dim locationid As Integer
            Dim App_No As String = ""
            Dim Borrow_ID As String = ""
            Dim strSQL As String = ""
            Dim RoomInfo As New DataTable

            If dt_AppNo.Rows.Count <> 0 Then
                'locationid = GetFilelocation(dt_AppNo.Rows(0)("READERID"))
                For i As Integer = 0 To dt_AppNo.Rows.Count - 1
                    App_No = dt_AppNo.Rows(i)("APP_NO")
                    Borrow_ID = dt_AppNo.Rows(i)("borrow_id")
                    If locationid <> dt_AppNo.Rows(i)("READERID") Then
                        locationid = dt_AppNo.Rows(i)("READERID")
                        RoomInfo = GetRoomInfo(locationid)
                    End If

                    'Update TB_FILESTORE
                    Dim sql As String = "select id "
                    sql += " FROM TB_FILESTORE "
                    sql += " where app_no='" & App_No & "'"
                    Dim Fdt As DataTable = SqlDB.ExecuteTable(sql)
                    If Fdt.Rows.Count > 0 Then
                        strSQL &= " update TB_FILESTORE set"
                        strSQL &= " filelocation = " & locationid & ","
                        strSQL &= " updateon = GETDATE(),updateby='" & frmMain.txtUserName.Text & "'"
                        strSQL &= " where app_no ='" & App_No & "';" & vbNewLine & vbNewLine
                    Else
                        strSQL &= " insert into TB_FILESTORE (id,app_no,filelocation, createby,createon)"
                        strSQL &= " values((select max(id)+1 from TB_FILESTORE), '" & App_No & "', '" & locationid & "','" & frmMain.txtUserName.Text & "',getdate());" & vbNewLine & vbNewLine
                    End If


                    'Update TB_REQUISITION
                    strSQL &= " UPDATE TB_REQUISTION SET updateby='" & Borrow_ID & "',updateon=getdate(),filelocation = " & locationid
                    strSQL &= " WHERE APP_NO ='" & App_No & "'; " & vbNewLine & vbNewLine

                    'Update TS_FILE_CURRENT_LOCATION
                    sql = " select id, ms_room_id "
                    sql += " from TS_FILE_CURRENT_LOCATION"
                    sql += " where app_no='" & App_No & "'"
                    Fdt = SqlDB.ExecuteTable(sql)
                    Dim IsInsertHis As Boolean = False
                    If Fdt.Rows.Count > 0 Then
                        If RoomInfo.Rows.Count > 0 Then
                            Fdt.DefaultView.RowFilter = "ms_room_id='" & RoomInfo.Rows(0)("ms_room_id") & "'"
                            If Fdt.DefaultView.Count = 0 Then
                                strSQL += " UPDATE TS_FILE_CURRENT_LOCATION" & vbNewLine
                                strSQL += " set updated_by='" & frmMain.txtUserName.Text & "' , updated_date=getdate() " & vbNewLine
                                strSQL += " , move_date=getdate()" & vbNewLine
                                strSQL += " , readerid=0,rssi=0,ant_port_number=1 " & vbNewLine
                                strSQL += " , location_name = '" & RoomInfo.Rows(0)("room_name") & "'" & vbNewLine
                                strSQL += " , ms_room_id = '" & RoomInfo.Rows(0)("ms_room_id") & "'" & vbNewLine
                                strSQL += " , tb_officer_id=0, officer_name='', ms_desktop_id=0, desk_name=''" & vbNewLine
                                strSQL += " where app_no='" & App_No & "';" & vbNewLine & vbNewLine

                                IsInsertHis = True
                            End If
                            Fdt.DefaultView.RowFilter = ""
                        End If
                    Else
                        strSQL += " INSERT INTO TS_FILE_CURRENT_LOCATION(created_by,created_date,app_no" & vbNewLine
                        strSQL += " ,move_date,ReaderID,rssi,ant_port_number,location_name,ms_room_id" & vbNewLine
                        strSQL += " ,tb_officer_id,officer_name,ms_desktop_id,desk_name)" & vbNewLine
                        strSQL += " VALUES('" & frmMain.txtUserName.Text & "',getdate(),'" & App_No & "'," & vbNewLine
                        strSQL += " getdate(),0,0,1,'" & RoomInfo.Rows(0)("room_name") & "','" & RoomInfo.Rows(0)("ms_room_id") & "'" & vbNewLine
                        strSQL += " ,0,'',0,'');" & vbNewLine & vbNewLine

                        IsInsertHis = True
                    End If

                    If IsInsertHis = True Then
                        strSQL += " INSERT INTO TS_FILE_MOVE_HISTORY(created_by,created_date,app_no"
                        strSQL += " ,move_date,ReaderID,rssi,ant_port_number,location_name,ms_room_id"
                        strSQL += " ,tb_officer_id,officer_name,ms_desktop_id,desk_name "
                        strSQL += " ,ms_grid_layout_id, grid_row, grid_col, is_update_current_location)"
                        strSQL += " VALUES('" & frmMain.txtUserName.Text & "',getdate(),'" & App_No & "'" & vbNewLine
                        strSQL += " ,getdate(),0,0,1,'" & RoomInfo.Rows(0)("room_name") & "','" & RoomInfo.Rows(0)("ms_room_id") & "'" & vbNewLine
                        strSQL += " ,0,'',0,''"
                        strSQL += " ,0,0,0,'Y');" & vbNewLine & vbNewLine
                    End If
                Next
            End If
            'Dim strSQL As String
            'strSQL = " update " & ModuleConfig.IPINNOVA & "PATENTSYSTEM.dbo.FILESTORE set "
            'strSQL &= " filelocation = @filelocation,"
            'strSQL &= " updateon = GETDATE()"
            'strSQL &= " where app_no in (" & App_No & ");"
            'strSQL &= " update TB_FILESTORE set"
            'strSQL &= " filelocation = " & locationid & ","
            'strSQL &= " updateon = GETDATE()"
            'strSQL &= " where app_no in (" & App_No & ");"
            'strSQL &= " UPDATE TB_REQUISTION SET status='inprogress',updateon=getdate(),filelocation = " & locationid
            'strSQL &= " WHERE APP_NO in (" & App_No & ") "
            SqlDB.ExecuteNonQuery(strSQL)

            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("APP_NO", GetType(String)))
            dt.Columns.Add(New DataColumn("LOCATION", GetType(String)))
            dt.Columns.Add(New DataColumn("readerid", GetType(String)))
            dt.Columns.Add(New DataColumn("borrow_id", GetType(String)))
            dt.Columns.Add(New DataColumn("borrow_name", GetType(String)))
            GridAppNo.DataSource = dt
            lblCount.Text = "จำนวน " & 0 & " แฟ้ม"
            btnSave.Visible = False

            Dim rapi As New RAPI
            If rapi.DevicePresent = True Then
                rapi.Connect()
                If rapi.DeviceFileExists("\My Documents\HH_Count.txt") Then
                    rapi.DeleteDeviceFile("\My Documents\HH_Count.txt")
                End If
                rapi.Disconnect()
            End If

            MsgBox("บันทึกข้อมูลสถานที่เก็บแฟ้มสำเร็จ")
        Catch ex As Exception
            MsgBox("บันทึกข้อมูลสถานที่เก็บแฟ้มไม่สำเร็จ")
        End Try

    End Sub

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
End Class