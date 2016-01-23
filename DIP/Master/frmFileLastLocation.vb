Imports System.Data
Imports System.Data.SqlClient
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.Data.Table
Imports DIP_RFID.DAL.Common.Utilities
Imports OpenNETCF.Desktop.Communication
Imports System.IO
Imports System.Net.Sockets

Public Class frmFileLastLocation

    Dim dtValue As New DataTable

    Private Sub frmFloorCount_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim sql As String = "select r.id, r.room_name + ' ' + fl.floor_name location_name "
        sql += " from ms_room r"
        sql += " inner join ms_floor fl on fl.id=r.ms_floor_id"
        sql += " order by r.room_name, fl.floor_name"
        Dim dt As DataTable
        dt = SqlDB.ExecuteTable(sql)
        If dt.Rows.Count = 0 Then
            dt = New DataTable
            dt.Columns.Add("id")
            dt.Columns.Add("location_name")
        End If

        Dim dr As DataRow = dt.NewRow
        dr("id") = "0"
        dr("location_name") = "เลือก"
        dt.Rows.InsertAt(dr, 0)

        cbLocation.ValueMember = "id"
        cbLocation.DisplayMember = "location_name"
        cbLocation.DataSource = dt
    End Sub


    Private Sub GridAppNo_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles gvFileLastLocation.DataError
        MsgBox(e.Exception.Message)
    End Sub

    Private Sub ShowData()
        Dim sql As String
        sql = " select f.borrowername,f.borrowerdate, f.fileborrow_code, fb.app_no, " & vbNewLine
        sql += " isnull(rm.room_name + ' ' + fl.floor_name, isnull(cl.location_name,rlm.room_name + ' ' + flm.floor_name)) location_name " & vbNewLine
        sql += " from TMP_FILEBORROWITEM fb" & vbNewLine
        sql += " inner join TB_FILEBORROWITEM fi on fi.id=fb.fileborrowitem_id" & vbNewLine
        sql += " inner join TB_FILEBORROW f on f.id=fi.fileborrow_id" & vbNewLine
        sql += " inner join TB_REQUISTION rq on rq.app_no=fb.app_no" & vbNewLine
        sql += " left join TB_FILELOCATION fc on fc.id=rq.filelocation" & vbNewLine
        sql += " left join MS_ROOM rlm on rlm.id=fc.ms_room_id" & vbNewLine
        sql += " left join MS_FLOOR flm on flm.id=rlm.ms_floor_id" & vbNewLine
        sql += " left join TS_FILE_CURRENT_LOCATION cl on cl.app_no=fb.app_no" & vbNewLine
        sql += " left join MS_SPEEDWAY sp on sp.ReaderID=cl.ReaderID" & vbNewLine
        sql += " left join MS_ROOM rm on rm.id=sp.ms_room_id" & vbNewLine
        sql += " left join MS_FLOOR fl on fl.id=rm.ms_floor_id" & vbNewLine
        sql += " where fb.fileborrowitem_id<>0" & vbNewLine
        If cbLocation.SelectedValue <> 0 Then
            sql += " and isnull(rm.id,rlm.id)='" & cbLocation.SelectedValue & "'" & vbNewLine
        End If
        sql += " order by  f.borrowerdate,f.borrowername"

        Dim dt As DataTable
        dt = SqlDB.ExecuteTable(sql)
        If dt.Rows.Count = 0 Then
            MsgBox("ไม่พบข้อมูล")
            lblCount.Text = "จำนวน " & 0 & " แฟ้ม"
            gvFileLastLocation.DataSource = Nothing
        Else
            lblCount.Text = "จำนวน  " & FormatNumber(dt.Rows.Count, 0) & " แฟ้ม"
            gvFileLastLocation.AutoGenerateColumns = False
            gvFileLastLocation.DataSource = dt
        End If

    End Sub

    'Private Function GetFileLastLocationData() As DataTable
    '    '    If dtValue.Columns.Count = 0 Then
    '    '        dtValue = New DataTable
    '    '        dtValue.Columns.Add("fileborrow_id", GetType(Long))
    '    '        dtValue.Columns.Add("fileborrow_code")
    '    '        dtValue.Columns.Add("borrowername")
    '    '        dtValue.Columns.Add("borrowerdate", GetType(DateTime))
    '    '        dtValue.Columns.Add("file_qty", GetType(Integer))
    '    '        dtValue.Columns.Add("tag_list")
    '    '    End If
    '    '    For i As Integer = 0 To gvFileLastLocation.RowCount - 1
    '    '        If gvFileLastLocation.Rows(i).Cells("chkSelect").Value = "Y" Then
    '    '            Dim dr As DataRow = dtValue.NewRow
    '    '            dr("fileborrow_id") = gvFileLastLocation.Rows(i).Cells("fileborrow_id").Value
    '    '            dr("fileborrow_code") = gvFileLastLocation.Rows(i).Cells("fileborrow_code").Value
    '    '            dr("borrowername") = gvFileLastLocation.Rows(i).Cells("borrowername").Value
    '    '            dr("borrowerdate") = gvFileLastLocation.Rows(i).Cells("borrowerdate").Value
    '    '            dr("file_qty") = gvFileLastLocation.Rows(i).Cells("file_qty").Value

    '    '            Dim sqlT As String = "select r.app_no, isnull(fl.floor_name + ' ' + ro.room_name, isnull(ft.location_name,'ห้องแฟ้มชั้น 6')) last_location" & vbNewLine
    '    '            sqlT += " from TB_FILEBORROWITEM bi" & vbNewLine
    '    '            sqlT += " inner join TB_REQUISTION r on r.id=bi.requisition_id" & vbNewLine
    '    '            sqlT += " left join TS_FILE_CURRENT_LOCATION fc on r.app_no=fc.app_no" & vbNewLine
    '    '            sqlT += " left join MS_ROOM ro on ro.id=fc.ms_room_id" & vbNewLine
    '    '            sqlT += " left join MS_FLOOR fl on fl.id=ro.ms_floor_id" & vbNewLine
    '    '            sqlT += " left join TB_FILELOCATION ft on ft.id=r.filelocation" & vbNewLine
    '    '            sqlT += " where bi.fileborrow_id='" & gvFileLastLocation.Rows(i).Cells("fileborrow_id").Value & "'"
    '    '            Dim dtT As DataTable = SqlDB.ExecuteTable(sqlT)
    '    '            If dtT.Rows.Count > 0 Then
    '    '                Dim TagList As String = ""
    '    '                For Each dtR As DataRow In dtT.Rows
    '    '                    If TagList = "" Then
    '    '                        TagList = dtR("app_no") & "," & dtR("last_location")
    '    '                    Else
    '    '                        TagList += "##" & dtR("app_no") & "," & dtR("last_location")
    '    '                    End If
    '    '                Next
    '    '                dr("tag_list") = TagList
    '    '            End If

    '    '            dtValue.Rows.Add(dr)
    '    '        End If
    '    '    Next
    '    '    Return dtValue
    'End Function

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

    Private Sub btnSendTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendTo.Click
        dtValue = New DataTable
        Dim dt As DataTable = gvFileLastLocation.DataSource
        If dt.Rows.Count > 0 Then
            Dim rapi As New RAPI
            If rapi.DevicePresent = False Then
                MsgBox("อุปกรณ์ต่อพ่วงไม่มีการเชื่อมต่อ")
                Exit Sub
            ElseIf dt.Rows.Count = 0 Then
                MsgBox("กรุณาเลือกใบยืมที่ต้องการส่งข้อมูลไปยัง Handheld")
                Exit Sub
            End If

            Dim frm As New frmMobile
            frm.FileLastLocation = dt
            frm.SyncFor = frmMobile.TASK_TYPE.Export
            frm.ShowDialog()
            'ShowData()
        End If
    End Sub


    Private Sub cbLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLocation.SelectedIndexChanged
        cbLocation.Enabled = False
        btnSendTo.Enabled = False
        If cbLocation.SelectedValue <> 0 Then
            ShowData()
        Else
            gvFileLastLocation.DataSource = Nothing
        End If
        cbLocation.Enabled = True
        btnSendTo.Enabled = True
    End Sub
End Class