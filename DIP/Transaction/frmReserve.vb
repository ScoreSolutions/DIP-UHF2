Imports System.Globalization
Imports System.Data
Imports System.Data.SqlClient
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.View
Imports DIP_RFID.Data.Table
Imports DIP_RFID.DAL.Common.Utilities
Imports DIP_RFID.Data.Common.Utilities
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class frmReserve

    Dim _err As String = ""
    Dim _ReserveID As Long

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim f As New frmReserveOfficer
        f.ShowDialog()
        If f.DialogResult <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If
        txtMemberName.Text = f.Name
        txtOfficerID.Text = f.OfficerID

    End Sub

    Private Sub frmReserve_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dal As New TbPatentTypeDAL
        Dim dt As DataTable = dal.GetDataList("1=1", "patent_type_code", Nothing)
        Dim i As Integer = 0
        For i = 0 To dt.Rows.Count - 1
            Dim data As New TbPatentTypeData
            data = dal.GetDataByid(dt.Rows(i)("id"), Nothing)
            CLBType.Items.Add(data.PATENT_TYPE_NAME, True)
        Next

        ''จองย้อนหลังได้กี่เดือน
        'Try

        '    Dim dtsetup As DataTable = SqlDB.ExecuteTable("select setup_value from tb_setup where setup_name= 'Month_Reserve'")
        '    If dtsetup.Rows.Count > 0 Then
        '        Dim dateLast As Date = Date.Now.Date
        '        Dim datefirst As Date = dateLast.AddMonths(-dtsetup.Rows(0)("setup_value"))
        '        txtDateTo.TextBox1.Text = dateLast
        '        txtDateFrom.TextBox1.Text = datefirst
        '    End If
        'Catch ex As Exception

        'End Try

 

        'ShowData()

        PictureReserve.BackgroundImage = Image.FromFile("images/bg2.png")
        Panel1.BackgroundImage = Image.FromFile("images/blog_03.jpg")
        BtnSearch.BackgroundImage = Image.FromFile("images/blog_10.jpg")
        Panel2.BackgroundImage = Image.FromFile("images/blog_05.jpg")
        'rdiBlank.BackgroundImage = Image.FromFile("images/blog4_03.jpg")
        'rdiNoBlank.BackgroundImage = Image.FromFile("images/blog4_03.jpg")
        'rdiBlankAll.BackgroundImage = Image.FromFile("images/blog4_03.jpg")

    End Sub

    Private Sub frmReserve1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.ControlBox = False
    End Sub

    Private Sub ShowForm(ByVal frm As Form)
        CloseAllForm()
        frm.MdiParent = frmMain
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.Show()
    End Sub

    Private Sub CloseAllForm()
        For Each fm In frmMain.MdiChildren
            fm.Close()
            fm.Dispose()
        Next
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        BtnSearch.Enabled = False
        picLoading.Visible = True
        Application.DoEvents()

        Dim frm As New frmReserveList()
        frm.officerid = txtOfficerID.Text
        frm.RegNoFrom = txtReqNoFrom.Text
        frm.RegNoTo = txtReqNoTo.Text
        frm.Jobno = txtJobNo.Text


        frm.Datefrom = IIf(txtDateFrom.TextDate <> "", " and convert(varchar(10),reserve_date,120) >= '" & txtDateFrom.DateCondition & "'", "") 'txtDateFrom.DateCondition
        frm.Dateto = IIf(txtDateTo.TextDate <> "", " and convert(varchar(10),reserve_date,120) <= '" & txtDateTo.DateCondition & "'", "") 'txtDateTo.DateCondition

        frm.ClbType = CLBType
        frm.Blank = rdiBlank
        frm.NoBlank = rdiNoBlank
        frm.AllBlank = rdiBlankAll
        frm.ShowData()
        If frm.CheckData = 1 Then
            'If frm.CheckShowData = True Then
            ' frm.ShowData()

            frmMain.txtDocumentEvent.Text = "borrow"
            frm.MdiParent = frmMain
            frm.Show()
            BtnSearch.Enabled = True
            picLoading.Visible = False
        Else
            BtnSearch.Enabled = True
            '  MsgBox("ไม่พบข้อมูล", MsgBoxStyle.Information)
        End If





    End Sub

    'Private Sub ShowData()
    '    GridReserve.DataSource = Nothing

    '    Dim whText As String = " 1=1 "
    '    whText += IIf(txtOfficerID.Text.Trim <> "", " and member_id = '" & txtOfficerID.Text.Trim & "'", "")
    '    whText += IIf(txtReqNoFrom.Text.Trim <> "", " and req_no >= '" & txtReqNoFrom.Text.Trim & "'", "")
    '    whText += IIf(txtReqNoTo.Text.Trim <> "", " and req_no <= '" & txtReqNoTo.Text.Trim & "'", "")
    '    whText += IIf(txtDateFrom.TextDate <> "", " and convert(varchar(10),reserve_date,120) >= '" & txtDateFrom.DateCondition & "'", "")
    '    whText += IIf(txtDateTo.TextDate <> "", " and convert(varchar(10),reserve_date,120) <= '" & txtDateTo.DateCondition & "'", "")
    '    whText += IIf(GetChkPatentType() <> "", " and patent_type_name in " & GetChkPatentType(), "")
    '    If rdiBlank.Checked Then
    '        whText += " and reserve_status = 'Y' "
    '    ElseIf rdiNoBlank.Checked Then
    '        whText += " and reserve_status = 'N' "
    '    End If

    '    Dim dal As New ReserveListDAL
    '    Dim dt As DataTable = dal.GetDataList(whText, "convert(varchar(8),reserve_date,112),member_name ,req_no", Nothing)


    '    If dt.Rows.Count > 0 Then
    '        GridReserve.AutoGenerateColumns = False

    '        dt.Columns.Add("seq")
    '        For i As Integer = 0 To dt.Rows.Count - 1
    '            dt.Rows(i)("seq") = i + 1
    '            dt.Rows(i)("reserve_status") = IIf(dt.Rows(i)("reserve_status").ToString = "Y", "ว่าง", "ไม่ว่าง")
    '        Next
    '        GridReserve.DataSource = dt
    '        lblNum.Text = dt.Rows.Count

    '        'If txtOfficerID.Text.Trim <> "" Then
    '        btnBorrow.Enabled = True
    '        btnPrint.Enabled = True
    '        btnSelectAll.Enabled = True
    '        GridReserve.Columns("chkSelect").ReadOnly = False
    '        'End If

    '    Else
    '        MsgBox("ไม่พบข้อมูล", MsgBoxStyle.Information)
    '    End If

    'End Sub

    Private Function GetChkPatentType() As String
        Dim ret As String = ""
        'For i As Integer = 0 To CLBType.Items.Count
        If CLBType.CheckedItems.Count > 0 Then
            Dim chkItem As String = ""
            For i As Integer = 0 To CLBType.CheckedItems.Count - 1
                If chkItem = "" Then
                    chkItem = "'" & CLBType.CheckedItems(i) & "'"
                Else
                    chkItem += ", '" & CLBType.CheckedItems(i) & "'"
                End If
            Next
            ret = "(" & chkItem & ")"
        Else
            ret = "(" & "null" & ")"
        End If

        Return ret

    End Function


    Function GetDate(ByVal arg As String) As String
        Dim txt As String = ""
        Try
            Dim argDate As Date = CDate(arg)

        Catch ex As Exception
            MessageBox.Show("รูปแบบของวันที่ไม่ถูกต้อง", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

        Return txt
    End Function

    'Private Function SaveReserveJob(ByVal trans As SqlTransaction) As Boolean
    '    Dim ret As Boolean = False
    '    Dim rowChk As Boolean = False
    '    For i As Integer = 0 To GridReserve.RowCount - 1
    '        If GridReserve.Rows(i).Cells("chkSelect").Value = "Y" Then
    '            rowChk = True
    '            Exit For
    '        End If
    '    Next

    '    If rowChk = True Then
    '        Dim memberID As Long
    '        Dim dtMem As New DataTable
    '        dtMem.Columns.Add("member_id")
    '        dtMem.Columns.Add("member_name")
    '        For i As Integer = 0 To GridReserve.RowCount - 1
    '            If GridReserve.Rows(i).Cells("chkSelect").Value = "Y" Then
    '                If GridReserve.Rows(i).Cells("member_id").Value <> memberID Then
    '                    memberID = GridReserve.Rows(i).Cells("member_id").Value
    '                    Dim dal As New TbOfficerDAL
    '                    Dim data As New TbOfficerData
    '                    data = dal.GetDataByid(memberID, Nothing)

    '                    Dim dr As DataRow = dtMem.NewRow
    '                    dr("member_id") = data.ID
    '                    dr("member_name") = data.FNAME & " " & data.LNAME
    '                    dtMem.Rows.Add(dr)
    '                End If
    '            End If
    '        Next

    '        If dtMem.Rows.Count > 1 Then
    '            _err = "กรุณาเลือกรายการสำหรับผู้ขอเบิก 1 คน"
    '            Return False
    '        End If

    '        For Each dr As DataRow In dtMem.Rows
    '            Dim jobDal As New TbReserveJobDAL
    '            If txtJobNo.Text <> "" Then
    '                jobDal.GetDataByJOB_NO(txtJobNo.Text, trans)
    '            Else
    '                jobDal.JOB_NO = GenReserveCode(trans)
    '            End If
    '            jobDal.JOB_DATE = DateTime.Now
    '            jobDal.MEMBER_ID = Convert.ToInt64(dr("member_id"))
    '            jobDal.MEMBER_NAME = dr("member_name")

    '            If txtJobNo.Text.Trim = "" Then
    '                ret = jobDal.InsertData(frmMain.txtUserName.Text, trans)
    '            Else
    '                ret = jobDal.UpdateByJOB_NO(txtJobNo.Text.Trim, frmMain.txtUserName.Text, trans)
    '            End If

    '            If ret = False Then
    '                _err = jobDal.ErrorMessage
    '                Return False
    '            End If

    '            If ret = True Then
    '                _ReserveID = jobDal.ID
    '                Dim Sql As String = "update tb_reserve set reserve_job_id = null where reserve_job_id = " & _ReserveID
    '                SqlDB.ExecuteNonQuery(Sql, trans)
    '                For i As Integer = 0 To GridReserve.RowCount - 1
    '                    If GridReserve.Rows(i).Cells("chkSelect").Value = "Y" Then
    '                        If GridReserve.Rows(i).Cells("member_id").Value = dr("member_id") Then
    '                            Dim jobItemDal As New TbReserveDAL
    '                            jobItemDal.GetDataByid(GridReserve.Rows(i).Cells("id").Value, trans)
    '                            jobItemDal.RESERVE_JOB_ID = jobDal.ID
    '                            ret = jobItemDal.UpdateByid(frmMain.txtUserName.Text, trans)
    '                            If ret = False Then
    '                                _err = jobItemDal.ErrorMessage
    '                                Exit For
    '                            End If
    '                        End If
    '                    End If
    '                Next
    '            Else
    '                ret = False
    '                _err = jobDal.ErrorMessage
    '            End If
    '        Next
    '    Else
    '        ret = False
    '        _err = "กรุณาเลือกรายการที่ต้องการยืม"
    '    End If

    '    Return ret

    'End Function

    'Private Sub btnBorrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If CheckStatus() = False Then
    '        Exit Sub
    '    End If

    '    Me.Cursor = Cursors.AppStarting
    '    btnBorrow.Enabled = False
    '    Dim trans As New SqlTransactionDB
    '    trans.CreateTransaction()
    '    If SaveReserveJob(trans.Trans) = True Then
    '        trans.CommitTransaction()
    '        Dim frm As New frmBorrow
    '        frm.MdiParent = frmMain
    '        frm.StartPosition = FormStartPosition.CenterScreen
    '        Dim dal As New TbReserveJobDAL
    '        dal.GetDataByid(_ReserveID, Nothing)
    '        frm.txtJobNo.Text = dal.JOB_NO
    '        frm.ShowData(dal.JOB_NO)
    '        frm.Show()

    '        Me.Close()
    '        Me.Dispose()
    '    Else
    '        trans.RollbackTransaction()
    '        MsgBox(_err, MsgBoxStyle.Critical)
    '    End If

    '    Me.Cursor = Cursors.Default
    '    btnBorrow.Enabled = True
    'End Sub

    Private Function GenReserveCode(ByVal trans As SqlTransaction) As String
        'Reserve Code Format : yyMM0000 เช่น 531201
        Dim ret As String = ""
        Dim vMM As String = Today.Month.ToString.PadLeft(2, "0")
        Dim vYY As String
        If Today.Year > 2500 Then
            vYY = Today.Year.ToString.Substring(2, 2)
        Else
            vYY = (Today.Year + 543).ToString.Substring(2, 2)
        End If

        Dim runNext As Int64
        Dim dal As New TbReserveJobDAL
        Dim dt As DataTable = dal.GetDataList("substring(job_no,1,4) = '" & vYY & vMM & "'", "job_no desc", trans)
        If dt.Rows.Count > 0 Then
            runNext = Convert.ToInt64(dt.Rows(0)("job_no").ToString.Substring(4)) + 1
        Else
            runNext = 1
        End If

        ret = vYY & vMM & runNext.ToString.PadLeft(4, "0")
        Return ret
    End Function

    'Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If txtSelectedAll.Text = "N" Then
    '        For i As Integer = 0 To GridReserve.RowCount - 1
    '            GridReserve.Rows(i).Cells("chkSelect").Value = "Y"
    '        Next
    '        txtSelectedAll.Text = "Y"
    '    Else
    '        For i As Integer = 0 To GridReserve.RowCount - 1
    '            GridReserve.Rows(i).Cells("chkSelect").Value = "N"
    '        Next
    '        txtSelectedAll.Text = "N"
    '    End If
    'End Sub

    'Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If CheckStatus() = False Then
    '        Exit Sub
    '    End If

    '    Me.Cursor = Cursors.AppStarting
    '    btnPrint.Enabled = False
    '    Dim trans As New SqlTransactionDB
    '    trans.CreateTransaction()
    '    If SaveReserveJob(trans.Trans) = True Then
    '        trans.CommitTransaction()

    '        Dim rDal As New TbReserveJobDAL
    '        rDal.GetDataByid(_ReserveID, Nothing)
    '        txtJobNo.Text = rDal.JOB_NO

    '        Dim logonInfo As New TableLogOnInfo
    '        logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
    '        logonInfo.ConnectionInfo.UserID = SqlDB.UserID
    '        logonInfo.ConnectionInfo.Password = SqlDB.Password

    '        Dim rep As New rptReserve
    '        rep.SetDataSource(GetReserveData(_ReserveID))
    '        rep.Database.Tables(0).ApplyLogOnInfo(logonInfo)

    '        Dim cryViewer As New frmReportPreview
    '        cryViewer.CrystalReportViewer1.ReportSource = rep
    '        cryViewer.CrystalReportViewer1.Refresh()
    '        cryViewer.WindowState = FormWindowState.Maximized
    '        cryViewer.Show()
    '    Else
    '        trans.RollbackTransaction()
    '        MsgBox(_err, MsgBoxStyle.Critical)
    '    End If
    '    Me.Cursor = Cursors.Default
    '    btnPrint.Enabled = True
    'End Sub

    Private Function GetReserveData(ByVal ReserveID As Long) As DataTable
        Dim rowPerCol As Integer = 25  'จำนวนแถวใน 1 คอลัมน์ ให้แสดงหน้าละ 3 คอลัมน์
        Dim ret As New DataTable
        Dim sql As String = ""
        'sql = "select 1 run1, '0000001' req_no1, 1 reserve_order1, "
        'sql += "26 run2, '0000026' req_no2, 1 reserve_order2,"
        'sql += "51 run3, '0000051' req_no3, 1 reserve_order3 "
        'Dim sql As String = "select  isnull(rq.app_no,rq.req_no) req_no, r.reserve_order, r.reserve_job_id, rj.job_no, rj.job_date,"
        'sql += " isnull(tm.title_name,'') + tbm.fname + ' ' + tbm.lname staff_name,"
        'sql += " isnull(tc.title_name,'') + tbc.fname + ' ' + tbc.lname createby_staff_name"
        'sql += " from TB_RESERVE r "
        'sql += " inner join TB_REQUISTION rq on rq.id=r.requidition_id"
        'sql += " inner join TB_RESERVE_JOB rj on rj.id=r.reserve_job_id"
        'sql += " left join TB_OFFICER tbm on tbm.id=rj.member_id"
        'sql += " left join TB_TITLE tm on tm.id=tbm.title_id"
        'sql += " left join TB_OFFICER tbc on tbc.username=rj.createby"
        'sql += " left join TB_TITLE tc on tc.id=tbc.title_id"
        'sql += " where r.reserve_job_id = '" & ReserveID.ToString & "'"

        sql = "declare @printdate as varchar(50); select @printdate = convert(varchar(10),dateadd(yyyy,543,GETDATE()),103)"

        sql += " select @printdate as printdate,req_no,reserve_order,reserve_job_id,job_no,job_date,staff_name,createby_staff_name,isnull(borrowername,'ว่าง') as borrowername"
        sql += " from "
        '-----------Query เดิม----------
        sql += " ("
        sql += " select rq.id,isnull(rq.app_no,rq.req_no) req_no, r.reserve_order, r.reserve_job_id, rj.job_no, rj.job_date, isnull(tm.title_name,'') + tbm.fname + ' ' + tbm.lname staff_name, isnull(tc.title_name,'') + tbc.fname + ' ' + tbc.lname createby_staff_name from TB_RESERVE r  inner join TB_REQUISTION rq on rq.id=r.requidition_id inner join TB_RESERVE_JOB rj on rj.id=r.reserve_job_id left join TB_OFFICER tbm on tbm.id=rj.member_id left join TB_TITLE tm on tm.id=tbm.title_id left join TB_OFFICER tbc on tbc.username=rj.createby left join TB_TITLE tc on tc.id=tbc.title_id "
        sql += " where r.reserve_job_id = '" & ReserveID.ToString & "'"
        '-----------------------------
        sql += " ) as TB1"
        sql += " Left Join"
        sql += " ("
        sql += " select fb_item.requisition_id,fb.borrowername from TB_FILEBORROWITEM as fb_item left join TB_FILEBORROW as fb on fb_item.fileborrow_id = fb.id where ISNULL(fb_item.returndate,'') = ''"
        sql += " ) as TB2"
        sql += " on TB1.id = TB2.requisition_id "

        Dim dal As New TbReserveDAL
        Dim dt As DataTable = dal.GetListBySql(sql, "req_no", Nothing)
        Dim rowCount As Integer = dt.Rows.Count
        If rowCount > 0 Then
            ret.Columns.Add("run1")
            ret.Columns.Add("req_no1")
            ret.Columns.Add("reserve_order1")
            ret.Columns.Add("status1")
            ret.Columns.Add("run2")
            ret.Columns.Add("req_no2")
            ret.Columns.Add("reserve_order2")
            ret.Columns.Add("status2")
            ret.Columns.Add("job_no")
            ret.Columns.Add("job_date")
            ret.Columns.Add("staff_name")
            ret.Columns.Add("createby_staff_name")
            ret.Columns.Add("filecount")
            ret.Columns.Add("printdate")
            Dim colNo As Integer = 1
            Dim rowNo As Integer = 1
            Dim pageNo As Integer = 1
            For i As Integer = 0 To rowCount - 1
                Dim iRow As Integer = i + 1
                pageNo = Math.Ceiling(iRow / (2 * rowPerCol))
                colNo = Math.Ceiling((iRow - ((2 * rowPerCol) * (pageNo - 1))) / rowPerCol)
                rowNo = iRow - ((rowPerCol * 2) * (pageNo - 1)) - (rowPerCol * (colNo - 1))
                Dim dtRow = rowNo + (rowPerCol * (pageNo - 1))

                If colNo = 1 Then
                    Dim dr As DataRow = ret.NewRow()
                    dr("run1") = i + 1
                    dr("req_no1") = dt.Rows(i)("req_no")
                    dr("reserve_order1") = dt.Rows(i)("reserve_order")
                    dr("status1") = dt.Rows(i)("borrowername")
                    dr("job_no") = dt.Rows(i)("job_no")
                    dr("job_date") = Convert.ToDateTime(dt.Rows(i)("job_date")).ToString("dd/MM/yyyy")
                    dr("staff_name") = dt.Rows(i)("staff_name")
                    dr("createby_staff_name") = dt.Rows(i)("createby_staff_name")
                    dr("filecount") = rowCount
                    dr("printdate") = dt.Rows(i)("printdate")
                    ret.Rows.Add(dr)
                End If
                If colNo = 2 Then
                    ret.Rows(dtRow - 1)("run2") = i + 1
                    ret.Rows(dtRow - 1)("req_no2") = dt.Rows(i)("req_no")
                    ret.Rows(dtRow - 1)("reserve_order2") = dt.Rows(i)("reserve_order")
                    ret.Rows(dtRow - 1)("status2") = dt.Rows(i)("borrowername")
                End If
                If colNo = 3 Then
                    ret.Rows(dtRow - 1)("run3") = i + 1
                    ret.Rows(dtRow - 1)("req_no3") = dt.Rows(i)("req_no")
                    ret.Rows(dtRow - 1)("reserve_order3") = dt.Rows(i)("reserve_order")
                End If

                If (rowNo * pageNo) = (rowPerCol * pageNo) Then
                    colNo = colNo + 1
                    rowNo = 1
                Else
                    rowNo = rowNo + 1
                End If
                If colNo > 3 Then
                    colNo = 1 'เริ่มนับหนึ่งใหม่ เพื่อให้ขึ้นหน้าใหม่
                    pageNo = pageNo + 1
                    rowNo = 1 + (pageNo * rowPerCol)
                End If
            Next

        End If

        Return ret
    End Function

    Private Sub txtMemberName_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        txtMemberName.SelectionStart = 0
        txtMemberName.SelectionLength = Len(txtMemberName.Text)
    End Sub

    Private Sub txtMemberName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txtMemberName.SelectionStart = 0
        txtMemberName.SelectionLength = Len(txtMemberName.Text)
    End Sub

    Private Sub txtMemberName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Then 'backspace
            txtMemberName.Text = ""
            txtOfficerID.Text = ""
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtMemberName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Asc(e.KeyCode) = 56 Then 'delete
            txtMemberName.Text = ""
            txtOfficerID.Text = ""
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtMemberName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtMemberName.Text.Trim() = "" Then
            txtOfficerID.Text = ""
        End If
    End Sub

    'Function CheckStatus() As Boolean
    '    Dim ret As Boolean = False
    '    If GridReserve.RowCount > 0 Then
    '        For i As Int32 = 0 To GridReserve.RowCount - 1
    '            If GridReserve.Rows(i).Cells("chkSelect").Value = "Y" And GridReserve.Rows(i).Cells("reserve_status").Value = "ไม่ว่าง" Then
    '                MsgBox("มีแฟ้มที่ถูกยืมไปแล้วในรายการ")
    '                Return False
    '            End If
    '        Next
    '    End If
    '    Return True
    'End Function

    Private Sub PictureReserve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureReserve.Click

    End Sub
    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub lblNum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub txtSelectedAll_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub lblSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub GridReserve_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub
    Private Sub gbxReserve_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub txtMemberName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub txtReqNoFrom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub txtReqNoTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub CLBType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub gbDetail_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub txtDateFrom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub txtDateTo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub txtOfficerID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub rdiBlank_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub rdiNoBlank_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub rdiBlankAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub txtJobNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub gbxType_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmDBA
        frm.Show()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.txtDateFrom.TextBox1.Text = ""
        Me.txtDateTo.TextBox1.Text = ""
        Me.txtMemberName.Text = ""
        Me.txtOfficerID.Text = ""
        Me.txtReqNoFrom.Text = ""
        Me.txtReqNoTo.Text = ""
        Me.rdiBlankAll.Checked = True
    End Sub
End Class