<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGateConsole
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGateConsole))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.rowno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.timestamp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.app_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnOpenComport = New System.Windows.Forms.Button
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.btnAlarmON = New System.Windows.Forms.Button
        Me.btnAlarmOFF = New System.Windows.Forms.Button
        Me.btnReadGate = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.cbAlarmStatus = New System.Windows.Forms.CheckBox
        Me.cbOnOff = New System.Windows.Forms.CheckBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 20
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rowno, Me.timestamp, Me.app_no})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 41)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(511, 520)
        Me.DataGridView1.TabIndex = 0
        '
        'rowno
        '
        Me.rowno.DataPropertyName = "rowno"
        Me.rowno.HeaderText = "ลำดับ"
        Me.rowno.Name = "rowno"
        '
        'timestamp
        '
        Me.timestamp.DataPropertyName = "timestamp"
        Me.timestamp.HeaderText = "Time"
        Me.timestamp.Name = "timestamp"
        Me.timestamp.Width = 200
        '
        'app_no
        '
        Me.app_no.DataPropertyName = "app_no"
        Me.app_no.HeaderText = "เลขที่คำขอ"
        Me.app_no.Name = "app_no"
        '
        'btnOpenComport
        '
        Me.btnOpenComport.Location = New System.Drawing.Point(12, 12)
        Me.btnOpenComport.Name = "btnOpenComport"
        Me.btnOpenComport.Size = New System.Drawing.Size(93, 23)
        Me.btnOpenComport.TabIndex = 1
        Me.btnOpenComport.Text = "Open Comport"
        Me.btnOpenComport.UseVisualStyleBackColor = True
        '
        'SerialPort1
        '
        Me.SerialPort1.PortName = "COM2"
        '
        'btnAlarmON
        '
        Me.btnAlarmON.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAlarmON.Location = New System.Drawing.Point(367, 12)
        Me.btnAlarmON.Name = "btnAlarmON"
        Me.btnAlarmON.Size = New System.Drawing.Size(75, 23)
        Me.btnAlarmON.TabIndex = 2
        Me.btnAlarmON.Text = "AlarmON"
        Me.btnAlarmON.UseVisualStyleBackColor = True
        '
        'btnAlarmOFF
        '
        Me.btnAlarmOFF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAlarmOFF.Location = New System.Drawing.Point(448, 12)
        Me.btnAlarmOFF.Name = "btnAlarmOFF"
        Me.btnAlarmOFF.Size = New System.Drawing.Size(75, 23)
        Me.btnAlarmOFF.TabIndex = 3
        Me.btnAlarmOFF.Text = "AlarmOff"
        Me.btnAlarmOFF.UseVisualStyleBackColor = True
        '
        'btnReadGate
        '
        Me.btnReadGate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReadGate.Location = New System.Drawing.Point(286, 12)
        Me.btnReadGate.Name = "btnReadGate"
        Me.btnReadGate.Size = New System.Drawing.Size(75, 23)
        Me.btnReadGate.TabIndex = 4
        Me.btnReadGate.Text = "ReadGate"
        Me.btnReadGate.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 570)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Comport : CLOSE"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(205, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Clear"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 600
        '
        'cbAlarmStatus
        '
        Me.cbAlarmStatus.AutoSize = True
        Me.cbAlarmStatus.Location = New System.Drawing.Point(438, 569)
        Me.cbAlarmStatus.Name = "cbAlarmStatus"
        Me.cbAlarmStatus.Size = New System.Drawing.Size(85, 17)
        Me.cbAlarmStatus.TabIndex = 9
        Me.cbAlarmStatus.Text = "Alarm Status"
        Me.cbAlarmStatus.UseVisualStyleBackColor = True
        '
        'cbOnOff
        '
        Me.cbOnOff.AutoSize = True
        Me.cbOnOff.Location = New System.Drawing.Point(336, 569)
        Me.cbOnOff.Name = "cbOnOff"
        Me.cbOnOff.Size = New System.Drawing.Size(86, 17)
        Me.cbOnOff.TabIndex = 10
        Me.cbOnOff.Text = "Alarm On-Off"
        Me.cbOnOff.UseVisualStyleBackColor = True
        '
        'frmGateConsole
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 593)
        Me.Controls.Add(Me.cbOnOff)
        Me.Controls.Add(Me.cbAlarmStatus)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnReadGate)
        Me.Controls.Add(Me.btnAlarmOFF)
        Me.Controls.Add(Me.btnAlarmON)
        Me.Controls.Add(Me.btnOpenComport)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGateConsole"
        Me.Text = "Gate Console"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnOpenComport As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents btnAlarmON As System.Windows.Forms.Button
    Friend WithEvents btnAlarmOFF As System.Windows.Forms.Button
    Friend WithEvents btnReadGate As System.Windows.Forms.Button
    Friend WithEvents rowno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents timestamp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents app_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents cbAlarmStatus As System.Windows.Forms.CheckBox
    Friend WithEvents cbOnOff As System.Windows.Forms.CheckBox

End Class
