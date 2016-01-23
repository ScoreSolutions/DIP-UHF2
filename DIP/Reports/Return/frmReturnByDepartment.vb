Imports DIP_RFID.DAL.Table
Imports System.Data
Imports DIP_RFID.DAL.Common.Utilities

Public Class frmReturnByDepartment

    Private Sub frmReturnByDepartment_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim dal As New TbDepartmentDAL
        Dim dt As DataTable = dal.GetDataList("", "department_name", Nothing)
        Dim dr As DataRow = dt.NewRow
        dr("id") = "0"
        dr("department_name") = "---------------------เลือก---------------------"
        dt.Rows.InsertAt(dr, 0)
        With cmbDepartment
            .DataSource = dt
            .ValueMember = "id"
            .DisplayMember = "department_name"
        End With
    End Sub

    Private Sub btnPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewReport.Click
        If cmbDepartment.Text = "---------------------เลือก---------------------" Then
            MsgBox("กรุณาเลือกสังกัด", MsgBoxStyle.Information)
            cmbDepartment.Focus()
        ElseIf txtDateFrom.dtDate.Value.Date > txtDateTo.dtDate.Value.Date Then
            MsgBox("กรุณาตรวจสอบวันที่", MsgBoxStyle.Information)
        Else
            date_timestart = FixDate(txtDateFrom.dtDate.Value)
            date_timestop = FixDate(txtDateTo.dtDate.Value)
            vrSearchGroup = cmbDepartment.SelectedValue
            Dim Str As String = ""
            Dim dt As New DataTable
            Try
                Str = "SELECT rq.app_no,isnull(ti.title_name,'')+tbo.fname + ' ' + tbo.lname as borrowername"
                Str += ",dp.department_name,convert(varchar(8),fbi.returndate,112) as returndate"
                Str += ",isnull(tt.title_name,'')+tof.fname+' '+tof.lname as officerreturn "
                Str += "FROM TB_FILEBORROW fb "
                Str += "INNER JOIN TB_FILEBORROWITEM fbi on fb.id=fbi.fileborrow_id "
                Str += "INNER JOIN TB_OFFICER tbo on tbo.id=fb.borrower_id "
                Str += "INNER JOIN TB_DEPARTMENT dp ON dp.id=tbo.department_id "
                Str += "INNER JOIN TB_TITLE ti ON tbo.title_id = ti.id "
                Str += "INNER JOIN TB_REQUISTION rq ON fbi.requisition_id = rq.id "
                Str += "INNER JOIN TB_OFFICER TOF ON TOF.username=fbi.officer_return "
                Str += "LEFT JOIN TB_TITLE TT ON TOF.title_id=TT.id "
                Str += "WHERE convert(varchar(8),fbi.returndate,112) "
                Str += "between '" & date_timestart & "' AND '" & date_timestop & "' "
                Str += "AND dp.id='" & vrSearchGroup & "'"
                Str += "order by fbi.returndate ASC"
                dt = SqlDB.ExecuteTable(Str)
                If dt.Rows.Count > 0 Then
                    checkInn_checked = "R011"
                    ViewReport_CheckInn.Show()
                Else
                    MsgBox("ไม่พบรายงาน", MessageBoxIcon.Information, "DIP")
                End If
            Catch ex As Exception
            End Try



        End If
    End Sub

    Private Sub frmReturnByDepartment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDateFrom.dtDate.Value = Date.Now
        txtDateTo.dtDate.Value = Date.Now
    End Sub

End Class