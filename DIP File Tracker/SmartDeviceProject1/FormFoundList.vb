Imports System.Data
Imports System.Xml
Imports SmartDeviceProject1.CEConnection

Public Class FormFoundList

    Public FoundList As DataTable
    Public JobDetail As DataTable

    Dim SelectionBackColor As Color = Color.Khaki

    Private Sub FormFoundList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LabelHead.Text = "พบ " & FoundList.Rows.Count & " แฟ้ม"
        DisplayList()
    End Sub

    Private Sub DisplayList()

        FoundContainer.Controls.Clear()

        While FoundContainer.Controls.Count > 0
            FoundContainer.Controls(0).Dispose()
        End While

        For i As Integer = 0 To FoundList.Rows.Count - 1
            Dim APP_NO As String = FoundList.Rows(i).Item("APP_NO")
            Dim Item As Panel = CreateFoundItem(i, APP_NO, FoundList.Rows(i).Item("APP_NAME"), FoundList.Rows(i).Item("FOUND_TIME"))
            FoundContainer.Controls.Add(Item)
        Next
    End Sub

    Private Function CreateFoundItem(ByVal PatentIndex As Integer, ByVal PatentCode As String, ByVal PatentName As String, ByVal FoundTime As Double) As Panel

        Dim Job As New Panel
        Job.BackColor = System.Drawing.Color.WhiteSmoke

        '--------PatentCode-------
        '
        Dim lblCode As New LinkLabel
        lblCode.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        lblCode.Location = New System.Drawing.Point(3, 5)
        lblCode.Name = "lblCode"
        lblCode.Size = New System.Drawing.Size(80, 18)
        lblCode.Text = PatentCode
        lblCode.Tag = PatentName


        '--------ปุ่ม--------
        '
        Dim btnOK As New Button
        btnOK.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular)
        'btnOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right
        btnOK.Location = New System.Drawing.Point(112, 3)
        btnOK.Name = "btnOK"
        btnOK.Size = New System.Drawing.Size(96, 22)
        btnOK.Text = "ยืนยันการค้นหา"
        btnOK.Tag = FoundTime
        btnOK.Visible = True

        Job.Controls.Add(lblCode)
        Job.Controls.Add(btnOK)

        AddHandler lblCode.Click, AddressOf SelectJobByChild
        AddHandler Job.Click, AddressOf SelectJobByParent
        AddHandler btnOK.Click, AddressOf ConfirmJob

        'Job.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Job.Size = New System.Drawing.Size(208, 28)
        Job.Location = New System.Drawing.Point(3, (30 * PatentIndex) + 3)
        Job.Name = "Job" & PatentCode

        Return Job
    End Function


    Private Sub SelectJobByChild(ByVal sender As Object, ByVal e As EventArgs)
        Dim Obj As Control = sender
        SelectJobByParent(Obj.Parent, e)
    End Sub

    Private Sub SelectJobByParent(ByVal sender As Object, ByVal e As EventArgs)
        Dim Job As Panel = sender
        Dim lblCode As LinkLabel = Job.Controls(0)
        Dim APP_NAME As String = lblCode.Tag
        Job.BackColor = SelectionBackColor
        MsgBox(APP_NAME)
        Job.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub ConfirmJob(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnOK As Button = sender
        Dim APP_NO As String = btnOK.Parent.Controls(0).Text

        JobDetail.DefaultView.RowFilter = "APP_NO='" & APP_NO & "' AND FIND_STATUS=0"

        FoundList.DefaultView.RowFilter = "APP_NO='" & APP_NO & "' "

        While JobDetail.DefaultView.Count > 0
            JobDetail.DefaultView(0).Row.Item("LOAD_DATETIME") = CDbl(btnOK.Tag)
            JobDetail.DefaultView(0).Row.Item("FIND_STATUS") = 1
        End While

        While FoundList.DefaultView.Count > 0
            FoundList.DefaultView(0).Row.Delete()
            FoundList.AcceptChanges()
        End While

        FoundList.DefaultView.RowFilter = ""
        JobDetail.DefaultView.RowFilter = ""

        If FoundList.Rows.Count = 0 Then
            ButtonBack_Click(Nothing, Nothing)
        End If

        DisplayList()

    End Sub

    Private Sub ButtonBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBack.Click

        Cursor.Current = Cursors.WaitCursor

        Dim CE As New CEConnection
        JobDetail.DefaultView.RowFilter = "FIND_STATUS=1"
        For i As Integer = 0 To JobDetail.DefaultView.Count - 1
            Dim SQL As String
            SQL = "UPDATE Job_Desc set FIND_STATUS=1,LOAD_DATETIME=" & JobDetail.DefaultView(i).Item("LOAD_DATETIME") & " WHERE APP_NO='" & JobDetail.DefaultView(i).Item("APP_NO") & "' AND FIND_STATUS=0"
            CE.ExecuteLocalCommand(SQL, LocalConnectionString)
        Next
        CE = Nothing

        Me.Close()
        FormDisplayJob.Focus()
        Cursor.Current = Cursors.Default
    End Sub
End Class