Imports DIP_RFID.Data.Common.Utilities
Imports DIP_RFID.DAL.Common.Utilities
Imports DIP_RFID.Data.Table
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.View

Public Class frmMain

    'Dim dtAlarm As New DataTable

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

    Private Sub mnuReserve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReserve.Click
        CloseAllForm()
        Dim frmLogin As New frmLogin
        frmLogin.txtFormName.Text = Constant.FormName.FormReserve
        If frmLogin.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim frm As New frmReserve
            ShowForm(frm)
        End If
    End Sub

    Private Sub mnuTitleName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTitleName.Click
        Dim frm As New frmTitle
        ShowForm(frm)
    End Sub

    Private Sub mnuOfficer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOfficer.Click
        Dim frm As New frmOfficerSearch
        ShowForm(frm)
    End Sub

    Private Sub mnuShutdownProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShutdownProgram.Click
        Dim frm As New frmShutdownProgram
        ShowForm(frm)
    End Sub

    Private Sub mnuPatentType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPatentType.Click
        Dim frm As New frmPatentType
        ShowForm(frm)
    End Sub

    Private Sub mnuPermission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPermission.Click
        Dim frm As New frmPermission
        ShowForm(frm)
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub mnuShutdownMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShutdownMenu.Click
        Dim frm As New frmShutdownMenu
        ShowForm(frm)
    End Sub

    Private Sub mnuBorrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBorrow.Click
        txtDocumentEvent.Text = "borrow"
        CloseAllForm()
        Dim frmLogin As New frmLogin
        frmLogin.txtFormName.Text = Constant.FormName.FormBorrow
        If frmLogin.ShowDialog = Windows.Forms.DialogResult.OK Then
            'If Func.IsUpdateActionModule("1", Trim(txtUserName.Text)) Then
            If Func.IsUpdateActionModule("1", "1") Then

                Dim frm As New frmBorrow
                ShowForm(frm)
            Else
                MessageBox.Show("Can't update SetActionModule.")
            End If
        End If
    End Sub

    Private Sub mnuReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuReturn.Click
        txtDocumentEvent.Text = "return"
        CloseAllForm()
        Dim frmLogin As New frmLogin
        frmLogin.txtFormName.Text = Constant.FormName.FormReturn
        If frmLogin.ShowDialog = Windows.Forms.DialogResult.OK Then
            'If Func.IsUpdateActionModule("2", Trim(txtUserName.Text)) Then
            If Func.IsUpdateActionModule("2", "2") Then
                Dim frm As New frmReturns
                ShowForm(frm)
            Else
                MessageBox.Show("Can't update SetActionModule.")
            End If
        End If
    End Sub

    Private Sub mnuTransfer_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTransfer.Click
        txtDocumentEvent.Text = "location"
        CloseAllForm()
        Dim frmLogin As New frmLogin
        frmLogin.txtFormName.Text = Constant.FormName.FormTransfer
        If frmLogin.ShowDialog = Windows.Forms.DialogResult.OK Then
            'If Func.IsUpdateActionModule("3", Trim(txtUserName.Text)) Then
            If Func.IsUpdateActionModule("3", "2") Then
                Dim frm As New frmTransfer
                ShowForm(frm)
            Else
                MessageBox.Show("Can't update SetActionModule.")
            End If
        End If
    End Sub

    'Function IsUpdateActionModule(ByVal Type As String) As Boolean
    '    Dim IsUpdate As Boolean = True
    '    Try
    '        Dim Trans As New SqlTransactionDB
    '        Trans.CreateTransaction()
    '        Dim dal As New TbSetModuleDAL
    '        dal.GetDataList("rederid=", Trans.Trans)
    '        dal.SETACTION = Type
    '        dal.UpdateByPK(Me.txtIdUser.Text, Trans.Trans)

    '        Trans.CommitTransaction()
    '    Catch ex As Exception
    '        IsUpdate = False
    '    End Try

    '    Return IsUpdate
    'End Function

    'Private Sub mnuReportsBorrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsBorrow.Click
    '    'Dim frm As New frm_Check_Outt
    '    'ShowForm(frm)
    'End Sub

    'Private Sub mnuReportsReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsReturn.Click
    '    Dim frm As New frm_Check_INN
    '    ShowForm(frm)
    'End Sub

    Private Sub mnuReportsHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsHistory.Click
        Dim frm As New frmFileHistory
        ShowForm(frm)

    End Sub

    'Private Sub mnuReportOfficer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm As New frm_statistics
    '    ShowForm(frm)
    'End Sub

    Private Sub mnuDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepartment.Click
        Dim frm As New frmDepartment
        ShowForm(frm)
    End Sub

    Private Sub mnuPosition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPosition.Click
        Dim frm As New frmPosition
        ShowForm(frm)
    End Sub

    Private Sub tmrCurrDate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCurrDate.Tick
        StatusStrip1.Items("stlCurrDate").Text = "วันที่ : " & Date.Now.ToString("dd/MM/yyyy HH:mm:ss")
    End Sub

    Private Sub AutoShutdownMenu(ByVal trans As SqlClient.SqlTransaction)
        'ตรวจสอบการตั้งเวลาเปิดเมนู ยืมคืน
        For Each mdl As ToolStripMenuItem In MenuStrip1.Items
            Dim i As Integer = 0
            For Each mnu As ToolStripItem In mdl.DropDownItems
                Dim CloseMenuDal As New TbShutdownsMenuDAL
                Dim dtm As DataTable = CloseMenuDal.GetDataList("convert(varchar(10),close_datetime,120) = '" & SqlDB.GetDateNow("D", trans) & "' and com_name ='" & My.Computer.Name & "' and s_status = 'Y'", "close_datetime", trans)
                For Each dr As DataRow In dtm.Rows
                    Dim CloseMenuData As New TbShutdownsMenuData
                    CloseMenuData = CloseMenuDal.GetDataByid(dr("id"), trans)
                    If CloseMenuData.CLOSE_DATETIME.ToString("HH:mm") <= DateTime.Now.ToString("HH:mm") Then
                        Dim menuDal As New TbMenuDAL
                        menuDal.GetDataByid(CloseMenuData.MENU_ID, trans)
                        If mnu.Name = menuDal.MENU_URL Then
                            mnu.Enabled = False
                            i += 1
                        End If
                    End If
                Next
            Next
            If mdl.DropDownItems.Count > 0 And mdl.DropDownItems.Count = i Then
                mdl.Enabled = False
            End If
        Next
    End Sub
    Private Sub AutoShutdownSystem(ByVal trans As SqlClient.SqlTransaction)
        'ตรวจสอบการตั้งเวลาปิดโปรแกรม
        Dim ShutDowndal As New TbShutdownDAL
        Dim dtp As DataTable = ShutDowndal.GetDataList("convert(varchar(10),close_datetime,120) = '" & SqlDB.GetDateNow("D", trans) & "' and s_status = 'Y' and com_name = '" & My.Computer.Name & "'", "close_datetime", trans)

        For Each dr As DataRow In dtp.Rows
            Dim ShutDownData As New TbShutdownData
            ShutDownData = ShutDowndal.GetDataByid(dr("id"), trans)

            'ตั้งเวลาเตือนล่วงหน้า
            Dim autoShutdownWarning As Integer = Func.GetSetupValue("Shutdown_Warning", trans)
            Dim closeTime As DateTime = ShutDownData.CLOSE_DATETIME
            Dim diffTime As Integer = DateDiff(DateInterval.Minute, DateTime.Now, closeTime)
            If diffTime <= autoShutdownWarning Then
                If diffTime <= 0 Then
                    End
                Else
                    MsgBox("ระบบจะปิดอัตโนมัติในอีก " & diffTime & " นาที", MsgBoxStyle.Exclamation)
                End If
            End If
        Next
    End Sub

    Private Sub tmrBGProcess_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrBGProcess.Tick
        Dim trans As New SqlTransactionDB
        trans.CreateTransaction()
        AutoShutdownSystem(trans.Trans)
        AutoShutdownMenu(trans.Trans)
        trans.CommitTransaction()
    End Sub

    Private Sub tmrChkAlarm_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrChkAlarm.Tick
        Try
            Dim trans As New SqlTransactionDB
            trans.CreateTransaction()
            Dim dal As New TbSetAlarmDAL
            If dal.ChkDataByWhere("setalarm = 'Y' and ReaderId=" & Func.GetReaderId, trans.Trans) = True Then
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

        For Each mdl As ToolStripMenuItem In MenuStrip1.Items
            mdl.Enabled = True
            For Each mnu As ToolStripItem In mdl.DropDownItems
                mnu.Enabled = True
            Next
        Next

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
        mnuShutdownProgram.Enabled = False
        mnuShutdownMenu.Enabled = False
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
        mnuSearchOfficerByDepartment.Enabled = False
        'mnuAgent.Enabled = False
        'mnuTransfer.Enabled = False
        'mnufloor_count.Enabled = False
        'mnumove.Enabled = False
        'mnuSearchFileborrow.Enabled=False

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
            Case "mnuShutdownProgram"
                mnuShutdownProgram.Enabled = True
            Case "mnuShutdownMenu"
                mnuShutdownMenu.Enabled = True
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
                'Case "mnuAgent"
                '   mnuAgent.Enabled = True
                'Case "mnuTransfer"
                '    mnuTransfer.Enabled = True
                'Case "mnufloor_count"
                '    mnufloor_count.Enabled = True
                'Case "mnumove"
                '    mnumove.Enabled = True
                'Case "mnuSearchFileborrow"
                '    mnuSearchFileborrow.Enabled = True
        End Select
    End Sub

    Private Sub mnuLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLogout.Click
        CloseAllForm()
        frmLogin.Visible = True
        frmLogin.txtFormName.Text = ""
        frmLogin.txtUserName.Text = ""
        frmLogin.txtPassword.Text = ""

        Me.Visible = False
        Me.txtUserName.Text = ""
    End Sub

    Private Sub mnuChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChangePassword.Click
        Dim frm As New frmChangePassword
        frm.txtUsername.Text = txtUserName.Text
        ShowForm(frm)
    End Sub

    Public Sub ApplyVisible()
        Dim trans As New SqlTransactionDB
        trans.CreateTransaction()
        AutoShutdownSystem(trans.Trans)
        AutoShutdownMenu(trans.Trans)
        SetAuthMenu(trans.Trans)
        trans.CommitTransaction()
    End Sub

    Private Sub frmMain_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        ApplyVisible()
        Dim version As System.Version = System.Reflection.Assembly.GetExecutingAssembly.GetName().Version
        Me.Text = Me.Text.Replace("%_%", version.Major & "." & version.Minor & "." & version.Build)
    End Sub

    Private Sub mnuBorrowByOfficer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBorrowByOfficer.Click
        Dim frm As New frmBorrowByOfficer
        ShowForm(frm)
    End Sub

    Private Sub mnuBorrowByDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBorrowByDepartment.Click
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

    Private Sub mnuBorrowAllOfficer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBorrowAllOfficer.Click
        'checkOut_Checked = 8
        'ViewReport_CheckOut.Show()
        Dim frm As New frmBorrowWithName
        ShowForm(frm)
    End Sub

    Private Sub mnuBorrowByDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBorrowByDate.Click
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

    Private Sub mnuReturnByOfficer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReturnByOfficer.Click
        Dim frm As New frmReturnByOfficer
        ShowForm(frm)
    End Sub

    Private Sub mnuReturnByDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReturnByDepartment.Click
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

    Private Sub mnuReturnByDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReturnByDate.Click
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

    Private Sub mnuBorrowNoReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBorrowNoReturn.Click
        Dim frm As New frmBorrowNoReturn
        ShowForm(frm)
    End Sub

    Private Sub mnuBorrowBetween_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBorrowBetween.Click
        Dim frm As New frmBorrowBetween
        ShowForm(frm)
    End Sub

    Private Sub mnuPerform_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPerform.Click
        Dim frm As New frmPerform
        ShowForm(frm)
    End Sub

    Private Sub mnuGraphAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGraphAll.Click
        Dim frm As New frmGraphAll
        ShowForm(frm)
    End Sub

    Private Sub mnuGraphBorrowByDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGraphBorrowByDepartment.Click
        Dim frm As New frmGraphByDepartment
        ShowForm(frm)
    End Sub

    Private Sub mnuGraphBorrowByPatentType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGraphBorrowByPatentType.Click
        Dim frm As New frmGraphByPatentType
        ShowForm(frm)
    End Sub

    Private Sub mnuGraphByOfficer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGraphByOfficer.Click
        Dim frm As New frmGraphByOfficer
        ShowForm(frm)
    End Sub

    Private Sub mnuStatisticsBorrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStatisticsBorrow.Click
        Dim frm As New frmStatisticsBorrow
        ShowForm(frm)
    End Sub

    Private Sub mnuStatisticsReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStatisticsReturn.Click
        Dim frm As New frmStatisticsReturn
        ShowForm(frm)
    End Sub

    Private Sub mnuStatisticsByOfficer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStatisticsByOfficer.Click
        Dim frm As New frmStatisticsByOfficer
        ShowForm(frm)
    End Sub

    Private Sub mnuSubFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSubFile.Click
        Dim frm As New frmSubfile
        ShowForm(frm)
    End Sub

    Private Sub mnuMifare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMifare.Click
        Dim frm As New frmMifare
        ShowForm(frm)
    End Sub

    Private Sub mnuHandheld_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHandheld.Click
        Dim frm As New frmSearchHistoryFromHandheld
        ShowForm(frm)
    End Sub

    Private Sub mnuShelf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShelf.Click
        Dim frm As New frmShelfName
        ShowForm(frm)
    End Sub

    Private Sub DatabaseSettingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatabaseSettingToolStripMenuItem.Click
        Dim frm As New frmDBConfig
        ShowForm(frm)
    End Sub

    Private Sub mnuCounterReader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCounterReader.Click
        Dim frm As New frmCounterReader
        ShowForm(frm)
    End Sub

    Private Sub mnuHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelp_admin.Click
        Dim HelpProvider1 As New HelpProvider
        HelpProvider1.HelpNamespace = Application.StartupPath + "/help_admin.chm"
        'HelpProvider1.HelpNamespace = Application.StartupPath + "/ConvertData_v0r1_kug20100628.doc"
        'HelpProvider1.HelpNamespace = Application.StartupPath + "/DIP_UM_v1r0_tae270111.doc"
        Help.ShowHelp(Me, HelpProvider1.HelpNamespace)
    End Sub

    Private Sub mnuHelp_user_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelp_user.Click
        Dim HelpProvider1 As New HelpProvider
        HelpProvider1.HelpNamespace = Application.StartupPath + "/help_user.chm"
        Help.ShowHelp(Me, HelpProvider1.HelpNamespace)
    End Sub

    Private Sub mnuSearchOfficerByDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSearchOfficerByDepartment.Click
        Dim frm As New frmOfficerSearchByDepartment
        ShowForm(frm)
    End Sub

    'Private Sub mnuAgent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If System.IO.File.Exists(Windows.Forms.Application.StartupPath & "\DB_Agent\DIP_DbAgent.exe") Then
    '        Dim proc As New Process()
    '        proc.StartInfo.FileName = Windows.Forms.Application.StartupPath & "\DB_Agent\DIP_DbAgent.exe"
    '        proc.StartInfo.Arguments = ""
    '        proc.Start()
    '    Else
    '        MessageBox.Show("File cannot be found!" & vbCrLf & Windows.Forms.Application.StartupPath & "\DB_Agent\DIP_DbAgent.exe", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End If
    'End Sub

    Private Sub mnuSearchAppno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSearchAppno.Click
        Dim frm As New frmSearchAppnoHistory
        ShowForm(frm)
    End Sub

    Private Sub mnuReportTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportTransfer.Click
        Dim frm As New frmTransferByLocation
        ShowForm(frm)
    End Sub

    Private Sub menu_floor_count_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnufloor_count.Click
        txtDocumentEvent.Text = "floorcount"
        Dim frm As New frmFloorCount
        ShowForm(frm)
    End Sub

    Private Sub menu_move_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnumove.Click
        txtDocumentEvent.Text = "floormove"
        Dim frm As New frmFloorMove
        ShowForm(frm)
    End Sub

    Private Sub mnuSearchFileborrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSearchFileborrow.Click
        txtDocumentEvent.Text = "frmBorrowToHandheld"
        Dim frm As New frmBorrowToHandheld
        ShowForm(frm)
    End Sub

    Private Sub mnuLastLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLastLocation.Click
        txtDocumentEvent.Text = "frmFileLastLocation"
        Dim frm As New frmFileLastLocation
        ShowForm(frm)
    End Sub
End Class