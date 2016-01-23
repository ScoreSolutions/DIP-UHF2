Imports System.Data.SqlClient
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.Common.Utilities

Public Class frmPosition

    Dim dal As New TbPositionDAL
    Dim trans As New SqlTransactionDB

    Sub Add()
        txtPositionCode.Enabled = True
        txtPositionName.Enabled = True
        txtPositionCode.Focus()
        GridPosition.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
        btnAdd.Enabled = False
    End Sub

    Sub Clear()
        txtPositionCode.Text = ""
        txtPositionName.Text = ""
        txtID.Text = ""
        txtPositionCode.Enabled = False
        txtPositionName.Enabled = False
        GridPosition.Enabled = True
        btnAdd.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Private Function Validation() As Boolean
        Dim ret As Boolean = True
        If txtPositionCode.Text.Trim = "" Then
            ret = False
            MsgBox("กรุณากรอกรหัสตำแหน่ง")
            txtPositionCode.Focus()
        ElseIf txtPositionName.Text.Trim = "" Then
            ret = False
            MsgBox("กรุณากรอกชื่อตำแหน่ง")
            txtPositionName.Focus()
        ElseIf ChkId(Nothing) = True Then
            ret = False
            MsgBox("รหัสตำแหน่งซ้ำกับข้อมูลในระบบ")
            txtPositionCode.Focus()
        ElseIf ChkName(Nothing) = True Then
            ret = False
            MsgBox("ชื่อตำแหน่งซ้ำกับข้อมูลในระบบ")
            txtPositionName.Focus()
        End If
        Return ret
    End Function

    Private Function ChkId(ByVal trans As SqlTransaction) As Boolean
        Dim dal As New TbPositionDAL
        Return dal.ChkDataByWhere("position_code = '" & txtPositionCode.Text.Replace("'", "''") & "' and id <> '" & Val(txtID.Text) & "'", trans)
    End Function

    Private Function ChkName(ByVal trans As SqlTransaction) As Boolean
        Dim dal As New TbPositionDAL
        Return dal.ChkDataByWhere("position_name = '" & txtPositionName.Text.Replace("'", "''") & "' and id <> '" & Val(txtID.Text) & "'", trans)
    End Function

    Private Sub ShowData()
        Dim dt As New DataTable
        dt = dal.GetDataList("", "position_name", Nothing)
        GridPosition.AutoGenerateColumns = False
        GridPosition.DataSource = dal.GetDataList("", "position_code", Nothing)
    End Sub

    Private Sub frmPosition_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ShowData()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Validation() Then
            Dim ret As Boolean = True
            dal = New TbPositionDAL
            If txtID.Text = "" Then
                'Insert
                dal.POSITION_CODE = txtPositionCode.Text.Trim
                dal.POSITION_NAME = txtPositionName.Text.Trim
                ret = dal.InsertData(frmMain.txtUserName.Text, trans.Trans)
            Else
                'Update
                dal.GetDataByid(txtID.Text, trans.Trans)
                dal.POSITION_CODE = txtPositionCode.Text.Trim
                dal.POSITION_NAME = txtPositionName.Text.Trim
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

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Add()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Clear()
    End Sub

    Private Sub GridPosition_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GridPosition.CellMouseDoubleClick
        If GridPosition.RowCount > 0 Then
            Add()
            txtPositionCode.Text = GridPosition.SelectedRows(0).Cells("position_code").Value.ToString.Trim
            txtPositionName.Text = GridPosition.SelectedRows(0).Cells("position_name").Value.ToString.Trim
            txtID.Text = GridPosition.SelectedRows(0).Cells("id").Value.ToString.Trim
            txtPositionName.Focus()
            txtPositionName.SelectAll()
        End If
    End Sub

    Private Sub txtPositionCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPositionCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtPositionName.Focus()
        End If
    End Sub

    Private Sub txtPositionName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPositionName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnSave.Focus()
        End If
    End Sub
End Class