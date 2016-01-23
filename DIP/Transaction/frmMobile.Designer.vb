<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMobile
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMobile))
        Me.ButtonNext = New System.Windows.Forms.Button
        Me.ButtonClose = New System.Windows.Forms.Button
        Me.TabMain = New System.Windows.Forms.TabControl
        Me.TabSelection = New System.Windows.Forms.TabPage
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.ddlMobileList = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblCommentOffline = New System.Windows.Forms.Label
        Me.lblCommentOnline = New System.Windows.Forms.Label
        Me.RadioTask2 = New System.Windows.Forms.RadioButton
        Me.RadioTask1 = New System.Windows.Forms.RadioButton
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabExportOffline = New System.Windows.Forms.TabPage
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblHeader_ExOf = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txtQtyExOf = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.IconExOfStep4 = New System.Windows.Forms.PictureBox
        Me.IconExOfStep3 = New System.Windows.Forms.PictureBox
        Me.IconExOfStep2 = New System.Windows.Forms.PictureBox
        Me.IconExOfStep1 = New System.Windows.Forms.PictureBox
        Me.LabelExOfStep4 = New System.Windows.Forms.Label
        Me.LabelExOfStep3 = New System.Windows.Forms.Label
        Me.LabelExOfStep2 = New System.Windows.Forms.Label
        Me.LabelExOfStep1 = New System.Windows.Forms.Label
        Me.btnFinishEF = New System.Windows.Forms.Button
        Me.btnCancelEF = New System.Windows.Forms.Button
        Me.btnBackEF = New System.Windows.Forms.Button
        Me.TabImportOffline = New System.Windows.Forms.TabPage
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblHeader_ImOf = New System.Windows.Forms.Label
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.btnViewErrorImport = New System.Windows.Forms.Button
        Me.txtErrImOf = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.btnViewImport = New System.Windows.Forms.Button
        Me.txtQtyImOf = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.IconImOfStep4 = New System.Windows.Forms.PictureBox
        Me.IconImOfStep3 = New System.Windows.Forms.PictureBox
        Me.IconImOfStep2 = New System.Windows.Forms.PictureBox
        Me.IconImOfStep1 = New System.Windows.Forms.PictureBox
        Me.LabelImOfStep4 = New System.Windows.Forms.Label
        Me.LabelImOfStep3 = New System.Windows.Forms.Label
        Me.LabelImOfStep2 = New System.Windows.Forms.Label
        Me.LabelImOfStep1 = New System.Windows.Forms.Label
        Me.btnFinishIF = New System.Windows.Forms.Button
        Me.btnCancelIF = New System.Windows.Forms.Button
        Me.btnBackIF = New System.Windows.Forms.Button
        Me.ImageStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.TimerWait = New System.Windows.Forms.Timer(Me.components)
        Me.TabMain.SuspendLayout()
        Me.TabSelection.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabExportOffline.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IconExOfStep4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IconExOfStep3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IconExOfStep2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IconExOfStep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabImportOffline.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IconImOfStep4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IconImOfStep3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IconImOfStep2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IconImOfStep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonNext
        '
        Me.ButtonNext.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ButtonNext.Location = New System.Drawing.Point(463, 325)
        Me.ButtonNext.Name = "ButtonNext"
        Me.ButtonNext.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNext.TabIndex = 1
        Me.ButtonNext.Text = "ต่อไป"
        Me.ButtonNext.UseVisualStyleBackColor = True
        '
        'ButtonClose
        '
        Me.ButtonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonClose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ButtonClose.Location = New System.Drawing.Point(382, 325)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClose.TabIndex = 2
        Me.ButtonClose.Text = "ยกเลิก"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabMain.Controls.Add(Me.TabSelection)
        Me.TabMain.Controls.Add(Me.TabExportOffline)
        Me.TabMain.Controls.Add(Me.TabImportOffline)
        Me.TabMain.Location = New System.Drawing.Point(3, 9)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(557, 380)
        Me.TabMain.TabIndex = 3
        '
        'TabSelection
        '
        Me.TabSelection.Controls.Add(Me.Panel1)
        Me.TabSelection.Controls.Add(Me.ButtonNext)
        Me.TabSelection.Controls.Add(Me.ButtonClose)
        Me.TabSelection.Location = New System.Drawing.Point(4, 25)
        Me.TabSelection.Name = "TabSelection"
        Me.TabSelection.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSelection.Size = New System.Drawing.Size(549, 351)
        Me.TabSelection.TabIndex = 0
        Me.TabSelection.Text = "Main"
        Me.TabSelection.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.ddlMobileList)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.RadioTask2)
        Me.Panel1.Controls.Add(Me.RadioTask1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(548, 316)
        Me.Panel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(188, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 19)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "อุปกรณ์..."
        '
        'ddlMobileList
        '
        Me.ddlMobileList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlMobileList.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ddlMobileList.Items.AddRange(New Object() {"HP iPaq 1", "HP iPaq 2"})
        Me.ddlMobileList.Location = New System.Drawing.Point(212, 134)
        Me.ddlMobileList.MaxLength = 50
        Me.ddlMobileList.Name = "ddlMobileList"
        Me.ddlMobileList.Size = New System.Drawing.Size(264, 21)
        Me.ddlMobileList.TabIndex = 32
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblCommentOffline)
        Me.GroupBox1.Controls.Add(Me.lblCommentOnline)
        Me.GroupBox1.Location = New System.Drawing.Point(173, 170)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(364, 136)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "คำแนะนำ"
        '
        'lblCommentOffline
        '
        Me.lblCommentOffline.AutoSize = True
        Me.lblCommentOffline.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblCommentOffline.ForeColor = System.Drawing.Color.DimGray
        Me.lblCommentOffline.Location = New System.Drawing.Point(16, 19)
        Me.lblCommentOffline.Name = "lblCommentOffline"
        Me.lblCommentOffline.Size = New System.Drawing.Size(299, 98)
        Me.lblCommentOffline.TabIndex = 4
        Me.lblCommentOffline.Text = resources.GetString("lblCommentOffline.Text")
        '
        'lblCommentOnline
        '
        Me.lblCommentOnline.AutoSize = True
        Me.lblCommentOnline.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblCommentOnline.ForeColor = System.Drawing.Color.DimGray
        Me.lblCommentOnline.Location = New System.Drawing.Point(16, 19)
        Me.lblCommentOnline.Name = "lblCommentOnline"
        Me.lblCommentOnline.Size = New System.Drawing.Size(312, 112)
        Me.lblCommentOnline.TabIndex = 3
        Me.lblCommentOnline.Text = resources.GetString("lblCommentOnline.Text")
        Me.lblCommentOnline.Visible = False
        '
        'RadioTask2
        '
        Me.RadioTask2.AutoSize = True
        Me.RadioTask2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.RadioTask2.Location = New System.Drawing.Point(212, 71)
        Me.RadioTask2.Name = "RadioTask2"
        Me.RadioTask2.Size = New System.Drawing.Size(271, 20)
        Me.RadioTask2.TabIndex = 2
        Me.RadioTask2.TabStop = True
        Me.RadioTask2.Text = "นำผลการค้นหาแฟ้ม กลับไปบันทึกในระบบ"
        Me.RadioTask2.UseVisualStyleBackColor = True
        '
        'RadioTask1
        '
        Me.RadioTask1.AutoSize = True
        Me.RadioTask1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.RadioTask1.Location = New System.Drawing.Point(212, 48)
        Me.RadioTask1.Name = "RadioTask1"
        Me.RadioTask1.Size = New System.Drawing.Size(266, 20)
        Me.RadioTask1.TabIndex = 2
        Me.RadioTask1.TabStop = True
        Me.RadioTask1.Text = "เชื่อมต่ออุปรณ์พกพา เพื่อนำไปค้นหาแฟ้ม"
        Me.RadioTask1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = CType(resources.GetObject("PictureBox1.ErrorImage"), System.Drawing.Image)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(154, 315)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(188, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "คุณต้องการที่จะ..."
        '
        'TabExportOffline
        '
        Me.TabExportOffline.Controls.Add(Me.Panel4)
        Me.TabExportOffline.Controls.Add(Me.btnFinishEF)
        Me.TabExportOffline.Controls.Add(Me.btnCancelEF)
        Me.TabExportOffline.Controls.Add(Me.btnBackEF)
        Me.TabExportOffline.Location = New System.Drawing.Point(4, 25)
        Me.TabExportOffline.Name = "TabExportOffline"
        Me.TabExportOffline.Padding = New System.Windows.Forms.Padding(3)
        Me.TabExportOffline.Size = New System.Drawing.Size(549, 351)
        Me.TabExportOffline.TabIndex = 4
        Me.TabExportOffline.Text = "Export Offline"
        Me.TabExportOffline.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.lblHeader_ExOf)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Controls.Add(Me.PictureBox4)
        Me.Panel4.Controls.Add(Me.IconExOfStep4)
        Me.Panel4.Controls.Add(Me.IconExOfStep3)
        Me.Panel4.Controls.Add(Me.IconExOfStep2)
        Me.Panel4.Controls.Add(Me.IconExOfStep1)
        Me.Panel4.Controls.Add(Me.LabelExOfStep4)
        Me.Panel4.Controls.Add(Me.LabelExOfStep3)
        Me.Panel4.Controls.Add(Me.LabelExOfStep2)
        Me.Panel4.Controls.Add(Me.LabelExOfStep1)
        Me.Panel4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(548, 316)
        Me.Panel4.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(514, 30)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "กำลังดำเนินการส่งออก USB ... "
        '
        'lblHeader_ExOf
        '
        Me.lblHeader_ExOf.AutoSize = True
        Me.lblHeader_ExOf.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader_ExOf.Location = New System.Drawing.Point(12, 34)
        Me.lblHeader_ExOf.Name = "lblHeader_ExOf"
        Me.lblHeader_ExOf.Size = New System.Drawing.Size(69, 19)
        Me.lblHeader_ExOf.TabIndex = 39
        Me.lblHeader_ExOf.Text = "            "
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Lavender
        Me.Panel2.Controls.Add(Me.txtQtyExOf)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(275, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(250, 29)
        Me.Panel2.TabIndex = 38
        '
        'txtQtyExOf
        '
        Me.txtQtyExOf.BackColor = System.Drawing.Color.White
        Me.txtQtyExOf.Location = New System.Drawing.Point(105, 3)
        Me.txtQtyExOf.Name = "txtQtyExOf"
        Me.txtQtyExOf.ReadOnly = True
        Me.txtQtyExOf.Size = New System.Drawing.Size(76, 23)
        Me.txtQtyExOf.TabIndex = 36
        Me.txtQtyExOf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 16)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "จำนวนข้อมูล"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(190, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 16)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "รายการ"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(16, 74)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(205, 160)
        Me.PictureBox4.TabIndex = 5
        Me.PictureBox4.TabStop = False
        '
        'IconExOfStep4
        '
        Me.IconExOfStep4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.IconExOfStep4.Location = New System.Drawing.Point(289, 215)
        Me.IconExOfStep4.Name = "IconExOfStep4"
        Me.IconExOfStep4.Size = New System.Drawing.Size(16, 14)
        Me.IconExOfStep4.TabIndex = 4
        Me.IconExOfStep4.TabStop = False
        '
        'IconExOfStep3
        '
        Me.IconExOfStep3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.IconExOfStep3.Location = New System.Drawing.Point(289, 182)
        Me.IconExOfStep3.Name = "IconExOfStep3"
        Me.IconExOfStep3.Size = New System.Drawing.Size(16, 14)
        Me.IconExOfStep3.TabIndex = 4
        Me.IconExOfStep3.TabStop = False
        '
        'IconExOfStep2
        '
        Me.IconExOfStep2.BackColor = System.Drawing.Color.GreenYellow
        Me.IconExOfStep2.Location = New System.Drawing.Point(289, 149)
        Me.IconExOfStep2.Name = "IconExOfStep2"
        Me.IconExOfStep2.Size = New System.Drawing.Size(16, 14)
        Me.IconExOfStep2.TabIndex = 4
        Me.IconExOfStep2.TabStop = False
        '
        'IconExOfStep1
        '
        Me.IconExOfStep1.BackColor = System.Drawing.Color.GreenYellow
        Me.IconExOfStep1.Location = New System.Drawing.Point(289, 117)
        Me.IconExOfStep1.Name = "IconExOfStep1"
        Me.IconExOfStep1.Size = New System.Drawing.Size(16, 14)
        Me.IconExOfStep1.TabIndex = 4
        Me.IconExOfStep1.TabStop = False
        '
        'LabelExOfStep4
        '
        Me.LabelExOfStep4.AutoSize = True
        Me.LabelExOfStep4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelExOfStep4.ForeColor = System.Drawing.Color.Gray
        Me.LabelExOfStep4.Location = New System.Drawing.Point(311, 215)
        Me.LabelExOfStep4.Name = "LabelExOfStep4"
        Me.LabelExOfStep4.Size = New System.Drawing.Size(100, 14)
        Me.LabelExOfStep4.TabIndex = 0
        Me.LabelExOfStep4.Text = "เสร็จสิ้นกระบวนการ"
        '
        'LabelExOfStep3
        '
        Me.LabelExOfStep3.AutoSize = True
        Me.LabelExOfStep3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelExOfStep3.ForeColor = System.Drawing.Color.Gray
        Me.LabelExOfStep3.Location = New System.Drawing.Point(311, 182)
        Me.LabelExOfStep3.Name = "LabelExOfStep3"
        Me.LabelExOfStep3.Size = New System.Drawing.Size(153, 14)
        Me.LabelExOfStep3.TabIndex = 0
        Me.LabelExOfStep3.Text = "ส่งข้อมูลไปยัง Mobile Device"
        '
        'LabelExOfStep2
        '
        Me.LabelExOfStep2.AutoSize = True
        Me.LabelExOfStep2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelExOfStep2.ForeColor = System.Drawing.Color.Green
        Me.LabelExOfStep2.Location = New System.Drawing.Point(311, 149)
        Me.LabelExOfStep2.Name = "LabelExOfStep2"
        Me.LabelExOfStep2.Size = New System.Drawing.Size(149, 14)
        Me.LabelExOfStep2.TabIndex = 0
        Me.LabelExOfStep2.Text = "เตรียมข้อมูลสำหรับส่งออก"
        '
        'LabelExOfStep1
        '
        Me.LabelExOfStep1.AutoSize = True
        Me.LabelExOfStep1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelExOfStep1.ForeColor = System.Drawing.Color.Green
        Me.LabelExOfStep1.Location = New System.Drawing.Point(311, 117)
        Me.LabelExOfStep1.Name = "LabelExOfStep1"
        Me.LabelExOfStep1.Size = New System.Drawing.Size(136, 14)
        Me.LabelExOfStep1.TabIndex = 0
        Me.LabelExOfStep1.Text = "ตรวจสอบสภาพแวดล้อม"
        '
        'btnFinishEF
        '
        Me.btnFinishEF.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFinishEF.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnFinishEF.Location = New System.Drawing.Point(463, 325)
        Me.btnFinishEF.Name = "btnFinishEF"
        Me.btnFinishEF.Size = New System.Drawing.Size(75, 23)
        Me.btnFinishEF.TabIndex = 8
        Me.btnFinishEF.Text = "ปิด"
        Me.btnFinishEF.UseVisualStyleBackColor = True
        '
        'btnCancelEF
        '
        Me.btnCancelEF.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelEF.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnCancelEF.Location = New System.Drawing.Point(301, 325)
        Me.btnCancelEF.Name = "btnCancelEF"
        Me.btnCancelEF.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelEF.TabIndex = 10
        Me.btnCancelEF.Text = "ยกเลิก"
        Me.btnCancelEF.UseVisualStyleBackColor = True
        '
        'btnBackEF
        '
        Me.btnBackEF.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBackEF.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnBackEF.Location = New System.Drawing.Point(382, 325)
        Me.btnBackEF.Name = "btnBackEF"
        Me.btnBackEF.Size = New System.Drawing.Size(75, 23)
        Me.btnBackEF.TabIndex = 9
        Me.btnBackEF.Text = "กลับ"
        Me.btnBackEF.UseVisualStyleBackColor = True
        '
        'TabImportOffline
        '
        Me.TabImportOffline.Controls.Add(Me.Panel3)
        Me.TabImportOffline.Controls.Add(Me.btnFinishIF)
        Me.TabImportOffline.Controls.Add(Me.btnCancelIF)
        Me.TabImportOffline.Controls.Add(Me.btnBackIF)
        Me.TabImportOffline.Location = New System.Drawing.Point(4, 25)
        Me.TabImportOffline.Name = "TabImportOffline"
        Me.TabImportOffline.Padding = New System.Windows.Forms.Padding(3)
        Me.TabImportOffline.Size = New System.Drawing.Size(549, 351)
        Me.TabImportOffline.TabIndex = 6
        Me.TabImportOffline.Text = "Import Offline"
        Me.TabImportOffline.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.lblHeader_ImOf)
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Controls.Add(Me.IconImOfStep4)
        Me.Panel3.Controls.Add(Me.IconImOfStep3)
        Me.Panel3.Controls.Add(Me.IconImOfStep2)
        Me.Panel3.Controls.Add(Me.IconImOfStep1)
        Me.Panel3.Controls.Add(Me.LabelImOfStep4)
        Me.Panel3.Controls.Add(Me.LabelImOfStep3)
        Me.Panel3.Controls.Add(Me.LabelImOfStep2)
        Me.Panel3.Controls.Add(Me.LabelImOfStep1)
        Me.Panel3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(548, 316)
        Me.Panel3.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(514, 30)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "กำลังดำเนินการส่งออก USB ... "
        '
        'lblHeader_ImOf
        '
        Me.lblHeader_ImOf.AutoSize = True
        Me.lblHeader_ImOf.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader_ImOf.Location = New System.Drawing.Point(12, 34)
        Me.lblHeader_ImOf.Name = "lblHeader_ImOf"
        Me.lblHeader_ImOf.Size = New System.Drawing.Size(69, 19)
        Me.lblHeader_ImOf.TabIndex = 39
        Me.lblHeader_ImOf.Text = "            "
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DarkOrange
        Me.Panel6.Controls.Add(Me.btnViewErrorImport)
        Me.Panel6.Controls.Add(Me.txtErrImOf)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Controls.Add(Me.Label10)
        Me.Panel6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel6.Location = New System.Drawing.Point(258, 99)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(279, 29)
        Me.Panel6.TabIndex = 38
        Me.Panel6.Visible = False
        '
        'btnViewErrorImport
        '
        Me.btnViewErrorImport.Image = CType(resources.GetObject("btnViewErrorImport.Image"), System.Drawing.Image)
        Me.btnViewErrorImport.Location = New System.Drawing.Point(238, 3)
        Me.btnViewErrorImport.Name = "btnViewErrorImport"
        Me.btnViewErrorImport.Size = New System.Drawing.Size(38, 23)
        Me.btnViewErrorImport.TabIndex = 38
        Me.btnViewErrorImport.UseVisualStyleBackColor = True
        '
        'txtErrImOf
        '
        Me.txtErrImOf.BackColor = System.Drawing.Color.White
        Me.txtErrImOf.Location = New System.Drawing.Point(105, 3)
        Me.txtErrImOf.Name = "txtErrImOf"
        Me.txtErrImOf.ReadOnly = True
        Me.txtErrImOf.Size = New System.Drawing.Size(76, 23)
        Me.txtErrImOf.TabIndex = 36
        Me.txtErrImOf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 16)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "ที่มีปัญหา"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(182, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 16)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "รายการ"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Lavender
        Me.Panel5.Controls.Add(Me.btnViewImport)
        Me.Panel5.Controls.Add(Me.txtQtyImOf)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel5.Location = New System.Drawing.Point(258, 64)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(279, 29)
        Me.Panel5.TabIndex = 38
        '
        'btnViewImport
        '
        Me.btnViewImport.Image = CType(resources.GetObject("btnViewImport.Image"), System.Drawing.Image)
        Me.btnViewImport.Location = New System.Drawing.Point(238, 3)
        Me.btnViewImport.Name = "btnViewImport"
        Me.btnViewImport.Size = New System.Drawing.Size(38, 23)
        Me.btnViewImport.TabIndex = 37
        Me.btnViewImport.UseVisualStyleBackColor = True
        '
        'txtQtyImOf
        '
        Me.txtQtyImOf.BackColor = System.Drawing.Color.White
        Me.txtQtyImOf.Location = New System.Drawing.Point(105, 3)
        Me.txtQtyImOf.Name = "txtQtyImOf"
        Me.txtQtyImOf.ReadOnly = True
        Me.txtQtyImOf.Size = New System.Drawing.Size(76, 23)
        Me.txtQtyImOf.TabIndex = 36
        Me.txtQtyImOf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 16)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "จำนวนข้อมูล"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(182, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 16)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "รายการ"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(16, 74)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(205, 160)
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'IconImOfStep4
        '
        Me.IconImOfStep4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.IconImOfStep4.Location = New System.Drawing.Point(270, 254)
        Me.IconImOfStep4.Name = "IconImOfStep4"
        Me.IconImOfStep4.Size = New System.Drawing.Size(16, 14)
        Me.IconImOfStep4.TabIndex = 4
        Me.IconImOfStep4.TabStop = False
        '
        'IconImOfStep3
        '
        Me.IconImOfStep3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.IconImOfStep3.Location = New System.Drawing.Point(270, 221)
        Me.IconImOfStep3.Name = "IconImOfStep3"
        Me.IconImOfStep3.Size = New System.Drawing.Size(16, 14)
        Me.IconImOfStep3.TabIndex = 4
        Me.IconImOfStep3.TabStop = False
        '
        'IconImOfStep2
        '
        Me.IconImOfStep2.BackColor = System.Drawing.Color.GreenYellow
        Me.IconImOfStep2.Location = New System.Drawing.Point(270, 188)
        Me.IconImOfStep2.Name = "IconImOfStep2"
        Me.IconImOfStep2.Size = New System.Drawing.Size(16, 14)
        Me.IconImOfStep2.TabIndex = 4
        Me.IconImOfStep2.TabStop = False
        '
        'IconImOfStep1
        '
        Me.IconImOfStep1.BackColor = System.Drawing.Color.GreenYellow
        Me.IconImOfStep1.Location = New System.Drawing.Point(270, 156)
        Me.IconImOfStep1.Name = "IconImOfStep1"
        Me.IconImOfStep1.Size = New System.Drawing.Size(16, 14)
        Me.IconImOfStep1.TabIndex = 4
        Me.IconImOfStep1.TabStop = False
        '
        'LabelImOfStep4
        '
        Me.LabelImOfStep4.AutoSize = True
        Me.LabelImOfStep4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelImOfStep4.ForeColor = System.Drawing.Color.Gray
        Me.LabelImOfStep4.Location = New System.Drawing.Point(292, 254)
        Me.LabelImOfStep4.Name = "LabelImOfStep4"
        Me.LabelImOfStep4.Size = New System.Drawing.Size(100, 14)
        Me.LabelImOfStep4.TabIndex = 0
        Me.LabelImOfStep4.Text = "เสร็จสิ้นกระบวนการ"
        '
        'LabelImOfStep3
        '
        Me.LabelImOfStep3.AutoSize = True
        Me.LabelImOfStep3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelImOfStep3.ForeColor = System.Drawing.Color.Gray
        Me.LabelImOfStep3.Location = New System.Drawing.Point(292, 221)
        Me.LabelImOfStep3.Name = "LabelImOfStep3"
        Me.LabelImOfStep3.Size = New System.Drawing.Size(200, 14)
        Me.LabelImOfStep3.TabIndex = 0
        Me.LabelImOfStep3.Text = "Update ข้อมูลการค้นหาไปยังฐานข้อมูล"
        '
        'LabelImOfStep2
        '
        Me.LabelImOfStep2.AutoSize = True
        Me.LabelImOfStep2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelImOfStep2.ForeColor = System.Drawing.Color.Green
        Me.LabelImOfStep2.Location = New System.Drawing.Point(292, 188)
        Me.LabelImOfStep2.Name = "LabelImOfStep2"
        Me.LabelImOfStep2.Size = New System.Drawing.Size(142, 14)
        Me.LabelImOfStep2.TabIndex = 0
        Me.LabelImOfStep2.Text = "เตรียมข้อมูลสำหรับนำเข้า"
        '
        'LabelImOfStep1
        '
        Me.LabelImOfStep1.AutoSize = True
        Me.LabelImOfStep1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelImOfStep1.ForeColor = System.Drawing.Color.Green
        Me.LabelImOfStep1.Location = New System.Drawing.Point(292, 156)
        Me.LabelImOfStep1.Name = "LabelImOfStep1"
        Me.LabelImOfStep1.Size = New System.Drawing.Size(136, 14)
        Me.LabelImOfStep1.TabIndex = 0
        Me.LabelImOfStep1.Text = "ตรวจสอบสภาพแวดล้อม"
        '
        'btnFinishIF
        '
        Me.btnFinishIF.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFinishIF.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnFinishIF.Location = New System.Drawing.Point(463, 325)
        Me.btnFinishIF.Name = "btnFinishIF"
        Me.btnFinishIF.Size = New System.Drawing.Size(75, 23)
        Me.btnFinishIF.TabIndex = 8
        Me.btnFinishIF.Text = "ปิด"
        Me.btnFinishIF.UseVisualStyleBackColor = True
        '
        'btnCancelIF
        '
        Me.btnCancelIF.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelIF.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnCancelIF.Location = New System.Drawing.Point(301, 325)
        Me.btnCancelIF.Name = "btnCancelIF"
        Me.btnCancelIF.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelIF.TabIndex = 10
        Me.btnCancelIF.Text = "ยกเลิก"
        Me.btnCancelIF.UseVisualStyleBackColor = True
        '
        'btnBackIF
        '
        Me.btnBackIF.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBackIF.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnBackIF.Location = New System.Drawing.Point(382, 325)
        Me.btnBackIF.Name = "btnBackIF"
        Me.btnBackIF.Size = New System.Drawing.Size(75, 23)
        Me.btnBackIF.TabIndex = 9
        Me.btnBackIF.Text = "กลับ"
        Me.btnBackIF.UseVisualStyleBackColor = True
        '
        'ImageStatus
        '
        Me.ImageStatus.ImageStream = CType(resources.GetObject("ImageStatus.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageStatus.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageStatus.Images.SetKeyName(0, "Box.png")
        Me.ImageStatus.Images.SetKeyName(1, "True.png")
        Me.ImageStatus.Images.SetKeyName(2, "False.png")
        '
        'TimerWait
        '
        Me.TimerWait.Interval = 1000
        '
        'frmMobile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.ButtonClose
        Me.ClientSize = New System.Drawing.Size(562, 387)
        Me.Controls.Add(Me.TabMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMobile"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mobile Device"
        Me.TabMain.ResumeLayout(False)
        Me.TabSelection.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabExportOffline.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IconExOfStep4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IconExOfStep3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IconExOfStep2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IconExOfStep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabImportOffline.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IconImOfStep4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IconImOfStep3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IconImOfStep2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IconImOfStep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonNext As System.Windows.Forms.Button
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents TabSelection As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCommentOnline As System.Windows.Forms.Label
    Friend WithEvents RadioTask2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioTask1 As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ImageStatus As System.Windows.Forms.ImageList
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ddlMobileList As System.Windows.Forms.ComboBox
    Friend WithEvents lblCommentOffline As System.Windows.Forms.Label
    Friend WithEvents TabExportOffline As System.Windows.Forms.TabPage
    Friend WithEvents TabImportOffline As System.Windows.Forms.TabPage
    Friend WithEvents btnFinishEF As System.Windows.Forms.Button
    Friend WithEvents btnCancelEF As System.Windows.Forms.Button
    Friend WithEvents btnBackEF As System.Windows.Forms.Button
    Friend WithEvents btnFinishIF As System.Windows.Forms.Button
    Friend WithEvents btnCancelIF As System.Windows.Forms.Button
    Friend WithEvents btnBackIF As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblHeader_ExOf As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtQtyExOf As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents IconExOfStep4 As System.Windows.Forms.PictureBox
    Friend WithEvents IconExOfStep3 As System.Windows.Forms.PictureBox
    Friend WithEvents IconExOfStep2 As System.Windows.Forms.PictureBox
    Friend WithEvents IconExOfStep1 As System.Windows.Forms.PictureBox
    Friend WithEvents LabelExOfStep4 As System.Windows.Forms.Label
    Friend WithEvents LabelExOfStep3 As System.Windows.Forms.Label
    Friend WithEvents LabelExOfStep2 As System.Windows.Forms.Label
    Friend WithEvents LabelExOfStep1 As System.Windows.Forms.Label
    Friend WithEvents TimerWait As System.Windows.Forms.Timer
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblHeader_ImOf As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents txtQtyImOf As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents IconImOfStep4 As System.Windows.Forms.PictureBox
    Friend WithEvents IconImOfStep3 As System.Windows.Forms.PictureBox
    Friend WithEvents IconImOfStep2 As System.Windows.Forms.PictureBox
    Friend WithEvents IconImOfStep1 As System.Windows.Forms.PictureBox
    Friend WithEvents LabelImOfStep4 As System.Windows.Forms.Label
    Friend WithEvents LabelImOfStep3 As System.Windows.Forms.Label
    Friend WithEvents LabelImOfStep2 As System.Windows.Forms.Label
    Friend WithEvents LabelImOfStep1 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents txtErrImOf As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnViewErrorImport As System.Windows.Forms.Button
    Friend WithEvents btnViewImport As System.Windows.Forms.Button
End Class
