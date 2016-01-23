<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlAuthList
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.btnDelAll = New System.Windows.Forms.Button
        Me.btnDelSel = New System.Windows.Forms.Button
        Me.btnAddSel = New System.Windows.Forms.Button
        Me.btnAddAll = New System.Windows.Forms.Button
        Me.lstLeftList = New System.Windows.Forms.ListBox
        Me.lstRightList = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.Location = New System.Drawing.Point(624, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 20)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "สิทธิ์ที่ยังไม่กำหนด"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.Location = New System.Drawing.Point(134, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 20)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "สิทธิ์ที่ผู้ใช้ได้รับ"
        '
        'btnDelAll
        '
        Me.btnDelAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnDelAll.Location = New System.Drawing.Point(419, 64)
        Me.btnDelAll.Name = "btnDelAll"
        Me.btnDelAll.Size = New System.Drawing.Size(45, 31)
        Me.btnDelAll.TabIndex = 8
        Me.btnDelAll.Text = ">>"
        Me.btnDelAll.UseVisualStyleBackColor = True
        '
        'btnDelSel
        '
        Me.btnDelSel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnDelSel.Location = New System.Drawing.Point(419, 118)
        Me.btnDelSel.Name = "btnDelSel"
        Me.btnDelSel.Size = New System.Drawing.Size(45, 31)
        Me.btnDelSel.TabIndex = 9
        Me.btnDelSel.Text = ">"
        Me.btnDelSel.UseVisualStyleBackColor = True
        '
        'btnAddSel
        '
        Me.btnAddSel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnAddSel.Location = New System.Drawing.Point(419, 155)
        Me.btnAddSel.Name = "btnAddSel"
        Me.btnAddSel.Size = New System.Drawing.Size(45, 31)
        Me.btnAddSel.TabIndex = 10
        Me.btnAddSel.Text = "<"
        Me.btnAddSel.UseVisualStyleBackColor = True
        '
        'btnAddAll
        '
        Me.btnAddAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnAddAll.Location = New System.Drawing.Point(419, 206)
        Me.btnAddAll.Name = "btnAddAll"
        Me.btnAddAll.Size = New System.Drawing.Size(45, 31)
        Me.btnAddAll.TabIndex = 11
        Me.btnAddAll.Text = "<<"
        Me.btnAddAll.UseVisualStyleBackColor = True
        '
        'lstLeftList
        '
        Me.lstLeftList.AllowDrop = True
        Me.lstLeftList.FormattingEnabled = True
        Me.lstLeftList.Location = New System.Drawing.Point(3, 33)
        Me.lstLeftList.Name = "lstLeftList"
        Me.lstLeftList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstLeftList.Size = New System.Drawing.Size(410, 251)
        Me.lstLeftList.TabIndex = 12
        '
        'lstRightList
        '
        Me.lstRightList.AllowDrop = True
        Me.lstRightList.FormattingEnabled = True
        Me.lstRightList.Location = New System.Drawing.Point(470, 33)
        Me.lstRightList.Name = "lstRightList"
        Me.lstRightList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstRightList.Size = New System.Drawing.Size(410, 251)
        Me.lstRightList.TabIndex = 13
        '
        'ctlAuthList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lstRightList)
        Me.Controls.Add(Me.lstLeftList)
        Me.Controls.Add(Me.btnAddAll)
        Me.Controls.Add(Me.btnAddSel)
        Me.Controls.Add(Me.btnDelSel)
        Me.Controls.Add(Me.btnDelAll)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Name = "ctlAuthList"
        Me.Size = New System.Drawing.Size(884, 290)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnDelAll As System.Windows.Forms.Button
    Friend WithEvents btnDelSel As System.Windows.Forms.Button
    Friend WithEvents btnAddSel As System.Windows.Forms.Button
    Friend WithEvents btnAddAll As System.Windows.Forms.Button
    Friend WithEvents lstLeftList As System.Windows.Forms.ListBox
    Friend WithEvents lstRightList As System.Windows.Forms.ListBox

End Class
