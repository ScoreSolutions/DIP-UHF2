Imports DIP_RFID.DAL.Table
Imports DIP_RFID.Data.Table
Imports DIP_RFID.DAL.Common.Utilities

Public Class frmReserveOfficer

    Dim TbReserve As New TbOfficerDAL
    Dim trans As New SqlTransactionDB
    'Dim dt As New DataTable
    Public Name As String = ""
    Public OfficerID As String = ""
    Dim dt As DataTable

    Sub ShowData()

        Dim sql As String = "select o.id,o.officer_no,ltrim(isnull(t.title_name,'') + isnull(o.fname,'') + ' ' + isnull(o.lname,'')) as fullname "
        sql += " from TB_OFFICER o"
        sql += " left join tb_title t on t.id=o.title_id"
        sql += " order by o.fname"

        dt = TbReserve.GetListBySql(sql, "", Nothing)

        If dt.Rows.Count > 0 Then
            With GridOfficer
                .DataSource = dt
            End With
        End If
    End Sub

    Private Sub frmReserveOfficee_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ShowData()
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        Try
            dt.DefaultView.RowFilter = "fullname like '%" & txtSearch.Text.Trim.Replace("'", "''") & "%'"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GridOfficer_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GridOfficer.CellMouseDoubleClick
        Try
            OfficerID = GridOfficer.Rows(e.RowIndex).Cells("id").Value.ToString
            Name = GridOfficer.Rows(e.RowIndex).Cells("fullname").Value.ToString
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception : End Try

    End Sub

End Class