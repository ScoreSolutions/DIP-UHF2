<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewReport_Statistics
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewReport_Statistics))
        Me.crpStatistics = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'crpStatistics
        '
        Me.crpStatistics.ActiveViewIndex = -1
        Me.crpStatistics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crpStatistics.DisplayGroupTree = False
        Me.crpStatistics.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crpStatistics.Location = New System.Drawing.Point(0, 0)
        Me.crpStatistics.Name = "crpStatistics"
        Me.crpStatistics.SelectionFormula = ""
        Me.crpStatistics.Size = New System.Drawing.Size(801, 396)
        Me.crpStatistics.TabIndex = 1
        Me.crpStatistics.ViewTimeSelectionFormula = ""
        '
        'ViewReport_Statistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 396)
        Me.Controls.Add(Me.crpStatistics)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ViewReport_Statistics"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ViewReport_Statistics"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crpStatistics As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
