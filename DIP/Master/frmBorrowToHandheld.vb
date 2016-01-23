Imports System.Data
Imports System.Data.SqlClient
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.Data.Table
Imports DIP_RFID.DAL.Common.Utilities
Imports OpenNETCF.Desktop.Communication
Imports System.IO
Imports System.Net.Sockets

Public Class frmBorrowToHandheld

    Dim dtValue As New DataTable

    Private Sub frmFloorCount_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

    End Sub


    Private Sub GridAppNo_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles gvFileBorrow.DataError
        MsgBox(e.Exception.Message)
    End Sub

    Private Sub ShowData()
        Dim sql As String
        sql = " select f.id fileborrow_id, f.fileborrow_code,f.borrowername,f.borrowerdate, count(fi.id) file_qty"
        sql += " from TB_FILEBORROW f"
        sql += " inner join TB_FILEBORROWITEM fi on f.id=fi.fileborrow_id"
        sql += " where f.send_time is null "
        If txtBorrowerDate.TextDate.Trim <> "" Then
            sql += " and convert(varchar(8),f.borrowerdate,112)='" & txtBorrowerDate.DateValue.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "'"
        End If
        sql += " group by f.id, f.fileborrow_code,f.borrowername,f.borrowerdate"
        sql += " order by  f.borrowerdate,f.borrowername"

        Dim dt As DataTable
        dt = SqlDB.ExecuteTable(sql)
        If dt.Rows.Count = 0 Then
            MsgBox("ไม่พอข้อมูล")
            lblCount.Text = "จำนวน " & 0 & " รายการ"
            cbAll.Enabled = False
        Else
            lblCount.Text = "จำนวน  " & FormatNumber(dt.Rows.Count, 0) & " รายการ"
            gvFileBorrow.AutoGenerateColumns = False
            gvFileBorrow.DataSource = dt
            cbAll.Enabled = True
        End If

    End Sub

    Private Function GetBorrowData() As DataTable
        If dtValue.Columns.Count = 0 Then
            dtValue = New DataTable
            dtValue.Columns.Add("fileborrow_id", GetType(Long))
            dtValue.Columns.Add("fileborrow_code")
            dtValue.Columns.Add("borrowername")
            dtValue.Columns.Add("borrowerdate", GetType(DateTime))
            dtValue.Columns.Add("file_qty", GetType(Integer))
            dtValue.Columns.Add("tag_list")
        End If
        For i As Integer = 0 To gvFileBorrow.RowCount - 1
            If gvFileBorrow.Rows(i).Cells("chkSelect").Value = "Y" Then
                Dim dr As DataRow = dtValue.NewRow
                dr("fileborrow_id") = gvFileBorrow.Rows(i).Cells("fileborrow_id").Value
                dr("fileborrow_code") = gvFileBorrow.Rows(i).Cells("fileborrow_code").Value
                dr("borrowername") = gvFileBorrow.Rows(i).Cells("borrowername").Value
                dr("borrowerdate") = gvFileBorrow.Rows(i).Cells("borrowerdate").Value
                dr("file_qty") = gvFileBorrow.Rows(i).Cells("file_qty").Value

                Dim sqlT As String = "select r.app_no, isnull(fl.floor_name + ' ' + ro.room_name, isnull(ft.location_name,'ห้องแฟ้มชั้น 6')) last_location" & vbNewLine
                sqlT += " from TB_FILEBORROWITEM bi" & vbNewLine
                sqlT += " inner join TB_REQUISTION r on r.id=bi.requisition_id" & vbNewLine
                sqlT += " left join TS_FILE_CURRENT_LOCATION fc on r.app_no=fc.app_no" & vbNewLine
                sqlT += " left join MS_ROOM ro on ro.id=fc.ms_room_id" & vbNewLine
                sqlT += " left join MS_FLOOR fl on fl.id=ro.ms_floor_id" & vbNewLine
                sqlT += " left join TB_FILELOCATION ft on ft.id=r.filelocation" & vbNewLine
                sqlT += " where bi.fileborrow_id='" & gvFileBorrow.Rows(i).Cells("fileborrow_id").Value & "'"
                Dim dtT As DataTable = SqlDB.ExecuteTable(sqlT)
                If dtT.Rows.Count > 0 Then
                    Dim TagList As String = ""
                    For Each dtR As DataRow In dtT.Rows
                        If TagList = "" Then
                            TagList = dtR("app_no") & "," & dtR("last_location")
                        Else
                            TagList += "##" & dtR("app_no") & "," & dtR("last_location")
                        End If
                    Next
                    dr("tag_list") = TagList
                End If

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
    

    Private Sub cbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAll.CheckedChanged
        If cbAll.Checked = True Then
            For i As Integer = 0 To gvFileBorrow.RowCount - 1
                gvFileBorrow.Rows(i).Cells("chkSelect").Value = "Y"
            Next
        Else
            For i As Integer = 0 To gvFileBorrow.RowCount - 1
                gvFileBorrow.Rows(i).Cells("chkSelect").Value = "N"
            Next
        End If
    End Sub

    Private Sub btnSendTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendTo.Click
        dtValue = New DataTable
        Dim dt As DataTable = GetBorrowData()
        Dim rapi As New RAPI
        If rapi.DevicePresent = False Then
            MsgBox("อุปกรณ์ต่อพ่วงไม่มีการเชื่อมต่อ")
            Exit Sub
        ElseIf dt.Rows.Count = 0 Then
            MsgBox("กรุณาเลือกใบยืมที่ต้องการส่งข้อมูลไปยัง Handheld")
            Exit Sub
        End If

        Dim frm As New frmMobile
        frm.FileBorrowList = dt
        frm.SyncFor = frmMobile.TASK_TYPE.Export
        frm.ShowDialog()
        ShowData()
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

        ShowData()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        ShowData()
    End Sub
End Class