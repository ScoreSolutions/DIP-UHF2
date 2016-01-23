Imports DIP_RFID.DAL.Common.Utilities

Public Class frmTransferByLocation

    Dim dt As New DataTable
    Dim sql As String = ""
    Private Sub btnPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewReport.Click
        'If TxtDate1.dtDate.Value.Date > TxtDate2.dtDate.Value.Date Then
        '    MsgBox("กรุณาตรวจสอบวันที่", MsgBoxStyle.Information)
        'Else
        'sql = "select rq.app_no,fb.borrower_id, isnull(tib.title_name,'')+ofb.fname + ' ' + ofb.lname borrowername,"
        'sql &= vbCrLf & " where re.borrowstatus='T' and b.requisition_id is null"
        'sql &= vbCrLf & " and convert(varchar(10),re.reserve_date,112) between '" & FixDate(TxtDate1.dtDate.Value) & "' and '" & FixDate(TxtDate2.dtDate.Value) & "'"
        'sql &= vbCrLf & " and re.officer_id_receive ='" & txtOfficerID.Text & "'"

        sql = " SELECT "
        sql &= " LG.app_no,"
        sql &= " convert(varchar,dateadd(year,543,LG.log_date),103)  as log_date,"
        sql &= " convert(varchar,LG.log_date,108)  as log_time,"
        'sql &= " (case readerid "
        'sql &= " when 1 then 'ชั้น 6' "
        'sql &= " when 2 then 'ชั้น 1/1' "
        'sql &= " when 3 then 'ชั้น 1/2'"
        'sql &= " End"
        'sql &= " ) as location,"
        sql &= " FL.Location_Name  as location,"
        sql &= "'" & frmMain.txtFullUserName.Text & "'  as staff,"
        sql &= "'" & Date.Now.ToShortDateString & "'  as printdate"
        sql &= " FROM TB_LOG_LOCATION LG  "
        sql &= " LEFT JOIN  TB_FILELOCATION FL ON FL.READERID = LG.READERID  where 1=1 "
        If TxtDate1.TextBox1.Text <> "" And TxtDate2.TextBox1.Text <> "" Then
            sql &= " and convert(varchar(10),log_date,112) between '" & FixDate(TxtDate1.dtDate.Value) & "' and '" & FixDate(TxtDate2.dtDate.Value) & "'"
        End If
        If cmblocation.SelectedIndex <> 0 Then
            sql &= " and readerid ='" & cmblocation.SelectedValue & "'"
        End If



        dt = SqlDB.ExecuteTable(sql)
        If dt.Rows.Count > 0 Then
            dt.TableName = "dsTransferHistory"
            Dim ds As New DataSet
            ds.Tables.Add(dt)
            Dim rep As New rptTransferHistory
            With ds
                For i As Integer = 0 To .Tables.Count - 1
                    rep.Database.Tables(.Tables(i).TableName).SetDataSource(.Tables(i))
                Next
            End With
            rep.SetDataSource(dt)
            Dim cryViewer As New frmReportPreview
            cryViewer.CrystalReportViewer1.ReportSource = rep
            cryViewer.CrystalReportViewer1.Refresh()
            cryViewer.WindowState = FormWindowState.Maximized
            cryViewer.Show()
        Else
            MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
        End If




        'Dim ds As New DataSet
        'ds.Tables.Add(dt)
        'ds.WriteXmlSchema("C:\dsTransferHistory.xsd")

        'If dt.Rows.Count > 0 Then
        '    Dim rpt As New DIP_R008
        '    Dim f As New ViewReport_CheckOut
        '    rpt.SetDataSource(dt)
        '    rpt.DataDefinition.FormulaFields("from_date").Text = "'" & TxtDate1.TextBox1.Text & "'"
        '    rpt.DataDefinition.FormulaFields("to_date").Text = "'" & TxtDate2.TextBox1.Text & "'"
        '    rpt.DataDefinition.FormulaFields("staff").Text = "'" & frmMain.txtFullUserName.Text & "'"
        '    rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
        '    rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
        '    f.crpCheckOut.ReportSource = rpt
        '    f.Show()
        'Else
        '    MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
        'End If
        '  End If
    End Sub

    Private Sub frmTransferByLocation_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim strReaderID As String
        Dim dt As DataTable
        strReaderID = " SELECT 1 as ID, 'ชั้น 6' as Location"
        strReaderID &= " UNION"
        strReaderID &= " SELECT 2 as ID, 'ชั้น 1/1' as Location"
        strReaderID &= " UNION"
        strReaderID &= " SELECT 3 as ID, 'ชั้น 1/2' as Location"
        dt = SqlDB.ExecuteTable(strReaderID)



        Dim dr As DataRow = dt.NewRow
        dr("id") = "0"
        dr("Location") = "---------------------เลือก---------------------"
        dt.Rows.InsertAt(dr, 0)
        With cmblocation
            .DataSource = dt
            .ValueMember = "id"
            .DisplayMember = "Location"
        End With
    End Sub

 
End Class