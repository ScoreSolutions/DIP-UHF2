<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOfficer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOfficer))
        Me.ข้อมูลผู้ใช้งาน = New System.Windows.Forms.GroupBox
        Me.txtCpw = New System.Windows.Forms.TextBox
        Me.txtPw = New System.Windows.Forms.TextBox
        Me.txtUs = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtOfficerNo = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtId = New System.Windows.Forms.TextBox
        Me.cbDepartment = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbPosition = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbTitle = New System.Windows.Forms.ComboBox
        Me.txtlname = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtfname = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.CtlAuthGroupList = New DIP.ctlAuthList
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.CtlAuthPersonList = New DIP.ctlAuthList
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSaveRFID = New System.Windows.Forms.Button
        Me.ข้อมูลผู้ใช้งาน.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ข้อมูลผู้ใช้งาน
        '
        Me.ข้อมูลผู้ใช้งาน.Controls.Add(Me.txtCpw)
        Me.ข้อมูลผู้ใช้งาน.Controls.Add(Me.txtPw)
        Me.ข้อมูลผู้ใช้งาน.Controls.Add(Me.txtUs)
        Me.ข้อมูลผู้ใช้งาน.Controls.Add(Me.Label3)
        Me.ข้อมูลผู้ใช้งาน.Controls.Add(Me.Label2)
        Me.ข้อมูลผู้ใช้งาน.Controls.Add(Me.Label1)
        Me.ข้อมูลผู้ใช้งาน.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ข้อมูลผู้ใช้งาน.Location = New System.Drawing.Point(12, 12)
        Me.ข้อมูลผู้ใช้งาน.Name = "ข้อมูลผู้ใช้งาน"
        Me.ข้อมูลผู้ใช้งาน.Size = New System.Drawing.Size(316, 136)
        Me.ข้อมูลผู้ใช้งาน.TabIndex = 0
        Me.ข้อมูลผู้ใช้งาน.TabStop = False
        Me.ข้อมูลผู้ใช้งาน.Text = "ข้อมูลการเข้าระบบ"
        '
        'txtCpw
        '
        Me.txtCpw.Location = New System.Drawing.Point(107, 96)
        Me.txtCpw.Name = "txtCpw"
        Me.txtCpw.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCpw.Size = New System.Drawing.Size(190, 25)
        Me.txtCpw.TabIndex = 5
        '
        'txtPw
        '
        Me.txtPw.Location = New System.Drawing.Point(107, 63)
        Me.txtPw.Name = "txtPw"
        Me.txtPw.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPw.Size = New System.Drawing.Size(190, 25)
        Me.txtPw.TabIndex = 4
        '
        'txtUs
        '
        Me.txtUs.Location = New System.Drawing.Point(107, 29)
        Me.txtUs.Name = "txtUs"
        Me.txtUs.Size = New System.Drawing.Size(190, 25)
        Me.txtUs.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "ยืนยันรหัสผ่าน"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(46, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "รหัสผ่าน"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ชื่อเข้าระบบ"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtOfficerNo)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtId)
        Me.GroupBox2.Controls.Add(Me.cbDepartment)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cbPosition)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cbTitle)
        Me.GroupBox2.Controls.Add(Me.txtlname)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtfname)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(342, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(603, 138)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ข้อมูลผู้ใช้งาน"
        '
        'txtOfficerNo
        '
        Me.txtOfficerNo.Location = New System.Drawing.Point(104, 29)
        Me.txtOfficerNo.Name = "txtOfficerNo"
        Me.txtOfficerNo.Size = New System.Drawing.Size(265, 25)
        Me.txtOfficerNo.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 17)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "รหัสเจ้าหน้าที่"
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(469, 29)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(33, 25)
        Me.txtId.TabIndex = 15
        Me.txtId.Visible = False
        '
        'cbDepartment
        '
        Me.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDepartment.FormattingEnabled = True
        Me.cbDepartment.Location = New System.Drawing.Point(377, 96)
        Me.cbDepartment.Name = "cbDepartment"
        Me.cbDepartment.Size = New System.Drawing.Size(200, 25)
        Me.cbDepartment.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(320, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 17)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "หน่วยงาน"
        '
        'cbPosition
        '
        Me.cbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPosition.FormattingEnabled = True
        Me.cbPosition.Location = New System.Drawing.Point(104, 96)
        Me.cbPosition.Name = "cbPosition"
        Me.cbPosition.Size = New System.Drawing.Size(200, 25)
        Me.cbPosition.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(39, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 17)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "ตำแหน่ง"
        '
        'cbTitle
        '
        Me.cbTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTitle.FormattingEnabled = True
        Me.cbTitle.Location = New System.Drawing.Point(104, 62)
        Me.cbTitle.Name = "cbTitle"
        Me.cbTitle.Size = New System.Drawing.Size(100, 25)
        Me.cbTitle.TabIndex = 6
        '
        'txtlname
        '
        Me.txtlname.Location = New System.Drawing.Point(420, 62)
        Me.txtlname.Name = "txtlname"
        Me.txtlname.Size = New System.Drawing.Size(157, 25)
        Me.txtlname.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(381, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 17)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "สกุล"
        '
        'txtfname
        '
        Me.txtfname.Location = New System.Drawing.Point(243, 62)
        Me.txtfname.Name = "txtfname"
        Me.txtfname.Size = New System.Drawing.Size(126, 25)
        Me.txtfname.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(214, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 17)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "ชื่อ"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "คำนำหน้าชื่อ"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 154)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(933, 347)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage1.Controls.Add(Me.CtlAuthGroupList)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(925, 321)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "สิทธิ์การใช้ตามกลุ่ม"
        '
        'CtlAuthGroupList
        '
        Me.CtlAuthGroupList.Location = New System.Drawing.Point(17, 14)
        Me.CtlAuthGroupList.Name = "CtlAuthGroupList"
        Me.CtlAuthGroupList.Size = New System.Drawing.Size(884, 290)
        Me.CtlAuthGroupList.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage2.Controls.Add(Me.CtlAuthPersonList)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(925, 321)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "สิทธิ์การใช้รายบุคคล"
        '
        'CtlAuthPersonList
        '
        Me.CtlAuthPersonList.Location = New System.Drawing.Point(17, 14)
        Me.CtlAuthPersonList.Name = "CtlAuthPersonList"
        Me.CtlAuthPersonList.Size = New System.Drawing.Size(884, 290)
        Me.CtlAuthPersonList.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(646, 507)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 31)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "บันทึก"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(744, 507)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 31)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "ยกเลิก"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSaveRFID
        '
        Me.btnSaveRFID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveRFID.Location = New System.Drawing.Point(853, 507)
        Me.btnSaveRFID.Name = "btnSaveRFID"
        Me.btnSaveRFID.Size = New System.Drawing.Size(88, 31)
        Me.btnSaveRFID.TabIndex = 5
        Me.btnSaveRFID.Text = "บันทึกลง RFID"
        Me.btnSaveRFID.UseVisualStyleBackColor = True
        '
        'frmOfficer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(957, 547)
        Me.Controls.Add(Me.btnSaveRFID)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ข้อมูลผู้ใช้งาน)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOfficer"
        Me.ShowInTaskbar = False
        Me.Text = "ข้อมูลผู้ใช้งาน"
        Me.ข้อมูลผู้ใช้งาน.ResumeLayout(False)
        Me.ข้อมูลผู้ใช้งาน.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ข้อมูลผู้ใช้งาน As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCpw As System.Windows.Forms.TextBox
    Friend WithEvents txtPw As System.Windows.Forms.TextBox
    Friend WithEvents txtUs As System.Windows.Forms.TextBox
    Friend WithEvents cbPosition As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbTitle As System.Windows.Forms.ComboBox
    Friend WithEvents txtlname As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtfname As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents CtlAuthGroupList As DIP.ctlAuthList
    Friend WithEvents CtlAuthPersonList As DIP.ctlAuthList
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSaveRFID As System.Windows.Forms.Button
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents txtOfficerNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
