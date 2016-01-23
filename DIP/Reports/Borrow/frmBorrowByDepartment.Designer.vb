<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBorrowByDepartment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBorrowByDepartment))
        Me.btnPreviewReport = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rdiStatusAll = New System.Windows.Forms.RadioButton
        Me.rdiStatusNoReturn = New System.Windows.Forms.RadioButton
        Me.rdiStatusReturn = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbDepartment = New System.Windows.Forms.ComboBox
        Me.TxtDate2 = New DIP.txtDate
        Me.TxtDate1 = New DIP.txtDate
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPreviewReport
        '
        Me.btnPreviewReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnPreviewReport.Location = New System.Drawing.Point(437, 295)
        Me.btnPreviewReport.Name = "btnPreviewReport"
        Me.btnPreviewReport.Size = New System.Drawing.Size(117, 45)
        Me.btnPreviewReport.TabIndex = 19
        Me.btnPreviewReport.Text = "แสดงรายงาน"
        Me.btnPreviewReport.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdiStatusAll)
        Me.Panel1.Controls.Add(Me.rdiStatusNoReturn)
        Me.Panel1.Controls.Add(Me.rdiStatusReturn)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cmbDepartment)
        Me.Panel1.Controls.Add(Me.TxtDate2)
        Me.Panel1.Controls.Add(Me.TxtDate1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(146, 119)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(469, 170)
        Me.Panel1.TabIndex = 21
        '
        'rdiStatusAll
        '
        Me.rdiStatusAll.AutoSize = True
        Me.rdiStatusAll.Checked = True
        Me.rdiStatusAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdiStatusAll.Location = New System.Drawing.Point(381, 103)
        Me.rdiStatusAll.Name = "rdiStatusAll"
        Me.rdiStatusAll.Size = New System.Drawing.Size(77, 24)
        Me.rdiStatusAll.TabIndex = 33
        Me.rdiStatusAll.TabStop = True
        Me.rdiStatusAll.Text = "ทั้งหมด"
        Me.rdiStatusAll.UseVisualStyleBackColor = True
        '
        'rdiStatusNoReturn
        '
        Me.rdiStatusNoReturn.AutoSize = True
        Me.rdiStatusNoReturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdiStatusNoReturn.Location = New System.Drawing.Point(250, 103)
        Me.rdiStatusNoReturn.Name = "rdiStatusNoReturn"
        Me.rdiStatusNoReturn.Size = New System.Drawing.Size(127, 24)
        Me.rdiStatusNoReturn.TabIndex = 32
        Me.rdiStatusNoReturn.Text = "ยืมโดยการโอน"
        Me.rdiStatusNoReturn.UseVisualStyleBackColor = True
        '
        'rdiStatusReturn
        '
        Me.rdiStatusReturn.AutoSize = True
        Me.rdiStatusReturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdiStatusReturn.Location = New System.Drawing.Point(127, 103)
        Me.rdiStatusReturn.Name = "rdiStatusReturn"
        Me.rdiStatusReturn.Size = New System.Drawing.Size(117, 24)
        Me.rdiStatusReturn.TabIndex = 31
        Me.rdiStatusReturn.Text = "ยืมที่ห้องแฟ้ม"
        Me.rdiStatusReturn.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 20)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "ลักษณะการยืม :"
        '
        'cmbDepartment
        '
        Me.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbDepartment.FormattingEnabled = True
        Me.cmbDepartment.Location = New System.Drawing.Point(130, 26)
        Me.cmbDepartment.Name = "cmbDepartment"
        Me.cmbDepartment.Size = New System.Drawing.Size(278, 28)
        Me.cmbDepartment.TabIndex = 29
        '
        'TxtDate2
        '
        Me.TxtDate2.DateValue = New Date(CType(0, Long))
        Me.TxtDate2.Location = New System.Drawing.Point(290, 66)
        Me.TxtDate2.Name = "TxtDate2"
        Me.TxtDate2.Size = New System.Drawing.Size(118, 26)
        Me.TxtDate2.TabIndex = 28
        '
        'TxtDate1
        '
        Me.TxtDate1.DateValue = New Date(CType(0, Long))
        Me.TxtDate1.Location = New System.Drawing.Point(130, 67)
        Me.TxtDate1.Name = "TxtDate1"
        Me.TxtDate1.Size = New System.Drawing.Size(118, 26)
        Me.TxtDate1.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(254, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 20)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "ถึง :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(54, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 20)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "วันที่ยืม :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(66, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 20)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "สังกัด :"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(108, 5)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(496, 40)
        Me.TextBox1.TabIndex = 22
        Me.TextBox1.Text = "รายงานการยืมแฟ้ม (ตามสังกัด)"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(108, 499)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 24
        Me.PictureBox1.TabStop = False
        '
        'frmBorrowByDepartment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 404)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnPreviewReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBorrowByDepartment"
        Me.Text = "รายงานการยืมแฟ้มตามสังกัด"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPreviewReport As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtDate1 As DIP.txtDate
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtDate2 As DIP.txtDate
    Friend WithEvents cmbDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents rdiStatusAll As System.Windows.Forms.RadioButton
    Friend WithEvents rdiStatusNoReturn As System.Windows.Forms.RadioButton
    Friend WithEvents rdiStatusReturn As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
