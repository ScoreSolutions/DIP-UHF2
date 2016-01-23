Imports DIP_RFID.DAL.Common.Utilities
Imports CrystalDecisions.Shared

Public Class ViewReport_CheckOut
    Private Sub ViewReport_CheckOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If checkOut_Checked = "R009" Then 'รายงานตามรายชื่อ
        '    Dim rpt As New DIP_R009
        '    Dim str As String = ""
        '    Dim dt As New DataTable
        '    Try
        '        str = "SELECT TB_REQUISTION.app_no,convert(varchar(8),TB_FILEBORROW.borrowerdate,112) "
        '        str += "as borrowerdate,TB_PATENT_TYPE.patent_type_name"
        '        str += ",TB_FILEBORROW.borrowername as borrowername,isnull(TT.title_name,'')+"
        '        str += "OF2.fname+ ' ' +OF2.lname as officercreateby "
        '        str += "FROM TB_FILEBORROWITEM "
        '        str += "INNER JOIN TB_REQUISTION ON TB_FILEBORROWITEM.requisition_id = TB_REQUISTION.id "
        '        str += "INNER JOIN TB_PATENT_TYPE ON TB_REQUISTION.patent_type_id = TB_PATENT_TYPE.id "
        '        str += "INNER JOIN TB_FILEBORROW ON TB_FILEBORROWITEM.fileborrow_id=TB_FILEBORROW.id "
        '        str += "INNER JOIN TB_OFFICER ON TB_FILEBORROW.borrower_id=TB_OFFICER.id "
        '        str += "left JOIN TB_TITLE ON TB_OFFICER.title_id=TB_TITLE.id "
        '        str += "INNER JOIN TB_OFFICER OF2 ON OF2.username = TB_FILEBORROW.createby "
        '        str += "left JOIN TB_TITLE TT ON TT.id = OF2.title_id "
        '        str += "WHERE TB_FILEBORROWITEM.returndate Is NULL "
        '        str += "and convert(varchar(8),TB_FILEBORROW.createon,112)"
        '        str += "between '" & date_timestart & "' AND '" & date_timestop & "' "
        '        str += "AND TB_FILEBORROW.borrower_id='" & vrSearchName & "' "
        '        str += "ORDER BY TB_FILEBORROW.borrowerdate ASC"
        '        dt = SqlDB.ExecuteTable(str)

        '        If dt.Rows.Count > 0 Then
        '            rpt.SetDataSource(dt)
        '            Dim paramValue As New ParameterDiscreteValue
        '            Dim curValue As New ParameterValues
        '            paramValue.Value = frmMain.txtFullUserName.Text
        '            curValue = rpt.ParameterFields("staff").CurrentValues
        '            curValue.Add(paramValue)
        '            rpt.ParameterFields("staff").CurrentValues = curValue
        '            paramValue.Value = DateNowCondition()
        '            curValue = rpt.ParameterFields("date").CurrentValues
        '            curValue.Add(paramValue)
        '            rpt.ParameterFields("date").CurrentValues = curValue
        '            crpCheckOut.ReportSource = rpt
        '        Else
        '            MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
        '            Me.Close()
        '        End If
        '    Catch ex As Exception
        '    End Try

        'ElseIf checkOut_Checked = "R016" Then ' รายงานการปฏิบัติหน้าที่ของเจ้าหน้าที่ห้องแฟ้ม
        '    Dim rpt As New DIP_R016
        '    Dim str As String = ""
        '    Dim zero As Integer = 0
        '    Dim dt As New DataTable
        '    Try
        '        str = "select CONVERT(VARCHAR(8),TB3.borrowerdate,112)borrowerdate,TB3.Patentedinvention"
        '        str += ",TB3.Patenteddesign,TB4.Pettypatent FROM "
        '        str += "(select tb1.borrowerdate,tb1.Patentedinvention,tb2.Patenteddesign FROM "
        '        str += "(SELECT FB.borrowerdate,COUNT(PT.patent_type_name)Patentedinvention "
        '        str += "FROM TB_FILEBORROW FB INNER JOIN "
        '        str += "TB_FILEBORROWITEM FBI ON FB.id = FBI.fileborrow_id INNER JOIN "
        '        str += "TB_OFFICER OFC ON FB.borrower_id = OFC.id INNER JOIN "
        '        str += "TB_DEPARTMENT DPTM ON OFC.department_id = DPTM.department_code INNER JOIN "
        '        str += "TB_REQUISTION REQ ON FBI.requisition_id=REQ.id INNER JOIN "
        '        str += "TB_PATENT_TYPE PT ON REQ.patent_type_id=PT.id "
        '        str += "WHERE PT.id='01' GROUP BY FB.borrowerdate) TB1 LEFT JOIN "
        '        str += "(SELECT FB2.borrowerdate,COUNT(PT2.patent_type_name)Patenteddesign "
        '        str += "FROM TB_FILEBORROW FB2 INNER JOIN "
        '        str += "TB_FILEBORROWITEM FBI2 ON FB2.id = FBI2.fileborrow_id INNER JOIN "
        '        str += "TB_OFFICER OFC2 ON FB2.borrower_id = OFC2.id INNER JOIN "
        '        str += "TB_DEPARTMENT DPTM2 ON OFC2.department_id = DPTM2.department_code INNER JOIN "
        '        str += "TB_REQUISTION REQ2 ON FBI2.requisition_id=REQ2.id INNER JOIN "
        '        str += "TB_PATENT_TYPE PT2 ON REQ2.patent_type_id=PT2.id "
        '        str += "WHERE PT2.id='02' GROUP BY FB2.borrowerdate)TB2 on TB1.borrowerdate=tb2.borrowerdate) TB3 LEFT JOIN "
        '        str += "(SELECT FB3.borrowerdate,COUNT(PT3.patent_type_name)Pettypatent "
        '        str += "FROM TB_FILEBORROW FB3 INNER JOIN "
        '        str += "TB_FILEBORROWITEM FBI3 ON FB3.id = FBI3.fileborrow_id INNER JOIN "
        '        str += "TB_OFFICER OFC3 ON FB3.borrower_id = OFC3.id INNER JOIN "
        '        str += "TB_DEPARTMENT DPTM3 ON OFC3.department_id = DPTM3.department_code INNER JOIN "
        '        str += "TB_REQUISTION REQ3 ON FBI3.requisition_id=REQ3.id INNER JOIN "
        '        str += "TB_PATENT_TYPE PT3 ON REQ3.patent_type_id=PT3.id "
        '        str += "WHERE PT3.id='02' GROUP BY FB3.borrowerdate)TB4 ON TB3.borrowerdate=TB4.borrowerdate "
        '        str += "WHERE CONVERT(VARCHAR(8),TB3.borrowerdate,112) "
        '        str += "between '" & date_timestart & "' AND '" & date_timestop & "'"
        '        dt = SqlDB.ExecuteTable(str)

        '        rpt.SetDataSource(dt)
        '        If dt.Rows.Count > 0 Then

        '            If dt.Rows(0)(6).ToString = "" Then
        '                ddd = "0001"
        '            End If

        '            rpt.DataDefinition.FormulaFields("Patentedinventionssss").Text = zero
        '            rpt.DataDefinition.FormulaFields("Pettypatentssss").Text = zero
        '            crpCheckOut.ReportSource = rpt
        '        Else
        '            MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
        '            Me.Close()
        '        End If
        '    Catch ex As Exception
        '    End Try
        'ElseIf checkOut_Checked = "3" Then 'แยกระหว่างวันที่ ถึง วันที่
        '    Dim rpt As New crsCheckOut_DateNow
        '    Dim strmsg As String = ""
        '    Dim dt As New DataTable
        '    Try
        '        dt = SqlDB.ExecuteTable(" select rq.req_no,pt.patent_type_name, fb.borrowername,dt.department_name,ti.title_name," & _
        '        " tbo.fname,tbo.lname , convert(varchar(8),fb.borrowerdate,112) borrowerdate," & _
        '        " case fbi.scan_by when 'R' then 'RFID' when 'B' then 'BARCODE' end scan_by" & _
        '        " from TB_FILEBORROW fb" & _
        '        " inner join TB_FILEBORROWITEM fbi on fb.id=fbi.fileborrow_id" & _
        '        " inner join TB_REQUISTION rq on rq.id=fbi.requisition_id" & _
        '        " inner join TB_PATENT_TYPE pt on pt.id=rq.patent_type_id" & _
        '        " inner join TB_OFFICER tbo on tbo.username=fb.createby" & _
        '        " left join TB_TITLE ti on ti.id=tbo.title_id" & _
        '        " inner join TB_OFFICER tbb on tbb.id=fb.borrower_id" & _
        '        " left join TB_DEPARTMENT dt on dt.id=tbb.department_id" & _
        '        " where convert(varchar(8),fb.borrowerdate,112) between '" & date_timestart & "' and '" & date_timestop & "'")
        '        rpt.SetDataSource(dt)
        '        If dt.Rows.Count > 0 Then
        '            rpt.DataDefinition.FormulaFields("dtStart").Text = "'" & date_timestart & "'" 'นำตัวแปร ไปแสดงใน crs
        '            rpt.DataDefinition.FormulaFields("dtStop").Text = "'" & date_timestop & "'" 'นำตัวแปร ไปแสดงใน Crs
        '            crpCheckOut.ReportSource = rpt
        '        Else
        '            MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
        '            Me.Close()
        '        End If
        '    Catch ex As Exception
        '    End Try

        'ElseIf checkOut_Checked = "4" Then 'แยกตามเดือน ปี
        '    Dim rpt As New crsCheckOut_Mount
        '    Dim strmsg As String = ""
        '    Dim dt As New DataTable
        '    Try
        '        dt = SqlDB.ExecuteTable(" Select pt.patent_type_name" & _
        '        " ,convert(varchar(6),fb.borrowerdate,112) borrowerdate" & _
        '        " ,COUNT (rq.req_no ) total" & _
        '        " from TB_FILEBORROW fb" & _
        '        " inner join TB_FILEBORROWITEM fbi on fb.id=fbi.fileborrow_id" & _
        '        " inner join TB_REQUISTION rq on rq.id=fbi.requisition_id" & _
        '        " inner join TB_PATENT_TYPE pt on pt.id=rq.patent_type_id" & _
        '        " inner join TB_OFFICER tbo on tbo.username=fb.createby" & _
        '        " left join TB_TITLE ti on ti.id=tbo.title_id" & _
        '        " inner join TB_OFFICER tbb on tbb.id=fb.borrower_id" & _
        '        " left join TB_DEPARTMENT dt on dt.id=tbb.department_id" & _
        '        " where convert(varchar(6),fb.borrowerdate,112)between '" & ShowCrs1 & "' and '" & ShowCrs2 & "'" & _
        '        " group by pt.patent_type_name ,fb.borrowerdate ")
        '        rpt.SetDataSource(dt)
        '        If dt.Rows.Count > 0 Then
        '            rpt.DataDefinition.FormulaFields("M1").Text = "'" & cMonth1 & "'"
        '            rpt.DataDefinition.FormulaFields("Y1").Text = "'" & cYear1 & "'"
        '            rpt.DataDefinition.FormulaFields("M2").Text = "'" & cMonth2 & "'"
        '            rpt.DataDefinition.FormulaFields("Y2").Text = "'" & cYear2 & "'"
        '            crpCheckOut.ReportSource = rpt
        '        Else
        '            MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
        '            Me.Close()
        '        End If
        '    Catch ex As Exception
        '    End Try

        'ElseIf checkOut_Checked = "5" Then '-------------------------------------------แยกตามปี
        '    Dim rpt As New crsCheckOut_Year
        '    Dim sql As String = ""
        '    Dim strmsg As String = ""
        '    Dim dt As New DataTable
        '    Try
        '        dt = SqlDB.ExecuteTable(" select pt.patent_type_name" & _
        '        " ,convert(varchar(4),fb.borrowerdate,112) borrowerdate" & _
        '        " ,COUNT (rq.req_no ) total" & _
        '        " from TB_FILEBORROW fb" & _
        '        " inner join TB_FILEBORROWITEM fbi on fb.id=fbi.fileborrow_id" & _
        '        " inner join TB_REQUISTION rq on rq.id=fbi.requisition_id" & _
        '        " inner join TB_PATENT_TYPE pt on pt.id=rq.patent_type_id" & _
        '        " inner join TB_OFFICER tbo on tbo.username=fb.createby" & _
        '        " left join TB_TITLE ti on ti.id=tbo.title_id" & _
        '        " inner join TB_OFFICER tbb on tbb.id=fb.borrower_id" & _
        '        " left join TB_DEPARTMENT dt on dt.id=tbb.department_id" & _
        '        " where convert(varchar(4),fb.borrowerdate,112)between '" & cYear1 & "' and '" & cYear2 & "'" & _
        '        " group by pt.patent_type_name,fb.borrowerdate ")
        '        rpt.SetDataSource(dt)
        '        If dt.Rows.Count > 0 Then
        '            rpt.DataDefinition.FormulaFields("Y1").Text = "'" & ShowCrs1 & "'"
        '            rpt.DataDefinition.FormulaFields("Y2").Text = "'" & ShowCrs2 & "'"
        '            crpCheckOut.ReportSource = rpt
        '        Else
        '            MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
        '            Me.Close()
        '        End If
        '    Catch ex As Exception
        '    End Try

        'ElseIf checkOut_Checked = "6" Then ' รายงาน ตามประเภทคำขอ
        '    Dim rpt As New crsCheckOut_TypeRe
        '    Dim strmsg As String = ""
        '    Dim dt As New DataTable
        '    Try

        '        dt = SqlDB.ExecuteTable(" select rq.req_no,pt.patent_type_name, fb.borrowername,dt.department_name," & _
        '        " ti.title_name ,tbo.fname,tbo.lname , convert(varchar(10),fb.borrowerdate,112) borrowerdate," & _
        '        " case fbi.scan_by when 'R' then 'RFID' when 'B' then 'BARCODE' end scan_by" & _
        '        " from TB_FILEBORROW fb" & _
        '        " inner join TB_FILEBORROWITEM fbi on fb.id=fbi.fileborrow_id" & _
        '        " inner join TB_REQUISTION rq on rq.id=fbi.requisition_id" & _
        '        " inner join TB_PATENT_TYPE pt on pt.id=rq.patent_type_id" & _
        '        " inner join TB_OFFICER tbo on tbo.username=fb.createby" & _
        '        " left join TB_TITLE ti on ti.id=tbo.title_id" & _
        '        " inner join TB_OFFICER tbb on tbb.id=fb.borrower_id" & _
        '        " left join TB_DEPARTMENT dt on dt.id=tbb.department_id" & _
        '        " where pt.patent_type_name = '" & vrSearch & "'")
        '        rpt.SetDataSource(dt)
        '        If dt.Rows.Count > 0 Then
        '            crpCheckOut.ReportSource = rpt
        '        Else
        '            MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
        '            Me.Close()
        '        End If
        '    Catch ex As Exception
        '    End Try

        'ElseIf checkOut_Checked = "7" Then 'เลขที่คำขอ
        '    Dim rpt As New crsCheckOut_FNo
        '    Dim strmsg As String = ""
        '    Dim dt As New DataTable
        '    Try
        '        dt = SqlDB.ExecuteTable(" select rq.req_no ,pt.patent_type_name" & _
        '        " ,convert(varchar(4),fb.borrowerdate,112) borrowerdate" & _
        '        " ,COUNT (rq.req_no) total" & _
        '        " from TB_FILEBORROW fb" & _
        '        " inner join TB_FILEBORROWITEM fbi on fb.id=fbi.fileborrow_id" & _
        '        " inner join TB_REQUISTION rq on rq.id=fbi.requisition_id" & _
        '        " inner join TB_PATENT_TYPE pt on pt.id=rq.patent_type_id" & _
        '        " inner join TB_OFFICER tbo on tbo.username=fb.createby" & _
        '        " left join TB_TITLE ti on ti.id=tbo.title_id" & _
        '        " inner join TB_OFFICER tbb on tbb.id=fb.borrower_id" & _
        '        " left join TB_DEPARTMENT dt on dt.id=tbb.department_id" & _
        '        " where rq.req_no between '" & vrSearch & "' and '" & vrSearch2 & "'" & _
        '        " group by pt.patent_type_name,fb.borrowerdate,rq.req_no ")
        '        rpt.SetDataSource(dt)
        '        If dt.Rows.Count > 0 Then
        '            rpt.DataDefinition.FormulaFields("No1").Text = "'" & vrSearch & "'"
        '            rpt.DataDefinition.FormulaFields("No2").Text = "'" & vrSearch2 & "'"
        '            crpCheckOut.ReportSource = rpt
        '        Else
        '            MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
        '            Me.Close()
        '        End If
        '    Catch ex As Exception
        '    End Try

        'ElseIf checkOut_Checked = "8" Then 'ติดชื่อผู้ยืมทั้งหมด
        '    'Dim rpt As New crsCheckOut_All
        '    Dim strmsg As String = ""
        '    Dim dt As New DataTable
        '    Try
        '        dt = SqlDB.ExecuteTable("")
        '        rpt.SetDataSource(dt)
        '        If dt.Rows.Count > 0 Then
        '            crpCheckOut.ReportSource = rpt
        '        Else
        '            MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
        '            rpt.SetDataSource(dt)
        '        End If
        '    Catch ex As Exception
        '    End Try
        'End If
    End Sub
End Class