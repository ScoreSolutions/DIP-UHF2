Imports System.Data
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.Common.Utilities

Public Class frmOfficerSearch

    Dim SqlDB As New SqlDB
    Dim dal_position As New TbPositionDAL
    Dim dal_department As New TbDepartmentDAL
    Dim dal_officer As New TbOfficerDAL
    Dim dt As New DataTable
    Dim sql As String = ""
    Dim trans As New SqlTransactionDB

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim f As New frmOfficer
        f.ShowDialog()
        'Me.Close()
    End Sub

    Private Sub frmOfficerSearch_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.ControlBox = False
    End Sub

    Private Sub frmOfficerSearch_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        With cbPosition
            .DataSource = dal_position.GetListBySql("select 0 as id, ' --------เลือก--------' as position_name union all select id,position_name  from TB_POSITION", "position_name", Nothing)
            .ValueMember = "id"
            .DisplayMember = "position_name"
        End With

        With cbDepartment
            .DataSource = dal_department.GetListBySql("select 0 as id, ' --------เลือก--------' as department_name union all select id,department_name  from TB_DEPARTMENT", "department_name", Nothing)
            .ValueMember = "id"
            .DisplayMember = "department_name"
        End With

        ShowData("")
    End Sub

    Sub ShowData(ByVal Where As String)
        'sql = "select ltrim(isnull(d.title_name,'') + isnull(fname,'') + ' ' + isnull(lname,'')) as fullname,position_name,department_name"
        'sql &= " ,a.id,officer_no,title_id,fname,lname,position_id,department_id,username,[password] "
        'sql &= " from TB_OFFICER a left join TB_DEPARTMENT b on a.department_id = b.id"
        'sql &= " left join TB_POSITION c on a.position_id = c.id left join TB_TITLE d on a.title_id = d.id"
        sql = "select tb2.id,tb1.fullname,tb2.officer_no,position_name,department_name  from (select MAX(officer_no) as of_no,ltrim(isnull(title_name,'') + isnull(fname,'') + ' ' + isnull(lname,'')) as fullname  from TB_OFFICER x left join TB_TITLE y on x.title_id = y.id group by title_name,fname,lname ) as tb1 left join TB_OFFICER as tb2 on tb1.of_no = tb2.officer_no left join TB_DEPARTMENT tb3 on tb2.department_id = tb3.id left join TB_POSITION tb4 on tb2.position_id = tb4.id"
        dt = dal_position.GetListBySql(sql, "fullname", trans.Trans)
        If Where <> "" Then
            dt.DefaultView.RowFilter = Where
        End If
        GridOfficer.AutoGenerateColumns = False
        GridOfficer.DataSource = dt

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtName.Text = ""
        cbDepartment.SelectedIndex = 0
        cbPosition.SelectedIndex = 0
        ShowData("")
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim txt As String = ""
        If txtName.Text <> "" Then
            txt = "fullname like '%" & txtName.Text.Trim.Replace("'", "''") & "%' "
        End If

        If cbPosition.SelectedValue > 0 Then
            If txt = "" Then
                txt = "position_id = '" & cbPosition.SelectedValue.ToString & "' "
            Else
                txt = txt & "and position_id = '" & cbPosition.SelectedValue.ToString & "' "
            End If
        End If

        If cbDepartment.SelectedValue > 0 Then
            If txt = "" Then
                txt = "department_id = '" & cbDepartment.SelectedValue.ToString & "' "
            Else
                txt = txt & "and department_id = '" & cbDepartment.SelectedValue.ToString & "' "
            End If
        End If
        ShowData(txt)
    End Sub

    Private Sub GridOfficer_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridOfficer.CellDoubleClick
        Dim f As New frmOfficer
        'Dim dal As New TbOfficerDAL

        'dal.GetDataByid(GridOfficer.Rows(e.RowIndex).Cells("id").Value, Nothing)
        f.txtId.Text = GridOfficer.Rows(e.RowIndex).Cells("id").Value
        f.ShowDialog()
    End Sub

    Private Sub GridOfficer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridOfficer.CellContentClick

    End Sub
End Class