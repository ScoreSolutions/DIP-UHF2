<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReserveOfficerNew
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReserveOfficerNew))
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GridOfficer = New System.Windows.Forms.DataGridView
        Me.fullname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fname = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.GridOfficer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtSearch.Location = New System.Drawing.Point(70, 12)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(343, 25)
        Me.txtSearch.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(13, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 19)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "ค้นหา :"
        '
        'GridOfficer
        '
        Me.GridOfficer.AllowUserToAddRows = False
        Me.GridOfficer.AllowUserToDeleteRows = False
        Me.GridOfficer.AllowUserToResizeColumns = False
        Me.GridOfficer.AllowUserToResizeRows = False
        Me.GridOfficer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridOfficer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridOfficer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fullname, Me.fname})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridOfficer.DefaultCellStyle = DataGridViewCellStyle1
        Me.GridOfficer.Location = New System.Drawing.Point(12, 45)
        Me.GridOfficer.MultiSelect = False
        Me.GridOfficer.Name = "GridOfficer"
        Me.GridOfficer.ReadOnly = True
        Me.GridOfficer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridOfficer.Size = New System.Drawing.Size(401, 244)
        Me.GridOfficer.TabIndex = 22
        '
        'fullname
        '
        Me.fullname.DataPropertyName = "fullname"
        Me.fullname.FillWeight = 132.9609!
        Me.fullname.HeaderText = "ชื่อ - สกุล"
        Me.fullname.Name = "fullname"
        Me.fullname.ReadOnly = True
        Me.fullname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.fullname.Width = 238
        '
        'fname
        '
        Me.fname.DataPropertyName = "fname"
        Me.fname.HeaderText = "fname"
        Me.fname.Name = "fname"
        Me.fname.ReadOnly = True
        Me.fname.Visible = False
        '
        'frmReserveOfficerNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 299)
        Me.Controls.Add(Me.GridOfficer)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReserveOfficerNew"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ค้นหาชื่อผู้จอง"
        CType(Me.GridOfficer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GridOfficer As System.Windows.Forms.DataGridView
    Friend WithEvents fullname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fname As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
