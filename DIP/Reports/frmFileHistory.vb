Imports DIP_RFID.DAL.Common.Utilities
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmFileHistory

    Dim dt As New DataTable
    Dim sql As String = ""
    
    Private Sub frmFileHistory_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtDateFrom.dtDate.Value = Date.Now
        txtDateTo.dtDate.Value = Date.Now
    End Sub

    Private Sub btnPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewReport.Click
        If txtAppNo.Text = "" Then
            MsgBox("กรุณาตรวจสอบเลขที่คำขอ", MsgBoxStyle.Information)
            txtAppNo.Focus()
        Else
            Dim logonInfo As New TableLogOnInfo
            logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
            logonInfo.ConnectionInfo.UserID = SqlDB.UserID
            logonInfo.ConnectionInfo.Password = SqlDB.Password

            sql = "select rq.app_no,CONVERT(varchar(10), DATEADD(year,543, re.reserve_date),103) reserve_date,re.member_name"
            sql &= vbCrLf & " ,case when re.borrowstatus = 'T' then re.member_name else fb.borrowername  end borrowname  "
            sql &= vbCrLf & " ,case when re.borrowstatus = 'T' then CONVERT(varchar(10), DATEADD(year,543, re.reserve_date),103) else CONVERT(varchar(10), DATEADD(year,543, fb.borrowerdate ),103)  end borrowdate"
            sql &= vbCrLf & " ,case when re.borrowstatus = 'T' then 'ยืมโดยการโอน' else case when isnull(fb.borrowerdate,'') = '' then '' else 'ยืมที่ห้องแฟ้ม' end end borrow_quality "
            sql &= vbCrLf & " ,case when re.borrowstatus = 'T' then re.member_name else case when isnull(fb.borrowerdate,'') = '' then '' else ISNULL(tt1.title_name,'') + of1.fname + ' ' + of1.lname end end staff_borrow "
            sql &= vbCrLf & " ,case when re.borrowstatus = 'R' then CONVERT(varchar(10), DATEADD(year,543, re.reserve_date),103) else CONVERT(varchar(10), DATEADD(year,543, fbi.returndate ),103)  end returndate"
            sql &= vbCrLf & " ,case when re.borrowstatus = 'R' then 'คืนโดยการโอน' else case when isnull(fbi.returndate,'') = '' then '' else 'คืนที่ห้องแฟ้ม' end end return_quality "
            sql &= vbCrLf & " ,case when re.borrowstatus = 'R' then re.member_name else case when isnull(fbi.returndate,'') = '' then '' else ISNULL(tt2.title_name,'') + of2.fname + ' ' + of2.lname end end staff_return"
            sql &= vbCrLf & " from TB_RESERVE re "
            sql &= vbCrLf & " left join TB_REQUISTION rq on re.requidition_id = rq.id "
            sql &= vbCrLf & " left join TB_RESERVE_JOB rej on re.reserve_job_id = rej.id"
            sql &= vbCrLf & " left join TB_FILEBORROW fb on re.reserve_job_id = fb.reserve_job_id"
            sql &= vbCrLf & " left join TB_FILEBORROWITEM fbi on fb.id = fbi.fileborrow_id and re.requidition_id = fbi.requisition_id"
            sql &= vbCrLf & " left join TB_OFFICER of1 on fb.createby = of1.username "
            sql &= vbCrLf & " left join TB_TITLE tt1 on of1.title_id = tt1.id"
            sql &= vbCrLf & " left join TB_OFFICER of2 on fbi.officer_return = of2.username "
            sql &= vbCrLf & " left join TB_TITLE tt2 on of2.title_id = tt2.id"
            sql &= vbCrLf & " where re.reserve_job_id Is Not null"
            sql &= vbCrLf & " and rq.app_no = '" & txtAppNo.Text.Trim.Replace("'", "''") & "'"

            dt = SqlDB.ExecuteTable(sql)
            If dt.Rows.Count > 0 Then
                Dim rpt As New DIP_R017
                Dim f As New ViewReport_CheckOut
                rpt.SetDataSource(dt)
                rpt.DataDefinition.FormulaFields("staff").Text = "'" & frmMain.txtFullUserName.Text & "'"
                rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
                rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
                f.crpCheckOut.ReportSource = rpt
                f.Show()
            Else
                MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
            End If

        End If
    End Sub
End Class