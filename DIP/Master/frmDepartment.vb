Imports System.Data.SqlClient
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL
Imports DIP_RFID.DAL.Common.Utilities

Public Class frmDepartment

    Sub Add()
        txtDepartmentCode.Enabled = True
        txtDepartmentName.Enabled = True
        txtDepartmentCode.Focus()
        GridDepartment.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
        btnAdd.Enabled = False
    End Sub

    Sub Clear()
        txtDepartmentCode.Text = ""
        txtDepartmentName.Text = ""
        txtID.Text = ""
        txtDepartmentCode.Enabled = False
        txtDepartmentName.Enabled = False
        GridDepartment.Enabled = True
        btnAdd.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Private Sub ShowData()
        Dim dal As New TbDepartmentDAL
        GridDepartment.AutoGenerateColumns = False
        GridDepartment.DataSource = dal.GetDataList("", "department_code", Nothing)
    End Sub

    Private Function Validation() As Boolean
        Dim dal As New TbDepartmentDAL
        Dim trans As New SqlTransactionDB
        Dim ret As Boolean = True
        If txtDepartmentCode.Text.Trim = "" Then
            ret = False
            MsgBox("กรุณากรอกรหัสหน่วยงาน")
            txtDepartmentCode.Focus()
        ElseIf txtDepartmentName.Text.Trim = "" Then
            ret = False
            MsgBox("กรุณากรอกชื่อหน่วยงาน")
            txtDepartmentName.Focus()
        ElseIf ChkId(Nothing) = True Then
            ret = False
            MsgBox("รหัสหน่วยงานซ้ำกับข้อมูลในระบบ")
            txtDepartmentCode.Focus()
        ElseIf ChkName(Nothing) = True Then
            ret = False
            MsgBox("ชื่อหน่วยงานซ้ำกับข้อมูลในระบบ")
            txtDepartmentName.Focus()
        End If
        Return ret
    End Function

    Private Function ChkId(ByVal trans As SqlTransaction) As Boolean
        Dim dal As New TbDepartmentDAL
        Return dal.ChkDataByWhere("department_code = '" & txtDepartmentCode.Text.Replace("'", "''") & "' and id <> '" & Val(txtID.Text) & "'", trans)
    End Function

    Private Function ChkName(ByVal trans As SqlTransaction) As Boolean
        Dim dal As New TbDepartmentDAL
        Return dal.ChkDataByWhere("department_name = '" & txtDepartmentName.Text.Replace("'", "''") & "' and id <> '" & Val(txtID.Text) & "'", trans)
    End Function


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Add()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Clear()
    End Sub

    Private Sub frmDepartment_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ShowData()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Validation() Then
            Dim dal As New TbDepartmentDAL
            Dim trans As New SqlTransactionDB
            Dim ret As Boolean = True
            dal = New TbDepartmentDAL
            If txtID.Text = "" Then
                'Insert
                dal.DEPARTMENT_CODE = txtDepartmentCode.Text.Trim
                dal.DEPARTMENT_NAME = txtDepartmentName.Text.Trim
                ret = dal.InsertData(frmMain.txtUserName.Text, trans.Trans)
            Else
                'Update
                dal.GetDataByid(txtID.Text, trans.Trans)
                dal.DEPARTMENT_CODE = txtDepartmentCode.Text.Trim
                dal.DEPARTMENT_NAME = txtDepartmentName.Text.Trim
                ret = dal.UpdateByid(frmMain.txtUserName.Text, trans.Trans)
            End If

            If ret = True Then
                trans.CommitTransaction()
                MsgBox("บันทึกข้อมูลเรียบร้อย")
                Clear()
                ShowData()
            Else
                trans.RollbackTransaction()
                MsgBox(dal.ErrorMessage)
            End If
        End If
    End Sub

    Private Sub GridDepartment_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GridDepartment.CellMouseDoubleClick
        If GridDepartment.RowCount > 0 Then
            Add()
            txtDepartmentCode.Text = GridDepartment.SelectedRows(0).Cells("department_code").Value.ToString.Trim
            txtDepartmentName.Text = GridDepartment.SelectedRows(0).Cells("department_name").Value.ToString.Trim
            txtID.Text = GridDepartment.SelectedRows(0).Cells("id").Value.ToString.Trim
            txtDepartmentName.Focus()
            txtDepartmentName.SelectAll()
        End If
    End Sub

    Private Sub txtDepartmentCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDepartmentCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtDepartmentName.Focus()
        End If
    End Sub

    Private Sub txtDepartmentName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDepartmentName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnSave.Focus()
        End If
    End Sub
End Class