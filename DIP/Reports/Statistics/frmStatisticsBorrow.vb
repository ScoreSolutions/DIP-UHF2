Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.Common.Utilities

Public Class frmStatisticsBorrow

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

    Private Sub frmStatisticsBorrow_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetPatentType()
        txtDateFrom.dtDate.Value = Date.Now
        txtDateTo.dtDate.Value = Date.Now
    End Sub


    Private Sub btnPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewReport.Click
        If date_timestart > date_timestop Then
            MsgBox("กรุณาตรวจสอบวันที่", MsgBoxStyle.Information)
        Else
            pattened = cmbPatentType.SelectedValue
            date_timestart = FixDate(txtDateFrom.dtDate.Value)
            date_timestop = FixDate(txtDateTo.dtDate.Value)

            Dim str As String = ""
            Dim sqlqury As String = ""
            Dim dt As New DataTable
            If pattened = 0 Then
                sqlqury = ""
            Else
                sqlqury = "and pt.id='" & pattened & "'"
            End If
            Try
                'คำสั่ง sql เงื่อนไข ไปแสดงในรายงาน
                str = "select CONVERT(VARCHAR(8),fb.borrowerdate,112) as dateBorrow"
                str += ",pt.patent_type_name,COUNT (fbi.requisition_id)as borrow "
                str += "from TB_FILEBORROWITEM fbi "
                str += "inner join TB_FILEBORROW fb on fb.id=fbi.fileborrow_id "
                str += "inner join TB_REQUISTION rq on rq.id=fbi.requisition_id "
                str += "inner join TB_PATENT_TYPE pt on pt.id=rq.patent_type_id "
                str += "where Convert(VARCHAR(8),fb.borrowerdate,112) "
                str += "between '" & date_timestart & "' and '" & date_timestop & "' "
                str += "" & sqlqury & " group by fb.borrowerdate,pt.patent_type_name "
                str += "order by fb.borrowerdate ASC"
                dt = SqlDB.ExecuteTable(str)
                If dt.Rows.Count > 0 Then
                    Valueed = "R013"
                    ViewReport_Statistics.Show()
                Else
                    MsgBox("ไม่พบรายงาน", MsgBoxStyle.Information)
                End If
            Catch ex As Exception
            End Try


        End If
    End Sub
End Class