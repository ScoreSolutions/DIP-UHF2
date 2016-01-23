Imports System.IO
Imports DIP_File_Tracker.CEConnection
Imports System.Data

Public Class FormReportOffline

    Dim PDAData As New DataTable

    Private Sub LinkBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkBack.Click, PicBack.Click
        Cursor.Current = Cursors.WaitCursor
        FormLoadChoice.Focus()
        FormLoadChoice.BringToFront()
        Cursor.Current = Cursors.Default
    End Sub

    Public Sub FormReportOffline_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.Default

        LinkReport.Text = "เสียบสาย USB และ Click" & vbNewLine & "เพื่อส่งผลการค้นหา"
        ProgressReport.Value = 0

        Dim CE As New CEConnection

        PDAData = New DataTable

        Dim IsNoData As Boolean = False
        If Not File.Exists(LocalConnectionString.Replace("Data Source=", "")) Then
            IsNoData = True
        Else
            PDAData = CE.SelectData("SELECT * FROM Job_Desc", LocalConnectionString)
            If PDAData.Rows.Count = 0 Then
               IsNoData=True
            End If
        End If

        If IsNoData Then
            MsgBox("ไม่พบแฟ้มข้อมูลที่ต้องส่งออก", MsgBoxStyle.Critical)
            LinkReport.Enabled = False
            PicReport.Enabled = False
            CheckClearData.Enabled = False
            Exit Sub
        End If

        If File.Exists(ReportFileName) Then
            Try
                File.Delete(ReportFileName)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                LinkReport.Enabled = False
                PicReport.Enabled = False
                CheckClearData.Enabled = False
                Exit Sub
            End Try
        End If

        LinkReport.Enabled = True
        PicReport.Enabled = True
        CheckClearData.Enabled = True

    End Sub

    Private Sub LinkReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkReport.Click, PicReport.Click

        LinkReport.Text = "กำลังส่งออก"
        LinkReport.Enabled = False
        LinkReport.Refresh()

        ProgressReport.Value = 0
        ProgressReport.Refresh()

        Dim CE As New CEConnection
        'Dim F As New StreamWriter(ReportFileName)

        '---------------Write File-------------
        'Dim T As New Threading.Thread(AddressOf ExportResultDataset)
        'T.IsBackground = True
        'T.Priority = Threading.ThreadPriority.BelowNormal
        'T.Start()

        ExportResultDataset()


        ProgressReport.Maximum = PDAData.Rows.Count

        For i As Integer = 0 To PDAData.Rows.Count - 1
            Dim Query As String = "INSERT INTO TB_FIND_HHT ("
            Query &= "id,"
            Query &= "app_no,"
            Query &= "load_datetime,"
            Query &= "load_type,"
            Query &= "find_status,"
            Query &= "createon,"
            Query &= "updateon,"
            Query &= "ref_id"
            Query &= ") VALUES ("
            Query &= "(SELECT ISNULL(MAX(id),0)+1 FROM TB_FIND_HHT),"
            Query &= "'" & PDAData.Rows(i).Item("APP_NO") & "',"

            Dim loadtime As DateTime = DateTime.FromOADate(PDAData.Rows(i).Item("LOAD_DATETIME"))

            Query &= "'" & loadtime.Year & "-" & loadtime.Month.ToString.PadLeft(2, "0") & "-" & loadtime.Day.ToString.PadLeft(2, "0") & " " & loadtime.Hour.ToString.PadLeft(2, "0") & ":" & loadtime.Minute.ToString.PadLeft(2, "0") & ":" & loadtime.Second.ToString.PadLeft(2, "0") & "',"
            Query &= "'D',"
            Select Case PDAData.Rows(i).Item("FIND_STATUS")
                Case 1
                    Query &= "'Y',"
                Case 0
                    Query &= "'N',"
            End Select

            Query &= "GetDate(),"
            Query &= "GetDate(),"
            Query &= PDAData.Rows(i).Item("REF_ID")
            Query &= ")"

            'F.WriteLine(Query)

            If CheckClearData.Checked Then
                CE.ExecuteLocalCommand("DELETE FROM Job_Desc WHERE APP_NO='" & PDAData.Rows(i).Item("APP_NO") & "' AND FIND_STATUS=" & PDAData.Rows(i).Item("FIND_STATUS") & " AND REF_ID=" & PDAData.Rows(i).Item("REF_ID"), LocalConnectionString)
            End If
            ProgressReport.Value += 1
            ProgressReport.Refresh()
        Next

        'F.Close()

        If CheckClearData.Checked Then
            CE.ExecuteLocalCommand("DELETE FROM Job_Desc", LocalConnectionString)
        End If

        CE = Nothing

        MsgBox("รายงานผลการค้นหาสำเร็จ")
        MsgBox("ตรวจสอบการเชื่อมต่อกับเครื่อง PC" & vbNewLine & "เพื่อบันทึกผลการค้นหาไปยังฐานข้อมูล")

        Cursor.Current = Cursors.WaitCursor
        FormLoadChoice.Show()
        FormLoadChoice.Focus()
        FormLoadChoice.BringToFront()
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub ExportResultDataset()
        Dim DS As New DataSet
        Dim DT As New DataTable
        DT = PDAData.Copy
        DT.TableName = "Import"
        DS.Tables.Add(DT)
        DS.DataSetName = "DIP"
        DS.WriteXml(ReportFileName)
        DS.Dispose()
        'Exit From Currnet Thread
        'Threading.Thread.CurrentThread.Abort()
    End Sub

End Class