<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransfer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransfer))
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBarcode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnComfirm = New System.Windows.Forms.Button
        Me.PictureReserve = New System.Windows.Forms.PictureBox
        Me.ddlLocation = New System.Windows.Forms.ComboBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.btnMobileDevice = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnReadRFID = New System.Windows.Forms.Button
        Me.gdvDataBook = New System.Windows.Forms.DataGridView
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.location = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReadBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnPrint = New System.Windows.Forms.Button
        CType(Me.PictureReserve, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.gdvDataBook, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(199, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 37)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Barcode"
        '
        'txtBarcode
        '
        Me.txtBarcode.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(340, 165)
        Me.txtBarcode.MaxLength = 20
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(200, 25)
        Me.txtBarcode.TabIndex = 0
        Me.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(587, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 37)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Location"
        Me.Label1.Visible = False
        '
        'btnComfirm
        '
        Me.btnComfirm.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnComfirm.Location = New System.Drawing.Point(964, 342)
        Me.btnComfirm.Name = "btnComfirm"
        Me.btnComfirm.Size = New System.Drawing.Size(188, 50)
        Me.btnComfirm.TabIndex = 43
        Me.btnComfirm.UseVisualStyleBackColor = True
        '
        'PictureReserve
        '
        Me.PictureReserve.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureReserve.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureReserve.Location = New System.Drawing.Point(0, 0)
        Me.PictureReserve.Name = "PictureReserve"
        Me.PictureReserve.Size = New System.Drawing.Size(1164, 741)
        Me.PictureReserve.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureReserve.TabIndex = 47
        Me.PictureReserve.TabStop = False
        '
        'ddlLocation
        '
        Me.ddlLocation.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ddlLocation.FormattingEnabled = True
        Me.ddlLocation.Location = New System.Drawing.Point(734, 164)
        Me.ddlLocation.Name = "ddlLocation"
        Me.ddlLocation.Size = New System.Drawing.Size(217, 25)
        Me.ddlLocation.TabIndex = 49
        Me.ddlLocation.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.btnMobileDevice)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnReadRFID)
        Me.Panel1.Controls.Add(Me.gdvDataBook)
        Me.Panel1.Location = New System.Drawing.Point(196, 211)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(763, 431)
        Me.Panel1.TabIndex = 50
        '
        'Button1
        '
        Me.Button1.Image = Global.DIP.My.Resources.Resources.door_bt
        Me.Button1.Location = New System.Drawing.Point(511, 318)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 60)
        Me.Button1.TabIndex = 87
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Location = New System.Drawing.Point(144, 352)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(235, 66)
        Me.Panel5.TabIndex = 86
        '
        'btnMobileDevice
        '
        Me.btnMobileDevice.BackColor = System.Drawing.SystemColors.Control
        Me.btnMobileDevice.Font = New System.Drawing.Font("Browallia New", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMobileDevice.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnMobileDevice.Location = New System.Drawing.Point(476, 67)
        Me.btnMobileDevice.Name = "btnMobileDevice"
        Me.btnMobileDevice.Size = New System.Drawing.Size(151, 67)
        Me.btnMobileDevice.TabIndex = 85
        Me.btnMobileDevice.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.Location = New System.Drawing.Point(461, 240)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(189, 51)
        Me.btnCancel.TabIndex = 49
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnReadRFID
        '
        Me.btnReadRFID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnReadRFID.Location = New System.Drawing.Point(450, 164)
        Me.btnReadRFID.Name = "btnReadRFID"
        Me.btnReadRFID.Size = New System.Drawing.Size(207, 51)
        Me.btnReadRFID.TabIndex = 48
        Me.btnReadRFID.UseVisualStyleBackColor = True
        '
        'gdvDataBook
        '
        Me.gdvDataBook.AllowUserToAddRows = False
        Me.gdvDataBook.AllowUserToDeleteRows = False
        Me.gdvDataBook.AllowUserToResizeColumns = False
        Me.gdvDataBook.AllowUserToResizeRows = False
        Me.gdvDataBook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.gdvDataBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gdvDataBook.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column7, Me.location, Me.ReadBy})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gdvDataBook.DefaultCellStyle = DataGridViewCellStyle1
        Me.gdvDataBook.Location = New System.Drawing.Point(120, 33)
        Me.gdvDataBook.MultiSelect = False
        Me.gdvDataBook.Name = "gdvDataBook"
        Me.gdvDataBook.ReadOnly = True
        Me.gdvDataBook.RowHeadersVisible = False
        Me.gdvDataBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gdvDataBook.Size = New System.Drawing.Size(288, 308)
        Me.gdvDataBook.TabIndex = 47
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "seq"
        Me.Column6.HeaderText = "ลำดับที่"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column6.Width = 45
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "tag_id"
        Me.Column7.HeaderText = "เลขที่คำขอ"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column7.Width = 61
        '
        'location
        '
        Me.location.DataPropertyName = "location"
        Me.location.HeaderText = "สถานที่จัดเก็บ"
        Me.location.Name = "location"
        Me.location.ReadOnly = True
        Me.location.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.location.Width = 78
        '
        'ReadBy
        '
        Me.ReadBy.DataPropertyName = "ReadBy"
        Me.ReadBy.HeaderText = "ReadBy"
        Me.ReadBy.Name = "ReadBy"
        Me.ReadBy.ReadOnly = True
        Me.ReadBy.Visible = False
        Me.ReadBy.Width = 70
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(964, 414)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(188, 50)
        Me.btnPrint.TabIndex = 51
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'frmTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.DIP.My.Resources.Resources.bg
        Me.ClientSize = New System.Drawing.Size(1164, 741)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ddlLocation)
        Me.Controls.Add(Me.btnComfirm)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.PictureReserve)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTransfer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ย้ายสิทธิบัตร"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureReserve, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.gdvDataBook, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnComfirm As System.Windows.Forms.Button
    Friend WithEvents PictureReserve As System.Windows.Forms.PictureBox
    Friend WithEvents ddlLocation As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnReadRFID As System.Windows.Forms.Button
    Friend WithEvents gdvDataBook As System.Windows.Forms.DataGridView
    Friend WithEvents btnMobileDevice As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents location As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReadBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
End Class
