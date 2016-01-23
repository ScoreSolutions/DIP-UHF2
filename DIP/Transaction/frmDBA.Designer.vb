<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDBA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDBA))
        Me.DBTool = New System.Windows.Forms.ToolStrip
        Me.btnStart = New System.Windows.Forms.ToolStripButton
        Me.btnStop = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnClear = New System.Windows.Forms.ToolStripButton
        Me.status = New System.Windows.Forms.StatusStrip
        Me.tlActive = New System.Windows.Forms.ToolStripDropDownButton
        Me.statusBar = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkInclude10 = New System.Windows.Forms.CheckBox
        Me.chkInclude8 = New System.Windows.Forms.CheckBox
        Me.pg8 = New System.Windows.Forms.ProgressBar
        Me.pg10 = New System.Windows.Forms.ProgressBar
        Me.lblPct10 = New System.Windows.Forms.Label
        Me.lblPct8 = New System.Windows.Forms.Label
        Me.lblTask8 = New System.Windows.Forms.Label
        Me.lblTask10 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkInclude9 = New System.Windows.Forms.CheckBox
        Me.chkInclude7 = New System.Windows.Forms.CheckBox
        Me.pg7 = New System.Windows.Forms.ProgressBar
        Me.pg9 = New System.Windows.Forms.ProgressBar
        Me.lblPct9 = New System.Windows.Forms.Label
        Me.lblPct7 = New System.Windows.Forms.Label
        Me.lblTask7 = New System.Windows.Forms.Label
        Me.lblTask9 = New System.Windows.Forms.Label
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.txtLog = New System.Windows.Forms.TextBox
        Me.bw10 = New System.ComponentModel.BackgroundWorker
        Me.bw9 = New System.ComponentModel.BackgroundWorker
        Me.bw8 = New System.ComponentModel.BackgroundWorker
        Me.bw7 = New System.ComponentModel.BackgroundWorker
        Me.DBTool.SuspendLayout()
        Me.status.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DBTool
        '
        Me.DBTool.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.DBTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnStart, Me.btnStop, Me.ToolStripSeparator1, Me.btnClear})
        Me.DBTool.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.DBTool.Location = New System.Drawing.Point(0, 0)
        Me.DBTool.Name = "DBTool"
        Me.DBTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.DBTool.Size = New System.Drawing.Size(732, 31)
        Me.DBTool.TabIndex = 1
        Me.DBTool.Text = "ToolStrip1"
        '
        'btnStart
        '
        Me.btnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnStart.Image = CType(resources.GetObject("btnStart.Image"), System.Drawing.Image)
        Me.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(28, 28)
        Me.btnStart.ToolTipText = "Start Medtrak Agent"
        '
        'btnStop
        '
        Me.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnStop.Image = CType(resources.GetObject("btnStop.Image"), System.Drawing.Image)
        Me.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(28, 28)
        Me.btnStop.ToolTipText = "Stop Medtrak Agent"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'btnClear
        '
        Me.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(28, 28)
        Me.btnClear.ToolTipText = "Clear Screen Log"
        '
        'status
        '
        Me.status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlActive, Me.statusBar})
        Me.status.Location = New System.Drawing.Point(0, 424)
        Me.status.Name = "status"
        Me.status.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.status.Size = New System.Drawing.Size(732, 22)
        Me.status.TabIndex = 2
        '
        'tlActive
        '
        Me.tlActive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlActive.Image = CType(resources.GetObject("tlActive.Image"), System.Drawing.Image)
        Me.tlActive.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlActive.Name = "tlActive"
        Me.tlActive.ShowDropDownArrow = False
        Me.tlActive.Size = New System.Drawing.Size(20, 20)
        '
        'statusBar
        '
        Me.statusBar.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Size = New System.Drawing.Size(695, 17)
        Me.statusBar.Spring = True
        Me.statusBar.Text = "Ready"
        Me.statusBar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 254)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(732, 170)
        Me.Panel1.TabIndex = 6
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkInclude10)
        Me.GroupBox2.Controls.Add(Me.chkInclude8)
        Me.GroupBox2.Controls.Add(Me.pg8)
        Me.GroupBox2.Controls.Add(Me.pg10)
        Me.GroupBox2.Controls.Add(Me.lblPct10)
        Me.GroupBox2.Controls.Add(Me.lblPct8)
        Me.GroupBox2.Controls.Add(Me.lblTask8)
        Me.GroupBox2.Controls.Add(Me.lblTask10)
        Me.GroupBox2.Location = New System.Drawing.Point(370, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(352, 82)
        Me.GroupBox2.TabIndex = 75
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Update"
        '
        'chkInclude10
        '
        Me.chkInclude10.AutoSize = True
        Me.chkInclude10.Checked = True
        Me.chkInclude10.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInclude10.Location = New System.Drawing.Point(270, 46)
        Me.chkInclude10.Name = "chkInclude10"
        Me.chkInclude10.Size = New System.Drawing.Size(75, 18)
        Me.chkInclude10.TabIndex = 67
        Me.chkInclude10.Text = "Include"
        Me.chkInclude10.UseVisualStyleBackColor = True
        '
        'chkInclude8
        '
        Me.chkInclude8.AutoSize = True
        Me.chkInclude8.Checked = True
        Me.chkInclude8.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInclude8.Location = New System.Drawing.Point(270, 26)
        Me.chkInclude8.Name = "chkInclude8"
        Me.chkInclude8.Size = New System.Drawing.Size(75, 18)
        Me.chkInclude8.TabIndex = 67
        Me.chkInclude8.Text = "Include"
        Me.chkInclude8.UseVisualStyleBackColor = True
        '
        'pg8
        '
        Me.pg8.Location = New System.Drawing.Point(123, 27)
        Me.pg8.Name = "pg8"
        Me.pg8.Size = New System.Drawing.Size(105, 14)
        Me.pg8.TabIndex = 46
        '
        'pg10
        '
        Me.pg10.Location = New System.Drawing.Point(123, 47)
        Me.pg10.Name = "pg10"
        Me.pg10.Size = New System.Drawing.Size(105, 14)
        Me.pg10.TabIndex = 46
        '
        'lblPct10
        '
        Me.lblPct10.AutoSize = True
        Me.lblPct10.Location = New System.Drawing.Point(234, 47)
        Me.lblPct10.Name = "lblPct10"
        Me.lblPct10.Size = New System.Drawing.Size(21, 14)
        Me.lblPct10.TabIndex = 56
        Me.lblPct10.Text = "0%"
        Me.lblPct10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPct8
        '
        Me.lblPct8.AutoSize = True
        Me.lblPct8.Location = New System.Drawing.Point(234, 27)
        Me.lblPct8.Name = "lblPct8"
        Me.lblPct8.Size = New System.Drawing.Size(21, 14)
        Me.lblPct8.TabIndex = 56
        Me.lblPct8.Text = "0%"
        Me.lblPct8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTask8
        '
        Me.lblTask8.AutoSize = True
        Me.lblTask8.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTask8.Location = New System.Drawing.Point(12, 27)
        Me.lblTask8.Name = "lblTask8"
        Me.lblTask8.Size = New System.Drawing.Size(84, 14)
        Me.lblTask8.TabIndex = 51
        Me.lblTask8.Text = "Requisition"
        '
        'lblTask10
        '
        Me.lblTask10.AutoSize = True
        Me.lblTask10.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTask10.Location = New System.Drawing.Point(12, 47)
        Me.lblTask10.Name = "lblTask10"
        Me.lblTask10.Size = New System.Drawing.Size(105, 14)
        Me.lblTask10.TabIndex = 51
        Me.lblTask10.Text = "FileBorrowItem"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkInclude9)
        Me.GroupBox1.Controls.Add(Me.chkInclude7)
        Me.GroupBox1.Controls.Add(Me.pg7)
        Me.GroupBox1.Controls.Add(Me.pg9)
        Me.GroupBox1.Controls.Add(Me.lblPct9)
        Me.GroupBox1.Controls.Add(Me.lblPct7)
        Me.GroupBox1.Controls.Add(Me.lblTask7)
        Me.GroupBox1.Controls.Add(Me.lblTask9)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 82)
        Me.GroupBox1.TabIndex = 74
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Insert"
        '
        'chkInclude9
        '
        Me.chkInclude9.AutoSize = True
        Me.chkInclude9.Checked = True
        Me.chkInclude9.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInclude9.Location = New System.Drawing.Point(268, 46)
        Me.chkInclude9.Name = "chkInclude9"
        Me.chkInclude9.Size = New System.Drawing.Size(75, 18)
        Me.chkInclude9.TabIndex = 67
        Me.chkInclude9.Text = "Include"
        Me.chkInclude9.UseVisualStyleBackColor = True
        '
        'chkInclude7
        '
        Me.chkInclude7.AutoSize = True
        Me.chkInclude7.Checked = True
        Me.chkInclude7.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInclude7.Location = New System.Drawing.Point(268, 26)
        Me.chkInclude7.Name = "chkInclude7"
        Me.chkInclude7.Size = New System.Drawing.Size(75, 18)
        Me.chkInclude7.TabIndex = 67
        Me.chkInclude7.Text = "Include"
        Me.chkInclude7.UseVisualStyleBackColor = True
        '
        'pg7
        '
        Me.pg7.Location = New System.Drawing.Point(121, 27)
        Me.pg7.Name = "pg7"
        Me.pg7.Size = New System.Drawing.Size(105, 14)
        Me.pg7.TabIndex = 46
        '
        'pg9
        '
        Me.pg9.Location = New System.Drawing.Point(121, 47)
        Me.pg9.Name = "pg9"
        Me.pg9.Size = New System.Drawing.Size(105, 14)
        Me.pg9.TabIndex = 46
        '
        'lblPct9
        '
        Me.lblPct9.AutoSize = True
        Me.lblPct9.Location = New System.Drawing.Point(232, 47)
        Me.lblPct9.Name = "lblPct9"
        Me.lblPct9.Size = New System.Drawing.Size(21, 14)
        Me.lblPct9.TabIndex = 56
        Me.lblPct9.Text = "0%"
        Me.lblPct9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPct7
        '
        Me.lblPct7.AutoSize = True
        Me.lblPct7.Location = New System.Drawing.Point(232, 27)
        Me.lblPct7.Name = "lblPct7"
        Me.lblPct7.Size = New System.Drawing.Size(21, 14)
        Me.lblPct7.TabIndex = 56
        Me.lblPct7.Text = "0%"
        Me.lblPct7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTask7
        '
        Me.lblTask7.AutoSize = True
        Me.lblTask7.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTask7.Location = New System.Drawing.Point(10, 27)
        Me.lblTask7.Name = "lblTask7"
        Me.lblTask7.Size = New System.Drawing.Size(84, 14)
        Me.lblTask7.TabIndex = 51
        Me.lblTask7.Text = "Requisition"
        '
        'lblTask9
        '
        Me.lblTask9.AutoSize = True
        Me.lblTask9.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTask9.Location = New System.Drawing.Point(10, 47)
        Me.lblTask9.Name = "lblTask9"
        Me.lblTask9.Size = New System.Drawing.Size(105, 14)
        Me.lblTask9.TabIndex = 51
        Me.lblTask9.Text = "FileBorrowItem"
        '
        'Splitter1
        '
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 250)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(732, 4)
        Me.Splitter1.TabIndex = 7
        Me.Splitter1.TabStop = False
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.Color.Black
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLog.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLog.ForeColor = System.Drawing.Color.LimeGreen
        Me.txtLog.Location = New System.Drawing.Point(0, 31)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLog.Size = New System.Drawing.Size(732, 219)
        Me.txtLog.TabIndex = 8
        Me.txtLog.WordWrap = False
        '
        'bw10
        '
        Me.bw10.WorkerReportsProgress = True
        Me.bw10.WorkerSupportsCancellation = True
        '
        'bw9
        '
        Me.bw9.WorkerReportsProgress = True
        Me.bw9.WorkerSupportsCancellation = True
        '
        'bw8
        '
        Me.bw8.WorkerReportsProgress = True
        Me.bw8.WorkerSupportsCancellation = True
        '
        'bw7
        '
        Me.bw7.WorkerReportsProgress = True
        Me.bw7.WorkerSupportsCancellation = True
        '
        'frmDBA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 446)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.status)
        Me.Controls.Add(Me.DBTool)
        Me.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDBA"
        Me.Text = "Medtrak DB Agent"
        Me.DBTool.ResumeLayout(False)
        Me.DBTool.PerformLayout()
        Me.status.ResumeLayout(False)
        Me.status.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DBTool As System.Windows.Forms.ToolStrip
    Friend WithEvents btnStart As System.Windows.Forms.ToolStripButton
    Friend WithEvents status As System.Windows.Forms.StatusStrip
    Friend WithEvents statusBar As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents btnStop As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents tlActive As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkInclude9 As System.Windows.Forms.CheckBox
    Friend WithEvents chkInclude7 As System.Windows.Forms.CheckBox
    Friend WithEvents lblPct9 As System.Windows.Forms.Label
    Friend WithEvents lblPct7 As System.Windows.Forms.Label
    Friend WithEvents lblTask9 As System.Windows.Forms.Label
    Friend WithEvents lblTask7 As System.Windows.Forms.Label
    Friend WithEvents pg9 As System.Windows.Forms.ProgressBar
    Friend WithEvents pg7 As System.Windows.Forms.ProgressBar
    Friend WithEvents bw10 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw9 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw8 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw7 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkInclude10 As System.Windows.Forms.CheckBox
    Friend WithEvents chkInclude8 As System.Windows.Forms.CheckBox
    Friend WithEvents pg8 As System.Windows.Forms.ProgressBar
    Friend WithEvents pg10 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblPct10 As System.Windows.Forms.Label
    Friend WithEvents lblPct8 As System.Windows.Forms.Label
    Friend WithEvents lblTask8 As System.Windows.Forms.Label
    Friend WithEvents lblTask10 As System.Windows.Forms.Label
End Class
