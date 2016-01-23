Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.Common.Utilities
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmGraphByPatentType

    Dim dt As New DataTable
    Dim sql As String = ""

    Private Sub frmGraphByPatentType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dal As New TbPatentTypeDAL
        Dim dt As DataTable = dal.GetDataList("1=1", "patent_type_name", Nothing)
        Dim dr As DataRow = dt.NewRow
        dr("id") = 0
        dr("patent_type_name") = "-----------ทั้งหมด-----------"
        dt.Rows.InsertAt(dr, 0)
        cmbPatentType.DataSource = dt
        cmbPatentType.DisplayMember = "patent_type_name"
        cmbPatentType.ValueMember = "id"

        TxtDate1.dtDate.Value = Date.Now
        TxtDate2.dtDate.Value = Date.Now
    End Sub


    Private Sub btnPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewReport.Click
        If TxtDate1.dtDate.Value.Date > TxtDate2.dtDate.Value.Date Then
            MsgBox("กรุณาตรวจสอบวันที่", MsgBoxStyle.Information)
        Else
            Dim logonInfo As New TableLogOnInfo
            logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
            logonInfo.ConnectionInfo.UserID = SqlDB.UserID
            logonInfo.ConnectionInfo.Password = SqlDB.Password

            sql = "declare @f_date as varchar(8); select @f_date = '" & FixDate(TxtDate1.dtDate.Value) & "'"
            sql &= vbCrLf & " declare @t_date as varchar(8); select @t_date = '" & FixDate(TxtDate2.dtDate.Value) & "' "
            sql &= vbCrLf & " declare @type as varchar(10); select @type = '" & cmbPatentType.SelectedValue.ToString & "'"
            sql &= vbCrLf & " select SUM(data) as data,'ยืม' as txt from ("
            sql &= vbCrLf & " select COUNT(1) as data from TB_FILEBORROW fb left join TB_FILEBORROWITEM fbi on fb.id = fbi.fileborrow_id "
            sql &= vbCrLf & " left join TB_REQUISTION rq on fbi.requisition_id = rq.id "
            sql &= vbCrLf & " where convert(varchar(10),fb.borrowerdate,112) between @f_date and @t_date"
            If cmbPatentType.SelectedIndex > 0 Then
                sql &= vbCrLf & " and rq.patent_type_id  = @type"
            End If
            sql &= vbCrLf & " Union all"
            sql &= vbCrLf & " select COUNT(1) as data from TB_RESERVE re"
            sql &= vbCrLf & " left join TB_REQUISTION rq on re.requidition_id = rq.id"
            sql &= vbCrLf & " where borrowstatus = 'T' and convert(varchar(10),reserve_date,112) between @f_date and @t_date"
            If cmbPatentType.SelectedIndex > 0 Then
                sql &= vbCrLf & " and rq.patent_type_id  = @type"
            End If
            sql &= vbCrLf & " ) as TB"
            sql &= vbCrLf & " Union all"
            sql &= vbCrLf & " select SUM(data) as data,'คืน' as txt from ("
            sql &= vbCrLf & " select COUNT(1) as data from TB_FILEBORROW fb left join TB_FILEBORROWITEM fbi on fb.id = fbi.fileborrow_id "
            sql &= vbCrLf & " left join TB_REQUISTION rq on fbi.requisition_id  = rq.id"
            sql &= vbCrLf & " where(fbi.returndate Is Not null)"
            sql &= vbCrLf & " and convert(varchar(10),fb.borrowerdate,112) between @f_date and @t_date"
            If cmbPatentType.SelectedIndex > 0 Then
                sql &= vbCrLf & " and rq.patent_type_id  = @type"
            End If
            sql &= vbCrLf & " Union all"
            sql &= vbCrLf & " select COUNT(1) as data from TB_RESERVE re"
            sql &= vbCrLf & " left join TB_REQUISTION rq on re.requidition_id  = rq.id"
            sql &= vbCrLf & " where borrowstatus = 'R' and convert(varchar(10),reserve_date,112) between @f_date and @t_date"
            If cmbPatentType.SelectedIndex > 0 Then
                sql &= vbCrLf & " and rq.patent_type_id  = @type"
            End If
            sql &= vbCrLf & " ) as TB"
            dt = SqlDB.ExecuteTable(sql)
            If CInt(dt.Rows(0).Item("data").ToString) <> 0 Or CInt(dt.Rows(1).Item("data").ToString) <> 0 Then
                Dim rpt As New DIP_R020
                Dim f As New ViewReportGraph
                rpt.SetDataSource(dt)
                rpt.DataDefinition.FormulaFields("from_date").Text = "'" & TxtDate1.TextBox1.Text & "'"
                rpt.DataDefinition.FormulaFields("to_date").Text = "'" & TxtDate2.TextBox1.Text & "'"
                rpt.DataDefinition.FormulaFields("staff").Text = "'" & frmMain.txtFullUserName.Text & "'"
                rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
                If cmbPatentType.SelectedIndex = 0 Then
                    rpt.DataDefinition.FormulaFields("type").Text = "'ทั้งหมด'"
                Else
                    rpt.DataDefinition.FormulaFields("type").Text = "'" & cmbPatentType.Text & "'"
                End If
                rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
                f.crpGraph.ReportSource = rpt
                f.Show()
            Else
                MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
            End If
        End If
    End Sub
End Class