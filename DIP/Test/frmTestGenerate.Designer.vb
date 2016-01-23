<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTestGenerate
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtID = New System.Windows.Forms.TextBox
        Me.txtColUnique = New System.Windows.Forms.TextBox
        Me.txtColInt = New System.Windows.Forms.TextBox
        Me.txtColVarchar = New System.Windows.Forms.TextBox
        Me.txtColDatetime = New System.Windows.Forms.TextBox
        Me.txtColCreateby = New System.Windows.Forms.TextBox
        Me.txtColCreateon = New System.Windows.Forms.TextBox
        Me.txtColUpdateby = New System.Windows.Forms.TextBox
        Me.txtColUpdateon = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(290, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(137, 12)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 1
        '
        'txtColUnique
        '
        Me.txtColUnique.Location = New System.Drawing.Point(137, 38)
        Me.txtColUnique.Name = "txtColUnique"
        Me.txtColUnique.Size = New System.Drawing.Size(100, 20)
        Me.txtColUnique.TabIndex = 2
        '
        'txtColInt
        '
        Me.txtColInt.Location = New System.Drawing.Point(137, 64)
        Me.txtColInt.Name = "txtColInt"
        Me.txtColInt.Size = New System.Drawing.Size(100, 20)
        Me.txtColInt.TabIndex = 3
        '
        'txtColVarchar
        '
        Me.txtColVarchar.Location = New System.Drawing.Point(137, 90)
        Me.txtColVarchar.Name = "txtColVarchar"
        Me.txtColVarchar.Size = New System.Drawing.Size(100, 20)
        Me.txtColVarchar.TabIndex = 4
        '
        'txtColDatetime
        '
        Me.txtColDatetime.Location = New System.Drawing.Point(137, 116)
        Me.txtColDatetime.Name = "txtColDatetime"
        Me.txtColDatetime.Size = New System.Drawing.Size(100, 20)
        Me.txtColDatetime.TabIndex = 5
        '
        'txtColCreateby
        '
        Me.txtColCreateby.Location = New System.Drawing.Point(137, 142)
        Me.txtColCreateby.Name = "txtColCreateby"
        Me.txtColCreateby.Size = New System.Drawing.Size(100, 20)
        Me.txtColCreateby.TabIndex = 6
        '
        'txtColCreateon
        '
        Me.txtColCreateon.Location = New System.Drawing.Point(137, 168)
        Me.txtColCreateon.Name = "txtColCreateon"
        Me.txtColCreateon.Size = New System.Drawing.Size(100, 20)
        Me.txtColCreateon.TabIndex = 7
        '
        'txtColUpdateby
        '
        Me.txtColUpdateby.Location = New System.Drawing.Point(136, 194)
        Me.txtColUpdateby.Name = "txtColUpdateby"
        Me.txtColUpdateby.Size = New System.Drawing.Size(100, 20)
        Me.txtColUpdateby.TabIndex = 8
        '
        'txtColUpdateon
        '
        Me.txtColUpdateon.Location = New System.Drawing.Point(137, 220)
        Me.txtColUpdateon.Name = "txtColUpdateon"
        Me.txtColUpdateon.Size = New System.Drawing.Size(100, 20)
        Me.txtColUpdateon.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "lblID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(55, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "lblColUnique"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(55, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "lblColInt"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(55, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "lblColVarchar"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(55, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "lblColDatetime"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(55, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "lblColCreateby"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(55, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "lblColCreateon"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(55, 197)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "lblColUpdateby"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(55, 223)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "lblColUpdateon"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(290, 57)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "Show"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 246)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(659, 150)
        Me.DataGridView1.TabIndex = 20
        '
        'frmTestGenerate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 408)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtColUpdateon)
        Me.Controls.Add(Me.txtColUpdateby)
        Me.Controls.Add(Me.txtColCreateon)
        Me.Controls.Add(Me.txtColCreateby)
        Me.Controls.Add(Me.txtColDatetime)
        Me.Controls.Add(Me.txtColVarchar)
        Me.Controls.Add(Me.txtColInt)
        Me.Controls.Add(Me.txtColUnique)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmTestGenerate"
        Me.Text = "frmTestGenerate"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents txtColUnique As System.Windows.Forms.TextBox
    Friend WithEvents txtColInt As System.Windows.Forms.TextBox
    Friend WithEvents txtColVarchar As System.Windows.Forms.TextBox
    Friend WithEvents txtColDatetime As System.Windows.Forms.TextBox
    Friend WithEvents txtColCreateby As System.Windows.Forms.TextBox
    Friend WithEvents txtColCreateon As System.Windows.Forms.TextBox
    Friend WithEvents txtColUpdateby As System.Windows.Forms.TextBox
    Friend WithEvents txtColUpdateon As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
