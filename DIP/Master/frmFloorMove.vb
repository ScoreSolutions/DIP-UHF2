Imports System.Data
Imports System.Data.SqlClient
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.Data.Table
Imports DIP_RFID.DAL.Common.Utilities
Imports OpenNETCF.Desktop.Communication
Imports System.IO
Imports System.Net.Sockets

Public Class frmFloorMove

    Dim dtValue As New DataTable
    Dim sql As String = ""
    Dim qty As Int32 = 0

    Private Sub frmFloorCount_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ShowData()
    End Sub


    Private Sub GridAppNo_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles GridAppNo.DataError
        MsgBox(e.Exception.Message)
    End Sub

    Private Sub ShowData()
        Dim sql As String
        sql = " Select table1.* from ( "
        sql &= " Select rq.app_no "
        sql &= " ,pt.patent_type_name as patentype"
        sql &= " , '0' found "
        sql &= " ,s.status_name"
        sql &= " ,cg.location_id_from"
        sql &= " ,cg.location_id_to"
        sql &= " ,datediff(year,rq.createon,getdate()) AS amountyear"
        sql &= " ,(case when s.status_name ='ละทิ้ง' then 0"
        sql &= " 	    when s.status_name ='ประกาศ' then "
        sql &= " 							case  when datediff(year,rq.createon,getdate()) >= cg.year_qty then 0"
        sql &= " 								  else 1 end"
        sql &= " 		else 1 "
        sql &= "  end) as  getount"
        sql &= "  ,f.location_name as locationto"
        sql &= " from TB_REQUISTION  rq"
        sql &= " inner join TB_PATENT_TYPE  pt"
        sql &= " on rq.patent_type_id = pt.id"
        sql &= " inner join TB_STATUS s"
        sql &= " on rq.app_status= s.id"
        sql &= " inner join CF_CHANGE_LOCATION cg"
        sql &= " on cg.location_id_from = isnull(rq.filelocation,1) and s.status_name = cg.status_name"
        sql &= " inner join TB_FILELOCATION f"
        sql &= " on f.id = cg.location_id_to"
        sql &= " where isnull(rq.filelocation,1) <> cg.location_id_to"
        sql &= " ) as table1 where table1.getount=0 order by table1.app_no"
        Dim dt_AppNo As DataTable
        dt_AppNo = SqlDB.ExecuteTable(sql)
        '  dt_Book = dal.GetListBySql(sql, "APP_NO ASC", trans.Trans)
        If dt_AppNo.Rows.Count = 0 Then
            MsgBox("ไม่สามารถอ่านไฟล์รายงานผลได้")
            lblCount.Text = "จำนวน " & 0 & " แฟ้ม"
            'btnCancel.Visible = True
            cbAll.Enabled = False
        Else
            lblCount.Text = "จำนวน  " & FormatNumber(dt_AppNo.Rows.Count, 0) & " แฟ้ม"
            GridAppNo.AutoGenerateColumns = False
            GridAppNo.DataSource = dt_AppNo
            ' GridAppNo.Columns.Item(4).Visible = False
            ' btnCancel.Visible = True
            cbAll.Enabled = True
        End If
    End Sub

    Private Sub ShowDataSelect()
        lblCount.Text = "จำนวน  " & dtValue.Rows.Count & " แฟ้ม"
        GridAppNo.DataSource = dtValue
        GridAppNo.Columns.Item(0).Visible = False
        '  GridAppNo.Columns.Item(3).Visible = False
        ' btnCancel.Visible = True
        cbAll.Visible = False
    End Sub


    Private Function GetFloorMoveData() As DataTable
        If dtValue.Columns.Count = 0 Then
            dtValue.Columns.Add("app_no")
            dtValue.Columns.Add("patentype")
            dtValue.Columns.Add("status_name")
            dtValue.Columns.Add("location_id_from")
            dtValue.Columns.Add("location_id_to")
            dtValue.Columns.Add("locationto")
            dtValue.Columns.Add("found")
        End If
        For i As Integer = 0 To GridAppNo.RowCount - 1
            If GridAppNo.Rows(i).Cells("chkSelect").Value = "Y" Then
                Dim dr As DataRow = dtValue.NewRow
                dr("app_no") = GridAppNo.Rows(i).Cells("app_no").Value
                dr("patentype") = GridAppNo.Rows(i).Cells("patentype").Value
                dr("status_name") = GridAppNo.Rows(i).Cells("status_name").Value
                dr("location_id_from") = GridAppNo.Rows(i).Cells("location_id_from").Value
                dr("location_id_to") = GridAppNo.Rows(i).Cells("location_id_to").Value
                dr("locationto") = GridAppNo.Rows(i).Cells("locationto").Value
                dr("found") = 0
                dtValue.Rows.Add(dr)
            End If
        Next
        Return dtValue
    End Function

    Private Sub ShowForm(ByVal frm As Form)
        CloseAllForm()
        frm.MdiParent = frmMain
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.Show()
    End Sub

    Private Sub CloseAllForm()
        For Each fm In Me.MdiChildren
            fm.Close()
            fm.Dispose()
        Next
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        Dim frm As New frmFloorMove
        ShowForm(frm)
        'ShowData()
        'btnSendTo.Enabled = True
        'btnSendBack.Enabled = False
        'btnSave.Enabled = False
        'lblCount.Text = "จำนวน " & 0 & " แฟ้ม"
        'Try
        '    Dim dt_AppNo As DataTable = GridAppNo.DataSource
        '    Dim locationid As Integer
        '    Dim App_No As String = ""
        '    If dt_AppNo.Rows.Count <> 0 Then
        '        locationid = GetFilelocation(dt_AppNo.Rows(0)("READERID"))
        '        For i As Integer = 0 To dt_AppNo.Rows.Count - 1
        '            If App_No = "" Then
        '                App_No = "'" & dt_AppNo.Rows(i)("APP_NO") & "'"
        '            Else
        '                App_No &= ",'" & dt_AppNo.Rows(i)("APP_NO") & "'"
        '            End If
        '        Next
        '    End If

        '    Dim strSQL As String
        '    strSQL = " update TB_FILESTORE set"
        '    strSQL &= " filelocation = " & locationid & ","
        '    strSQL &= " updateon = GETDATE()"
        '    strSQL &= " where app_no in (" & App_No & ");"
        '    strSQL &= " UPDATE TB_REQUISTION SET updateon=getdate(),filelocation = " & locationid
        '    strSQL &= " WHERE APP_NO in (" & App_No & ") "
        '    SqlDB.ExecuteNonQuery(strSQL)

        '    Dim dt As New DataTable
        '    dt.Columns.Add(New DataColumn("APP_NO", GetType(String)))
        '    dt.Columns.Add(New DataColumn("LOCATION", GetType(String)))
        '    dt.Columns.Add(New DataColumn("readerid", GetType(String)))
        '    GridAppNo.DataSource = dt
        '    lblCount.Text = "จำนวน " & 0 & " แฟ้ม"
        '    btnCancel.Visible = False
        '    MsgBox("บันทึกข้อมูลสถานที่เก็บแฟ้มสำเร็จ")
        'Catch ex As Exception
        '    MsgBox("บันทึกข้อมูลสถานที่เก็บแฟ้มไม่สำเร็จ")
        'End Try

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

    Private Sub cbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAll.CheckedChanged
        If cbAll.Checked = True Then
            For i As Integer = 0 To GridAppNo.RowCount - 1
                GridAppNo.Rows(i).Cells("chkSelect").Value = "Y"
            Next
        Else
            For i As Integer = 0 To GridAppNo.RowCount - 1
                GridAppNo.Rows(i).Cells("chkSelect").Value = "N"
            Next
        End If
    End Sub

    Private Sub btnSendTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendTo.Click

        Dim dtcheck As DataTable = GetFloorMoveData()
        Dim rapi As New RAPI
        If rapi.DevicePresent = False Then
            MsgBox("อุปกรณ์ต่อพ่วงไม่มีการเชื่อมต่อ")
            Exit Sub
        ElseIf dtcheck.Rows.Count = 0 Then
            MsgBox("กรุณาเลือกแฟ้มที่ต้องการย้าย")
            Exit Sub
        End If

        Dim frm As New frmMobile
        frm.DataFloormove = dtcheck
        frm.SyncFor = frmMobile.TASK_TYPE.Export
        frm.ShowDialog()
        ShowDataSelect()
        btnSendTo.Enabled = False
        btnSendBack.Enabled = True
    End Sub


    Private Sub btnSendBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendBack.Click
        Dim rapi As New RAPI
        If rapi.DevicePresent = False Then
            MsgBox("อุปกรณ์ต่อพ่วงไม่มีการเชื่อมต่อ")
            Exit Sub
        End If

        Dim frm As New frmMobile
        frm.SyncFor = frmMobile.TASK_TYPE.Import
        frm.ShowDialog()

        CompareData()
        CheckSave()
    End Sub
    Private Sub CheckSave()
        Dim sql As String
        sql = " select location_name,id  from TB_FILELOCATION where readerid in(1,2,3) order by location_name"
        Dim dt_check As DataTable
        dt_check = SqlDB.ExecuteTable(sql)
        '  dt_Book = dal.GetListBySql(sql, "APP_NO ASC", trans.Trans)
        If dt_check.Rows.Count <> 0 Then
            ' cbLocation.DisplayMember = "location_name"
            'cbLocation.ValueMember = "id"
            'cbLocation.DataSource = dt_check
            btnSave.Enabled = True
            'lbllocation.Visible = True
            'cbLocation.Visible = True
        End If

    End Sub
    Public Sub CompareData()
        Dim ReadTextFile As New ReadBarcodeFromTextFile
        Dim dt_AppNo_Import As DataTable = ReadTextFile.ReadTextFileMove(Application.StartupPath & "\HH_MoveOut.txt")
        If dt_AppNo_Import.Rows.Count <> 0 Then
            For i As Integer = 0 To dtValue.Rows.Count - 1
                For j As Integer = 0 To dt_AppNo_Import.Rows.Count - 1
                    If dtValue.Rows(i)("app_no") = dt_AppNo_Import.Rows(j)("app_no") And dt_AppNo_Import.Rows(j)("found") = 1 Then
                        dtValue.Rows(i)("found") = 1
                    End If
                Next
            Next
        End If
        GridAppNo.DataSource = dtValue
    End Sub

    Private Sub GridAppNo_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles GridAppNo.DataBindingComplete
        Dim dt As New DataTable
        dt = dtValue
        For i As Integer = 0 To GridAppNo.Rows.Count - 1
            Select Case GridAppNo.Rows(i).Cells("found").Value
                Case "1"
                    GridAppNo.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End Select
            GridAppNo.Rows(i).DefaultCellStyle.SelectionBackColor = GridAppNo.Rows(i).DefaultCellStyle.BackColor
            GridAppNo.Rows(i).DefaultCellStyle.SelectionForeColor = GridAppNo.Rows(i).DefaultCellStyle.ForeColor
        Next
    End Sub

    Private Sub btnSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim strSQL As String = ""
            Dim dt_AppNo As DataTable = GridAppNo.DataSource
            Dim locationid As Integer
            Dim App_No As String = ""
            If dt_AppNo.Rows.Count <> 0 Then
                'locationid = cbLocation.SelectedValue
                For i As Integer = 0 To dt_AppNo.Rows.Count - 1
                    If dt_AppNo.Rows(i)("found") = 1 Then
                        'strSQL &= " UPDATE " & ModuleConfig.IPINNOVA & "PATENTSYSTEM.dbo.FILESTORE set "
                        'strSQL &= " filelocation = " & locationid & ","
                        'strSQL &= " updateon = GETDATE()"
                        'strSQL &= " where app_no ='" & App_No & "';"
                        strSQL &= " UPDATE TB_FILESTORE set"
                        strSQL &= " filelocation = " & dt_AppNo.Rows(i)("location_id_to") & ","
                        strSQL &= " updateon = GETDATE()"
                        strSQL &= " where app_no ='" & dt_AppNo.Rows(i)("app_no") & "';"
                        strSQL &= " UPDATE TB_REQUISTION SET status='complete', updateon=getdate(),filelocation = " & dt_AppNo.Rows(i)("location_id_to")
                        strSQL &= " WHERE app_no ='" & dt_AppNo.Rows(i)("app_no") & "';"

                    End If

                Next
            End If


            'strSQL = " update " & ModuleConfig.IPINNOVA & "PATENTSYSTEM.dbo.FILESTORE set "
            'strSQL &= " filelocation = " & locationid & ","
            'strSQL &= " updateon = GETDATE()"
            'strSQL &= " where app_no in (" & App_No & ");"
            'strSQL = " update TB_FILESTORE set"
            'strSQL &= " filelocation = " & locationid & ","
            'strSQL &= " updateon = GETDATE()"
            'strSQL &= " where app_no in (" & App_No & ");"
            'strSQL &= " UPDATE TB_REQUISTION SET status='complete', updateon=getdate(),filelocation = " & locationid
            'strSQL &= " WHERE APP_NO in (" & App_No & "); "
            SqlDB.ExecuteNonQuery(strSQL)


            MsgBox("บันทึกข้อมูลสถานที่เก็บแฟ้มสำเร็จ")

            Me.Close()
            Dim frm As New frmFloorMove
            ShowForm(frm)

        Catch ex As Exception
            MsgBox("บันทึกข้อมูลสถานที่เก็บแฟ้มไม่สำเร็จ")
        End Try
    End Sub
End Class