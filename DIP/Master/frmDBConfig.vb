Imports DIP_RFID.DAL.Common.Utilities
Imports System.Data.SqlClient

Public Class frmDBConfig

    Public EventOpenProgram As Boolean = False
    Public ButtonClick As Boolean = False

    Private Sub frmDBConfig_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If EventOpenProgram = True Then
            If ButtonClick = False Then
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtServer.Text.Trim = "" Or txtDB.Text.Trim = "" Or txtUser.Text.Trim = "" Then
            MessageBox.Show("Please enter all required information" & Environment.NewLine & "- Server" & Environment.NewLine & "- Database Name" & Environment.NewLine & "- Username", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else

            If CheckConn(getConnectionStrTest) = False Then
                txtServer.Focus()
                Exit Sub
            End If

            Dim ini As New IniReader(INIFlieName)
            ini.Section = "SETTING"
            ini.Write("Server", txtServer.Text)
            ini.Write("Database", txtDB.Text)
            ini.Write("Username", txtUser.Text)
            ini.Write("Password", txtPass.Text)
            ButtonClick = True
            Me.Close()
        End If

    End Sub

    Private Sub txtServer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtServer.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If txtServer.Text <> "" Then
                txtDB.Focus()
            End If
        End If
    End Sub

    Private Sub txtDB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDB.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If txtDB.Text <> "" Then
                txtUser.Focus()
            End If
        End If
    End Sub

    Private Sub txtUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUser.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If txtUser.Text <> "" Then
                txtPass.Focus()
            End If
        End If
    End Sub

    Private Sub txtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPass.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If txtPass.Text <> "" Then
                btnSave.Focus()
            End If
        End If
    End Sub

    Private Sub frmDBConfig_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim ini As New IniReader(INIFlieName)
        ini.Section = "SETTING"

        If Dir(INIFlieName) <> "" Then
            txtServer.Text = ini.ReadString("Server")
            txtDB.Text = ini.ReadString("Database")
            txtUser.Text = ini.ReadString("Username")
            txtPass.Text = ini.ReadString("Password")
        Else
            ini.Write("Server", "127.0.0.1")
            ini.Write("Database", "")
            ini.Write("Username", "sa")
            ini.Write("Password", "1234")
            txtServer.Text = ini.ReadString("Server")
            txtDB.Text = ini.ReadString("Database")
            txtUser.Text = ini.ReadString("Username")
            txtPass.Text = ini.ReadString("Password")
        End If
    End Sub

    Function getConnectionStrTest() As String
        Return "Data Source=" & txtServer.Text & ";Initial Catalog=" & txtDB.Text.Trim & ";Persist Security Info=True;User ID=" & txtUser.Text.Trim & ";Password=" & txtPass.Text.Trim & ";"
    End Function

    Private Sub frmDBConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
