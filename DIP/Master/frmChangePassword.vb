Imports DIP_RFID.DAL.Common.Utilities
Imports DIP_RFID.DAL.Table
Imports System.Data


Public Class frmChangePassword

    Private Sub btnChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click
        If ValidateData() = True Then
            Dim trans As New SqlTransactionDB
            trans.CreateTransaction()
            Dim dal As New TbOfficerDAL
            dal.GetDataByUSERNAME(frmMain.txtUserName.Text, Nothing)
            dal.PASSWORD = Func.GetEncrypt(txtPwd.Text.Trim)
            If dal.UpdateByUSERNAME(txtUsername.Text, frmMain.txtUserName.Text, trans.Trans) = False Then
                trans.RollbackTransaction()
                MsgBox(dal.ErrorMessage, MsgBoxStyle.Critical)

            Else
                trans.CommitTransaction()
                MsgBox("เปลี่ยนรหัสผ่านเรียบร้อย กรุณาเข้าระบบอีกครั้งด้วยรหัสผ่านใหม่", MsgBoxStyle.Information)

                frmLogin.Visible = True
                frmLogin.txtFormName.Text = ""
                frmLogin.txtUserName.Text = ""
                frmLogin.txtPassword.Text = ""

                frmMain.Visible = False
                frmMain.txtUserName.Text = ""
            End If
        End If
    End Sub

    Private Function ValidateData() As Boolean
        Dim ret As Boolean = True
        If txtPwd.Text.Trim = "" Then
            ret = False
            MsgBox("กรุณาระบุรหัสผ่านใหม่", MsgBoxStyle.Exclamation)
            txtPwd.Focus()
        ElseIf txtPwd.Text.Trim <> txtConfPwd.Text.Trim Then
            ret = False
            MsgBox("การยืนยันรหัสผ่านไม่ตรงกัน", MsgBoxStyle.Exclamation)
            txtConfPwd.Focus()
        End If

        Return ret
    End Function
End Class