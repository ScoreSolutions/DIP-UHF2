Imports DIP_RFID.DAL.Table

Public Class frmSearchHistoryFromHandheld

    Dim dt_Data As New DataTable

    Private Sub frmSearchHistoryFromHandheld_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        dtpFrom.Value = Date.Now
        cmbStatus.SelectedIndex = 0
        Dim dal As New TbFindHHTDAL
        Dim sql As String = ""
        ' Status 1 = ข้อมูลที่กำลังค้นหา
        ' Status 2 = ข้อมูลที่หาพบ
        ' Status 3 = ข้อมูลที่หาไม่พบ
        sql = "select TB1.app_no,TB1.s_date,TB1.[date]" & vbCrLf
        sql &= " ,case when isnull(TB2.f_time,'') = '' then '1' else " & vbCrLf
        sql &= " case when TB2.find_status = 'Y' then '2' else '3' end " & vbCrLf
        sql &= " end as [status]" & vbCrLf
        sql &= " ,case when isnull(TB2.f_time,'') = '' then 'ข้อมูลที่กำลังค้นหา' else " & vbCrLf
        sql &= " case when TB2.find_status = 'Y' then 'ข้อมูลที่หาพบ' else 'ข้อมูลที่หาไม่พบ' end " & vbCrLf
        sql &= " end as txt_status" & vbCrLf
        sql &= " ,case when isnull(TB2.f_time,'') = '' then s_time else f_time end as s_time" & vbCrLf
        sql &= " from" & vbCrLf
        sql &= " (" & vbCrLf
        sql &= " select id,app_no,CONVERT(varchar(10),DATEADD(YYYY,543, load_datetime),103) as s_date " & vbCrLf
        sql &= " ,CONVERT(varchar(8),load_datetime,112) as [date]" & vbCrLf
        sql &= " ,CONVERT(varchar(5),load_datetime,114) as s_time" & vbCrLf
        sql &= " from TB_FIND_HHT WHERE load_type = 'U'" & vbCrLf
        sql &= " ) as TB1" & vbCrLf
        sql &= " Left Join" & vbCrLf
        sql &= " (" & vbCrLf
        sql &= " select ref_id,find_status,CONVERT(varchar(10),DATEADD(YYYY,543, load_datetime),103) as f_date" & vbCrLf
        sql &= " ,CONVERT(varchar(5),load_datetime,114) as f_time" & vbCrLf
        sql &= " from TB_FIND_HHT WHERE load_type = 'D'" & vbCrLf
        sql &= " ) as TB2" & vbCrLf
        sql &= " on TB1.id  = TB2.ref_id " & vbCrLf

        sql &= " union all"
        sql &= " select app_no,CONVERT(varchar(10),DATEADD(YYYY,543, load_datetime),103) as s_date"
        sql &= " ,CONVERT(varchar(8),load_datetime,112) as [date]"
        sql &= " ,'2' as [status]"
        sql &= " ,'ข้อมูลที่หาพบ' as txt_status"
        sql &= " ,CONVERT(varchar(5),load_datetime,114) as s_time"
        sql &= " from TB_FIND_HHT WHERE load_type = 'D' and ref_id = 0"

        dt_Data = dal.GetListBySql(sql, "[date],app_no", Nothing)
        dt_Data.DefaultView.RowFilter = GetWhere()

        GridHHT.DataSource = dt_Data
    End Sub

    Private Sub dtpFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged
        txtDateFrom.Text = ConvertDateToString(dtpFrom.Value)
        txtDateFrom.SelectAll()
        If dt_Data.Rows.Count > 0 Then
            txtDateTo.Enabled = True
            dtpTo.Enabled = True
            dt_Data.DefaultView.RowFilter = GetWhere()
        End If

    End Sub

    Private Sub dtpTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.ValueChanged
        txtDateTo.Text = ConvertDateToString(dtpTo.Value)
        txtDateTo.SelectAll()
        If dt_Data.Rows.Count > 0 Then
            dt_Data.DefaultView.RowFilter = GetWhere()
        End If
    End Sub

    Function GetWhere() As String
        'If dtpFrom.Value.Date > dtpTo.Value.Date Then
        '    MsgBox("กรุณาตรวจสอบวันที่")
        '    Return ""
        'End If
        Dim whText As String = "isnull(app_no,'') <> ''"
        If txtDateFrom.Text.Trim <> "" And txtDateTo.Text.Trim <> "" Then
            whText += " and [date] >= '" & FixDate(dtpFrom.Value) & "'"
        ElseIf txtDateFrom.Text.Trim <> "" And txtDateTo.Text.Trim = "" Then
            whText += " and [date] = '" & FixDate(dtpFrom.Value) & "'"
        End If
        whText += IIf(txtDateTo.Text.Trim <> "", " and [date] <= '" & FixDate(dtpTo.Value) & "'", "")
        whText += " and app_no like '%" & txtAppNo.Text.Trim.Replace("'", "''") & "%'"
        If cmbStatus.SelectedIndex = 1 Then
            whText += " and [status] = '1' "
        ElseIf cmbStatus.SelectedIndex = 2 Then
            whText += " and [status] = '2' "
        ElseIf cmbStatus.SelectedIndex = 3 Then
            whText += " and [status] = '3' "
        End If
        Return whText
    End Function

    Function ConvertDateToString(ByVal ValueDate As Date) As String
        Dim d As String = ""
        Dim m As String = ""
        Dim y As String = ""
        If IsDate(ValueDate) Then
            Dim dmy As Date = CDate(ValueDate)
            d = dmy.Day
            m = dmy.Month
            y = dmy.Year
            If y < 2500 Then
                y = y + 543
            End If
            Return d.ToString.PadLeft(2, "0") & "/" & m.ToString.PadLeft(2, "0") & "/" & y.ToString
        Else
            Return ""
        End If
    End Function

    Public Function FixDate(ByVal StringDate As String) As String
        Dim d As String = ""
        Dim m As String = ""
        Dim y As String = ""
        If IsDate(StringDate) Then
            Dim dmy As Date = CDate(StringDate)
            d = dmy.Day
            m = dmy.Month
            y = dmy.Year
            If y > 2500 Then
                y = y - 543
            End If
            Return y.ToString & m.ToString.PadLeft(2, "0") & d.ToString.PadLeft(2, "0")
        Else
            Return ""
        End If
    End Function

   
    Private Sub txtDateFrom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDateFrom.KeyPress
        If Asc(e.KeyChar) = 8 Then
            txtDateFrom.Text = ""
            txtDateTo.Text = ""
            txtDateTo.Enabled = False
            dtpTo.Enabled = False
            dt_Data.DefaultView.RowFilter = GetWhere()
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtDateTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDateTo.KeyPress
        If Asc(e.KeyChar) = 8 Then
            txtDateTo.Text = ""
            dt_Data.DefaultView.RowFilter = GetWhere()
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtAppNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAppNo.KeyUp
        dt_Data.DefaultView.RowFilter = GetWhere()
    End Sub

    Private Sub cmbStatus_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbStatus.SelectionChangeCommitted
        dt_Data.DefaultView.RowFilter = GetWhere()
    End Sub
End Class