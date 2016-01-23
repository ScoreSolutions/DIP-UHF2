Imports System.Globalization
Imports System.Data
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.Data.Table
Imports DIP_RFID.DAL.Common.Utilities
Public Class ViewReportGraph
    Private Sub ViewReportGraph_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If graphValueed = "R018" Then 'รายงานตามรายชื่อ
            Dim rpt As New DIP_R018
            Dim str As String = ""
            Dim dt As New DataTable
            Dim str2 As String = ""
            Dim dt2 As New DataTable
            Dim showgraph As New DataTable
            Try
                str = "select COUNT(TB_FILEBORROWITEM.requisition_id) as borrow "
                str += "from TB_FILEBORROW,TB_FILEBORROWITEM "
                str += "where TB_FILEBORROW.id=TB_FILEBORROWITEM.fileborrow_id "
                str += "and convert(varchar(8),TB_FILEBORROW.borrowerdate,112) "
                str += "between '" & date_timestart & "' and '" & date_timestop & "'"
                dt = SqlDB.ExecuteTable(str)
                borrowfile = dt.Rows(0)(0).ToString
            Catch ex As Exception
            End Try
            Try
                str2 = "select COUNT(TB_FILEBORROWITEM.returndate) as returns "
                str2 += "from TB_FILEBORROWITEM "
                str2 += "where Convert(varchar(8), TB_FILEBORROWITEM.returndate, 112) "
                str2 += "between '" & date_timestart & "' and '" & date_timestop & "'"
                dt2 = SqlDB.ExecuteTable(str2)
                returnfile = dt2.Rows(0)(0).ToString
                rpt.DataDefinition.FormulaFields("staff").Text = "'" & frmMain.txtFullUserName.Text & "'"
                rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
            Catch ex As Exception
            End Try
            'แสดงกราฟ

            showgraph.Columns.Add("borrow")
            For i As Integer = 1 To CInt(borrowfile.ToString)
                showgraph.Rows.Add("ยืม")
            Next
            For ii As Integer = 1 To CInt(returnfile.ToString)
                showgraph.Rows.Add("คืน")
            Next
            If showgraph.Rows.Count > 1 Then
                rpt.SetDataSource(showgraph)
                crpGraph.ReportSource = rpt
            Else
                MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
                Me.Close()
            End If
        End If



    End Sub
End Class