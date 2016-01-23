Imports System.IO

Public Class FormLoadChoice

    Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click, PictExit.Click
        Application.Exit()
    End Sub

    Private Sub ButtonReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReport.Click, PicReport.Click
        Cursor.Current = Cursors.WaitCursor
        FormReportOffline.Show()
        FormReportOffline.FormReportOffline_Load(FormReportOffline, e)
        FormReportOffline.Focus()
        FormReportOffline.BringToFront()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ButtonOffline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOffline.Click, PicOffline.Click
        Cursor.Current = Cursors.WaitCursor
        FormLoadOffline.Show()
        FormLoadOffline.FormLoadOffline_Load(FormLoadOffline, e)
        FormLoadOffline.Focus()
        FormLoadOffline.BringToFront()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ButtonRemain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRemain.Click, PicRemain.Click
        Cursor.Current = Cursors.WaitCursor
        FormDisplayJob.Show()
        'If FormDisplayJob.JobContainer.Controls.Count = 0 Then
        FormDisplayJob.FormDisplayJob_Load(FormDisplayJob, e)
        'End If
        FormDisplayJob.Focus()
        FormDisplayJob.BringToFront()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub FormLoadChoice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.Default

        Try
            Dim Reader As New StreamReader(ApplicationPath() & "\DeviceName.txt")
            Dim DeviceName As String = Trim(Reader.ReadLine())
            Reader.Close()
            lblDevice.Text = "Device#" & DeviceName
        Catch ex As Exception
        End Try

        '--------------- Create New Database If Not Exists ---------------
        Dim CE As New CEConnection
        Dim IsError As Boolean = False
        Try
            CE.SelectData("SELECT 1 FROM Job_Desc", LocalConnectionString)
        Catch ex As Exception
            IsError = True
        End Try

        '----------- Try To Create New Database-------
        If IsError Then
            Try
                File.Delete(LocalConnectionString)
            Catch : End Try
            Try
                CE.CreateDataBase(LocalConnectionString)
                Dim Script As String = "CREATE TABLE Job_Desc(" & vbNewLine
                Script &= " [APP_NO] nvarchar(200)," & vbNewLine
                Script &= " [APP_NAME] nvarchar(200)," & vbNewLine
                Script &= " [APP_POSITION] nvarchar(200)," & vbNewLine
                Script &= " [LOAD_DATETIME] float," & vbNewLine
                Script &= " [FIND_STATUS] int," & vbNewLine
                Script &= " [REF_ID] int" & vbNewLine
                Script &= " )" & vbNewLine
                CE.ExecuteLocalCommand(Script, LocalConnectionString)
            Catch ex As Exception
            End Try
            Try
                CE.SelectData("SELECT 1 FROM Job_Desc", LocalConnectionString)
                IsError = False
            Catch ex As Exception
                IsError = True
            End Try
        End If

        CE = Nothing

        If IsError Then
            MsgBox("ไม่สามารถอ่านข้อมูล SDF ได้กรุณาติดต่อเจ้าหน้าที่", MsgBoxStyle.Critical)
            ButtonReport.Enabled = False ' Fix ----
            PicReport.Enabled = False ' Fix ----
            ButtonOffline.Enabled = False
            PicOffline.Enabled = False
            ButtonRemain.Enabled = False
            PicRemain.Enabled = False
        Else
            ButtonReport.Enabled = True ' Fix ----
            PicReport.Enabled = True ' Fix ----
            ButtonOffline.Enabled = True
            PicOffline.Enabled = True
            ButtonRemain.Enabled = True
            PicRemain.Enabled = True

        End If




    End Sub
End Class
