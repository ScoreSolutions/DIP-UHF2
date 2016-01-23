<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormAddItem
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
    Private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAddItem))
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureLogo = New System.Windows.Forms.PictureBox
        Me.PicBack = New System.Windows.Forms.PictureBox
        Me.LinkBack = New System.Windows.Forms.LinkLabel
        Me.Label4 = New System.Windows.Forms.Label
        Me.IconAdd = New System.Windows.Forms.PictureBox
        Me.lnkAdd = New System.Windows.Forms.Label
        Me.txtStart1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtStart2 = New System.Windows.Forms.TextBox
        Me.txtStart3 = New System.Windows.Forms.TextBox
        Me.chkTo = New System.Windows.Forms.CheckBox
        Me.txtEnd1 = New System.Windows.Forms.TextBox
        Me.txtEnd2 = New System.Windows.Forms.TextBox
        Me.txtEnd3 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.White
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(-160, 301)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(400, 20)
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(14, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(58, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(581, 35)
        Me.Label1.Text = "ระบบการจัดการแฟ้มทะเบียน" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "สำนักสิทธิบัตร(ค้นหาแฟ้ม)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureLogo
        '
        Me.PictureLogo.Image = CType(resources.GetObject("PictureLogo.Image"), System.Drawing.Image)
        Me.PictureLogo.Location = New System.Drawing.Point(3, 0)
        Me.PictureLogo.Name = "PictureLogo"
        Me.PictureLogo.Size = New System.Drawing.Size(54, 35)
        Me.PictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'PicBack
        '
        Me.PicBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicBack.Image = CType(resources.GetObject("PicBack.Image"), System.Drawing.Image)
        Me.PicBack.Location = New System.Drawing.Point(3, 438)
        Me.PicBack.Name = "PicBack"
        Me.PicBack.Size = New System.Drawing.Size(21, 20)
        '
        'LinkBack
        '
        Me.LinkBack.Location = New System.Drawing.Point(3, 276)
        Me.LinkBack.Name = "LinkBack"
        Me.LinkBack.Size = New System.Drawing.Size(122, 20)
        Me.LinkBack.TabIndex = 7
        Me.LinkBack.Text = "ยกเลิกและย้อนกลับ"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.SeaGreen
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(2, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(637, 20)
        Me.Label4.Text = "เพิ่มเลขแฟ้มที่ต้องค้นหา"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'IconAdd
        '
        Me.IconAdd.Image = CType(resources.GetObject("IconAdd.Image"), System.Drawing.Image)
        Me.IconAdd.Location = New System.Drawing.Point(219, 279)
        Me.IconAdd.Name = "IconAdd"
        Me.IconAdd.Size = New System.Drawing.Size(16, 16)
        '
        'lnkAdd
        '
        Me.lnkAdd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Underline)
        Me.lnkAdd.ForeColor = System.Drawing.Color.SeaGreen
        Me.lnkAdd.Location = New System.Drawing.Point(131, 279)
        Me.lnkAdd.Name = "lnkAdd"
        Me.lnkAdd.Size = New System.Drawing.Size(85, 17)
        Me.lnkAdd.Text = "เพิ่มเลขแฟ้ม"
        Me.lnkAdd.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtStart1
        '
        Me.txtStart1.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtStart1.Location = New System.Drawing.Point(92, 101)
        Me.txtStart1.MaxLength = 2
        Me.txtStart1.Name = "txtStart1"
        Me.txtStart1.Size = New System.Drawing.Size(28, 29)
        Me.txtStart1.TabIndex = 12
        Me.txtStart1.Text = "10"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.GhostWhite
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(25, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 20)
        Me.Label2.Text = "เลขแฟ้ม"
        '
        'txtStart2
        '
        Me.txtStart2.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtStart2.Location = New System.Drawing.Point(124, 101)
        Me.txtStart2.MaxLength = 2
        Me.txtStart2.Name = "txtStart2"
        Me.txtStart2.Size = New System.Drawing.Size(28, 29)
        Me.txtStart2.TabIndex = 14
        Me.txtStart2.Text = "02"
        '
        'txtStart3
        '
        Me.txtStart3.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtStart3.Location = New System.Drawing.Point(158, 101)
        Me.txtStart3.MaxLength = 6
        Me.txtStart3.Name = "txtStart3"
        Me.txtStart3.Size = New System.Drawing.Size(68, 29)
        Me.txtStart3.TabIndex = 14
        Me.txtStart3.Text = "000005"
        '
        'chkTo
        '
        Me.chkTo.BackColor = System.Drawing.Color.GhostWhite
        Me.chkTo.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.chkTo.Location = New System.Drawing.Point(86, 56)
        Me.chkTo.Name = "chkTo"
        Me.chkTo.Size = New System.Drawing.Size(78, 20)
        Me.chkTo.TabIndex = 15
        Me.chkTo.Text = "ถึง"
        '
        'txtEnd1
        '
        Me.txtEnd1.Enabled = False
        Me.txtEnd1.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtEnd1.Location = New System.Drawing.Point(92, 192)
        Me.txtEnd1.MaxLength = 2
        Me.txtEnd1.Name = "txtEnd1"
        Me.txtEnd1.Size = New System.Drawing.Size(28, 29)
        Me.txtEnd1.TabIndex = 12
        '
        'txtEnd2
        '
        Me.txtEnd2.Enabled = False
        Me.txtEnd2.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtEnd2.Location = New System.Drawing.Point(124, 192)
        Me.txtEnd2.MaxLength = 2
        Me.txtEnd2.Name = "txtEnd2"
        Me.txtEnd2.Size = New System.Drawing.Size(28, 29)
        Me.txtEnd2.TabIndex = 14
        '
        'txtEnd3
        '
        Me.txtEnd3.Enabled = False
        Me.txtEnd3.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtEnd3.Location = New System.Drawing.Point(158, 192)
        Me.txtEnd3.MaxLength = 6
        Me.txtEnd3.Name = "txtEnd3"
        Me.txtEnd3.Size = New System.Drawing.Size(68, 29)
        Me.txtEnd3.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.GhostWhite
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(25, 196)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 20)
        Me.Label3.Text = "เลขแฟ้ม"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.GhostWhite
        Me.Panel1.Controls.Add(Me.chkTo)
        Me.Panel1.Location = New System.Drawing.Point(10, 92)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(225, 142)
        '
        'FormAddItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(640, 480)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtEnd3)
        Me.Controls.Add(Me.txtStart3)
        Me.Controls.Add(Me.txtEnd2)
        Me.Controls.Add(Me.txtEnd1)
        Me.Controls.Add(Me.txtStart2)
        Me.Controls.Add(Me.txtStart1)
        Me.Controls.Add(Me.lnkAdd)
        Me.Controls.Add(Me.IconAdd)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LinkBack)
        Me.Controls.Add(Me.PicBack)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureLogo)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "FormAddItem"
        Me.Text = "DIP File Tracker"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents IconAdd As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LinkBack As System.Windows.Forms.LinkLabel
    Friend WithEvents PicBack As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureLogo As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents lnkAdd As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtStart1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtStart2 As System.Windows.Forms.TextBox
    Friend WithEvents txtStart3 As System.Windows.Forms.TextBox
    Friend WithEvents chkTo As System.Windows.Forms.CheckBox
    Friend WithEvents txtEnd1 As System.Windows.Forms.TextBox
    Friend WithEvents txtEnd2 As System.Windows.Forms.TextBox
    Friend WithEvents txtEnd3 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
