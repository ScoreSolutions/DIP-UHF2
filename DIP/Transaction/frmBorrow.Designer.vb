<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBorrow
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBorrow))
        Me.txtJobNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.gdvDataBook = New System.Windows.Forms.DataGridView
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.resv_app_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.reserve_status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReserveID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.app_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.app_position = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.borrow_status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.idTB_REQ1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gdvDataBorrow = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.idTB_REQ = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APP_NO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.member_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReadBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReserveID_Borrow = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.reserve_date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnReadRFID = New System.Windows.Forms.Button
        Me.btnSendtoHandheld = New System.Windows.Forms.Button
        Me.btnMobileDevice = New System.Windows.Forms.Button
        Me.gdvDataError = New System.Windows.Forms.DataGridView
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comment = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnComfirm = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBarcode = New System.Windows.Forms.TextBox
        Me.lblMemberID = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.lblDate = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblJob_Id = New System.Windows.Forms.Label
        Me.lblB_txt1 = New System.Windows.Forms.Label
        Me.lblB_count = New System.Windows.Forms.Label
        Me.lblB_txt2 = New System.Windows.Forms.Label
        Me.lblE_txt1 = New System.Windows.Forms.Label
        Me.lblE_txt2 = New System.Windows.Forms.Label
        Me.lblE_count = New System.Windows.Forms.Label
        Me.lblR_txt1 = New System.Windows.Forms.Label
        Me.lblR_count = New System.Windows.Forms.Label
        Me.lblR_txt2 = New System.Windows.Forms.Label
        Me.PictureReserve = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.btnBorrowToHandheld = New System.Windows.Forms.Button
        Me.btnOpenDoor = New System.Windows.Forms.Button
        Me.TimeAlertRed = New System.Windows.Forms.Timer(Me.components)
        CType(Me.gdvDataBook, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gdvDataBorrow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gdvDataError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureReserve, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtJobNo
        '
        Me.txtJobNo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJobNo.Location = New System.Drawing.Point(170, 148)
        Me.txtJobNo.Name = "txtJobNo"
        Me.txtJobNo.Size = New System.Drawing.Size(233, 25)
        Me.txtJobNo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Browallia New", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 46)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "เลขที่งาน "
        '
        'gdvDataBook
        '
        Me.gdvDataBook.AllowUserToAddRows = False
        Me.gdvDataBook.AllowUserToDeleteRows = False
        Me.gdvDataBook.AllowUserToResizeColumns = False
        Me.gdvDataBook.AllowUserToResizeRows = False
        Me.gdvDataBook.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gdvDataBook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.gdvDataBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gdvDataBook.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.resv_app_no, Me.Column10, Me.reserve_status, Me.Column4, Me.ReserveID, Me.app_name, Me.app_position, Me.borrow_status, Me.idTB_REQ1})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gdvDataBook.DefaultCellStyle = DataGridViewCellStyle1
        Me.gdvDataBook.Location = New System.Drawing.Point(22, 49)
        Me.gdvDataBook.MultiSelect = False
        Me.gdvDataBook.Name = "gdvDataBook"
        Me.gdvDataBook.ReadOnly = True
        Me.gdvDataBook.RowHeadersVisible = False
        Me.gdvDataBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gdvDataBook.Size = New System.Drawing.Size(255, 364)
        Me.gdvDataBook.TabIndex = 5
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "seq"
        Me.Column6.HeaderText = "ลำดับที่"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column6.Width = 47
        '
        'resv_app_no
        '
        Me.resv_app_no.DataPropertyName = "APP_NO"
        Me.resv_app_no.HeaderText = "เลขที่คำขอ"
        Me.resv_app_no.Name = "resv_app_no"
        Me.resv_app_no.ReadOnly = True
        Me.resv_app_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.resv_app_no.Width = 63
        '
        'Column10
        '
        Me.Column10.DataPropertyName = "reserve_date"
        Me.Column10.HeaderText = "วันที่จอง"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column10.Width = 53
        '
        'reserve_status
        '
        Me.reserve_status.DataPropertyName = "reserve_status"
        Me.reserve_status.HeaderText = "สถานะ"
        Me.reserve_status.Name = "reserve_status"
        Me.reserve_status.ReadOnly = True
        Me.reserve_status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.reserve_status.Width = 45
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "member_name"
        Me.Column4.HeaderText = "ชื่อผู้ยืม"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Visible = False
        Me.Column4.Width = 51
        '
        'ReserveID
        '
        Me.ReserveID.DataPropertyName = "ReserveID"
        Me.ReserveID.HeaderText = "ReserveID"
        Me.ReserveID.Name = "ReserveID"
        Me.ReserveID.ReadOnly = True
        Me.ReserveID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ReserveID.Visible = False
        Me.ReserveID.Width = 72
        '
        'app_name
        '
        Me.app_name.DataPropertyName = "app_name"
        Me.app_name.HeaderText = "app_name"
        Me.app_name.Name = "app_name"
        Me.app_name.ReadOnly = True
        Me.app_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.app_name.Visible = False
        Me.app_name.Width = 74
        '
        'app_position
        '
        Me.app_position.DataPropertyName = "app_position"
        Me.app_position.HeaderText = "app_position"
        Me.app_position.Name = "app_position"
        Me.app_position.ReadOnly = True
        Me.app_position.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.app_position.Visible = False
        Me.app_position.Width = 89
        '
        'borrow_status
        '
        Me.borrow_status.DataPropertyName = "borrow_status"
        Me.borrow_status.HeaderText = "borrow_status"
        Me.borrow_status.Name = "borrow_status"
        Me.borrow_status.ReadOnly = True
        Me.borrow_status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.borrow_status.Visible = False
        Me.borrow_status.Width = 96
        '
        'idTB_REQ1
        '
        Me.idTB_REQ1.DataPropertyName = "idTB_REQ"
        Me.idTB_REQ1.HeaderText = "idTB_REQ"
        Me.idTB_REQ1.Name = "idTB_REQ1"
        Me.idTB_REQ1.ReadOnly = True
        Me.idTB_REQ1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.idTB_REQ1.Visible = False
        Me.idTB_REQ1.Width = 69
        '
        'gdvDataBorrow
        '
        Me.gdvDataBorrow.AllowUserToAddRows = False
        Me.gdvDataBorrow.AllowUserToDeleteRows = False
        Me.gdvDataBorrow.AllowUserToResizeColumns = False
        Me.gdvDataBorrow.AllowUserToResizeRows = False
        Me.gdvDataBorrow.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gdvDataBorrow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gdvDataBorrow.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gdvDataBorrow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gdvDataBorrow.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.idTB_REQ, Me.APP_NO, Me.member_name, Me.ReadBy, Me.ReserveID_Borrow, Me.reserve_date})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gdvDataBorrow.DefaultCellStyle = DataGridViewCellStyle3
        Me.gdvDataBorrow.Location = New System.Drawing.Point(8, 54)
        Me.gdvDataBorrow.MultiSelect = False
        Me.gdvDataBorrow.Name = "gdvDataBorrow"
        Me.gdvDataBorrow.ReadOnly = True
        Me.gdvDataBorrow.RowHeadersVisible = False
        Me.gdvDataBorrow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gdvDataBorrow.Size = New System.Drawing.Size(232, 140)
        Me.gdvDataBorrow.TabIndex = 6
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "seq"
        Me.Column1.HeaderText = "ลำดับที่"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 47
        '
        'idTB_REQ
        '
        Me.idTB_REQ.DataPropertyName = "idTB_REQ"
        Me.idTB_REQ.HeaderText = "idTB_REQ"
        Me.idTB_REQ.Name = "idTB_REQ"
        Me.idTB_REQ.ReadOnly = True
        Me.idTB_REQ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.idTB_REQ.Visible = False
        Me.idTB_REQ.Width = 69
        '
        'APP_NO
        '
        Me.APP_NO.DataPropertyName = "APP_NO"
        Me.APP_NO.HeaderText = "เลขที่คำขอ"
        Me.APP_NO.Name = "APP_NO"
        Me.APP_NO.ReadOnly = True
        Me.APP_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.APP_NO.Width = 63
        '
        'member_name
        '
        Me.member_name.DataPropertyName = "member_name"
        Me.member_name.HeaderText = "ชื่อผู้ยืม"
        Me.member_name.Name = "member_name"
        Me.member_name.ReadOnly = True
        Me.member_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.member_name.Width = 47
        '
        'ReadBy
        '
        Me.ReadBy.DataPropertyName = "ReadBy"
        Me.ReadBy.HeaderText = "อ่านค่าจาก"
        Me.ReadBy.Name = "ReadBy"
        Me.ReadBy.ReadOnly = True
        Me.ReadBy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ReadBy.Visible = False
        Me.ReadBy.Width = 61
        '
        'ReserveID_Borrow
        '
        Me.ReserveID_Borrow.DataPropertyName = "ReserveID"
        Me.ReserveID_Borrow.HeaderText = "ReserveID_Borrow"
        Me.ReserveID_Borrow.Name = "ReserveID_Borrow"
        Me.ReserveID_Borrow.ReadOnly = True
        Me.ReserveID_Borrow.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ReserveID_Borrow.Visible = False
        Me.ReserveID_Borrow.Width = 119
        '
        'reserve_date
        '
        Me.reserve_date.DataPropertyName = "reserve_date"
        Me.reserve_date.HeaderText = "reserve_date"
        Me.reserve_date.Name = "reserve_date"
        Me.reserve_date.ReadOnly = True
        Me.reserve_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.reserve_date.Visible = False
        Me.reserve_date.Width = 88
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.BackColor = System.Drawing.SystemColors.Control
        Me.btnPrint.Enabled = False
        Me.btnPrint.Font = New System.Drawing.Font("Browallia New", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPrint.Location = New System.Drawing.Point(510, 89)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(153, 40)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnReadRFID
        '
        Me.btnReadRFID.BackColor = System.Drawing.SystemColors.Control
        Me.btnReadRFID.Enabled = False
        Me.btnReadRFID.FlatAppearance.BorderSize = 0
        Me.btnReadRFID.Font = New System.Drawing.Font("Browallia New", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReadRFID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnReadRFID.Location = New System.Drawing.Point(388, 434)
        Me.btnReadRFID.Name = "btnReadRFID"
        Me.btnReadRFID.Size = New System.Drawing.Size(207, 51)
        Me.btnReadRFID.TabIndex = 9
        Me.btnReadRFID.UseVisualStyleBackColor = False
        '
        'btnSendtoHandheld
        '
        Me.btnSendtoHandheld.BackColor = System.Drawing.SystemColors.Control
        Me.btnSendtoHandheld.Enabled = False
        Me.btnSendtoHandheld.Font = New System.Drawing.Font("Browallia New", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSendtoHandheld.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSendtoHandheld.Location = New System.Drawing.Point(414, 249)
        Me.btnSendtoHandheld.Name = "btnSendtoHandheld"
        Me.btnSendtoHandheld.Size = New System.Drawing.Size(150, 66)
        Me.btnSendtoHandheld.TabIndex = 10
        Me.btnSendtoHandheld.UseVisualStyleBackColor = False
        '
        'btnMobileDevice
        '
        Me.btnMobileDevice.BackColor = System.Drawing.SystemColors.Control
        Me.btnMobileDevice.Font = New System.Drawing.Font("Browallia New", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMobileDevice.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnMobileDevice.Location = New System.Drawing.Point(414, 337)
        Me.btnMobileDevice.Name = "btnMobileDevice"
        Me.btnMobileDevice.Size = New System.Drawing.Size(151, 67)
        Me.btnMobileDevice.TabIndex = 41
        Me.btnMobileDevice.UseVisualStyleBackColor = False
        '
        'gdvDataError
        '
        Me.gdvDataError.AllowUserToAddRows = False
        Me.gdvDataError.AllowUserToDeleteRows = False
        Me.gdvDataError.AllowUserToResizeColumns = False
        Me.gdvDataError.AllowUserToResizeRows = False
        Me.gdvDataError.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gdvDataError.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.gdvDataError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gdvDataError.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column8, Me.Column9, Me.Column11, Me.Status1, Me.comment, Me.Column13, Me.Column14})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gdvDataError.DefaultCellStyle = DataGridViewCellStyle4
        Me.gdvDataError.Location = New System.Drawing.Point(8, 49)
        Me.gdvDataError.MultiSelect = False
        Me.gdvDataError.Name = "gdvDataError"
        Me.gdvDataError.ReadOnly = True
        Me.gdvDataError.RowHeadersVisible = False
        Me.gdvDataError.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gdvDataError.Size = New System.Drawing.Size(232, 151)
        Me.gdvDataError.TabIndex = 6
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "seq"
        Me.Column8.HeaderText = "ลำดับที่"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column8.Width = 47
        '
        'Column9
        '
        Me.Column9.DataPropertyName = "APP_NO"
        Me.Column9.HeaderText = "เลขที่คำขอ"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column9.Width = 63
        '
        'Column11
        '
        Me.Column11.DataPropertyName = "reserve_date"
        Me.Column11.HeaderText = "วันที่จอง"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column11.Width = 53
        '
        'Status1
        '
        Me.Status1.DataPropertyName = "reserve_status"
        Me.Status1.HeaderText = "สถานะ"
        Me.Status1.Name = "Status1"
        Me.Status1.ReadOnly = True
        Me.Status1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Status1.Width = 45
        '
        'comment
        '
        Me.comment.DataPropertyName = "comment"
        Me.comment.HeaderText = "หมายเหตุ"
        Me.comment.Name = "comment"
        Me.comment.ReadOnly = True
        Me.comment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.comment.Visible = False
        Me.comment.Width = 58
        '
        'Column13
        '
        Me.Column13.DataPropertyName = "app_name"
        Me.Column13.HeaderText = "Column13"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column13.Visible = False
        Me.Column13.Width = 72
        '
        'Column14
        '
        Me.Column14.DataPropertyName = "app_position"
        Me.Column14.HeaderText = "Column14"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        Me.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column14.Visible = False
        Me.Column14.Width = 72
        '
        'btnComfirm
        '
        Me.btnComfirm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnComfirm.BackColor = System.Drawing.SystemColors.Control
        Me.btnComfirm.Enabled = False
        Me.btnComfirm.Font = New System.Drawing.Font("Browallia New", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnComfirm.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnComfirm.Location = New System.Drawing.Point(510, 26)
        Me.btnComfirm.Name = "btnComfirm"
        Me.btnComfirm.Size = New System.Drawing.Size(153, 40)
        Me.btnComfirm.TabIndex = 37
        Me.btnComfirm.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Font = New System.Drawing.Font("Browallia New", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(399, 511)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(189, 51)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Browallia New", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(911, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 46)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "BARCODE"
        '
        'txtBarcode
        '
        Me.txtBarcode.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(1050, 148)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(221, 25)
        Me.txtBarcode.TabIndex = 35
        Me.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblMemberID
        '
        Me.lblMemberID.AutoSize = True
        Me.lblMemberID.Location = New System.Drawing.Point(439, 626)
        Me.lblMemberID.Name = "lblMemberID"
        Me.lblMemberID.Size = New System.Drawing.Size(70, 17)
        Me.lblMemberID.TabIndex = 37
        Me.lblMemberID.Text = "MemberID"
        Me.lblMemberID.Visible = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(451, 658)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(43, 17)
        Me.lblName.TabIndex = 38
        Me.lblName.Text = "Name"
        Me.lblName.Visible = False
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(451, 592)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(35, 17)
        Me.lblDate.TabIndex = 39
        Me.lblDate.Text = "Date"
        Me.lblDate.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'lblJob_Id
        '
        Me.lblJob_Id.AutoSize = True
        Me.lblJob_Id.Location = New System.Drawing.Point(451, 563)
        Me.lblJob_Id.Name = "lblJob_Id"
        Me.lblJob_Id.Size = New System.Drawing.Size(40, 17)
        Me.lblJob_Id.TabIndex = 40
        Me.lblJob_Id.Text = "JobId"
        Me.lblJob_Id.Visible = False
        '
        'lblB_txt1
        '
        Me.lblB_txt1.AutoSize = True
        Me.lblB_txt1.BackColor = System.Drawing.Color.Transparent
        Me.lblB_txt1.Location = New System.Drawing.Point(633, 409)
        Me.lblB_txt1.Name = "lblB_txt1"
        Me.lblB_txt1.Size = New System.Drawing.Size(122, 17)
        Me.lblB_txt1.TabIndex = 42
        Me.lblB_txt1.Text = "จำนวนรายการยืมทั้งหมด"
        Me.lblB_txt1.Visible = False
        '
        'lblB_count
        '
        Me.lblB_count.BackColor = System.Drawing.Color.Transparent
        Me.lblB_count.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblB_count.Location = New System.Drawing.Point(772, 409)
        Me.lblB_count.Name = "lblB_count"
        Me.lblB_count.Size = New System.Drawing.Size(36, 17)
        Me.lblB_count.TabIndex = 43
        Me.lblB_count.Text = "0"
        Me.lblB_count.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblB_count.Visible = False
        '
        'lblB_txt2
        '
        Me.lblB_txt2.AutoSize = True
        Me.lblB_txt2.BackColor = System.Drawing.Color.Transparent
        Me.lblB_txt2.Location = New System.Drawing.Point(814, 409)
        Me.lblB_txt2.Name = "lblB_txt2"
        Me.lblB_txt2.Size = New System.Drawing.Size(42, 17)
        Me.lblB_txt2.TabIndex = 44
        Me.lblB_txt2.Text = "รายการ"
        Me.lblB_txt2.Visible = False
        '
        'lblE_txt1
        '
        Me.lblE_txt1.AutoSize = True
        Me.lblE_txt1.BackColor = System.Drawing.Color.Transparent
        Me.lblE_txt1.Location = New System.Drawing.Point(633, 180)
        Me.lblE_txt1.Name = "lblE_txt1"
        Me.lblE_txt1.Size = New System.Drawing.Size(153, 17)
        Me.lblE_txt1.TabIndex = 46
        Me.lblE_txt1.Text = "จำนวนรายการที่มีปัญหาทั้งหมด"
        Me.lblE_txt1.Visible = False
        '
        'lblE_txt2
        '
        Me.lblE_txt2.AutoSize = True
        Me.lblE_txt2.BackColor = System.Drawing.Color.Transparent
        Me.lblE_txt2.Location = New System.Drawing.Point(845, 180)
        Me.lblE_txt2.Name = "lblE_txt2"
        Me.lblE_txt2.Size = New System.Drawing.Size(42, 17)
        Me.lblE_txt2.TabIndex = 48
        Me.lblE_txt2.Text = "รายการ"
        Me.lblE_txt2.Visible = False
        '
        'lblE_count
        '
        Me.lblE_count.BackColor = System.Drawing.Color.Transparent
        Me.lblE_count.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblE_count.Location = New System.Drawing.Point(803, 180)
        Me.lblE_count.Name = "lblE_count"
        Me.lblE_count.Size = New System.Drawing.Size(36, 17)
        Me.lblE_count.TabIndex = 47
        Me.lblE_count.Text = "0"
        Me.lblE_count.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE_count.Visible = False
        '
        'lblR_txt1
        '
        Me.lblR_txt1.AutoSize = True
        Me.lblR_txt1.BackColor = System.Drawing.Color.Transparent
        Me.lblR_txt1.Location = New System.Drawing.Point(66, 180)
        Me.lblR_txt1.Name = "lblR_txt1"
        Me.lblR_txt1.Size = New System.Drawing.Size(127, 17)
        Me.lblR_txt1.TabIndex = 50
        Me.lblR_txt1.Text = "จำนวนรายการจองทั้งหมด"
        Me.lblR_txt1.Visible = False
        '
        'lblR_count
        '
        Me.lblR_count.BackColor = System.Drawing.Color.Transparent
        Me.lblR_count.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblR_count.Location = New System.Drawing.Point(207, 180)
        Me.lblR_count.Name = "lblR_count"
        Me.lblR_count.Size = New System.Drawing.Size(36, 17)
        Me.lblR_count.TabIndex = 51
        Me.lblR_count.Text = "0"
        Me.lblR_count.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblR_count.Visible = False
        '
        'lblR_txt2
        '
        Me.lblR_txt2.AutoSize = True
        Me.lblR_txt2.BackColor = System.Drawing.Color.Transparent
        Me.lblR_txt2.Location = New System.Drawing.Point(249, 180)
        Me.lblR_txt2.Name = "lblR_txt2"
        Me.lblR_txt2.Size = New System.Drawing.Size(42, 17)
        Me.lblR_txt2.TabIndex = 52
        Me.lblR_txt2.Text = "รายการ"
        Me.lblR_txt2.Visible = False
        '
        'PictureReserve
        '
        Me.PictureReserve.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureReserve.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureReserve.InitialImage = Nothing
        Me.PictureReserve.Location = New System.Drawing.Point(0, 0)
        Me.PictureReserve.Name = "PictureReserve"
        Me.PictureReserve.Size = New System.Drawing.Size(1276, 738)
        Me.PictureReserve.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureReserve.TabIndex = 23
        Me.PictureReserve.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.gdvDataBook)
        Me.Panel1.Location = New System.Drawing.Point(47, 200)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(308, 436)
        Me.Panel1.TabIndex = 54
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.gdvDataError)
        Me.Panel2.Location = New System.Drawing.Point(629, 200)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(666, 207)
        Me.Panel2.TabIndex = 55
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnBorrowToHandheld)
        Me.Panel3.Controls.Add(Me.btnComfirm)
        Me.Panel3.Controls.Add(Me.gdvDataBorrow)
        Me.Panel3.Controls.Add(Me.btnPrint)
        Me.Panel3.Location = New System.Drawing.Point(629, 429)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(666, 207)
        Me.Panel3.TabIndex = 56
        '
        'btnBorrowToHandheld
        '
        Me.btnBorrowToHandheld.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBorrowToHandheld.BackColor = System.Drawing.SystemColors.Control
        Me.btnBorrowToHandheld.Enabled = False
        Me.btnBorrowToHandheld.Font = New System.Drawing.Font("Browallia New", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrowToHandheld.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBorrowToHandheld.Location = New System.Drawing.Point(510, 152)
        Me.btnBorrowToHandheld.Name = "btnBorrowToHandheld"
        Me.btnBorrowToHandheld.Size = New System.Drawing.Size(153, 40)
        Me.btnBorrowToHandheld.TabIndex = 38
        Me.btnBorrowToHandheld.UseVisualStyleBackColor = False
        Me.btnBorrowToHandheld.Visible = False
        '
        'btnOpenDoor
        '
        Me.btnOpenDoor.Image = Global.DIP.My.Resources.Resources.door_bt
        Me.btnOpenDoor.Location = New System.Drawing.Point(453, 598)
        Me.btnOpenDoor.Name = "btnOpenDoor"
        Me.btnOpenDoor.Size = New System.Drawing.Size(80, 60)
        Me.btnOpenDoor.TabIndex = 57
        Me.btnOpenDoor.UseVisualStyleBackColor = True
        '
        'TimeAlertRed
        '
        '
        'frmBorrow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Menu
        Me.BackgroundImage = Global.DIP.My.Resources.Resources.bg
        Me.ClientSize = New System.Drawing.Size(1276, 738)
        Me.Controls.Add(Me.btnOpenDoor)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.btnMobileDevice)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnSendtoHandheld)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblR_txt2)
        Me.Controls.Add(Me.lblB_count)
        Me.Controls.Add(Me.lblR_txt1)
        Me.Controls.Add(Me.lblB_txt1)
        Me.Controls.Add(Me.lblB_txt2)
        Me.Controls.Add(Me.lblE_txt2)
        Me.Controls.Add(Me.btnReadRFID)
        Me.Controls.Add(Me.lblE_txt1)
        Me.Controls.Add(Me.lblE_count)
        Me.Controls.Add(Me.lblR_count)
        Me.Controls.Add(Me.lblJob_Id)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblMemberID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtJobNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureReserve)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBorrow"
        Me.Text = "ยืมสิทธิบัตร"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gdvDataBook, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gdvDataBorrow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gdvDataError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureReserve, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtJobNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gdvDataBook As System.Windows.Forms.DataGridView
    Friend WithEvents gdvDataBorrow As System.Windows.Forms.DataGridView
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnReadRFID As System.Windows.Forms.Button
    Friend WithEvents btnSendtoHandheld As System.Windows.Forms.Button
    Friend WithEvents gdvDataError As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents btnComfirm As System.Windows.Forms.Button
    Friend WithEvents lblMemberID As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblJob_Id As System.Windows.Forms.Label
    Friend WithEvents btnMobileDevice As System.Windows.Forms.Button
    Friend WithEvents lblB_txt1 As System.Windows.Forms.Label
    Friend WithEvents lblB_count As System.Windows.Forms.Label
    Friend WithEvents lblB_txt2 As System.Windows.Forms.Label
    Friend WithEvents lblE_txt1 As System.Windows.Forms.Label
    Friend WithEvents lblE_txt2 As System.Windows.Forms.Label
    Friend WithEvents lblE_count As System.Windows.Forms.Label
    Friend WithEvents lblR_txt1 As System.Windows.Forms.Label
    Friend WithEvents lblR_count As System.Windows.Forms.Label
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idTB_REQ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APP_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents member_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReadBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReserveID_Borrow As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents reserve_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblR_txt2 As System.Windows.Forms.Label
    Friend WithEvents PictureReserve As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnOpenDoor As System.Windows.Forms.Button
    Friend WithEvents TimeAlertRed As System.Windows.Forms.Timer
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents resv_app_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents reserve_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReserveID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents app_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents app_position As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents borrow_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idTB_REQ1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnBorrowToHandheld As System.Windows.Forms.Button
End Class
