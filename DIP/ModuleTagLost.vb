Imports System.IO
Imports System.Text
Imports DIP_RFID.DAL.Common.Utilities
Imports OpenNETCF.Desktop.Communication

Module ModuleTagLost
    Public Sub Do_Export_FileLost(ByVal DeviceName As String)
        Dim MyDocPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ' Dim FilePath As String = MyDocPath & "\" & DeviceName & " My Documents"
        Dim FilePath As String = MyDocPath & "\Documents on " & DeviceName
        If Not Directory.Exists(Application.StartupPath) Then
            Directory.CreateDirectory(Application.StartupPath)
        End If

        Dim DT As DataTable = SqlDB.ExecuteTable("select app_no, discover_msg from ts_file_lost where discover_date is null order by lost_date")
        If DT.Rows.Count > 0 Then
            '###เพิ่มการ Copy file To Device#######
            If File.Exists(Application.StartupPath & "\DIPFileLost.txt") Then File.Delete(Application.StartupPath & "\DIPFileLost.txt")
            Dim objWriter As New System.IO.StreamWriter(Application.StartupPath & "\DIPFileLost.txt", True)
            Dim strText As New StringBuilder
            For i As Integer = 0 To DT.Rows.Count - 1
                strText.Append(DT.Rows(i)("app_no"))
                strText.AppendLine()
            Next
            objWriter.Write(strText.ToString)
            objWriter.Close()

            Try
                Dim rapi As New RAPI
                If rapi.DevicePresent Then
                    Dim DIPFileLost As String = "\My Documents\DIPFileLost.txt"
                    rapi.Connect()
                    rapi.CopyFileToDevice(Application.StartupPath & "\DIPFileLost.txt", DIPFileLost, True)
                    rapi.Disconnect()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            '#################################
        End If
        DT.Dispose()


    End Sub

    Public Sub Do_Import_FileDiscover()
        Try
            Dim rapi As New RAPI
            If rapi.DevicePresent Then
                Dim strFileImportName As String = "DIPFileDiscover.txt"
                rapi.Connect()
                If rapi.DeviceFileExists("\My Documents\DIPExport.txt") Then
                    rapi.CopyFileFromDevice(Application.StartupPath & "\" & strFileImportName, "\My Documents\" & strFileImportName, True)
                    rapi.DeleteDeviceFile("\My Documents\" & strFileImportName)
                End If
                rapi.Disconnect()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module
