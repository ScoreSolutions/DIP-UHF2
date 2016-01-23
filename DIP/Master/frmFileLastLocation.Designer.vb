<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFileLastLocation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFileLastLocation))
        Me.gvFileLastLocation = New System.Windows.Forms.DataGridView
        Me.lblCount = New System.Windows.Forms.Label
        Me.btnSendTo = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbLocation = New System.Windows.Forms.ComboBox
        Me.colAppNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fileborrow_code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.borrowername = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.borrowerdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.location_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.gvFileLastLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvFileLastLocation
        '
        Me.gvFileLastLocation.AllowUserToAddRows = False
        Me.gvFileLastLocation.AllowUserToDeleteRows = False
        Me.gvFileLastLocation.AllowUserToResizeColumns = False
        Me.gvFileLastLocation.AllowUserToResizeRows = False
        Me.gvFileLastLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gvFileLastLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvFileLastLocation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAppNo, Me.fileborrow_code, Me.borrowername, Me.borrowerdate, Me.location_name})
        Me.gvFileLastLocation.Location = New System.Drawing.Point(12, 56)
        Me.gvFileLastLocation.MultiSelect = False
        Me.gvFileLastLocation.Name = "gvFileLastLocation"
        Me.gvFileLastLocation.RowHeadersVisible = False
        Me.gvFileLastLocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gvFileLastLocation.Size = New System.Drawing.Size(966, 344)
        Me.gvFileLastLocation.TabIndex = 6
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblCount.Location = New System.Drawing.Point(12, 414)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(103, 17)
        Me.lblCount.TabIndex = 30
        Me.lblCount.Text = "จำนวน  0 แฟ้ม"
        '
        'btnSendTo
        '
        Me.btnSendTo.Location = New System.Drawing.Point(872, 10)
        Me.btnSendTo.Name = "btnSendTo"
        Me.btnSendTo.Size = New System.Drawing.Size(106, 40)
        Me.btnSendTo.TabIndex = 32
        Me.btnSendTo.Text = "ส่งการค้นหาไปยัง Handhled"
        Me.btnSendTo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 17)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Location :"
        '
        'cbLocation
        '
        Me.cbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLocation.FormattingEnabled = True
        Me.cbLocation.Location = New System.Drawing.Point(88, 12)
        Me.cbLocation.Name = "cbLocation"
        Me.cbLocation.Size = New System.Drawing.Size(257, 21)
        Me.cbLocation.TabIndex = 47
        '
        'colAppNo
        '
        Me.colAppNo.DataPropertyName = "app_no"
        Me.colAppNo.HeaderText = "เลขที่แฟ้ม"
        Me.colAppNo.Name = "colAppNo"
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
        'location_name
        '
        Me.location_name.DataPropertyName = "location_name"
        Me.location_name.FillWeight = 76.14212!
        Me.location_name.HeaderText = "สถานที่พบ"
        Me.location_name.Name = "location_name"
        Me.location_name.ReadOnly = True
        Me.location_name.Width = 250
        '
        'frmFileLastLocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 440)
        Me.Controls.Add(Me.cbLocation)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSendTo)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.gvFileLastLocation)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFileLastLocation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "รายการยืม"
        CType(Me.gvFileLastLocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents gvFileLastLocation As System.Windows.Forms.DataGridView
    Friend WithEvents btnSendTo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbLocation As System.Windows.Forms.ComboBox
    Friend WithEvents colAppNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fileborrow_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents borrowername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents borrowerdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents location_name As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
