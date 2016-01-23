Imports System.Data
Imports System.Data.SqlClient
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.Data.Table
Imports DIP_RFID.DAL.Common.Utilities
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports RfidApiLib
Imports OpenNETCF.Desktop.Communication
Imports System.IO
Imports System.Net.Sockets





Public Class frmBorrow
    Dim blnBox1 As Boolean
    Dim sql As String = ""
    Dim dt_Borrow As New DataTable 'รายการยืม
    Dim dt_Error As New DataTable 'รายการที่มีปัญหา
    Dim dt_Book As New DataTable 'รายการจอง
    'Dim Count_Borrow As Int32 'จำนวนของแฟ้มต่อ ที่อยู่ในรายการยืม 
    'Dim Count_Error As Int32 'จำนวนของแฟ้มต่อ ที่อยู่ในรายการที่มีปัญหา
    Dim _BorrowID As Long

    'ส่วนอ่านค่าจาก RFID
    Dim dt_RFID As DataTable
    Dim rea As RFIDReader
    Dim api As New RfidApi
    Public TagCnt As Integer = 0
    Dim ReadMinute As Integer = Func.GetSetupValue("RFID_Read_Minute", Nothing)
    Dim ReadTime As Double
    Dim _err As String = ""
    Private Sub frmBorrow_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PictureReserve.BackgroundImage = Image.FromFile("images/bg.png")
        'btnReadRFID.BackgroundImage = Image.FromFile("images/Dis_blog3_09.jpg")
        btnCancel.BackgroundImage = Image.FromFile("images/blog3_13.jpg")
        Panel1.BackgroundImage = Image.FromFile("images/blog3_03.jpg")
        Panel2.BackgroundImage = Image.FromFile("images/blog3_06.jpg")
        Panel3.BackgroundImage = Image.FromFile("images/blog3_16.jpg")
        btnMobileDevice.BackgroundImage = Image.FromFile("images/blog3_31.jpg")
        btnComfirm.BackgroundImage = Image.FromFile("images/Dis_blog3_26.jpg")
        btnPrint.BackgroundImage = Image.FromFile("images/Dis_blog3_29.jpg")

        If txtJobNo.Text = "" Then
            btnReadRFID.BackgroundImage = Image.FromFile("images/Dis_blog3_09.jpg")
            btnSendtoHandheld.BackgroundImage = Image.FromFile("images/Dis_blog3_30.jpg")
            txtBarcode.Enabled = False
        Else
            txtJobNo.Enabled = False
        End If

        'ลบ Temp
        SqlDB.ExecuteNonQuery("DELETE FROM TMP_GATE_READER_TAG where Reader_id=" & ReadBarcodeFromTextFile.GetReaderId)
        'Set Module
        If Func.IsUpdateActionModule("1", "1") = False Then
            MessageBox.Show("Can't update SetActionModule.")
        End If

        'Label1.BackgroundImage = Image.FromFile("images/bg.png")
        'Label2.BackgroundImage = Image.FromFile("images/bg.png")

        'ซ่อนปุ่มเปิดประตู
        If ReadBarcodeFromTextFile.GetIsBox = 0 Then
            btnOpenDoor.Visible = False
        End If

        txtBarcode.Focus()
    End Sub

    Private Sub txtJobNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtJobNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'lblR_txtload.Visible = True
            lblR_txt1.Visible = False
            lblR_txt2.Visible = False
            lblR_count.Visible = False
            'lblE_txtload.Visible = True
            lblE_txt1.Visible = False
            lblE_txt2.Visible = False
            lblE_count.Visible = False
            'lblB_txtload.Visible = True
            lblB_txt1.Visible = False
            lblB_txt2.Visible = False
            lblB_count.Visible = False
            ShowData(txtJobNo.Text)
            dt_Error.Rows.Clear()
            dt_Borrow.Rows.Clear()
        End If
    End Sub

    Public Sub ShowData(ByVal job_no As String)
        Dim dal As New TbFileBorrowDAL
        Dim trans As New SqlTransactionDB
        trans.CreateTransaction()


        'requidition_id reserve_date status Name ใช้ที่  reserve_job
        gdvDataBook.DataSource = Nothing

        Dim sql As String = "SELECT TB_RJOB.id as Job_id, TB_REQ.id as idTB_REQ, TB_R.id as ReserveID, TB_REQ.APP_NO, reserve_date as date1,  " & vbNewLine
        sql &= " CONVERT(varchar(10),DATEADD(YYYY,543, reserve_date),103) as reserve_date, " & vbNewLine
        'sql &= " case when reserve_status = 'Y' then 'ว่าง' else 'ไม่ว่าง' end as reserve_status, " & vbNewLine
        'แก้ไข
        sql &= " CASE WHEN ISNULL(br.BORROWSTATUS, '') = '' then 'ว่าง' else 'ไม่ว่าง' end as reserve_status, " & vbNewLine

        sql &= " TB_RJOB.member_id,TB_R.member_name,TB_REQ.app_name,TB_REQ.app_position FROM TB_RESERVE_JOB AS TB_RJOB " & vbNewLine
        sql &= " LEFT JOIN TB_RESERVE AS TB_R " & vbNewLine
        sql &= " ON TB_RJOB.id = TB_R.reserve_job_id " & vbNewLine
        sql &= " LEFT JOIN TB_REQUISTION  as TB_REQ " & vbNewLine
        sql &= " ON TB_R.requidition_id = TB_REQ.id " & vbNewLine
        'เพิ่ม
        sql += "  LEFT JOIN " & ModuleConfig.IPINNOVA & "PATENTSYSTEM.dbo.FILEBORROWITEM AS Innova ON TB_R.ref_innova_id = Innova.ID AND Innova.BORROWSTATUS = 'S' LEFT OUTER JOIN"
        sql += "  (SELECT     BORROWSTATUS, APP_NO"
        sql += "  FROM        " & ModuleConfig.IPINNOVA & "PATENTSYSTEM.dbo.FILEBORROWITEM"
        sql += "  WHERE      (BORROWSTATUS IN ('B', 'T', 'A'))) AS br ON TB_REQ.app_no = br.APP_NO"

        sql &= " WHERE tb_rjob.job_no = '" & job_no & "' and tb_rjob.id not in (select reserve_job_id from tb_fileborrow)"

        '  dt_Book = dal.GetListBySql(sql, "APP_NO ASC", trans.Trans)
        dt_Book = dal.GetListBySql(sql, "TB_R.reserve_order, TB_R.reserve_date,TB_REQ.app_no", trans.Trans)


        If dt_Book.Rows.Count > 0 Then
            If Not IsDBNull(dt_Book.Rows(0)(1)) Then
                gdvDataBook.AutoGenerateColumns = False
                If Not IsDBNull(dt_Book(0)("Job_id")) Then
                    lblJob_Id.Text = dt_Book(0)("Job_id")
                End If
                If Not IsDBNull(dt_Book(0)("member_id")) Then
                    lblMemberID.Text = dt_Book(0)("member_id")
                End If
                If Not IsDBNull(dt_Book(0)("member_name")) Then
                    lblName.Text = dt_Book(0)("member_name")
                End If
                If Not IsDBNull(dt_Book(0)("date1")) Then
                    lblDate.Text = dt_Book(0)("date1")
                End If

                dt_Book.Columns.Add("seq")
                dt_Book.Columns.Add("borrow_status")
                For i As Integer = 0 To dt_Book.Rows.Count - 1
                    dt_Book.Rows(i)("seq") = i + 1
                    dt_Book.Rows(i)("borrow_status") = "N"

                Next
                gdvDataBook.DataSource = dt_Book

                'GroupBox1.Text = "จำนวนรายการจองทั้งหมด " & dt_Book.Rows.Count & " รายการ"
                'lblR_txtload.Visible = False
                lblR_txt1.Visible = True
                lblR_txt2.Visible = True
                lblR_count.Visible = True
                lblR_count.Text = dt_Book.Rows.Count
                btnComfirm.Enabled = False
                btnComfirm.BackgroundImage = Image.FromFile("images/Dis_blog3_26.jpg")
                btnReadRFID.Enabled = True
                btnReadRFID.BackgroundImage = Image.FromFile("images/blog3_09.jpg")
                btnSendtoHandheld.Enabled = True
                btnSendtoHandheld.BackgroundImage = Image.FromFile("images/blog3_30.jpg")
            End If
            txtBarcode.Enabled = True
            txtJobNo.Enabled = False
        Else
            MsgBox("ไม่พบข้อมูล", MsgBoxStyle.Information)
            btnReadRFID.BackgroundImage = Image.FromFile("images/Dis_blog3_09.jpg")
            btnSendtoHandheld.Enabled = False
            btnSendtoHandheld.BackgroundImage = Image.FromFile("images/Dis_blog3_30.jpg")
            txtBarcode.Enabled = False
            txtJobNo.Enabled = True
        End If
        trans.CommitTransaction()


    End Sub

    Private Sub gdvDataError_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles gdvDataError.DataBindingComplete
        For i As Integer = 0 To gdvDataError.Rows.Count - 1
            Select Case gdvDataError.Rows(i).Cells("comment").Value
                Case "NOTBOOK"
                    gdvDataError.Rows(i).DefaultCellStyle.BackColor = Color.Pink
                Case "NOTFOUND"
                    gdvDataError.Rows(i).DefaultCellStyle.BackColor = Color.Khaki
                Case "NOTSUBFILE"
                    gdvDataError.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
            End Select
            gdvDataError.Rows(i).DefaultCellStyle.SelectionBackColor = gdvDataError.Rows(i).DefaultCellStyle.BackColor
            gdvDataError.Rows(i).DefaultCellStyle.SelectionForeColor = gdvDataError.Rows(i).DefaultCellStyle.ForeColor
        Next
    End Sub

    Private Sub gdvDataBorrow_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles gdvDataBorrow.DataBindingComplete
        For i As Integer = 0 To gdvDataBorrow.Rows.Count - 1
            Select Case gdvDataBorrow.Rows(i).Cells("ReadBy").Value
                Case "RFID"
                    gdvDataBorrow.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 128)
                Case "BARCODE"
                    gdvDataBorrow.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End Select
            gdvDataBorrow.Rows(i).DefaultCellStyle.SelectionBackColor = gdvDataBorrow.Rows(i).DefaultCellStyle.BackColor
            gdvDataBorrow.Rows(i).DefaultCellStyle.SelectionForeColor = gdvDataBorrow.Rows(i).DefaultCellStyle.ForeColor
        Next
    End Sub

    Private Sub gdvDataBook_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles gdvDataBook.DataBindingComplete
        Dim dt As New DataTable
        dt = dt_Book
        For i As Integer = 0 To gdvDataBook.Rows.Count - 1
            Select Case gdvDataBook.Rows(i).Cells("borrow_status").Value
                Case "Y"
                    gdvDataBook.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End Select

            gdvDataBook.Rows(i).DefaultCellStyle.SelectionBackColor = gdvDataBook.Rows(i).DefaultCellStyle.BackColor
            gdvDataBook.Rows(i).DefaultCellStyle.SelectionForeColor = gdvDataBook.Rows(i).DefaultCellStyle.ForeColor
        Next
    End Sub

    Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Dim strText As String = txtBarcode.Text.Replace("*", "").Replace("'", "''")
            If Not IsNumeric(strText) Then
                MsgBox("กรุณากรอก Barcode เป็นตัวเลข")
                Exit Sub
            ElseIf strText.Length <> 10 Then
                MsgBox("กรุณากรอก Barcode 10 หลัก")
                Exit Sub
            End If
            txtBarcode.Text = txtBarcode.Text.Replace("*", "")
            GetDataBorrow(txtBarcode.Text.Replace("'", "''"), "BARCODE", Nothing)

            'Dim dvBorrow As DataView
            'dvBorrow = New DataView(dt_Borrow.Copy, "", "app_no asc", DataViewRowState.CurrentRows)
            'Dim dvError As DataView
            'dvError = New DataView(dt_Error.Copy, "", "app_no asc", DataViewRowState.CurrentRows)
            'gdvDataBorrow.DataSource = dvBorrow
            'gdvDataError.DataSource = dvError
            gdvDataBorrow.DataSource = dt_Borrow
            gdvDataError.DataSource = dt_Error
            'GroupBox2.Text = "จำนวนรายการที่มีปัญหาทั้งหมด " & gdvDataError.Rows.Count + Count_Error & " รายการ"
            'GroupBox3.Text = "จำนวนรายการยืมทั้งหมด " & gdvDataBorrow.Rows.Count + Count_Borrow & " รายการ"

            'lblE_txtload.Visible = False
            lblE_txt1.Visible = True
            lblE_txt2.Visible = True
            lblE_count.Visible = True
            lblE_count.Text = gdvDataError.Rows.Count '+ Count_Error
            'lblB_txtload.Visible = False
            lblB_txt1.Visible = True
            lblB_txt2.Visible = True
            lblB_count.Visible = True
            lblB_count.Text = gdvDataBorrow.Rows.Count '+ Count_Borrow

            txtBarcode.Text = ""
            txtBarcode.Focus()
            'If dt_Error.Rows.Count > 0 Then
            '    btnSendtoHandheld.Enabled = True
            '    btnSendtoHandheld.BackgroundImage = Image.FromFile("images/blog3_30.jpg")
            'End If
            If ReadBarcodeFromTextFile.GetIsBox = 1 Then
                SetLightRedBorrow()
            End If

        End If
    End Sub

    Sub Get_Dt_Borrow(ByVal dtReturn_borrow As DataTable, ByVal ReadBy As String)
        'Mapping แล้วข้อมูลที่ได้มาตรงกัน  Add ข้อมูล ที่ได้มาเข้า Datable dt_Borrow
        Dim dr As DataRow
        dr = dt_Borrow.NewRow
        dr("seq") = dt_Borrow.Rows.Count + 1
        dr("APP_NO") = dtReturn_borrow(0)("APP_NO")
        dr("member_name") = dtReturn_borrow(0)("member_name")
        dr("ReadBy") = ReadBy
        dr("ReserveID") = dtReturn_borrow(0)("ReserveID")
        dr("reserve_date") = dtReturn_borrow(0)("reserve_date")
        dr("idTB_REQ") = dtReturn_borrow(0)("idTB_REQ")
        dt_Borrow.Rows.Add(dr)

        'ถ้ามีข้อมูลค้างในรายการของ รายการที่มีปัญหา ก็ Clear Record นั้นด้วย
        dt_Error.DefaultView.RowFilter = "APP_NO = '" & dtReturn_borrow(0)("APP_NO") & "'"
        If dt_Error.DefaultView.Count > 0 Then
            '-----------Remove Found
            Dim dt_temp As New DataTable
            dt_Error.DefaultView.RowFilter = "APP_NO <> '" & dtReturn_borrow(0)("APP_NO") & "'"
            dt_temp = dt_Error.DefaultView.ToTable
            If dt_temp.Rows.Count > 0 Then
                dt_Error.Rows.Clear()
                For i As Int32 = 0 To dt_temp.Rows.Count - 1
                    dr = dt_Error.NewRow
                    dr("seq") = i + 1
                    dr("APP_NO") = dt_temp.Rows(i).Item("APP_NO").ToString
                    dr("reserve_date") = dt_temp.Rows(i).Item("reserve_date").ToString
                    dr("reserve_status") = dt_temp.Rows(i).Item("reserve_status").ToString
                    dr("comment") = dt_temp.Rows(i).Item("comment").ToString
                    dr("app_name") = dt_temp.Rows(i).Item("app_name").ToString
                    dr("app_position") = dt_temp.Rows(i).Item("app_position").ToString
                    dt_Error.Rows.Add(dr)
                Next
            Else
                dt_Error.Rows.Clear()
            End If
        End If
        dt_Error.DefaultView.RowFilter = ""

        'เพิ่ม สถานะใน List รายการจอง ว่า หาเจอแล้ว
        For i As Int32 = 0 To dt_Book.Rows.Count - 1
            If dt_Book.Rows(i).Item("APP_NO").ToString = dtReturn_borrow(0)("APP_NO").ToString Then
                dt_Book.Rows(i)("borrow_status") = "Y"
            End If
        Next

    End Sub

    Sub Get_Dt_Borrow_Error(ByVal dtReturn_borrow As DataTable, ByVal Comment As String)
        Dim dr As DataRow
        dr = dt_Error.NewRow
        dr("seq") = dt_Error.Rows.Count + 1
        dr("APP_NO") = dtReturn_borrow.Rows(0).Item("APP_NO").ToString
        dr("reserve_date") = dtReturn_borrow.Rows(0).Item("reserve_date").ToString
        dr("reserve_status") = dtReturn_borrow.Rows(0).Item("reserve_status").ToString
        dr("comment") = Comment
        dr("app_name") = dtReturn_borrow.Rows(0).Item("app_name").ToString
        dr("app_position") = dtReturn_borrow.Rows(0).Item("app_position").ToString
        dt_Error.Rows.Add(dr)
    End Sub

    Private Sub btnSendtoHandheld_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendtoHandheld.Click
        Dim rapi As New RAPI
        If rapi.DevicePresent = False Then
            MsgBox("อุปกรณ์ต่อพ่วงไม่มีการเชื่อมต่อ")
            Exit Sub
        End If

        Dim dt_temp As New DataTable
        'dt_Error.DefaultView.RowFilter = "comment <> 'NOTBOOK'"

        If dt_Book.DefaultView.Count > 0 Then
            dt_temp = dt_Book.DefaultView.ToTable
            '---------- ส่ง DataTable ตามโครวสร้างด้านลางมา-----------
            Dim DT As New DataTable
            Dim DR As DataRow
            DT.Columns.Add("APP_NO") '------------รหัส Patent----------
            DT.Columns.Add("APP_NAME") '--------------ชื่อ Patent---------
            DT.Columns.Add("APP_POSITION") '-------------ตำแหน่งที่เก็บ-------------
            DT.Columns.Add("LOAD_DATETIME") '----------เวลาที่ Load เข้า -----------
            DT.Columns.Add("FIND_STATUS") '0 = Not found , 1 = Found , 2 = Post

            For i As Int32 = 0 To dt_temp.Rows.Count - 1
                DR = DT.NewRow
                DR("APP_NO") = dt_temp.Rows(i).Item("APP_NO").ToString
                DR("APP_NAME") = dt_temp.Rows(i).Item("app_name").ToString
                DR("APP_POSITION") = ""
                DR("LOAD_DATETIME") = Now.ToOADate
                DR("FIND_STATUS") = "0"
                DT.Rows.Add(DR)
            Next

            Dim frm As New frmMobile
            frm.SyncFor = frmMobile.TASK_TYPE.Export
            frm.ExportList = DT
            frm.ShowDialog()
        End If
        dt_Borrow.DefaultView.RowFilter = ""
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'ลบ Temp
        SqlDB.ExecuteNonQuery("DELETE FROM TMP_GATE_READER_TAG where Reader_id=" & ReadBarcodeFromTextFile.GetReaderId)

        api.CloseCommPort()
        Timer1.Enabled = False
        Clear()
    End Sub

    Sub Clear()
        'Clear Page
        txtJobNo.Focus()
        txtJobNo.Text = ""
        txtBarcode.Text = ""
        dt_Book.Rows.Clear()
        dt_Borrow.Rows.Clear()
        dt_Error.Rows.Clear()
        'GroupBox1.Text = "รายการจอง"
        'GroupBox2.Text = "รายการที่มีปัญหา"
        'GroupBox3.Text = "รายการยืม"
        'lblR_txtload.Visible = True
        lblR_txt1.Visible = False
        lblR_txt2.Visible = False
        lblR_count.Visible = False
        'lblE_txtload.Visible = True
        lblE_txt1.Visible = False
        lblE_txt2.Visible = False
        lblE_count.Visible = False
        'lblB_txtload.Visible = True
        lblB_txt1.Visible = False
        lblB_txt2.Visible = False
        lblB_count.Visible = False
        btnReadRFID.Enabled = False
        btnReadRFID.BackgroundImage = Image.FromFile("images/Dis_blog3_09.jpg")
        btnSendtoHandheld.Enabled = False
        btnSendtoHandheld.BackgroundImage = Image.FromFile("images/Dis_blog3_30.jpg")
        btnComfirm.Enabled = False
        btnComfirm.BackgroundImage = Image.FromFile("images/Dis_blog3_26.jpg")
        btnPrint.Enabled = False
        btnPrint.BackgroundImage = Image.FromFile("images/Dis_blog3_29.jpg")
        txtBarcode.Enabled = False
        txtJobNo.Enabled = True
    End Sub

    Private Sub frmBorrow_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.ControlBox = False
    End Sub

    Private Sub frmBorrow_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        With dt_Borrow
            .Columns.Add("seq", GetType(System.String))
            .Columns.Add("APP_NO", GetType(System.String))
            .Columns.Add("member_name", GetType(System.String))
            .Columns.Add("ReadBy", GetType(System.String))
            .Columns.Add("ReserveID", GetType(System.String))
            .Columns.Add("reserve_date", GetType(System.String))
            .Columns.Add("idTB_REQ", GetType(System.String))
        End With

        With dt_Error
            .Columns.Add("seq", GetType(System.String))
            .Columns.Add("APP_NO", GetType(System.String))
            .Columns.Add("reserve_date", GetType(System.String))
            .Columns.Add("reserve_status", GetType(System.String))
            .Columns.Add("comment", GetType(System.String))
            .Columns.Add("app_name", GetType(System.String))
            .Columns.Add("app_position", GetType(System.String))
        End With

    End Sub

    Private Sub ReadWriteModule()
        Dim ExePath As String = IO.Path.Combine(Windows.Forms.Application.StartupPath & "\RFID", "RFID.exe")
        Dim Result As Integer
        Using p As New Process()
            With p.StartInfo
                .FileName = ExePath
                .Arguments = ""
            End With

            p.Start()
            p.WaitForExit()
            Result = p.ExitCode
        End Using
        'MsgBox(String.Format("ExitCode: {0}", Result))
    End Sub


    Private Sub InsertDataModule()
        Dim ReadTextFile As New ReadBarcodeFromTextFile
        ' Dim RT As DataTable = ReadTextFile.ReadTextFileModule()
        Dim IsInsert As Boolean = ReadTextFile.ReadTextFileModuleAndInsertToTemp(1)
        If IsInsert = False Then
            '-------------- Display Error -------------
            MsgBox("ไม่สามารถอ่านไฟล์รายงานผลได้")
            Exit Sub
        End If
    End Sub

    Private Sub btnReadRFID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadRFID.Click
        Try

            btnReadRFID.Enabled = False
            btnReadRFID.BackgroundImage = Image.FromFile("images/Dis_blog3_09.jpg")

            If ReadBarcodeFromTextFile.GetModuleRead = 1 Then
                ReadWriteModule()
                InsertDataModule()
            End If



            '   Timer1.Enabled = False

            Dim ini As New IniReader(INIFlieName)
            ini.Section = "SETTING"
            ''Read RFID
            api.OpenCommPort(Trim("COM" + ini.ReadString("CR_ComPort")))
            api.ClearIdBuf()
            TagCnt = 0
            ReadTime = 0
            dt_RFID = New DataTable
            dt_RFID.Columns.Add("APP_NO")
            dt_RFID.Columns.Add("APP_NO10")

            ''Read DB
            'dt_RFID = New DataTable
            'dt_RFID = ReadDB()

            ReadBorrow()

            'สั่งให้ Timer ทำงาน
            'Timer1.Enabled = True
        Catch ex As Exception
            btnReadRFID.Enabled = True
            btnReadRFID.BackgroundImage = Image.FromFile("images/blog3_09.jpg")
        End Try

        ''ส่วน(Test)
        ''********* จำลองข้อมูลจาก RFID ไว้ใน Datatable *********
        'Dim dt As New DataTable
        'dt = TestRFID()
        ''*************************************************

        'Count_Borrow = 0 'เคลียร์ค่าจำนวนของแฟ้มต่อ ที่อยู่ในรายการยืม 
        'Count_Error = 0 'เคลียร์ค่าจำนวนของแฟ้มต่อ ที่อยู่ในรายการที่มีปัญหา

        ''** กรองหมายเลขแฟ้มที่ได้มาจาก RFID ให้เหลือ 10 หลัก และไม่ซ้ำกัน **
        'Dim dt_AppNo As New DataTable
        'With dt_AppNo
        '    .Columns.Add("APP_NO", GetType(System.String))
        'End With

        'Dim dr As DataRow
        'Dim AppNo As String = ""
        'For i As Int32 = 0 To dt.Rows.Count - 1
        '    If dt.Rows(i).Item("APP_NO").ToString.Length > 9 Then
        '        AppNo = dt.Rows(i).Item("APP_NO").ToString.Substring(0, 10)
        '        dt_AppNo.DefaultView.RowFilter = "APP_NO = '" & AppNo & "'"
        '        If dt_AppNo.DefaultView.Count = 0 Then
        '            dr = dt_AppNo.NewRow
        '            dr("APP_NO") = dt.Rows(i).Item("APP_NO").ToString.Substring(0, 10)
        '            dt_AppNo.Rows.Add(dr)
        '        End If
        '        dt_AppNo.DefaultView.RowFilter = ""
        '    End If
        'Next
        ''****************************************************

        'If dt_AppNo.Rows.Count > 0 Then
        '    For i As Int32 = 0 To dt_AppNo.Rows.Count - 1
        '        '********* Mapping Data *********
        '        GetDataBorrow(dt_AppNo.Rows(i).Item("APP_NO").ToString.Trim, "RFID", dt)
        '        '********************************
        '    Next
        '    '***** หารายการที่หาไม่มีในใบจอง *****
        '    Req_NOTFOUND()
        '    '******************************

        '    gdvDataBorrow.DataSource = dt_Borrow
        '    gdvDataError.DataSource = dt_Error
        '    GroupBox2.Text = "จำนวนรายการที่มีปัญหาทั้งหมด " & gdvDataError.Rows.Count + Count_Error & " รายการ"
        '    GroupBox3.Text = "จำนวนรายการยืมทั้งหมด " & gdvDataBorrow.Rows.Count + Count_Borrow & " รายการ"

        'End If

        'If dt_Error.Rows.Count > 0 Then
        '    btnSendtoHandheld.Enabled = True
        'Else
        '    btnSendtoHandheld.Enabled = False
        'End If
    End Sub

    Sub Req_NOTFOUND()
        If gdvDataBook.Rows.Count > 0 Then
            Dim dt As New DataTable
            Dim dtBook As DataTable = gdvDataBook.DataSource
            For i As Int32 = 0 To dtBook.Rows.Count - 1
                dt_Borrow.DefaultView.RowFilter = "APP_NO = '" & dtBook.Rows(i).Item("APP_NO").ToString.Trim & "'"
                dt_Error.DefaultView.RowFilter = "APP_NO = '" & dtBook.Rows(i).Item("APP_NO").ToString.Trim & "'"
                If dt_Borrow.DefaultView.Count = 0 Then
                    If dt_Error.DefaultView.Count = 0 Then
                        Dim dr As DataRow
                        dr = dt_Error.NewRow
                        dr("seq") = dt_Error.Rows.Count + 1
                        dr("APP_NO") = dtBook.Rows(i).Item("APP_NO").ToString.Trim
                        dr("reserve_date") = dtBook.Rows(i).Item("reserve_date").ToString.Trim
                        dr("reserve_status") = dtBook.Rows(i).Item("reserve_status").ToString.Trim
                        dr("comment") = "NOTFOUND"
                        dr("app_name") = dtBook.Rows(i).Item("app_name").ToString.Trim
                        dr("app_position") = dtBook.Rows(i).Item("app_position").ToString.Trim
                        dt_Error.Rows.Add(dr)
                    End If
                End If
            Next
            dt_Borrow.DefaultView.RowFilter = ""
            dt_Error.DefaultView.RowFilter = ""
        End If
    End Sub

    Sub Req_NOTBOOK(ByVal reg_no As String, ByVal ReadBy As String)
        'Dim dal As New TbFileBorrowDAL
        'dt_Error.DefaultView.RowFilter = "APP_NO = '" & reg_no & "'"
        'If dt_Error.DefaultView.Count = 0 Then
        '    Dim dt As New DataTable
        '    dt = gdvDataBook.DataSource
        '    dt.DefaultView.RowFilter = "APP_NO = '" & reg_no & "'"
        '    If dt.DefaultView.Count > 0 Then
        '        Get_Dt_Borrow_Error(dt.DefaultView.ToTable, "NOTBOOK")
        '    Else
        '        If ReadBy = "BARCODE" Then
        '            dt_Error.DefaultView.RowFilter = ""
        '            dt_Book.DefaultView.RowFilter = ""
        '            dt_Borrow.DefaultView.RowFilter = ""
        '            MsgBox("ไม่พบข้อมูล")
        '        End If
        '    End If
        'End If

        Dim dal As New TbFileBorrowDAL
        dt_Error.DefaultView.RowFilter = "APP_NO = '" & reg_no & "'"
        If dt_Error.DefaultView.Count = 0 Then
            Dim dt As New DataTable
            Dim sql As String = "SELECT TB_REQ.app_no,  " & vbNewLine
            sql &= " CONVERT(varchar(10),DATEADD(YYYY,543, reserve_date),103) as reserve_date, " & vbNewLine
            sql &= " case when reserve_status = 'N' then 'ไม่ว่าง' else 'ว่าง' end as reserve_status, " & vbNewLine
            sql &= " TB_R.member_name,TB_REQ.app_name,TB_REQ.app_position FROM TB_RESERVE AS TB_R " & vbNewLine
            sql &= " RIGHT JOIN TB_REQUISTION  as TB_REQ " & vbNewLine
            sql &= " ON TB_R.requidition_id = TB_REQ.id " & vbNewLine
            sql &= " WHERE TB_REQ.app_no = '" & reg_no & "'"
            dt = dal.GetListBySql(sql, "app_no ASC", Nothing)

            If dt.Rows.Count > 0 Then
                Get_Dt_Borrow_Error(dt.DefaultView.ToTable, "NOTBOOK")
            Else
                If ReadBy = "BARCODE" Then
                    dt_Error.DefaultView.RowFilter = ""
                    dt_Book.DefaultView.RowFilter = ""
                    dt_Borrow.DefaultView.RowFilter = ""
                    MsgBox("ไม่พบข้อมูล")

                End If
            End If

        End If

    End Sub

    Sub Req_NotSubFile(ByVal reg_no As String, ByVal ReadBy As String)
        If gdvDataBook.Rows.Count > 0 Then
            Dim dt As New DataTable
            Dim dr As DataRow
            dt_Book.DefaultView.RowFilter = "APP_NO = '" & reg_no & "'"
            dt_Error.DefaultView.RowFilter = "APP_NO = '" & reg_no & "'"
            dt_Borrow.DefaultView.RowFilter = "APP_NO = '" & reg_no & "'"
            If dt_Error.DefaultView.Count = 0 And dt_Borrow.DefaultView.Count = 0 Then
                dt = dt_Book.DefaultView.ToTable
                dr = dt_Error.NewRow
                dr("seq") = dt_Error.Rows.Count + 1
                dr("APP_NO") = dt.Rows(0).Item("APP_NO").ToString.Trim
                dr("reserve_date") = dt.Rows(0).Item("reserve_date").ToString.Trim
                dr("reserve_status") = dt.Rows(0).Item("reserve_status").ToString.Trim
                dr("comment") = "NOTSUBFILE"
                dr("app_name") = dt.Rows(0).Item("app_name").ToString.Trim
                dr("app_position") = dt.Rows(0).Item("app_position").ToString.Trim
                dt_Error.Rows.Add(dr)

            ElseIf dt_Error.DefaultView.Count > 0 And dt_Borrow.DefaultView.Count = 0 Then
                '***********************************
                'ถ้ามีข้อมูลค้างในรายการของ รายการที่มีปัญหา ก็ Clear Record นั้นด้วย
                '-----------Remove Found
                Dim dt_temp As New DataTable
                dt_Error.DefaultView.RowFilter = "APP_NO <> '" & reg_no & "'"
                dt_temp = dt_Error.DefaultView.ToTable
                If dt_temp.Rows.Count > 0 Then
                    dt_Error.Rows.Clear()
                    For i As Int32 = 0 To dt_temp.Rows.Count - 1
                        dr = dt_Error.NewRow
                        dr("seq") = i + 1
                        dr("APP_NO") = dt_temp.Rows(i).Item("APP_NO").ToString
                        dr("reserve_date") = dt_temp.Rows(i).Item("reserve_date").ToString
                        dr("reserve_status") = dt_temp.Rows(i).Item("reserve_status").ToString
                        dr("comment") = dt_temp.Rows(i).Item("comment").ToString
                        dr("app_name") = dt_temp.Rows(i).Item("app_name").ToString
                        dr("app_position") = dt_temp.Rows(i).Item("app_position").ToString
                        dt_Error.Rows.Add(dr)
                    Next

                    dt = dt_Book.DefaultView.ToTable
                    dr = dt_Error.NewRow
                    dr("seq") = dt_Error.Rows.Count + 1
                    dr("APP_NO") = dt.Rows(0).Item("APP_NO").ToString.Trim
                    dr("reserve_date") = dt.Rows(0).Item("reserve_date").ToString.Trim
                    dr("reserve_status") = dt.Rows(0).Item("reserve_status").ToString.Trim
                    dr("comment") = "NOTSUBFILE"
                    dr("app_name") = dt.Rows(0).Item("app_name").ToString.Trim
                    dr("app_position") = dt.Rows(0).Item("app_position").ToString.Trim
                    dt_Error.Rows.Add(dr)
                Else
                    dt_Error.Rows.Clear()

                End If
                '***********************************

            End If
            dt_Error.DefaultView.RowFilter = ""
            dt_Book.DefaultView.RowFilter = ""
            dt_Borrow.DefaultView.RowFilter = ""
        End If
    End Sub

    Sub GetDataBorrow(ByVal reg_no As String, ByVal Readby As String, ByVal dt_RFID_Read As DataTable)
        If gdvDataBook.Rows.Count > 0 Then
            Dim dt As New DataTable
            Dim dtBook As DataTable = gdvDataBook.DataSource
            'เอา DT ที่ได้ไปเปรียบเทียบกับ gdvDataBook เพื่อโยนค่าที่ได้ไปใส่ gdvDataError และ gdvDataBorrow
            dtBook.DefaultView.RowFilter = "APP_NO = '" & reg_no & "'"
            dt_Borrow.DefaultView.RowFilter = "APP_NO = '" & reg_no & "'"
            dt_Error.DefaultView.RowFilter = "APP_NO = '" & reg_no & "'"


            If dtBook.DefaultView.Count > 0 Then
                '1. เช็คว่าเป็นรายการที่มีแฟ้มต่อหรือไม่ ถ้ามีแฟ้มต่อ ก็ตรวจสอบดูว่าแฟ้มต่อครบตามจำนวนหรือไม่
                If Check_Req_Qty(reg_no, dt_RFID_Read) = True Then
                    '2. แสดงว่าเป็นแฟ้มที่มีอยู่ในรายการจอง 
                    If dt_Borrow.DefaultView.Count = 0 Then
                        Get_Dt_Borrow(dtBook.DefaultView.ToTable, Readby)
                    End If
                    btnComfirm.Enabled = True
                    btnComfirm.BackgroundImage = Image.FromFile("images/blog3_26.jpg")
                Else
                    'แสดงว่าแฟ้มต่อไม่ครบจำนวนที่หาได้
                    Req_NotSubFile(reg_no, Readby)
                End If
            Else
                '3. Mapping แล้วข้อมูลที่ได้มาตรงไม่กัน แสดงว่าเป็นรายการที่หาไม่พบ
                Req_NOTBOOK(reg_no, Readby)

            End If
            'คืนค่าให้ DT
            dtBook.DefaultView.RowFilter = ""
            dt_Borrow.DefaultView.RowFilter = ""
            dt_Error.DefaultView.RowFilter = ""
        End If
    End Sub

    Function Check_Req_Qty(ByVal req As String, ByVal dt_RFID_Read As DataTable) As Boolean
        'เช็คว่าเป็นรายการที่มีแฟ้มต่อหรือไม่ ถ้ามีแฟ้มต่อ ก็ตรวจสอบดูว่าแฟ้มต่อครบตามจำนวนหรือไม่
        Dim ret As Boolean = False
        Dim dal As New TbRequisitionDAL
        Dim data As New TbRequisitionData
        If dt_RFID_Read Is Nothing Then
            'อ่านจาก Barcode ให้ข้ามการทำงานไป
            ret = True
        ElseIf dal.ChkDataByWhere("APP_NO = " & req & " and qty > 1", Nothing) = True Then
            'มีแฟ้มต่อ
            Dim qty As Int32 = 0
            data = dal.GetDataByAPP_NO(req, Nothing)
            qty = data.QTY
            dt_RFID_Read.DefaultView.RowFilter = "APP_NO LIKE '" & req & "%'"
            If dt_RFID_Read.DefaultView.Count >= qty Then
                'แฟ้มต่อครบ
                ret = True
                'Count_Borrow = Count_Borrow + dt_RFID_Read.DefaultView.Count - 1 'จำนวนของแฟ้มต่อ ที่อยู่ในรายการยืม 
                dt_RFID_Read.DefaultView.RowFilter = ""
            Else
                ret = False
                'Count_Error = Count_Error + dt_RFID_Read.DefaultView.Count - 1 'จำนวนของแฟ้มต่อ ที่อยู่ในรายการที่มีปัญหา
            End If
        Else
            'ไม่มีแฟ้มต่อ
            ret = True

        End If
        Return ret
    End Function

    'ข้อมูล Test
    Function TestRFID() As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim requidition_id(11) As String
        requidition_id(0) = "100300000701"
        requidition_id(1) = "100300000601"
        requidition_id(2) = "100300000501"
        requidition_id(3) = "100300000801"

        With dt
            .Columns.Add("APP_NO", GetType(System.String))
        End With

        For i As Int32 = 0 To requidition_id.Count - 1
            dr = dt.NewRow
            dr("APP_NO") = requidition_id(i)
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Private Sub btnComfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComfirm.Click
        'Insert to TB_FILEBORROW and TB_FILEBORROWITEM
        'Set isUpdate_innova_borrow = Y TB_FILEBORROWITEM
        'Scan_by= R,B อ่านด้วยอะไร

        'If gdvDataBook.RowCount <> gdvDataBorrow.RowCount Then
        '    MsgBox("ยังทำรายการยืมไม่ครบ")
        '    Exit Sub
        'End If
        Dim strApp_no As String = ""
        Dim dal As New TbFileBorrowDAL
        Dim ret As Boolean = True
        Dim trans As New SqlTransactionDB
        trans.CreateTransaction()

        If gdvDataBorrow.Rows.Count > 0 Then
            'Insert TbFileBorrow
            dal = New TbFileBorrowDAL
            dal.FILEBORROW_CODE = GenFILEBorrowCode(trans.Trans)
            dal.RESERVE_JOB_ID = lblJob_Id.Text
            dal.BORROWER_ID = lblMemberID.Text
            dal.BORROWERNAME = lblName.Text
            dal.BORROWERSTATUS = "B"
            dal.BORROWERDATE = DateTime.Now
            ret = dal.InsertData(frmMain.txtUserName.Text, trans.Trans)
            If ret = True Then
                'Insert TbFileBorrowItem
                _BorrowID = dal.ID
                For i As Integer = 0 To gdvDataBorrow.RowCount - 1
                    Dim rDal As New TbReserveDAL
                    Dim rData As New TbReserveData
                    rData = rDal.GetDataByid(gdvDataBorrow.Rows(i).Cells("ReserveID_Borrow").Value.ToString, trans.Trans)

                    Dim dalItem As New TbFileBorrowItemDAL
                    dalItem.FILEBORROW_ID = dal.ID
                    dalItem.REQUISITION_ID = gdvDataBorrow.Rows(i).Cells("idTB_REQ").Value.ToString
                    dalItem.RESERVE_ID = rData.ID
                    dalItem.RESERVEDATE = lblDate.Text
                    dalItem.SCAN_BY = gdvDataBorrow.Rows(i).Cells("ReadBy").Value.ToString
                    If gdvDataBorrow.Rows(i).Cells("ReadBy").Value = "RFID" Then
                        dalItem.SCAN_BY = "R"
                    Else
                        dalItem.SCAN_BY = "B"
                    End If

                    If Func.UpdateStatusToInnova("B", CStr(rData.REF_INNOVA_ID), frmMain.txtIdUser.Text, "") = True Then  'B = ยืมแฟ้มที่ห้องแฟ้ม
                        dalItem.ISUPDATE_INNOVA_BORROW = "Y"
                        '***************************** Insert Log ********************************
                        Dim id As String = GetRef_Innova_Id()
                        sql = "insert into TB_LOG_UPDATE_TO_INNOVA(ID,REF_INNOVA_ID,APP_NO,B_BORROWSTATUS,B_GETDATE,B_OFFICERAPPROVE,B_BORROWDATE,CREATEBY,CREATEON) values('" & id & "','" & rData.REF_INNOVA_ID & "','" & rData.REQUIDITION_ID & "','B',GETDATE(),'" & frmMain.txtIdUser.Text & "',GETDATE(),'" & frmMain.txtIdUser.Text & "',GETDATE())"
                        SqlDB.ExecuteTable(sql)
                        '******************** Update Status แฟ้ม ที่ TB_Reserve **********************
                        sql = "Update TB_RESERVE set reserve_status = 'N' where requidition_id = '" & rData.REQUIDITION_ID & "' and borrowstatus = 'B'"
                        SqlDB.ExecuteTable(sql)
                        '*************************************************************************
                    Else
                        dalItem.ISUPDATE_INNOVA_BORROW = "N"
                    End If

                    ret = dalItem.InsertData(frmMain.txtUserName.Text, trans.Trans)

                    If ret = True Then

                        If strApp_no = "" Then
                            strApp_no = "'" & gdvDataBorrow.Rows(i).Cells("APP_NO").Value.ToString & "'"
                        Else
                            strApp_no &= ",'" & gdvDataBorrow.Rows(i).Cells("APP_NO").Value.ToString & "'"
                        End If

                        Dim TmpDal As New TmpFileborrowItemDAL
                        TmpDal.FILEBORROWITEM_ID = dalItem.ID
                        TmpDal.APP_NO = gdvDataBorrow.Rows(i).Cells("APP_NO").Value.ToString
                        TmpDal.RESERVEDATE = dalItem.RESERVEDATE
                        TmpDal.BORROWDATE = dal.BORROWERDATE
                        TmpDal.BORROWER_ID = dal.BORROWER_ID
                        TmpDal.BORROWER_NAME = dal.BORROWERNAME
                        ret = TmpDal.InsertData(frmMain.txtUserName.Text.Trim, trans.Trans)
                        If ret = False Then
                            _err = TmpDal.ErrorMessage
                            Exit For
                        End If
                    Else
                        _err = dalItem.ErrorMessage
                        Exit For
                    End If
                Next
            Else
                _err = dal.ErrorMessage

            End If

            'ยืนยันเสร็จให้ลบ Temp
            SqlDB.ExecuteNonQuery("DELETE FROM TMP_GATE_READER_TAG WHERE Reader_id=" & ReadBarcodeFromTextFile.GetReaderId, trans.Trans)

            'Update Last Location ว่าเป็นการยืมแฟ้ม
            ret = UpdateLocationByBorrow(strApp_no)

            ''###############  Insert FileLost ###########################
            'Try
            '    Dim bDt As DataTable = gdvDataBorrow.DataSource
            '    For i As Integer = 0 To gdvDataBook.RowCount - 1
            '        Dim appNO As String = gdvDataBook.Rows(i).Cells("resv_app_no").Value
            '        bDt.DefaultView.RowFilter = "app_no='" & appNO & "'"
            '        If bDt.DefaultView.Count = 0 Then
            '            Dim s As String = "insert into TS_FILE_LOST (created_by, created_date,app_no,lost_date,discover_msg)"
            '            s += " values('" & frmMain.txtUserName.Text.Trim & "',getdate(),'" & appNO & "',getdate(),'พบแฟ้มที่สูญหาย')"

            '            If SqlDB.ExecuteNonQuery(s, trans.Trans) = 0 Then
            '                ret = False
            '                Exit For
            '            End If
            '        End If
            '        bDt.DefaultView.RowFilter = ""
            '    Next
            'Catch ex As Exception
            '    ret = False
            'End Try
            ''###############  Insert FileLost ###########################


            If ret = True Then
                trans.CommitTransaction()
                MsgBox("บันทึกข้อมูลเรียบร้อย")
                btnReadRFID.Enabled = False
                btnReadRFID.BackgroundImage = Image.FromFile("images/Dis_blog3_09.jpg")
                btnPrint.Enabled = True
                btnPrint.BackgroundImage = Image.FromFile("images/blog3_29.jpg")
                btnComfirm.Enabled = False
                btnComfirm.BackgroundImage = Image.FromFile("images/Dis_blog3_26.jpg")
                txtBarcode.Enabled = False
                txtJobNo.Enabled = False
                Timer1.Enabled = False
            Else
                trans.RollbackTransaction()
                MsgBox(_err)
            End If
        End If
    End Sub

    Private Function UpdateLocationByBorrow(ByVal strApp_no As String) As Boolean
        Try
            Dim ReaderID As String = ReadBarcodeFromTextFile.GetReaderId

            Dim strSQlUpdate As String
            strSQlUpdate = "update ts_file_current_location"
            strSQlUpdate &= " set  ts_file_current_location.ms_room_id =  (select top 1 fl.ms_room_id from tb_filelocation fl where fl.readerid='" & ReaderID & "')"
            strSQlUpdate &= " ,ts_file_current_location.location_name =  (select top 1 fl.location_name from tb_filelocation fl where fl.readerid='" & ReaderID & "')"
            strSQlUpdate &= " ,ts_file_current_location.ms_desktop_id = 0"
            strSQlUpdate &= " ,ts_file_current_location.desk_name = null"
            strSQlUpdate &= " ,ts_file_current_location.readerid = 0"
            strSQlUpdate &= " ,ts_file_current_location.rssi = 0"
            strSQlUpdate &= " where ts_file_current_location.app_no in (" & strApp_no & ")"
            SqlDB.ExecuteNonQuery(strSQlUpdate)


            Dim sql As String = "UPDATE TB_REQUISTION "
            sql += " SET updateon=getdate(), "
            sql += " filelocation = (select id  from TB_FILELOCATION  where  Readerid=" & ReaderID & ")"
            sql += " WHERE APP_NO in (" & strApp_no & ")"
            SqlDB.ExecuteNonQuery(sql)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function GetReserveDataByID(ByVal id As Integer, ByVal trans As SqlTransaction) As TbReserveData
        Dim dal As New TbReserveDAL
        Return dal.GetDataByid(id, trans)
    End Function

    Private Function GenFILEBorrowCode(ByVal trans As SqlTransaction) As String
        'Reserve Code Format : yyMM0000 เช่น 53120001
        Dim ret As String = ""
        Dim vMM As String = Today.Month.ToString.PadLeft(2, "0")
        Dim vYY As String
        If Today.Year > 2500 Then
            vYY = Today.Year.ToString.Substring(2, 2)
        Else
            vYY = (Today.Year + 543).ToString.Substring(2, 2)
        End If

        Dim runNext As Int64
        Dim dal As New TbFileBorrowDAL
        Dim dt As DataTable = dal.GetDataList("substring(fileborrow_code,1,4) = '" & vYY & vMM & "'", "fileborrow_code desc", trans)
        If dt.Rows.Count > 0 Then
            runNext = Convert.ToInt64(dt.Rows(0)("fileborrow_code").ToString.Substring(4)) + 1
        Else
            runNext = 1
        End If

        ret = vYY & vMM & runNext.ToString.PadLeft(4, "0")
        Return ret
    End Function

    Private Function GetRef_Innova_Id() As String
        Dim id As String = ""
        Dim dt As New DataTable
        Dim sql As String = "select isnull(MAX(id),0) + 1 as id from dbo.TB_LOG_UPDATE_TO_INNOVA"
        dt = SqlDB.ExecuteTable(sql)
        If dt.Rows.Count > 0 Then
            id = dt.Rows(0).Item("id").ToString
        End If
        Return id
    End Function

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'Print Report จากรายการจองทั้งหมด และรายการยืมทั้งหมด  by job_id
        btnPrint.Cursor = Cursors.AppStarting
        btnPrint.Enabled = False
        btnPrint.BackgroundImage = Image.FromFile("images/Dis_blog3_29.jpg")
        Dim trans As New SqlTransactionDB
        trans.CreateTransaction()

        Dim logonInfo As New TableLogOnInfo
        logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
        logonInfo.ConnectionInfo.UserID = SqlDB.UserID
        logonInfo.ConnectionInfo.Password = SqlDB.Password

        Dim rep As New rptBorrows
        rep.SetDataSource(GetBorrowData(_BorrowID))
        rep.Database.Tables(0).ApplyLogOnInfo(logonInfo)

        Dim cryViewer As New frmReportPreview
        cryViewer.CrystalReportViewer1.ReportSource = rep
        cryViewer.CrystalReportViewer1.Refresh()
        cryViewer.WindowState = FormWindowState.Maximized
        cryViewer.ShowDialog()

        Clear()

    End Sub

    Private Function GetBorrowData(ByVal BorrowID As Long) As DataTable
        Dim rowPerCol As Integer = 23  'จำนวนแถวใน 1 คอลัมน์ ให้แสดงหน้าละ 3 คอลัมน์
        Dim ret As New DataTable
        sql = "select req.app_no as requisition_id,fb.borrowername as staff_name,"
        sql &= " convert(varchar(20),dateadd(yyyy,543,fb_item.reservedate),103) as reserve_date,"
        sql &= " convert(varchar(20),dateadd(yyyy,543,fb.borrowerdate),103) as borrow_date,"
        sql &= " isnull(tt.title_name,'') + ' ' + isnull(ofc.fname,'') + ' ' + isnull(ofc.lname,'') as createby_staff_name"
        sql &= " from TB_FILEBORROW as fb "
        sql &= " left join TB_FILEBORROWITEM as fb_item on fb.id = fb_item.fileborrow_id "
        sql &= " left join TB_OFFICER as ofc on fb.createby = ofc.username"
        sql &= " left join TB_TITLE as tt on ofc.title_id = tt.id"
        sql &= " left join TB_REQUISTION as req on fb_item.requisition_id = req.id"
        sql &= " where fb.id = '" & BorrowID.ToString & "' order by req.app_no asc"
        'sql &= " where fb.id = '1'"

        Dim dal As New TbReserveDAL
        Dim dt As DataTable = dal.GetListBySql(sql, "", Nothing)
        Dim rowCount As Integer = dt.Rows.Count
        If rowCount > 0 Then
            ret.Columns.Add("run1")
            ret.Columns.Add("req_no1")
            ret.Columns.Add("reserve_date1")
            ret.Columns.Add("run2")
            ret.Columns.Add("req_no2")
            ret.Columns.Add("reserve_date2")
            ret.Columns.Add("run3")
            ret.Columns.Add("req_no3")
            ret.Columns.Add("reserve_date3")
            ret.Columns.Add("borrow_date")
            ret.Columns.Add("staff_name")
            ret.Columns.Add("createby_staff_name")
            ret.Columns.Add("filecount")

            Dim colNo As Integer = 1
            Dim rowNo As Integer = 1
            Dim pageNo As Integer = 1
            For i As Integer = 0 To rowCount - 1
                Dim iRow As Integer = i + 1
                pageNo = Math.Ceiling(iRow / (3 * rowPerCol))
                colNo = Math.Ceiling((iRow - ((3 * rowPerCol) * (pageNo - 1))) / rowPerCol)
                rowNo = iRow - ((rowPerCol * 3) * (pageNo - 1)) - (rowPerCol * (colNo - 1))
                Dim dtRow = rowNo + (rowPerCol * (pageNo - 1))

                If colNo = 1 Then
                    Dim dr As DataRow = ret.NewRow()
                    dr("run1") = i + 1
                    dr("req_no1") = dt.Rows(i)("requisition_id")
                    dr("reserve_date1") = dt.Rows(i)("reserve_date")
                    dr("borrow_date") = dt.Rows(i)("borrow_date")
                    dr("staff_name") = dt.Rows(i)("staff_name")
                    dr("createby_staff_name") = dt.Rows(i)("createby_staff_name")
                    dr("filecount") = rowCount
                    ret.Rows.Add(dr)
                End If
                If colNo = 2 Then
                    ret.Rows(dtRow - 1)("run2") = i + 1
                    ret.Rows(dtRow - 1)("req_no2") = dt.Rows(i)("requisition_id")
                    ret.Rows(dtRow - 1)("reserve_date2") = dt.Rows(i)("reserve_date")
                End If
                If colNo = 3 Then
                    ret.Rows(dtRow - 1)("run3") = i + 1
                    ret.Rows(dtRow - 1)("req_no3") = dt.Rows(i)("requisition_id")
                    ret.Rows(dtRow - 1)("reserve_date3") = dt.Rows(i)("reserve_date")
                End If

                'If (rowNo * pageNo) = (rowPerCol * pageNo) Then
                '    colNo = colNo + 1
                '    rowNo = 1
                'Else
                '    rowNo = rowNo + 1
                'End If
                'If colNo > 3 Then
                '    colNo = 1 'เริ่มนับหนึ่งใหม่ เพื่อให้ขึ้นหน้าใหม่
                '    pageNo = pageNo + 1
                '    rowNo = 1 + (pageNo * rowPerCol)
                'End If

            Next

        End If

        Return ret
    End Function

    Function ReadDB() As DataTable

        Dim dt As New DataTable
        Try
            'Dim ini As New IniReader(INIFlieName)
            'ini.Section = "SETTING"
            'Dim ReaderId As String
            'If Dir(INIFlieName) <> "" Then
            '    ReaderId = ini.ReadString("ReaderId")
            'End If



            Dim trans As New SqlTransactionDB
            Dim sql As String

            sql = "select distinct tag_id as app_no from TMP_GATE_READER_TAG where read_type='1' and reader_id=" & Func.GetReaderId & "  Order By app_no"

            Dim dal As New TbRequisitionDAL

            dt = dal.GetListBySql(sql, "", trans.Trans)


        Catch ex As Exception
        End Try

        Return dt
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try



            Dim rea As New RFIDReader
            'โยนค่า RFID Datatable เข้าไป
            Dim dt As New DataTable
            dt = ReadDB() 'rea.ReadRFID(dt_RFID, api)



            'Count_Borrow = 0 'เคลียร์ค่าจำนวนของแฟ้มต่อ ที่อยู่ในรายการยืม 
            'Count_Error = 0 'เคลียร์ค่าจำนวนของแฟ้มต่อ ที่อยู่ในรายการที่มีปัญหา
            '** กรองหมายเลขแฟ้มที่ได้มาจาก RFID ให้เหลือ 10 หลัก และไม่ซ้ำกัน **
            Dim dt_AppNo As New DataTable
            With dt_AppNo
                .Columns.Add("APP_NO", GetType(System.String))
            End With

            Dim dr As DataRow
            Dim AppNo As String = ""
            For i As Int32 = 0 To dt.Rows.Count - 1
                If dt.Rows(i).Item("APP_NO").ToString.Length >= 10 Then
                    AppNo = dt.Rows(i).Item("APP_NO").ToString.Substring(0, 10)
                    dt_AppNo.DefaultView.RowFilter = "APP_NO = '" & AppNo & "'"
                    If dt_AppNo.DefaultView.Count = 0 Then
                        dr = dt_AppNo.NewRow
                        dr("APP_NO") = dt.Rows(i).Item("APP_NO").ToString.Substring(0, 10)
                        dt_AppNo.Rows.Add(dr)
                    End If
                    dt_AppNo.DefaultView.RowFilter = ""
                End If
            Next
            '****************************************************

            If dt_AppNo.Rows.Count > 0 Then
                For i As Int32 = 0 To dt_AppNo.Rows.Count - 1
                    '********* Mapping Data *********
                    GetDataBorrow(dt_AppNo.Rows(i).Item("APP_NO").ToString.Trim, "RFID", dt)
                    '********************************

                Next
            End If
            '***** หารายการที่หาไม่มีในใบจอง และรายการมีปัญหาที่เหลือ *****
            Req_NOTFOUND()
            '************************************************
            gdvDataBorrow.DataSource = dt_Borrow
            gdvDataError.DataSource = dt_Error

            'GroupBox2.Text = "จำนวนรายการที่มีปัญหาทั้งหมด " & gdvDataError.Rows.Count + Count_Error & " รายการ"
            'GroupBox3.Text = "จำนวนรายการยืมทั้งหมด " & gdvDataBorrow.Rows.Count + Count_Borrow & " รายการ"

            'lblE_txtload.Visible = False
            lblE_txt1.Visible = True
            lblE_txt2.Visible = True
            lblE_count.Visible = True
            lblE_count.Text = gdvDataError.Rows.Count '+ Count_Error
            'lblB_txtload.Visible = False
            lblB_txt1.Visible = True
            lblB_txt2.Visible = True
            lblB_count.Visible = True
            lblB_count.Text = gdvDataBorrow.Rows.Count '+ Count_Borrow

            'If dt_Error.Rows.Count > 0 Then
            '    ' btnSendtoHandheld.Enabled = True
            '    ' btnSendtoHandheld.BackgroundImage = Image.FromFile("images/blog3_30.jpg")
            'Else
            '    'btnSendtoHandheld.Enabled = False
            '    'btnSendtoHandheld.BackgroundImage = Image.FromFile("images/Dis_blog3_30.jpg")

            'End If

            ReadTime += Timer1.Interval
            If ReadTime / 1000 >= ReadMinute Then
                api.CloseCommPort()
                Timer1.Enabled = False
                btnReadRFID.Enabled = True
                btnReadRFID.BackgroundImage = Image.FromFile("images/blog3_09.jpg")
                If ReadBarcodeFromTextFile.GetIsBox = 1 Then
                    SetLightRedBorrow()
                End If

            End If
        Catch ex As Exception
            btnReadRFID.Enabled = True
            btnReadRFID.BackgroundImage = Image.FromFile("images/blog3_09.jpg")
        End Try

    End Sub
    Private Sub ReadBorrow()
        Try



            Dim rea As New RFIDReader
            'โยนค่า RFID Datatable เข้าไป
            Dim dt As New DataTable
            dt = ReadDB() 'rea.ReadRFID(dt_RFID, api)



            'Count_Borrow = 0 'เคลียร์ค่าจำนวนของแฟ้มต่อ ที่อยู่ในรายการยืม 
            'Count_Error = 0 'เคลียร์ค่าจำนวนของแฟ้มต่อ ที่อยู่ในรายการที่มีปัญหา
            '** กรองหมายเลขแฟ้มที่ได้มาจาก RFID ให้เหลือ 10 หลัก และไม่ซ้ำกัน **
            Dim dt_AppNo As New DataTable
            With dt_AppNo
                .Columns.Add("APP_NO", GetType(System.String))
            End With

            Dim dr As DataRow
            Dim AppNo As String = ""
            For i As Int32 = 0 To dt.Rows.Count - 1
                If dt.Rows(i).Item("APP_NO").ToString.Length >= 10 Then
                    AppNo = dt.Rows(i).Item("APP_NO").ToString.Substring(0, 10)
                    dt_AppNo.DefaultView.RowFilter = "APP_NO = '" & AppNo & "'"
                    If dt_AppNo.DefaultView.Count = 0 Then
                        dr = dt_AppNo.NewRow
                        dr("APP_NO") = dt.Rows(i).Item("APP_NO").ToString.Substring(0, 10)
                        dt_AppNo.Rows.Add(dr)
                    End If
                    dt_AppNo.DefaultView.RowFilter = ""
                End If
            Next
            '****************************************************

            If dt_AppNo.Rows.Count > 0 Then
                For i As Int32 = 0 To dt_AppNo.Rows.Count - 1
                    '********* Mapping Data *********
                    GetDataBorrow(dt_AppNo.Rows(i).Item("APP_NO").ToString.Trim, "RFID", dt)
                    '********************************

                Next
            End If
            '***** หารายการที่หาไม่มีในใบจอง และรายการมีปัญหาที่เหลือ *****
            Req_NOTFOUND()
            '************************************************
            gdvDataBorrow.DataSource = dt_Borrow
            gdvDataError.DataSource = dt_Error

            'GroupBox2.Text = "จำนวนรายการที่มีปัญหาทั้งหมด " & gdvDataError.Rows.Count + Count_Error & " รายการ"
            'GroupBox3.Text = "จำนวนรายการยืมทั้งหมด " & gdvDataBorrow.Rows.Count + Count_Borrow & " รายการ"

            'lblE_txtload.Visible = False
            lblE_txt1.Visible = True
            lblE_txt2.Visible = True
            lblE_count.Visible = True
            lblE_count.Text = gdvDataError.Rows.Count '+ Count_Error
            'lblB_txtload.Visible = False
            lblB_txt1.Visible = True
            lblB_txt2.Visible = True
            lblB_count.Visible = True
            lblB_count.Text = gdvDataBorrow.Rows.Count '+ Count_Borrow


         
            api.CloseCommPort()
            btnReadRFID.Enabled = True
            btnReadRFID.BackgroundImage = Image.FromFile("images/blog3_09.jpg")
            If ReadBarcodeFromTextFile.GetIsBox = 1 Then
                SetLightRedBorrow()
            End If


        Catch ex As Exception
            btnReadRFID.Enabled = True
            btnReadRFID.BackgroundImage = Image.FromFile("images/blog3_09.jpg")
        End Try
    End Sub
    Private Sub SetLightRedBorrow()
        If gdvDataBook.RowCount <> gdvDataBorrow.RowCount Then
            If blnBox1 = False Then
                LightRedReturn("ON")
            End If
            blnBox1 = True
        Else
            LightRedReturn("OFF")
            ' TimeAlertRed.Enabled = False
        End If
    End Sub

    Private Sub LightRedReturn(ByVal para As String)
        Try
            'If para.ToUpper = "ON" Then TowerLamp("GREEN2", "OFF") Else TowerLamp("GREEN2", "ON")
            If File.Exists(Application.StartupPath & "\Box1.txt") Then File.Delete(Application.StartupPath & "\Box1.txt")
            Dim sw As New StreamWriter(Application.StartupPath & "\Box1.txt", True)
            sw.Write("CH2:" & para)
            'If blnBox1 = False Then
            '    sw.Write("CH2:ON")
            '    blnBox1 = True
            'Else
            '    sw.Write("CH2:OFF")
            '    blnBox1 = False
            'End If

            sw.Dispose()
            Dim filebuffer As Byte()
            Dim clientSocket As New TcpClient("10.9.6.20", 1025)
            Dim networkStream As NetworkStream
            Dim fileStream As Stream
            fileStream = File.OpenRead(Application.StartupPath & "\Box1.txt")
            ' Alocate memory space for the file 
            ReDim filebuffer(fileStream.Length)
            fileStream.Read(filebuffer, 0, fileStream.Length)
            ' Open a TCP/IP Connection and send the data 

            networkStream = clientSocket.GetStream()
            networkStream.Write(filebuffer, 0, fileStream.Length)
            Try

                Dim strResut As Integer = 0
                strResut = networkStream.Read(filebuffer, 0, fileStream.Length)
                ' If strResut <> 0 Then MsgBox("light On!!") Else MsgBox("Cannot control")
                networkStream.Close()
                networkStream.Dispose()
                clientSocket.Close()
                fileStream.Close()
                fileStream.Dispose()
            Catch ex As Exception
                ' MsgBox("Cannot control")
                'TimeAlertRed.Enabled = False
            End Try
            'NetworkStream.Close()

        Catch ex As Exception
            TimeAlertRed.Enabled = False
        End Try
    End Sub

    Private Sub LightRedBorrow(ByVal para As String)
        Try
            'If para.ToUpper = "ON" Then TowerLamp("GREEN2", "OFF") Else TowerLamp("GREEN2", "ON")
            If File.Exists(Application.StartupPath & "\Box2.txt") Then File.Delete(Application.StartupPath & "\Box2.txt")
            Dim sw As New StreamWriter(Application.StartupPath & "\Box2.txt", True)
            sw.Write("CH5:" & para)
            'If blnBox1 = False Then
            '    sw.Write("CH5:ON")
            '    blnBox1 = True
            'Else
            '    sw.Write("CH5:OFF")
            '    blnBox1 = False
            'End If

            sw.Dispose()
            Dim filebuffer As Byte()
            Dim clientSocket As New TcpClient("10.9.6.20", 1025)
            Dim networkStream As NetworkStream
            Dim fileStream As Stream
            fileStream = File.OpenRead(Application.StartupPath & "\Box2.txt")
            ' Alocate memory space for the file 
            ReDim filebuffer(fileStream.Length)
            fileStream.Read(filebuffer, 0, fileStream.Length)
            ' Open a TCP/IP Connection and send the data 

            networkStream = clientSocket.GetStream()
            networkStream.Write(filebuffer, 0, fileStream.Length)
            Try

                Dim strResut As Integer = 0
                strResut = networkStream.Read(filebuffer, 0, fileStream.Length)
                'If strResut <> 0 Then MsgBox("light On!!") Else MsgBox("Cannot control")
                networkStream.Close()
                networkStream.Dispose()
                clientSocket.Close()
                fileStream.Close()
                fileStream.Dispose()
            Catch ex As Exception
                ' MsgBox("Cannot control")

            End Try
            'NetworkStream.Close()

        Catch ex As Exception

        End Try
    End Sub



    Private Sub btnMobileDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMobileDevice.Click
        Dim rapi As New RAPI
        If rapi.DevicePresent = False Then
            MsgBox("อุปกรณ์ต่อพ่วงไม่มีการเชื่อมต่อ")
            Exit Sub
        End If

        Dim frm As New frmMobile
        frm.SyncFor = frmMobile.TASK_TYPE.Import
        frm.ShowDialog()
    End Sub



    Private Sub PictureReserve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureReserve.Click

    End Sub

    Private Sub btnOpenDoor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenDoor.Click

       
        Try

            Dim sw As New StreamWriter(Application.StartupPath & "\Gate.txt", True)
            sw.Write("GATE1:ON")
            sw.Dispose()
            Dim filebuffer As Byte()
            Dim clientSocket As New TcpClient("10.9.6.20", 1025)
            Dim networkStream As NetworkStream
            Dim fileStream As Stream
            fileStream = File.OpenRead(Application.StartupPath & "\Gate.txt")
            ' Alocate memory space for the file 
            ReDim filebuffer(fileStream.Length)
            fileStream.Read(filebuffer, 0, fileStream.Length)
            ' Open a TCP/IP Connection and send the data 

            networkStream = clientSocket.GetStream()
            NetworkStream.Write(filebuffer, 0, fileStream.Length)
            Try

                Dim strResut As Integer = 0
                strResut = NetworkStream.Read(filebuffer, 0, fileStream.Length)
                If strResut <> 0 Then MsgBox("door is opened!!") Else MsgBox("Cannot open the door")
                networkStream.Close()
                networkStream.Dispose()
                clientSocket.Close()
                fileStream.Close()
                fileStream.Dispose()
            Catch ex As Exception
                MsgBox("Cannot open the door")

            End Try
            'NetworkStream.Close()

        Catch ex As Exception
            MsgBox("Cannot open the door")
        End Try
       
    End Sub


    'str = CH01,CH02    strStatus=ON,OFF
    Function TowerLamp(ByVal str As String, ByVal strStatus As String)
        Try

            Dim sw As New StreamWriter(Application.StartupPath & "\Alert.txt", True)
            sw.Write(str & ":" & strStatus)
            sw.Dispose()
            Dim filebuffer As Byte()
            Dim clientSocket As New TcpClient("10.9.6.20", 1025)
            Dim networkStream As NetworkStream
            Dim fileStream As Stream
            fileStream = File.OpenRead(Application.StartupPath & "\Alert.txt")
            ' Alocate memory space for the file 
            ReDim filebuffer(fileStream.Length)
            fileStream.Read(filebuffer, 0, fileStream.Length)
            ' Open a TCP/IP Connection and send the data 

            networkStream = clientSocket.GetStream()
            networkStream.Write(filebuffer, 0, fileStream.Length)
            Try

                Dim strResut As Integer = 0
                strResut = networkStream.Read(filebuffer, 0, fileStream.Length)
                If strResut <> 0 Then Return True Else Return False
                networkStream.Close()
                networkStream.Dispose()
                clientSocket.Close()
                fileStream.Close()
                fileStream.Dispose()
            Catch ex As Exception
                Return False

            End Try
            'NetworkStream.Close()

        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub TimeAlertRed_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimeAlertRed.Tick
        'If gdvDataBook.RowCount <> gdvDataBorrow.RowCount Then
        '    TowerLamp("CH01", "ON")
        'Else
        '    TowerLamp("CH01", "OFF")
        '    TimeAlertRed.Enabled = False
        'End If
        If ReadBarcodeFromTextFile.GetIsBox = 1 Then
            SetLightRedBorrow()
        End If
    End Sub

  
End Class
