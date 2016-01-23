Imports DIP_RFID.DAL.Common.Utilities
Imports CrystalDecisions.Shared

Public Class frmBorrowWithName

    Private Sub btnPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewReport.Click
        If txtDateFrom.dtDate.Value.Date > txtDateTo.dtDate.Value.Date Then
            MsgBox("กรุณาตรวจสอบวันที่", MsgBoxStyle.Information)
        Else

            Dim dt As New DataTable
            Dim logonInfo As New TableLogOnInfo
            logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
            logonInfo.ConnectionInfo.UserID = SqlDB.UserID
            logonInfo.ConnectionInfo.Password = SqlDB.Password
            date_timestart = FixDate(txtDateFrom.dtDate.Value)
            date_timestop = FixDate(txtDateTo.dtDate.Value)
            'vrSearchName = txtOfficerID.Text

            Dim str As String = ""
            str = "SELECT TB_REQUISTION.app_no,convert(varchar(8),TB_FILEBORROW.borrowerdate,112) "
            str += "as borrowerdate,TB_PATENT_TYPE.patent_type_name"
            str += ",TB_FILEBORROW.borrowername as borrowername,isnull(TT.title_name,'')+"
            str += "OF2.fname+ ' ' +OF2.lname as officercreateby "
            str += "FROM TB_FILEBORROWITEM "
            str += "INNER JOIN TB_REQUISTION ON TB_FILEBORROWITEM.requisition_id = TB_REQUISTION.id "
            str += "INNER JOIN TB_PATENT_TYPE ON TB_REQUISTION.patent_type_id = TB_PATENT_TYPE.id "
            str += "INNER JOIN TB_FILEBORROW ON TB_FILEBORROWITEM.fileborrow_id=TB_FILEBORROW.id "
            str += "INNER JOIN TB_OFFICER ON TB_FILEBORROW.borrower_id=TB_OFFICER.id "
            str += "left JOIN TB_TITLE ON TB_OFFICER.title_id=TB_TITLE.id "
            str += "INNER JOIN TB_OFFICER OF2 ON OF2.username = TB_FILEBORROW.createby "
            str += "left JOIN TB_TITLE TT ON TT.id = OF2.title_id "
            str += "WHERE TB_FILEBORROWITEM.returndate Is NULL "
            str += "and convert(varchar(8),TB_FILEBORROW.createon,112)"
            str += "between '" & date_timestart & "' AND '" & date_timestop & "' "
            'str += "AND TB_FILEBORROW.borrower_id='" & vrSearchName & "' "
            str += "ORDER BY TB_FILEBORROW.borrowerdate ASC"
            dt = SqlDB.ExecuteTable(str)
            If dt.Rows.Count > 0 Then
                Dim rpt As New DIP_R009
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

    Private Sub frmBorrowWithName_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtDateFrom.dtDate.Value = Date.Now
        txtDateTo.dtDate.Value = Date.Now
    End Sub
End Class