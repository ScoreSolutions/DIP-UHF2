Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.Common.Utilities
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmBorrowByOfficer

    Dim dt As New DataTable
    Dim sql As String = ""

    Private Sub btnPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewReport.Click
        If txtOfficerName.Text.Trim = "" Then
            MsgBox("กรุณาตรวจสอบผู้ใช้งาน", MsgBoxStyle.Information)
            btnSearchUser.Focus()
        ElseIf txtDateFrom.dtDate.Value.Date > txtDateTo.dtDate.Value.Date Then
            MsgBox("กรุณาตรวจสอบวันที่", MsgBoxStyle.Information)
        Else
            Dim logonInfo As New TableLogOnInfo
            logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
            logonInfo.ConnectionInfo.UserID = SqlDB.UserID
            logonInfo.ConnectionInfo.Password = SqlDB.Password
            Dim sql1 As String = ""
            Dim sql2 As String = ""
            sql1 = "select rq.app_no,CONVERT(varchar(10), DATEADD(year,543, fb.borrowerdate),103) borrowdate,"
            sql1 &= vbCrLf & " 'ยืมที่ห้องแฟ้ม'  borrow_quality,fb.borrower_id, ISNULL(tt.title_name,'') + of2.fname + ' ' ++ of2.lname staff_name"
            sql1 &= vbCrLf & " from TB_FILEBORROW fb"
            sql1 &= vbCrLf & " inner join TB_FILEBORROWITEM fbi on fb.id =fbi.fileborrow_id "
            sql1 &= vbCrLf & " inner join TB_REQUISTION rq on rq.id =fbi.requisition_id "
            sql1 &= vbCrLf & " inner join TB_OFFICER OF2 on of2.username = fb.createby "
            sql1 &= vbCrLf & " left join TB_TITLE TT on tt.id =of2.title_id "
            sql1 &= vbCrLf & " inner join TB_RESERVE re on re.id = fbi.reserve_id "
            sql1 &= vbCrLf & " where fb.borrower_id  ='" & txtOfficerID.Text & "'"
            sql1 &= vbCrLf & " and convert(varchar(10),fb.borrowerdate,112) between '" & FixDate(txtDateFrom.dtDate.Value) & "' and '" & FixDate(txtDateTo.dtDate.Value) & "'"

            sql2 = "select rq.app_no, CONVERT(varchar(10), DATEADD(year,543, re.reserve_date),103) transfer_date,"
            sql2 &= vbCrLf & " 'ยืมโดยการโอน',re.member_id,ISNULL(ti.title_name,'') + ofo.fname + ' ' + ofo.lname staff_name"
            sql2 &= vbCrLf & " from TB_RESERVE re"
            sql2 &= vbCrLf & " inner join TB_REQUISTION rq on rq.id=re.requidition_id"
            sql2 &= vbCrLf & " inner join TB_OFFICER ofo on ofo.id=re.member_id"
            sql2 &= vbCrLf & " left join TB_TITLE ti on ti.id=ofo.title_id"
            sql2 &= vbCrLf & " where re.borrowstatus='T'"
            sql2 &= vbCrLf & " and re.officer_id_receive  ='" & txtOfficerID.Text & "'"
            sql2 &= vbCrLf & " and convert(varchar(10),re.reserve_date,112) between '" & FixDate(txtDateFrom.dtDate.Value) & "' and '" & FixDate(txtDateTo.dtDate.Value) & "'"

            If rdiBorrowQualityBorrow.Checked Then
                sql = sql1
            ElseIf rdiBorrowQualityTransfer.Checked Then
                sql = sql2
            Else
                sql = sql1 & vbCrLf & " union all " & vbCrLf & sql2
            End If
            dt = SqlDB.ExecuteTable(sql)
            If dt.Rows.Count > 0 Then
                Dim rpt As New DIP_R004
                Dim f As New ViewReport_CheckOut
                rpt.SetDataSource(dt)
                rpt.DataDefinition.FormulaFields("from_date").Text = "'" & txtDateFrom.TextBox1.Text & "'"
                rpt.DataDefinition.FormulaFields("to_date").Text = "'" & txtDateTo.TextBox1.Text & "'"
                rpt.DataDefinition.FormulaFields("staff").Text = "'" & frmMain.txtFullUserName.Text & "'"
                rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
                rpt.DataDefinition.FormulaFields("member_name").Text = "'" & txtOfficerName.Text & "'"
                Dim dal As New TbOfficerDAL
                Dim dt_department As New DataTable
                dt_department = dal.GetListBySql("select y.department_name  from TB_OFFICER x left join TB_DEPARTMENT y on x.department_id = y.id where x.id = '" & txtOfficerID.Text & "'", "", Nothing)
                If dt_department.Rows.Count > 0 Then
                    rpt.DataDefinition.FormulaFields("member_department").Text = "'" & dt_department.Rows(0).Item("department_name").ToString & "'"
                End If
                rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
                f.crpCheckOut.ReportSource = rpt
                f.Show()
            Else
                MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
            End If



        End If
    End Sub

    Private Sub frmBorrowByOfficer_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtDateFrom.dtDate.Value = Date.Now
        txtDateTo.dtDate.Value = Date.Now
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
End Class