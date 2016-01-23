Imports DIP_RFID.DAL.Common.Utilities
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmGraphAll

    Dim dt As New DataTable
    Dim sql As String = ""

    Private Sub btnPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewReport.Click
        If txtDateFrom.dtDate.Value.Date > txtDateTo.dtDate.Value.Date Then
            MsgBox("กรุณาตรวจสอบวันที่", MsgBoxStyle.Information)
        Else
            Dim logonInfo As New TableLogOnInfo
            logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
            logonInfo.ConnectionInfo.UserID = SqlDB.UserID
            logonInfo.ConnectionInfo.Password = SqlDB.Password

            sql = "declare @f_date as varchar(8); select @f_date = '" & FixDate(txtDateFrom.dtDate.Value) & "'"
            sql &= vbCrLf & " declare @t_date as varchar(8); select @t_date = '" & FixDate(txtDateTo.dtDate.Value) & "' "
            sql &= vbCrLf & " select SUM(data) as data,'ยืม' as txt from ("
            sql &= vbCrLf & " select COUNT(1) as data from TB_FILEBORROW fb left join TB_FILEBORROWITEM fbi on fb.id = fbi.fileborrow_id "
            sql &= vbCrLf & " where convert(varchar(10),fb.borrowerdate,112) between @f_date and @t_date"
            sql &= vbCrLf & " union all"
            sql &= vbCrLf & " select COUNT(1) as data from TB_RESERVE re"
            sql &= vbCrLf & " where borrowstatus = 'T' and convert(varchar(10),reserve_date,112) between @f_date and @t_date"
            sql &= vbCrLf & " ) as TB"
            sql &= vbCrLf & " union all"
            sql &= vbCrLf & " select SUM(data) as data,'คืน' as txt from ("
            sql &= vbCrLf & " select COUNT(1) as data from TB_FILEBORROWITEM "
            sql &= vbCrLf & " where(returndate Is Not null)"
            sql &= vbCrLf & " and convert(varchar(10),returndate,112) between @f_date and @t_date"
            sql &= vbCrLf & " union all"
            sql &= vbCrLf & " select COUNT(1) as data from TB_RESERVE "
            sql &= vbCrLf & " where borrowstatus = 'R' and convert(varchar(10),reserve_date,112) between @f_date and @t_date"
            sql &= vbCrLf & " ) as TB"

            dt = SqlDB.ExecuteTable(sql)
            If CInt(dt.Rows(0).Item("data").ToString) <> 0 Or CInt(dt.Rows(1).Item("data").ToString) <> 0 Then
                Dim rpt As New DIP_R018
                Dim f As New ViewReportGraph
                rpt.SetDataSource(dt)
                rpt.DataDefinition.FormulaFields("from_date").Text = "'" & txtDateFrom.TextBox1.Text & "'"
                rpt.DataDefinition.FormulaFields("to_date").Text = "'" & txtDateTo.TextBox1.Text & "'"
                rpt.DataDefinition.FormulaFields("staff").Text = "'" & frmMain.txtFullUserName.Text & "'"
                rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"

                rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
                f.crpGraph.ReportSource = rpt
                f.Show()
            Else
                MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
            End If

        End If

    End Sub

    Private Sub frmGraphAll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDateFrom.dtDate.Value = Date.Now
        txtDateTo.dtDate.Value = Date.Now
    End Sub
End Class