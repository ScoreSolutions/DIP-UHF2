Imports System.Data
Imports DIP_RFID.DAL
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.Data.Table
Imports DIP_RFID.Data.Common.Utilities
Imports DIP_RFID.DAL.Common.Utilities
Imports System.IO
Imports Desktop_Reader
Imports DIP_RFID.DAL.Common.Utilities.Func


Public Class frmLogin
    Dim d As New Desktop_Reader.ReadCommand

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        Dim trans As New SqlTransactionDB
        Dim dal As New TbOfficerDAL
        Dim data As New TbOfficerData


        data = dal.GetDataByUSERNAME(txtUserName.Text, trans.Trans)
        If dal.HaveData = True Then
            If data.PASSWORD = Func.GetEncrypt(txtPassword.Text) Then
                'If data.PASSWORD = txtPassword.Text Then  ''   ffdfd
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Visible = False

                CreateExistShutdown()
                frmMain.txtUserName.Text = data.USERNAME
                frmMain.txtIdUser.Text = data.OFFICER_NO
                frmMain.Show()
                frmMain.ApplyVisible()

                Dim titleData As New TbTitleData
                Dim titleDAL As New TbTitleDAL
                titleData = titleDAL.GetDataByid(dal.TITLE_ID, trans.Trans)
                frmMain.StatusStrip1.Items("stlOfficerName").Text = "ชื่อผู้ใช้งาน : " & titleData.TITLE_NAME & data.FNAME & " " & data.LNAME & "   "
                frmMain.StatusStrip1.Items("stlCurrDate").Text = "วันที่ : " & Date.Now.ToString("dd/MM/yyyy HH:mm")
                frmMain.txtFullUserName.Text = titleData.TITLE_NAME & data.FNAME & " " & data.LNAME
                frmMain.Focus()

                If txtFormName.Text.Trim = "" Then
                    If Func.ChkUserMenu(data.ID, Constant.MenuName.FrmReserve.MenuID, trans.Trans) = True Or Func.ChkUserPermission(data.ID, Func.GetSetupValue("AdminRole", trans.Trans), trans.Trans) = True Or data.USERNAME = "admin" Then
                        Dim frm As New frmReserve
                        'Dim frm As New frmAutoupdate
                        frm.MdiParent = frmMain
                        frm.StartPosition = FormStartPosition.CenterParent
                        frm.Show()
                    End If
                ElseIf txtFormName.Text.Trim = Constant.FormName.FormReserve Then
                    If Func.ChkUserMenu(data.ID, Constant.MenuName.FrmReserve.MenuID, trans.Trans) = True Or Func.ChkUserPermission(data.ID, Func.GetSetupValue("AdminRole", trans.Trans), trans.Trans) = True Or data.USERNAME = "admin" Then
                        Dim frm As New frmReserve
                        frm.MdiParent = frmMain
                        frm.StartPosition = FormStartPosition.CenterParent
                        frm.Show()
                    Else
                        MsgBox("ผู้ใช้ไม่มีสิทธิ์")
                        Me.DialogResult = Windows.Forms.DialogResult.Cancel
                        Me.Visible = True
                        Exit Sub
                    End If

                    'Dim frm As New frmReserve
                    'frm.MdiParent = frmMain
                    'frm.StartPosition = FormStartPosition.CenterParent
                    'frm.Show()
                ElseIf txtFormName.Text.Trim = Constant.FormName.FormBorrow Then
                    If Func.ChkUserMenu(data.ID, Constant.MenuName.FrmBorrow.MenuID, trans.Trans) = True Or Func.ChkUserPermission(data.ID, Func.GetSetupValue("AdminRole", trans.Trans), trans.Trans) = True Or data.USERNAME = "admin" Then
                        Dim frm As New frmBorrow
                        frm.MdiParent = frmMain
                        frm.StartPosition = FormStartPosition.CenterParent
                        frm.Show()
                    Else
                        MsgBox("ผู้ใช้ไม่มีสิทธิ์")
                        Me.DialogResult = Windows.Forms.DialogResult.Cancel
                        Me.Visible = True
                        Exit Sub
                    End If


                    'Dim frm As New frmBorrow
                    'frm.MdiParent = frmMain
                    'frm.StartPosition = FormStartPosition.CenterParent
                    'frm.Show()
                ElseIf txtFormName.Text.Trim = Constant.FormName.FormReturn Then
                    If Func.ChkUserMenu(data.ID, Constant.MenuName.FrmReturn.MenuID, trans.Trans) = True Or Func.ChkUserPermission(data.ID, Func.GetSetupValue("AdminRole", trans.Trans), trans.Trans) = True Or data.USERNAME = "admin" Then
                        Dim frm As New frmReturns
                        frm.MdiParent = frmMain
                        frm.StartPosition = FormStartPosition.CenterParent
                        frm.Show()
                    Else
                        MsgBox("ผู้ใช้ไม่มีสิทธิ์")
                        Me.DialogResult = Windows.Forms.DialogResult.Cancel
                        Me.Visible = True
                        Exit Sub
                    End If


                    'Dim frm As New frmReturns
                    'frm.MdiParent = frmMain
                    'frm.StartPosition = FormStartPosition.CenterParent
                    'frm.Show()
                End If
            Else
                MsgBox("รหัสผ่านไม่ถูกต้อง")
                txtPassword.Text = ""
                txtUserName.Focus()
            End If
        Else
            txtPassword.Text = ""
            txtUserName.Focus()
            MsgBox("ไม่พบข้อมูลผู้ใช้")
        End If
    End Sub

    Private Sub ShowOperationForm(ByVal frm As Form)

    End Sub

    Private Sub CreateExistShutdown()
        'Create Schedule Task สำหรับการกำหนดเวลาเปิดโปรแกรม
        Dim comName As String = My.Computer.Name
        Dim dal As New TbShutdownDAL
        Dim dt As DataTable = dal.GetDataList("com_name = '" & comName & "' and s_status='Y'", "open_datetime", Nothing)
        For Each dr As DataRow In dt.Rows
            Dim data As New TbShutdownData
            data = dal.GetDataByid(dr("id"), Nothing)
            Dim taskName = data.OPEN_DATETIME.ToString("yyyyMMddhhmm")
            'MsgBox(taskName)

            'Create Window Schedule Task

        Next
    End Sub

    Private Sub txtUserName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            If txtUserName.Text.Trim = "" Then

                Dim ini As New IniReader(INIFlieName)
                ini.Section = "SETTING"

                Dim ctl As New MifareControl
                Dim port As Int32 = ini.ReadString("MF_ComPort")
                Dim bund As Int32 = ini.ReadString("MF_BaudRate")
                If ctl.Connect(port, bund) = True Then
                    Dim act As MifareControl.ActivityStatus
                    act = ctl.SelectTag()

                    If act.Available = True Then

                        Dim dal As New TbOfficerDAL
                        dal.GetDataByMIFARE_CARD_ID(act.Result, Nothing)
                        If dal.HaveData = True Then
                            txtUserName.Text = dal.USERNAME
                            txtPassword.Focus()
                            'Else
                            '    Timer1.Enabled = False
                            '    MessageBox.Show("ไม่พบข้อมูลผู้ใช้")
                            '    'Timer1.Enabled = True
                        End If
                    End If

                    ctl.DisConnect()
                    'If txtUserName.Text.Trim <> "" Then
                    '    Timer1.Enabled = False
                    'End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmLogin_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtUserName.Focus()

    End Sub

    Private Sub frmLogin_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If CkeckConfigDB() = False Then
            Dim f As New frmDBConfig
            f.EventOpenProgram = True
            f.ShowDialog()
        End If

        If CkeckConfigMifare() = False Then
            Dim f As New frmMifare
            f.EventOpenProgram = True
            f.ShowDialog()
        End If
        If CkeckConfigCounterReader() = False Then
            Dim f As New frmCounterReader
            f.EventOpenProgram = True
            f.ShowDialog()
        End If
        Timer1.Enabled = True

    End Sub

    'Private Sub txtUserName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserName.LostFocus
    '    If txtUserName.Text.Trim = "" Then
    '        Timer1.Enabled = True
    '    End If
    'End Sub

    Function CkeckConfigDB() As Boolean
        Dim ini As New IniReader(INIFlieName)
        Dim ret As Boolean
        ini.Section = "SETTING"
        If Dir(INIFlieName) = "" Then
            ret = False
        Else
            If SqlDB.ChkConnection = True Then
                ret = True
            End If
        End If
        Return ret
    End Function

    Function CkeckConfigMifare() As Boolean
        Dim ini As New IniReader(INIFlieName)
        Dim ret As Boolean
        ini.Section = "SETTING"
        If Dir(INIFlieName) = "" Then
            ret = False
        Else
            If ini.ReadString("MF_ComPort") = "" Then
                ret = False
            Else
                ret = True
            End If
        End If
        Return ret
    End Function

    Function CkeckConfigCounterReader() As Boolean
        Dim ini As New IniReader(INIFlieName)
        Dim ret As Boolean
        ini.Section = "SETTING"
        If Dir(INIFlieName) = "" Then
            ret = False
        Else
            If ini.ReadString("CR_ComPort") = "" Then
                ret = False
            Else
                ret = True
            End If
        End If
        Return ret
    End Function

    Private Sub txtUserName_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtUserName.MouseClick
        txtUserName.SelectAll()
        Timer1.Enabled = True
    End Sub
End Class