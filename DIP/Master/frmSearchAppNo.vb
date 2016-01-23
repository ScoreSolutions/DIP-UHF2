Imports DIP_RFID.DAL.Table

Public Class frmSearchAppNo

    Public dt As New DataTable
    Public AppNo As String = ""
    Public AppNo_From As String = ""

    Private Sub frmReserveOfficee_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        GridAppNo.DataSource = dt.DefaultView.ToTable(False, "APP_NO")
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        dt.DefaultView.RowFilter = "APP_NO LIKE '%" & txtSearch.Text.Trim.Replace("'", "''") & "%'"
        GridAppNo.DataSource = dt.DefaultView
    End Sub

    Private Sub GridAppNo_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GridAppNo.CellMouseDoubleClick
        AppNo = GridAppNo.Rows(e.RowIndex).Cells("APP_NO").Value.ToString
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

End Class