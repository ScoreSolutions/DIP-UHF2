Imports DIP_RFID.DAL.Common.Utilities
Imports CrystalDecisions.Shared

Public Class ViewReport_CheckInn

    Private Sub ViewReport_CheckInn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If checkInn_checked = "R010" Then 'รายงานการคืนแฟ้ม(รายคน)
            Dim rpt As New DIP_R010
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
                rpt.SetDataSource(dt)
                If dt.Rows.Count > 0 Then
                    rpt.DataDefinition.FormulaFields("datestart").Text = "'" & date_timestart & "'"
                    rpt.DataDefinition.FormulaFields("datestop").Text = "'" & date_timestop & "'"
                    rpt.SetDataSource(dt)
                    Dim paramValue As New ParameterDiscreteValue
                    Dim curValue As New ParameterValues
                    paramValue.Value = frmMain.txtFullUserName.Text
                    curValue = rpt.ParameterFields("staff").CurrentValues
                    curValue.Add(paramValue)
                    rpt.ParameterFields("staff").CurrentValues = curValue
                    paramValue.Value = DateNowCondition()
                    curValue = rpt.ParameterFields("date").CurrentValues
                    curValue.Add(paramValue)
                    rpt.ParameterFields("date").CurrentValues = curValue
                    crpCheckInn.ReportSource = rpt
                Else
                    MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
                    Me.Close()
                End If
            Catch ex As Exception
            End Try

        ElseIf checkInn_checked = "R011" Then 'รายงานการคืนแฟ้ม(ตามสังกัด)
            Dim rpt As New DIP_R011
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
                rpt.SetDataSource(dt)
                If dt.Rows.Count > 0 Then
                    rpt.DataDefinition.FormulaFields("datestart").Text = "'" & date_timestart & "'"
                    rpt.DataDefinition.FormulaFields("datestop").Text = "'" & date_timestop & "'"
                    rpt.DataDefinition.FormulaFields("staff").Text = "'" & frmMain.txtFullUserName.Text & "'"
                    rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
                    crpCheckInn.ReportSource = rpt
                Else
                    MsgBox("ไม่พบรายงาน", MessageBoxIcon.Information, "DIP")
                    Me.Close()
                End If
            Catch ex As Exception
            End Try

        ElseIf checkInn_checked = "R012" Then 'รายงานการคืนแฟ้มประจำวัน
            Dim rpt As New DIP_R012
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
                rpt.SetDataSource(dt)
                If dt.Rows.Count > 0 Then
                    rpt.DataDefinition.FormulaFields("datestart").Text = "'" & date_timestart & "'"
                    rpt.DataDefinition.FormulaFields("datestop").Text = "'" & date_timestop & "'"
                    rpt.DataDefinition.FormulaFields("staff").Text = "'" & frmMain.txtFullUserName.Text & "'"
                    rpt.DataDefinition.FormulaFields("date").Text = "'" & DateNowCondition() & "'"
                    crpCheckInn.ReportSource = rpt
                Else
                    MsgBox("ไม่พบรายงาน", MessageBoxIcon.Information, "DIP")
                    Me.Close()
                End If
            Catch ex As Exception
            End Try

            'ElseIf checkInn_checked = "4" Then ' ประจำเดือน
            'Dim rpt As New crsCheckInn_Mount
            'monthstart = cYear1 & valuemonth1
            'monthstop = cYear2 & valuemonth2
            'Dim dt As New DataTable
            'Try
            '    dt = SqlDB.ExecuteTable("select CONVERT (VARCHAR(6),TB_FILEBORROWITEM.returndate,112) as hmonth,TB_PATENT_TYPE.patent_type_name as typeqeqution" & _
            '   ",count (TB_PATENT_TYPE.patent_type_name) as cnum from TB_FILEBORROWITEM,TB_REQUISTION,TB_PATENT_TYPE" & _
            '   " where TB_REQUISTION.patent_type_id = TB_PATENT_TYPE.id And TB_FILEBORROWITEM.requisition_id = TB_REQUISTION.id" & _
            '   " and CONVERT (VARCHAR(6),TB_FILEBORROWITEM.returndate,112) between '" & monthstart & "' and '" & monthstop & "'" & _
            '   " Group by TB_PATENT_TYPE.patent_type_name,CONVERT (VARCHAR(6),TB_FILEBORROWITEM.returndate,112) order by TB_PATENT_TYPE.patent_type_name")
            '    rpt.SetDataSource(dt)
            '    If dt.Rows.Count > 0 Then
            '        monthstart = monthconvartrp(monthstart)
            '        monthstop = monthconvartrp(monthstop)
            '        rpt.DataDefinition.FormulaFields("datestart").Text = "'" & monthstart & "'"
            '        rpt.DataDefinition.FormulaFields("datestop").Text = "'" & monthstop & "'"
            '        crpCheckInn.ReportSource = rpt
            '    Else
            '        MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
            '        Me.Close()
            '    End If
            'Catch ex As Exception
            'End Try

            'ElseIf checkInn_checked = "5" Then ' ประจำปี
            'Dim rpt As New crsCheckInn_Year
            'Dim ccYear1 As String = ""
            'Dim ccYear2 As String = ""
            'Dim dt As New DataTable
            'Try
            '    dt = SqlDB.ExecuteTable("select CONVERT (VARCHAR(4),TB_FILEBORROWITEM.returndate,112)as hmonth,TB_PATENT_TYPE.patent_type_name as typeqeqution" & _
            '    ",count (TB_PATENT_TYPE.patent_type_name) as cnum from TB_FILEBORROWITEM,TB_REQUISTION,TB_PATENT_TYPE" & _
            '    " where(TB_REQUISTION.patent_type_id = TB_PATENT_TYPE.id And TB_FILEBORROWITEM.requisition_id = TB_REQUISTION.id)" & _
            '    " and CONVERT (VARCHAR(4),TB_FILEBORROWITEM.returndate,112) between '" & cYear1 & "' and '" & cYear2 & "'" & _
            '    " Group by TB_PATENT_TYPE.patent_type_name,CONVERT (VARCHAR(4),TB_FILEBORROWITEM.returndate,112)" & _
            '    " order by TB_PATENT_TYPE.patent_type_name")
            '    rpt.SetDataSource(dt)
            '    If dt.Rows.Count > 0 Then
            '        ccYear1 = cYear1 + 543
            '        ccYear2 = cYear2 + 543
            '        rpt.DataDefinition.FormulaFields("datestart").Text = "'" & ccYear1 & "'"
            '        rpt.DataDefinition.FormulaFields("datestop").Text = "'" & ccYear2 & "'"
            '        crpCheckInn.ReportSource = rpt
            '    Else
            '        MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
            '        Me.Close()
            '    End If
            'Catch ex As Exception
            'End Try

            'ElseIf checkInn_checked = "6" Then 'ประเภทแฟ้ม
            'Dim rpt As New crsCheckInn_TypeRe
            'Dim dt As New DataTable
            'Try
            '    dt = SqlDB.ExecuteTable("select CONVERT(VARCHAR(8),tb1 .datein,112)as dateborrow,tb1.req_no as requition" & _
            '    ",tb2.title_name + tb2 .fname + ' ' + tb2.lname as nameborrow" & _
            '    ",tb2 .department_name as department,tb1.title_name + tb1.fname + ' ' + tb1.lname as officerreturn from" & _
            '    " (select TB_FILEBORROWITEM.fileborrow_id, CONVERT(VARCHAR(8),TB_FILEBORROWITEM.returndate,112)as datein" & _
            '    ",TB_REQUISTION.req_no,TB_TITLE.title_name ,TB_OFFICER.fname,TB_OFFICER.lname,TB_PATENT_TYPE.patent_type_name" & _
            '    " from TB_FILEBORROWITEM, TB_OFFICER, TB_REQUISTION, TB_PATENT_TYPE, TB_TITLE" & _
            '    " where TB_FILEBORROWITEM.returndate<>''" & _
            '    " and TB_FILEBORROWITEM.officer_return=TB_OFFICER.username" & _
            '    " and TB_FILEBORROWITEM.requisition_id=TB_REQUISTION.id" & _
            '    " and TB_PATENT_TYPE.id=TB_REQUISTION.patent_type_id" & _
            '    " and TB_TITLE.id = TB_OFFICER .title_id )as tb1 left join" & _
            '    " (select TB_FILEBORROW.id,TB_TITLE.title_name, TB_OFFICER.fname,TB_OFFICER.lname,TB_DEPARTMENT.department_name" & _
            '    " from TB_FILEBORROW, TB_OFFICER, TB_DEPARTMENT, TB_TITLE" & _
            '    " where TB_FILEBORROW.borrower_id = TB_OFFICER.id And TB_OFFICER.department_id = TB_DEPARTMENT.id" & _
            '    " and TB_TITLE.id = TB_OFFICER .title_id) as tb2" & _
            '    " on tb1.fileborrow_id=tb2.id where tb1 .patent_type_name='" & pattened & "'" & _
            '    " order by tb1 .datein")
            '    rpt.SetDataSource(dt)
            '    If dt.Rows.Count > 0 Then
            '        rpt.DataDefinition.FormulaFields("patents").Text = "'" & pattened & "'"
            '        crpCheckInn.ReportSource = rpt
            '    Else
            '        MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
            '        Me.Close()
            '    End If
            'Catch ex As Exception
            'End Try

            'ElseIf checkInn_checked = "7" Then 'เลขที่คำขอ
            'Dim rpt As New crsCheckInn_FNo
            'Dim dt As New DataTable
            'Try
            '    dt = SqlDB.ExecuteTable("select TB_REQUISTION.req_no as crequition,TB_PATENT_TYPE.patent_type_name as typecrequition,count(TB_REQUISTION.req_no) as ccount" & _
            '    " from TB_FILEBORROWITEM, TB_REQUISTION, TB_PATENT_TYPE" & _
            '    " where  TB_FILEBORROWITEM.returndate <>'' and TB_FILEBORROWITEM.requisition_id=TB_REQUISTION.id" & _
            '    " and TB_REQUISTION.patent_type_id=TB_PATENT_TYPE.id" & _
            '    " and TB_REQUISTION.req_no between '" & norequitionstr & "' and '" & norequitionsto & "' group by TB_REQUISTION.req_no,TB_PATENT_TYPE.patent_type_name" & _
            '    " order by TB_REQUISTION.req_no ASC")
            '    rpt.SetDataSource(dt)
            '    If dt.Rows.Count > 0 Then
            '        rpt.DataDefinition.FormulaFields("requitionstart").Text = "'" & norequitionstr & "'"
            '        rpt.DataDefinition.FormulaFields("requitionstop").Text = "'" & norequitionsto & "'"
            '        crpCheckInn.ReportSource = rpt
            '    Else
            '        MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
            '        Me.Close()
            '    End If
            'Catch ex As Exception
            'End Try
        End If
    End Sub
End Class