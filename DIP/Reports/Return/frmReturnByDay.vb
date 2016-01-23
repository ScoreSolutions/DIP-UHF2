Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.Common.Utilities

Public Class frmReturnByDay

    Private Sub SetPatentType()
        Dim dal As New TbPatentTypeDAL
        Dim dt As DataTable = dal.GetDataList("1=1", "patent_type_name", Nothing)
        Dim dr As DataRow = dt.NewRow
        dr("id") = "0"
        dr("patent_type_name") = "------------------ทั้งหมด----------------------"
        If dt.Rows.Count > 0 Then

            dt.Rows.InsertAt(dr, 0)
            cmbPatentType.DataSource = dt
            cmbPatentType.DisplayMember = "patent_type_name"
            cmbPatentType.ValueMember = "id"
        End If
    End Sub

    Private Sub frmReturnByDay_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetPatentType()
        txtDateFrom.dtDate.Value = Date.Now
        txtDateTo.dtDate.Value = Date.Now
    End Sub

    Private Sub btnPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewReport.Click
        If txtDateFrom.dtDate.Value.Date > txtDateTo.dtDate.Value.Date Then
            MsgBox("กรุณาตรวจสอบวันที่", MsgBoxStyle.Information)
        Else
            date_timestart = FixDate(txtDateFrom.dtDate.Value)
            date_timestop = FixDate(txtDateTo.dtDate.Value)
            pattened = cmbPatentType.SelectedValue
            Dim sqlqury As String = ""
            Dim str As String
            Dim dt As New DataTable
            'MsgBox(pattened)
            If pattened = 0 Then
                sqlqury = ""
            Else
                sqlqury = "and pt.id='" & pattened & "'"
            End If
            Try
                str = "SELECT convert(varchar(8),fbi.returndate,112)returndate , rq.app_no"
                str += ",isnull(ti.title_name,'')+tbo.fname+' '+tbo.lname as borrowername"
                str += ",dp.department_name,pt.patent_type_name "
                str += ",isnull(tt.title_name,'')+tof.fname + ' ' + tof.lname as officerreturn "
                str += "FROM TB_FILEBORROW fb "
                str += "inner join TB_FILEBORROWITEM fbi on fb.id=fbi.fileborrow_id "
                str += "inner join TB_OFFICER tbo on tbo.id=fb.borrower_id "
                str += "left JOIN TB_TITLE ti ON tbo.title_id = ti.id "
                str += "left JOIN TB_DEPARTMENT dp ON dp.id=tbo.department_id "
                str += "INNER JOIN TB_REQUISTION rq ON fbi.requisition_id = rq.id "
                str += "inner join TB_PATENT_TYPE pt on pt.id=rq.patent_type_id "
                str += "INNER JOIN TB_OFFICER TOF ON TOF.username=fbi.officer_return "
                str += "left JOIN TB_TITLE TT ON TOF.title_id=TT.id "
                str += "WHERE convert(varchar(8),fbi.returndate,112) "
                str += "between '" & date_timestart & "' AND '" & date_timestop & "'"
                str += "" & sqlqury & " order by fbi.returndate ASC"
                dt = SqlDB.ExecuteTable(str)
                If dt.Rows.Count > 0 Then
                    checkInn_checked = "R012"
                    ViewReport_CheckInn.Show()
                Else
                    MsgBox("ไม่พบรายงาน", MessageBoxIcon.Information, "DIP")
                End If
            Catch ex As Exception
            End Try


        End If
    End Sub

End Class