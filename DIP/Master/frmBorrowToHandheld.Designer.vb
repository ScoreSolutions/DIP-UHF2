<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBorrowToHandheld
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBorrowToHandheld))
        Me.gvFileBorrow = New System.Windows.Forms.DataGridView
        Me.chkSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.fileborrow_code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.borrowername = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.borrowerdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.file_qty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fileborrow_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnSendBack = New System.Windows.Forms.Button
        Me.lblCount = New System.Windows.Forms.Label
        Me.btnSendTo = New System.Windows.Forms.Button
        Me.cbAll = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtBorrowerDate = New DIP.txtDate
        CType(Me.gvFileBorrow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvFileBorrow
        '
        Me.gvFileBorrow.AllowUserToAddRows = False
        Me.gvFileBorrow.AllowUserToDeleteRows = False
        Me.gvFileBorrow.AllowUserToResizeColumns = False
        Me.gvFileBorrow.AllowUserToResizeRows = False
        Me.gvFileBorrow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gvFileBorrow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvFileBorrow.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chkSelect, Me.fileborrow_code, Me.borrowername, Me.borrowerdate, Me.file_qty, Me.fileborrow_id})
        Me.gvFileBorrow.Location = New System.Drawing.Point(12, 56)
        Me.gvFileBorrow.MultiSelect = False
        Me.gvFileBorrow.Name = "gvFileBorrow"
        Me.gvFileBorrow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gvFileBorrow.Size = New System.Drawing.Size(775, 344)
        Me.gvFileBorrow.TabIndex = 6
        '
        'chkSelect
        '
        Me.chkSelect.FalseValue = "N"
        Me.chkSelect.FillWeight = 9.054475!
        Me.chkSelect.HeaderText = "เลือก"
        Me.chkSelect.Name = "chkSelect"
        Me.chkSelect.TrueValue = "Y"
        Me.chkSelect.Width = 50
        '
        'fileborrow_code
        '
        Me.fileborrow_code.DataPropertyName = "fileborrow_code"
        Me.fileborrow_code.FillWeight = 75.13921!
        Me.fileborrow_code.HeaderText = "เลขที่ใบยืม"
        Me.fileborrow_code.Name = "fileborrow_code"
        '
        'borrowername
        '
        Me.borrowername.DataPropertyName = "borrowername"
        DataGridViewCellStyle1.NullValue = "1"
        Me.borrowername.DefaultCellStyle = DataGridViewCellStyle1
        Me.borrowername.FillWeight = 160.3086!
        Me.borrowername.HeaderText = "ชื่อผู้ยืม"
        Me.borrowername.Name = "borrowername"
        Me.borrowername.Width = 250
        '
        'borrowerdate
        '
        Me.borrowerdate.DataPropertyName = "borrowerdate"
        Me.borrowerdate.FillWeight = 179.3555!
        Me.borrowerdate.HeaderText = "วันที่ยืม"
        Me.borrowerdate.Name = "borrowerdate"
        Me.borrowerdate.ReadOnly = True
        Me.borrowerdate.Width = 150
        '
        'file_qty
        '
        Me.file_qty.DataPropertyName = "file_qty"
        Me.file_qty.FillWeight = 76.14212!
        Me.file_qty.HeaderText = "จำนวนแฟ้ม"
        Me.file_qty.Name = "file_qty"
        Me.file_qty.ReadOnly = True
        '
        'fileborrow_id
        '
        Me.fileborrow_id.DataPropertyName = "fileborrow_id"
        Me.fileborrow_id.HeaderText = "fileborrow_id"
        Me.fileborrow_id.Name = "fileborrow_id"
        Me.fileborrow_id.Visible = False
        Me.fileborrow_id.Width = 91
        '
        'btnSendBack
        '
        Me.btnSendBack.Location = New System.Drawing.Point(793, 115)
        Me.btnSendBack.Name = "btnSendBack"
        Me.btnSendBack.Size = New System.Drawing.Size(185, 40)
        Me.btnSendBack.TabIndex = 29
        Me.btnSendBack.Text = "บันทึกการค้นหาจาก Handhled"
        Me.btnSendBack.UseVisualStyleBackColor = True
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblCount.Location = New System.Drawing.Point(12, 414)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(108, 17)
        Me.lblCount.TabIndex = 30
        Me.lblCount.Text = "จำนวน  0 ใบยืม"
        '
        'btnSendTo
        '
        Me.btnSendTo.Location = New System.Drawing.Point(793, 53)
        Me.btnSendTo.Name = "btnSendTo"
        Me.btnSendTo.Size = New System.Drawing.Size(185, 40)
        Me.btnSendTo.TabIndex = 32
        Me.btnSendTo.Text = "ส่งการค้นหาไปยัง Handhled"
        Me.btnSendTo.UseVisualStyleBackColor = True
        '
        'cbAll
        '
        Me.cbAll.AutoSize = True
        Me.cbAll.Enabled = False
        Me.cbAll.Location = New System.Drawing.Point(56, 33)
        Me.cbAll.Name = "cbAll"
        Me.cbAll.Size = New System.Drawing.Size(59, 17)
        Me.cbAll.TabIndex = 38
        Me.cbAll.Text = "ทั้งหมด"
        Me.cbAll.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(520, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 17)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "วันที่ยืม"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(709, 24)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 26)
        Me.btnSearch.TabIndex = 46
        Me.btnSearch.Text = "ค้นหา"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtBorrowerDate
        '
        Me.txtBorrowerDate.DateValue = New Date(CType(0, Long))
        Me.txtBorrowerDate.Location = New System.Drawing.Point(581, 24)
        Me.txtBorrowerDate.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBorrowerDate.Name = "txtBorrowerDate"
        Me.txtBorrowerDate.Size = New System.Drawing.Size(120, 26)
        Me.txtBorrowerDate.TabIndex = 45
        '
        'frmBorrowToHandheld
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 440)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtBorrowerDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbAll)
        Me.Controls.Add(Me.btnSendTo)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.btnSendBack)
        Me.Controls.Add(Me.gvFileBorrow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBorrowToHandheld"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "รายการยืม"
        CType(Me.gvFileBorrow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSendBack As System.Windows.Forms.Button
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents gvFileBorrow As System.Windows.Forms.DataGridView
    Friend WithEvents btnSendTo As System.Windows.Forms.Button
    Friend WithEvents cbAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents fileborrow_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents borrowername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents borrowerdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents file_qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fileborrow_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBorrowerDate As DIP.txtDate
    Friend WithEvents btnSearch As System.Windows.Forms.Button
End Class
