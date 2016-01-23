<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReserveList
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnPrint = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtSelectedAll = New System.Windows.Forms.TextBox
        Me.btnBorrow = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GridReserve = New System.Windows.Forms.DataGridView
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.isselect = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ref_innova_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.member_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.seq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.chkSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.req_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.app_status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.reserve_date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.member_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.reserve_order = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.reserve_status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BORROWNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.location = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.patent_type_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblNum = New System.Windows.Forms.Label
        Me.btnSelectAll = New System.Windows.Forms.Button
        Me.PictureReserve = New System.Windows.Forms.PictureBox
        Me.Panel1.SuspendLayout()
        CType(Me.GridReserve, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureReserve, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPrint.Location = New System.Drawing.Point(272, 658)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(188, 52)
        Me.btnPrint.TabIndex = 13
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(466, 658)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(189, 51)
        Me.Button1.TabIndex = 19
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtSelectedAll
        '
        Me.txtSelectedAll.Location = New System.Drawing.Point(289, 443)
        Me.txtSelectedAll.Name = "txtSelectedAll"
        Me.txtSelectedAll.Size = New System.Drawing.Size(41, 20)
        Me.txtSelectedAll.TabIndex = 16
        Me.txtSelectedAll.Text = "N"
        Me.txtSelectedAll.Visible = False
        '
        'btnBorrow
        '
        Me.btnBorrow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBorrow.Enabled = False
        Me.btnBorrow.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnBorrow.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBorrow.Location = New System.Drawing.Point(75, 658)
        Me.btnBorrow.Name = "btnBorrow"
        Me.btnBorrow.Size = New System.Drawing.Size(190, 52)
        Me.btnBorrow.TabIndex = 14
        Me.btnBorrow.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GridReserve)
        Me.Panel1.Controls.Add(Me.lblNum)
        Me.Panel1.Controls.Add(Me.btnSelectAll)
        Me.Panel1.Location = New System.Drawing.Point(75, 159)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1182, 385)
        Me.Panel1.TabIndex = 20
        '
        'GridReserve
        '
        Me.GridReserve.AllowUserToAddRows = False
        Me.GridReserve.AllowUserToDeleteRows = False
        Me.GridReserve.AllowUserToResizeColumns = False
        Me.GridReserve.AllowUserToResizeRows = False
        Me.GridReserve.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridReserve.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GridReserve.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridReserve.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.isselect, Me.ref_innova_id, Me.member_id, Me.seq, Me.chkSelect, Me.req_no, Me.app_status, Me.reserve_date, Me.member_name, Me.reserve_order, Me.reserve_status, Me.BORROWNAME, Me.location, Me.patent_type_name})
        Me.GridReserve.Location = New System.Drawing.Point(21, 101)
        Me.GridReserve.MultiSelect = False
        Me.GridReserve.Name = "GridReserve"
        Me.GridReserve.RowHeadersVisible = False
        Me.GridReserve.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridReserve.Size = New System.Drawing.Size(862, 270)
        Me.GridReserve.TabIndex = 19
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.id.Visible = False
        Me.id.Width = 50
        '
        'isselect
        '
        Me.isselect.DataPropertyName = "isselect"
        Me.isselect.HeaderText = "isselect"
        Me.isselect.Name = "isselect"
        Me.isselect.Visible = False
        '
        'ref_innova_id
        '
        Me.ref_innova_id.DataPropertyName = "ref_innova_id"
        Me.ref_innova_id.HeaderText = "ref_innova_id"
        Me.ref_innova_id.Name = "ref_innova_id"
        Me.ref_innova_id.ReadOnly = True
        Me.ref_innova_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ref_innova_id.Visible = False
        '
        'member_id
        '
        Me.member_id.DataPropertyName = "member_id"
        Me.member_id.HeaderText = "member_id"
        Me.member_id.Name = "member_id"
        Me.member_id.ReadOnly = True
        Me.member_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.member_id.Visible = False
        '
        'seq
        '
        Me.seq.DataPropertyName = "seq"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.seq.DefaultCellStyle = DataGridViewCellStyle2
        Me.seq.FillWeight = 8.08558!
        Me.seq.HeaderText = "ลำดับ"
        Me.seq.Name = "seq"
        Me.seq.ReadOnly = True
        Me.seq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.seq.Width = 40
        '
        'chkSelect
        '
        Me.chkSelect.FalseValue = "N"
        Me.chkSelect.FillWeight = 9.680693!
        Me.chkSelect.HeaderText = "เลือก"
        Me.chkSelect.Name = "chkSelect"
        Me.chkSelect.ReadOnly = True
        Me.chkSelect.TrueValue = "Y"
        Me.chkSelect.Width = 40
        '
        'req_no
        '
        Me.req_no.DataPropertyName = "req_no"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.req_no.DefaultCellStyle = DataGridViewCellStyle3
        Me.req_no.FillWeight = 23.75795!
        Me.req_no.HeaderText = "เลขที่คำขอ"
        Me.req_no.Name = "req_no"
        Me.req_no.ReadOnly = True
        Me.req_no.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.req_no.Width = 80
        '
        'app_status
        '
        Me.app_status.DataPropertyName = "app_status"
        Me.app_status.HeaderText = "สถานะคำขอ"
        Me.app_status.Name = "app_status"
        Me.app_status.ReadOnly = True
        '
        'reserve_date
        '
        Me.reserve_date.DataPropertyName = "reserve_date2"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.reserve_date.DefaultCellStyle = DataGridViewCellStyle4
        Me.reserve_date.FillWeight = 37.68068!
        Me.reserve_date.HeaderText = "วันที่จอง"
        Me.reserve_date.Name = "reserve_date"
        Me.reserve_date.ReadOnly = True
        Me.reserve_date.Width = 80
        '
        'member_name
        '
        Me.member_name.DataPropertyName = "member_name"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.member_name.DefaultCellStyle = DataGridViewCellStyle5
        Me.member_name.FillWeight = 92.15744!
        Me.member_name.HeaderText = "ชื่อผู้จอง"
        Me.member_name.Name = "member_name"
        Me.member_name.ReadOnly = True
        Me.member_name.Width = 150
        '
        'reserve_order
        '
        Me.reserve_order.DataPropertyName = "reserve_order"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.reserve_order.DefaultCellStyle = DataGridViewCellStyle6
        Me.reserve_order.FillWeight = 121.8274!
        Me.reserve_order.HeaderText = "ลำดับจอง"
        Me.reserve_order.Name = "reserve_order"
        Me.reserve_order.ReadOnly = True
        Me.reserve_order.Width = 90
        '
        'reserve_status
        '
        Me.reserve_status.DataPropertyName = "reserve_status"
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.reserve_status.DefaultCellStyle = DataGridViewCellStyle7
        Me.reserve_status.FillWeight = 225.0059!
        Me.reserve_status.HeaderText = "สถานะ"
        Me.reserve_status.Name = "reserve_status"
        Me.reserve_status.ReadOnly = True
        Me.reserve_status.Width = 120
        '
        'BORROWNAME
        '
        Me.BORROWNAME.DataPropertyName = "BORROWNAME"
        Me.BORROWNAME.HeaderText = "ชื่อผู้ยืม"
        Me.BORROWNAME.Name = "BORROWNAME"
        Me.BORROWNAME.ReadOnly = True
        '
        'location
        '
        Me.location.DataPropertyName = "location"
        Me.location.HeaderText = "สถานที่จัดเก็บ"
        Me.location.Name = "location"
        Me.location.ReadOnly = True
        '
        'patent_type_name
        '
        Me.patent_type_name.DataPropertyName = "patent_type_name"
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.patent_type_name.DefaultCellStyle = DataGridViewCellStyle8
        Me.patent_type_name.FillWeight = 281.8044!
        Me.patent_type_name.HeaderText = "ประเภทแฟ้ม"
        Me.patent_type_name.Name = "patent_type_name"
        Me.patent_type_name.ReadOnly = True
        Me.patent_type_name.Width = 160
        '
        'lblNum
        '
        Me.lblNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNum.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblNum.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNum.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNum.Location = New System.Drawing.Point(942, 134)
        Me.lblNum.Name = "lblNum"
        Me.lblNum.Size = New System.Drawing.Size(161, 41)
        Me.lblNum.TabIndex = 18
        Me.lblNum.Text = "0"
        Me.lblNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAll.BackColor = System.Drawing.Color.White
        Me.btnSelectAll.Enabled = False
        Me.btnSelectAll.Image = Global.DIP.My.Resources.Resources.select_all_03
        Me.btnSelectAll.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSelectAll.Location = New System.Drawing.Point(21, 67)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(104, 28)
        Me.btnSelectAll.TabIndex = 15
        Me.btnSelectAll.UseVisualStyleBackColor = False
        '
        'PictureReserve
        '
        Me.PictureReserve.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureReserve.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureReserve.Location = New System.Drawing.Point(0, 0)
        Me.PictureReserve.Name = "PictureReserve"
        Me.PictureReserve.Size = New System.Drawing.Size(1269, 741)
        Me.PictureReserve.TabIndex = 10
        Me.PictureReserve.TabStop = False
        '
        'frmReserveList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1269, 741)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnBorrow)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.txtSelectedAll)
        Me.Controls.Add(Me.PictureReserve)
        Me.Name = "frmReserveList"
        Me.Text = "frmReserveList"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.GridReserve, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureReserve, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureReserve As System.Windows.Forms.PictureBox
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtSelectedAll As System.Windows.Forms.TextBox
    Friend WithEvents btnBorrow As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblNum As System.Windows.Forms.Label
    Friend WithEvents GridReserve As System.Windows.Forms.DataGridView
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents isselect As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ref_innova_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents member_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents seq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents req_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents app_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents reserve_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents member_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents reserve_order As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents reserve_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BORROWNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents location As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents patent_type_name As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
