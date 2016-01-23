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

Public Class frmReturns

    Dim sql As String = ""
    Dim dt_Return As New DataTable 'รายการคืนที่อ่านจาก RFID หรือ Barcode ทั้งหมด
    Dim dt_Error As New DataTable 'รายการที่ไม่ผ่านการยืม
    Dim dt_Reserve As New DataTable 'รายการคืนที่มีการจองต่อ
    Dim dt_Borrow As New DataTable 'รายการยืมทั้งหมด เริ่มหาตอน Event Form_Show
    'Dim Count_Return As Int32 'จำนวนของแฟ้มต่อ ที่อยู่ในรายการคืน 

    'ส่วนอ่านค่าจาก RFID
    Dim dt_RFID As DataTable
    Dim rea As RFIDReader
    Dim api As New RfidApi
    Public TagCnt As Integer = 0
    Dim ReadMinute As Integer = Func.GetSetupValue("RFID_Read_Minute", Nothing)
    Dim ReadTime As Double
    Dim _err As String = ""


    '1. อ่านค่าจาก RFID หรือ Barcode
    '2. gdvReturns แสดงรายการทั้งหมดที่อ่านได้ โดยแบ่งสีตาม ประเภทของการอ่าน
    '3. gdvError แสดงเฉพาะรายการที่ไม่ได้ถูกยืม
    '4. gdvBook แสดงรายการที่มีการจองต่อไป


    Function ReadDB() As DataTable

        'Dim ini As New IniReader(INIFlieName)
        'ini.Section = "SETTING"
        'Dim ReaderId As String
        'If Dir(INIFlieName) <> "" Then
        '    ReaderId = ini.ReadString("ReaderId")
        'End If


        Dim dt As New DataTable
        Try
            Dim trans As New SqlTransactionDB
            Dim sql As String
            sql = "select tag_id as app_no from TMP_GATE_READER_TAG where read_type='2' and reader_id=" & Func.GetReaderId & " order by app_no"

            Dim dal As New TbRequisitionDAL
            dt = dal.GetListBySql(sql, "", trans.Trans)

        Catch ex As Exception
        End Try

        Return dt
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim rea As New RFIDReader
            '** กรองหมายเลขแฟ้มที่ได้มาจาก RFID ให้เหลือ 10 หลัก และเช็คด้วยว่าถ่าแฟ้มต่อไม่ครบ ก็ไม่ต้องเอาข้อมูลมา  **
            'Count_Return = 0 'เคลียร์จำนวนของแฟ้มต่อ ที่อยู่ในรายการคืน
            Dim dt_AppNo As New DataTable
            dt_AppNo = ReadDB() 'โยนค่า RFID Datatable เข้าไป
            '*******************************************************************************
            If dt_AppNo.Rows.Count > 0 Then
                GetDataReturn(dt_AppNo)
                gdvReturns.DataSource = dt_Return
                gdvError.DataSource = dt_Error
                gdvBook.DataSource = dt_Reserve
                If dt_Return.Rows.Count > 0 Then
                    btnConfirm.Enabled = True
                    btnConfirm.BackgroundImage = Image.FromFile("images/blog4_033.jpg")
                Else
                    btnConfirm.Enabled = False
                    btnConfirm.BackgroundImage = Image.FromFile("images/Dis_blog4_033.jpg")

                    btnPrint.Enabled = False
                    btnPrint.BackgroundImage = Image.FromFile("images/Dis_blog4_066.jpg")
                End If
                'GroupBox1.Text = "จำนวนรายการคืนทั้งหมด " & dt_Return.Rows.Count + Count_Return & " รายการ"
                'GroupBox2.Text = "จำนวนรายการที่ไม่ผ่านการยืมทั้งหมด " & dt_Error.Rows.Count & " รายการ"
                'GroupBox3.Text = "จำนวนรายการที่มีการจองทั้งหมด " & dt_Reserve.Rows.Count & " รายการ"

                lblR_txtload.Visible = False
                lblR_txt1.Visible = True
                lblR_txt2.Visible = True
                lblR_count.Visible = True
                lblR_count.Text = dt_Return.Rows.Count '+ Count_Return
                lblE_txtload.Visible = False
                lblE_txt1.Visible = True
                lblE_txt2.Visible = True
                lblE_count.Visible = True
                lblE_count.Text = dt_Error.Rows.Count '+ Count_Return
                lblB_txtload.Visible = False
                lblB_txt1.Visible = True
                lblB_txt2.Visible = True
                lblB_count.Visible = True
                lblB_count.Text = dt_Reserve.Rows.Count '+ Count_Return
            End If

            ReadTime += Timer1.Interval
            If ReadTime / 1000 >= ReadMinute Then
                api.CloseCommPort()
                Timer1.Enabled = False
                btnReadRFID.Enabled = True
                btnReadRFID.BackgroundImage = Image.FromFile("images/blog4_11.jpg")
            End If
        Catch ex As Exception
            btnReadRFID.Enabled = True
            btnReadRFID.BackgroundImage = Image.FromFile("images/blog4_11.jpg")
        End Try

    End Sub

    Private Sub ReadReturn()
        Try
            Dim rea As New RFIDReader
            '** กรองหมายเลขแฟ้มที่ได้มาจาก RFID ให้เหลือ 10 หลัก และเช็คด้วยว่าถ่าแฟ้มต่อไม่ครบ ก็ไม่ต้องเอาข้อมูลมา  **
            'Count_Return = 0 'เคลียร์จำนวนของแฟ้มต่อ ที่อยู่ในรายการคืน
            Dim dt_AppNo As New DataTable
            dt_AppNo = ReadDB() 'โยนค่า RFID Datatable เข้าไป
            '*******************************************************************************
            If dt_AppNo.Rows.Count > 0 Then
                GetDataReturn(dt_AppNo)
                gdvReturns.DataSource = dt_Return
                gdvError.DataSource = dt_Error
                gdvBook.DataSource = dt_Reserve
                If dt_Return.Rows.Count > 0 Then
                    btnConfirm.Enabled = True
                    btnConfirm.BackgroundImage = Image.FromFile("images/blog4_033.jpg")
                Else
                    btnConfirm.Enabled = False
                    btnConfirm.BackgroundImage = Image.FromFile("images/Dis_blog4_033.jpg")

                    btnPrint.Enabled = False
                    btnPrint.BackgroundImage = Image.FromFile("images/Dis_blog4_066.jpg")
                End If
                'GroupBox1.Text = "จำนวนรายการคืนทั้งหมด " & dt_Return.Rows.Count + Count_Return & " รายการ"
                'GroupBox2.Text = "จำนวนรายการที่ไม่ผ่านการยืมทั้งหมด " & dt_Error.Rows.Count & " รายการ"
                'GroupBox3.Text = "จำนวนรายการที่มีการจองทั้งหมด " & dt_Reserve.Rows.Count & " รายการ"

                lblR_txtload.Visible = False
                lblR_txt1.Visible = True
                lblR_txt2.Visible = True
                lblR_count.Visible = True
                lblR_count.Text = dt_Return.Rows.Count '+ Count_Return
                lblE_txtload.Visible = False
                lblE_txt1.Visible = True
                lblE_txt2.Visible = True
                lblE_count.Visible = True
                lblE_count.Text = dt_Error.Rows.Count '+ Count_Return
                lblB_txtload.Visible = False
                lblB_txt1.Visible = True
                lblB_txt2.Visible = True
                lblB_count.Visible = True
                lblB_count.Text = dt_Reserve.Rows.Count '+ Count_Return
            End If

            api.CloseCommPort()
            btnReadRFID.Enabled = True
            btnReadRFID.BackgroundImage = Image.FromFile("images/blog4_11.jpg")

        Catch ex As Exception
            btnReadRFID.Enabled = True
            btnReadRFID.BackgroundImage = Image.FromFile("images/blog4_11.jpg")
        End Try
    End Sub

    Private Sub btnReadRFID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadRFID.Click
        'btnReadRFID.BackgroundImage = Image.FromFile("images/blog4_11.jpg")
        Try
            btnReadRFID.Enabled = False
            btnReadRFID.BackgroundImage = Image.FromFile("images/Dis_blog3_09.jpg")

            If ReadBarcodeFromTextFile.GetModuleRead = 1 Then
                ReadWriteModule()
                InsertDataModule()
            End If

            ' Timer1.Enabled = False
            Dim ini As New IniReader(INIFlieName)
            ini.Section = "SETTING"

            'Read RFID
            api.OpenCommPort(Trim("COM" + ini.ReadString("CR_ComPort")))
            api.ClearIdBuf()
            TagCnt = 0
            ReadTime = 0
            dt_RFID = New DataTable
            dt_RFID.Columns.Add("APP_NO")
            dt_RFID.Columns.Add("APP_NO10")
            'สั่งให้ Timer ทำงาน
            ' Timer1.Enabled = True
            ReadReturn()
        Catch ex As Exception
            btnReadRFID.Enabled = True
            btnReadRFID.BackgroundImage = Image.FromFile("images/blog4_11.jpg")
        End Try



        ''ส่วน Test
        ''********* จำลองข้อมูลจาก RFID ไว้ใน Datatable *********
        'Dim dt As New DataTable
        'dt = TestRFID()
        ''*************************************************

        ''** กรองหมายเลขแฟ้มที่ได้มาจาก RFID ให้เหลือ 10 หลัก และเช็คด้วยว่าถ่าแฟ้มต่อไม่ครบ ก็ไม่ต้องเอาข้อมูลมา  **
        'Count_Return = 0 'เคลียร์จำนวนของแฟ้มต่อ ที่อยู่ในรายการคืน
        'Dim dt_AppNo As New DataTable
        'dt_AppNo = Get_AppNo(dt)
        ''*******************************************************************************

        'GetDataReturn(dt_AppNo)
        'gdvReturns.DataSource = dt_Return
        'gdvError.DataSource = dt_Error
        'gdvBook.DataSource = dt_Reserve
        'If dt_Return.Rows.Count > 0 Then
        '    btnConfirm.Enabled = True
        'Else
        '    btnConfirm.Enabled = False
        '    btnPrint.Enabled = False
        'End If
        'GroupBox1.Text = "จำนวนรายการคืนทั้งหมด " & dt_Return.Rows.Count + Count_Return & " รายการ"
        'GroupBox2.Text = "จำนวนรายการที่ไม่ผ่านการยืมทั้งหมด " & dt_Error.Rows.Count & " รายการ"
        'GroupBox3.Text = "จำนวนรายการที่มีการจองทั้งหมด " & dt_Reserve.Rows.Count & " รายการ"
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
        Dim IsInsert As Boolean = ReadTextFile.ReadTextFileModuleAndInsertToTemp(2)
        If IsInsert = False Then
            '-------------- Display Error -------------
            MsgBox("ไม่สามารถอ่านไฟล์รายงานผลได้")
            Exit Sub
        End If
    End Sub

    Function Get_AppNo(ByVal dt_RFID_Read As DataTable) As DataTable
        Dim dt_AppNo As New DataTable
        Dim dt_AppNo_Commit As New DataTable

        If dt_RFID_Read.Rows.Count > 0 Then
            dt_AppNo.Columns.Add("APP_NO", GetType(System.String))
            dt_AppNo_Commit.Columns.Add("APP_NO", GetType(System.String))

            Dim dr As DataRow
            Dim AppNo As String = ""
            ' Loop เพื่อกรองหมายเลขแฟ้มที่ได้มาจาก RFID ให้เหลือ 10 หลัก และไม่ซ้ำกัน
            For i As Int32 = 0 To dt_RFID_Read.Rows.Count - 1
                If dt_RFID_Read.Rows(i).Item("APP_NO").ToString.Length > 9 Then
                    AppNo = dt_RFID_Read.Rows(i).Item("APP_NO").ToString.Substring(0, 10)
                    dt_AppNo.DefaultView.RowFilter = "APP_NO = '" & AppNo & "'"
                    If dt_AppNo.DefaultView.Count = 0 Then
                        dr = dt_AppNo.NewRow
                        dr("APP_NO") = AppNo
                        dt_AppNo.Rows.Add(dr)
                    End If
                    dt_AppNo.DefaultView.RowFilter = ""
                End If
            Next
            '*********************************************************

            If dt_AppNo.Rows.Count > 0 Then
                Dim dal As New TbRequisitionDAL
                Dim data As New TbRequisitionData
                For i As Int32 = 0 To dt_AppNo.Rows.Count - 1
                    'เช็คว่าเป็นรายการที่มีแฟ้มต่อหรือไม่ ถ้ามีแฟ้มต่อ ก็ตรวจสอบดูว่าแฟ้มต่อครบตามจำนวนหรือไม่
                    AppNo = dt_AppNo.Rows(i).Item("APP_NO").ToString.Trim

                    If dal.ChkDataByWhere("APP_NO = '" & AppNo & "' and qty > 1", Nothing) = True Then
                        'มีแฟ้มต่อ
                        Dim qty As Int32 = 0
                        data = dal.GetDataByAPP_NO(AppNo, Nothing)
                        qty = data.QTY
                        dt_RFID_Read.DefaultView.RowFilter = "APP_NO LIKE '" & AppNo & "%'"
                        If dt_RFID_Read.DefaultView.Count >= qty Then
                            dr = dt_AppNo_Commit.NewRow
                            dr("APP_NO") = AppNo
                            dt_AppNo_Commit.Rows.Add(dr)
                        End If
                        'Count_Return = Count_Return + qty - 1
                        dt_RFID_Read.DefaultView.RowFilter = ""
                    ElseIf dal.ChkDataByWhere("APP_NO = '" & AppNo & "'", Nothing) = True Then
                        'ไม่มีแฟ้มต่อ แต่เป็นแฟ้มที่มีอยู่จริงใน database
                        dr = dt_AppNo_Commit.NewRow
                        dr("APP_NO") = AppNo
                        dt_AppNo_Commit.Rows.Add(dr)
                    End If
                Next
            End If
        End If

        Return dt_AppNo_Commit
    End Function

    Function TestRFID() As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim requidition_id(11) As String
        requidition_id(0) = "000100000101"
        requidition_id(1) = "000100000401"
        requidition_id(2) = "000100000501"
        requidition_id(3) = "000100000301"
        requidition_id(4) = "000100000601"
        requidition_id(5) = "000100000303"
        requidition_id(6) = "000100003001"
        requidition_id(7) = "000100000801"
        requidition_id(8) = "000100000901"
        requidition_id(9) = "000100001001"
        requidition_id(10) = "000100000201"
        requidition_id(11) = "000100000302"

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

    Sub GetDataReturn(ByVal dt_RFID As DataTable)
        'dt_RFID เป็นรายการที่อ่านจากได้จาก RFID
        'dt_Borrow เป็นรายการยืมทั้งหมด
        Dim Fc_dt_Return As New DataTable
        Dim Fc_dt_Error As New DataTable
        Dim Fc_dt_Reserve As New DataTable

        '************************* รายการคืนทั้งหมด ***************************
        Dim dt_CheckReturn As New DataTable
        'หมายเหตุ ใน Function Join ชื่อฟิลด์ในการ Join ต้องเหมือนกัน
        Fc_dt_Return = LeftJoin(dt_RFID, dt_Borrow, "APP_NO", "APP_NO")
        Get_dt_Return(Fc_dt_Return, "RFID")
        '*****************************************************************

        '*********************** รายการที่ไม่ผ่านการยืม *************************
        dt_Return.DefaultView.RowFilter = "isnull(borrow_date,'') = ''"
        Fc_dt_Error = dt_Return.DefaultView.ToTable
        Get_dt_Error(Fc_dt_Error, "RFID")
        '*****************************************************************

        '*********************** รายการคืนที่มีการจองต่อ ************************
        dt_Return.DefaultView.RowFilter = "Reserve = True"
        Fc_dt_Reserve = dt_Return.DefaultView.ToTable
        Get_dt_Reserve(Fc_dt_Reserve, "RFID")
        '*****************************************************************

        dt_Return.DefaultView.RowFilter = ""
        dt_Error.DefaultView.RowFilter = ""
        dt_Reserve.DefaultView.RowFilter = ""
        dt_Borrow.DefaultView.RowFilter = ""
    End Sub

    Sub GetDataReturn(ByVal txetBarcode As String)
        'dt_Requisition เป็นรายการแฟ้มทั้งหมด
        Dim Fc_dt_Return As New DataTable
        Dim Fc_dt_Error As New DataTable
        Dim Fc_dt_Reserve As New DataTable

        'เช็คว่ารายการซ้ำกับที่มีอยู่หรือไม่
        dt_Return.DefaultView.RowFilter = "APP_NO = '" & txetBarcode.Trim & "'"
        If dt_Return.DefaultView.Count = 0 Then
            'เช็คว่าเป็นรายการยืมหรือไม่
            dt_Borrow.DefaultView.RowFilter = "APP_NO = '" & txetBarcode.Trim & "'"
            If dt_Borrow.DefaultView.Count > 0 Then
                'รายการคืน
                Fc_dt_Return = dt_Borrow.DefaultView.ToTable
                Get_dt_Return(Fc_dt_Return, "BARCODE")
                'รายการคืนที่มีการจองต่อ
                dt_Return.DefaultView.RowFilter = "Reserve = True"
                Fc_dt_Reserve = dt_Return.DefaultView.ToTable
                Get_dt_Reserve(Fc_dt_Reserve, "BARCODE")
            Else
                'รายการคืน
                Dim dr As DataRow
                dr = dt_Return.NewRow
                dr("No") = dt_Return.Rows.Count + 1
                dr("APP_NO") = txetBarcode.Trim
                dr("member_name") = ""
                dr("borrow_date") = ""
                dr("ReadBy") = "BARCODE"
                dr("Reserve") = False
                dt_Return.Rows.Add(dr)

                'รายการที่ไม่ผ่านการยืม
                dr = dt_Error.NewRow
                dr("No") = dt_Error.Rows.Count + 1
                dr("APP_NO") = txetBarcode.Trim
                dr("member_name") = ""
                dr("borrow_date") = ""
                dr("ReadBy") = "BARCODE"
                dr("Reserve") = False
                dt_Error.Rows.Add(dr)
            End If
        End If

        dt_Return.DefaultView.RowFilter = ""
        dt_Error.DefaultView.RowFilter = ""
        dt_Reserve.DefaultView.RowFilter = ""
        dt_Borrow.DefaultView.RowFilter = ""
    End Sub

    Sub Get_dt_Return(ByVal FC_dt_Return As DataTable, ByVal ReadBy As String)
        If FC_dt_Return.Rows.Count > 0 Then
            Dim dr As DataRow
            For i As Int32 = 0 To FC_dt_Return.Rows.Count - 1
                dt_Return.DefaultView.RowFilter = "APP_NO = '" & FC_dt_Return.Rows(i).Item("APP_NO").ToString & "'"
                If dt_Return.DefaultView.Count = 0 Then
                    Dim chk As Boolean = True
                    dr = dt_Return.NewRow
                    dr("No") = dt_Return.Rows.Count + 1
                    dr("APP_NO") = FC_dt_Return.Rows(i).Item("APP_NO").ToString
                    dr("member_name") = FC_dt_Return.Rows(i).Item("member_name").ToString
                    dr("borrow_date") = FC_dt_Return.Rows(i).Item("borrow_date").ToString
                    dr("ReadBy") = ReadBy
                    If FC_dt_Return.Rows(i).Item("Reserve").ToString = "" Then
                        chk = False
                    End If
                    dr("Reserve") = chk
                    If IsDBNull(FC_dt_Return.Rows(i).Item("ItemID")) Then
                        dr("ItemID") = ""
                    Else
                        dr("ItemID") = FC_dt_Return.Rows(i).Item("ItemID").ToString
                    End If
                    dr("member_id") = FC_dt_Return.Rows(i).Item("member_id").ToString
                    dr("Printdate") = FC_dt_Return.Rows(i).Item("Printdate").ToString
                    dr("staff") = FC_dt_Return.Rows(i).Item("staff").ToString
                    dr("REF_INNOVA_ID") = FC_dt_Return.Rows(i).Item("REF_INNOVA_ID").ToString
                    dt_Return.Rows.Add(dr)
                End If
            Next
        End If
    End Sub

    Sub Get_dt_Error(ByVal FC_dt_Error As DataTable, ByVal ReadBy As String)
        If FC_dt_Error.Rows.Count > 0 Then
            Dim dr As DataRow
            For i As Int32 = 0 To FC_dt_Error.Rows.Count - 1
                dt_Error.DefaultView.RowFilter = "APP_NO = '" & FC_dt_Error.Rows(i).Item("APP_NO").ToString & "'"
                If dt_Error.DefaultView.Count = 0 Then
                    Dim chk As Boolean = True
                    dr = dt_Error.NewRow
                    dr("No") = dt_Error.Rows.Count + 1
                    dr("APP_NO") = FC_dt_Error.Rows(i).Item("APP_NO").ToString
                    dr("member_name") = FC_dt_Error.Rows(i).Item("member_name").ToString
                    dr("borrow_date") = FC_dt_Error.Rows(i).Item("borrow_date").ToString
                    dr("ReadBy") = ReadBy
                    If FC_dt_Error.Rows(i).Item("Reserve").ToString = "False" Then
                        chk = False
                    End If
                    dr("Reserve") = chk
                    dt_Error.Rows.Add(dr)
                End If
            Next
        End If
    End Sub

    Sub Get_dt_Reserve(ByVal FC_dt_Reserve As DataTable, ByVal ReadBy As String)
        If FC_dt_Reserve.Rows.Count > 0 Then
            Dim dr As DataRow
            For i As Int32 = 0 To FC_dt_Reserve.Rows.Count - 1
                dt_Reserve.DefaultView.RowFilter = "APP_NO = '" & FC_dt_Reserve.Rows(i).Item("APP_NO").ToString & "'"
                If dt_Reserve.DefaultView.Count = 0 Then
                    Dim chk As Boolean = True
                    dr = dt_Reserve.NewRow
                    dr("No") = dt_Reserve.Rows.Count + 1
                    dr("APP_NO") = FC_dt_Reserve.Rows(i).Item("APP_NO").ToString
                    dr("member_name") = FC_dt_Reserve.Rows(i).Item("member_name").ToString
                    dr("borrow_date") = FC_dt_Reserve.Rows(i).Item("borrow_date").ToString
                    dr("ReadBy") = ReadBy
                    dr("Reserve") = chk
                    dt_Reserve.Rows.Add(dr)
                End If
            Next
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'ลบ Temp
        SqlDB.ExecuteNonQuery("DELETE FROM TMP_GATE_READER_TAG WHERE Reader_id=" & ReadBarcodeFromTextFile.GetReaderId)

        api.CloseCommPort()
        Timer1.Enabled = False
        Clear()
    End Sub

    Sub Clear()
        'Clear Page
        'Count_Return = 0 'เคลียร์จำนวนของแฟ้มต่อ ที่อยู่ในรายการคืน
        txtBarcode.Text = ""
        dt_Reserve.Rows.Clear()
        dt_Error.Rows.Clear()
        dt_Return.Rows.Clear()
        'dt_RFID.Rows.Clear()
        'GroupBox1.Text = "รายการจอง"
        'GroupBox2.Text = "รายการที่มีปัญหา"
        'GroupBox3.Text = "รายการยืม"
        lblR_txtload.Visible = True
        lblR_txt1.Visible = False
        lblR_txt2.Visible = False
        lblR_count.Visible = False
        lblE_txtload.Visible = True
        lblE_txt1.Visible = False
        lblE_txt2.Visible = False
        lblE_count.Visible = False
        lblB_txtload.Visible = True
        lblB_txt1.Visible = False
        lblB_txt2.Visible = False
        lblB_count.Visible = False
        btnConfirm.Enabled = False
        btnConfirm.BackgroundImage = Image.FromFile("images/Dis_blog4_033.jpg")
        btnPrint.Enabled = False
        btnPrint.BackgroundImage = Image.FromFile("images/Dis_blog4_066.jpg")
        btnReadRFID.Enabled = True
        btnReadRFID.BackgroundImage = Image.FromFile("images/blog4_11.jpg")
        txtBarcode.Enabled = True
    End Sub

    Function CheckReturn(ByVal messagebox As Boolean) As Boolean
        If gdvReturns.Rows.Count > 0 Then
            For i As Int32 = 0 To gdvReturns.Rows.Count - 1
                If gdvReturns.Rows(i).Cells("borrow_date").Value.ToString <> "" Then
                    Return True
                End If
            Next
        End If
        If messagebox = True Then
            MsgBox("ไม่มีรายการที่สามารถทำรายการคืนได้")
        End If
        Return False
    End Function

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        FinddataBorrow()
        Dim strApp_no As String = ""
        Dim ret As Boolean = True
        Dim trans As New SqlTransactionDB
        trans.CreateTransaction()
        Dim dalItem As New TbFileBorrowItemDAL
        '********************
        If CheckReturn(True) = True Then
            'Insert TbFileBorrowItem
            For i As Integer = 0 To gdvReturns.RowCount - 1

                If strApp_no = "" Then
                    strApp_no = "'" & gdvReturns.Rows(i).Cells("APP_NO").Value.ToString & "'"
                Else
                    strApp_no &= ",'" & gdvReturns.Rows(i).Cells("APP_NO").Value.ToString & "'"
                End If


                If gdvReturns.Rows(i).Cells("ItemID").Value.ToString = "0" Then
                    '***************************** Insert Log ********************************

                    Dim id As String = GetRef_Innova_Id()
                    Dim id_app As String = ""
                    Dim dt As New DataTable
                    Dim sql As String = "select id from TB_REQUISTION where app_no = '" & gdvReturns.Rows(i).Cells("APP_NO").Value.ToString & "'"
                    dt = SqlDB.ExecuteTable(sql)
                    If dt.Rows.Count > 0 Then
                        id_app = dt.Rows(0).Item("id").ToString
                    End If

                    sql = "insert into TB_LOG_UPDATE_TO_INNOVA(ID,REF_INNOVA_ID,APP_NO,R_BORROWSTATUS,R_RETURNDATE,R_OFFICERRETURN,R_ENDSTATUS,CREATEBY,CREATEON) values('" & id & "','" & gdvReturns.Rows(i).Cells("REF_INNOVA_ID").Value.ToString & "','" & id_app & "','R',GETDATE(),'" & frmMain.txtIdUser.Text & "','R','" & frmMain.txtIdUser.Text & "',GETDATE())"
                    SqlDB.ExecuteTable(sql)

                    sql = "exec UPDATERETURN '" & gdvReturns.Rows(i).Cells("REF_INNOVA_ID").Value.ToString & "','" & frmMain.txtIdUser.Text & "'"
                    SqlDB.ExecuteTable(sql)


                ElseIf gdvReturns.Rows(i).Cells("ItemID").Value.ToString <> "" Then
                    dalItem.GetDataByid(gdvReturns.Rows(i).Cells("ItemID").Value.ToString, trans.Trans)
                    dalItem.RETURNDATE = DateAndTime.Now
                    dalItem.OFFICER_RETURN = frmMain.txtUserName.Text
                    If gdvReturns.Rows(i).Cells("ReadBy").Value = "RFID" Then
                        dalItem.RETURN_SCAN_BY = "R"
                    Else
                        dalItem.RETURN_SCAN_BY = "B"
                    End If

                    Dim rDal As New TbReserveDAL
                    rDal.GetDataByid(dalItem.RESERVE_ID, Nothing)
                    If Func.UpdateStatusToInnova("R", CStr(rDal.REF_INNOVA_ID), frmMain.txtIdUser.Text, CStr(dalItem.REQUISITION_ID)) = True Then
                        dalItem.ISUPDATE_INNOVA_RETURN = "Y"
                        '***************************** Insert Log ********************************
                        'sql = "Update TB_LOG_UPDATE_TO_INNOVA set R_BORROWSTATUS = 'R',R_RETURNDATE = GETDATE(),R_OFFICERRETURN = '" & frmMain.txtIdUser.Text & "',R_ENDSTATUS = 'R' WHERE REF_INNOVA_ID = '" & rDal.REF_INNOVA_ID & "'"
                        Dim id As String = GetRef_Innova_Id()
                        sql = "insert into TB_LOG_UPDATE_TO_INNOVA(ID,REF_INNOVA_ID,APP_NO,R_BORROWSTATUS,R_RETURNDATE,R_OFFICERRETURN,R_ENDSTATUS,CREATEBY,CREATEON) values('" & id & "','" & rDal.REF_INNOVA_ID & "','" & dalItem.REQUISITION_ID & "','R',GETDATE(),'" & frmMain.txtIdUser.Text & "','R','" & frmMain.txtIdUser.Text & "',GETDATE())"
                        SqlDB.ExecuteTable(sql)
                        '******************** Update Status แฟ้ม ที่ TB_Reserve **********************
                        sql = "Update TB_RESERVE set reserve_status = 'Y' where requidition_id = '" & dalItem.REQUISITION_ID & "' and borrowstatus = 'R' and reserve_status = 'N'"
                        SqlDB.ExecuteTable(sql)
                        '*************************************************************************
                        '************************* Update Reserve Order **************************
                        Dim dt As New DataTable
                        sql = "select id,requidition_id,ROW_NUMBER() OVER(PARTITION BY requidition_id ORDER BY reserve_date ASC) AS reserve_order from TB_RESERVE where borrowstatus = 'S' and requidition_id = '" & dalItem.REQUISITION_ID & "' and id NOT IN (SELECT ISNULL(reserve_id, 0) AS Expr1 FROM TB_FILEBORROWITEM where requidition_id = '" & dalItem.REQUISITION_ID & "')"
                        dt = SqlDB.ExecuteTable(sql)
                        If dt.Rows.Count > 0 Then
                            For j As Int32 = 0 To dt.Rows.Count - 1
                                sql = "update TB_RESERVE set reserve_order = '" & dt.Rows(j).Item("reserve_order").ToString & "' where id = '" & dt.Rows(j).Item("id").ToString & "'"
                                SqlDB.ExecuteTable(sql)
                            Next
                        End If
                        '*************************************************************************
                    Else
                        dalItem.ISUPDATE_INNOVA_RETURN = "N"
                    End If

                    ret = dalItem.UpdateByid(frmMain.txtUserName.Text, Nothing)
                    If ret = True Then
                        Dim tmpDal As New TmpFileborrowItemDAL
                        tmpDal.GetDataByFILEBORROWITEM_ID(dalItem.ID, Nothing)
                        Dim retDelete As Boolean = tmpDal.DeleteByFILEBORROWITEM_ID(dalItem.ID, Nothing)
                        If retDelete = False Then
                            '_err = tmpDal.ErrorMessage
                            'Exit For
                        End If
                    Else
                        _err = dalItem.ErrorMessage
                        Exit For
                    End If
                End If

            Next

            'ยืนยันเสร็จให้ลบ Temp
            SqlDB.ExecuteNonQuery("DELETE FROM TMP_GATE_READER_TAG WHERE Reader_id=" & ReadBarcodeFromTextFile.GetReaderId)

            'Update location
            ret = UpdateLocationByRetrun(strApp_no)

            If ret = True Then
                trans.CommitTransaction()
                MsgBox("บันทึกข้อมูลเรียบร้อย")
                btnPrint.Enabled = True
                btnPrint.BackgroundImage = Image.FromFile("images/blog4_066.jpg")
                btnConfirm.Enabled = False
                btnConfirm.BackgroundImage = Image.FromFile("images/Dis_blog4_033.jpg")
                btnReadRFID.Enabled = False
                btnReadRFID.BackgroundImage = Image.FromFile("images/Dis_blog3_09.jpg")
                txtBarcode.Enabled = False
                FinddataBorrow()
                Timer1.Enabled = False
            Else
                trans.RollbackTransaction()
                MsgBox(_err)
            End If

        End If

        'TB_FILEBORROWITEM officer_return, returndate, return_scan_by, tag_code, isUpdate_innova_return
    End Sub

    Private Function UpdateLocationByRetrun(ByVal strApp_no As String) As Boolean
        Try
            Dim ReaderID As String = ReadBarcodeFromTextFile.GetReaderId

            Dim strSQlUpdate As String
            strSQlUpdate = "update ts_file_current_location"
            strSQlUpdate &= " set  ts_file_current_location.ms_room_id =  (select top 1 fl.ms_room_id from tb_filelocation fl where fl.readerid='" & ReaderID & "')"
            strSQlUpdate &= " ,ts_file_current_location.location_name =  (select top 1 fl.location_name from tb_filelocation fl where fl.readerid='" & ReaderID & "')"
            strSQlUpdate &= " ,ts_file_current_location.ms_desktop_id = 0"
            strSQlUpdate &= " ,ts_file_current_location.desk_name = null"
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

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        '******** Get datatable เพื่อเอาไปแสดงใน Report **********
        '************ โดยเลือกเอา เฉพาะที่มีรายการยืม *****************
        Dim dt_report As New DataTable
        Dim dt_finddata As New DataTable
        Dim dr As DataRow
        With dt_report
            .Columns.Add("requisition_id", GetType(System.String))
            .Columns.Add("member_name", GetType(System.String))
            .Columns.Add("borrow_date", GetType(System.String))
            .Columns.Add("member_id", GetType(System.String))
            .Columns.Add("Printdate", GetType(System.String))
            .Columns.Add("staff", GetType(System.String))
            .Columns.Add("filecount", GetType(System.String))
        End With
        dt_Return.DefaultView.RowFilter = "isnull(borrow_date,'') <> ''"
        dt_finddata = dt_Return.DefaultView.ToTable
        For i As Int32 = 0 To dt_finddata.Rows.Count - 1
            dr = dt_report.NewRow
            dr("requisition_id") = dt_finddata.Rows(i).Item("APP_NO").ToString
            dr("member_name") = dt_finddata.Rows(i).Item("member_name").ToString
            dr("borrow_date") = dt_finddata.Rows(i).Item("borrow_date").ToString
            dr("member_id") = dt_finddata.Rows(i).Item("member_id").ToString
            dr("Printdate") = dt_finddata.Rows(i).Item("Printdate").ToString
            dr("staff") = dt_finddata.Rows(i).Item("staff").ToString
            dr("filecount") = dt_finddata.Rows.Count
            dt_report.Rows.Add(dr)
        Next
        dt_Return.DefaultView.RowFilter = ""
        '******************************************************

        dt_report.DefaultView.Sort = "requisition_id"
        btnPrint.Cursor = Cursors.AppStarting
        btnPrint.Enabled = False
        btnPrint.BackgroundImage = Image.FromFile("images/Dis_blog4_066.jpg")
        Dim trans As New SqlTransactionDB
        trans.CreateTransaction()
        'If SaveBorrow(False) = True Then

        Dim logonInfo As New TableLogOnInfo
        logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
        logonInfo.ConnectionInfo.UserID = SqlDB.UserID
        logonInfo.ConnectionInfo.Password = SqlDB.Password

        Dim rep As New rptReturn
        rep.SetDataSource(dt_report.DefaultView.ToTable)
        rep.Database.Tables(0).ApplyLogOnInfo(logonInfo)

        'rep.DataDefinition.FormulaFields("staff").Text = frm_ReportBorrow.TextBox1.Text

        Dim cryViewer As New frmReportPreview
        cryViewer.CrystalReportViewer1.ReportSource = rep
        cryViewer.CrystalReportViewer1.Refresh()
        cryViewer.WindowState = FormWindowState.Maximized
        cryViewer.Show()

        Clear()

    End Sub

    Private Sub frmReturns_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.ControlBox = False
    End Sub

    Function LeftJoin(ByVal First As DataTable, ByVal Second As DataTable, ByVal FJC As DataColumn(), ByVal SJC As DataColumn()) As DataTable
        Dim table As New DataTable("Join")
        Using ds As DataSet = New DataSet
            ds.Tables.AddRange(New DataTable() {First.Copy, Second.Copy})
            Dim parentcolumns As DataColumn() = New DataColumn(FJC.Length - 1) {}
            Dim i As Integer
            For i = 0 To parentcolumns.Length - 1
                parentcolumns(i) = ds.Tables.Item(0).Columns.Item(FJC(i).ColumnName)
            Next i
            Dim childcolumns As DataColumn() = New DataColumn(SJC.Length - 1) {}
            'Dim i As Integer
            For i = 0 To childcolumns.Length - 1
                childcolumns(i) = ds.Tables.Item(1).Columns.Item(SJC(i).ColumnName)
            Next i
            Dim r As New DataRelation(String.Empty, parentcolumns, childcolumns, False)
            ds.Relations.Add(r)
            'Dim i As Integer
            For i = 0 To First.Columns.Count - 1
                table.Columns.Add(First.Columns.Item(i).ColumnName, First.Columns.Item(i).DataType)
            Next i
            'Dim i As Integer
            For i = 0 To Second.Columns.Count - 1
                If Not table.Columns.Contains(Second.Columns.Item(i).ColumnName) Then
                    table.Columns.Add(Second.Columns.Item(i).ColumnName, Second.Columns.Item(i).DataType)
                Else
                    table.Columns.Add((Second.Columns.Item(i).ColumnName & "_Second"), Second.Columns.Item(i).DataType)
                End If
            Next i
            table.BeginLoadData()
            Dim firstrow As DataRow
            For Each firstrow In ds.Tables.Item(0).Rows
                Dim childrows As DataRow() = firstrow.GetChildRows(r)
                If ((Not childrows Is Nothing) AndAlso (childrows.Length > 0)) Then
                    Dim parentarray_ As Object() = firstrow.ItemArray
                    Dim secondrow As DataRow
                    For Each secondrow In childrows
                        Dim secondarray As Object() = secondrow.ItemArray
                        Dim joinarray_ As Object() = New Object((parentarray_.Length + secondarray.Length) - 1) {}
                        Array.Copy(parentarray_, 0, joinarray_, 0, parentarray_.Length)
                        Array.Copy(secondarray, 0, joinarray_, parentarray_.Length, secondarray.Length)
                        table.LoadDataRow(joinarray_, True)
                    Next
                    Continue For
                End If
                Dim parentarray As Object() = firstrow.ItemArray
                Dim joinarray As Object() = New Object(parentarray.Length - 1) {}
                Array.Copy(parentarray, 0, joinarray, 0, parentarray.Length)
                table.LoadDataRow(joinarray, True)
            Next
            table.EndLoadData()
        End Using
        Return table
    End Function

    Function LeftJoin(ByVal First As DataTable, ByVal Second As DataTable, ByVal FJC As String, ByVal SJC As String) As DataTable
        Return LeftJoin(First, Second, New DataColumn() {First.Columns.Item(FJC)}, New DataColumn() {First.Columns.Item(SJC)})
    End Function

    Private Sub frmReturns_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        With dt_Return
            .Columns.Add("No", GetType(System.String))
            .Columns.Add("APP_NO", GetType(System.String))
            .Columns.Add("member_name", GetType(System.String))
            .Columns.Add("borrow_date", GetType(System.String))
            .Columns.Add("ReadBy", GetType(System.String))
            .Columns.Add("Reserve", GetType(System.Boolean))
            .Columns.Add("ItemID", GetType(System.String))
            .Columns.Add("member_id", GetType(System.String))
            .Columns.Add("Printdate", GetType(System.String))
            .Columns.Add("staff", GetType(System.String))
            .Columns.Add("REF_INNOVA_ID", GetType(System.String))
        End With

        With dt_Error
            .Columns.Add("No", GetType(System.String))
            .Columns.Add("APP_NO", GetType(System.String))
            .Columns.Add("member_name", GetType(System.String))
            .Columns.Add("borrow_date", GetType(System.String))
            .Columns.Add("ReadBy", GetType(System.String))
            .Columns.Add("Reserve", GetType(System.Boolean))
        End With

        With dt_Reserve
            .Columns.Add("No", GetType(System.String))
            .Columns.Add("APP_NO", GetType(System.String))
            .Columns.Add("member_name", GetType(System.String))
            .Columns.Add("borrow_date", GetType(System.String))
            .Columns.Add("ReadBy", GetType(System.String))
            .Columns.Add("Reserve", GetType(System.Boolean))
        End With
        FinddataBorrow() 'หารายการยืมทั้งหมด เก็บไว้ใน Datable Table
    End Sub

    Sub FinddataBorrow()
        '************************* หารายการยืมทั้งหมด *************************
        'Dim dal_FileBorrow As New TbFileBorrowItemDAL
        'sql = "declare @staff as varchar(50); select @staff = (select top 1 isnull(tt.title_name,'') + ' ' + isnull(ofc.fname,'') + ' ' + isnull(ofc.lname,'') from TB_OFFICER as ofc left join TB_TITLE as tt on ofc.title_id = tt.id where ofc.username = '" & frmMain.txtUserName.Text.Replace("'", "''").Trim & "');"
        'sql &= "select distinct fb_it.id as ItemID,req.app_no,borrower_id as member_id,borrowername as member_name,convert(varchar(10),dateadd(yyyy,543,borrowerdate),103) as borrow_date,convert(varchar(10),dateadd(yyyy,543,getdate()),103) as Printdate,@staff as staff"
        'sql &= " ,scan_by as ReadBy,rs.requidition_id as Reserve"
        'sql &= " from TB_FILEBORROWITEM as fb_it"
        'sql &= " left join TB_FILEBORROW as fb on fb_it.fileborrow_id = fb.id"
        'sql &= " left join TB_REQUISTION as req on fb_it.requisition_id = req.id"
        'sql &= " left join (select requidition_id  from TB_RESERVE where reserve_order=1 and id not in (select reserve_id from TB_FILEBORROWITEM)) as rs"
        'sql &= " on fb_it.requisition_id = rs.requidition_id"
        'sql &= " where ISNULL(returndate,'') = '' and ISNULL(fb_it.requisition_id,'') <> ''"

        '*********************************** New 
        Dim dal_FileBorrow As New TbFileBorrowItemDAL
        sql = "declare @staff as varchar(50); select @staff = (select top 1 isnull(tt.title_name,'') + ' ' + isnull(ofc.fname,'') + ' ' + isnull(ofc.lname,'') from TB_OFFICER as ofc left join TB_TITLE as tt on ofc.title_id = tt.id where ofc.username = '" & frmMain.txtUserName.Text.Replace("'", "''").Trim & "');"
        sql &= "select distinct fb_it.id as ItemID,req.app_no,borrower_id as member_id,borrowername as member_name,convert(varchar(10),dateadd(yyyy,543,borrowerdate),103) as borrow_date,convert(varchar(10),dateadd(yyyy,543,getdate()),103) as Printdate,@staff as staff"
        sql &= " ,scan_by as ReadBy,rs.requidition_id as Reserve,0 as REF_INNOVA_ID"
        sql &= " from TB_FILEBORROWITEM as fb_it"
        sql &= " left join TB_FILEBORROW as fb on fb_it.fileborrow_id = fb.id"
        sql &= " left join TB_REQUISTION as req on fb_it.requisition_id = req.id"
        sql &= " left join (select requidition_id  from TB_RESERVE where id not in (select reserve_id from TB_FILEBORROWITEM)) as rs"
        sql &= " on fb_it.requisition_id = rs.requidition_id"
        sql &= " where ISNULL(returndate,'') = '' and ISNULL(fb_it.requisition_id,'') <> ''"
        sql &= " union all select 0 as ItemID,x.app_no,BORROWERID as member_id,BORROWNAME as member_name ,convert(varchar(10),dateadd(yyyy,543,BORROWDATE),103) as borrow_date ,convert(varchar(10),dateadd(yyyy,543,getdate()),103) as Printdate,'' as staff ,'' as ReadBy,rs.requidition_id as Reserve,x.ID as REF_INNOVA_ID from " & ModuleConfig.IPINNOVA & "PATENTSYSTEM.dbo.FILEBORROWITEM x left join TB_REQUISTION y on x.APP_NO = y.app_no left join (select requidition_id  from TB_RESERVE where reserve_order=1 and id not in (select reserve_id from TB_FILEBORROWITEM)) as rs on y.id = rs.requidition_id where BORROWSTATUS in ('B','T') and x.app_no  not in (select b.app_no  from TB_FILEBORROWITEM a left join TB_REQUISTION b on a.requisition_id = b.id where a.updateby is null)"
        '***********************************

        dt_Borrow = dal_FileBorrow.GetListBySql(sql, "", Nothing)
        '*****************************************************************
    End Sub

    Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtBarcode.Text = txtBarcode.Text.Replace("*", "")
            Dim dal As New TbRequisitionDAL
            Dim data As New TbRequisitionData
            If dal.ChkDataByWhere("APP_NO = '" & txtBarcode.Text.Trim.Replace("'", "''") & "' and qty = 1", Nothing) = True Then
                'ถ้าไม่มีแฟ้มต่อ
                GetDataReturn(txtBarcode.Text)
                'Dim dvReturn As DataView
                'dvReturn = New DataView(dt_Return.Copy, "", "app_no asc", DataViewRowState.CurrentRows)
                'Dim dvError As DataView
                'dvError = New DataView(dt_Error.Copy, "", "app_no asc", DataViewRowState.CurrentRows)
                'Dim dvReserve As DataView
                'dvReserve = New DataView(dt_Reserve.Copy, "", "app_no asc", DataViewRowState.CurrentRows)
                'gdvReturns.DataSource = dvReturn
                'gdvError.DataSource = dvError
                'gdvBook.DataSource = dvReserve
                gdvReturns.DataSource = dt_Return
                gdvError.DataSource = dt_Error
                gdvBook.DataSource = dt_Reserve
                If CheckReturn(False) = True Then
                    btnConfirm.Enabled = True
                    btnConfirm.BackgroundImage = Image.FromFile("images/blog4_033.jpg")
                    'btnPrint.Enabled = True
                Else
                    btnConfirm.Enabled = False
                    'btnPrint.Enabled = False
                    btnConfirm.BackgroundImage = Image.FromFile("images/Dis_blog4_033.jpg")
                End If
                'GroupBox1.Text = "จำนวนรายการคืนทั้งหมด " & dt_Return.Rows.Count & " รายการ"
                'GroupBox2.Text = "จำนวนรายการที่ไม่ผ่านการยืมทั้งหมด " & dt_Error.Rows.Count & " รายการ"
                'GroupBox3.Text = "จำนวนรายการที่มีการจองทั้งหมด " & dt_Reserve.Rows.Count & " รายการ"

                lblR_txtload.Visible = False
                lblR_txt1.Visible = True
                lblR_txt2.Visible = True
                lblR_count.Visible = True
                lblR_count.Text = dt_Return.Rows.Count '+ Count_Return
                lblE_txtload.Visible = False
                lblE_txt1.Visible = True
                lblE_txt2.Visible = True
                lblE_count.Visible = True
                lblE_count.Text = dt_Error.Rows.Count '+ Count_Return
                lblB_txtload.Visible = False
                lblB_txt1.Visible = True
                lblB_txt2.Visible = True
                lblB_count.Visible = True
                lblB_count.Text = dt_Reserve.Rows.Count '+ Count_Return
                'Else
                '    MsgBox("ไม่มีรายการนี้ในระบบ")
            End If
            txtBarcode.Text = ""
            txtBarcode.Focus()
        End If
    End Sub

    Private Sub gdvReturns_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles gdvReturns.CellFormatting
        For i As Integer = 0 To gdvReturns.Rows.Count - 1
            Select Case gdvReturns.Rows(i).Cells("ReadBy").Value
                Case "RFID"
                    gdvReturns.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 128)
                Case "BARCODE"
                    gdvReturns.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End Select
            gdvReturns.Rows(i).DefaultCellStyle.SelectionBackColor = gdvReturns.Rows(i).DefaultCellStyle.BackColor
            gdvReturns.Rows(i).DefaultCellStyle.SelectionForeColor = gdvReturns.Rows(i).DefaultCellStyle.ForeColor
        Next
    End Sub

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


    Private Sub gdvReturns_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub frmReturns_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel1.BackgroundImage = Image.FromFile("images/blog4_03_big.jpg")
        PictureReserve.BackgroundImage = Image.FromFile("images/bg.png")
        btnReadRFID.BackgroundImage = Image.FromFile("images/blog4_11.jpg")
        'btnReadRFID.BackgroundImage = Image.FromFile("images/Dis_blog3_09.jpg")
        btnCancel.BackgroundImage = Image.FromFile("images/blog4_07.jpg")
        'btnConfirm.BackgroundImage = Image.FromFile("images/blog4_033.jpg")
        btnConfirm.BackgroundImage = Image.FromFile("images/Dis_blog4_033.jpg")
        'btnPrint.BackgroundImage = Image.FromFile("images/blog4_066.jpg")
        btnPrint.BackgroundImage = Image.FromFile("images/Dis_blog4_066.jpg")
        Panel5.BackgroundImage = Image.FromFile("images/blog4_03_smaller.jpg")
        btnMobileDevice.BackgroundImage = Image.FromFile("images/blog3_31.jpg")

        'ลบ Temp
        SqlDB.ExecuteNonQuery("DELETE FROM TMP_GATE_READER_TAG WHERE Reader_id=" & ReadBarcodeFromTextFile.GetReaderId)

        'ซ่อนปุ่มเปิดประตู
        If ReadBarcodeFromTextFile.GetIsBox = 0 Then
            Button1.Visible = False
        End If
        txtBarcode.Focus()
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
       
        Try

            Dim sw As New StreamWriter(Application.StartupPath & "\Gate.txt", True)
            sw.Write("GATE1:ON")
            sw.Dispose()
            Dim filebuffer As Byte()
            Dim networkStream As NetworkStream
            Dim clientSocket As New TcpClient("10.9.6.20", 1025)
            Dim fileStream As Stream
            fileStream = File.OpenRead(Application.StartupPath & "\Gate.txt")
            ' Alocate memory space for the file 
            ReDim filebuffer(fileStream.Length)
            fileStream.Read(filebuffer, 0, fileStream.Length)
            ' Open a TCP/IP Connection and send the data 


            NetworkStream = clientSocket.GetStream()
            NetworkStream.Write(filebuffer, 0, fileStream.Length)
            Try

                Dim strResut As Integer = 0
                strResut = NetworkStream.Read(filebuffer, 0, fileStream.Length)
                If strResut <> 0 Then MsgBox("door is opened!!") Else MsgBox("Cannot open the door")
            Catch ex As Exception
                MsgBox("Cannot open the door")

            End Try
            clientSocket.Close()
            networkStream.Close()
            networkStream.Dispose()
            fileStream.Close()
            fileStream.Dispose()
            'NetworkStream.Close()
        Catch ex As Exception
            MsgBox("Cannot open the door")
        End Try
    End Sub
End Class