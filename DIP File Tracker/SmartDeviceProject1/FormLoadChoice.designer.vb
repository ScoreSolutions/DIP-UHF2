<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormLoadChoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLoadChoice))
        Me.PictureLogo = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.ButtonOffline = New System.Windows.Forms.LinkLabel
        Me.ButtonExit = New System.Windows.Forms.LinkLabel
        Me.ButtonRemain = New System.Windows.Forms.LinkLabel
        Me.ButtonReport = New System.Windows.Forms.LinkLabel
        Me.PictExit = New System.Windows.Forms.PictureBox
        Me.PicRemain = New System.Windows.Forms.PictureBox
        Me.PicOffline = New System.Windows.Forms.PictureBox
        Me.PicReport = New System.Windows.Forms.PictureBox
        Me.lblDevice = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'PictureLogo
        '
        Me.PictureLogo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureLogo.Image = CType(resources.GetObject("PictureLogo.Image"), System.Drawing.Image)
        Me.PictureLogo.Location = New System.Drawing.Point(67, 3)
        Me.PictureLogo.Name = "PictureLogo"
        Me.PictureLogo.Size = New System.Drawing.Size(507, 70)
        Me.PictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(14, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(640, 35)
        Me.Label1.Text = "ระบบการจัดการแฟ้มทะเบียน" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "สำนักสิทธิบัตร(ค้นหาแฟ้ม)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.White
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(-160, 301)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(400, 20)
        '
        'ButtonOffline
        '
        Me.ButtonOffline.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonOffline.ForeColor = System.Drawing.Color.Black
        Me.ButtonOffline.Location = New System.Drawing.Point(2, 167)
        Me.ButtonOffline.Name = "ButtonOffline"
        Me.ButtonOffline.Size = New System.Drawing.Size(121, 32)
        Me.ButtonOffline.TabIndex = 0
        Me.ButtonOffline.Text = "ดึงข้อมูลงานค้นแฟ้ม" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ผ่าน USB"
        Me.ButtonOffline.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ButtonExit
        '
        Me.ButtonExit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonExit.ForeColor = System.Drawing.Color.Black
        Me.ButtonExit.Location = New System.Drawing.Point(119, 258)
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(121, 32)
        Me.ButtonExit.TabIndex = 1
        Me.ButtonExit.Text = "ออกจากโปรแกรม"
        Me.ButtonExit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ButtonRemain
        '
        Me.ButtonRemain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonRemain.ForeColor = System.Drawing.Color.Black
        Me.ButtonRemain.Location = New System.Drawing.Point(15, 259)
        Me.ButtonRemain.Name = "ButtonRemain"
        Me.ButtonRemain.Size = New System.Drawing.Size(98, 32)
        Me.ButtonRemain.TabIndex = 2
        Me.ButtonRemain.Text = "แสดงงาน" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ค้นหาแฟ้ม"
        Me.ButtonRemain.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ButtonReport
        '
        Me.ButtonReport.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonReport.ForeColor = System.Drawing.Color.Black
        Me.ButtonReport.Location = New System.Drawing.Point(120, 167)
        Me.ButtonReport.Name = "ButtonReport"
        Me.ButtonReport.Size = New System.Drawing.Size(120, 32)
        Me.ButtonReport.TabIndex = 3
        Me.ButtonReport.Text = "ส่งผลการค้นหา ไปยังเครื่อง PC"
        Me.ButtonReport.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictExit
        '
        Me.PictExit.Image = CType(resources.GetObject("PictExit.Image"), System.Drawing.Image)
        Me.PictExit.Location = New System.Drawing.Point(154, 210)
        Me.PictExit.Name = "PictExit"
        Me.PictExit.Size = New System.Drawing.Size(46, 46)
        '
        'PicRemain
        '
        Me.PicRemain.Image = CType(resources.GetObject("PicRemain.Image"), System.Drawing.Image)
        Me.PicRemain.Location = New System.Drawing.Point(37, 210)
        Me.PicRemain.Name = "PicRemain"
        Me.PicRemain.Size = New System.Drawing.Size(46, 46)
        '
        'PicOffline
        '
        Me.PicOffline.Image = CType(resources.GetObject("PicOffline.Image"), System.Drawing.Image)
        Me.PicOffline.Location = New System.Drawing.Point(37, 118)
        Me.PicOffline.Name = "PicOffline"
        Me.PicOffline.Size = New System.Drawing.Size(46, 46)
        '
        'PicReport
        '
        Me.PicReport.Image = CType(resources.GetObject("PicReport.Image"), System.Drawing.Image)
        Me.PicReport.Location = New System.Drawing.Point(154, 118)
        Me.PicReport.Name = "PicReport"
        Me.PicReport.Size = New System.Drawing.Size(46, 46)
        '
        'lblDevice
        '
        Me.lblDevice.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lblDevice.Location = New System.Drawing.Point(178, 3)
        Me.lblDevice.Name = "lblDevice"
        Me.lblDevice.Size = New System.Drawing.Size(57, 15)
        Me.lblDevice.Text = "Device#1"
        '
        'FormLoadChoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(640, 480)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblDevice)
        Me.Controls.Add(Me.ButtonOffline)
        Me.Controls.Add(Me.ButtonExit)
        Me.Controls.Add(Me.ButtonRemain)
        Me.Controls.Add(Me.ButtonReport)
        Me.Controls.Add(Me.PictExit)
        Me.Controls.Add(Me.PicRemain)
        Me.Controls.Add(Me.PicOffline)
        Me.Controls.Add(Me.PicReport)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureLogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "FormLoadChoice"
        Me.Text = "DIP File Tracker"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonOffline As System.Windows.Forms.LinkLabel
    Friend WithEvents ButtonExit As System.Windows.Forms.LinkLabel
    Friend WithEvents ButtonRemain As System.Windows.Forms.LinkLabel
    Friend WithEvents ButtonReport As System.Windows.Forms.LinkLabel
    Friend WithEvents PictExit As System.Windows.Forms.PictureBox
    Friend WithEvents PicRemain As System.Windows.Forms.PictureBox
    Friend WithEvents PicOffline As System.Windows.Forms.PictureBox
    Friend WithEvents PicReport As System.Windows.Forms.PictureBox
    Friend WithEvents lblDevice As System.Windows.Forms.Label

End Class
