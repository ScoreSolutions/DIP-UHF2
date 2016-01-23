<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPermission
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPermission))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.gvPermissionList = New System.Windows.Forms.DataGridView
        Me.seq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.permission_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.permission_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.gvMenuList = New System.Windows.Forms.DataGridView
        Me.cb = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.module_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.menu_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.menu_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.gvOfficerList = New System.Windows.Forms.DataGridView
        Me.cb1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.officer_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.staff_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.position_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.department_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtPermission = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.gvPermissionList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.gvMenuList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.gvOfficerList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.gvPermissionList)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(559, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(331, 542)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "รายการสิทธิ์การใช้งาน"
        '
        'gvPermissionList
        '
        Me.gvPermissionList.AllowUserToAddRows = False
        Me.gvPermissionList.AllowUserToDeleteRows = False
        Me.gvPermissionList.AllowUserToResizeColumns = False
        Me.gvPermissionList.AllowUserToResizeRows = False
        Me.gvPermissionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvPermissionList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.seq, Me.permission_name, Me.permission_id})
        Me.gvPermissionList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvPermissionList.Location = New System.Drawing.Point(3, 21)
        Me.gvPermissionList.MultiSelect = False
        Me.gvPermissionList.Name = "gvPermissionList"
        Me.gvPermissionList.ReadOnly = True
        Me.gvPermissionList.RowHeadersVisible = False
        Me.gvPermissionList.RowHeadersWidth = 30
        Me.gvPermissionList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvPermissionList.Size = New System.Drawing.Size(325, 518)
        Me.gvPermissionList.TabIndex = 5
        '
        'seq
        '
        Me.seq.DataPropertyName = "seq"
        Me.seq.HeaderText = "ลำดับ"
        Me.seq.Name = "seq"
        Me.seq.ReadOnly = True
        '
        'permission_name
        '
        Me.permission_name.DataPropertyName = "permission_name"
        Me.permission_name.HeaderText = "สิทธิ์การใช้งาน"
        Me.permission_name.Name = "permission_name"
        Me.permission_name.ReadOnly = True
        Me.permission_name.Width = 200
        '
        'permission_id
        '
        Me.permission_id.DataPropertyName = "id"
        Me.permission_id.HeaderText = "permission_id"
        Me.permission_id.Name = "permission_id"
        Me.permission_id.ReadOnly = True
        Me.permission_id.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 103)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(540, 408)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage1.Controls.Add(Me.gvMenuList)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(532, 382)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "เมนูที่มีสิทธิ์"
        '
        'gvMenuList
        '
        Me.gvMenuList.AllowUserToAddRows = False
        Me.gvMenuList.AllowUserToDeleteRows = False
        Me.gvMenuList.AllowUserToOrderColumns = True
        Me.gvMenuList.AllowUserToResizeColumns = False
        Me.gvMenuList.AllowUserToResizeRows = False
        Me.gvMenuList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvMenuList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cb, Me.module_name, Me.menu_name, Me.menu_id})
        Me.gvMenuList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvMenuList.Location = New System.Drawing.Point(3, 3)
        Me.gvMenuList.MultiSelect = False
        Me.gvMenuList.Name = "gvMenuList"
        Me.gvMenuList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvMenuList.Size = New System.Drawing.Size(526, 376)
        Me.gvMenuList.TabIndex = 0
        '
        'cb
        '
        Me.cb.HeaderText = ""
        Me.cb.Name = "cb"
        Me.cb.Width = 25
        '
        'module_name
        '
        Me.module_name.DataPropertyName = "module_name"
        Me.module_name.HeaderText = "ชื่อระบบ"
        Me.module_name.Name = "module_name"
        Me.module_name.Width = 150
        '
        'menu_name
        '
        Me.menu_name.DataPropertyName = "menu_name"
        Me.menu_name.HeaderText = "ชื่อเมนู"
        Me.menu_name.Name = "menu_name"
        Me.menu_name.Width = 150
        '
        'menu_id
        '
        Me.menu_id.DataPropertyName = "menu_id"
        Me.menu_id.HeaderText = "menu_id"
        Me.menu_id.Name = "menu_id"
        Me.menu_id.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage2.Controls.Add(Me.gvOfficerList)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(532, 382)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "ผู้ใช้งาน"
        '
        'gvOfficerList
        '
        Me.gvOfficerList.AllowUserToAddRows = False
        Me.gvOfficerList.AllowUserToDeleteRows = False
        Me.gvOfficerList.AllowUserToOrderColumns = True
        Me.gvOfficerList.AllowUserToResizeColumns = False
        Me.gvOfficerList.AllowUserToResizeRows = False
        Me.gvOfficerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvOfficerList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cb1, Me.officer_id, Me.staff_name, Me.position_name, Me.department_name})
        Me.gvOfficerList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvOfficerList.Location = New System.Drawing.Point(3, 3)
        Me.gvOfficerList.MultiSelect = False
        Me.gvOfficerList.Name = "gvOfficerList"
        Me.gvOfficerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvOfficerList.Size = New System.Drawing.Size(526, 376)
        Me.gvOfficerList.TabIndex = 0
        '
        'cb1
        '
        Me.cb1.HeaderText = ""
        Me.cb1.Name = "cb1"
        Me.cb1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cb1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.cb1.Width = 25
        '
        'officer_id
        '
        Me.officer_id.DataPropertyName = "officer_id"
        Me.officer_id.HeaderText = "officer_id"
        Me.officer_id.Name = "officer_id"
        Me.officer_id.Visible = False
        '
        'staff_name
        '
        Me.staff_name.DataPropertyName = "staff_name"
        Me.staff_name.HeaderText = "ชื่อ-สกุล"
        Me.staff_name.Name = "staff_name"
        Me.staff_name.Width = 180
        '
        'position_name
        '
        Me.position_name.DataPropertyName = "position_name"
        Me.position_name.HeaderText = "ตำแหน่ง"
        Me.position_name.Name = "position_name"
        Me.position_name.Width = 135
        '
        'department_name
        '
        Me.department_name.DataPropertyName = "department_name"
        Me.department_name.HeaderText = "หน่วยงาน"
        Me.department_name.Name = "department_name"
        Me.department_name.Width = 140
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPermission)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(536, 85)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "กำหนดสิทธิ์การใช้งาน"
        '
        'txtPermission
        '
        Me.txtPermission.Location = New System.Drawing.Point(147, 35)
        Me.txtPermission.Name = "txtPermission"
        Me.txtPermission.Size = New System.Drawing.Size(285, 25)
        Me.txtPermission.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(63, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "สิทธิ์การใช้งาน"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(378, 517)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 34)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "บันทึก"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(468, 517)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(84, 34)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "ล้าง"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'frmPermission
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 566)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPermission"
        Me.Text = "กำหนดสิทธิ์การใช้งานตามกลุ่ม"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.gvPermissionList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.gvMenuList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.gvOfficerList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gvPermissionList As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtPermission As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gvMenuList As System.Windows.Forms.DataGridView
    Friend WithEvents gvOfficerList As System.Windows.Forms.DataGridView
    Friend WithEvents cb1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents officer_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents staff_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents position_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents department_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents cb As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents module_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents menu_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents menu_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents seq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents permission_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents permission_id As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
