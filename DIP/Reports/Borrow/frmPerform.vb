Imports DIP_RFID.DAL.Common.Utilities
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmPerform

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

    Private Sub frmPerform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDateFrom.dtDate.Value = Date.Now
        txtDateTo.dtDate.Value = Date.Now
    End Sub

    Private Sub btnPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewReport.Click
        If txtOfficerName.Text = "" Then
            MsgBox("กรุณาตรวจสอบผู้ใช้งาน", MsgBoxStyle.Information)
            txtOfficerName.Focus()
        ElseIf txtDateFrom.dtDate.Value.Date > txtDateTo.dtDate.Value.Date Then
            MsgBox("กรุณาตรวจสอบวันที่", MsgBoxStyle.Information)
        Else
            Dim logonInfo As New TableLogOnInfo
            logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
            logonInfo.ConnectionInfo.UserID = SqlDB.UserID
            logonInfo.ConnectionInfo.Password = SqlDB.Password
            '******************** หา Username และ รหัสพนักงาน *******************
            Dim dt_ As New DataTable
            Dim username As String = ""
            Dim membercode As String = ""
            dt_ = SqlDB.ExecuteTable("select officer_no,username from TB_OFFICER where id = '" & txtOfficerID.Text & "'")
            If dt_.Rows.Count > 0 Then
                username = dt_.Rows(0).Item("username").ToString.Trim
                membercode = dt_.Rows(0).Item("officer_no").ToString.Trim
            End If
            '***************************************************************
            '********** หาข้อมูล Borrow และ Return เพื่อใส่ใน sub report ***********
            Dim dt_borrow As New DataTable
            Dim dt_return As New DataTable

            sql = "select borrowdate,SUM(type1) type1,SUM(type2) type2,SUM(type3) type3 from ("
            sql &= vbCrLf & " select CONVERT(varchar(10), DATEADD(year,543, fb.borrowerdate ),103) borrowdate"
            sql &= vbCrLf & " ,case when rq.patent_type_id = 1 then 1 else 0 end as type1"
            sql &= vbCrLf & " ,case when rq.patent_type_id = 2 then 1 else 0 end as type2"
            sql &= vbCrLf & " ,case when rq.patent_type_id = 3 then 1 else 0 end as type3"
            sql &= vbCrLf & " ,fb.createby "
            sql &= vbCrLf & " from TB_FILEBORROW fb "
            sql &= vbCrLf & " left join TB_FILEBORROWITEM fbi on fb.id = fbi.fileborrow_id "
            sql &= vbCrLf & " left join TB_REQUISTION rq on fbi.requisition_id = rq.id"
            sql &= vbCrLf & " where fb.createby = '" & username & "'"
            sql &= vbCrLf & " and convert(varchar(10),fb.borrowerdate,112) between '" & FixDate(txtDateFrom.dtDate.Value) & "' and '" & FixDate(txtDateTo.dtDate.Value) & "'"
            sql &= vbCrLf & " ) as TB group by borrowdate order by borrowdate desc"
            dt_borrow = SqlDB.ExecuteTable(sql)

            sql = "select returndate,SUM(type1) type1,SUM(type2) type2,SUM(type3) type3 from ("
            sql &= vbCrLf & " select CONVERT(varchar(10), DATEADD(year,543, fbi.returndate ),103) returndate"
            sql &= vbCrLf & " ,case when rq.patent_type_id = 1 then 1 else 0 end as type1"
            sql &= vbCrLf & " ,case when rq.patent_type_id = 2 then 1 else 0 end as type2"
            sql &= vbCrLf & " ,case when rq.patent_type_id = 3 then 1 else 0 end as type3"
            sql &= vbCrLf & " ,fbi.officer_return  "
            sql &= vbCrLf & " from TB_FILEBORROWITEM fbi left join TB_REQUISTION rq on fbi.requisition_id = rq.id"
            sql &= vbCrLf & " where returndate is not null and fbi.officer_return = '" & username & "' "
            sql &= vbCrLf & " and convert(varchar(10),fbi.returndate,112) between '" & FixDate(txtDateFrom.dtDate.Value) & "' and '" & FixDate(txtDateTo.dtDate.Value) & "'"
            sql &= vbCrLf & " ) as TB group by returndate order by returndate desc"
            dt_return = SqlDB.ExecuteTable(sql)
            '***************************************************************

            If dt_borrow.Rows.Count > 0 Or dt_return.Rows.Count > 0 Then
                Dim rpt As New DIP_R016
                Dim f As New ViewReport_CheckOut

                rpt.Subreports(0).SetDataSource(dt_borrow)
                rpt.Subreports(1).SetDataSource(dt_return)

                rpt.DataDefinition.FormulaFields("from_date").Text = "'" & txtDateFrom.TextBox1.Text & "'"
                rpt.DataDefinition.FormulaFields("to_date").Text = "'" & txtDateTo.TextBox1.Text & "'"
                rpt.DataDefinition.FormulaFields("staff").Text = "'" & frmMain.txtFullUserName.Text & "'"
                rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
                rpt.DataDefinition.FormulaFields("membername").Text = "'" & txtOfficerName.Text & "'"
                rpt.DataDefinition.FormulaFields("membercode").Text = "'" & membercode & "'"

                rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
                f.crpCheckOut.ReportSource = rpt
                f.Show()
            Else
                MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
            End If

        End If
    End Sub

End Class