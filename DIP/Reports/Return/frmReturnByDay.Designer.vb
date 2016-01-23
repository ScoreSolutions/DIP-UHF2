<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReturnByDay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReturnByDay))
        Me.btnPreviewReport = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtDateFrom = New DIP.txtDate
        Me.txtDateTo = New DIP.txtDate
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.cmbPatentType = New System.Windows.Forms.ComboBox
        Me.lbType = New System.Windows.Forms.Label
        Me.lbDateStartUp = New System.Windows.Forms.Label
        Me.lbDateStart = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPreviewReport
        '
        Me.btnPreviewReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnPreviewReport.Location = New System.Drawing.Point(453, 318)
        Me.btnPreviewReport.Name = "btnPreviewReport"
        Me.btnPreviewReport.Size = New System.Drawing.Size(117, 45)
        Me.btnPreviewReport.TabIndex = 19
        Me.btnPreviewReport.Text = "แสดงรายงาน"
        Me.btnPreviewReport.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtDateFrom)
        Me.Panel1.Controls.Add(Me.txtDateTo)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.lbType)
        Me.Panel1.Controls.Add(Me.lbDateStartUp)
        Me.Panel1.Controls.Add(Me.lbDateStart)
        Me.Panel1.Location = New System.Drawing.Point(141, 134)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(443, 112)
        Me.Panel1.TabIndex = 21
        '
        'txtDateFrom
        '
        Me.txtDateFrom.DateValue = New Date(CType(0, Long))
        Me.txtDateFrom.Location = New System.Drawing.Point(125, 21)
        Me.txtDateFrom.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(129, 26)
        Me.txtDateFrom.TabIndex = 33
        '
        'txtDateTo
        '
        Me.txtDateTo.DateValue = New Date(CType(0, Long))
        Me.txtDateTo.Location = New System.Drawing.Point(303, 21)
        Me.txtDateTo.Margin = New System.Windows.Forms.Padding(5)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(126, 26)
        Me.txtDateTo.TabIndex = 34
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.cmbPatentType)
        Me.Panel2.Location = New System.Drawing.Point(125, 63)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(296, 28)
        Me.Panel2.TabIndex = 31
        '
        'cmbPatentType
        '
        Me.cmbPatentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPatentType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbPatentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbPatentType.FormattingEnabled = True
        Me.cmbPatentType.Location = New System.Drawing.Point(-1, -2)
        Me.cmbPatentType.Name = "cmbPatentType"
        Me.cmbPatentType.Size = New System.Drawing.Size(293, 28)
        Me.cmbPatentType.TabIndex = 30
        '
        'lbType
        '
        Me.lbType.AutoSize = True
        Me.lbType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbType.Location = New System.Drawing.Point(14, 63)
        Me.lbType.Name = "lbType"
        Me.lbType.Size = New System.Drawing.Size(105, 20)
        Me.lbType.TabIndex = 29
        Me.lbType.Text = "ประเภทแฟ้ม :"
        '
        'lbDateStartUp
        '
        Me.lbDateStartUp.AutoSize = True
        Me.lbDateStartUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbDateStartUp.Location = New System.Drawing.Point(257, 24)
        Me.lbDateStartUp.Name = "lbDateStartUp"
        Me.lbDateStartUp.Size = New System.Drawing.Size(37, 20)
        Me.lbDateStartUp.TabIndex = 26
        Me.lbDateStartUp.Text = "ถึง :"
        '
        'lbDateStart
        '
        Me.lbDateStart.AutoSize = True
        Me.lbDateStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbDateStart.Location = New System.Drawing.Point(51, 24)
        Me.lbDateStart.Name = "lbDateStart"
        Me.lbDateStart.Size = New System.Drawing.Size(68, 20)
        Me.lbDateStart.TabIndex = 22
        Me.lbDateStart.Text = "วันที่คืน :"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(109, 5)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(496, 40)
        Me.TextBox1.TabIndex = 22
        Me.TextBox1.Text = "รายงานการคืนแฟ้มประจำวัน"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 457)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'frmReturnByDay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 397)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnPreviewReport)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReturnByDay"
        Me.Text = "รายงานการคืนแฟ้มประจำวัน"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPreviewReport As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtDate1 As DIP.txtDate
    Friend WithEvents lbDateStartUp As System.Windows.Forms.Label
    Friend WithEvents lbDateStart As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtDate2 As DIP.txtDate
    Friend WithEvents cmbPatentType As System.Windows.Forms.ComboBox
    Friend WithEvents lbType As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtDateFrom As DIP.txtDate
    Friend WithEvents txtDateTo As DIP.txtDate
End Class
