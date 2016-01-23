<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewReport_CheckOut
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewReport_CheckOut))
        Me.crpCheckOut = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'crpCheckOut
        '
        Me.crpCheckOut.ActiveViewIndex = -1
        Me.crpCheckOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crpCheckOut.DisplayGroupTree = False
        Me.crpCheckOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crpCheckOut.EnableDrillDown = False
        Me.crpCheckOut.Location = New System.Drawing.Point(0, 0)
        Me.crpCheckOut.Name = "crpCheckOut"
        Me.crpCheckOut.SelectionFormula = ""
        Me.crpCheckOut.ShowGroupTreeButton = False
        Me.crpCheckOut.Size = New System.Drawing.Size(811, 406)
        Me.crpCheckOut.TabIndex = 0
        Me.crpCheckOut.ViewTimeSelectionFormula = ""
        '
        'ViewReport_CheckOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 406)
        Me.Controls.Add(Me.crpCheckOut)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ViewReport_CheckOut"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "รายงาน"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crpCheckOut As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
