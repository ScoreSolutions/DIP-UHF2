Imports DIP_RFID.DAL.Common.Utilities

Public Class frmSearchAppnoHistory

    Sub ShowData()
        If txtSearch.Text.Trim <> "" Then
            Dim sql As String = ""
            Dim dt As New DataTable
            sql = "exec dbo.SEARCH_APP '" & txtSearch.Text.Replace("'", "''") & "'"
            dt = SqlDB.ExecuteTable(sql)
            gdvData.DataSource = dt
        End If
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        ShowData()
        txtSearch.Focus()
        txtSearch.SelectAll()
    End Sub

    Private Sub frmSearchAppnoHistory_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtSearch.Focus()
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If Asc(e.KeyChar) = 13 Then
            ShowData()
            txtSearch.Focus()
            txtSearch.SelectAll()
        End If
    End Sub
End Class