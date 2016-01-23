Public Class frmPreviewMobile

    Public Datasource As DataTable

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub FormPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GridSample.DataSource = Datasource.DefaultView
    End Sub

    Private Sub GridSample_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles GridSample.DataError
    End Sub

End Class