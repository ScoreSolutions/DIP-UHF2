Imports DIP_RFID.DAL.Common.Utilities

Public Class frmReturnByOfficer

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim f As New frmReserveOfficer
        f.ShowDialog()
        If f.DialogResult <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If
        txtName.Text = f.Name
        txtId.Text = f.OfficerID
    End Sub

    Private Sub btnPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewReport.Click
        If txtName.Text = "" Then
            MsgBox("กรุณาตรวจสอบผู้ใช้งาน", MsgBoxStyle.Information)
            txtName.Focus()
        ElseIf txtDateFrom.dtDate.Value.Date > txtDateTo.dtDate.Value.Date Then
            MsgBox("กรุณาตรวจสอบวันที่", MsgBoxStyle.Information)
        Else

            date_timestart = FixDate(txtDateFrom.dtDate.Value)
            date_timestop = FixDate(txtDateTo.dtDate.Value)
            vrSearchName = txtId.Text

            Dim Str As String = ""
            Dim dt As New DataTable
            Try
                Str = "SELECT rq.app_no,convert(varchar(8),fbi.returndate,112) as returndate"
                Str += ",isnull(tt.title_name,'')+tof.fname+' '+tof.lname as officerreturn"
                Str += ",ti.title_name+TBO.fname+' '+TBO.lname as borrowername,dp.department_name "
                Str += "FROM TB_FILEBORROW fb "
                Str += "INNER JOIN TB_FILEBORROWITEM fbi on fb.id=fbi.fileborrow_id "
                Str += "INNER JOIN TB_OFFICER tbo on tbo.id=fb.borrower_id "
                Str += "LEFT JOIN TB_TITLE ti ON tbo.title_id = ti.id "
                Str += "LEFT JOIN TB_DEPARTMENT dp ON dp.id=tbo.department_id "
                Str += "INNER JOIN TB_REQUISTION rq ON fbi.requisition_id = rq.id "
                Str += "INNER JOIN TB_PATENT_TYPE pt on pt.id=rq.patent_type_id "
                Str += "INNER JOIN TB_OFFICER TOF ON TOF.username=fbi.officer_return "
                Str += "LEFT JOIN TB_TITLE TT ON TOF.title_id=TT.id "
                Str += "WHERE convert(varchar(8),fbi.returndate,112) "
                Str += "between '" & date_timestart & "' AND '" & date_timestop & "' "
                Str += "and fb.borrower_id='" & vrSearchName & "'"
                Str += "order by fbi.returndate ASC"
                dt = SqlDB.ExecuteTable(Str)
                If dt.Rows.Count > 0 Then
                    checkInn_checked = "R010"
                    ViewReport_CheckInn.Show()
                Else
                    MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)

                End If
            Catch ex As Exception
            End Try

        End If
    End Sub

    Private Sub frmReturnByOfficer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDateFrom.dtDate.Value = Date.Now
        txtDateTo.dtDate.Value = Date.Now
    End Sub

End Class