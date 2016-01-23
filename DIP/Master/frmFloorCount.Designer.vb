<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFloorCount
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFloorCount))
        Me.GridAppNo = New System.Windows.Forms.DataGridView
        Me.btnSearch = New System.Windows.Forms.Button
        Me.lblCount = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.app_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.app_qty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.borrow_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.readerid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.borrow_id = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.GridAppNo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridAppNo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridAppNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridAppNo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.app_no, Me.app_qty, Me.borrow_name, Me.readerid, Me.borrow_id})
        Me.GridAppNo.Location = New System.Drawing.Point(12, 56)
        Me.GridAppNo.MultiSelect = False
        Me.GridAppNo.Name = "GridAppNo"
        Me.GridAppNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridAppNo.Size = New System.Drawing.Size(562, 343)
        Me.GridAppNo.TabIndex = 6
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(12, 10)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(185, 40)
        Me.btnSearch.TabIndex = 29
        Me.btnSearch.Text = "บันทึกการค้นหาจาก Handhled"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblCount.Location = New System.Drawing.Point(229, 21)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(103, 17)
        Me.lblCount.TabIndex = 30
        Me.lblCount.Text = "จำนวน  0 แฟ้ม"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(257, 405)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 30)
        Me.btnSave.TabIndex = 31
        Me.btnSave.Text = "บันทึก"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'app_no
        '
        Me.app_no.DataPropertyName = "app_no"
        Me.app_no.HeaderText = "เลขที่คำขอ"
        Me.app_no.Name = "app_no"
        Me.app_no.ReadOnly = True
        '
        'app_qty
        '
        Me.app_qty.DataPropertyName = "location"
        DataGridViewCellStyle1.NullValue = "1"
        Me.app_qty.DefaultCellStyle = DataGridViewCellStyle1
        Me.app_qty.HeaderText = "สถานที่"
        Me.app_qty.Name = "app_qty"
        '
        'borrow_name
        '
        Me.borrow_name.DataPropertyName = "borrow_name"
        Me.borrow_name.HeaderText = "ผู้ครอบครอง"
        Me.borrow_name.Name = "borrow_name"
        '
        'readerid
        '
        Me.readerid.HeaderText = "readerid"
        Me.readerid.Name = "readerid"
        Me.readerid.Visible = False
        '
        'borrow_id
        '
        Me.borrow_id.HeaderText = "borrow_id"
        Me.borrow_id.Name = "borrow_id"
        Me.borrow_id.Visible = False
        '
        'frmFloorCount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 440)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.GridAppNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFloorCount"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ตรวจนับแฟ้ม"
        CType(Me.GridAppNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents GridAppNo As System.Windows.Forms.DataGridView
    Friend WithEvents app_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents app_qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents borrow_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents readerid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents borrow_id As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
