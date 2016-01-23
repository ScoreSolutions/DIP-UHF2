Public Class frmReturnByMonth

    Private Sub frmReturnByMonth_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        SetMonthList(cmbMonthFrom)
        SetMonthList(cmbMonthTo)
    End Sub

    Private Sub SetMonthList(ByVal cmb As ComboBox)
        Dim dt As New DataTable
        dt.Columns.Add("month_no")
        dt.Columns.Add("month_name")

        Dim dr As DataRow = dt.NewRow
        dr("month_no") = "0"
        dr("month_name") = "เลือก"
        dt.Rows.Add(dr)

        For i As Integer = 0 To 11
            Dim monthName As String = ""
            Select Case i + 1
                Case "1"
                    monthName = "มกราคม"
                Case "2"
                    monthName = "กุมภาพันธ์"
                Case "3"
                    monthName = "มีนาคม"
                Case "4"
                    monthName = "เมษายน"
                Case "5"
                    monthName = "พฤษภาคม"
                Case "6"
                    monthName = "มิถุนายน"
                Case "7"
                    monthName = "กรกฎาคม"
                Case "8"
                    monthName = "สิงหาคม"
                Case "9"
                    monthName = "กันยายน"
                Case "10"
                    monthName = "ตุลาคม"
                Case "11"
                    monthName = "พฤศจิกายน"
                Case "12"
                    monthName = "ธันวาคม"
            End Select

            dr = dt.NewRow
            dr("month_no") = Format(i + 1, "00")
            dr("month_name") = monthName
            dt.Rows.Add(dr)
        Next

        cmb.DataSource = dt
        cmb.ValueMember = "month_no"
        cmb.DisplayMember = "month_name"
    End Sub
End Class