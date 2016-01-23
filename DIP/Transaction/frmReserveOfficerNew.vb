Imports DIP_RFID.DAL.Table
Imports DIP_RFID.Data.Table
Imports DIP_RFID.DAL.Common.Utilities

Public Class frmReserveOfficerNew

    Dim TbReserve As New TbOfficerDAL
    Dim trans As New SqlTransactionDB
    'Dim dt As New DataTable
    Public Name As String = ""
    Public OfficerID As String = ""
    Dim dt As DataTable

    Sub ShowData()
        Dim sql As String = "select distinct rtrim(ltrim(isnull(t.title_name,'') + isnull(o.fname,'') + ' ' + isnull(o.lname,''))) as fullname,o.fname from TB_OFFICER o left join tb_title t on t.id=o.title_id order by o.fname"
        dt = TbReserve.GetListBySql(sql, "", Nothing)
        If dt.Rows.Count > 0 Then
            With GridOfficer
                .DataSource = dt
            End With
        End If
    End Sub

    Function FindOfficerId(ByVal Name As String) As String
        Dim id As String = ""
        Dim sql As String = "select o.officer_no, rtrim(ltrim(isnull(t.title_name,'') + isnull(o.fname,'') + ' ' + isnull(o.lname,''))) as fullname from TB_OFFICER o left join tb_title t on t.id=o.title_id where rtrim(ltrim(isnull(t.title_name,'') + isnull(o.fname,'') + ' ' + isnull(o.lname,''))) = '" & Name & "'"
        dt = TbReserve.GetListBySql(sql, "", Nothing)

        If dt.Rows.Count > 0 Then
            For i As Int32 = 0 To dt.Rows.Count - 1
                If id = "" Then
                    id = dt.Rows(i).Item("officer_no").ToString
                Else
                    id = id & "','" & dt.Rows(i).Item("officer_no").ToString
                End If
            Next
        End If
        Return id
    End Function

    Private Sub frmReserveOfficee_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ShowData()
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        dt.DefaultView.RowFilter = "fullname like '%" & txtSearch.Text.Trim.Replace("'", "''") & "%'"
    End Sub

    Private Sub GridOfficer_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GridOfficer.CellMouseDoubleClick
        Try
            OfficerID = FindOfficerId(GridOfficer.Rows(e.RowIndex).Cells("fullname").Value.ToString)
            Name = GridOfficer.Rows(e.RowIndex).Cells("fullname").Value.ToString
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception : End Try

    End Sub

   
End Class