Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.Common.Utilities
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmBorrowByDepartment

    Dim dt As New DataTable
    Dim sql As String = ""

    Private Sub frmBorrowByDepartment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        If cmbDepartment.SelectedIndex = 0 Then
            MsgBox("กรุณาเลือกสังกัด", MsgBoxStyle.Information)
            cmbDepartment.Focus()
        ElseIf TxtDate1.dtDate.Value.Date > TxtDate2.dtDate.Value.Date Then
            MsgBox("กรุณาตรวจสอบวันที่", MsgBoxStyle.Information)
        Else
            Dim logonInfo As New TableLogOnInfo
            logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
            logonInfo.ConnectionInfo.UserID = SqlDB.UserID
            logonInfo.ConnectionInfo.Password = SqlDB.Password
            Dim sql1 As String = ""
            Dim sql2 As String = ""
            sql1 = "select rq.app_no,fb.borrower_id, isnull(tib.title_name,'')+ofb.fname + ' ' + ofb.lname borrowername,"
            sql1 &= vbCrLf & " CONVERT(varchar(10), DATEADD(year,543, fb.borrowerdate),103) borrowdate,"
            sql1 &= vbCrLf & " 'ยืมที่ห้องแฟ้ม'  borrow_quality, ISNULL(tt.title_name,'') + of2.fname + ' ' + of2.lname staff_name,"
            sql1 &= vbCrLf & " isnull((select isnull(t.title_name,'')+f.fname + ' ' + f.lname borrowname"
            sql1 &= vbCrLf & " from TB_OFFICER f"
            sql1 &= vbCrLf & " left join TB_TITLE t on t.id=f.title_id"
            sql1 &= vbCrLf & " inner join TB_FILEBORROW b on b.borrower_id=f.id"
            sql1 &= vbCrLf & " inner join TB_FILEBORROWITEM bi on b.id=bi.fileborrow_id"
            sql1 &= vbCrLf & " where(bi.requisition_id = fbi.requisition_id And bi.returndate Is null)"
            sql1 &= vbCrLf & " ),'ว่าง') file_status"
            sql1 &= vbCrLf & " from TB_FILEBORROW fb"
            sql1 &= vbCrLf & " inner join TB_FILEBORROWITEM fbi on fb.id =fbi.fileborrow_id "
            sql1 &= vbCrLf & " left join TB_OFFICER ofb on ofb.id=fb.borrower_id "
            sql1 &= vbCrLf & " left join TB_TITLE tib on tib.id=ofb.title_id "
            sql1 &= vbCrLf & " inner join TB_REQUISTION rq on rq.id =fbi.requisition_id "
            sql1 &= vbCrLf & " inner join TB_OFFICER OF2 on of2.username = fb.createby "
            sql1 &= vbCrLf & " left join TB_TITLE TT on tt.id =of2.title_id "
            sql1 &= vbCrLf & " inner join TB_RESERVE re on re.id = fbi.reserve_id "
            sql1 &= vbCrLf & " where  ofb.department_id = '" & cmbDepartment.SelectedValue.ToString & "'"
            sql1 &= vbCrLf & " and convert(varchar(10),fb.borrowerdate,112) between '" & FixDate(TxtDate1.dtDate.Value) & "' and '" & FixDate(TxtDate2.dtDate.Value) & "'"

            sql2 = " select rq.app_no, re.officer_id_receive, ISNULL(tir.title_name,'')+ofr.fname + ' ' + ofr.lname borrowername,"
            sql2 &= vbCrLf & " CONVERT(varchar(10), DATEADD(year,543, re.reserve_date),103) transfer_date,"
            sql2 &= vbCrLf & " 'ยืมโดยการโอน' borrow_quality,ISNULL(ti.title_name,'') + ofo.fname + ' ' + ofo.lname staff_name,"
            sql2 &= vbCrLf & " isnull((select isnull(t.title_name,'')+f.fname + ' ' + f.lname borrowname"
            sql2 &= vbCrLf & " from TB_OFFICER f"
            sql2 &= vbCrLf & " left join TB_TITLE t on t.id=f.title_id"
            sql2 &= vbCrLf & " inner join TB_FILEBORROW b on b.borrower_id=f.id"
            sql2 &= vbCrLf & " inner join TB_FILEBORROWITEM bi on b.id=bi.fileborrow_id"
            sql2 &= vbCrLf & " where(bi.requisition_id = rq.id And bi.returndate Is null)"
            sql2 &= vbCrLf & " ),'ว่าง') file_status"
            sql2 &= vbCrLf & " from TB_RESERVE re"
            sql2 &= vbCrLf & " inner join TB_REQUISTION rq on rq.id=re.requidition_id"
            sql2 &= vbCrLf & " left join TB_OFFICER ofr on ofr.id=re.officer_id_receive"
            sql2 &= vbCrLf & " left join TB_TITLE tir on tir.id=ofr.title_id"
            sql2 &= vbCrLf & " inner join TB_OFFICER ofo on ofo.id=re.member_id"
            sql2 &= vbCrLf & " left join TB_TITLE ti on ti.id=ofo.title_id"
            sql2 &= vbCrLf & " where re.borrowstatus='T'"
            sql2 &= vbCrLf & " and ofr.department_id = '" & cmbDepartment.SelectedValue.ToString & "'"
            sql2 &= vbCrLf & " and convert(varchar(10),re.reserve_date,112) between '" & FixDate(TxtDate1.dtDate.Value) & "' and '" & FixDate(TxtDate2.dtDate.Value) & "'"

            If rdiStatusReturn.Checked Then
                sql = sql1
            ElseIf rdiStatusNoReturn.Checked Then
                sql = sql2
            Else
                sql = sql1 & vbCrLf & " union all " & vbCrLf & sql2
            End If
            dt = SqlDB.ExecuteTable(sql)
            If dt.Rows.Count > 0 Then
                Dim rpt As New DIP_R005
                Dim f As New ViewReport_CheckOut
                rpt.SetDataSource(dt)
                rpt.DataDefinition.FormulaFields("from_date").Text = "'" & TxtDate1.TextBox1.Text & "'"
                rpt.DataDefinition.FormulaFields("to_date").Text = "'" & TxtDate2.TextBox1.Text & "'"
                rpt.DataDefinition.FormulaFields("staff").Text = "'" & frmMain.txtFullUserName.Text & "'"
                rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
                rpt.DataDefinition.FormulaFields("department").Text = "'" & cmbDepartment.Text & "'"
                Dim dal As New TbDepartmentDAL
                Dim dt_department As New DataTable
                dt_department = dal.GetListBySql("select department_code  from TB_DEPARTMENT where id = '" & cmbDepartment.SelectedValue.ToString & "'", "", Nothing)
                If dt_department.Rows.Count > 0 Then
                    rpt.DataDefinition.FormulaFields("group").Text = "'" & dt_department.Rows(0).Item("department_code").ToString & "'"
                End If
                rpt.Database.Tables(0).ApplyLogOnInfo(logonInfo)
                f.crpCheckOut.ReportSource = rpt
                f.Show()
            Else
                MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
            End If
        End If
    End Sub
End Class