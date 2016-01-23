<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFloorMove
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFloorMove))
        Me.GridAppNo = New System.Windows.Forms.DataGridView
        Me.btnSendBack = New System.Windows.Forms.Button
        Me.lblCount = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSendTo = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.cbAll = New System.Windows.Forms.CheckBox
        Me.chkSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.app_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.patentype = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.status_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.locationto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.found = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.location_id_from = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.location_id_to = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.GridAppNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridAppNo
        '
        Me.GridAppNo.AllowUserToAddRows = False
        Me.GridAppNo.AllowUserToDeleteRows = False
        Me.GridAppNo.AllowUserToOrderColumns = True
        Me.GridAppNo.AllowUserToResizeColumns = False
        Me.GridAppNo.AllowUserToResizeRows = False
        Me.GridAppNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GridAppNo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridAppNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridAppNo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chkSelect, Me.app_no, Me.patentype, Me.status_name, Me.locationto, Me.found, Me.location_id_from, Me.location_id_to})
        Me.GridAppNo.Location = New System.Drawing.Point(12, 56)
        Me.GridAppNo.MultiSelect = False
        Me.GridAppNo.Name = "GridAppNo"
        Me.GridAppNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridAppNo.Size = New System.Drawing.Size(651, 344)
        Me.GridAppNo.TabIndex = 6
        '
        'btnSendBack
        '
        Me.btnSendBack.Enabled = False
        Me.btnSendBack.Location = New System.Drawing.Point(672, 118)
        Me.btnSendBack.Name = "btnSendBack"
        Me.btnSendBack.Size = New System.Drawing.Size(185, 40)
        Me.btnSendBack.TabIndex = 29
        Me.btnSendBack.Text = "บันทึกการค้นหาจาก Handhled"
        Me.btnSendBack.UseVisualStyleBackColor = True
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblCount.Location = New System.Drawing.Point(12, 414)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(103, 17)
        Me.lblCount.TabIndex = 30
        Me.lblCount.Text = "จำนวน  0 แฟ้ม"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(774, 363)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(83, 37)
        Me.btnCancel.TabIndex = 31
        Me.btnCancel.Text = "ยกเลิก"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSendTo
        '
        Me.btnSendTo.Location = New System.Drawing.Point(672, 56)
        Me.btnSendTo.Name = "btnSendTo"
        Me.btnSendTo.Size = New System.Drawing.Size(185, 40)
        Me.btnSendTo.TabIndex = 32
        Me.btnSendTo.Text = "ส่งการค้นหาไปยัง Handhled"
        Me.btnSendTo.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(672, 363)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(83, 37)
        Me.btnSave.TabIndex = 35
        Me.btnSave.Text = "บันทึก"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cbAll
        '
        Me.cbAll.AutoSize = True
        Me.cbAll.Enabled = False
        Me.cbAll.Location = New System.Drawing.Point(12, 23)
        Me.cbAll.Name = "cbAll"
        Me.cbAll.Size = New System.Drawing.Size(59, 17)
        Me.cbAll.TabIndex = 38
        Me.cbAll.Text = "ทั้งหมด"
        Me.cbAll.UseVisualStyleBackColor = True
        '
        'chkSelect
        '
        Me.chkSelect.FalseValue = "N"
        Me.chkSelect.FillWeight = 76.14214!
        Me.chkSelect.HeaderText = "เลือก"
        Me.chkSelect.Name = "chkSelect"
        Me.chkSelect.TrueValue = "Y"
        '
        'app_no
        '
        Me.app_no.DataPropertyName = "app_no"
        Me.app_no.FillWeight = 111.9289!
        Me.app_no.HeaderText = "เลขที่คำขอ"
        Me.app_no.Name = "app_no"
        '
        'patentype
        '
        Me.patentype.DataPropertyName = "patentype"
        DataGridViewCellStyle1.NullValue = "1"
        Me.patentype.DefaultCellStyle = DataGridViewCellStyle1
        Me.patentype.FillWeight = 111.9289!
        Me.patentype.HeaderText = "ประเภทแฟ้ม"
        Me.patentype.Name = "patentype"
        '
        'status_name
        '
        Me.status_name.DataPropertyName = "status_name"
        Me.status_name.HeaderText = "สถานะ"
        Me.status_name.Name = "status_name"
        Me.status_name.ReadOnly = True
        '
        'locationto
        '
        Me.locationto.DataPropertyName = "locationto"
        Me.locationto.HeaderText = "ย้ายไปยังสถานที่"
        Me.locationto.Name = "locationto"
        Me.locationto.ReadOnly = True
        '
        'found
        '
        Me.found.DataPropertyName = "found"
        Me.found.HeaderText = "found"
        Me.found.Name = "found"
        Me.found.Visible = False
        '
        'location_id_from
        '
        Me.location_id_from.DataPropertyName = "location_id_from"
        Me.location_id_from.HeaderText = "location_id_from"
        Me.location_id_from.Name = "location_id_from"
        Me.location_id_from.Visible = False
        '
        'location_id_to
        '
        Me.location_id_to.DataPropertyName = "location_id_to"
        Me.location_id_to.HeaderText = "location_id_to"
        Me.location_id_to.Name = "location_id_to"
        Me.location_id_to.Visible = False
        '
        'frmFloorMove
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 440)
        Me.Controls.Add(Me.cbAll)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnSendTo)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.btnSendBack)
        Me.Controls.Add(Me.GridAppNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFloorMove"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "แฟ้มเอกสารทั้งหมดที่ต้องเคลื่อนย้าย"
        CType(Me.GridAppNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSendBack As System.Windows.Forms.Button
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GridAppNo As System.Windows.Forms.DataGridView
    Friend WithEvents btnSendTo As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cbAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents app_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents patentype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents locationto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents found As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents location_id_from As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents location_id_to As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
