Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.Common.Utilities
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmGraphByDepartment

    Dim dt As New DataTable
    Dim sql As String = ""

    Private Sub frmGraphByDepartment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dal As New TbDepartmentDAL
        Dim dt As DataTable = dal.GetDataList("", "department_name", Nothing)
        Dim dr As DataRow = dt.NewRow
        dr("id") = "0"
        dr("department_name") = "-------------------เลือก----------------"
        dt.Rows.InsertAt(dr, 0)
        With cmbDepartment
            .DataSource = dt
            .ValueMember = "id"
            .DisplayMember = "department_name"
        End With
        TxtDate1.dtDate.Value = Date.Now
        TxtDate2.dtDate.Value = Date.Now
    End Sub

    Private Sub btnPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewReport.Click
        If TxtDate1.dtDate.Value.Date > TxtDate2.dtDate.Value.Date Then
            MsgBox("กรุณาตรวจสอบวันที่", MsgBoxStyle.Information)
        ElseIf cmbDepartment.SelectedIndex = 0 Then
            MsgBox("กรุณาเลือกสังกัด", MsgBoxStyle.Information)
        Else
            Dim logonInfo As New TableLogOnInfo
            logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
            logonInfo.ConnectionInfo.UserID = SqlDB.UserID
            logonInfo.ConnectionInfo.Password = SqlDB.Password

            sql = "declare @f_date as varchar(8); select @f_date = '" & FixDate(TxtDate1.dtDate.Value) & "'"
            sql &= vbCrLf & " declare @t_date as varchar(8); select @t_date = '" & FixDate(TxtDate2.dtDate.Value) & "' "
            sql &= vbCrLf & " declare @dpm as varchar(10); select @dpm = '" & cmbDepartment.SelectedValue.ToString & "'"
            sql &= vbCrLf & " select SUM(data) as data,'ยืม' as txt from ("
            sql &= vbCrLf & " select COUNT(1) as data from TB_FILEBORROW fb left join TB_FILEBORROWITEM fbi on fb.id = fbi.fileborrow_id "
            sql &= vbCrLf & " left join TB_OFFICER ofc on fb.borrower_id = ofc.id"
            sql &= vbCrLf & " where convert(varchar(10),fb.borrowerdate,112) between @f_date and @t_date"
            sql &= vbCrLf & " and ofc.department_id = @dpm"
            sql &= vbCrLf & " Union all"
            sql &= vbCrLf & " select COUNT(1) as data from TB_RESERVE re"
            sql &= vbCrLf & " left join TB_OFFICER ofc on re.member_id = ofc.id"
            sql &= vbCrLf & " where borrowstatus = 'T' and convert(varchar(10),reserve_date,112) between @f_date and @t_date"
            sql &= vbCrLf & " and ofc.department_id = @dpm"
            sql &= vbCrLf & " ) as TB"
            sql &= vbCrLf & " Union all"
            sql &= vbCrLf & " select SUM(data) as data,'คืน' as txt from ("
            sql &= vbCrLf & " select COUNT(1) as data from TB_FILEBORROW fb left join TB_FILEBORROWITEM fbi on fb.id = fbi.fileborrow_id "
            sql &= vbCrLf & " left join TB_OFFICER ofc on fb.borrower_id = ofc.id"
            sql &= vbCrLf & " where(fbi.returndate Is Not null)"
            sql &= vbCrLf & " and convert(varchar(10),fb.borrowerdate,112) between @f_date and @t_date"
            sql &= vbCrLf & " and ofc.department_id = @dpm"
            sql &= vbCrLf & " Union all"
            sql &= vbCrLf & " select COUNT(1) as data from TB_RESERVE re"
            sql &= vbCrLf & " left join TB_OFFICER ofc on re.member_id = ofc.id"
            sql &= vbCrLf & " where borrowstatus = 'R' and convert(varchar(10),reserve_date,112) between @f_date and @t_date"
            sql &= vbCrLf & " and ofc.department_id = @dpm"
            sql &= vbCrLf & " ) as TB"

            dt = SqlDB.ExecuteTable(sql)
            If CInt(dt.Rows(0).Item("data").ToString) <> 0 Or CInt(dt.Rows(1).Item("data").ToString) <> 0 Then
                Dim rpt As New DIP_R019
                Dim f As New ViewReportGraph
                rpt.SetDataSource(dt)
                rpt.DataDefinition.FormulaFields("from_date").Text = "'" & TxtDate1.TextBox1.Text & "'"
                rpt.DataDefinition.FormulaFields("to_date").Text = "'" & TxtDate2.TextBox1.Text & "'"
                rpt.DataDefinition.FormulaFields("staff").Text = "'" & frmMain.txtFullUserName.Text & "'"
                rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
                rpt.DataDefinition.FormulaFields("department").Text = "'" & cmbDepartment.Text & "'"
                rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
                f.crpGraph.ReportSource = rpt
                f.Show()
            Else
                MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
            End If
        End If
    End Sub
End Class