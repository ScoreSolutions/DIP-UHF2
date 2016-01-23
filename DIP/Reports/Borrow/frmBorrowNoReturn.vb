Imports DIP_RFID.DAL.Common.Utilities
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmBorrowNoReturn

    Dim dt As New DataTable
    Dim sql As String = ""

    Private Sub btnPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewReport.Click
        If txtOfficerName.Text.Trim = "" Then
            MsgBox("กรุณาตรวจสอบผู้ใช้งาน", MsgBoxStyle.Information)
            btnSearchUser.Focus()
        ElseIf TxtDate1.dtDate.Value.Date > TxtDate2.dtDate.Value.Date Then
            MsgBox("กรุณาตรวจสอบวันที่", MsgBoxStyle.Information)
        Else
            Dim logonInfo As New TableLogOnInfo
            logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
            logonInfo.ConnectionInfo.UserID = SqlDB.UserID
            logonInfo.ConnectionInfo.Password = SqlDB.Password
            sql = "select rq.app_no,fb.borrower_id, isnull(tib.title_name,'')+ofb.fname + ' ' + ofb.lname borrowername,"
            sql &= vbCrLf & " dp.department_name, CONVERT(varchar(10), DATEADD(year,543, fb.borrowerdate),103) borrowdate,"
            sql &= vbCrLf & " 'ยืมที่ห้องแฟ้ม'  borrow_quality, ISNULL(tt.title_name,'') + of2.fname + ' ' + of2.lname staff_name,"
            sql &= vbCrLf & " isnull((select top 1 isnull(t.title_name,'')+f.fname + ' ' + f.lname borrowname"
            sql &= vbCrLf & " from TB_OFFICER f"
            sql &= vbCrLf & " left join TB_TITLE t on t.id=f.title_id"
            sql &= vbCrLf & " inner join TB_FILEBORROW b on b.borrower_id=f.id"
            sql &= vbCrLf & " inner join TB_FILEBORROWITEM bi on b.id=bi.fileborrow_id"
            sql &= vbCrLf & " where(bi.requisition_id = fbi.requisition_id And bi.returndate Is null)"
            sql &= vbCrLf & " ),'ว่าง') file_status"
            sql &= vbCrLf & " from TB_FILEBORROW fb"
            sql &= vbCrLf & " inner join TB_FILEBORROWITEM fbi on fb.id =fbi.fileborrow_id "
            sql &= vbCrLf & " left join TB_OFFICER ofb on ofb.id=fb.borrower_id "
            sql &= vbCrLf & " left join TB_TITLE tib on tib.id=ofb.title_id "
            sql &= vbCrLf & " left join TB_DEPARTMENT dp on dp.id=ofb.department_id"
            sql &= vbCrLf & " inner join TB_REQUISTION rq on rq.id =fbi.requisition_id "
            sql &= vbCrLf & " inner join TB_OFFICER OF2 on of2.username = fb.createby "
            sql &= vbCrLf & " left join TB_TITLE TT on tt.id =of2.title_id "
            sql &= vbCrLf & " where(fbi.returndate Is null)"
            sql &= vbCrLf & " and convert(varchar(10),fb.borrowerdate,112) between '" & FixDate(TxtDate1.dtDate.Value) & "' and '" & FixDate(TxtDate2.dtDate.Value) & "'"
            sql &= vbCrLf & " and fb.borrower_id = '" & txtOfficerID.Text & "'"
            sql &= vbCrLf & " union all "
            sql &= vbCrLf & " select rq.app_no, re.officer_id_receive, ISNULL(tir.title_name,'')+ofr.fname + ' ' + ofr.lname borrowername,"
            sql &= vbCrLf & " dp.department_name, CONVERT(varchar(10), DATEADD(year,543, re.reserve_date),103) transfer_date,"
            sql &= vbCrLf & " 'ยืมโดยการโอน',ISNULL(ti.title_name,'') + ofo.fname + ' ' + ofo.lname staff_name,"
            sql &= vbCrLf & " isnull((select top 1 isnull(t.title_name,'')+f.fname + ' ' + f.lname borrowname"
            sql &= vbCrLf & " from TB_OFFICER f"
            sql &= vbCrLf & " left join TB_TITLE t on t.id=f.title_id"
            sql &= vbCrLf & " inner join TB_FILEBORROW b on b.borrower_id=f.id"
            sql &= vbCrLf & " inner join TB_FILEBORROWITEM bi on b.id=bi.fileborrow_id"
            sql &= vbCrLf & " where(bi.requisition_id = rq.id And bi.returndate Is null)"
            sql &= vbCrLf & " ),'ว่าง') file_status"
            sql &= vbCrLf & " from TB_RESERVE re"
            sql &= vbCrLf & " inner join TB_REQUISTION rq on rq.id=re.requidition_id"
            sql &= vbCrLf & " left join TB_OFFICER ofr on ofr.id=re.officer_id_receive"
            sql &= vbCrLf & " left join TB_TITLE tir on tir.id=ofr.title_id"
            sql &= vbCrLf & " left join TB_DEPARTMENT dp on dp.id=ofr.department_id"
            sql &= vbCrLf & " inner join TB_OFFICER ofo on ofo.id=re.member_id"
            sql &= vbCrLf & " left join TB_TITLE ti on ti.id=ofo.title_id"
            sql &= vbCrLf & " left join (select bi.requisition_id"
            sql &= vbCrLf & " from TB_FILEBORROW b "
            sql &= vbCrLf & " inner join TB_FILEBORROWITEM bi on b.id=bi.fileborrow_id"
            sql &= vbCrLf & " where  bi.returndate is null) b on b.requisition_id=rq.id"
            sql &= vbCrLf & " where re.borrowstatus='T' and b.requisition_id is null"
            sql &= vbCrLf & " and convert(varchar(10),re.reserve_date,112) between '" & FixDate(TxtDate1.dtDate.Value) & "' and '" & FixDate(TxtDate2.dtDate.Value) & "'"
            sql &= vbCrLf & " and re.officer_id_receive ='" & txtOfficerID.Text & "'"
            dt = SqlDB.ExecuteTable(sql)
            If dt.Rows.Count > 0 Then
                Dim rpt As New DIP_R008
                Dim f As New ViewReport_CheckOut
                rpt.SetDataSource(dt)
                rpt.DataDefinition.FormulaFields("from_date").Text = "'" & TxtDate1.TextBox1.Text & "'"
                rpt.DataDefinition.FormulaFields("to_date").Text = "'" & TxtDate2.TextBox1.Text & "'"
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

    Private Sub btnSearchUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchUser.Click
        Dim f As New frmReserveOfficer
        f.ShowDialog()
        If f.DialogResult <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If
        txtOfficerName.Text = f.Name
        txtOfficerID.Text = f.OfficerID
    End Sub

    Private Sub frmBorrowNoReturn_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        TxtDate1.dtDate.Value = Date.Now
        TxtDate2.dtDate.Value = Date.Now
    End Sub
End Class