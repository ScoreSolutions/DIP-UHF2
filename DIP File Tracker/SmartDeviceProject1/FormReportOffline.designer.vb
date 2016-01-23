<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormReportOffline
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormReportOffline))
        Me.PictureLogo = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PicReport = New System.Windows.Forms.PictureBox
        Me.LinkReport = New System.Windows.Forms.LinkLabel
        Me.ProgressReport = New System.Windows.Forms.ProgressBar
        Me.PicBack = New System.Windows.Forms.PictureBox
        Me.LinkBack = New System.Windows.Forms.LinkLabel
        Me.TimerTest = New System.Windows.Forms.Timer
        Me.LabelHeader = New System.Windows.Forms.Label
        Me.CheckClearData = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'PictureLogo
        '
        Me.PictureLogo.Image = CType(resources.GetObject("PictureLogo.Image"), System.Drawing.Image)
        Me.PictureLogo.Location = New System.Drawing.Point(3, 0)
        Me.PictureLogo.Name = "PictureLogo"
        Me.PictureLogo.Size = New System.Drawing.Size(454, 35)
        Me.PictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
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
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.White
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(-160, 301)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(400, 20)
        '
        'PicReport
        '
        Me.PicReport.Image = CType(resources.GetObject("PicReport.Image"), System.Drawing.Image)
        Me.PicReport.Location = New System.Drawing.Point(20, 95)
        Me.PicReport.Name = "PicReport"
        Me.PicReport.Size = New System.Drawing.Size(46, 46)
        '
        'LinkReport
        '
        Me.LinkReport.Font = New System.Drawing.Font("Tahoma", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.LinkReport.Location = New System.Drawing.Point(80, 103)
        Me.LinkReport.Name = "LinkReport"
        Me.LinkReport.Size = New System.Drawing.Size(144, 38)
        Me.LinkReport.TabIndex = 4
        Me.LinkReport.Text = "Click" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "เพื่อส่งผลการค้นหา"
        '
        'ProgressReport
        '
        Me.ProgressReport.Location = New System.Drawing.Point(20, 151)
        Me.ProgressReport.Name = "ProgressReport"
        Me.ProgressReport.Size = New System.Drawing.Size(197, 13)
        '
        'PicBack
        '
        Me.PicBack.Image = CType(resources.GetObject("PicBack.Image"), System.Drawing.Image)
        Me.PicBack.Location = New System.Drawing.Point(3, 278)
        Me.PicBack.Name = "PicBack"
        Me.PicBack.Size = New System.Drawing.Size(21, 20)
        '
        'LinkBack
        '
        Me.LinkBack.Font = New System.Drawing.Font("Tahoma", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.LinkBack.Location = New System.Drawing.Point(29, 280)
        Me.LinkBack.Name = "LinkBack"
        Me.LinkBack.Size = New System.Drawing.Size(104, 20)
        Me.LinkBack.TabIndex = 8
        Me.LinkBack.Text = "กลับไปหน้าแรก"
        '
        'TimerTest
        '
        Me.TimerTest.Interval = 50
        '
        'LabelHeader
        '
        Me.LabelHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelHeader.BackColor = System.Drawing.Color.Green
        Me.LabelHeader.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelHeader.ForeColor = System.Drawing.Color.White
        Me.LabelHeader.Location = New System.Drawing.Point(2, 38)
        Me.LabelHeader.Name = "LabelHeader"
        Me.LabelHeader.Size = New System.Drawing.Size(637, 18)
        Me.LabelHeader.Text = "ส่งผลการค้นหาไปยังระบบหลัก"
        Me.LabelHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CheckClearData
        '
        Me.CheckClearData.Checked = True
        Me.CheckClearData.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckClearData.Location = New System.Drawing.Point(20, 182)
        Me.CheckClearData.Name = "CheckClearData"
        Me.CheckClearData.Size = New System.Drawing.Size(220, 20)
        Me.CheckClearData.TabIndex = 15
        Me.CheckClearData.Text = "ลบข้อมูลในเครื่องหลังเสร็จขั้นตอน"
        '
        'FormReportOffline
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(640, 480)
        Me.ControlBox = False
        Me.Controls.Add(Me.CheckClearData)
        Me.Controls.Add(Me.LabelHeader)
        Me.Controls.Add(Me.LinkBack)
        Me.Controls.Add(Me.PicBack)
        Me.Controls.Add(Me.ProgressReport)
        Me.Controls.Add(Me.LinkReport)
        Me.Controls.Add(Me.PicReport)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureLogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "FormReportOffline"
        Me.Text = "DIP File Tracker"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureLogo As System.Windows.Forms.PictureBox
    Friend WithEvents PicReport As System.Windows.Forms.PictureBox
    Friend WithEvents LinkReport As System.Windows.Forms.LinkLabel
    Friend WithEvents ProgressReport As System.Windows.Forms.ProgressBar
    Friend WithEvents PicBack As System.Windows.Forms.PictureBox
    Friend WithEvents LinkBack As System.Windows.Forms.LinkLabel
    Friend WithEvents TimerTest As System.Windows.Forms.Timer
    Friend WithEvents LabelHeader As System.Windows.Forms.Label
    Friend WithEvents CheckClearData As System.Windows.Forms.CheckBox
End Class
