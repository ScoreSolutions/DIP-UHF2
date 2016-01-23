Imports System.Data
Imports SmartDeviceProject1.CEConnection

Public Class FormDisplayJob

    Dim JobDetail As DataTable
    Dim RFID As New CAEN_READ
    Dim FoundList As DataTable
    Dim Sound As New Sound

    Dim SelectionBackColor As Color = Color.Khaki

    Private ReadOnly Property RFIDStatus() As RFID_STATUS
        Get
            Select Case PanelRFIDStatus.BackColor
                Case Color.Black
                    Return RFID_STATUS.Offline
                Case Color.RoyalBlue
                    Return RFID_STATUS.Searching
                Case Color.Green
                    Return RFID_STATUS.Found
            End Select
        End Get
    End Property

    Private Sub LinkBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkBack.Click, PicBack.Click
        Cursor.Current = Cursors.WaitCursor
        FormDisplayJob_Disposed(Me, e)
        FormLoadChoice.Show()
        FormLoadChoice.Focus()
        FormLoadChoice.BringToFront()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub LinkNext_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub


    Private Function CreateJob(ByVal PatentIndex As Integer, ByVal PatentCode As String, ByVal PatentName As String, ByVal PatentPosition As String, ByVal RefID As Integer) As Panel

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
        '--------ตำแหน่ง--------
        '
        Dim lblHPos As New Label
        lblHPos.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        lblHPos.Location = New System.Drawing.Point(84, 5)
        lblHPos.Name = "lblHPos"
        lblHPos.Size = New System.Drawing.Size(49, 18)
        lblHPos.Text = "ตำแหน่ง"

        '-------Position-------
        Dim lblPos As New Label
        lblPos.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        lblPos.Location = New System.Drawing.Point(139, 5)
        lblPos.Name = "lblPos"
        lblPos.Size = New System.Drawing.Size(41, 18)
        lblPos.Text = PatentPosition


        AddHandler lblCode.Click, AddressOf SelectJobByChild
        AddHandler lblHPos.Click, AddressOf SelectJobByChild
        AddHandler lblPos.Click, AddressOf SelectJobByChild
        AddHandler Job.Click, AddressOf SelectJobByParent

        Job.Size = New System.Drawing.Size(208, 28)
        Job.Location = New System.Drawing.Point(3, (30 * PatentIndex) + 3)
        Job.Name = "Job" & PatentCode
        Job.Visible = True
        Job.Tag = RefID

        Job.Controls.Add(lblCode)
        Job.Controls.Add(lblHPos)
        Job.Controls.Add(lblPos)


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

    Private Sub FormDisplayJob_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed, MyBase.Closing
        On Error Resume Next
        TimerRead.Enabled = False
        Sound.StopSound()
        If Not IsNothing(RFID) Then RFID.Close()
        If Not IsNothing(RFID) Then RFID = Nothing
    End Sub

    Public Sub FormDisplayJob_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DisplayJob()

        'Try To Open
        PicStatusOffline_Click(PicStatusOffline, e)

        JobContainer.Height = Me.Height - 136
        PicBack.Top = Me.Height - 17
        LinkBack.Top = Me.Height - 17
        lnkNext.Top = Me.Height - 17
        PicNext.Top = Me.Height - 17

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub DisplayJob()

        JobContainer.Controls.Clear()

        Dim CE As New CEConnection
        JobDetail = New DataTable
        JobDetail = CE.SelectData("SELECT DISTINCT * FROM Job_Desc WHERE FIND_STATUS=0", LocalConnectionString)
        CE = Nothing

        For i As Integer = 0 To JobDetail.Rows.Count - 1
            Dim APP_NO As String = JobDetail.Rows(i).Item("APP_NO")
            Dim Job As Panel = CreateJob(i, APP_NO, JobDetail.Rows(i).Item("APP_NAME"), JobDetail.Rows(i).Item("APP_POSITION"), JobDetail.Rows(i).Item("REF_ID"))
            JobContainer.Controls.Add(Job)
        Next

        lblHeader.Text = "รายการที่ต้องค้นหา " & JobDetail.Rows.Count & " แฟ้ม"

    End Sub

    Private Enum RFID_STATUS
        Offline = 0
        Searching = 1
        Found = 2
    End Enum

    Private Sub SetRFIDStatus(ByVal Status As RFID_STATUS, ByVal Text1 As String, ByVal Text2 As String)
        Select Case Status
            Case RFID_STATUS.Offline
                PanelRFIDStatus.BackColor = Color.Black
                PicStatusOffline.Visible = True
                PicStatusSearch.Visible = False
                PicStatusFound.Visible = False
            Case RFID_STATUS.Searching
                PanelRFIDStatus.BackColor = Color.RoyalBlue
                PicStatusOffline.Visible = False
                PicStatusSearch.Visible = True
                PicStatusFound.Visible = False
            Case RFID_STATUS.Found
                PanelRFIDStatus.BackColor = Color.Green
                PicStatusOffline.Visible = False
                PicStatusSearch.Visible = False
                PicStatusFound.Visible = True
        End Select

        lblText1.BackColor = PanelRFIDStatus.BackColor
        lblText2.BackColor = PanelRFIDStatus.BackColor
        lblText1.Text = Text1
        lblText2.Text = Text2
        lblText1.Refresh()
        lblText2.Refresh()

        '----------- Change Icon-----------
    End Sub


    Private Sub PicStatusFound_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicStatusFound.Click
        Dim F As New FormFoundList
        F.FoundList = FoundList
        F.JobDetail = JobDetail

        FormDisplayJob_Disposed(Me, e)
        SetRFIDStatus(RFID_STATUS.Offline, "Disconnected", "")
        TimerRead.Enabled = False
        F.ShowDialog()
        FormDisplayJob_Load(Me, e)
    End Sub

    Private Sub PicStatusOffline_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicStatusOffline.Click
        Cursor.Current = Cursors.WaitCursor

        SetRFIDStatus(RFID_STATUS.Offline, "Connecting RFID", "")
        TimerRead.Enabled = False

        Try
            RFID.Close()
        Catch ex As Exception
        End Try
        If IsNothing(RFID) Then
            RFID = New CAEN_READ
        End If

        Dim OpenResult As CAEN_READ.RFID_STATUS = RFID.Open()
        If Not OpenResult.Available Then
            SetRFIDStatus(RFID_STATUS.Offline, "Disconnected", OpenResult.Detail)
            TimerRead.Enabled = False
        Else
            SetRFIDStatus(RFID_STATUS.Searching, "Searching", "")
            TimerRead.Enabled = True
            '---------- Reset Found List---------
            CreateFoundList()
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub lnkNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkNext.Click, PicNext.Click
        Dim F As New FormAddItem
        If Not F.ShowDialog Then Exit Sub
        FormDisplayJob_Load(Me, Nothing)
    End Sub

    Private Sub CreateFoundList()
        Dim DT As New DataTable
        DT.Columns.Add("APP_NO", GetType(String))
        DT.Columns.Add("APP_NAME", GetType(String))
        DT.Columns.Add("FOUND_TIME", GetType(Double)) '------ Collect OADate-------
        FoundList = DT
    End Sub

    Private Sub TimerRead_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerRead.Tick

        '-----------------Remove Expire Time/Create New List----------------
        If IsNothing(FoundList) Then
            CreateFoundList()
        Else
            Dim ExpiredTime As Double = DateAdd(DateInterval.Second, -5, Now).ToOADate
            FoundList.DefaultView.RowFilter = "FOUND_TIME>" & ExpiredTime
            FoundList = FoundList.DefaultView.ToTable
        End If
       
        Dim Result As New CAEN_READ.RFID_STATUS
        '------------------- Start Read --------------------
        Result = RFID.Read()

        If Not IsNothing(Result.Tags) AndAlso Result.Tags.Length > 0 Then

            Dim FoundItems As Integer = 0

            For Each tag As com.caen.RFIDLibrary.CAENRFIDTag In Result.Tags

                Dim IDTag As String = System.BitConverter.ToString(tag.GetId()).Replace("-", "")

                Dim App_No As String = IDTag
                '-------------------------Hard Code For Testing Read Tag-----------------
                'Select Case IDTag
                '    Case "BFD790099011900100000C45"
                '        App_No = "0001000244"
                '    Case "026030101122001A00000C31"
                '        App_No = "0001000016"
                '    Case "9BAD00000022224400000C3E"
                '        App_No = "0001000011"
                '    Case "D17230109001900100000C66"
                '        App_No = "0001000015"
                '    Case "026030100000001A00000C52"
                '        App_No = "0101001799"
                '    Case "026030100000001A00000C2A"
                '        App_No = "0101001803"
                '    Case "00AA30100000001A00000C81"
                '        App_No = "0201003061"
                '    Case "6CCE30100000001A00000C6D"
                '        App_No = "0301003563"
                '    Case "026030100000001A00000C7A"
                '        App_No = "0201003058"

                'End Select
                Try
                    App_No = Mid(App_No, 1, 10)
                Catch ex As Exception
                End Try
                '-------------------------Hard Code For Testing Read Tag-----------------

                '--------------- Check Exists App_No------------ 
                FoundList.DefaultView.RowFilter = "APP_NO='" & App_No & "'"
                JobDetail.DefaultView.RowFilter = "APP_NO='" & App_No & "' AND FIND_STATUS=0"
                '---------------If Not Exists Then -------------
                If JobDetail.DefaultView.Count > 0 Then
                    FoundItems += 1
                    If FoundList.DefaultView.Count = 0 Then
                        Dim DR As DataRow = FoundList.NewRow
                        DR("APP_NO") = App_No
                        DR("APP_NAME") = JobDetail.DefaultView(0).Item("APP_NAME")
                        DR("FOUND_TIME") = Now.ToOADate
                        FoundList.Rows.Add(DR)
                    End If
                End If
            Next
            '------------- Clear Status
            FoundList.DefaultView.RowFilter = ""
            JobDetail.DefaultView.RowFilter = ""
            If FoundItems > 0 Then
                SetRFIDStatus(RFID_STATUS.Found, "FOUND !!", FoundItems & " files")
                If Not Sound.NowPlaying Then
                    'Sound.Play(ApplicationPath() & "\Found.wav", True)
                    Sound.Play("\Windows\Ring.wav", True)
                End If
            Else
                If Sound.NowPlaying Then
                    Sound.StopSound()
                End If
                SetRFIDStatus(RFID_STATUS.Searching, "Searching", "")
            End If
        Else
            If Sound.NowPlaying Then
                Sound.StopSound()
            End If
            SetRFIDStatus(RFID_STATUS.Searching, "Searching", "")
        End If
    End Sub

    Private Sub PanelRFIDStatus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelRFIDStatus.Click, PicStatusSearch.Click
        Select Case Me.RFIDStatus
            Case RFID_STATUS.Offline
                PicStatusOffline_Click(sender, e)
            Case RFID_STATUS.Searching
                If Not IsNothing(FoundList) AndAlso FoundList.Rows.Count > 0 Then
                    PicStatusFound_Click(sender, e)
                End If
            Case RFID_STATUS.Found
                PicStatusFound_Click(sender, e)
        End Select
    End Sub
End Class