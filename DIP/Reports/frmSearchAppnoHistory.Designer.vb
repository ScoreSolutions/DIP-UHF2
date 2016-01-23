<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchAppnoHistory
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.gdvData = New System.Windows.Forms.DataGridView
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APP_NO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BORROWERID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BORROWNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.S_BORROW = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EMP_BORROW = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.R_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.S_RETURN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EMP_RETURN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gdvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI Symbol", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 4)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(921, 60)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(272, 21)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 25)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "ค้นหา"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(84, 21)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(173, 25)
        Me.txtSearch.TabIndex = 1
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "เลขที่คำขอ :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.gdvData)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 63)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(921, 316)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'gdvData
        '
        Me.gdvData.AllowUserToAddRows = False
        Me.gdvData.AllowUserToDeleteRows = False
        Me.gdvData.AllowUserToResizeRows = False
        Me.gdvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gdvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.gdvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gdvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.APP_NO, Me.B_DATE, Me.BORROWERID, Me.BORROWNAME, Me.S_BORROW, Me.EMP_BORROW, Me.R_DATE, Me.S_RETURN, Me.EMP_RETURN})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gdvData.DefaultCellStyle = DataGridViewCellStyle2
        Me.gdvData.Location = New System.Drawing.Point(13, 23)
        Me.gdvData.MultiSelect = False
        Me.gdvData.Name = "gdvData"
        Me.gdvData.ReadOnly = True
        Me.gdvData.RowHeadersVisible = False
        Me.gdvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gdvData.Size = New System.Drawing.Size(896, 278)
        Me.gdvData.TabIndex = 28
        '
        'No
        '
        Me.No.DataPropertyName = "No"
        Me.No.HeaderText = "ลำดับที่"
        Me.No.Name = "No"
        Me.No.ReadOnly = True
        Me.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.No.Width = 47
        '
        'APP_NO
        '
        Me.APP_NO.DataPropertyName = "APP_NO"
        Me.APP_NO.HeaderText = "เลขที่คำขอ"
        Me.APP_NO.Name = "APP_NO"
        Me.APP_NO.ReadOnly = True
        Me.APP_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.APP_NO.Width = 63
        '
        'B_DATE
        '
        Me.B_DATE.DataPropertyName = "B_DATE"
        Me.B_DATE.HeaderText = "วันที่ยืม"
        Me.B_DATE.Name = "B_DATE"
        Me.B_DATE.ReadOnly = True
        Me.B_DATE.Width = 67
        '
        'BORROWERID
        '
        Me.BORROWERID.DataPropertyName = "BORROWERID"
        Me.BORROWERID.HeaderText = "รหัสผู้ยืม"
        Me.BORROWERID.Name = "BORROWERID"
        Me.BORROWERID.ReadOnly = True
        Me.BORROWERID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.BORROWERID.Width = 55
        '
        'BORROWNAME
        '
        Me.BORROWNAME.DataPropertyName = "BORROWNAME"
        Me.BORROWNAME.HeaderText = "ชื่อผู้ยืม"
        Me.BORROWNAME.Name = "BORROWNAME"
        Me.BORROWNAME.ReadOnly = True
        Me.BORROWNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.BORROWNAME.Width = 47
        '
        'S_BORROW
        '
        Me.S_BORROW.DataPropertyName = "S_BORROW"
        Me.S_BORROW.HeaderText = "ลักษณะการยืม"
        Me.S_BORROW.Name = "S_BORROW"
        Me.S_BORROW.ReadOnly = True
        Me.S_BORROW.Width = 97
        '
        'EMP_BORROW
        '
        Me.EMP_BORROW.DataPropertyName = "EMP_BORROW"
        Me.EMP_BORROW.HeaderText = "ผู้ให้ยืม"
        Me.EMP_BORROW.Name = "EMP_BORROW"
        Me.EMP_BORROW.ReadOnly = True
        Me.EMP_BORROW.Width = 66
        '
        'R_DATE
        '
        Me.R_DATE.DataPropertyName = "R_DATE"
        Me.R_DATE.HeaderText = "วันที่คืน"
        Me.R_DATE.Name = "R_DATE"
        Me.R_DATE.ReadOnly = True
        Me.R_DATE.Width = 68
        '
        'S_RETURN
        '
        Me.S_RETURN.DataPropertyName = "S_RETURN"
        Me.S_RETURN.HeaderText = "ลักษณะการคืน"
        Me.S_RETURN.Name = "S_RETURN"
        Me.S_RETURN.ReadOnly = True
        Me.S_RETURN.Width = 98
        '
        'EMP_RETURN
        '
        Me.EMP_RETURN.DataPropertyName = "EMP_RETURN"
        Me.EMP_RETURN.HeaderText = "ผู้รับแฟ้ม"
        Me.EMP_RETURN.Name = "EMP_RETURN"
        Me.EMP_RETURN.ReadOnly = True
        Me.EMP_RETURN.Width = 74
        '
        'frmSearchAppnoHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 391)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearchAppnoHistory"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ค้นหาแฟ้มที่ติดชื่อผู้ยืม"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.gdvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gdvData As System.Windows.Forms.DataGridView
    Friend WithEvents No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APP_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B_DATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BORROWERID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BORROWNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents S_BORROW As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMP_BORROW As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents R_DATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents S_RETURN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMP_RETURN As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
