Imports DIP_RFID.DAL.Common.Utilities
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmGraphByOfficer

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

    Private Sub frmGraphByOfficer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtDate1.dtDate.Value = Date.Now
        TxtDate2.dtDate.Value = Date.Now
    End Sub

    Private Sub btnPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewReport.Click
        If txtOfficerID.Text = "" Then
            MsgBox("กรุณาตรวจสอบผู้ใช้งาน", MsgBoxStyle.Information)
        ElseIf TxtDate1.dtDate.Value.Date > TxtDate2.dtDate.Value.Date Then
            MsgBox("กรุณาตรวจสอบวันที่", MsgBoxStyle.Information)
        Else
            Dim logonInfo As New TableLogOnInfo
            logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
            logonInfo.ConnectionInfo.UserID = SqlDB.UserID
            logonInfo.ConnectionInfo.Password = SqlDB.Password
            Dim dt_ As New DataTable
            Dim username As String = ""
            sql = "select username from TB_OFFICER where id = '" & txtOfficerID.Text & "'"
            dt_ = SqlDB.ExecuteTable(sql)
            If dt_.Rows.Count > 0 Then
                username = dt_.Rows(0).Item("username").ToString.Trim
            End If

            sql = "declare @f_date as varchar(8); select @f_date = '" & FixDate(TxtDate1.dtDate.Value) & "'"
            sql &= vbCrLf & " declare @t_date as varchar(8); select @t_date = '" & FixDate(TxtDate2.dtDate.Value) & "' "
            sql &= vbCrLf & " declare @user as varchar(20); select @user = '" & username & "'"
            sql &= vbCrLf & " select SUM(data) as data,'ยืม' as txt from ("
            sql &= vbCrLf & " select COUNT(1) as data from TB_FILEBORROW fb left join TB_FILEBORROWITEM fbi on fb.id = fbi.fileborrow_id "
            sql &= vbCrLf & " where convert(varchar(10),fb.borrowerdate,112) between @f_date and @t_date"
            sql &= vbCrLf & " and fb.createby = @user"
            sql &= vbCrLf & " union all"
            sql &= vbCrLf & " select COUNT(1) as data from TB_RESERVE re"
            sql &= vbCrLf & " left join TB_OFFICER ofc on re.officer_id_receive = ofc.id"
            sql &= vbCrLf & " where borrowstatus = 'T' and convert(varchar(10),reserve_date,112) between @f_date and @t_date"
            sql &= vbCrLf & " and ofc.username = @user"
            sql &= vbCrLf & " ) as TB"
            sql &= vbCrLf & " union all"
            sql &= vbCrLf & " select SUM(data) as data,'คืน' as txt from ("
            sql &= vbCrLf & " select COUNT(1) as data from TB_FILEBORROW fb left join TB_FILEBORROWITEM fbi on fb.id = fbi.fileborrow_id "
            sql &= vbCrLf & " where(fbi.returndate Is Not null)"
            sql &= vbCrLf & " and convert(varchar(10),fb.borrowerdate,112) between @f_date and @t_date"
            sql &= vbCrLf & " and fbi.officer_return = @user"
            sql &= vbCrLf & " union all"
            sql &= vbCrLf & " select COUNT(1) as data from TB_RESERVE re"
            sql &= vbCrLf & " left join TB_OFFICER ofc on re.officer_id_receive = ofc.id"
            sql &= vbCrLf & " where borrowstatus = 'R' and convert(varchar(10),reserve_date,112) between @f_date and @t_date"
            sql &= vbCrLf & " and ofc.username = @user"
            sql &= vbCrLf & " ) as TB"
            dt = SqlDB.ExecuteTable(sql)
            If CInt(dt.Rows(0).Item("data").ToString) <> 0 Or CInt(dt.Rows(1).Item("data").ToString) <> 0 Then
                Dim rpt As New DIP_R021
                Dim f As New ViewReportGraph
                rpt.SetDataSource(dt)
                rpt.DataDefinition.FormulaFields("from_date").Text = "'" & TxtDate1.TextBox1.Text & "'"
                rpt.DataDefinition.FormulaFields("to_date").Text = "'" & TxtDate2.TextBox1.Text & "'"
                rpt.DataDefinition.FormulaFields("staff").Text = "'" & frmMain.txtFullUserName.Text & "'"
                rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
                rpt.DataDefinition.FormulaFields("user").Text = "'" & txtOfficerName.Text & "'"
                rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
                f.crpGraph.ReportSource = rpt
                f.Show()
            Else
                MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
            End If
        End If

    End Sub
End Class