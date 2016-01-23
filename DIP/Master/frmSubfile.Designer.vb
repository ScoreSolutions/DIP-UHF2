<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSubfile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSubfile))
        Me.GridAppNo = New System.Windows.Forms.DataGridView
        Me.app_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.app_qty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtReqNoTo = New System.Windows.Forms.TextBox
        Me.txtReqNoFrom = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
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
        Me.GridAppNo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.app_no, Me.app_qty, Me.id})
        Me.GridAppNo.Location = New System.Drawing.Point(12, 42)
        Me.GridAppNo.MultiSelect = False
        Me.GridAppNo.Name = "GridAppNo"
        Me.GridAppNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridAppNo.Size = New System.Drawing.Size(390, 366)
        Me.GridAppNo.TabIndex = 6
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
        Me.app_qty.DataPropertyName = "qty"
        DataGridViewCellStyle1.NullValue = "1"
        Me.app_qty.DefaultCellStyle = DataGridViewCellStyle1
        Me.app_qty.HeaderText = "จำนวนแฟ้มทั้งหมด"
        Me.app_qty.Name = "app_qty"
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(353, 5)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(50, 26)
        Me.btnSearch.TabIndex = 29
        Me.btnSearch.Text = "ค้นหา"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(9, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 19)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "เลขที่คำขอ :"
        '
        'txtReqNoTo
        '
        Me.txtReqNoTo.BackColor = System.Drawing.Color.White
        Me.txtReqNoTo.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtReqNoTo.Location = New System.Drawing.Point(234, 6)
        Me.txtReqNoTo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtReqNoTo.Name = "txtReqNoTo"
        Me.txtReqNoTo.Size = New System.Drawing.Size(113, 25)
        Me.txtReqNoTo.TabIndex = 28
        '
        'txtReqNoFrom
        '
        Me.txtReqNoFrom.BackColor = System.Drawing.Color.White
        Me.txtReqNoFrom.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtReqNoFrom.Location = New System.Drawing.Point(86, 6)
        Me.txtReqNoFrom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtReqNoFrom.Name = "txtReqNoFrom"
        Me.txtReqNoFrom.Size = New System.Drawing.Size(113, 25)
        Me.txtReqNoFrom.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(205, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 19)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "ถึง"
        '
        'frmSubfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 420)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtReqNoTo)
        Me.Controls.Add(Me.txtReqNoFrom)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GridAppNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSubfile"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "กำหนดจำนวนแฟ้มต่อ"
        CType(Me.GridAppNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridAppNo As System.Windows.Forms.DataGridView
    Friend WithEvents app_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents app_qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtReqNoTo As System.Windows.Forms.TextBox
    Friend WithEvents txtReqNoFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
