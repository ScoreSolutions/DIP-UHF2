Imports System.IO
Imports System.Data
Imports System.Data.SqlServerCe

Public Class FormLoadOffline

    Private Sub LinkBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkBack.Click, PicBack.Click
        Cursor.Current = Cursors.WaitCursor
        FormLoadChoice.Focus()
        FormLoadChoice.BringToFront()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub LinkDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkDownload.Click, PicDownload.Click


        LinkDownload.Text = "กำลังทำการดาวน์โหลด"
        LinkDownload.Enabled = False
        LinkDownload.Refresh()

        Dim DS As New DataSet
        Dim DT As New DataTable
        Dim CE As New CEConnection

        DS.ReadXml(ExportFileName)
        DT = DS.Tables(0)

        ProgressDownload.Value = 0
        ProgressDownload.Maximum = DT.Rows.Count

        Dim PDAData As DataTable = CE.SelectData("SELECT * FROM Job_Desc", LocalConnectionString)

        'Compare Data In PDA And XML
        For i As Integer = 0 To DT.Rows.Count - 1

            PDAData.DefaultView.RowFilter = "APP_NO='" & DT.Rows(i).Item("APP_NO") & "' AND FIND_STATUS=0 AND REF_ID=" & DT.Rows(i).Item("REF_ID")
            If PDAData.DefaultView.Count = 0 Then
                Try
                    Dim SQL As String = "INSERT INTO Job_Desc ( " & vbNewLine
                    SQL &= "APP_NO, " & vbNewLine
                    SQL &= "APP_NAME, " & vbNewLine
                    SQL &= "APP_POSITION, " & vbNewLine
                    SQL &= "LOAD_DATETIME, " & vbNewLine
                    SQL &= "FIND_STATUS," & vbNewLine
                    SQL &= "REF_ID " & vbNewLine
                    SQL &= ") VALUES (" & vbNewLine

                    SQL &= "'" & DT.Rows(i).Item("APP_NO") & "'," & vbNewLine
                    If Not IsDBNull(DT.Rows(i).Item("APP_NAME")) Then SQL &= "'" & DT.Rows(i).Item("APP_NAME") & "'," & vbNewLine Else SQL &= "'',"
                    If Not IsDBNull(DT.Rows(i).Item("APP_POSITION")) Then SQL &= "'" & DT.Rows(i).Item("APP_POSITION") & "'," & vbNewLine Else SQL &= "'',"
                    SQL &= DT.Rows(i).Item("LOAD_DATETIME") & "," & vbNewLine
                    SQL &= DT.Rows(i).Item("FIND_STATUS") & "," & vbNewLine
                    SQL &= DT.Rows(i).Item("REF_ID") & vbNewLine
                    SQL &= ")"

                    CE.ExecuteLocalCommand(SQL, LocalConnectionString)

                Catch ex As Exception

                End Try
            End If
            ProgressDownload.Value += 1
            ProgressDownload.Refresh()
        Next


        Cursor.Current = Cursors.WaitCursor
        FormDisplayJob.Show()
        'If FormDisplayJob.JobContainer.Controls.Count = 0 Then
        FormDisplayJob.FormDisplayJob_Load(FormDisplayJob, e)
        'End If
        FormDisplayJob.Focus()
        FormDisplayJob.BringToFront()
        Cursor.Current = Cursors.Default

    End Sub

    Public Sub FormLoadOffline_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.Default

        LinkDownload.Text = "เสียบสาย USB และ Click" & vbNewLine & "เพื่อดาวน์โหลดข้อมูล"
        ProgressDownload.Value = 0

        If Not File.Exists(ExportFileName) Then
            MsgBox("ไม่พบแฟ้มข้อมูลที่ ส่งออกจากเครื่องคอมพิวเตอร์หลัก " & vbNewLine & "เสียบสาย USB เพื่อ Load ไฟล์ข้อมูลจากเครื่องคอมพิวเตอร์ก่อน", MsgBoxStyle.Critical)
            LinkDownload.Enabled = False
            PicDownload.Enabled = False
        Else
            LinkDownload.Enabled = True
            PicDownload.Enabled = True
        End If
    End Sub
End Class