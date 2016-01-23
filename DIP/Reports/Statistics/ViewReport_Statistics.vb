Imports DIP_RFID.DAL.Common.Utilities
Public Class ViewReport_Statistics

    Private Sub ViewReport_Statistics_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Valueed = "R013" Then
            Dim rpt As New DIP_R013
            Dim str As String = ""
            Dim sqlqury As String = ""
            Dim dt As New DataTable
            If pattened = 0 Then
                sqlqury = ""
            Else
                sqlqury = "and pt.id='" & pattened & "'"
            End If
            Try
                'คำสั่ง sql เงื่อนไข ไปแสดงในรายงาน
                str = "select CONVERT(VARCHAR(8),fb.borrowerdate,112) as dateBorrow"
                str += ",pt.patent_type_name,COUNT (fbi.requisition_id)as borrow "
                str += "from TB_FILEBORROWITEM fbi "
                str += "inner join TB_FILEBORROW fb on fb.id=fbi.fileborrow_id "
                str += "inner join TB_REQUISTION rq on rq.id=fbi.requisition_id "
                str += "inner join TB_PATENT_TYPE pt on pt.id=rq.patent_type_id "
                str += "where Convert(VARCHAR(8),fb.borrowerdate,112) "
                str += "between '" & date_timestart & "' and '" & date_timestop & "' "
                str += "" & sqlqury & " group by fb.borrowerdate,pt.patent_type_name "
                str += "order by fb.borrowerdate ASC"
                dt = SqlDB.ExecuteTable(str)
                rpt.SetDataSource(dt)
                If dt.Rows.Count > 0 Then
                    rpt.DataDefinition.FormulaFields("datestart").Text = "'" & date_timestart & "'"
                    rpt.DataDefinition.FormulaFields("datestop").Text = "'" & date_timestop & "'"
                    rpt.DataDefinition.FormulaFields("staff").Text = "'" & frmMain.txtFullUserName.Text & "'"
                    rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
                    crpStatistics.ReportSource = rpt
                Else
                    MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
                    Me.Close()
                End If
            Catch ex As Exception
            End Try

        ElseIf Valueed = "R014" Then
            Dim rpt As New DIP_R014
            Dim str As String = ""
            Dim sqlqury As String = ""
            Dim dt As New DataTable
            If pattened = 0 Then
                sqlqury = ""
            Else
                sqlqury = "and pt.id='" & pattened & "'"
            End If
            Try
                str = "select CONVERT(VARCHAR(8),fbi.returndate,112) as returndate ,pt.patent_type_name"
                str += ",COUNT (fbi.requisition_id)as returned "
                str += "from TB_FILEBORROWITEM fbi "
                str += "inner join TB_REQUISTION rq on rq.id=fbi.requisition_id "
                str += "inner join TB_PATENT_TYPE pt on pt.id=rq.patent_type_id "
                str += "where Convert(VARCHAR(8), fbi.returndate, 112) "
                str += "between '" & date_timestart & "' and '" & date_timestop & "' "
                str += "" & sqlqury & ""
                str += "group by CONVERT(VARCHAR(8),fbi.returndate,112),pt.patent_type_name "
                str += "order by CONVERT(VARCHAR(8),fbi.returndate,112) ASC"
                dt = SqlDB.ExecuteTable(str)
                rpt.SetDataSource(dt)
                If dt.Rows.Count > 0 Then
                    rpt.DataDefinition.FormulaFields("datestart").Text = "'" & date_timestart & "'"
                    rpt.DataDefinition.FormulaFields("datestop").Text = "'" & date_timestop & "'"
                    rpt.DataDefinition.FormulaFields("staff").Text = "'" & frmMain.txtFullUserName.Text & "'"
                    rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
                    crpStatistics.ReportSource = rpt
                Else
                    MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
                    Me.Close()
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class