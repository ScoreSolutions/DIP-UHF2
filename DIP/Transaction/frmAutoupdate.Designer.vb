<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAutoupdate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAutoupdate))
        Me.pg1 = New System.Windows.Forms.ProgressBar
        Me.lblPct1 = New System.Windows.Forms.Label
        Me.bw1 = New System.ComponentModel.BackgroundWorker
        Me.status = New System.Windows.Forms.StatusStrip
        Me.statusBar = New System.Windows.Forms.ToolStripStatusLabel
        Me.DBTool = New System.Windows.Forms.ToolStrip
        Me.btnStart = New System.Windows.Forms.ToolStripButton
        Me.btnStop = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.status.SuspendLayout()
        Me.DBTool.SuspendLayout()
        Me.SuspendLayout()
        '
        'pg1
        '
        resources.ApplyResources(Me.pg1, "pg1")
        Me.pg1.Name = "pg1"
        '
        'lblPct1
        '
        resources.ApplyResources(Me.lblPct1, "lblPct1")
        Me.lblPct1.Name = "lblPct1"
        '
        'bw1
        '
        Me.bw1.WorkerReportsProgress = True
        Me.bw1.WorkerSupportsCancellation = True
        '
        'status
        '
        Me.status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusBar})
        resources.ApplyResources(Me.status, "status")
        Me.status.Name = "status"
        '
        'statusBar
        '
        resources.ApplyResources(Me.statusBar, "statusBar")
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Spring = True
        '
        'DBTool
        '
        Me.DBTool.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.DBTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnStart, Me.btnStop, Me.ToolStripSeparator1})
        Me.DBTool.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        resources.ApplyResources(Me.DBTool, "DBTool")
        Me.DBTool.Name = "DBTool"
        Me.DBTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        '
        'btnStart
        '
        Me.btnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnStart, "btnStart")
        Me.btnStart.Name = "btnStart"
        '
        'btnStop
        '
        Me.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnStop, "btnStop")
        Me.btnStop.Name = "btnStop"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'frmAutoupdate
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DBTool)
        Me.Controls.Add(Me.status)
        Me.Controls.Add(Me.pg1)
        Me.Controls.Add(Me.lblPct1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAutoupdate"
        Me.status.ResumeLayout(False)
        Me.status.PerformLayout()
        Me.DBTool.ResumeLayout(False)
        Me.DBTool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pg1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblPct1 As System.Windows.Forms.Label
    Friend WithEvents bw1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents status As System.Windows.Forms.StatusStrip
    Friend WithEvents statusBar As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DBTool As System.Windows.Forms.ToolStrip
    Friend WithEvents btnStart As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnStop As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
