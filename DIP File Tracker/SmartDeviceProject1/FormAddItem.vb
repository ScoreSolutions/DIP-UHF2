Imports System.Data
Public Class FormAddItem

    Private Sub chkTo_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTo.CheckStateChanged

        txtEnd3.Text = ""
        txtEnd1.Enabled = chkTo.Checked
        txtEnd2.Enabled = chkTo.Checked
        txtEnd3.Enabled = chkTo.Checked

        If chkTo.Checked Then
            txtEnd1.Text = txtStart1.Text
            txtEnd2.Text = txtStart2.Text
            txtEnd3.Focus()
        Else
            txtEnd1.Text = ""
            txtEnd2.Text = ""
        End If

    End Sub


    Private Sub IconAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IconAdd.Click, lnkAdd.Click
        Dim StartID As String = txtStart1.Text & txtStart2.Text & txtStart3.Text
        Dim EndID As String = txtEnd1.Text & txtEnd2.Text & txtEnd3.Text

        '---------------------------------Validate---------------------------------
        If StartID.Length <> 10 Then
            MsgBox("กรอกเลขแฟ้มที่ต้องการค้นหา 10 หลัก")
            Exit Sub
        End If
        For i As Integer = 0 To StartID.Length - 1
            If Asc(StartID.Substring(i, 1)) < Asc("0") Or Asc(StartID.Substring(i, 1)) > Asc("9") Then
                MsgBox("กรอกเลขแฟ้มที่ต้องการค้นหา 10 หลัก")
                Exit Sub
            End If
        Next
        If chkTo.Checked Then
            If EndID.Length <> 10 Then
                MsgBox("กรอกเลขแฟ้มที่ต้องการค้นหา 10 หลัก")
                Exit Sub
            End If
            For i As Integer = 0 To EndID.Length - 1
                If Asc(EndID.Substring(i, 1)) < Asc("0") Or Asc(EndID.Substring(i, 1)) > Asc("9") Then
                    MsgBox("กรอกเลขแฟ้มที่ต้องการค้นหา 10 หลัก")
                    Exit Sub
                End If
            Next
        End If

        Dim StepNext As Integer = +1
        If StartID > EndID Then StepNext = -1

        '-------------Check Add Single File Or Many File------------

        Cursor.Current = Cursors.WaitCursor

        Dim CE As New CEConnection
        Dim SQL As String = ""
        If Not chkTo.Checked Then
            SQL = "SELECT * FROM Job_Desc WHERE APP_NO='" & StartID & "'"
            Dim DT As New DataTable
            DT = CE.SelectData(SQL, LocalConnectionString)
            If DT.Rows.Count = 0 Then
                SQL = "INSERT INTO Job_Desc ( " & vbNewLine
                SQL &= "APP_NO, " & vbNewLine
                SQL &= "APP_NAME, " & vbNewLine
                SQL &= "APP_POSITION, " & vbNewLine
                SQL &= "LOAD_DATETIME, " & vbNewLine
                SQL &= "FIND_STATUS," & vbNewLine
                SQL &= "REF_ID " & vbNewLine
                SQL &= ") VALUES (" & vbNewLine

                SQL &= "'" & StartID & "'," & vbNewLine
                SQL &= "'เพิ่มโดยการกรอกเลข'," & vbNewLine
                SQL &= "''," & vbNewLine
                SQL &= "GETDATE()," & vbNewLine
                SQL &= "0," & vbNewLine
                SQL &= "0" & vbNewLine
                SQL &= ")"
                CE.ExecuteLocalCommand(SQL, LocalConnectionString)
                CE = Nothing

                Cursor.Current = Cursors.Default

                Me.DialogResult = Windows.Forms.DialogResult.Yes
                Me.Close()
            Else
                SQL = "UPDATE Job_Desc set FIND_STATUS=0 WHERE APP_NO='" & StartID & "'"
                CE.ExecuteLocalCommand(SQL, LocalConnectionString)
                CE = Nothing

                Cursor.Current = Cursors.Default

                Me.DialogResult = Windows.Forms.DialogResult.Yes
                Me.Close()
            End If
        Else
            SQL = "SELECT * FROM Job_Desc"
            Dim DT As New DataTable
            DT = CE.SelectData(SQL, LocalConnectionString)
            For i As Integer = StartID To EndID Step StepNext
                DT.DefaultView.RowFilter = "APP_NO='" & i & "'"
                If DT.DefaultView.Count = 0 Then
                    SQL = "INSERT INTO Job_Desc ( " & vbNewLine
                    SQL &= "APP_NO, " & vbNewLine
                    SQL &= "APP_NAME, " & vbNewLine
                    SQL &= "APP_POSITION, " & vbNewLine
                    SQL &= "LOAD_DATETIME, " & vbNewLine
                    SQL &= "FIND_STATUS," & vbNewLine
                    SQL &= "REF_ID " & vbNewLine
                    SQL &= ") VALUES (" & vbNewLine

                    SQL &= "'" & i & "'," & vbNewLine
                    SQL &= "'เพิ่มโดยการกรอกเลข'," & vbNewLine
                    SQL &= "''," & vbNewLine
                    SQL &= "GETDATE()," & vbNewLine
                    SQL &= "0," & vbNewLine
                    SQL &= "0" & vbNewLine
                    SQL &= ")"
                    CE.ExecuteLocalCommand(SQL, LocalConnectionString)
                Else
                    SQL = "UPDATE Job_Desc set FIND_STATUS=0 WHERE APP_NO='" & i & "'"
                    CE.ExecuteLocalCommand(SQL, LocalConnectionString)
                End If
            Next

            Cursor.Current = Cursors.Default

            CE = Nothing
            Me.DialogResult = Windows.Forms.DialogResult.Yes
            Me.Close()
        End If

    End Sub

    Private Sub LinkBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkBack.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    'CE.CreateDataBase(LocalConnectionString)
    'Dim Script As String = "CREATE TABLE Job_Desc(" & vbNewLine
    '            Script &= " [APP_NO] nvarchar(200)," & vbNewLine
    '            Script &= " [APP_NAME] nvarchar(200)," & vbNewLine
    '            Script &= " [APP_POSITION] nvarchar(200)," & vbNewLine
    '            Script &= " [LOAD_DATETIME] float," & vbNewLine
    '            Script &= " [FIND_STATUS] int," & vbNewLine
    '            Script &= " [REF_ID] int" & vbNewLine
    '            Script &= " )" & vbNewLine
    '            CE.ExecuteLocalCommand(Script, LocalConnectionString)

End Class