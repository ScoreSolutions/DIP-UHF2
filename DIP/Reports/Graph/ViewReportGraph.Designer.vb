<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewReportGraph
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewReportGraph))
        Me.crpGraph = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'crpGraph
        '
        Me.crpGraph.ActiveViewIndex = -1
        Me.crpGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crpGraph.DisplayGroupTree = False
        Me.crpGraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crpGraph.Location = New System.Drawing.Point(0, 0)
        Me.crpGraph.Name = "crpGraph"
        Me.crpGraph.SelectionFormula = ""
        Me.crpGraph.ShowGroupTreeButton = False
        Me.crpGraph.Size = New System.Drawing.Size(811, 406)
        Me.crpGraph.TabIndex = 1
        Me.crpGraph.ViewTimeSelectionFormula = ""
        '
        'ViewReportGraph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 406)
        Me.Controls.Add(Me.crpGraph)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ViewReportGraph"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ViewReportGraph"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crpGraph As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
