<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchHistoryFromHandheld
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchHistoryFromHandheld))
        Me.txtAppNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GridHHT = New System.Windows.Forms.DataGridView
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbStatus = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.txtDateFrom = New System.Windows.Forms.TextBox
        Me.dtpTo = New System.Windows.Forms.DateTimePicker
        Me.txtDateTo = New System.Windows.Forms.TextBox
        Me.app_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.S_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TXT_STATUS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.S_TIME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FIND_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FIND_STATUS = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.GridHHT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAppNo
        '
        Me.txtAppNo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAppNo.Location = New System.Drawing.Point(120, 54)
        Me.txtAppNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAppNo.Name = "txtAppNo"
        Me.txtAppNo.Size = New System.Drawing.Size(329, 25)
        Me.txtAppNo.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(39, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 19)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "เลขที่คำขอ :"
        '
        'GridHHT
        '
        Me.GridHHT.AllowUserToAddRows = False
        Me.GridHHT.AllowUserToDeleteRows = False
        Me.GridHHT.AllowUserToOrderColumns = True
        Me.GridHHT.AllowUserToResizeColumns = False
        Me.GridHHT.AllowUserToResizeRows = False
        Me.GridHHT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridHHT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridHHT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.app_no, Me.S_DATE, Me.TXT_STATUS, Me.S_TIME, Me.FIND_DATE, Me.FIND_STATUS})
        Me.GridHHT.Location = New System.Drawing.Point(16, 138)
        Me.GridHHT.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridHHT.MultiSelect = False
        Me.GridHHT.Name = "GridHHT"
        Me.GridHHT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridHHT.Size = New System.Drawing.Size(548, 314)
        Me.GridHHT.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(276, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 19)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "ถึง"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(71, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 19)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "วันที่ :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(59, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 19)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "สถานะ :"
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"ข้อมูลทั้งหมด", "ข้อมูลที่กำลังค้นหา", "ข้อมูลที่หาพบ", "ข้อมูลที่หาไม่พบ"})
        Me.cmbStatus.Location = New System.Drawing.Point(120, 87)
        Me.cmbStatus.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(329, 25)
        Me.cmbStatus.TabIndex = 38
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.txtDateFrom)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtDateTo)
        Me.GroupBox1.Controls.Add(Me.cmbStatus)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtAppNo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 5)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(550, 125)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(243, 20)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(18, 25)
        Me.dtpFrom.TabIndex = 42
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(120, 20)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(122, 25)
        Me.txtDateFrom.TabIndex = 41
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(428, 20)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(18, 25)
        Me.dtpTo.TabIndex = 40
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(305, 20)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(122, 25)
        Me.txtDateTo.TabIndex = 39
        '
        'app_no
        '
        Me.app_no.DataPropertyName = "app_no"
        Me.app_no.HeaderText = "เลขที่คำขอ"
        Me.app_no.Name = "app_no"
        Me.app_no.ReadOnly = True
        Me.app_no.Width = 95
        '
        'S_DATE
        '
        Me.S_DATE.DataPropertyName = "S_DATE"
        DataGridViewCellStyle1.NullValue = "1"
        Me.S_DATE.DefaultCellStyle = DataGridViewCellStyle1
        Me.S_DATE.HeaderText = "วันที่ค้นหา"
        Me.S_DATE.Name = "S_DATE"
        Me.S_DATE.ReadOnly = True
        Me.S_DATE.Width = 95
        '
        'TXT_STATUS
        '
        Me.TXT_STATUS.DataPropertyName = "TXT_STATUS"
        Me.TXT_STATUS.HeaderText = "สถานะ"
        Me.TXT_STATUS.Name = "TXT_STATUS"
        Me.TXT_STATUS.ReadOnly = True
        Me.TXT_STATUS.Width = 200
        '
        'S_TIME
        '
        Me.S_TIME.DataPropertyName = "S_TIME"
        Me.S_TIME.HeaderText = "เมื่อเวลา"
        Me.S_TIME.Name = "S_TIME"
        Me.S_TIME.ReadOnly = True
        Me.S_TIME.Width = 95
        '
        'FIND_DATE
        '
        Me.FIND_DATE.DataPropertyName = "DATE"
        Me.FIND_DATE.HeaderText = "DATE"
        Me.FIND_DATE.Name = "FIND_DATE"
        Me.FIND_DATE.ReadOnly = True
        Me.FIND_DATE.Visible = False
        '
        'FIND_STATUS
        '
        Me.FIND_STATUS.DataPropertyName = "STATUS"
        Me.FIND_STATUS.HeaderText = "STATUS"
        Me.FIND_STATUS.Name = "FIND_STATUS"
        Me.FIND_STATUS.ReadOnly = True
        Me.FIND_STATUS.Visible = False
        '
        'frmSearchHistoryFromHandheld
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 465)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GridHHT)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearchHistoryFromHandheld"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ประวัติการค้นหาข้อมูลจาก Handheld"
        CType(Me.GridHHT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtAppNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GridHHT As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDateTo As System.Windows.Forms.TextBox
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDateFrom As System.Windows.Forms.TextBox
    Friend WithEvents app_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents S_DATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TXT_STATUS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents S_TIME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FIND_DATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FIND_STATUS As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
