Option Explicit On


Imports System.Data
Imports System.Data.SqlClient
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.Data.Table
Imports DIP_RFID.DAL.Common.Utilities
Imports OpenNETCF.Desktop.Communication
Imports System.IO
Imports System.Threading
Imports System.Text


Public Class frmMobile

    Public Enum TASK_TYPE
        Import = 1
        Export = 2
    End Enum

    Public Enum FIND_STATUS
        NotFound = 0
        Found = 1
        Post = 2
    End Enum

    Public Property SyncFor() As TASK_TYPE
        Get
            Select Case True
                Case RadioTask1.Checked
                    Return TASK_TYPE.Export
                Case RadioTask2.Checked
                    Return TASK_TYPE.Import
            End Select
        End Get
        Set(ByVal value As TASK_TYPE)
            Select Case value
                Case TASK_TYPE.Export
                    RadioTask1.Checked = True
                Case TASK_TYPE.Import
                    RadioTask2.Checked = True
            End Select
        End Set
    End Property

    Public ReadOnly Property DeviceName() As String
        Get
            Return Trim(ddlMobileList.Text)
        End Get
    End Property
    Dim _DataFloormove As DataTable
    Public Property DataFloormove() As DataTable
        Get
            Return _DataFloormove
        End Get
        Set(ByVal value As DataTable)
            _DataFloormove = value
        End Set
    End Property

    Dim _FileBorrowList As DataTable
    Public Property FileBorrowList() As DataTable
        Get
            Return _FileBorrowList
        End Get
        Set(ByVal value As DataTable)
            _FileBorrowList = value
        End Set
    End Property

    Dim _FileLastLocation As DataTable
    Public Property FileLastLocation() As DataTable
        Get
            Return _FileLastLocation
        End Get
        Set(ByVal value As DataTable)
            _FileLastLocation = value
        End Set
    End Property

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub frmMobile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'RadioTask1.Checked = True
        'Hide Tab Interface
        TabMain.Top = -22
        Me.Height = 385

        'Clear Form
        ResetForm()

    End Sub

    Private Sub ResetForm()

        'Get Device_Name
        ddlMobileList.Items.Clear()
        Dim Devices() As String = GetDeviceNames()
        For i = 0 To Devices.Length - 1
            ddlMobileList.Items.Add(Devices(i))
        Next
        ddlMobileList.SelectedIndex = 0

    End Sub


    Public ExportList As DataTable

    Private Function GenerateExportList() As DataTable

        If Not IsNothing(ExportList) Then

            ExportList.TableName = "Export"
            Return ExportList
        Else
            Dim DT As New DataTable
            DT.Columns.Add("APP_NO") '------------รหัส Patent----------
            DT.Columns.Add("APP_NAME") '--------------ชื่อ Patent---------
            DT.Columns.Add("APP_POSITION") '-------------ตำแหน่งที่เก็บ-------------
            DT.Columns.Add("LOAD_DATETIME") '----------เวลาที่ Load เข้า -----------
            DT.Columns.Add("FIND_STATUS") '0 = Not found , 1 = Found , 2 = Post
            '---------Additional From Joining  Table---------

            DT.TableName = "Export"
            Return DT
        End If
    End Function

    Private Function GetDeviceNames() As String() 'Get List Of Device Name Array-------------------------------
        Dim Temp As String = ""
        Dim i As Integer

        ' Dim F As FileIO
        Dim MyDocPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim IndexOfLastBackSlash As Integer = InStrRev(FileIO.FileSystem.GetDirectories(MyDocPath).Item(0), "\")
        For i = 0 To FileIO.FileSystem.GetDirectories(MyDocPath).Count - 1
            Dim TempFolderName As String = FileIO.FileSystem.GetDirectories(MyDocPath).Item(i)
            '"My Documents"
            TempFolderName = Mid(TempFolderName, IndexOfLastBackSlash + 1)
            If InStr(TempFolderName, "My Documents") > 0 Then
                ' Shift Another One Element Dimention
                Temp &= Trim(Mid(TempFolderName, 1, InStr(TempFolderName, "My Documents") - 1) & "\")
            ElseIf InStr(TempFolderName, "Documents on ") = 1 And InStr(TempFolderName, "'s Device") > 0 Then
                'Documents on xXx's Device
                Dim _tmp As String = TempFolderName.Replace("Documents on ", "")
                _tmp = _tmp.Substring(0, Len(_tmp) - Len("'s Device"))
                Temp &= Trim(_tmp) & "\"
            ElseIf InStr(TempFolderName, "Documents on ") = 1 Then
                'Documents on xXx
                Dim _tmp As String = TempFolderName.Replace("Documents on ", "")
                Temp &= Trim(_tmp) & "\"
            End If
        Next

        If Len(Temp) > 0 Then Temp = Mid(Temp, 1, Len(Temp) - 1)

        'Optimize New Returned Array
        GetDeviceNames = Split(Temp, "\")

    End Function

    

    Private Sub ButtonNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNext.Click
        If Not RadioTask1.Checked And Not RadioTask2.Checked Then
            MsgBox("คุณต้องการที่จะ....") 'คุณต้องการที่จะ
            Exit Sub
        End If
        If DeviceName = "" Then
            MsgBox("เลือกอุปกรณ์....")
            Exit Sub
        End If

        Select Case True
            Case RadioTask1.Checked
                If frmMain.txtDocumentEvent.Text.ToLower = "floormove" Then
                    Do_Export_Floormove()
                ElseIf frmMain.txtDocumentEvent.Text = "frmBorrowToHandheld" Then
                    Do_Export_FileBorrowData()
                ElseIf frmMain.txtDocumentEvent.Text = "frmFileLastLocation" Then
                    Do_Export_FileLastLocationData()
                Else
                    Do_Export()
                End If

                'Do_Export_FileLost(DeviceName)
            Case RadioTask2.Checked
                If frmMain.txtDocumentEvent.Text.ToLower = "floorcount" Then
                    Do_Import_Floorcount()
                ElseIf frmMain.txtDocumentEvent.Text.ToLower = "floormove" Then
                    Do_Import_Floormove()
                ElseIf frmMain.txtDocumentEvent.Text = "frmBorrowToHandheld" Then
                    Do_Import_FileBorrowDeliver()
                Else
                    Do_Import()
                End If

                'Do_Export_FileLost(DeviceName)
                Do_Import_FileDiscover()
        End Select

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackEF.Click, btnBackIF.Click
        TabMain.SelectedTab = TabSelection
    End Sub

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinishEF.Click, btnFinishIF.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

#Region "Export Offline"

    Private Sub Do_Export()

        '-------------------------------Clear All Status'-------------------------------
        LabelExOfStep1.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelExOfStep2.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelExOfStep3.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelExOfStep4.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        LabelExOfStep1.ForeColor = Color.Gray
        LabelExOfStep2.ForeColor = Color.Gray
        LabelExOfStep3.ForeColor = Color.Gray
        LabelExOfStep4.ForeColor = Color.Gray

        IconExOfStep1.BackColor = Color.WhiteSmoke
        IconExOfStep2.BackColor = Color.WhiteSmoke
        IconExOfStep3.BackColor = Color.WhiteSmoke
        IconExOfStep4.BackColor = Color.WhiteSmoke

        txtQtyExOf.Clear()

        lblHeader_ExOf.Text = "ส่งออกไปยัง " & DeviceName & " ..." 'ส่งออกไปยัง

        btnCancelEF.Enabled = True
        btnBackEF.Enabled = False
        btnFinishEF.Enabled = False

        TabMain.SelectedTab = TabExportOffline

        '-------------------------------Step 1 Check Environment-------------------------------
        LabelExOfStep1.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))

        Dim MyDocPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ' Dim FilePath As String = MyDocPath & "\" & DeviceName & " My Documents"
        Dim FilePath As String = MyDocPath & "\Documents on " & DeviceName
        If Not Directory.Exists(Application.StartupPath) Then
            Directory.CreateDirectory(Application.StartupPath)
            'Documents on xXx's Device
            'Temp = TempFolderName.Replace("Documents on ", "")
            'Temp = Temp.Substring(0, Len(Temp) - Len("'s Device"))
            ' FilePath = MyDocPath & "\Documents on " & DeviceName & "'s Device"
            'If Not Directory.Exists(FilePath) Then
            '    MsgBox("ไม่พบ Directory ที่ต้องการส่งออก" & vbNewLine & "กรุณาตรวจสอบอีกครั้ง")

            '    '-------------- Display Error -------------
            '    LabelExOfStep1.ForeColor = Color.Red
            '    IconExOfStep1.BackColor = Color.Red
            '    StopExport(Nothing, Nothing)
            '    Exit Sub
            'End If
        End If

        If Not btnCancelEF.Enabled Then Exit Sub '----------Check Cancel Requested--------

        LabelExOfStep1.ForeColor = Color.Green
        IconExOfStep1.BackColor = Color.GreenYellow

        '-------------------------------Step 2 Retrieve Data To Export-------------------------
        LabelExOfStep2.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Dim DT As DataTable
        Try
            DT = GenerateExportList().Copy

            DT.Columns.Add("REF_ID")

            Dim trans As New SqlTransactionDB
            trans.CreateTransaction()
            Dim ret As Boolean = False
            Dim ErrMessage As String = ""
            'ref_id
            For i As Integer = 0 To DT.Rows.Count - 1
                Dim dal As New TbFindHHTDAL
                dal.APP_NO = DT.Rows(i).Item("APP_NO")
                dal.LOAD_DATETIME = Now
                dal.LOAD_TYPE = "U"
                dal.FIND_STATUS = "N"

                ret = dal.InsertData(frmMain.txtUserName.Text, trans.Trans)

                If Not ret Then
                    ErrMessage = dal.ErrorMessage
                    StopExport(Nothing, Nothing)
                    Exit For
                Else
                    DT.Rows(i).Item("REF_ID") = dal.ID
                End If
            Next

            If ret Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                MsgBox(ErrMessage)
                LabelExOfStep2.Text = "ไม่สามารถเตรียมข้อมูลได้" 'ไม่สามารถเตรียมข้อมูลได้
                LabelExOfStep2.ForeColor = Color.Red
                IconExOfStep2.BackColor = Color.Red
                Exit Sub
            End If


        Catch ex As Exception

            '-------------- Display Error -------------
            LabelExOfStep2.ForeColor = Color.Red
            IconExOfStep2.BackColor = Color.Red
            StopExport(Nothing, Nothing)
            MsgBox(ex.Message)
            Exit Sub

        End Try

        '###เพิ่มการ Copy file To Device#######
        'If File.Exists(FilePath & "\DIPExport.txt") Then File.Delete(Application.StartupPath & "\DIPExport.txt")
        'Dim objWriter As New System.IO.StreamWriter(Application.StartupPath & "\DIPExport.txt", True)
        If File.Exists(Application.StartupPath & "\DIPCheckOut.txt") Then File.Delete(Application.StartupPath & "\DIPCheckOut.txt")
        Dim objWriter As New System.IO.StreamWriter(Application.StartupPath & "\DIPCheckOut.txt", True)
        Dim strText As New StringBuilder
        For i As Integer = 0 To DT.Rows.Count - 1
            'strText.Append(DAL.Common.Utilities.Func.strToHex(DT.Rows(i)("APP_NO")))
            strText.Append(DT.Rows(i)("APP_NO"))
            strText.AppendLine()
        Next

        objWriter.Write(strText.ToString)
        objWriter.Close()

        Try
            Dim rapi As New RAPI
            If rapi.DevicePresent Then
                'If rapi.DeviceFileExists("\My Documents\DIPExport.txt") Then
                '    rapi.DeleteDeviceFile("\My Documents\DIPExport.txt")
                'End If
                rapi.Connect()
                rapi.CopyFileToDevice(Application.StartupPath & "\DIPCheckOut.txt", "\My Documents\DIPCheckOut.txt", True)
                ' rapi.CopyFileToDevice(Application.StartupPath & "\ApplicationType.txt", "\My Documents\ApplicationType.txt", True)
                rapi.Disconnect()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        '#################################

        txtQtyExOf.Text = FormatNumber(DT.Rows.Count, 0)

        If Not btnCancelEF.Enabled Then Exit Sub '----------Check Cancel Requested--------

        LabelExOfStep2.ForeColor = Color.Green
        IconExOfStep2.BackColor = Color.GreenYellow

        '-------------------------------Step 3 Write Text File-------------------------------
        LabelExOfStep3.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))

        Dim FileName As String = Application.StartupPath & "\DIPExport.dat"
        Try

            If File.Exists(FileName) Then File.Delete(FileName)
            Dim DS As New DataSet("DIP")
            DS.Tables.Add(DT)
            DS.WriteXml(FileName)


        Catch ex As Exception

            '-------------- Display Error -------------
            LabelExOfStep3.ForeColor = Color.Red
            IconExOfStep3.BackColor = Color.Red
            StopExport(Nothing, Nothing)
            MsgBox(ex.Message)
            Exit Sub

        End Try

        If Not btnCancelEF.Enabled Then Exit Sub '----------Check Cancel Requested--------

        LabelExOfStep3.ForeColor = Color.Green
        IconExOfStep3.BackColor = Color.GreenYellow

        '-------------------------------Step 4 Wait For Syncronize----------------------------
        LabelExOfStep4.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        WaitCount = 0
        TimerWait.Enabled = True
        '-------------------------------Finish-----------------------------------------

        MsgBox("บันทึกข้อมูลสู่อุปกรณ์ต่อพ่วงสำเร็จ") 'บันทึกข้อมูลสู่อุปกรณ์ต่อพ่วงสำเร็จ

    End Sub

    Private Sub Do_Export_Floormove()
        '-------------------------------Clear All Status'-------------------------------
        LabelExOfStep1.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelExOfStep2.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelExOfStep3.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelExOfStep4.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        LabelExOfStep1.ForeColor = Color.Gray
        LabelExOfStep2.ForeColor = Color.Gray
        LabelExOfStep3.ForeColor = Color.Gray
        LabelExOfStep4.ForeColor = Color.Gray

        IconExOfStep1.BackColor = Color.WhiteSmoke
        IconExOfStep2.BackColor = Color.WhiteSmoke
        IconExOfStep3.BackColor = Color.WhiteSmoke
        IconExOfStep4.BackColor = Color.WhiteSmoke

        txtQtyExOf.Clear()

        lblHeader_ExOf.Text = "ส่งออกไปยัง " & DeviceName & " ..." 'ส่งออกไปยัง

        btnCancelEF.Enabled = True
        btnBackEF.Enabled = False
        btnFinishEF.Enabled = False

        TabMain.SelectedTab = TabExportOffline

        '-------------------------------Step 1 Check Environment-------------------------------
        LabelExOfStep1.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))

        Dim MyDocPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ' Dim FilePath As String = MyDocPath & "\" & DeviceName & " My Documents"
        Dim FilePath As String = MyDocPath & "\Documents on " & DeviceName
        If Not Directory.Exists(Application.StartupPath) Then
            Directory.CreateDirectory(Application.StartupPath)
        End If

        If Not btnCancelEF.Enabled Then Exit Sub '----------Check Cancel Requested--------

        LabelExOfStep1.ForeColor = Color.Green
        IconExOfStep1.BackColor = Color.GreenYellow

        '-------------------------------Step 2 Retrieve Data To Export-------------------------
        LabelExOfStep2.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Dim DT As DataTable = DataFloormove


        '###เพิ่มการ Copy file To Device#######
        If File.Exists(Application.StartupPath & "\DIPMoveOut.txt") Then File.Delete(Application.StartupPath & "\DIPMoveOut.txt")
        Dim objWriter As New System.IO.StreamWriter(Application.StartupPath & "\DIPMoveOut.txt", True)
        Dim strText As New StringBuilder
        For i As Integer = 0 To DT.Rows.Count - 1
            'strText.Append(DAL.Common.Utilities.Func.strToHex(DT.Rows(i)("APP_NO")))
            strText.Append(DT.Rows(i)("APP_NO"))
            strText.AppendLine()
        Next

        objWriter.Write(strText.ToString)
        objWriter.Close()

        Try
            Dim rapi As New RAPI
            If rapi.DevicePresent Then
                'If rapi.DeviceFileExists("\My Documents\DIPExport.txt") Then
                '    rapi.DeleteDeviceFile("\My Documents\DIPExport.txt")
                'End If
                rapi.Connect()
                rapi.CopyFileToDevice(Application.StartupPath & "\DIPMoveOut.txt", "\My Documents\DIPMoveOut.txt", True)
                ' rapi.CopyFileToDevice(Application.StartupPath & "\ApplicationType.txt", "\My Documents\ApplicationType.txt", True)
                rapi.Disconnect()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        '#################################

        txtQtyExOf.Text = FormatNumber(DT.Rows.Count, 0)

        If Not btnCancelEF.Enabled Then Exit Sub '----------Check Cancel Requested--------

        LabelExOfStep2.ForeColor = Color.Green
        IconExOfStep2.BackColor = Color.GreenYellow

        '-------------------------------Step 3 Write Text File-------------------------------
        LabelExOfStep3.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))

        'Dim FileName As String = Application.StartupPath & "\DIPExport.dat"
        'Try

        '    If File.Exists(FileName) Then File.Delete(FileName)
        '    Dim DS As New DataSet("DIP")
        '    DS.Tables.Add(DT)
        '    DS.WriteXml(FileName)


        'Catch ex As Exception

        '    '-------------- Display Error -------------
        '    LabelExOfStep3.ForeColor = Color.Red
        '    IconExOfStep3.BackColor = Color.Red
        '    StopExport(Nothing, Nothing)
        '    MsgBox(ex.Message)
        '    Exit Sub

        'End Try

        If Not btnCancelEF.Enabled Then Exit Sub '----------Check Cancel Requested--------

        LabelExOfStep3.ForeColor = Color.Green
        IconExOfStep3.BackColor = Color.GreenYellow

        '-------------------------------Step 4 Wait For Syncronize----------------------------
        LabelExOfStep4.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        WaitCount = 0
        TimerWait.Enabled = True
        '-------------------------------Finish-----------------------------------------

        MsgBox("บันทึกข้อมูลสู่อุปกรณ์ต่อพ่วงสำเร็จ") 'บันทึกข้อมูลสู่อุปกรณ์ต่อพ่วงสำเร็จ

    End Sub


    Private Function CreateImageBorrowername(ByVal PathFile As String, ByVal BorrowerName As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim bm As New Bitmap(180, 20)
            Dim g As Graphics = Graphics.FromImage(bm)
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault
            g.Clear(Color.White)
            g.DrawString(BorrowerName, New Font("Tahoma", 10, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 1, 0)

            If File.Exists(PathFile) = True Then
                Try
                    File.SetAttributes(PathFile, FileAttributes.Normal)
                    File.Delete(PathFile)
                Catch ex As Exception

                End Try
            End If

            bm.Save(PathFile, Imaging.ImageFormat.Jpeg)
            bm.Dispose()
            g.Dispose()

            ret = True
        Catch ex As Exception
            ret = False
        End Try
        
        Return ret
    End Function

    Private Sub Do_Export_FileBorrowData()
        '-------------------------------Clear All Status'-------------------------------
        LabelExOfStep1.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelExOfStep2.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelExOfStep3.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelExOfStep4.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        LabelExOfStep1.ForeColor = Color.Gray
        LabelExOfStep2.ForeColor = Color.Gray
        LabelExOfStep3.ForeColor = Color.Gray
        LabelExOfStep4.ForeColor = Color.Gray

        IconExOfStep1.BackColor = Color.WhiteSmoke
        IconExOfStep2.BackColor = Color.WhiteSmoke
        IconExOfStep3.BackColor = Color.WhiteSmoke
        IconExOfStep4.BackColor = Color.WhiteSmoke

        txtQtyExOf.Clear()

        lblHeader_ExOf.Text = "ส่งออกไปยัง " & DeviceName & " ..." 'ส่งออกไปยัง

        btnCancelEF.Enabled = True
        btnBackEF.Enabled = False
        btnFinishEF.Enabled = False

        TabMain.SelectedTab = TabExportOffline

        '-------------------------------Step 1 Check Environment-------------------------------
        LabelExOfStep1.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))

        Dim MyDocPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim FilePath As String = MyDocPath & "\Documents on " & DeviceName
        If Not Directory.Exists(Application.StartupPath) Then
            Directory.CreateDirectory(Application.StartupPath)
        End If

        If Not btnCancelEF.Enabled Then Exit Sub '----------Check Cancel Requested--------

        LabelExOfStep1.ForeColor = Color.Green
        IconExOfStep1.BackColor = Color.GreenYellow

        '-------------------------------Step 2 Retrieve Data To Export-------------------------
        LabelExOfStep2.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Dim DT As DataTable = FileBorrowList


        '###เพิ่มการ Copy file To Device#######
        If File.Exists(Application.StartupPath & "\FileBorrowList.txt") Then File.Delete(Application.StartupPath & "\FileBorrowList.txt")

        Dim FileBorrowerName As String = Application.StartupPath & "\FileBorrowerName"
        If Directory.Exists(FileBorrowerName) = True Then
            Try
                Directory.Delete(FileBorrowerName, True)
                Directory.CreateDirectory(FileBorrowerName)
            Catch ex As Exception

            End Try
        Else
            Try
                Directory.CreateDirectory(FileBorrowerName)
            Catch ex As Exception

            End Try
        End If


        Dim objWriter As New System.IO.StreamWriter(Application.StartupPath & "\FileBorrowList.txt", True)
        Dim strText As New StringBuilder
        For i As Integer = 0 To DT.Rows.Count - 1
            strText.Append(DT.Rows(i)("fileborrow_code") & "|")
            strText.Append(Convert.ToDateTime(DT.Rows(i)("borrowerdate")).ToString("yyyy-MM-dd HH:mm", New Globalization.CultureInfo("en-US")) & "|")
            strText.Append(DT.Rows(i)("tag_list") & "|")
            strText.AppendLine()

            CreateImageBorrowername(FileBorrowerName & "\" & DT.Rows(i)("fileborrow_code") & ".jpg", DT.Rows(i)("borrowername"))
        Next
        objWriter.Write(strText.ToString)
        objWriter.Close()

        Try
            Dim rapi As New RAPI
            If rapi.DevicePresent Then
                rapi.Connect()
                rapi.CopyFileToDevice(Application.StartupPath & "\FileBorrowList.txt", "\My Documents\FileBorrowList.txt", True)

                Try
                    rapi.RemoveDeviceDirectory("\My Documents\FileBorrowerName", True)
                Catch ex As Exception

                End Try

                rapi.CreateDeviceDirectory("\My Documents\FileBorrowerName")
                If Directory.Exists(FileBorrowerName) = True Then
                    For Each f As String In Directory.GetFiles(FileBorrowerName)
                        Dim fInfo As New FileInfo(f)
                        rapi.CopyFileToDevice(f, "\My Documents\FileBorrowerName\" & fInfo.Name, True)
                    Next
                End If

                rapi.Disconnect()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        '#################################

        txtQtyExOf.Text = FormatNumber(DT.Rows.Count, 0)

        If Not btnCancelEF.Enabled Then Exit Sub '----------Check Cancel Requested--------

        LabelExOfStep2.ForeColor = Color.Green
        IconExOfStep2.BackColor = Color.GreenYellow

        '-------------------------------Step 3 Wait For Syncronize-------------------------------
        

        If Not btnCancelEF.Enabled Then Exit Sub '----------Check Cancel Requested--------

        LabelExOfStep3.ForeColor = Color.Green
        IconExOfStep3.BackColor = Color.GreenYellow

        '-------------------------------Step 4 Delete Temp File----------------------------
        Try
            If Directory.Exists(FileBorrowerName) = True Then
                Directory.Delete(FileBorrowerName, True)
            End If
            If File.Exists(Application.StartupPath & "\FileBorrowList.txt") = True Then
                File.Delete(Application.StartupPath & "\FileBorrowList.txt")
            End If

        Catch ex As Exception
            MsgBox(ex)
            LabelImOfStep4.Text = "ไม่สามารถลบ File ได้"
            LabelImOfStep4.ForeColor = Color.Red
            IconImOfStep4.BackColor = Color.Red
            Exit Sub
        End Try


        LabelExOfStep4.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        WaitCount = 0
        TimerWait.Enabled = True
        '-------------------------------Finish-----------------------------------------

        MsgBox("บันทึกข้อมูลสู่อุปกรณ์ต่อพ่วงสำเร็จ") 'บันทึกข้อมูลสู่อุปกรณ์ต่อพ่วงสำเร็จ
    End Sub

    Private Sub Do_Export_FileLastLocationData()
        'ข้อมูล Location ของแฟ้มในแต่ละชั้น
        '-------------------------------Clear All Status'-------------------------------
        LabelExOfStep1.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelExOfStep2.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelExOfStep3.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelExOfStep4.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        LabelExOfStep1.ForeColor = Color.Gray
        LabelExOfStep2.ForeColor = Color.Gray
        LabelExOfStep3.ForeColor = Color.Gray
        LabelExOfStep4.ForeColor = Color.Gray

        IconExOfStep1.BackColor = Color.WhiteSmoke
        IconExOfStep2.BackColor = Color.WhiteSmoke
        IconExOfStep3.BackColor = Color.WhiteSmoke
        IconExOfStep4.BackColor = Color.WhiteSmoke

        txtQtyExOf.Clear()

        lblHeader_ExOf.Text = "ส่งออกไปยัง " & DeviceName & " ..." 'ส่งออกไปยัง

        btnCancelEF.Enabled = True
        btnBackEF.Enabled = False
        btnFinishEF.Enabled = False

        TabMain.SelectedTab = TabExportOffline

        '-------------------------------Step 1 Check Environment-------------------------------
        LabelExOfStep1.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))

        Dim MyDocPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim FilePath As String = MyDocPath & "\Documents on " & DeviceName
        If Not Directory.Exists(Application.StartupPath) Then
            Directory.CreateDirectory(Application.StartupPath)
        End If

        If Not btnCancelEF.Enabled Then Exit Sub '----------Check Cancel Requested--------

        LabelExOfStep1.ForeColor = Color.Green
        IconExOfStep1.BackColor = Color.GreenYellow

        '-------------------------------Step 2 Retrieve Data To Export-------------------------
        LabelExOfStep2.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Dim DT As DataTable = FileLastLocation

        '###เพิ่มการ Copy file To Device#######
        If File.Exists(Application.StartupPath & "\FileLastLocationList.txt") Then File.Delete(Application.StartupPath & "\FileLastLocationList.txt")

        Dim objWriter As New System.IO.StreamWriter(Application.StartupPath & "\FileLastLocationList.txt", True)
        Dim strText As New StringBuilder
        For i As Integer = 0 To DT.Rows.Count - 1
            strText.Append(DT.Rows(i)("borrowername") & "|")
            strText.Append(Convert.ToDateTime(DT.Rows(i)("borrowerdate")).ToString("yyyy-MM-dd HH:mm", New Globalization.CultureInfo("en-US")) & "|")
            strText.Append(DT.Rows(i)("fileborrow_code") & "|")
            strText.Append(DT.Rows(i)("app_no") & "|")
            strText.Append(DT.Rows(i)("location_name") & "|")
            strText.AppendLine()
        Next
        objWriter.Write(strText.ToString)
        objWriter.Close()

        Try
            Dim rapi As New RAPI
            If rapi.DevicePresent Then
                rapi.Connect()
                rapi.CopyFileToDevice(Application.StartupPath & "\FileLastLocationList.txt", "\My Documents\FileLastLocationList.txt", True)
                rapi.Disconnect()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        '#################################

        txtQtyExOf.Text = FormatNumber(DT.Rows.Count, 0)

        If Not btnCancelEF.Enabled Then Exit Sub '----------Check Cancel Requested--------

        LabelExOfStep2.ForeColor = Color.Green
        IconExOfStep2.BackColor = Color.GreenYellow

        '-------------------------------Step 3 Wait For Syncronize-------------------------------
        If Not btnCancelEF.Enabled Then Exit Sub '----------Check Cancel Requested--------

        LabelExOfStep3.ForeColor = Color.Green
        IconExOfStep3.BackColor = Color.GreenYellow

        '-------------------------------Step 4 Delete Temp File----------------------------
        Try
            If File.Exists(Application.StartupPath & "\FileLastLocationList.txt") = True Then
                File.Delete(Application.StartupPath & "\FileLastLocationList.txt")
            End If

        Catch ex As Exception
            MsgBox(ex)
            LabelImOfStep4.Text = "ไม่สามารถลบ File ได้"
            LabelImOfStep4.ForeColor = Color.Red
            IconImOfStep4.BackColor = Color.Red
            Exit Sub
        End Try

        LabelExOfStep4.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        WaitCount = 0
        TimerWait.Enabled = True
        '-------------------------------Finish-----------------------------------------

        MsgBox("บันทึกข้อมูลสู่อุปกรณ์ต่อพ่วงสำเร็จ") 'บันทึกข้อมูลสู่อุปกรณ์ต่อพ่วงสำเร็จ
    End Sub



    Private Function SetRFIDTAG(ByVal APP_NO As String)
        Dim dt As DataTable = SqlDB.ExecuteTable("SELECT APP_NO FROM TB_REQUISTION WHERE  APP_NO='" & APP_NO & "'")
        If dt.Rows.Count > 0 Then
            Return dt(0)("TAGRFID")
        Else
            Return ""
        End If
    End Function



    Private Sub StopExport(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelEF.Click
        btnCancelEF.Enabled = False
        btnBackEF.Enabled = True
        btnFinishEF.Enabled = True
    End Sub

#End Region

#Region "Import"
    Private Sub Do_Import_FileBorrowDeliver()
        '-------------------------------Clear All Status'-------------------------------
        LabelImOfStep1.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelImOfStep2.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelImOfStep3.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelImOfStep4.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        LabelImOfStep1.ForeColor = Color.Gray
        LabelImOfStep2.ForeColor = Color.Gray
        LabelImOfStep3.ForeColor = Color.Gray
        LabelImOfStep4.ForeColor = Color.Gray

        IconImOfStep1.BackColor = Color.WhiteSmoke
        IconImOfStep2.BackColor = Color.WhiteSmoke
        IconImOfStep3.BackColor = Color.WhiteSmoke
        IconImOfStep4.BackColor = Color.WhiteSmoke

        txtQtyImOf.Clear()
        txtErrImOf.Clear()

        btnViewImport.Enabled = False
        btnViewErrorImport.Enabled = False

        TotalImport = Nothing
        TotalError = Nothing

        lblHeader_ImOf.Text = "อ่านรายงานการนำเข้าข้อมูลจาก  " & DeviceName & " ..." 'อ่านรายงานการค้นหาจาก

        TabMain.SelectedTab = TabImportOffline

        '-------------------------------Step 1 Check Environment-------------------------------
        LabelImOfStep1.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))

        Dim FileImageSignPath As String = Application.StartupPath & "\FileBorrowDeliverSign"
        If Directory.Exists(FileImageSignPath) = False Then
            Directory.CreateDirectory(FileImageSignPath)
        End If
        Dim strFileImportName As String = "FileBorrowDeliverList.txt"
        Dim strType As String = "5"

        Try
            Dim rapi As New RAPI
            If rapi.DevicePresent Then
                rapi.Connect()
                rapi.CopyFileFromDevice(Application.StartupPath & "\" & strFileImportName, "\My Documents\" & strFileImportName, True)
                rapi.Disconnect()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        If Not btnCancelIF.Enabled Then Exit Sub '----------Check Cancel Requested--------

        LabelImOfStep1.ForeColor = Color.Green
        IconImOfStep1.BackColor = Color.GreenYellow

        '-------------------------------Step 2 Retrieve Data To Import-------------------------
        LabelImOfStep2.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))


        '= ReadTextFile.ReadTextFileCount(Application.StartupPath & "\" & strFileImportName)
        If File.Exists(Application.StartupPath & "\" & strFileImportName) = False Then
            '-------------- Display Error -------------
            LabelImOfStep2.Text = "ไม่สามารถอ่านไฟล์รายงานผลได้"
            LabelImOfStep2.ForeColor = Color.Red
            IconImOfStep2.BackColor = Color.Red
            StopImport(Nothing, Nothing)
            MsgBox("ไม่สามารถอ่านไฟล์รายงานผลได้")
            Exit Sub
        End If

        Dim rd As New ReadBarcodeFromTextFile
        Dim RT As DataTable = rd.ReadTextFileDeliverSign(strFileImportName)

        If RT.Rows.Count = 0 Then
            '-------------- Display Error -------------
            LabelImOfStep2.Text = "ไม่สามารถอ่านไฟล์รายงานผลได้"
            LabelImOfStep2.ForeColor = Color.Red
            IconImOfStep2.BackColor = Color.Red
            StopImport(Nothing, Nothing)
            MsgBox("ไม่สามารถอ่านไฟล์รายงานผลได้")
            Exit Sub
        End If

        'Copy Image Sign from Device
        Try
            Dim rapi As New RAPI
            If rapi.DevicePresent Then
                rapi.Connect()
                For Each rr As DataRow In RT.Rows
                    rapi.CopyFileFromDevice(FileImageSignPath & "\" & rr("fileborrow_code") & ".jpg", "\My Documents\FileBorrowDeliverSign\" & rr("fileborrow_code") & ".jpg", True)
                Next
                rapi.Disconnect()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        txtQtyImOf.Text = RT.Rows.Count
        txtErrImOf.Text = 0

        btnViewImport.Enabled = True

        TotalImport = RT
        TotalError = RT.Copy


        If Not btnCancelIF.Enabled Then Exit Sub '----------Check Cancel Requested--------

        LabelImOfStep2.ForeColor = Color.Green
        IconImOfStep2.BackColor = Color.GreenYellow

        '-------------------------------Step 3 Update File Borrow Data-------------------------------
        LabelImOfStep3.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))

        Dim trans As New SqlTransactionDB
        trans.CreateTransaction()
        Dim ret As Boolean = False
        Dim ErrMessage As String = ""
        Dim ErrCount As Integer = 0

        For i As Integer = 0 To RT.Rows.Count - 1
            Dim sql As String = " update tb_fileborrow "
            sql += " set is_send_complete = 'Y'"
            sql += ", send_time = '" & RT.Rows(i)("sign_date") & "'"
            sql += ", sign_image = @_sign_image"
            sql += ", updateby = '" & frmMain.txtUserName.Text & "',updateon=getdate()"
            sql += " where fileborrow_code= '" & RT.Rows(i)("fileborrow_code") & "'"

            Dim fByte() As Byte = File.ReadAllBytes(FileImageSignPath & "\" & RT.Rows(i)("fileborrow_code") & ".jpg")
            Dim pam(0) As SqlParameter
            Dim p As New SqlParameter("@_sign_image", SqlDbType.Image, fByte.Length)
            p.Value = fByte
            pam(0) = p

            ret = SqlDB.ExecuteNonQuery(sql, trans.Trans, pam)

            If Not ret Then
                '--------------- Get Error Record---------
                Dim DR As DataRow = TotalError.NewRow
                For j As Integer = 0 To RT.Columns.Count - 1
                    If Not IsDBNull(RT.Rows(i)) Then
                        DR(j) = RT.Rows(i)
                    End If
                Next
                TotalError.Rows.Add(DR)
                '--------------- Get Error Record---------

                ErrMessage = " Update Error : SQL=" & sql
                ErrCount += 1
                txtErrImOf.Text = ErrCount
                txtErrImOf.Refresh()
                btnViewErrorImport.Enabled = True
                Exit For
            End If
        Next

        If ErrCount > 0 Then
            If MsgBox("มีข้อมูลจำนวน " & ErrCount & " รายการ จาก " & RT.Rows.Count & "รายการ" & vbNewLine & " ไม่สามารถบันทึกผลได้" & vbNewLine & "คุณต้องการบันทึกผลรายการที่เหลือหรือไม่?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                LabelImOfStep2.Text = "ยกเลิกการบันทึกข้อมูล"
                LabelImOfStep2.ForeColor = Color.Red
                IconImOfStep2.BackColor = Color.Red
                trans.RollbackTransaction()
                Exit Sub
            End If
        End If
        trans.CommitTransaction()

        If Not btnCancelEF.Enabled Then Exit Sub '----------Check Cancel Requested--------

        LabelImOfStep3.ForeColor = Color.Green
        IconImOfStep3.BackColor = Color.GreenYellow

        '-------------------------------Step 4 Delete File From Handheld----------------------------
        LabelImOfStep4.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))

        Try
            If Directory.Exists(FileImageSignPath) = True Then
                Directory.Delete(FileImageSignPath, True)
            End If
            If File.Exists(Application.StartupPath & "\" & strFileImportName) = True Then
                File.Delete(Application.StartupPath & "\" & strFileImportName)
            End If

            Try
                Dim rapi As New RAPI
                If rapi.DevicePresent Then
                    rapi.Connect()
                    rapi.RemoveDeviceDirectory("\My Documents\FileBorrowDeliverSign", True)
                    rapi.RemoveDeviceDirectory("\My Documents\FileBorrowerName", True)
                    rapi.DeleteDeviceFile("\My Documents\FileBorrowDeliverList.txt")
                    rapi.DeleteDeviceFile("\My Documents\FileBorrowList.txt")
                    rapi.Disconnect()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            'trans = Nothing
            'RemoveAccessDatabase(Application.StartupPath & "\" & strFileImportName, 100, 5)
        Catch ex As Exception
            MsgBox(ex)
            LabelImOfStep4.Text = "ไม่สามารถลบ File ได้"
            LabelImOfStep4.ForeColor = Color.Red
            IconImOfStep4.BackColor = Color.Red
            Exit Sub
        End Try
        RT.Dispose()
        '-------------------------------Finish-----------------------------------------

        LabelImOfStep4.ForeColor = Color.Green
        IconImOfStep4.BackColor = Color.GreenYellow
        btnViewImport.Visible = False
    End Sub
    Public Function Do_Import_Floormove()

        '-------------------------------Clear All Status'-------------------------------
        LabelImOfStep1.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelImOfStep2.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelImOfStep3.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelImOfStep4.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        LabelImOfStep1.ForeColor = Color.Gray
        LabelImOfStep2.ForeColor = Color.Gray
        LabelImOfStep3.ForeColor = Color.Gray
        LabelImOfStep4.ForeColor = Color.Gray

        IconImOfStep1.BackColor = Color.WhiteSmoke
        IconImOfStep2.BackColor = Color.WhiteSmoke
        IconImOfStep3.BackColor = Color.WhiteSmoke
        IconImOfStep4.BackColor = Color.WhiteSmoke

        txtQtyImOf.Clear()
        txtErrImOf.Clear()

        btnViewImport.Enabled = False
        btnViewErrorImport.Enabled = False

        TotalImport = Nothing
        TotalError = Nothing

        lblHeader_ImOf.Text = "อ่านรายงานการค้นหาจาก  " & DeviceName & " ..." 'อ่านรายงานการค้นหาจาก

        TabMain.SelectedTab = TabImportOffline

        '-------------------------------Step 1 Check Environment-------------------------------
        LabelImOfStep1.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))

        Dim MyDocPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        'Dim FilePath As String = MyDocPath & "\" & DeviceName & " My Documents"
        Dim FilePath As String = MyDocPath & "\Documents on " & DeviceName


        Dim strFileImportName As String = "HH_MoveOut.txt"
        Dim strType As String = "5"
        Dim strRFIDREaderID As String = "0"


        Try
            Dim rapi As New RAPI
            If rapi.DevicePresent Then
                'If rapi.DeviceFileExists("\My Documents\DIPExport.txt") Then
                '    rapi.DeleteDeviceFile("\My Documents\DIPExport.txt")
                'End If
                rapi.Connect()
                rapi.CopyFileFromDevice(Application.StartupPath & "\" & strFileImportName, "\My Documents\" & strFileImportName, True)
                rapi.Disconnect()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        If Not btnCancelIF.Enabled Then Exit Function '----------Check Cancel Requested--------

        LabelImOfStep1.ForeColor = Color.Green
        IconImOfStep1.BackColor = Color.GreenYellow

        '-------------------------------Step 2 Retrieve Data To Import-------------------------
        LabelImOfStep2.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))

        Dim ReadTextFile As New ReadBarcodeFromTextFile
        Dim RT As DataTable = ReadTextFile.ReadTextFileCount(Application.StartupPath & "\" & strFileImportName)
        If RT.Rows.Count = 0 Then
            '-------------- Display Error -------------
            LabelImOfStep2.Text = "ไม่สามารถอ่านไฟล์รายงานผลได้"
            LabelImOfStep2.ForeColor = Color.Red
            IconImOfStep2.BackColor = Color.Red
            StopImport(Nothing, Nothing)
            MsgBox("ไม่สามารถอ่านไฟล์รายงานผลได้")
            Exit Function
        End If

        ''Dim DS As New DataSet
        ''Dim RT As DataTable
        ''Try
        ''    DS.ReadXml(Application.StartupPath & "\My Documents\DIPImport.txt")
        ''    RT = DS.Tables(0)
        ''Catch ex As Exception
        ''    '-------------- Display Error -------------
        ''    LabelImOfStep2.Text = "ไม่สามารถอ่านไฟล์รายงานผลได้"
        ''    LabelImOfStep2.ForeColor = Color.Red
        ''    IconImOfStep2.BackColor = Color.Red
        ''    StopImport(Nothing, Nothing)
        ''    MsgBox(ex.Message)
        ''    Exit Sub
        ''End Try


        txtQtyImOf.Text = RT.Rows.Count
        txtErrImOf.Text = 0

        btnViewImport.Enabled = True

        TotalImport = RT
        TotalError = RT.Copy

        If RT.Rows.Count = 0 Then
            '-------------- Display Error -------------
            LabelImOfStep2.ForeColor = Color.Red
            IconImOfStep2.BackColor = Color.Red
            StopImport(Nothing, Nothing)
            MsgBox("ไม่พบข้อมูลที่ต้องการบันทึกผล")
            LabelImOfStep2.Text = "ไม่พบข้อมูล"
            btnViewErrorImport.Enabled = True
            Exit Function
        End If

        If Not btnCancelIF.Enabled Then Exit Function '----------Check Cancel Requested--------

        LabelImOfStep2.ForeColor = Color.Green
        IconImOfStep2.BackColor = Color.GreenYellow

        '-------------------------------Step 3 Write Text File-------------------------------
        LabelImOfStep3.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))

        Dim trans As New SqlTransactionDB
        trans.CreateTransaction()
        Dim ret As Boolean = False
        Dim ErrMessage As String = ""
        Dim ErrCount As Integer = 0

        For i As Integer = 0 To RT.Rows.Count - 1
            Dim GetTextFile As New ReadBarcodeFromTextFile
            Dim strApp_No As String = GetTextFile.GetApplicationNoByRFID(RT.Rows(i).Item("APP_NO"))
            If strApp_No <> "" Then
                Dim dal As New TbFindHHTDAL
                dal.APP_NO = strApp_No
                'Dim LoadTime As DateTime = DateTime.FromOADate(CDbl(RT.Rows(i).Item("LOAD_DATETIME")))
                dal.LOAD_DATETIME = RT.Rows(i).Item("LOAD_DATETIME")
                dal.LOAD_TYPE = "D"
                If RT.Rows(i).Item("FIND_STATUS") = "0" Then
                    dal.FIND_STATUS = "N"
                Else
                    dal.FIND_STATUS = "Y"
                End If
                ' dal.REF_ID = RT.Rows(i).Item("REF_ID")
                ret = dal.InsertData(frmMain.txtUserName.Text, trans.Trans)
                If Not ret Then

                    '--------------- Get Error Record---------
                    Dim DR As DataRow = TotalError.NewRow
                    For j As Integer = 0 To RT.Columns.Count - 1
                        If Not IsDBNull(RT.Rows(i)) Then
                            DR(j) = RT.Rows(i)
                        End If
                    Next
                    TotalError.Rows.Add(DR)
                    '--------------- Get Error Record---------

                    ErrMessage = dal.ErrorMessage
                    ErrCount += 1
                    txtErrImOf.Text = ErrCount
                    txtErrImOf.Refresh()
                    btnViewErrorImport.Enabled = True
                    Exit For
                End If
            End If



        Next

        If ErrCount > 0 Then
            If MsgBox("มีข้อมูลจำนวน " & ErrCount & " รายการ จาก " & RT.Rows.Count & "รายการ" & vbNewLine & " ไม่สามารถบันทึกผลได้" & vbNewLine & "คุณต้องการบันทึกผลรายการที่เหลือหรือไม่?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                LabelImOfStep2.Text = "ยกเลิกการบันทึกข้อมูล"
                LabelImOfStep2.ForeColor = Color.Red
                IconImOfStep2.BackColor = Color.Red
                Exit Function
            End If
        End If

        If ErrCount <> RT.Rows.Count Then
            trans.CommitTransaction()
        Else
            trans.RollbackTransaction()
        End If

        If Not btnCancelEF.Enabled Then Exit Function '----------Check Cancel Requested--------

        LabelImOfStep3.ForeColor = Color.Green
        IconImOfStep3.BackColor = Color.GreenYellow

        '-------------------------------Step 4 Delete File----------------------------
        LabelImOfStep4.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        RT.Dispose()
        Try
            'If File.Exists(Application.StartupPath & "\" & strFileImportName) Then
            '    File.Delete(Application.StartupPath & "\" & strFileImportName)
            'End If
            'trans = Nothing
            'RemoveAccessDatabase(Application.StartupPath & "\" & strFileImportName, 100, 5)
        Catch ex As Exception
            MsgBox(ex)
            LabelImOfStep4.Text = "ไม่สามารถลบ File ได้"
            LabelImOfStep4.ForeColor = Color.Red
            IconImOfStep4.BackColor = Color.Red
            Exit Function
        End Try
        '-------------------------------Finish-----------------------------------------

        LabelImOfStep4.ForeColor = Color.Green
        IconImOfStep4.BackColor = Color.GreenYellow

        ' MsgBox("บันทึกข้อมูลการค้นหาสำเร็จ")

    End Function

    Public Function Do_Import_Floorcount()

        '-------------------------------Clear All Status'-------------------------------
        LabelImOfStep1.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelImOfStep2.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelImOfStep3.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelImOfStep4.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        LabelImOfStep1.ForeColor = Color.Gray
        LabelImOfStep2.ForeColor = Color.Gray
        LabelImOfStep3.ForeColor = Color.Gray
        LabelImOfStep4.ForeColor = Color.Gray

        IconImOfStep1.BackColor = Color.WhiteSmoke
        IconImOfStep2.BackColor = Color.WhiteSmoke
        IconImOfStep3.BackColor = Color.WhiteSmoke
        IconImOfStep4.BackColor = Color.WhiteSmoke

        txtQtyImOf.Clear()
        txtErrImOf.Clear()

        btnViewImport.Enabled = False
        btnViewErrorImport.Enabled = False

        TotalImport = Nothing
        TotalError = Nothing

        lblHeader_ImOf.Text = "อ่านรายงานการค้นหาจาก  " & DeviceName & " ..." 'อ่านรายงานการค้นหาจาก

        TabMain.SelectedTab = TabImportOffline

        '-------------------------------Step 1 Check Environment-------------------------------
        LabelImOfStep1.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))

        Dim MyDocPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        'Dim FilePath As String = MyDocPath & "\" & DeviceName & " My Documents"
        Dim FilePath As String = MyDocPath & "\Documents on " & DeviceName


        Dim strFileImportName As String = "HH_Count.txt"
        Dim strType As String = "4"
        Dim strRFIDREaderID As String = "0"


        Try
            Dim rapi As New RAPI
            If rapi.DevicePresent Then
                rapi.Connect()
                rapi.CopyFileFromDevice(Application.StartupPath & "\" & strFileImportName, "\My Documents\" & strFileImportName, True)

                If rapi.DeviceFileExists("\My Documents\" & strFileImportName) Then
                    rapi.DeleteDeviceFile("\My Documents\" & strFileImportName)
                End If
                rapi.Disconnect()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        If Not btnCancelIF.Enabled Then Exit Function '----------Check Cancel Requested--------

        LabelImOfStep1.ForeColor = Color.Green
        IconImOfStep1.BackColor = Color.GreenYellow

        '-------------------------------Step 2 Retrieve Data To Import-------------------------
        LabelImOfStep2.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))

        Dim ReadTextFile As New ReadBarcodeFromTextFile
        Dim RT As DataTable = ReadTextFile.ReadTextFileCount(Application.StartupPath & "\" & strFileImportName)
        If RT.Rows.Count = 0 Then
            '-------------- Display Error -------------
            LabelImOfStep2.Text = "ไม่สามารถอ่านไฟล์รายงานผลได้"
            LabelImOfStep2.ForeColor = Color.Red
            IconImOfStep2.BackColor = Color.Red
            StopImport(Nothing, Nothing)
            MsgBox("ไม่สามารถอ่านไฟล์รายงานผลได้")
            Exit Function
        End If

        ''Dim DS As New DataSet
        ''Dim RT As DataTable
        ''Try
        ''    DS.ReadXml(Application.StartupPath & "\My Documents\DIPImport.txt")
        ''    RT = DS.Tables(0)
        ''Catch ex As Exception
        ''    '-------------- Display Error -------------
        ''    LabelImOfStep2.Text = "ไม่สามารถอ่านไฟล์รายงานผลได้"
        ''    LabelImOfStep2.ForeColor = Color.Red
        ''    IconImOfStep2.BackColor = Color.Red
        ''    StopImport(Nothing, Nothing)
        ''    MsgBox(ex.Message)
        ''    Exit Sub
        ''End Try


        txtQtyImOf.Text = RT.Rows.Count
        txtErrImOf.Text = 0

        btnViewImport.Enabled = True

        TotalImport = RT
        TotalError = RT.Copy

        If RT.Rows.Count = 0 Then
            '-------------- Display Error -------------
            LabelImOfStep2.ForeColor = Color.Red
            IconImOfStep2.BackColor = Color.Red
            StopImport(Nothing, Nothing)
            MsgBox("ไม่พบข้อมูลที่ต้องการบันทึกผล")
            LabelImOfStep2.Text = "ไม่พบข้อมูล"
            btnViewErrorImport.Enabled = True
            Exit Function
        End If

        If Not btnCancelIF.Enabled Then Exit Function '----------Check Cancel Requested--------

        LabelImOfStep2.ForeColor = Color.Green
        IconImOfStep2.BackColor = Color.GreenYellow

        '-------------------------------Step 3 Write Text File-------------------------------
        LabelImOfStep3.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))

        Dim trans As New SqlTransactionDB
        trans.CreateTransaction()
        Dim ret As Boolean = False
        Dim ErrMessage As String = ""
        Dim ErrCount As Integer = 0

        For i As Integer = 0 To RT.Rows.Count - 1
            Dim GetTextFile As New ReadBarcodeFromTextFile
            Dim strApp_No As String = GetTextFile.GetApplicationNoByRFID(RT.Rows(i).Item("APP_NO"))
            If strApp_No <> "" Then
                Dim dal As New TbFindHHTDAL
                dal.APP_NO = strApp_No
                'Dim LoadTime As DateTime = DateTime.FromOADate(CDbl(RT.Rows(i).Item("LOAD_DATETIME")))
                dal.LOAD_DATETIME = RT.Rows(i).Item("LOAD_DATETIME")
                dal.LOAD_TYPE = "D"
                If RT.Rows(i).Item("FIND_STATUS") = "0" Then
                    dal.FIND_STATUS = "N"
                Else
                    dal.FIND_STATUS = "Y"
                End If
                ' dal.REF_ID = RT.Rows(i).Item("REF_ID")
                ret = dal.InsertData(frmMain.txtUserName.Text, trans.Trans)
                If Not ret Then

                    '--------------- Get Error Record---------
                    Dim DR As DataRow = TotalError.NewRow
                    For j As Integer = 0 To RT.Columns.Count - 1
                        If Not IsDBNull(RT.Rows(i)) Then
                            DR(j) = RT.Rows(i)
                        End If
                    Next
                    TotalError.Rows.Add(DR)
                    '--------------- Get Error Record---------

                    ErrMessage = dal.ErrorMessage
                    ErrCount += 1
                    txtErrImOf.Text = ErrCount
                    txtErrImOf.Refresh()
                    btnViewErrorImport.Enabled = True
                    Exit For
                End If
            End If



        Next

        If ErrCount > 0 Then
            If MsgBox("มีข้อมูลจำนวน " & ErrCount & " รายการ จาก " & RT.Rows.Count & "รายการ" & vbNewLine & " ไม่สามารถบันทึกผลได้" & vbNewLine & "คุณต้องการบันทึกผลรายการที่เหลือหรือไม่?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                LabelImOfStep2.Text = "ยกเลิกการบันทึกข้อมูล"
                LabelImOfStep2.ForeColor = Color.Red
                IconImOfStep2.BackColor = Color.Red
                Exit Function
            End If
        End If

        If ErrCount <> RT.Rows.Count Then
            trans.CommitTransaction()
        Else
            trans.RollbackTransaction()
        End If

        If Not btnCancelEF.Enabled Then Exit Function '----------Check Cancel Requested--------

        LabelImOfStep3.ForeColor = Color.Green
        IconImOfStep3.BackColor = Color.GreenYellow

        '-------------------------------Step 4 Delete File----------------------------
        LabelImOfStep4.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        RT.Dispose()
        Try
            'If File.Exists(Application.StartupPath & "\" & strFileImportName) Then
            '    File.Delete(Application.StartupPath & "\" & strFileImportName)
            'End If
            'trans = Nothing
            'RemoveAccessDatabase(Application.StartupPath & "\" & strFileImportName, 100, 5)
        Catch ex As Exception
            MsgBox(ex)
            LabelImOfStep4.Text = "ไม่สามารถลบ File ได้"
            LabelImOfStep4.ForeColor = Color.Red
            IconImOfStep4.BackColor = Color.Red
            Exit Function
        End Try
        '-------------------------------Finish-----------------------------------------

        LabelImOfStep4.ForeColor = Color.Green
        IconImOfStep4.BackColor = Color.GreenYellow

        ' MsgBox("บันทึกข้อมูลการค้นหาสำเร็จ")

    End Function

    Private Sub Do_Import()

        '-------------------------------Clear All Status'-------------------------------
        LabelImOfStep1.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelImOfStep2.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelImOfStep3.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        LabelImOfStep4.Font = New Font("Tahoma", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        LabelImOfStep1.ForeColor = Color.Gray
        LabelImOfStep2.ForeColor = Color.Gray
        LabelImOfStep3.ForeColor = Color.Gray
        LabelImOfStep4.ForeColor = Color.Gray

        IconImOfStep1.BackColor = Color.WhiteSmoke
        IconImOfStep2.BackColor = Color.WhiteSmoke
        IconImOfStep3.BackColor = Color.WhiteSmoke
        IconImOfStep4.BackColor = Color.WhiteSmoke

        txtQtyImOf.Clear()
        txtErrImOf.Clear()

        btnViewImport.Enabled = False
        btnViewErrorImport.Enabled = False

        TotalImport = Nothing
        TotalError = Nothing

        lblHeader_ImOf.Text = "อ่านรายงานการค้นหาจาก  " & DeviceName & " ..." 'อ่านรายงานการค้นหาจาก

        TabMain.SelectedTab = TabImportOffline

        '-------------------------------Step 1 Check Environment-------------------------------
        LabelImOfStep1.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))

        Dim MyDocPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        'Dim FilePath As String = MyDocPath & "\" & DeviceName & " My Documents"
        Dim FilePath As String = MyDocPath & "\Documents on " & DeviceName


        Dim strFileImportName As String = ""
        Dim strType As String = ""
        Dim strRFIDREaderID As String = "0"
        Select Case frmMain.txtDocumentEvent.Text.ToLower
            Case "borrow"
                strFileImportName = "HH_CheckOut.txt"
                strType = 1
            Case "return"
                strFileImportName = "HH_CheckIn.txt"
                strType = 2
            Case "location"
                strFileImportName = "HH_Change.txt"
                strType = 3
        End Select

        Try
            Dim rapi As New RAPI
            If rapi.DevicePresent Then
                'If rapi.DeviceFileExists("\My Documents\DIPExport.txt") Then
                '    rapi.DeleteDeviceFile("\My Documents\DIPExport.txt")
                'End If
                rapi.Connect()
                rapi.CopyFileFromDevice(Application.StartupPath & "\" & strFileImportName, "\My Documents\" & strFileImportName, True)
                rapi.Disconnect()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        If Not btnCancelIF.Enabled Then Exit Sub '----------Check Cancel Requested--------

        LabelImOfStep1.ForeColor = Color.Green
        IconImOfStep1.BackColor = Color.GreenYellow

        '-------------------------------Step 2 Retrieve Data To Import-------------------------
        LabelImOfStep2.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))

        'ยืนยันเสร็จให้ลบ Temp
        SqlDB.ExecuteNonQuery("DELETE FROM TMP_GATE_READER_TAG where createby='MOBILE' and Reader_id=" & ReadBarcodeFromTextFile.GetReaderId)

        Dim ReadTextFile As New ReadBarcodeFromTextFile
        Dim RT As DataTable = ReadTextFile.ReadTextFile(Application.StartupPath & "\" & strFileImportName)
        Dim IsInsert As Boolean = ReadTextFile.ReadTextFileAndInsertToTemp(Application.StartupPath & "\" & strFileImportName, strRFIDREaderID, strType)
        If IsInsert = False Then
            '-------------- Display Error -------------
            LabelImOfStep2.Text = "ไม่สามารถอ่านไฟล์รายงานผลได้"
            LabelImOfStep2.ForeColor = Color.Red
            IconImOfStep2.BackColor = Color.Red
            StopImport(Nothing, Nothing)
            MsgBox("ไม่สามารถอ่านไฟล์รายงานผลได้")
            Exit Sub
        End If

        ''Dim DS As New DataSet
        ''Dim RT As DataTable
        ''Try
        ''    DS.ReadXml(Application.StartupPath & "\My Documents\DIPImport.txt")
        ''    RT = DS.Tables(0)
        ''Catch ex As Exception
        ''    '-------------- Display Error -------------
        ''    LabelImOfStep2.Text = "ไม่สามารถอ่านไฟล์รายงานผลได้"
        ''    LabelImOfStep2.ForeColor = Color.Red
        ''    IconImOfStep2.BackColor = Color.Red
        ''    StopImport(Nothing, Nothing)
        ''    MsgBox(ex.Message)
        ''    Exit Sub
        ''End Try


        txtQtyImOf.Text = RT.Rows.Count
        txtErrImOf.Text = 0

        btnViewImport.Enabled = True

        TotalImport = RT
        TotalError = RT.Copy

        If RT.Rows.Count = 0 Then
            '-------------- Display Error -------------
            LabelImOfStep2.ForeColor = Color.Red
            IconImOfStep2.BackColor = Color.Red
            StopImport(Nothing, Nothing)
            MsgBox("ไม่พบข้อมูลที่ต้องการบันทึกผล")
            LabelImOfStep2.Text = "ไม่พบข้อมูล"
            btnViewErrorImport.Enabled = True
            Exit Sub
        End If

        If Not btnCancelIF.Enabled Then Exit Sub '----------Check Cancel Requested--------

        LabelImOfStep2.ForeColor = Color.Green
        IconImOfStep2.BackColor = Color.GreenYellow

        '-------------------------------Step 3 Write Text File-------------------------------
        LabelImOfStep3.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))

        Dim trans As New SqlTransactionDB
        trans.CreateTransaction()
        Dim ret As Boolean = False
        Dim ErrMessage As String = ""
        Dim ErrCount As Integer = 0

        For i As Integer = 0 To RT.Rows.Count - 1
            Dim GetTextFile As New ReadBarcodeFromTextFile
            Dim strApp_No As String = GetTextFile.GetApplicationNoByRFID(RT.Rows(i).Item("APP_NO"))
            If strApp_No <> "" Then
                Dim dal As New TbFindHHTDAL
                dal.APP_NO = strApp_No
                'Dim LoadTime As DateTime = DateTime.FromOADate(CDbl(RT.Rows(i).Item("LOAD_DATETIME")))
                dal.LOAD_DATETIME = RT.Rows(i).Item("LOAD_DATETIME")
                dal.LOAD_TYPE = "D"
                If RT.Rows(i).Item("FIND_STATUS") = "0" Then
                    dal.FIND_STATUS = "N"
                Else
                    dal.FIND_STATUS = "Y"
                End If
                ' dal.REF_ID = RT.Rows(i).Item("REF_ID")
                ret = dal.InsertData(frmMain.txtUserName.Text, trans.Trans)
                If Not ret Then

                    '--------------- Get Error Record---------
                    Dim DR As DataRow = TotalError.NewRow
                    For j As Integer = 0 To RT.Columns.Count - 1
                        If Not IsDBNull(RT.Rows(i)) Then
                            DR(j) = RT.Rows(i)
                        End If
                    Next
                    TotalError.Rows.Add(DR)
                    '--------------- Get Error Record---------

                    ErrMessage = dal.ErrorMessage
                    ErrCount += 1
                    txtErrImOf.Text = ErrCount
                    txtErrImOf.Refresh()
                    btnViewErrorImport.Enabled = True
                    Exit For
                End If
            End If



        Next

        If ErrCount > 0 Then
            If MsgBox("มีข้อมูลจำนวน " & ErrCount & " รายการ จาก " & RT.Rows.Count & "รายการ" & vbNewLine & " ไม่สามารถบันทึกผลได้" & vbNewLine & "คุณต้องการบันทึกผลรายการที่เหลือหรือไม่?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                LabelImOfStep2.Text = "ยกเลิกการบันทึกข้อมูล"
                LabelImOfStep2.ForeColor = Color.Red
                IconImOfStep2.BackColor = Color.Red
                Exit Sub
            End If
        End If

        If ErrCount <> RT.Rows.Count Then
            trans.CommitTransaction()
        Else
            trans.RollbackTransaction()
        End If

        If Not btnCancelEF.Enabled Then Exit Sub '----------Check Cancel Requested--------

        LabelImOfStep3.ForeColor = Color.Green
        IconImOfStep3.BackColor = Color.GreenYellow

        '-------------------------------Step 4 Delete File----------------------------
        LabelImOfStep4.Font = New Font("Tahoma", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        RT.Dispose()
        Try

            Dim DelExportFileName As String = Application.StartupPath & "\DIPCheckOut.txt"
            If File.Exists(DelExportFileName) = True Then
                File.SetAttributes(DelExportFileName, FileAttributes.Normal)
                File.Delete(DelExportFileName)
            End If

            Dim rapi As New RAPI
            If rapi.DevicePresent Then
                Dim DelFileName As String = "\My Documents\" & strFileImportName
                rapi.Connect()
                If rapi.DeviceFileExists(DelFileName) Then
                    rapi.DeleteDeviceFile(DelFileName)
                End If
                rapi.Disconnect()
            End If
        Catch ex As Exception
            MsgBox(ex)
            LabelImOfStep4.Text = "ไม่สามารถลบ File ได้"
            LabelImOfStep4.ForeColor = Color.Red
            IconImOfStep4.BackColor = Color.Red
            Exit Sub
        End Try
        '-------------------------------Finish-----------------------------------------

        LabelImOfStep4.ForeColor = Color.Green
        IconImOfStep4.BackColor = Color.GreenYellow

        MsgBox("บันทึกข้อมูลการค้นหาสำเร็จ")

    End Sub

    Function RemoveAccessDatabase( _
    ByVal FileName As String, _
    ByVal WaitTime As Integer, _
    ByVal Loops As Integer) As Boolean

        Dim Success As Boolean = False

        Dim LockFile As String = IO.Path.ChangeExtension(FileName, "txt")

        For Counter As Integer = 0 To Loops
            If IO.File.Exists(LockFile) Then
                System.Threading.Thread.Sleep(WaitTime)
                IO.File.Delete(FileName)
            Else
                Success = True
                Exit For
            End If
        Next

        Return Success

    End Function

    Dim TotalImport As DataTable
    Dim TotalError As DataTable

    Private Sub btnViewImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewImport.Click
        Dim F As New frmPreviewMobile
        F.Datasource = TotalImport
        Dim Total As Integer = 0
        If Not IsNothing(TotalImport) AndAlso TotalImport.Rows.Count > 0 Then
            F.Text = "สรุปรายงานการทั้งหมด " & TotalImport.Rows.Count & " แฟ้ม"
            Dim tmp As DataTable = TotalError.Copy
            tmp.DefaultView.RowFilter = "FIND_STATUS='1'"
            F.Text &= "ค้นหาเจอ " & tmp.DefaultView.Count & "/" & tmp.Rows.Count
            tmp.Dispose()
        Else
            F.Text = "ไม่พบแฟ้มที่ต้องสรุปผลการค้นหา"
        End If
        F.ShowDialog()
    End Sub

    Private Sub btnViewErrorImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewErrorImport.Click
        Dim F As New frmPreviewMobile
        F.Datasource = TotalError
        Dim Total As Integer = 0
        If Not IsNothing(TotalError) AndAlso TotalError.Rows.Count > 0 Then
            F.Text = "สรุปรายงานที่ไม่สามารถบันทึกผลได้ " & TotalError.Rows.Count & " แฟ้ม"
        Else
            F.Text = "ไม่พบรายงานแฟ้มที่ไม่สามารถบันทึกผลได้"
        End If
        F.ShowDialog()
    End Sub

    'Private Function IsFormatQuery(ByVal InputText As String) As String
    '    If Not InputText.IndexOf("INSERT INTO TB_FIND_HHT (id,app_no,load_datetime,load_type,find_status,createon,updateon) VALUES ((SELECT ISNULL(MAX(id),0)+1 FROM TB_FIND_HHT),") <> 0 Then
    '        Return False
    '    End If
    '    Try
    '        If Not InputText.IndexOf(",GetDate(),GetDate())") = -1 Then
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        Return False
    '    End Try
    '    Return True
    'End Function

    Private Sub StopImport(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelIF.Click
        btnCancelIF.Enabled = False
        btnBackIF.Enabled = True
        btnFinishIF.Enabled = True
    End Sub


#End Region

    Dim WaitCount As Integer = 0
    Dim MaxWait As Integer = 5

    Private Sub TimerWait_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerWait.Tick
        WaitCount += 1

        '---------- Check Cancel Requested----------
        Select Case SyncFor
            Case TASK_TYPE.Export

                If Not btnCancelEF.Enabled Then
                    LabelExOfStep4.ForeColor = Color.Red
                    IconExOfStep4.BackColor = Color.Red
                    StopExport(Nothing, Nothing)
                    WaitCount = 0
                    TimerWait.Enabled = False
                    Exit Sub
                End If

                If WaitCount >= MaxWait Then
                    LabelExOfStep4.ForeColor = Color.Green
                    IconExOfStep4.BackColor = Color.GreenYellow
                    StopExport(Nothing, Nothing)
                    WaitCount = 0
                    TimerWait.Enabled = False
                End If

            Case TASK_TYPE.Import

        End Select

    End Sub

End Class