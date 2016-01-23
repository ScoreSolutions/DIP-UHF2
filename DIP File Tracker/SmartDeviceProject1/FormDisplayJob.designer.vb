<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormDisplayJob
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDisplayJob))
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureLogo = New System.Windows.Forms.PictureBox
        Me.PicBack = New System.Windows.Forms.PictureBox
        Me.LinkBack = New System.Windows.Forms.LinkLabel
        Me.PicStatusOffline = New System.Windows.Forms.PictureBox
        Me.PicStatusSearch = New System.Windows.Forms.PictureBox
        Me.PicStatusFound = New System.Windows.Forms.PictureBox
        Me.JobContainer = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblFileName = New System.Windows.Forms.Label
        Me.lblText1 = New System.Windows.Forms.Label
        Me.lblHeader = New System.Windows.Forms.Label
        Me.PanelRFIDStatus = New System.Windows.Forms.Panel
        Me.lblText2 = New System.Windows.Forms.Label
        Me.PicNext = New System.Windows.Forms.PictureBox
        Me.lnkNext = New System.Windows.Forms.LinkLabel
        Me.TimerRead = New System.Windows.Forms.Timer
        Me.JobContainer.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PanelRFIDStatus.SuspendLayout()
        Me.SuspendLayout()
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
        Me.PicBack.Location = New System.Drawing.Point(3, 461)
        Me.PicBack.Name = "PicBack"
        Me.PicBack.Size = New System.Drawing.Size(21, 20)
        '
        'LinkBack
        '
        Me.LinkBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkBack.Font = New System.Drawing.Font("Tahoma", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.LinkBack.Location = New System.Drawing.Point(27, 463)
        Me.LinkBack.Name = "LinkBack"
        Me.LinkBack.Size = New System.Drawing.Size(109, 17)
        Me.LinkBack.TabIndex = 7
        Me.LinkBack.Text = "กลับไปหน้าแรก"
        '
        'PicStatusOffline
        '
        Me.PicStatusOffline.Image = CType(resources.GetObject("PicStatusOffline.Image"), System.Drawing.Image)
        Me.PicStatusOffline.Location = New System.Drawing.Point(3, 38)
        Me.PicStatusOffline.Name = "PicStatusOffline"
        Me.PicStatusOffline.Size = New System.Drawing.Size(48, 48)
        '
        'PicStatusSearch
        '
        Me.PicStatusSearch.Image = CType(resources.GetObject("PicStatusSearch.Image"), System.Drawing.Image)
        Me.PicStatusSearch.Location = New System.Drawing.Point(3, 38)
        Me.PicStatusSearch.Name = "PicStatusSearch"
        Me.PicStatusSearch.Size = New System.Drawing.Size(48, 48)
        '
        'PicStatusFound
        '
        Me.PicStatusFound.Image = CType(resources.GetObject("PicStatusFound.Image"), System.Drawing.Image)
        Me.PicStatusFound.Location = New System.Drawing.Point(3, 38)
        Me.PicStatusFound.Name = "PicStatusFound"
        Me.PicStatusFound.Size = New System.Drawing.Size(48, 48)
        '
        'JobContainer
        '
        Me.JobContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.JobContainer.AutoScroll = True
        Me.JobContainer.BackColor = System.Drawing.Color.White
        Me.JobContainer.Controls.Add(Me.Panel1)
        Me.JobContainer.Location = New System.Drawing.Point(3, 112)
        Me.JobContainer.Name = "JobContainer"
        Me.JobContainer.Size = New System.Drawing.Size(634, 344)
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblFileName)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(610, 28)
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(139, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 18)
        Me.Label3.Text = "xxxxx"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(84, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 18)
        Me.Label2.Text = "ตำแหน่ง"
        '
        'lblFileName
        '
        Me.lblFileName.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblFileName.Location = New System.Drawing.Point(3, 5)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(86, 18)
        Me.lblFileName.Text = "1003000001"
        '
        'lblText1
        '
        Me.lblText1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblText1.BackColor = System.Drawing.Color.Transparent
        Me.lblText1.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblText1.ForeColor = System.Drawing.Color.White
        Me.lblText1.Location = New System.Drawing.Point(1, 0)
        Me.lblText1.Name = "lblText1"
        Me.lblText1.Size = New System.Drawing.Size(578, 25)
        Me.lblText1.Text = "File Found"
        Me.lblText1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblHeader
        '
        Me.lblHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHeader.BackColor = System.Drawing.Color.SeaGreen
        Me.lblHeader.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeader.ForeColor = System.Drawing.Color.White
        Me.lblHeader.Location = New System.Drawing.Point(3, 89)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(636, 20)
        Me.lblHeader.Text = "รายการที่ต้องค้นหา xxx แฟ้ม"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PanelRFIDStatus
        '
        Me.PanelRFIDStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelRFIDStatus.BackColor = System.Drawing.Color.Green
        Me.PanelRFIDStatus.Controls.Add(Me.lblText2)
        Me.PanelRFIDStatus.Controls.Add(Me.lblText1)
        Me.PanelRFIDStatus.Location = New System.Drawing.Point(58, 38)
        Me.PanelRFIDStatus.Name = "PanelRFIDStatus"
        Me.PanelRFIDStatus.Size = New System.Drawing.Size(581, 47)
        '
        'lblText2
        '
        Me.lblText2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblText2.BackColor = System.Drawing.Color.Transparent
        Me.lblText2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblText2.ForeColor = System.Drawing.Color.White
        Me.lblText2.Location = New System.Drawing.Point(0, 28)
        Me.lblText2.Name = "lblText2"
        Me.lblText2.Size = New System.Drawing.Size(583, 19)
        Me.lblText2.Text = "1003000003"
        Me.lblText2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PicNext
        '
        Me.PicNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicNext.Image = CType(resources.GetObject("PicNext.Image"), System.Drawing.Image)
        Me.PicNext.Location = New System.Drawing.Point(619, 462)
        Me.PicNext.Name = "PicNext"
        Me.PicNext.Size = New System.Drawing.Size(16, 16)
        '
        'lnkNext
        '
        Me.lnkNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkNext.Font = New System.Drawing.Font("Tahoma", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lnkNext.ForeColor = System.Drawing.Color.SeaGreen
        Me.lnkNext.Location = New System.Drawing.Point(536, 463)
        Me.lnkNext.Name = "lnkNext"
        Me.lnkNext.Size = New System.Drawing.Size(80, 17)
        Me.lnkNext.TabIndex = 1
        Me.lnkNext.Text = "เพิ่มเลขแฟ้ม"
        Me.lnkNext.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TimerRead
        '
        Me.TimerRead.Interval = 1000
        '
        'FormDisplayJob
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(640, 480)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelRFIDStatus)
        Me.Controls.Add(Me.lnkNext)
        Me.Controls.Add(Me.PicNext)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.JobContainer)
        Me.Controls.Add(Me.LinkBack)
        Me.Controls.Add(Me.PicBack)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureLogo)
        Me.Controls.Add(Me.PicStatusFound)
        Me.Controls.Add(Me.PicStatusSearch)
        Me.Controls.Add(Me.PicStatusOffline)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "FormDisplayJob"
        Me.Text = "DIP File Tracker"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.JobContainer.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.PanelRFIDStatus.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureLogo As System.Windows.Forms.PictureBox
    Friend WithEvents PicBack As System.Windows.Forms.PictureBox
    Friend WithEvents LinkBack As System.Windows.Forms.LinkLabel
    Friend WithEvents PicStatusOffline As System.Windows.Forms.PictureBox
    Friend WithEvents PicStatusSearch As System.Windows.Forms.PictureBox
    Friend WithEvents PicStatusFound As System.Windows.Forms.PictureBox
    Friend WithEvents JobContainer As System.Windows.Forms.Panel
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents PanelRFIDStatus As System.Windows.Forms.Panel
    Friend WithEvents lblText1 As System.Windows.Forms.Label
    Friend WithEvents lblText2 As System.Windows.Forms.Label
    Friend WithEvents PicNext As System.Windows.Forms.PictureBox
    Friend WithEvents lnkNext As System.Windows.Forms.LinkLabel
    Friend WithEvents TimerRead As System.Windows.Forms.Timer
End Class
