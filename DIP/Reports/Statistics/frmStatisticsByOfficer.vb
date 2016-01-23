Imports DIP_RFID.DAL.Common.Utilities
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmStatisticsByOfficer

    Dim dt As New DataTable
    Dim sql As String = ""

    Private Sub btnSearchUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchUser.Click
        Dim f As New frmReserveOfficer
        f.ShowDialog()
        If f.DialogResult <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If
        txtOfficerName.Text = f.Name
        txtOfficerID.Text = f.OfficerID
    End Sub

    Private Sub btnPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewReport.Click
        If txtOfficerName.Text = "" Then
            MsgBox("กรุณาตรวจสอบผู้ใช้งาน", MsgBoxStyle.Information)
            txtOfficerName.Focus()
        ElseIf date_timestart > date_timestop Then
            MsgBox("กรุณาตรวจสอบวันที่", MsgBoxStyle.Information)
        Else
            Dim logonInfo As New TableLogOnInfo
            logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
            logonInfo.ConnectionInfo.UserID = SqlDB.UserID
            logonInfo.ConnectionInfo.Password = SqlDB.Password

            sql = "select rq.app_no,CONVERT(varchar(10), DATEADD(year,543, fb.borrowerdate),103) borrowdate,"
            sql &= vbCrLf & " 'ยืมที่ห้องแฟ้ม'  borrow_quality,fb.borrower_id, ISNULL(tt1.title_name,'') + of1.fname + ' ' ++ of1.lname staff_name"
            sql &= vbCrLf & " ,CONVERT(varchar(10), DATEADD(year,543, fbi.returndate),103) returndate "
            sql &= vbCrLf & " ,case when ISNULL(returndate,'') <> '' then 'คืนที่ห้องแฟ้ม' else '' end return_quality"
            sql &= vbCrLf & " ,ISNULL(tt2.title_name,'') + of2.fname + ' ' ++ of2.lname return_staff_name"
            sql &= vbCrLf & " from TB_FILEBORROW fb"
            sql &= vbCrLf & " inner join TB_FILEBORROWITEM fbi on fb.id =fbi.fileborrow_id "
            sql &= vbCrLf & " inner join TB_REQUISTION rq on rq.id =fbi.requisition_id "
            sql &= vbCrLf & " inner join TB_OFFICER OF1 on of1.username = fb.createby "
            sql &= vbCrLf & " left join TB_TITLE TT1 on tt1.id =of1.title_id "
            sql &= vbCrLf & " inner join TB_RESERVE re on re.id = fbi.reserve_id "
            sql &= vbCrLf & " left join TB_OFFICER OF2 on of2.username = fbi.officer_return  "
            sql &= vbCrLf & " left join TB_TITLE TT2 on tt2.id =of2.title_id "
            sql &= vbCrLf & " where fb.borrower_id  ='" & txtOfficerID.Text & "'"
            sql &= vbCrLf & " and convert(varchar(10),fb.borrowerdate,112) between '" & FixDate(txtDateFrom.dtDate.Value) & "' and '" & FixDate(txtDateTo.dtDate.Value) & "'"
            sql &= vbCrLf & " union all"
            sql &= vbCrLf & " Select rq.app_no"
            sql &= vbCrLf & " ,case when re.borrowstatus = 'T' then CONVERT(varchar(10), DATEADD(year,543, re.reserve_date),103) else '' end borrowdate"
            sql &= vbCrLf & " ,case when re.borrowstatus = 'T' then 'ยืมโดยการโอน' else '' end borrow_quality"
            sql &= vbCrLf & " ,re.member_id borrower_id "
            sql &= vbCrLf & " ,case when re.borrowstatus = 'T' then ISNULL(ti.title_name,'') + ofo.fname + ' ' + ofo.lname else '' end staff_name"
            sql &= vbCrLf & " ,case when re.borrowstatus = 'R' then CONVERT(varchar(10), DATEADD(year,543, re.reserve_date),103) else '' end returndate"
            sql &= vbCrLf & " ,case when re.borrowstatus = 'R' then 'คืนโดยการโอน' else '' end return_quality"
            sql &= vbCrLf & " ,case when re.borrowstatus = 'R' then ISNULL(ti.title_name,'') + ofo.fname + ' ' + ofo.lname else '' end return_staff_name"
            sql &= vbCrLf & " from TB_RESERVE re"
            sql &= vbCrLf & " inner join TB_REQUISTION rq on rq.id=re.requidition_id"
            sql &= vbCrLf & " inner join TB_OFFICER ofo on ofo.id=re.member_id"
            sql &= vbCrLf & " left join TB_TITLE ti on ti.id=ofo.title_id"
            sql &= vbCrLf & " where re.borrowstatus in ('T','R')"
            sql &= vbCrLf & " and re.officer_id_receive  ='" & txtOfficerID.Text & "'"
            sql &= vbCrLf & " and convert(varchar(10),re.reserve_date,112) between '" & FixDate(txtDateFrom.dtDate.Value) & "' and '" & FixDate(txtDateTo.dtDate.Value) & "'"

            dt = SqlDB.ExecuteTable(sql)
            If dt.Rows.Count > 0 Then
                Dim rpt As New DIP_R015
                Dim f As New ViewReport_CheckOut
                rpt.SetDataSource(dt)
                rpt.DataDefinition.FormulaFields("from_date").Text = "'" & txtDateFrom.TextBox1.Text & "'"
                rpt.DataDefinition.FormulaFields("to_date").Text = "'" & txtDateTo.TextBox1.Text & "'"
                rpt.DataDefinition.FormulaFields("staff").Text = "'" & frmMain.txtFullUserName.Text & "'"
                rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
                rpt.DataDefinition.FormulaFields("membername").Text = "'" & txtOfficerName.Text & "'"

                Dim dt_ As New DataTable
                dt_ = SqlDB.ExecuteTable("select officer_no,department_name  from TB_OFFICER x left join TB_DEPARTMENT y on x.department_id = y.id where x.id = '" & txtOfficerID.Text & "'")
                If dt_.Rows.Count > 0 Then
                    rpt.DataDefinition.FormulaFields("membercode").Text = "'" & dt_.Rows(0).Item("officer_no").ToString & "'"
                    rpt.DataDefinition.FormulaFields("group").Text = "'" & dt_.Rows(0).Item("department_name").ToString & "'"
                End If

                rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
                f.crpCheckOut.ReportSource = rpt
                f.Show()
            Else
                MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
            End If

        End If
    End Sub

    Private Sub frmStatisticsByOfficer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDateFrom.dtDate.Value = Date.Now
        txtDateTo.dtDate.Value = Date.Now
    End Sub
End Class