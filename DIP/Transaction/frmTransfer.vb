Imports System.Data
Imports System.Data.SqlClient
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.Data.Table
Imports DIP_RFID.DAL.Common.Utilities
Imports OpenNETCF.Desktop.Communication
Imports System.IO
Imports System.Net.Sockets

Public Class frmTransfer

    Private Sub frmTransfer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetLocation()

        PictureReserve.BackgroundImage = Image.FromFile("Images/bg.png")
        Panel1.BackgroundImage = Image.FromFile("Images/blog4_03_small.jpg")
        btnReadRFID.BackgroundImage = Image.FromFile("Images/blog3_09.jpg")
        btnCancel.BackgroundImage = Image.FromFile("Images/blog3_13.jpg")
        btnMobileDevice.BackgroundImage = Image.FromFile("images/blog3_31.jpg")
        Panel5.BackgroundImage = Image.FromFile("images/blog4_03_smaller.jpg")
        btnPrint.BackgroundImage = Image.FromFile("images/Dis_blog5_066.jpg")

        SetControl()

        'ลบ Temp
        SqlDB.ExecuteNonQuery("DELETE FROM TMP_GATE_READER_TAG WHERE Reader_id=" & ReadBarcodeFromTextFile.GetReaderId)

        'ซ่อนปุ่มเปิดประตู
        If ReadBarcodeFromTextFile.GetIsBox = 0 Then
            Button1.Visible = False
        End If
        txtBarcode.Focus()
    End Sub
    Private Sub SetControl()
        If gdvDataBook.RowCount = 0 Then
            btnComfirm.Enabled = False
            btnComfirm.BackgroundImage = Image.FromFile("Images/Dis_blog4_033.jpg")
        Else
            btnComfirm.Enabled = True
            btnComfirm.BackgroundImage = Image.FromFile("Images/blog4_033.jpg")
        End If
    End Sub

    Private Sub frmTransfer_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.ControlBox = False
    End Sub

    Private Sub btnReadRFID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadRFID.Click
        showdata()
    End Sub

    Private Sub btnComfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComfirm.Click
        UpdateLocation()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'ลบ Temp
        SqlDB.ExecuteNonQuery("DELETE FROM TMP_GATE_READER_TAG WHERE Reader_id=" & ReadBarcodeFromTextFile.GetReaderId)

        ClearForm()
        SetControl()
    End Sub

    Private Sub ClearForm()
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("seq", GetType(String)))
        dt.Columns.Add(New DataColumn("tag_id", GetType(String)))
        dt.Columns.Add(New DataColumn("ReadBy", GetType(String)))
        dt.Columns.Add(New DataColumn("location", GetType(String)))

        gdvDataBook.DataSource = dt
        dt.Dispose()

        txtBarcode.Text = ""
        ddlLocation.SelectedIndex = 0
    End Sub

    Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txtBarcode.Text) = "" Then
                MessageBox.Show("กรุณาระบุ Barcode")
                Exit Sub
            End If

            If IsExistBook() = False Then
                MessageBox.Show("กรุณาระบุ Barcode ให้ถูกต้อง")
                Exit Sub
            End If

            'If CheckDuplicate(txtBarcode.Text) = True Then
            '    MessageBox.Show("Barcode ซ้ำ")
            '    Exit Sub
            'End If


            Dim dt As New DataTable
            If gdvDataBook.RowCount > 0 Then
                dt = gdvDataBook.DataSource
            Else
                dt.Columns.Add(New DataColumn("seq", GetType(String)))
                dt.Columns.Add(New DataColumn("tag_id", GetType(String)))
                dt.Columns.Add(New DataColumn("ReadBy", GetType(String)))
                dt.Columns.Add(New DataColumn("location", GetType(String)))
            End If


            Dim dvTemp As DataView = dt.Copy.DefaultView
            dvTemp.RowFilter = "tag_id=" & txtBarcode.Text.Trim
            If dvTemp.Count = 0 Then
                Dim dr As DataRow
                dr = dt.NewRow
                dr("seq") = dt.Rows.Count + 1
                dr("tag_id") = Trim(txtBarcode.Text)
                dr("ReadBy") = "BARCODE"
                dr("location") = GetLocationByStore(Trim(txtBarcode.Text))
                dt.Rows.Add(dr)
            End If
            dvTemp.RowFilter = ""

            gdvDataBook.DataSource = dt
            dt.Dispose()
            txtBarcode.Text = ""
            txtBarcode.Focus()
            SetControl()
        End If
    End Sub

    Private Function CheckDuplicate(ByVal tag_id As String) As Boolean
        Dim ValueReturn As Boolean
        If gdvDataBook.RowCount > 0 Then
            Dim dttemp As DataTable = gdvDataBook.DataSource
            Dim dvtemp As DataView = dttemp.DefaultView
            dvtemp.RowFilter = "tag_id='" & tag_id & "'"
            If dvtemp.Count > 0 Then
                ValueReturn = True
            Else
                ValueReturn = False
            End If
            dvtemp.RowFilter = ""
        Else
            ValueReturn = False
        End If

        Return ValueReturn
    End Function


    Private Sub showdata()

        Try

            btnReadRFID.Enabled = False
            btnReadRFID.BackgroundImage = Image.FromFile("images/Dis_blog3_09.jpg")

            If ReadBarcodeFromTextFile.GetModuleRead = 1 Then
                ReadWriteModule()
                InsertDataModule()
            End If

            Dim dal As New TmpGateReaderTagDAL
            Dim sql As String = ""
            sql &= " select distinct TG.tag_id ,RT.locationname as location"
            sql &= " from TMP_GATE_READER_TAG TG"
            sql &= " LEFT JOIN TB_FileStore FS"
            sql &= " ON FS.app_no = TG.tag_id"
            sql &= " LEFT JOIN TB_FileLocation RT"
            sql &= " ON FS.filelocation = RT.id"
            sql &= " where read_type = 3  and TG.reader_id=" & Func.GetReaderId & ""
            Dim dt As New DataTable
            'dt = dal.GetListBySql(sql, "app_no", Nothing)
            dt = SqlDB.ExecuteTable(sql)


            dt.Columns.Add("seq")
            dt.Columns.Add("ReadBy")

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("seq") = i + 1
                dt.Rows(i)("ReadBy") = "RFID"
            Next
            gdvDataBook.DataSource = dt

            dt.Dispose()
            dal = Nothing
            SetControl()

            btnReadRFID.Enabled = True
            btnReadRFID.BackgroundImage = Image.FromFile("images/blog4_11.jpg")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
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
        Dim IsInsert As Boolean = ReadTextFile.ReadTextFileModuleAndInsertToTemp(3)
        If IsInsert = False Then
            '-------------- Display Error -------------
            MsgBox("ไม่สามารถอ่านไฟล์รายงานผลได้")
            Exit Sub
        End If
    End Sub

    Private Sub UpdateLocation()
        Try

            'If ddlLocation.SelectedIndex = 0 Then
            '    MessageBox.Show("กรุณาระบุ Location")
            '    Exit Sub
            'End If

            If gdvDataBook.RowCount = 0 Then
                MessageBox.Show("กรุณาระบุแฟ้มที่ต้องการย้าย")
                Exit Sub
            End If

            Dim trans As New SqlTransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            dt = gdvDataBook.DataSource

            Dim ReaderID As String = ReadBarcodeFromTextFile.GetReaderId
            Dim FileLocationID As Long = GetFilelocationByReaderID(ReaderID)
            Dim RoomInfo As DataTable = GetRoomInfo(FileLocationID)

            For i As Integer = 0 To dt.Rows.Count - 1
                Dim dalItem As New TbRequisitionDAL
                Dim tag_id As String = dt.Rows(i).Item("tag_id").ToString()
                dalItem.GetDataByAPP_NO(tag_id, trans.Trans)
                '  dalItem.LOCATION = ddlLocation.SelectedValue
                dalItem.STATUS = "inprogress"
                dalItem.FILELOCATION = FileLocationID
                dalItem.UpdateByID(frmMain.txtIdUser.Text, trans.Trans)


                'Update TS_FILE_CURRENT_LOCATION
                Dim Sql As String = " select id, ms_room_id "
                Sql += " from TS_FILE_CURRENT_LOCATION"
                Sql += " where app_no='" & tag_id & "'"
                Dim Fdt As DataTable = SqlDB.ExecuteTable(Sql)
                Dim IsInsertHis As Boolean = False
                Dim strSQL As String = ""
                If Fdt.Rows.Count > 0 Then
                    If RoomInfo.Rows.Count > 0 Then
                        Fdt.DefaultView.RowFilter = "ms_room_id='" & RoomInfo.Rows(0)("ms_room_id") & "'"
                        If Fdt.DefaultView.Count = 0 Then
                            strSQL = " UPDATE TS_FILE_CURRENT_LOCATION" & vbNewLine
                            strSQL += " set updated_by='" & frmMain.txtUserName.Text & "' , updated_date=getdate() " & vbNewLine
                            strSQL += " , move_date=getdate()" & vbNewLine
                            strSQL += " , readerid='" & ReaderID & "',rssi=0,ant_port_number=1 " & vbNewLine
                            strSQL += " , location_name = '" & RoomInfo.Rows(0)("room_name") & "'" & vbNewLine
                            strSQL += " , ms_room_id = '" & RoomInfo.Rows(0)("ms_room_id") & "'" & vbNewLine
                            strSQL += " , tb_officer_id=0, officer_name='', ms_desktop_id=0, desk_name=''" & vbNewLine
                            strSQL += " where app_no='" & tag_id & "';" & vbNewLine & vbNewLine
                            SqlDB.ExecuteTable(strSQL)

                            IsInsertHis = True
                        End If
                        Fdt.DefaultView.RowFilter = ""
                    End If
                Else
                    strSQL = " INSERT INTO TS_FILE_CURRENT_LOCATION(created_by,created_date,app_no" & vbNewLine
                    strSQL += " ,move_date,ReaderID,rssi,ant_port_number,location_name,ms_room_id" & vbNewLine
                    strSQL += " ,tb_officer_id,officer_name,ms_desktop_id,desk_name)" & vbNewLine
                    strSQL += " VALUES('" & frmMain.txtUserName.Text & "',getdate(),'" & tag_id & "'," & vbNewLine
                    strSQL += " getdate(),'" & ReaderID & "',0,1,'" & RoomInfo.Rows(0)("room_name") & "','" & RoomInfo.Rows(0)("ms_room_id") & "'" & vbNewLine
                    strSQL += " ,0,'',0,'');" & vbNewLine & vbNewLine
                    SqlDB.ExecuteTable(strSQL)

                    IsInsertHis = True
                End If

                If IsInsertHis = True Then
                    strSQL = " INSERT INTO TS_FILE_MOVE_HISTORY(created_by,created_date,app_no"
                    strSQL += " ,move_date,ReaderID,rssi,ant_port_number,location_name,ms_room_id"
                    strSQL += " ,tb_officer_id,officer_name,ms_desktop_id,desk_name "
                    strSQL += " ,ms_grid_layout_id, grid_row, grid_col, is_update_current_location)"
                    strSQL += " VALUES('" & frmMain.txtUserName.Text & "',getdate(),'" & tag_id & "'" & vbNewLine
                    strSQL += " ,getdate(),'" & ReaderID & "',0,1,'" & RoomInfo.Rows(0)("room_name") & "','" & RoomInfo.Rows(0)("ms_room_id") & "'" & vbNewLine
                    strSQL += " ,0,'',0,''"
                    strSQL += " ,0,0,0,'Y');" & vbNewLine
                    SqlDB.ExecuteTable(strSQL)
                End If
            Next
            dt.Dispose()

            'ยืนยันเสร็จให้ลบ Temp
            SqlDB.ExecuteNonQuery("DELETE FROM TMP_GATE_READER_TAG WHERE Reader_id=" & ReadBarcodeFromTextFile.GetReaderId)


            trans.CommitTransaction()
            'ClearForm()
            MsgBox("บันทึกข้อมูลเรียบร้อย")
            'btnReadRFID.Enabled = False
            'btnReadRFID.BackgroundImage = Image.FromFile("images/Dis_blog3_09.jpg")
            btnComfirm.Enabled = False
            btnComfirm.BackgroundImage = Image.FromFile("images/Dis_blog4_033.jpg")
            btnPrint.Enabled = True
            btnPrint.BackgroundImage = Image.FromFile("images/blog5_066.jpg")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Function GetFilelocationByReaderID(ByVal ReaderID As String) As Integer
        'Dim tbreq As New TbRequisitionDAL
        'Dim dtReq As New DataTable
        'Dim Trans As New SqlTransactionDB
        'Trans.CreateTransaction()
        'dtReq = tbreq.GetListBySql("Select id From TB_FILELOCATION WHERE ReaderId='" & ReaderID & "'", "", Trans.Trans)
        'Dim ApplicationNo As String = ""
        'If dtReq.Rows.Count > 0 Then
        '    ApplicationNo = dtReq.Rows(0).Item("Id") & ""
        'Else
        '    ApplicationNo = ""
        'End If
        'Trans.CommitTransaction()
        'Return ApplicationNo

        Dim strSQL As String
        strSQL = "Select id From TB_FILELOCATION WHERE ReaderId='" & ReaderID & "'"
        Dim dt As DataTable = SqlDB.ExecuteTable(strSQL)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)("id")
        Else
            Return 0
        End If
    End Function

    Private Function IsExistBook() As Boolean
        Dim dal As New TbRequisitionDAL
        Dim trans As New SqlTransactionDB
        Dim dt As New DataTable
        dal.GetDataByAPP_NO(txtBarcode.Text, trans.Trans)
        If dal.ID = 0 Then
            Return False
        End If
        Return True
    End Function

    Private Sub SetLocation()
        Dim dal As New TbRequisitionDAL
        Dim trans As New SqlTransactionDB
        Dim dt As New DataTable
        Dim sql As String = "select distinct id,location_name from tb_filelocation"
        dt = dal.GetListBySql(sql, "location_name", trans.Trans)
        Dim dr As DataRow = dt.NewRow
        dr("location_name") = "--Select Location--"
        dt.Rows.InsertAt(dr, 0)

        ddlLocation.ValueMember = "id"
        ddlLocation.DisplayMember = "location_name"
        ddlLocation.DataSource = dt

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


    Private Sub gdvDataBook_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles gdvDataBook.CellFormatting
        For i As Integer = 0 To gdvDataBook.Rows.Count - 1
            Select Case gdvDataBook.Rows(i).Cells("ReadBy").Value
                Case "RFID"
                    gdvDataBook.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 128)
                Case "BARCODE"
                    gdvDataBook.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End Select
            gdvDataBook.Rows(i).DefaultCellStyle.SelectionBackColor = gdvDataBook.Rows(i).DefaultCellStyle.BackColor
            gdvDataBook.Rows(i).DefaultCellStyle.SelectionForeColor = gdvDataBook.Rows(i).DefaultCellStyle.ForeColor
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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
            networkStream.Write(filebuffer, 0, fileStream.Length)
            Try

                Dim strResut As Integer = 0
                strResut = networkStream.Read(filebuffer, 0, fileStream.Length)
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

    Private Function GetLocationByTag(ByVal TagID As String) As String
        Dim dal As New TbRequisitionDAL
        Dim trans As New SqlTransactionDB
        Dim dtLocation As New DataTable
        Dim sql As String = "select location from TB_REQUISTION where app_no='" & TagID & "'"
        dtLocation = dal.GetListBySql(sql, "Location", trans.Trans)
        If dtLocation.Rows.Count > 0 Then
            Return dtLocation.Rows(0)("location") & ""
        Else
            Return ""
        End If
    End Function

    Private Function GetLocationByStore(ByVal TagID As String) As String
        Dim dal As New TbLogLocationDAL
        Dim trans As New SqlTransactionDB
        Dim dtLocation As New DataTable
        Dim sql As String
        sql = "select top 1 "
        sql &= " FS.app_no"
        sql &= " ,RT.location_name"
        sql &= " FROM TB_FileStore FS"
        sql &= " LEFT JOIN TB_FileLocation RT"
        sql &= " ON FS.filelocation = RT.id"
        sql &= " where FS.app_no='" & TagID & "'"
        ' sql &= " order by logl.log_date desc"
        dtLocation = dal.GetListBySql(sql, "app_no desc", trans.Trans)
        If dtLocation.Rows.Count > 0 Then
            Return dtLocation.Rows(0)("location_name") & ""
        Else
            Return ""
        End If
    End Function

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        '******** Get datatable เพื่อเอาไปแสดงใน Report **********
        '************ โดยเลือกเอา เฉพาะที่มีรายการยืม *****************

        Dim dt As New DataTable
        dt = (DirectCast(gdvDataBook.DataSource, DataTable)).Copy
        dt.Columns.Add("Printdate", GetType(System.String))
        dt.Columns.Add("staff", GetType(System.String))
        dt.Columns.Add("filecount", GetType(System.String))
        For i As Integer = 0 To dt.Rows.Count - 1
            dt(i)("staff") = frmMain.txtFullUserName.Text
            dt(i)("printdate") = Date.Now.ToShortDateString
            dt(i)("filecount") = dt.Rows.Count
        Next

        dt.TableName = "dsTransfer"
        Dim dsNew As New DataSet
        dsNew.Tables.Add(dt)
        Dim rep As New rptTransfer
        With dsNew
            For i As Integer = 0 To .Tables.Count - 1
                rep.Database.Tables(.Tables(i).TableName).SetDataSource(.Tables(i))
            Next
        End With
        rep.SetDataSource(dt)
        Dim cryViewer As New frmReportPreview
        cryViewer.CrystalReportViewer1.ReportSource = rep
        cryViewer.CrystalReportViewer1.Refresh()
        cryViewer.WindowState = FormWindowState.Maximized
        cryViewer.Show()


        ClearForm()


        'Dim dsNew As New DataSet
        'dsNew.Tables.Add(dt)
        'dsNew.WriteXmlSchema("C:\dsTransfer.xsd")
        'ClearForm
        'dt_Return.DefaultView.RowFilter = "isnull(borrow_date,'') <> ''"
        'dt_finddata = dt_Return.DefaultView.ToTable
        'For i As Int32 = 0 To dt_finddata.Rows.Count - 1
        '    dr = dt_report.NewRow
        '    dr("requisition_id") = dt_finddata.Rows(i).Item("APP_NO").ToString
        '    dr("member_name") = dt_finddata.Rows(i).Item("member_name").ToString
        '    dr("borrow_date") = dt_finddata.Rows(i).Item("borrow_date").ToString
        '    dr("member_id") = dt_finddata.Rows(i).Item("member_id").ToString
        '    dr("Printdate") = dt_finddata.Rows(i).Item("Printdate").ToString
        '    dr("staff") = dt_finddata.Rows(i).Item("staff").ToString
        '    dr("filecount") = dt_finddata.Rows.Count
        '    dt_report.Rows.Add(dr)
        'Next
        'dt_Return.DefaultView.RowFilter = ""
        ''******************************************************

        'dt_report.DefaultView.Sort = "requisition_id"
        'btnPrint.Cursor = Cursors.AppStarting
        'btnPrint.Enabled = False
        'btnPrint.BackgroundImage = Image.FromFile("images/Dis_blog4_066.jpg")
        'Dim trans As New SqlTransactionDB
        'trans.CreateTransaction()
        ''If SaveBorrow(False) = True Then

        'Dim logonInfo As New TableLogOnInfo
        'logonInfo.ConnectionInfo.DatabaseName = SqlDB.DbName
        'logonInfo.ConnectionInfo.UserID = SqlDB.UserID
        'logonInfo.ConnectionInfo.Password = SqlDB.Password

        'Dim rep As New rptReturn
        'rep.SetDataSource(dt_report.DefaultView.ToTable)
        'rep.Database.Tables(0).ApplyLogOnInfo(logonInfo)

        ''rep.DataDefinition.FormulaFields("staff").Text = frm_ReportBorrow.TextBox1.Text

        'Dim cryViewer As New frmReportPreview
        'cryViewer.CrystalReportViewer1.ReportSource = rep
        'cryViewer.CrystalReportViewer1.Refresh()
        'cryViewer.WindowState = FormWindowState.Maximized
        'cryViewer.Show()


    End Sub
End Class