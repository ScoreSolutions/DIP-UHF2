<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShelfName
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShelfName))
        Me.txtReqNoTo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtReqNoFrom = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtShelf = New System.Windows.Forms.TextBox
        Me.GridAppNo = New System.Windows.Forms.DataGridView
        Me.app_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.shelf_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnSave = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridAppNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtReqNoTo
        '
        Me.txtReqNoTo.BackColor = System.Drawing.Color.White
        Me.txtReqNoTo.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtReqNoTo.Location = New System.Drawing.Point(252, 19)
        Me.txtReqNoTo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtReqNoTo.Name = "txtReqNoTo"
        Me.txtReqNoTo.Size = New System.Drawing.Size(113, 25)
        Me.txtReqNoTo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(223, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 19)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "ถึง"
        '
        'txtReqNoFrom
        '
        Me.txtReqNoFrom.BackColor = System.Drawing.Color.White
        Me.txtReqNoFrom.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtReqNoFrom.Location = New System.Drawing.Point(104, 19)
        Me.txtReqNoFrom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtReqNoFrom.Name = "txtReqNoFrom"
        Me.txtReqNoFrom.Size = New System.Drawing.Size(113, 25)
        Me.txtReqNoFrom.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(27, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 19)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "เลขที่คำขอ :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtShelf)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtReqNoTo)
        Me.GroupBox1.Controls.Add(Me.txtReqNoFrom)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 4)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(435, 90)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(371, 18)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(50, 26)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "ค้นหา"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(8, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 19)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "ชั้นวางเอกสาร :"
        '
        'txtShelf
        '
        Me.txtShelf.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtShelf.Location = New System.Drawing.Point(104, 52)
        Me.txtShelf.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtShelf.Name = "txtShelf"
        Me.txtShelf.Size = New System.Drawing.Size(317, 25)
        Me.txtShelf.TabIndex = 3
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
        Me.GridAppNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridAppNo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.app_no, Me.shelf_name, Me.id})
        Me.GridAppNo.Location = New System.Drawing.Point(10, 106)
        Me.GridAppNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridAppNo.MultiSelect = False
        Me.GridAppNo.Name = "GridAppNo"
        Me.GridAppNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridAppNo.Size = New System.Drawing.Size(435, 388)
        Me.GridAppNo.TabIndex = 29
        '
        'app_no
        '
        Me.app_no.DataPropertyName = "app_no"
        Me.app_no.HeaderText = "เลขที่คำขอ"
        Me.app_no.Name = "app_no"
        Me.app_no.ReadOnly = True
        Me.app_no.Width = 120
        '
        'shelf_name
        '
        Me.shelf_name.DataPropertyName = "shelf_name"
        Me.shelf_name.HeaderText = "ชั้นวางเอกสาร"
        Me.shelf_name.Name = "shelf_name"
        Me.shelf_name.ReadOnly = True
        Me.shelf_name.Width = 220
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSave.Location = New System.Drawing.Point(173, 502)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(110, 30)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "บันทึก"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmShelfName
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 538)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GridAppNo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmShelfName"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "กำหนดชั้นวางเอกสาร"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridAppNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtReqNoTo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtReqNoFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtShelf As System.Windows.Forms.TextBox
    Friend WithEvents GridAppNo As System.Windows.Forms.DataGridView
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents app_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents shelf_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
