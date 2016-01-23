<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOfficerSearchByDepartment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOfficerSearchByDepartment))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbDepartment = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GridOfficer = New System.Windows.Forms.DataGridView
        Me.fullname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.position_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.department_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.officer_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.position_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.department_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridOfficer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cbDepartment)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(707, 65)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ค้นหา"
        '
        'cbDepartment
        '
        Me.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDepartment.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDepartment.FormattingEnabled = True
        Me.cbDepartment.Location = New System.Drawing.Point(53, 24)
        Me.cbDepartment.Name = "cbDepartment"
        Me.cbDepartment.Size = New System.Drawing.Size(246, 25)
        Me.cbDepartment.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "สังกัด"
        '
        'GridOfficer
        '
        Me.GridOfficer.AllowUserToAddRows = False
        Me.GridOfficer.AllowUserToDeleteRows = False
        Me.GridOfficer.AllowUserToOrderColumns = True
        Me.GridOfficer.AllowUserToResizeColumns = False
        Me.GridOfficer.AllowUserToResizeRows = False
        Me.GridOfficer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridOfficer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridOfficer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fullname, Me.position_name, Me.department_name, Me.id, Me.officer_no, Me.position_id, Me.department_id})
        Me.GridOfficer.Location = New System.Drawing.Point(12, 74)
        Me.GridOfficer.MultiSelect = False
        Me.GridOfficer.Name = "GridOfficer"
        Me.GridOfficer.ReadOnly = True
        Me.GridOfficer.RowHeadersVisible = False
        Me.GridOfficer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridOfficer.Size = New System.Drawing.Size(707, 456)
        Me.GridOfficer.TabIndex = 1
        '
        'fullname
        '
        Me.fullname.DataPropertyName = "fullname"
        Me.fullname.HeaderText = "ชื่อ-สกุล"
        Me.fullname.Name = "fullname"
        Me.fullname.ReadOnly = True
        Me.fullname.Width = 230
        '
        'position_name
        '
        Me.position_name.DataPropertyName = "position_name"
        Me.position_name.HeaderText = "ตำแหน่ง"
        Me.position_name.Name = "position_name"
        Me.position_name.ReadOnly = True
        Me.position_name.Width = 180
        '
        'department_name
        '
        Me.department_name.DataPropertyName = "department_name"
        Me.department_name.HeaderText = "สังกัด"
        Me.department_name.Name = "department_name"
        Me.department_name.ReadOnly = True
        Me.department_name.Width = 200
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'officer_no
        '
        Me.officer_no.DataPropertyName = "officer_no"
        Me.officer_no.HeaderText = "officer_no"
        Me.officer_no.Name = "officer_no"
        Me.officer_no.ReadOnly = True
        Me.officer_no.Visible = False
        '
        'position_id
        '
        Me.position_id.DataPropertyName = "position_id"
        Me.position_id.HeaderText = "position_id"
        Me.position_id.Name = "position_id"
        Me.position_id.ReadOnly = True
        Me.position_id.Visible = False
        '
        'department_id
        '
        Me.department_id.DataPropertyName = "department_id"
        Me.department_id.HeaderText = "department_id"
        Me.department_id.Name = "department_id"
        Me.department_id.ReadOnly = True
        Me.department_id.Visible = False
        '
        'frmOfficerSearchByDepartment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 542)
        Me.Controls.Add(Me.GridOfficer)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOfficerSearchByDepartment"
        Me.ShowInTaskbar = False
        Me.Text = "รายการผู้ใช้งาน"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridOfficer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GridOfficer As System.Windows.Forms.DataGridView
    Friend WithEvents fullname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents position_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents department_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents officer_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents position_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents department_id As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
