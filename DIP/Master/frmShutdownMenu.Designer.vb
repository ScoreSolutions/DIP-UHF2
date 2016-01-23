<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShutdownMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShutdownMenu))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtId = New System.Windows.Forms.TextBox
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.cbo_e_m = New System.Windows.Forms.ComboBox
        Me.cbo_e_h = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbo_s_m = New System.Windows.Forms.ComboBox
        Me.cbo_s_h = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboCom = New System.Windows.Forms.ComboBox
        Me.cboMenu = New System.Windows.Forms.ComboBox
        Me.TxtDate = New DIP.txtDate
        Me.cb = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.stDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.open_time = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.close_time = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.menu_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.status_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.menu_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.s_status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtId)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.cbo_e_m)
        Me.Panel1.Controls.Add(Me.cbo_e_h)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cbo_s_m)
        Me.Panel1.Controls.Add(Me.cbo_s_h)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.cboCom)
        Me.Panel1.Controls.Add(Me.cboMenu)
        Me.Panel1.Controls.Add(Me.TxtDate)
        Me.Panel1.Controls.Add(Me.cb)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(501, 199)
        Me.Panel1.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(115, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 17)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = "เมนู"
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(416, 12)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(57, 20)
        Me.txtId.TabIndex = 64
        Me.txtId.Visible = False
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(147, 157)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 27)
        Me.btnAdd.TabIndex = 63
        Me.btnAdd.Text = "เพิ่ม"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Enabled = False
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(309, 157)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 27)
        Me.btnCancel.TabIndex = 62
        Me.btnCancel.Text = "ยกเลิก"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(228, 157)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 27)
        Me.btnSave.TabIndex = 61
        Me.btnSave.Text = "บันทึก"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cbo_e_m
        '
        Me.cbo_e_m.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbo_e_m.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_e_m.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_e_m.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_e_m.FormattingEnabled = True
        Me.cbo_e_m.Items.AddRange(New Object() {"00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"})
        Me.cbo_e_m.Location = New System.Drawing.Point(333, 97)
        Me.cbo_e_m.Name = "cbo_e_m"
        Me.cbo_e_m.Size = New System.Drawing.Size(38, 25)
        Me.cbo_e_m.TabIndex = 60
        '
        'cbo_e_h
        '
        Me.cbo_e_h.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbo_e_h.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_e_h.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_e_h.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_e_h.FormatString = "N2"
        Me.cbo_e_h.FormattingEnabled = True
        Me.cbo_e_h.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cbo_e_h.Location = New System.Drawing.Point(288, 97)
        Me.cbo_e_h.Name = "cbo_e_h"
        Me.cbo_e_h.Size = New System.Drawing.Size(38, 25)
        Me.cbo_e_h.TabIndex = 59
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(325, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 17)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = ":"
        '
        'cbo_s_m
        '
        Me.cbo_s_m.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbo_s_m.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_s_m.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_s_m.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_s_m.FormattingEnabled = True
        Me.cbo_s_m.Items.AddRange(New Object() {"00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"})
        Me.cbo_s_m.Location = New System.Drawing.Point(193, 97)
        Me.cbo_s_m.Name = "cbo_s_m"
        Me.cbo_s_m.Size = New System.Drawing.Size(38, 25)
        Me.cbo_s_m.TabIndex = 57
        '
        'cbo_s_h
        '
        Me.cbo_s_h.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbo_s_h.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_s_h.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_s_h.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_s_h.FormatString = "N2"
        Me.cbo_s_h.FormattingEnabled = True
        Me.cbo_s_h.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cbo_s_h.Location = New System.Drawing.Point(148, 97)
        Me.cbo_s_h.Name = "cbo_s_h"
        Me.cbo_s_h.Size = New System.Drawing.Size(38, 25)
        Me.cbo_s_h.TabIndex = 56
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(185, 100)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 17)
        Me.Label11.TabIndex = 55
        Me.Label11.Text = ":"
        '
        'cboCom
        '
        Me.cboCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCom.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCom.FormattingEnabled = True
        Me.cboCom.Location = New System.Drawing.Point(148, 12)
        Me.cboCom.Name = "cboCom"
        Me.cboCom.Size = New System.Drawing.Size(223, 25)
        Me.cboCom.TabIndex = 14
        '
        'cboMenu
        '
        Me.cboMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMenu.FormattingEnabled = True
        Me.cboMenu.Location = New System.Drawing.Point(148, 40)
        Me.cboMenu.Name = "cboMenu"
        Me.cboMenu.Size = New System.Drawing.Size(117, 25)
        Me.cboMenu.TabIndex = 13
        '
        'TxtDate
        '
        Me.TxtDate.DateValue = New Date(CType(0, Long))
        Me.TxtDate.Location = New System.Drawing.Point(148, 68)
        Me.TxtDate.Name = "TxtDate"
        Me.TxtDate.Size = New System.Drawing.Size(125, 24)
        Me.TxtDate.TabIndex = 12
        '
        'cb
        '
        Me.cb.AutoSize = True
        Me.cb.Checked = True
        Me.cb.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb.Location = New System.Drawing.Point(150, 130)
        Me.cb.Name = "cb"
        Me.cb.Size = New System.Drawing.Size(57, 21)
        Me.cb.TabIndex = 9
        Me.cb.Text = "ใช้งาน"
        Me.cb.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(240, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "เวลาปิด"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(95, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "เวลาเปิด"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(111, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "วันที่"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(91, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ชื่อเครื่อง"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.stDate, Me.open_time, Me.close_time, Me.menu_name, Me.status_name, Me.menu_id, Me.s_status, Me.id})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 217)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(501, 202)
        Me.DataGridView1.TabIndex = 1
        '
        'stDate
        '
        Me.stDate.DataPropertyName = "stDate"
        Me.stDate.HeaderText = "วันที่"
        Me.stDate.Name = "stDate"
        Me.stDate.ReadOnly = True
        '
        'open_time
        '
        Me.open_time.DataPropertyName = "open_time"
        Me.open_time.HeaderText = "เวลาเปิด"
        Me.open_time.Name = "open_time"
        Me.open_time.ReadOnly = True
        '
        'close_time
        '
        Me.close_time.DataPropertyName = "close_time"
        Me.close_time.HeaderText = "เวลาปิด"
        Me.close_time.Name = "close_time"
        Me.close_time.ReadOnly = True
        '
        'menu_name
        '
        Me.menu_name.DataPropertyName = "menu_name"
        Me.menu_name.HeaderText = "เมนู"
        Me.menu_name.Name = "menu_name"
        Me.menu_name.ReadOnly = True
        '
        'status_name
        '
        Me.status_name.DataPropertyName = "status_name"
        Me.status_name.HeaderText = "status_name"
        Me.status_name.Name = "status_name"
        Me.status_name.ReadOnly = True
        Me.status_name.Visible = False
        '
        'menu_id
        '
        Me.menu_id.DataPropertyName = "menu_id"
        Me.menu_id.HeaderText = "menu_id"
        Me.menu_id.Name = "menu_id"
        Me.menu_id.ReadOnly = True
        Me.menu_id.Visible = False
        '
        's_status
        '
        Me.s_status.DataPropertyName = "s_status"
        Me.s_status.HeaderText = "s_status"
        Me.s_status.Name = "s_status"
        Me.s_status.ReadOnly = True
        Me.s_status.Visible = False
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'frmShutdownMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 431)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmShutdownMenu"
        Me.Text = "กำหนดเวลาเปิดปิดเมนู ยืม-คืน"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TxtDate As DIP.txtDate
    Friend WithEvents cboMenu As System.Windows.Forms.ComboBox
    Friend WithEvents cboCom As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_e_m As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_e_h As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_s_m As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_s_h As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents stDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents open_time As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents close_time As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents menu_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents menu_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
