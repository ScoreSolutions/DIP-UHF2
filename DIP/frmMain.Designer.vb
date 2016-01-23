<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.Menu1 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuReserve = New System.Windows.Forms.ToolStripMenuItem
        Me.mdlBorRet = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuBorrow = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuReturn = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTransfer = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu3 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuReportsBorrow = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuBorrowByOfficer = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuBorrowByDepartment = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuBorrowByDate = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuBorrowBetween = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuBorrowNoReturn = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuBorrowAllOfficer = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuReportsReturn = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuReturnByOfficer = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuReturnByDepartment = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuReturnByDate = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStatistics = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStatisticsBorrow = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStatisticsReturn = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStatisticsByOfficer = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPerform = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuReportsHistory = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuGraph = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuGraphBorrowAll = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuGraphAll = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuGraphBorrowByDepartment = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuGraphBorrowByPatentType = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuGraghPerform = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuGraphByOfficer = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHandheld = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuReportTransfer = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu4 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuShutdownProgram = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuShutdownMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPermission = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuOfficer = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDepartment = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPosition = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTitleName = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPatentType = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuShelf = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSubFile = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMifare = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCounterReader = New System.Windows.Forms.ToolStripMenuItem
        Me.mnufloor_count = New System.Windows.Forms.ToolStripMenuItem
        Me.mnumove = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSearchFileborrow = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHelp_admin = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHelp_user = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSearchOfficerByDepartment = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSearchAppno = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuChangePassword = New System.Windows.Forms.ToolStripMenuItem
        Me.DatabaseSettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLogout = New System.Windows.Forms.ToolStripMenuItem
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.tmrCurrDate = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.stsOfficerName = New System.Windows.Forms.ToolStripStatusLabel
        Me.stlOfficerName = New System.Windows.Forms.ToolStripStatusLabel
        Me.stlCurrDate = New System.Windows.Forms.ToolStripStatusLabel
        Me.tmrBGProcess = New System.Windows.Forms.Timer(Me.components)
        Me.tmrChkAlarm = New System.Windows.Forms.Timer(Me.components)
        Me.txtFullUserName = New System.Windows.Forms.TextBox
        Me.txtIdUser = New System.Windows.Forms.TextBox
        Me.txtDocumentEvent = New System.Windows.Forms.TextBox
        Me.mnuLastLocation = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu1, Me.mdlBorRet, Me.Menu3, Me.Menu4, Me.MenuHelp, Me.mnuChangePassword, Me.DatabaseSettingToolStripMenuItem, Me.mnuLogout})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(10, 2, 0, 2)
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(969, 27)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Menu1
        '
        Me.Menu1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuReserve})
        Me.Menu1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Menu1.Image = CType(resources.GetObject("Menu1.Image"), System.Drawing.Image)
        Me.Menu1.Name = "Menu1"
        Me.Menu1.Size = New System.Drawing.Size(95, 23)
        Me.Menu1.Text = "รายการจอง"
        '
        'mnuReserve
        '
        Me.mnuReserve.Image = CType(resources.GetObject("mnuReserve.Image"), System.Drawing.Image)
        Me.mnuReserve.Name = "mnuReserve"
        Me.mnuReserve.Size = New System.Drawing.Size(172, 24)
        Me.mnuReserve.Text = "ข้อมูลการจองแฟ้ม"
        '
        'mdlBorRet
        '
        Me.mdlBorRet.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBorrow, Me.mnuReturn, Me.mnuTransfer})
        Me.mdlBorRet.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.mdlBorRet.Image = CType(resources.GetObject("mdlBorRet.Image"), System.Drawing.Image)
        Me.mdlBorRet.Name = "mdlBorRet"
        Me.mdlBorRet.Size = New System.Drawing.Size(116, 23)
        Me.mdlBorRet.Text = "ยืม - คืน - ย้าย"
        '
        'mnuBorrow
        '
        Me.mnuBorrow.Image = CType(resources.GetObject("mnuBorrow.Image"), System.Drawing.Image)
        Me.mnuBorrow.Name = "mnuBorrow"
        Me.mnuBorrow.Size = New System.Drawing.Size(143, 24)
        Me.mnuBorrow.Text = "ยืมสิทธิบัตร"
        '
        'mnuReturn
        '
        Me.mnuReturn.Image = CType(resources.GetObject("mnuReturn.Image"), System.Drawing.Image)
        Me.mnuReturn.Name = "mnuReturn"
        Me.mnuReturn.Size = New System.Drawing.Size(143, 24)
        Me.mnuReturn.Text = "คืนสิทธิบัตร"
        '
        'mnuTransfer
        '
        Me.mnuTransfer.Name = "mnuTransfer"
        Me.mnuTransfer.Size = New System.Drawing.Size(143, 24)
        Me.mnuTransfer.Text = "ย้ายสิทธิบัตร"
        '
        'Menu3
        '
        Me.Menu3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuReportsBorrow, Me.mnuReportsReturn, Me.mnuStatistics, Me.mnuPerform, Me.mnuReportsHistory, Me.mnuGraph, Me.mnuHandheld, Me.mnuReportTransfer})
        Me.Menu3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Menu3.Image = CType(resources.GetObject("Menu3.Image"), System.Drawing.Image)
        Me.Menu3.Name = "Menu3"
        Me.Menu3.Size = New System.Drawing.Size(75, 23)
        Me.Menu3.Text = "รายงาน"
        '
        'mnuReportsBorrow
        '
        Me.mnuReportsBorrow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBorrowByOfficer, Me.mnuBorrowByDepartment, Me.mnuBorrowByDate, Me.mnuBorrowBetween, Me.mnuBorrowNoReturn, Me.mnuBorrowAllOfficer})
        Me.mnuReportsBorrow.Image = CType(resources.GetObject("mnuReportsBorrow.Image"), System.Drawing.Image)
        Me.mnuReportsBorrow.Name = "mnuReportsBorrow"
        Me.mnuReportsBorrow.Size = New System.Drawing.Size(298, 24)
        Me.mnuReportsBorrow.Text = "รายงานการยืมแฟ้ม"
        '
        'mnuBorrowByOfficer
        '
        Me.mnuBorrowByOfficer.Image = CType(resources.GetObject("mnuBorrowByOfficer.Image"), System.Drawing.Image)
        Me.mnuBorrowByOfficer.Name = "mnuBorrowByOfficer"
        Me.mnuBorrowByOfficer.Size = New System.Drawing.Size(265, 24)
        Me.mnuBorrowByOfficer.Text = "รายงานการยืมแฟ้ม (รายคน)"
        '
        'mnuBorrowByDepartment
        '
        Me.mnuBorrowByDepartment.Image = CType(resources.GetObject("mnuBorrowByDepartment.Image"), System.Drawing.Image)
        Me.mnuBorrowByDepartment.Name = "mnuBorrowByDepartment"
        Me.mnuBorrowByDepartment.Size = New System.Drawing.Size(265, 24)
        Me.mnuBorrowByDepartment.Text = "รายงานการยืมแฟ้ม (ตามสังกัด)"
        '
        'mnuBorrowByDate
        '
        Me.mnuBorrowByDate.Image = CType(resources.GetObject("mnuBorrowByDate.Image"), System.Drawing.Image)
        Me.mnuBorrowByDate.Name = "mnuBorrowByDate"
        Me.mnuBorrowByDate.Size = New System.Drawing.Size(265, 24)
        Me.mnuBorrowByDate.Text = "รายงานการยืมแฟ้มประจำวัน"
        '
        'mnuBorrowBetween
        '
        Me.mnuBorrowBetween.Image = CType(resources.GetObject("mnuBorrowBetween.Image"), System.Drawing.Image)
        Me.mnuBorrowBetween.Name = "mnuBorrowBetween"
        Me.mnuBorrowBetween.Size = New System.Drawing.Size(265, 24)
        Me.mnuBorrowBetween.Text = "รายงานแฟ้มที่ติดชื่อผู้ยืม (ตามสังกัด)"
        '
        'mnuBorrowNoReturn
        '
        Me.mnuBorrowNoReturn.Image = CType(resources.GetObject("mnuBorrowNoReturn.Image"), System.Drawing.Image)
        Me.mnuBorrowNoReturn.Name = "mnuBorrowNoReturn"
        Me.mnuBorrowNoReturn.Size = New System.Drawing.Size(265, 24)
        Me.mnuBorrowNoReturn.Text = "รายงานแฟ้มที่ติดชื่อผู้ยืม (รายคน)"
        '
        'mnuBorrowAllOfficer
        '
        Me.mnuBorrowAllOfficer.Image = CType(resources.GetObject("mnuBorrowAllOfficer.Image"), System.Drawing.Image)
        Me.mnuBorrowAllOfficer.Name = "mnuBorrowAllOfficer"
        Me.mnuBorrowAllOfficer.Size = New System.Drawing.Size(265, 24)
        Me.mnuBorrowAllOfficer.Text = "รายงานแฟ้มที่ติดชื่อผู้ยืมทั้งหมด"
        '
        'mnuReportsReturn
        '
        Me.mnuReportsReturn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuReturnByOfficer, Me.mnuReturnByDepartment, Me.mnuReturnByDate})
        Me.mnuReportsReturn.Image = CType(resources.GetObject("mnuReportsReturn.Image"), System.Drawing.Image)
        Me.mnuReportsReturn.Name = "mnuReportsReturn"
        Me.mnuReportsReturn.Size = New System.Drawing.Size(298, 24)
        Me.mnuReportsReturn.Text = "รายงานการคืนแฟ้ม"
        '
        'mnuReturnByOfficer
        '
        Me.mnuReturnByOfficer.Image = CType(resources.GetObject("mnuReturnByOfficer.Image"), System.Drawing.Image)
        Me.mnuReturnByOfficer.Name = "mnuReturnByOfficer"
        Me.mnuReturnByOfficer.Size = New System.Drawing.Size(239, 24)
        Me.mnuReturnByOfficer.Text = "รายงานการคืนแฟ้ม (รายคน)"
        '
        'mnuReturnByDepartment
        '
        Me.mnuReturnByDepartment.Image = CType(resources.GetObject("mnuReturnByDepartment.Image"), System.Drawing.Image)
        Me.mnuReturnByDepartment.Name = "mnuReturnByDepartment"
        Me.mnuReturnByDepartment.Size = New System.Drawing.Size(239, 24)
        Me.mnuReturnByDepartment.Text = "รายงานการคืนแฟ้ม (ตามสังกัด)"
        '
        'mnuReturnByDate
        '
        Me.mnuReturnByDate.Image = CType(resources.GetObject("mnuReturnByDate.Image"), System.Drawing.Image)
        Me.mnuReturnByDate.Name = "mnuReturnByDate"
        Me.mnuReturnByDate.Size = New System.Drawing.Size(239, 24)
        Me.mnuReturnByDate.Text = "รายงานการคืนแฟ้มประจำวัน"
        '
        'mnuStatistics
        '
        Me.mnuStatistics.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuStatisticsBorrow, Me.mnuStatisticsReturn, Me.mnuStatisticsByOfficer})
        Me.mnuStatistics.Image = CType(resources.GetObject("mnuStatistics.Image"), System.Drawing.Image)
        Me.mnuStatistics.Name = "mnuStatistics"
        Me.mnuStatistics.Size = New System.Drawing.Size(298, 24)
        Me.mnuStatistics.Text = "รายงานสถิติการยืม-คืน"
        '
        'mnuStatisticsBorrow
        '
        Me.mnuStatisticsBorrow.Image = CType(resources.GetObject("mnuStatisticsBorrow.Image"), System.Drawing.Image)
        Me.mnuStatisticsBorrow.Name = "mnuStatisticsBorrow"
        Me.mnuStatisticsBorrow.Size = New System.Drawing.Size(269, 24)
        Me.mnuStatisticsBorrow.Text = "รายงานสถิติการยืมแฟ้ม"
        '
        'mnuStatisticsReturn
        '
        Me.mnuStatisticsReturn.Image = CType(resources.GetObject("mnuStatisticsReturn.Image"), System.Drawing.Image)
        Me.mnuStatisticsReturn.Name = "mnuStatisticsReturn"
        Me.mnuStatisticsReturn.Size = New System.Drawing.Size(269, 24)
        Me.mnuStatisticsReturn.Text = "รายงานสถิติการคืนแฟ้ม"
        '
        'mnuStatisticsByOfficer
        '
        Me.mnuStatisticsByOfficer.Image = CType(resources.GetObject("mnuStatisticsByOfficer.Image"), System.Drawing.Image)
        Me.mnuStatisticsByOfficer.Name = "mnuStatisticsByOfficer"
        Me.mnuStatisticsByOfficer.Size = New System.Drawing.Size(269, 24)
        Me.mnuStatisticsByOfficer.Text = "รายงานประวัติการยืม-คืน (รายบุคคล)"
        '
        'mnuPerform
        '
        Me.mnuPerform.Image = CType(resources.GetObject("mnuPerform.Image"), System.Drawing.Image)
        Me.mnuPerform.Name = "mnuPerform"
        Me.mnuPerform.Size = New System.Drawing.Size(298, 24)
        Me.mnuPerform.Text = "รายงานการปฏิบัติงานของเจ้าหน้าที่ห้องแฟ้ม"
        '
        'mnuReportsHistory
        '
        Me.mnuReportsHistory.Image = CType(resources.GetObject("mnuReportsHistory.Image"), System.Drawing.Image)
        Me.mnuReportsHistory.Name = "mnuReportsHistory"
        Me.mnuReportsHistory.Size = New System.Drawing.Size(298, 24)
        Me.mnuReportsHistory.Text = "รายงานประวัติการยืม-การคืนแฟ้ม"
        '
        'mnuGraph
        '
        Me.mnuGraph.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuGraphBorrowAll, Me.mnuGraghPerform})
        Me.mnuGraph.Image = CType(resources.GetObject("mnuGraph.Image"), System.Drawing.Image)
        Me.mnuGraph.Name = "mnuGraph"
        Me.mnuGraph.Size = New System.Drawing.Size(298, 24)
        Me.mnuGraph.Text = "รายงานแสดงกราฟ"
        '
        'mnuGraphBorrowAll
        '
        Me.mnuGraphBorrowAll.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuGraphAll, Me.mnuGraphBorrowByDepartment, Me.mnuGraphBorrowByPatentType})
        Me.mnuGraphBorrowAll.Image = CType(resources.GetObject("mnuGraphBorrowAll.Image"), System.Drawing.Image)
        Me.mnuGraphBorrowAll.Name = "mnuGraphBorrowAll"
        Me.mnuGraphBorrowAll.Size = New System.Drawing.Size(260, 24)
        Me.mnuGraphBorrowAll.Text = "สถิติการยืม-คืน"
        '
        'mnuGraphAll
        '
        Me.mnuGraphAll.Image = CType(resources.GetObject("mnuGraphAll.Image"), System.Drawing.Image)
        Me.mnuGraphAll.Name = "mnuGraphAll"
        Me.mnuGraphAll.Size = New System.Drawing.Size(332, 24)
        Me.mnuGraphAll.Text = "กราฟแสดงรายการยืม-คืนแฟ้ม (ทั้งหมด)"
        '
        'mnuGraphBorrowByDepartment
        '
        Me.mnuGraphBorrowByDepartment.Image = CType(resources.GetObject("mnuGraphBorrowByDepartment.Image"), System.Drawing.Image)
        Me.mnuGraphBorrowByDepartment.Name = "mnuGraphBorrowByDepartment"
        Me.mnuGraphBorrowByDepartment.Size = New System.Drawing.Size(332, 24)
        Me.mnuGraphBorrowByDepartment.Text = "กราฟแสดงรายการยิม-คืนแฟ้ม (ตามสังกัด)"
        '
        'mnuGraphBorrowByPatentType
        '
        Me.mnuGraphBorrowByPatentType.Image = CType(resources.GetObject("mnuGraphBorrowByPatentType.Image"), System.Drawing.Image)
        Me.mnuGraphBorrowByPatentType.Name = "mnuGraphBorrowByPatentType"
        Me.mnuGraphBorrowByPatentType.Size = New System.Drawing.Size(332, 24)
        Me.mnuGraphBorrowByPatentType.Text = "กราฟแสดงรายการยิม-คืนแฟ้ม (ตามประเภทแฟ้ม)"
        '
        'mnuGraghPerform
        '
        Me.mnuGraghPerform.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuGraphByOfficer})
        Me.mnuGraghPerform.Image = CType(resources.GetObject("mnuGraghPerform.Image"), System.Drawing.Image)
        Me.mnuGraghPerform.Name = "mnuGraghPerform"
        Me.mnuGraghPerform.Size = New System.Drawing.Size(260, 24)
        Me.mnuGraghPerform.Text = "การปฏิบัติงานของเจ้าหน้าที่ห้องแฟ้ม"
        '
        'mnuGraphByOfficer
        '
        Me.mnuGraphByOfficer.Image = CType(resources.GetObject("mnuGraphByOfficer.Image"), System.Drawing.Image)
        Me.mnuGraphByOfficer.Name = "mnuGraphByOfficer"
        Me.mnuGraphByOfficer.Size = New System.Drawing.Size(360, 24)
        Me.mnuGraphByOfficer.Text = "กราฟแสดงรายการยืม-คืนแฟ้ม (ตามเจ้าหน้าที่ห้องแฟ้ม)"
        '
        'mnuHandheld
        '
        Me.mnuHandheld.Name = "mnuHandheld"
        Me.mnuHandheld.Size = New System.Drawing.Size(298, 24)
        Me.mnuHandheld.Text = "ประวัติการค้นหาข้อมูลจาก Handheld"
        '
        'mnuReportTransfer
        '
        Me.mnuReportTransfer.Name = "mnuReportTransfer"
        Me.mnuReportTransfer.Size = New System.Drawing.Size(298, 24)
        Me.mnuReportTransfer.Text = "รายงานการย้าย"
        '
        'Menu4
        '
        Me.Menu4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShutdownProgram, Me.mnuShutdownMenu, Me.mnuPermission, Me.mnuOfficer, Me.mnuDepartment, Me.mnuPosition, Me.mnuTitleName, Me.mnuPatentType, Me.mnuShelf, Me.mnuSubFile, Me.mnuMifare, Me.mnuCounterReader, Me.mnufloor_count, Me.mnumove, Me.mnuSearchFileborrow, Me.mnuLastLocation})
        Me.Menu4.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Menu4.Image = CType(resources.GetObject("Menu4.Image"), System.Drawing.Image)
        Me.Menu4.Name = "Menu4"
        Me.Menu4.Size = New System.Drawing.Size(92, 23)
        Me.Menu4.Text = "ข้อมูลหลัก"
        '
        'mnuShutdownProgram
        '
        Me.mnuShutdownProgram.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.mnuShutdownProgram.Image = CType(resources.GetObject("mnuShutdownProgram.Image"), System.Drawing.Image)
        Me.mnuShutdownProgram.Name = "mnuShutdownProgram"
        Me.mnuShutdownProgram.Size = New System.Drawing.Size(291, 24)
        Me.mnuShutdownProgram.Text = "กำหนดวันเวลาเปิด - ปิด โปรแกรม"
        '
        'mnuShutdownMenu
        '
        Me.mnuShutdownMenu.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.mnuShutdownMenu.Image = CType(resources.GetObject("mnuShutdownMenu.Image"), System.Drawing.Image)
        Me.mnuShutdownMenu.Name = "mnuShutdownMenu"
        Me.mnuShutdownMenu.Size = New System.Drawing.Size(291, 24)
        Me.mnuShutdownMenu.Text = "กำหนดวันเวลาเปิด - ปิด เมนูยืม-คืน"
        '
        'mnuPermission
        '
        Me.mnuPermission.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.mnuPermission.Image = CType(resources.GetObject("mnuPermission.Image"), System.Drawing.Image)
        Me.mnuPermission.Name = "mnuPermission"
        Me.mnuPermission.Size = New System.Drawing.Size(291, 24)
        Me.mnuPermission.Text = "กำหนดสิทธิ์การเข้าใช้งาน"
        '
        'mnuOfficer
        '
        Me.mnuOfficer.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.mnuOfficer.Name = "mnuOfficer"
        Me.mnuOfficer.Size = New System.Drawing.Size(291, 24)
        Me.mnuOfficer.Text = "กำหนดชื่อผู้ใช้งาน"
        '
        'mnuDepartment
        '
        Me.mnuDepartment.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.mnuDepartment.Name = "mnuDepartment"
        Me.mnuDepartment.Size = New System.Drawing.Size(291, 24)
        Me.mnuDepartment.Text = "กำหนดชื่อหน่วยงาน"
        '
        'mnuPosition
        '
        Me.mnuPosition.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.mnuPosition.Name = "mnuPosition"
        Me.mnuPosition.Size = New System.Drawing.Size(291, 24)
        Me.mnuPosition.Text = "กำหนดตำแหน่งเจ้าหน้าที่"
        '
        'mnuTitleName
        '
        Me.mnuTitleName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.mnuTitleName.Name = "mnuTitleName"
        Me.mnuTitleName.Size = New System.Drawing.Size(291, 24)
        Me.mnuTitleName.Text = "กำหนดคำนำหน้าชื่อ"
        '
        'mnuPatentType
        '
        Me.mnuPatentType.Name = "mnuPatentType"
        Me.mnuPatentType.Size = New System.Drawing.Size(291, 24)
        Me.mnuPatentType.Text = "กำหนดประเภทสิทธิบัตร"
        '
        'mnuShelf
        '
        Me.mnuShelf.Name = "mnuShelf"
        Me.mnuShelf.Size = New System.Drawing.Size(291, 24)
        Me.mnuShelf.Text = "กำหนดชั้นวางเอกสาร"
        Me.mnuShelf.Visible = False
        '
        'mnuSubFile
        '
        Me.mnuSubFile.Name = "mnuSubFile"
        Me.mnuSubFile.Size = New System.Drawing.Size(291, 24)
        Me.mnuSubFile.Text = "บันทึกข้อมูลแฟ้มต่อ"
        '
        'mnuMifare
        '
        Me.mnuMifare.Name = "mnuMifare"
        Me.mnuMifare.Size = New System.Drawing.Size(291, 24)
        Me.mnuMifare.Text = "ตั้งค่า Mifare"
        '
        'mnuCounterReader
        '
        Me.mnuCounterReader.Name = "mnuCounterReader"
        Me.mnuCounterReader.Size = New System.Drawing.Size(291, 24)
        Me.mnuCounterReader.Text = "ตั้งค่า Counter Reader"
        '
        'mnufloor_count
        '
        Me.mnufloor_count.Name = "mnufloor_count"
        Me.mnufloor_count.Size = New System.Drawing.Size(291, 24)
        Me.mnufloor_count.Text = "ตรวจนับแฟ้มเอกสาร"
        '
        'mnumove
        '
        Me.mnumove.Name = "mnumove"
        Me.mnumove.Size = New System.Drawing.Size(291, 24)
        Me.mnumove.Text = "ค้นหาแฟ้มเอกสารทั้งหมดที่ต้องเคลื่อนย้าย"
        '
        'mnuSearchFileborrow
        '
        Me.mnuSearchFileborrow.Name = "mnuSearchFileborrow"
        Me.mnuSearchFileborrow.Size = New System.Drawing.Size(291, 24)
        Me.mnuSearchFileborrow.Text = "ค้นหาใบยืม"
        '
        'MenuHelp
        '
        Me.MenuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelp_admin, Me.mnuHelp_user, Me.mnuSearchOfficerByDepartment, Me.mnuSearchAppno})
        Me.MenuHelp.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.MenuHelp.Image = CType(resources.GetObject("MenuHelp.Image"), System.Drawing.Image)
        Me.MenuHelp.Name = "MenuHelp"
        Me.MenuHelp.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.MenuHelp.Size = New System.Drawing.Size(99, 23)
        Me.MenuHelp.Text = "ตัวช่วยเหลือ"
        '
        'mnuHelp_admin
        '
        Me.mnuHelp_admin.Name = "mnuHelp_admin"
        Me.mnuHelp_admin.Size = New System.Drawing.Size(206, 24)
        Me.mnuHelp_admin.Text = "User Manual Admin"
        '
        'mnuHelp_user
        '
        Me.mnuHelp_user.Name = "mnuHelp_user"
        Me.mnuHelp_user.Size = New System.Drawing.Size(206, 24)
        Me.mnuHelp_user.Text = "User Manual User"
        '
        'mnuSearchOfficerByDepartment
        '
        Me.mnuSearchOfficerByDepartment.Name = "mnuSearchOfficerByDepartment"
        Me.mnuSearchOfficerByDepartment.Size = New System.Drawing.Size(206, 24)
        Me.mnuSearchOfficerByDepartment.Text = "ค้นหาเจ้าหน้าที่ตามสังกัด"
        '
        'mnuSearchAppno
        '
        Me.mnuSearchAppno.Name = "mnuSearchAppno"
        Me.mnuSearchAppno.Size = New System.Drawing.Size(206, 24)
        Me.mnuSearchAppno.Text = "ค้นหาแฟ้มที่ติดชื่อผู้ยืม"
        '
        'mnuChangePassword
        '
        Me.mnuChangePassword.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.mnuChangePassword.Image = CType(resources.GetObject("mnuChangePassword.Image"), System.Drawing.Image)
        Me.mnuChangePassword.Name = "mnuChangePassword"
        Me.mnuChangePassword.Size = New System.Drawing.Size(116, 23)
        Me.mnuChangePassword.Text = "เปลี่ยนรหัสผ่าน"
        '
        'DatabaseSettingToolStripMenuItem
        '
        Me.DatabaseSettingToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.DatabaseSettingToolStripMenuItem.Image = CType(resources.GetObject("DatabaseSettingToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DatabaseSettingToolStripMenuItem.Name = "DatabaseSettingToolStripMenuItem"
        Me.DatabaseSettingToolStripMenuItem.Size = New System.Drawing.Size(131, 23)
        Me.DatabaseSettingToolStripMenuItem.Text = "เชื่อมต่อฐานข้อมูล"
        '
        'mnuLogout
        '
        Me.mnuLogout.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.mnuLogout.Image = CType(resources.GetObject("mnuLogout.Image"), System.Drawing.Image)
        Me.mnuLogout.Name = "mnuLogout"
        Me.mnuLogout.Size = New System.Drawing.Size(107, 23)
        Me.mnuLogout.Text = "ออกจากระบบ"
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(43, 52)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(100, 20)
        Me.txtUserName.TabIndex = 4
        Me.txtUserName.Visible = False
        '
        'tmrCurrDate
        '
        Me.tmrCurrDate.Enabled = True
        Me.tmrCurrDate.Interval = 1000
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stsOfficerName, Me.stlOfficerName, Me.stlCurrDate})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 703)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(969, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'stsOfficerName
        '
        Me.stsOfficerName.Name = "stsOfficerName"
        Me.stsOfficerName.Size = New System.Drawing.Size(0, 17)
        '
        'stlOfficerName
        '
        Me.stlOfficerName.Name = "stlOfficerName"
        Me.stlOfficerName.Size = New System.Drawing.Size(56, 17)
        Me.stlOfficerName.Text = "ชื่อผู้ใช้งาน"
        '
        'stlCurrDate
        '
        Me.stlCurrDate.Name = "stlCurrDate"
        Me.stlCurrDate.Size = New System.Drawing.Size(32, 17)
        Me.stlCurrDate.Text = "วันที่ :"
        '
        'tmrBGProcess
        '
        Me.tmrBGProcess.Enabled = True
        Me.tmrBGProcess.Interval = 60000
        '
        'tmrChkAlarm
        '
        Me.tmrChkAlarm.Enabled = True
        Me.tmrChkAlarm.Interval = 200
        '
        'txtFullUserName
        '
        Me.txtFullUserName.Location = New System.Drawing.Point(188, 52)
        Me.txtFullUserName.Name = "txtFullUserName"
        Me.txtFullUserName.Size = New System.Drawing.Size(100, 20)
        Me.txtFullUserName.TabIndex = 8
        Me.txtFullUserName.Visible = False
        '
        'txtIdUser
        '
        Me.txtIdUser.Location = New System.Drawing.Point(317, 52)
        Me.txtIdUser.Name = "txtIdUser"
        Me.txtIdUser.Size = New System.Drawing.Size(100, 20)
        Me.txtIdUser.TabIndex = 10
        Me.txtIdUser.Visible = False
        '
        'txtDocumentEvent
        '
        Me.txtDocumentEvent.Location = New System.Drawing.Point(445, 52)
        Me.txtDocumentEvent.Name = "txtDocumentEvent"
        Me.txtDocumentEvent.Size = New System.Drawing.Size(100, 20)
        Me.txtDocumentEvent.TabIndex = 31
        Me.txtDocumentEvent.Visible = False
        '
        'mnuLastLocation
        '
        Me.mnuLastLocation.Name = "mnuLastLocation"
        Me.mnuLastLocation.Size = New System.Drawing.Size(291, 24)
        Me.mnuLastLocation.Text = "ข้อมูลสถานที่พบล่าสุด"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 725)
        Me.Controls.Add(Me.txtDocumentEvent)
        Me.Controls.Add(Me.txtIdUser)
        Me.Controls.Add(Me.txtFullUserName)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.Text = "ระบบยืม-คืน แฟ้มสิทธิบัตร  Version [%_%]"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Menu1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReserve As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mdlBorRet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBorrow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReturn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReportsReturn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReportsHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuShutdownProgram As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuShutdownMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPermission As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOfficer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDepartment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPosition As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTitleName As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLogout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPatentType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents tmrCurrDate As System.Windows.Forms.Timer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents stsOfficerName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents stlOfficerName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents stlCurrDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tmrBGProcess As System.Windows.Forms.Timer
    Friend WithEvents tmrChkAlarm As System.Windows.Forms.Timer
    Friend WithEvents mnuChangePassword As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReturnByOfficer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReturnByDepartment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReturnByDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStatistics As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStatisticsBorrow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStatisticsReturn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStatisticsByOfficer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPerform As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGraph As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGraphBorrowAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGraghPerform As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGraphAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGraphBorrowByDepartment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGraphBorrowByPatentType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGraphByOfficer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSubFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMifare As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHandheld As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuShelf As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DatabaseSettingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtFullUserName As System.Windows.Forms.TextBox
    Friend WithEvents mnuCounterReader As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp_admin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSearchOfficerByDepartment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReportsBorrow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBorrowByOfficer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBorrowByDepartment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBorrowByDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBorrowBetween As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBorrowNoReturn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBorrowAllOfficer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtIdUser As System.Windows.Forms.TextBox
    Friend WithEvents mnuHelp_user As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransfer As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents txtDocumentEvent As System.Windows.Forms.TextBox
    Friend WithEvents mnuSearchAppno As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReportTransfer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnufloor_count As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnumove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSearchFileborrow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLastLocation As System.Windows.Forms.ToolStripMenuItem
End Class
