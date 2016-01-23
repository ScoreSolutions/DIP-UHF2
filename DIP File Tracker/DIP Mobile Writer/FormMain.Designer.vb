<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.timer1 = New System.Windows.Forms.Timer
        Me.comboBox1 = New System.Windows.Forms.ComboBox
        Me.textBox1 = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.textBox2 = New System.Windows.Forms.TextBox
        Me.status = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'timer1
        '
        '
        'comboBox1
        '
        Me.comboBox1.Location = New System.Drawing.Point(3, 86)
        Me.comboBox1.Name = "comboBox1"
        Me.comboBox1.Size = New System.Drawing.Size(223, 23)
        Me.comboBox1.TabIndex = 0
        '
        'textBox1
        '
        Me.textBox1.Location = New System.Drawing.Point(3, 148)
        Me.textBox1.Multiline = True
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(223, 50)
        Me.textBox1.TabIndex = 1
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(3, 60)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(223, 20)
        Me.label1.Text = "Memory Bank:"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(3, 118)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(223, 20)
        Me.label2.Text = "Data:"
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(3, 5)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(223, 18)
        Me.label3.Text = "UID:"
        '
        'textBox2
        '
        Me.textBox2.Location = New System.Drawing.Point(3, 32)
        Me.textBox2.Name = "textBox2"
        Me.textBox2.ReadOnly = True
        Me.textBox2.Size = New System.Drawing.Size(223, 23)
        Me.textBox2.TabIndex = 5
        '
        'status
        '
        Me.status.Location = New System.Drawing.Point(5, 210)
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(223, 66)
        Me.status.Text = "Press Main (Center) trigger(s) to Inventory tags"
        Me.status.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(245, 292)
        Me.Controls.Add(Me.status)
        Me.Controls.Add(Me.textBox2)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.comboBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMain"
        Me.Text = "DIP MOBILE WRITER"
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents timer1 As System.Windows.Forms.Timer
    Private WithEvents comboBox1 As System.Windows.Forms.ComboBox
    Private WithEvents textBox1 As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents textBox2 As System.Windows.Forms.TextBox
    Private WithEvents status As System.Windows.Forms.Label


End Class
