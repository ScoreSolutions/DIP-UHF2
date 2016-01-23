Imports DIP_RFID.Data.Common.Utilities
Imports DIP_RFID.DAL.Common.Utilities
Imports DIP_RFID.Data.Table
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.View

Public Class frmMenuNew

    Private Sub ShowForm(ByVal frm As Form)
        CloseAllForm()
        frm.MdiParent = Me
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.Show()
    End Sub

    Private Sub CloseAllForm()
        For Each fm In Me.MdiChildren
            fm.Close()
            fm.Dispose()
        Next
    End Sub

    Private Sub mnuReserve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CloseAllForm()
        Dim frmLogin As New frmLogin
        frmLogin.txtFormName.Text = Constant.FormName.FormReserve
        If frmLogin.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim frm As New frmAutoupdate
            ShowForm(frm)
        End If
    End Sub

    Private Sub mnuTitleName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmTitle
        ShowForm(frm)
    End Sub

    Private Sub mnuOfficer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmOfficerSearch
        ShowForm(frm)
    End Sub

    Private Sub mnuShutdownProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmShutdownProgram
        ShowForm(frm)
    End Sub

    Private Sub mnuPatentType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmPatentType
        ShowForm(frm)
    End Sub

    Private Sub mnuPermission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmPermission
        ShowForm(frm)
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub mnuShutdownMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmShutdownMenu
        ShowForm(frm)
    End Sub

    Private Sub mnuBorrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtDocumentEvent.Text = "borrow"
        CloseAllForm()
        Dim frmLogin As New frmLogin
        frmLogin.txtFormName.Text = Constant.FormName.FormBorrow
        If frmLogin.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IsUpdateActionModule("1") Then
                Dim frm As New frmBorrow
                ShowForm(frm)
            Else
                MessageBox.Show("Can't update SetActionModule.")
            End If
        End If
    End Sub

    Private Sub mnuReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        txtDocumentEvent.Text = "return"
        CloseAllForm()
        Dim frmLogin As New frmLogin
        frmLogin.txtFormName.Text = Constant.FormName.FormReturn
        If frmLogin.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IsUpdateActionModule("2") Then
                Dim frm As New frmReturns
                ShowForm(frm)
            Else
                MessageBox.Show("Can't update SetActionModule.")
            End If
        End If
    End Sub

    Private Sub mnuTransfer_click(ByVal sender As Object, ByVal e As System.EventArgs)
        txtDocumentEvent.Text = "location"
        CloseAllForm()
        Dim frmLogin As New frmLogin
        frmLogin.txtFormName.Text = Constant.FormName.FormTransfer
        If frmLogin.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IsUpdateActionModule("3") Then
                Dim frm As New frmTransfer
                ShowForm(frm)
            Else
                MessageBox.Show("Can't update SetActionModule.")
            End If
        End If
    End Sub

    Function IsUpdateActionModule(ByVal Type As String) As Boolean
        Dim IsUpdate As Boolean = True
        Try
            Dim Trans As New SqlTransactionDB
            Trans.CreateTransaction()
            Dim dal As New tbsetmoduledal
            dal.GetDataByID("1", Trans.Trans)
            dal.setaction = Type
            dal.UpdateByPK(Me.txtIdUser.Text, Trans.Trans)

            Trans.CommitTransaction()
        Catch ex As Exception
            IsUpdate = False
        End Try

        Return IsUpdate
    End Function

    'Private Sub mnuReportsBorrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsBorrow.Click
    '    'Dim frm As New frm_Check_Outt
    '    'ShowForm(frm)
    'End Sub

    'Private Sub mnuReportsReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsReturn.Click
    '    Dim frm As New frm_Check_INN
    '    ShowForm(frm)
    'End Sub

    Private Sub mnuReportsHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmFileHistory
        ShowForm(frm)

    End Sub

    'Private Sub mnuReportOfficer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm As New frm_statistics
    '    ShowForm(frm)
    'End Sub

    Private Sub mnuDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmDepartment
        ShowForm(frm)
    End Sub

    Private Sub mnuPosition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmPosition
        ShowForm(frm)
    End Sub

    Private Sub tmrCurrDate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCurrDate.Tick
        StatusStrip1.Items("stlCurrDate").Text = "วันที่ : " & Date.Now.ToString("dd/MM/yyyy HH:mm:ss")
    End Sub

    'Private Sub AutoShutdownMenu(ByVal trans As SqlClient.SqlTransaction)
    '    'ตรวจสอบการตั้งเวลาเปิดเมนู ยืมคืน
    '    For Each mdl As ToolStripMenuItem In MenuStrip1.Items
    '        Dim i As Integer = 0
    '        For Each mnu As ToolStripItem In mdl.DropDownItems
    '            Dim CloseMenuDal As New TbShutdownsMenuDAL
    '            Dim dtm As DataTable = CloseMenuDal.GetDataList("convert(varchar(10),close_datetime,120) = '" & SqlDB.GetDateNow("D", trans) & "' and com_name ='" & My.Computer.Name & "' and s_status = 'Y'", "close_datetime", trans)
    '            For Each dr As DataRow In dtm.Rows
    '                Dim CloseMenuData As New TbShutdownsMenuData
    '                CloseMenuData = CloseMenuDal.GetDataByid(dr("id"), trans)
    '                If CloseMenuData.CLOSE_DATETIME.ToString("HH:mm") <= DateTime.Now.ToString("HH:mm") Then
    '                    Dim menuDal As New TbMenuDAL
    '                    menuDal.GetDataByid(CloseMenuData.MENU_ID, trans)
    '                    If mnu.Name = menuDal.MENU_URL Then
    '                        mnu.Enabled = False
    '                        i += 1
    '                    End If
    '                End If
    '            Next
    '        Next
    '        If mdl.DropDownItems.Count > 0 And mdl.DropDownItems.Count = i Then
    '            mdl.Enabled = False
    '        End If
    '    Next
    'End Sub
    'Private Sub AutoShutdownSystem(ByVal trans As SqlClient.SqlTransaction)
    '    'ตรวจสอบการตั้งเวลาปิดโปรแกรม
    '    Dim ShutDowndal As New TbShutdownDAL
    '    Dim dtp As DataTable = ShutDowndal.GetDataList("convert(varchar(10),close_datetime,120) = '" & SqlDB.GetDateNow("D", trans) & "' and s_status = 'Y' and com_name = '" & My.Computer.Name & "'", "close_datetime", trans)

    '    For Each dr As DataRow In dtp.Rows
    '        Dim ShutDownData As New TbShutdownData
    '        ShutDownData = ShutDowndal.GetDataByid(dr("id"), trans)

    '        'ตั้งเวลาเตือนล่วงหน้า
    '        Dim autoShutdownWarning As Integer = Func.GetSetupValue("Shutdown_Warning", trans)
    '        Dim closeTime As DateTime = ShutDownData.CLOSE_DATETIME
    '        Dim diffTime As Integer = DateDiff(DateInterval.Minute, DateTime.Now, closeTime)
    '        If diffTime <= autoShutdownWarning Then
    '            If diffTime <= 0 Then
    '                End
    '            Else
    '                MsgBox("ระบบจะปิดอัตโนมัติในอีก " & diffTime & " นาที", MsgBoxStyle.Exclamation)
    '            End If
    '        End If
    '    Next
    'End Sub

    Private Sub tmrBGProcess_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrBGProcess.Tick
        Dim trans As New SqlTransactionDB
        trans.CreateTransaction()
        'AutoShutdownSystem(trans.Trans)
        'AutoShutdownMenu(trans.Trans)
        trans.CommitTransaction()
    End Sub

    Private Sub tmrChkAlarm_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrChkAlarm.Tick
        Try
            Dim trans As New SqlTransactionDB
            trans.CreateTransaction()
            Dim dal As New TbSetAlarmDAL
            If dal.ChkDataByWhere("setalarm = 'Y'", trans.Trans) = True Then
                tmrChkAlarm.Enabled = False

                Dim dtAlarm As New DataTable
                dtAlarm.Columns.Add("id")
                dtAlarm.Columns.Add("app_no")

                If GetGateConsole(trans.Trans) = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
                'frmAlarm.SetGridView(dtAlarm)
                frmAlarm.WindowState = FormWindowState.Maximized
                'frmAlarm.WindowState = FormWindowState.Normal
                frmAlarm.Visible = True
                Me.Visible = False
            Else
                trans.RollbackTransaction()
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Function GetGateConsole(ByVal trans As SqlClient.SqlTransaction) As Boolean

        Dim ret As Boolean = False
        Try
            Dim lDal As New TbGateConsoleLogDAL
            Dim dt As DataTable = lDal.GetDataList("isalarm='Y' and alarm_disable_time is null", "app_no", trans)   'ค่าที่ได้มากจาก Gate

            For Each dgr As DataRow In dt.Rows
                Dim dal As New TmpFileborrowItemDAL
                dal.GetDataByAPP_NO(dgr("app_no"), trans)
                If dal.HaveData = False Then  'ตรวจสอบค่าที่ได้จาก Gate แล้วไม่ใช่รายการที่ถูกยืม
                    'ดึงข้อมูลเพื่อแสดงในหน้าจอ Alarm
                    'Dim dr As DataRow = dtAlarm.NewRow
                    'dr("id") = dgr("id")
                    'dr("app_no") = dgr("app_no")
                    'dtAlarm.Rows.Add(dr)

                    'Insert Alarm Log
                    Dim rDal As New TbRequisitionDAL
                    rDal.GetDataByAPP_NO(dgr("app_no"), trans)
                    Dim aDal As New TbAlarmLogDAL
                    aDal.ALARM_DATETIME = DateTime.Now
                    aDal.REQUISITION_ID = rDal.ID
                    ret = aDal.InsertData(txtUserName.Text.Trim, trans)
                End If
            Next
        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function

    Private Sub SetAuthMenu(ByVal trans As SqlClient.SqlTransaction)

        'For Each mdl As ToolStripMenuItem In MenuStrip1.Items
        '    mdl.Enabled = True
        '    For Each mnu As ToolStripItem In mdl.DropDownItems
        '        mnu.Enabled = True
        '    Next
        'Next

        Dim oDal As New TbOfficerDAL
        oDal.GetDataByUSERNAME(txtUserName.Text.Trim, trans)
        If Func.ChkUserPermission(oDal.ID, Func.GetSetupValue("AdminRole", trans), trans) = False And oDal.USERNAME <> "admin" Then
            'ถ้าเป็น Admin ก็ไม่ต้องทำในส่วนนี้
            'For Each mdl As ToolStripMenuItem In MenuStrip1.Items
            '    Dim i As Integer = 0
            '    For Each mnu As ToolStripItem In mdl.DropDownItems
            '        Dim AuthMenuDal As New OfficerMenuListDAL
            '        Dim dtm As DataTable = AuthMenuDal.GetDataList("menu_url = '" & mnu.Name & "'", "", trans)
            '        If dtm.Rows.Count = 0 Then
            '            mnu.Enabled = False
            '            i += 1
            '        End If
            '    Next
            '    If mdl.DropDownItems.Count > 0 And mdl.DropDownItems.Count = i Then
            '        mdl.Enabled = False
            '    End If
            'Next

            '***** Hardcode ในส่วนของเมนู  *****
            CheckMenu(oDal.ID)
        End If
    End Sub

    Sub CheckMenu(ByVal OfficeID As String)
        mnuReserve.Enabled = False
        mnuBorrow.Enabled = False
        mnuReturn.Enabled = False
        mnuBorrowByOfficer.Enabled = False
        mnuBorrowByDepartment.Enabled = False
        mnuBorrowByDate.Enabled = False
        mnuBorrowBetween.Enabled = False
        mnuBorrowNoReturn.Enabled = False
        mnuBorrowAllOfficer.Enabled = False
        mnuReturnByOfficer.Enabled = False
        mnuReturnByDepartment.Enabled = False
        mnuReturnByDate.Enabled = False
        mnuStatisticsBorrow.Enabled = False
        mnuStatisticsReturn.Enabled = False
        mnuStatisticsByOfficer.Enabled = False
        mnuPerform.Enabled = False
        mnuReportsHistory.Enabled = False
        mnuGraphAll.Enabled = False
        mnuGraphBorrowByDepartment.Enabled = False
        mnuGraphBorrowByPatentType.Enabled = False
        mnuGraphByOfficer.Enabled = False
        'mnuShutdownProgram.Enabled = False
        'mnuShutdownMenu.Enabled = False
        mnuPermission.Enabled = False
        mnuOfficer.Enabled = False
        mnuDepartment.Enabled = False
        mnuPosition.Enabled = False
        mnuTitleName.Enabled = False
        mnuPatentType.Enabled = False
        mnuShelf.Enabled = False
        mnuSubFile.Enabled = False
        mnuHandheld.Enabled = False
        mnuMifare.Enabled = False
        mnuCounterReader.Enabled = False
        'mnuSearchOfficerByDepartment.Enabled = False
        mnuAgent.Enabled = False

        Dim AuthMenuDal As New OfficerMenuListDAL
        Dim dtmenu As DataTable = AuthMenuDal.GetDataList("officer_id = '" & OfficeID & "'", "", Nothing)
        If dtmenu.Rows.Count > 0 Then
            For i As Int32 = 0 To dtmenu.Rows.Count - 1
                CheckMenuNotDisable(dtmenu.Rows(i).Item("menu_url").ToString.Trim)
            Next
        End If

    End Sub

    Sub CheckMenuNotDisable(ByVal MenuName As String)
        Select Case MenuName
            Case "mnuReserve"
                mnuReserve.Enabled = True
            Case "mnuBorrow"
                mnuBorrow.Enabled = True
            Case "mnuReturn"
                mnuReturn.Enabled = True
            Case "mnuBorrowByOfficer"
                mnuBorrowByOfficer.Enabled = True
            Case "mnuBorrowByDepartment"
                mnuBorrowByDepartment.Enabled = True
            Case "mnuBorrowByDate"
                mnuBorrowByDate.Enabled = True
            Case "mnuBorrowBetween"
                mnuBorrowBetween.Enabled = True
            Case "mnuBorrowNoReturn"
                mnuBorrowNoReturn.Enabled = True
            Case "mnuBorrowAllOfficer"
                mnuBorrowAllOfficer.Enabled = True
            Case "mnuReturnByOfficer"
                mnuReturnByOfficer.Enabled = True
            Case "mnuReturnByDepartment"
                mnuReturnByDepartment.Enabled = True
            Case "mnuReturnByDate"
                mnuReturnByDate.Enabled = True
            Case "mnuStatisticsBorrow"
                mnuStatisticsBorrow.Enabled = True
            Case "mnuStatisticsReturn"
                mnuStatisticsReturn.Enabled = True
            Case "mnuStatisticsByOfficer"
                mnuStatisticsByOfficer.Enabled = True
            Case "mnuPerform"
                mnuPerform.Enabled = True
            Case "mnuReportsHistory"
                mnuReportsHistory.Enabled = True
            Case "mnuGraphAll"
                mnuGraphAll.Enabled = True
            Case "mnuGraphBorrowByDepartment"
                mnuGraphBorrowByDepartment.Enabled = True
            Case "mnuGraphBorrowByPatentType"
                mnuGraphBorrowByPatentType.Enabled = True
            Case "mnuGraphByOfficer"
                mnuGraphByOfficer.Enabled = True
                'Case "mnuShutdownProgram"
                '    mnuShutdownProgram.Enabled = True
                'Case "mnuShutdownMenu"
                '    mnuShutdownMenu.Enabled = True
            Case "mnuPermission"
                mnuPermission.Enabled = True
            Case "mnuOfficer"
                mnuOfficer.Enabled = True
            Case "mnuDepartment"
                mnuDepartment.Enabled = True
            Case "mnuPosition"
                mnuPosition.Enabled = True
            Case "mnuTitleName"
                mnuTitleName.Enabled = True
            Case "mnuPatentType"
                mnuPatentType.Enabled = True
            Case "mnuShelf"
                mnuShelf.Enabled = True
            Case "mnuSubFile"
                mnuSubFile.Enabled = True
            Case "mnuHandheld"
                mnuHandheld.Enabled = True
            Case "mnuMifare"
                mnuMifare.Enabled = True
            Case "mnuCounterReader"
                mnuCounterReader.Enabled = True
            Case "mnuSearchOfficerByDepartment"
                mnuSearchOfficerByDepartment.Enabled = True
            Case "mnuAgent"
                mnuAgent.Enabled = True
        End Select
    End Sub

    Private Sub mnuLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CloseAllForm()
        frmLogin.Visible = True
        frmLogin.txtFormName.Text = ""
        frmLogin.txtUserName.Text = ""
        frmLogin.txtPassword.Text = ""

        Me.Visible = False
        Me.txtUserName.Text = ""
    End Sub

    Private Sub mnuChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmChangePassword
        frm.txtUsername.Text = txtUserName.Text
        ShowForm(frm)
    End Sub

    Public Sub ApplyVisible()
        Dim trans As New SqlTransactionDB
        trans.CreateTransaction()
        'AutoShutdownSystem(trans.Trans)
        'AutoShutdownMenu(trans.Trans)
        'SetAuthMenu(trans.Trans)
        trans.CommitTransaction()
    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        C1Ribbon1.Minimized = True
    End Sub

    Private Sub frmMain_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        ApplyVisible()
        Dim version As System.Version = System.Reflection.Assembly.GetExecutingAssembly.GetName().Version
        Me.Text = Me.Text.Replace("%_%", version.Major & "." & version.Minor & "." & version.Build)
    End Sub

    Private Sub mnuBorrowByOfficer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmBorrowByOfficer
        ShowForm(frm)
    End Sub

    Private Sub mnuBorrowByDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmBorrowByDepartment
        ShowForm(frm)
    End Sub

    Private Sub mnuBorrowByPatentType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmBorrowByPatentType
        ShowForm(frm)
    End Sub

    Private Sub mnuBorrowByMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmBorrowByMonth
        ShowForm(frm)
    End Sub

    Private Sub mnuBorrowAllOfficer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'checkOut_Checked = 8
        'ViewReport_CheckOut.Show()
        Dim frm As New frmBorrowWithName
        ShowForm(frm)
    End Sub

    Private Sub mnuBorrowByDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmBorrowByDate
        ShowForm(frm)
    End Sub

    Private Sub mnuBorrowByAppNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmBorrowByAppNo
        ShowForm(frm)
    End Sub

    Private Sub mnuBorrowByYear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmBorrowByYear
        ShowForm(frm)
    End Sub

    Private Sub mnuReturnByOfficer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmReturnByOfficer
        ShowForm(frm)
    End Sub

    Private Sub mnuReturnByDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmReturnByDepartment
        ShowForm(frm)
    End Sub

    Private Sub mnuReturnByPatentType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmTransferByLocation
        ShowForm(frm)
    End Sub

    Private Sub mnuReturnByAppNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmReturnByRequistion
        ShowForm(frm)
    End Sub

    Private Sub mnuReturnByDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmReturnByDay
        ShowForm(frm)
    End Sub

    Private Sub mnuReturnByMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmReturnByMonth
        ShowForm(frm)
    End Sub

    Private Sub mnuReturnByYear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmReturnByYear
        ShowForm(frm)
    End Sub

    Private Sub mnuBorrowNoReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmBorrowNoReturn
        ShowForm(frm)
    End Sub

    Private Sub mnuBorrowBetween_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmBorrowBetween
        ShowForm(frm)
    End Sub

    Private Sub mnuPerform_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmPerform
        ShowForm(frm)
    End Sub

    Private Sub mnuGraphAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmGraphAll
        ShowForm(frm)
    End Sub

    Private Sub mnuGraphBorrowByDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmGraphByDepartment
        ShowForm(frm)
    End Sub

    Private Sub mnuGraphBorrowByPatentType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmGraphByPatentType
        ShowForm(frm)
    End Sub

    Private Sub mnuGraphByOfficer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmGraphByOfficer
        ShowForm(frm)
    End Sub

    Private Sub mnuStatisticsBorrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmStatisticsBorrow
        ShowForm(frm)
    End Sub

    Private Sub mnuStatisticsReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmStatisticsReturn
        ShowForm(frm)
    End Sub

    Private Sub mnuStatisticsByOfficer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmStatisticsByOfficer
        ShowForm(frm)
    End Sub

    Private Sub mnuSubFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmSubfile
        ShowForm(frm)
    End Sub

    Private Sub mnuMifare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmMifare
        ShowForm(frm)
    End Sub

    Private Sub mnuHandheld_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmSearchHistoryFromHandheld
        ShowForm(frm)
    End Sub

    Private Sub mnuShelf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmShelfName
        ShowForm(frm)
    End Sub

    Private Sub DatabaseSettingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmDBConfig
        ShowForm(frm)
    End Sub

    Private Sub mnuCounterReader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmCounterReader
        ShowForm(frm)
    End Sub

    Private Sub mnuHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim HelpProvider1 As New HelpProvider
        HelpProvider1.HelpNamespace = Application.StartupPath + "/help_admin.chm"
        'HelpProvider1.HelpNamespace = Application.StartupPath + "/ConvertData_v0r1_kug20100628.doc"
        'HelpProvider1.HelpNamespace = Application.StartupPath + "/DIP_UM_v1r0_tae270111.doc"
        Help.ShowHelp(Me, HelpProvider1.HelpNamespace)
    End Sub

    Private Sub mnuHelp_user_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim HelpProvider1 As New HelpProvider
        HelpProvider1.HelpNamespace = Application.StartupPath + "/help_user.chm"
        Help.ShowHelp(Me, HelpProvider1.HelpNamespace)
    End Sub

    Private Sub mnuSearchOfficerByDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmOfficerSearchByDepartment
        ShowForm(frm)
    End Sub

    Private Sub mnuAgent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If System.IO.File.Exists(Windows.Forms.Application.StartupPath & "\DB_Agent\DIP_DbAgent.exe") Then
            Dim proc As New Process()
            proc.StartInfo.FileName = Windows.Forms.Application.StartupPath & "\DB_Agent\DIP_DbAgent.exe"
            proc.StartInfo.Arguments = ""
            proc.Start()
        Else
            MessageBox.Show("File cannot be found!" & vbCrLf & Windows.Forms.Application.StartupPath & "\DB_Agent\DIP_DbAgent.exe", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub RibbonButton36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton36.Click
        mnuLogout_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton1.Click
        mnuReserve_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton2.Click
        mnuBorrow_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton3.Click
        mnuReturn_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton4.Click
        mnuTransfer_click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPermission.Click
        mnuPermission_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton6.Click
        mnuOfficer_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton7.Click
        mnuDepartment_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton8.Click
        mnuPosition_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton9.Click
        mnuTitleName_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton10.Click
        mnuPatentType_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton11.Click
        mnuShelf_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton12.Click
        mnuSubFile_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton13.Click
        mnuMifare_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton14.Click
        mnuCounterReader_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton15.Click
        mnuChangePassword_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton16.Click
        DatabaseSettingToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton37.Click
        mnuAgent_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBorrowByOfficer.Click
        mnuBorrowByOfficer_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBorrowByDepartment.Click
        mnuBorrowByDepartment_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBorrowByDate.Click
        mnuBorrowByDate_Click(Nothing, Nothing)
    End Sub


    Private Sub RibbonButton20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBorrowBetween.Click
        mnuBorrowBetween_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBorrowNoReturn.Click
        mnuBorrowNoReturn_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBorrowAllOfficer.Click
        mnuBorrowAllOfficer_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReturnByOfficer.Click
        mnuReturnByOfficer_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReturnByDepartment.Click
        mnuReturnByDepartment_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReturnByDate.Click
        mnuReturnByDate_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStatisticsBorrow.Click
        mnuStatisticsBorrow_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStatisticsReturn.Click
        mnuStatisticsReturn_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStatisticsByOfficer.Click
        mnuStatisticsByOfficer_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton26.Click
        mnuPerform_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton27.Click
        mnuReportsHistory_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGraphAll.Click
        mnuGraphAll_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGraphBorrowByDepartment.Click
        mnuGraphBorrowByDepartment_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGraphBorrowByPatentType.Click
        mnuGraphBorrowByPatentType_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGraphByOfficer.Click
        mnuGraphByOfficer_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton28.Click
        mnuHandheld_Click(Nothing, Nothing)
    End Sub

    Private Sub RibbonButton33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton33.Click
        Dim HelpProvider1 As New HelpProvider
        HelpProvider1.HelpNamespace = Application.StartupPath + "/help_admin.chm"
        'HelpProvider1.HelpNamespace = Application.StartupPath + "/ConvertData_v0r1_kug20100628.doc"
        'HelpProvider1.HelpNamespace = Application.StartupPath + "/DIP_UM_v1r0_tae270111.doc"
        Help.ShowHelp(Me, HelpProvider1.HelpNamespace)
    End Sub

    Private Sub RibbonButton34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton34.Click
        Dim HelpProvider1 As New HelpProvider
        HelpProvider1.HelpNamespace = Application.StartupPath + "/help_user.chm"
        Help.ShowHelp(Me, HelpProvider1.HelpNamespace)
    End Sub

    Private Sub RibbonButton35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton35.Click
        mnuSearchOfficerByDepartment_Click(Nothing, Nothing)
    End Sub
End Class
