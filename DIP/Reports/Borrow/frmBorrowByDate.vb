Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.Common.Utilities
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmBorrowByDate

    Dim dt As New DataTable
    Dim sql As String = ""

    Private Sub frmBorrowByDate_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
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
            Dim sql1 As String = ""
            Dim sql2 As String = ""
            sql1 = "select rq.app_no,fb.borrower_id, isnull(tib.title_name,'')+ofb.fname + ' ' + ofb.lname borrowername,"
            sql1 &= vbCrLf & " dp.department_name, CONVERT(varchar(10), DATEADD(year,543, fb.borrowerdate),103) borrowdate,"
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
            sql1 &= vbCrLf & " left join TB_DEPARTMENT dp on dp.id=ofb.department_id"
            sql1 &= vbCrLf & " inner join TB_REQUISTION rq on rq.id =fbi.requisition_id "
            sql1 &= vbCrLf & " inner join TB_OFFICER OF2 on of2.username = fb.createby "
            sql1 &= vbCrLf & " left join TB_TITLE TT on tt.id =of2.title_id "
            sql1 &= vbCrLf & " where  convert(varchar(10),fb.borrowerdate,112) between '" & FixDate(TxtDate1.dtDate.Value) & "' and '" & FixDate(TxtDate2.dtDate.Value) & "'"
            sql1 &= vbCrLf & " and fb.borrowerstatus='B'  --ลักษณะการยืม B=ยืมที่ห้องแฟ้ม"

            If rdiStatusReturn.Checked = True Then
                sql1 &= vbCrLf & " and fbi.returndate is not null  --สถานะแฟ้มยังไม่คืน ถ้าคืนแล้วให้เป็น fbi.returndate is not null"
            ElseIf rdiStatusNoReturn.Checked = True Then
                sql1 &= vbCrLf & " and fbi.returndate is null  --สถานะแฟ้มยังไม่คืน ถ้าคืนแล้วให้เป็น fbi.returndate is not null"
            End If

            sql2 = "select * from ( select rq.app_no, re.officer_id_receive, ISNULL(tir.title_name,'')+ofr.fname + ' ' + ofr.lname borrowername,"
            sql2 &= vbCrLf & " dp.department_name, CONVERT(varchar(10), DATEADD(year,543, re.reserve_date),103) transfer_date,"
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
            sql2 &= vbCrLf & " left join TB_DEPARTMENT dp on dp.id=ofr.department_id"
            sql2 &= vbCrLf & " inner join TB_OFFICER ofo on ofo.id=re.member_id"
            sql2 &= vbCrLf & " left join TB_TITLE ti on ti.id=ofo.title_id"
            sql2 &= vbCrLf & " where re.borrowstatus='T' --ลักษณะการยืม T=ยืมโดยการโอน"
            sql2 &= vbCrLf & " and convert(varchar(10),re.reserve_date,112) between '" & FixDate(TxtDate1.dtDate.Value) & "' and '" & FixDate(TxtDate1.dtDate.Value) & "') as TB"
            If rdiStatusReturn.Checked = True Then
                sql2 &= vbCrLf & "  where file_status <> 'ว่าง'  --กรณีคืนแล้ว ถ้ายังไม่คืนให้ file_status<>'ว่าง'"
            ElseIf rdiStatusNoReturn.Checked = True Then
                sql2 &= vbCrLf & "  where file_status = 'ว่าง'  --กรณีคืนแล้ว ถ้ายังไม่คืนให้ file_status<>'ว่าง'"
            End If

            If rdiBorrowQualityBorrow.Checked Then
                sql = sql1
            ElseIf rdiBorrowQualityTransfer.Checked Then
                sql = sql2
            Else
                sql = sql1 & vbCrLf & " union all " & vbCrLf & sql2
            End If

            dt = SqlDB.ExecuteTable(sql)
            If dt.Rows.Count > 0 Then
                Dim rpt As New DIP_R006
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
End Class