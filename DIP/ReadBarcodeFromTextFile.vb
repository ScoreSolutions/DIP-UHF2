Imports System.IO
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.Common.Utilities

Public Class ReadBarcodeFromTextFile
 
    Function ReadTextFile(ByVal strFilePath As String) As DataTable
        If File.Exists(strFilePath) = False Then
            Return New DataTable
        End If
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("APP_NO", GetType(String))) '------------รหัส Patent----------
        dt.Columns.Add(New DataColumn("APP_NAME", GetType(String))) '--------------ชื่อ Patent---------
        dt.Columns.Add(New DataColumn("APP_POSITION", GetType(String))) '-------------ตำแหน่งที่เก็บ-------------
        dt.Columns.Add(New DataColumn("LOAD_DATETIME", GetType(String))) '----------เวลาที่ Load เข้า -----------
        dt.Columns.Add(New DataColumn("FIND_STATUS", GetType(String))) '0 = Not found , 1 = Found , 2 = Post
        Dim dr As DataRow
        Dim line, lineTemp As String
        Dim ckLine As String()
        Dim ValueSearch As String
        Dim sr As New StreamReader(strFilePath)
        Try
            ' Dim sr As New StreamReader(strFilePath)
            While (sr.Peek() > -1)
                lineTemp = sr.ReadLine
                ckLine = lineTemp.Split(",") 'มี , บาง  ใน File Check Out
                If ckLine.Length > 0 Then
                    line = ckLine(0)
                    If ckLine.Length > 1 Then
                        ValueSearch = ckLine(1)
                    Else
                        ValueSearch = 1
                    End If

                Else
                    line = lineTemp
                    ValueSearch = 1
                End If
                If ValueSearch = 1 Then
                    dr = dt.NewRow
                    dr("APP_NO") = line
                    dr("APP_NAME") = ""
                    dr("APP_POSITION") = ""
                    dr("LOAD_DATETIME") = Date.Now
                    dr("FIND_STATUS") = 1
                    dt.Rows.Add(dr)
                End If

            End While


        Catch e As Exception
            'Console.WriteLine("The file could not be read:")
            'Console.WriteLine(e.Message)
        Finally
            sr.Close()
        End Try
        Return dt

        'Dim IniFileName As String = Application.StartupPath & "\" & strFileName
        'Dim ini As New IniReader(IniFileName)
        'ini.Section = "Setting"
        'Dim mypath As String = ini.ReadString("txtBarcodePath ")

        'Dim dt As New DataTable
        'dt.Columns.Add(New DataColumn("Barcode", GetType(String)))
        'Dim line As String = ""
        'Try
        '    Dim sr As New StreamReader(mypath)
        '    Dim dr As DataRow
        '    While (sr.Peek() > -1)
        '        line = sr.ReadLine
        '        dr = dt.NewRow
        '        dr(0) = line
        '        dt.Rows.Add(dr)
        '    End While
        'Catch
        'End Try
        'Return dt
    End Function

    Function ReadTextFileAndInsertToTemp(ByVal strFilePath As String, ByVal reader_id As String, ByVal read_type As String) As Boolean
        Dim IsInsert As Boolean = True
        Dim dt As New DataTable
        dt = ReadTextFile(strFilePath)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

            Try
                Dim Trans As New SqlTransactionDB
                Trans.CreateTransaction()
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim tagrfid As String = dt.Rows(i).Item("APP_NO") & ""
                    Dim tbreq As New TbRequisitionDAL
                    Dim dtReq As New DataTable
                    Dim dtTemp As New DataTable
                    dtReq = tbreq.GetListBySql("Select App_No From TB_REQUISTION WHERE App_No='" & tagrfid & "'", "", Trans.Trans)
                    If dtReq.Rows.Count = 0 Then
                        Continue For
                    End If
                    dtTemp = tbreq.GetListBySql("Select tag_id From TMP_GATE_READER_TAG WHERE  tag_id='" & tagrfid & "'", "", Trans.Trans)
                    If dtTemp.Rows.Count > 0 Then
                        Continue For
                    End If

                    Dim tmp As New TmpGateReaderTagDAL
                    tmp.READER_ID = GetReaderId()
                    tmp.TAG_ID = tagrfid
                    tmp.READ_TYPE = read_type
                    tmp.CREATEBY = "MOBILE"
                    Dim a = tmp.InsertData("MOBILE", Trans.Trans)
                Next
                Trans.CommitTransaction()
            Catch ex As Exception
                IsInsert = False
            End Try

            Return IsInsert
        End If
    End Function

    Function GetApplicationNoByRFID(ByVal tagrfid As String) As String
        Dim tbreq As New TbRequisitionDAL
        Dim dtReq As New DataTable
        Dim Trans As New SqlTransactionDB
        Trans.CreateTransaction()
        dtReq = tbreq.GetListBySql("Select App_No From TB_REQUISTION WHERE TAGRFID='" & tagrfid & "'", "", Trans.Trans)
        Dim ApplicationNo As String = ""
        If dtReq.Rows.Count > 0 Then
            ApplicationNo = dtReq.Rows(0).Item("App_No") & ""
        Else
            ApplicationNo = ""
        End If
        Trans.CommitTransaction()
        Return ApplicationNo
    End Function

    Function ReadTextFileModule() As DataTable
        Dim strFilePath As String = Application.StartupPath & "\RFID\" & "RFID.txt"
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("TagID", GetType(String))) '------------รหัส Patent----------
        dt.Columns.Add(New DataColumn("AntID", GetType(String))) '--------------ชื่อ Patent---------
        dt.Columns.Add(New DataColumn("RSSI", GetType(String))) '-------------ตำแหน่งที่เก็บ-------------
        dt.Columns.Add(New DataColumn("Time", GetType(String))) '----------เวลาที่ Load เข้า -----------
        Dim dr As DataRow
        Dim line As String = ""
        Dim lineTemp As String = ""
        Dim strTagID As String = ""
        Dim strAntID As String = ""
        Dim strRSSI As String = ""
        Dim strTime As String = ""
        Dim ckLine As String()
        Dim sr As New StreamReader(strFilePath)
        Try
            ' Dim sr As New StreamReader(strFilePath)
            While (sr.Peek() > -1)
                lineTemp = sr.ReadLine
                ckLine = lineTemp.Split(",") 'มี , บาง  ใน File Check Out
                If ckLine.Length = 4 Then
                    strTagID = ckLine(0)
                    strAntID = ckLine(1)
                    strRSSI = ckLine(2)
                    strTime = ckLine(3)
                Else
                    line = ""
                End If

                If line = "" Then
                    dr = dt.NewRow
                    dr("TagID") = lineTemp
                    dr("AntID") = ""
                    dr("RSSI") = ""
                    dr("Time") = ""
                    dt.Rows.Add(dr)
                Else
                    dr = dt.NewRow
                    dr("TagID") = strTagID
                    dr("AntID") = strAntID
                    dr("RSSI") = strRSSI
                    dr("Time") = strTime
                    dt.Rows.Add(dr)
                End If

            End While


        Catch e As Exception
            'Console.WriteLine("The file could not be read:")
            'Console.WriteLine(e.Message)
        Finally
            sr.Close()
        End Try
        Return dt

    End Function

    Function ReadTextFileModuleAndInsertToTemp(ByVal read_type As String) As Boolean
        Dim strFilePath As String = Application.StartupPath & "\RFID\" & "RFID.txt"
        Dim IsInsert As Boolean = True
        Dim dt As New DataTable
        dt = ReadTextFileModule()

        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

            Try
                Dim Trans As New SqlTransactionDB
                Trans.CreateTransaction()
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim tagrfid As String = dt.Rows(i).Item("TagID") & ""
                    Dim tbreq As New TbRequisitionDAL
                    Dim dtReq As New DataTable
                    Dim dtTemp As New DataTable
                    If tagrfid <> "" Then

                        dtReq = tbreq.GetListBySql("Select App_No From TB_REQUISTION WHERE App_No='" & tagrfid & "'", "", Trans.Trans)
                        If dtReq.Rows.Count = 0 Then
                            Continue For
                        End If
                        dtTemp = tbreq.GetListBySql("Select tag_id From TMP_GATE_READER_TAG WHERE  tag_id='" & tagrfid & "'", "", Trans.Trans)
                        If dtTemp.Rows.Count > 0 Then
                            Continue For
                        End If

                        Dim tmp As New TmpGateReaderTagDAL
                        tmp.READER_ID = GetReaderId()
                        tmp.TAG_ID = tagrfid
                        tmp.READ_TYPE = read_type
                        tmp.CREATEBY = "DESKTOP"
                        Dim a = tmp.InsertData("DESKTOP", Trans.Trans)
                    End If

                Next
                Trans.CommitTransaction()
            Catch ex As Exception
                IsInsert = False
            End Try

            Return IsInsert
        End If
    End Function

    Public Shared Function GetReaderId() As String
        Dim ini As New IniReader(INIFlieName)
        ini.Section = "SETTING"
        If Dir(INIFlieName) <> "" Then
            Return ini.ReadString("ReaderId") & ""
        Else
            Return "0"
        End If
    End Function

    Public Shared Function GetModuleRead() As String
        Dim ini As New IniReader(INIFlieName)
        ini.Section = "SETTING"
        If Dir(INIFlieName) <> "" Then
            Return ini.ReadString("RF_ModuleRead") & ""
        Else
            Return "0"
        End If
    End Function

    Public Shared Function GetIsBox()
        Dim ini As New IniReader(INIFlieName)
        ini.Section = "SETTING"
        If Dir(INIFlieName) <> "" Then
            Return Val(ini.ReadString("IsBox") & "")
        Else
            Return "0"
        End If
    End Function

    Function ReadTextFileCount(ByVal strFilePath As String) As DataTable
        If File.Exists(strFilePath) = False Then
            Return New DataTable
        End If

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("APP_NO", GetType(String))) '------------รหัส แฟ้ม----------
        dt.Columns.Add(New DataColumn("LOCATION", GetType(String))) '--------------ชื่อ สถานที่---------
        dt.Columns.Add(New DataColumn("readerid", GetType(String))) '--------------ID สถานที่---------
        dt.Columns.Add(New DataColumn("borrow_id", GetType(String))) '--------------ชื่อ ผู่---------
        dt.Columns.Add(New DataColumn("borrow_name", GetType(String))) '--------------ID สถานที่---------

        Dim dr As DataRow
        Dim line, lineTemp As String
        Dim ckLine As String()
        Dim Valueappno, Valuelocation, Valuelocationid, ValueborrowId, Valueborrow_name As String
        Dim sr As New StreamReader(strFilePath, System.Text.Encoding.GetEncoding(874))
        Try
            ' Dim sr As New StreamReader(strFilePath)
            While (sr.Peek() > -1)
                lineTemp = sr.ReadLine
                ckLine = lineTemp.Split(",") 'app_no/location
                If ckLine.Length > 0 Then
                    Valueappno = ckLine(0)
                    Valuelocationid = ckLine(1)
                    ValueborrowId = ckLine(2)
                    Valueborrow_name = ckLine(3)
                    Select Case ckLine(1)
                        Case 1
                            Valuelocation = "ห้องแฟ้มชั้น6"
                        Case 2
                            Valuelocation = "ห้องแฟ้มชั้น1A"
                        Case 3
                            Valuelocation = "ห้องแฟ้มชั้น1B"
                        Case 4
                            Valuelocation = "ห้องแฟ้มชั้น 9"
                        Case 6
                            Valuelocation = "ห้องแฟ้มชั้น10"
                        Case 7
                            Valuelocation = "ห้องแฟ้มชั้น12"
                    End Select
                End If

                dr = dt.NewRow
                dr("APP_NO") = Valueappno
                dr("LOCATION") = Valuelocation
                dr("readerid") = Valuelocationid
                dr("borrow_id") = ValueborrowId
                dr("borrow_name") = Valueborrow_name
                dt.Rows.Add(dr)


            End While


        Catch e As Exception
            'Console.WriteLine("The file could not be read:")
            'Console.WriteLine(e.Message)
        Finally
            sr.Close()
        End Try
        Return dt

    End Function

    Function ReadTextFileMove(ByVal strFilePath As String) As DataTable
        If File.Exists(strFilePath) = False Then
            Return New DataTable
        End If
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("app_no", GetType(String))) '------------รหัส แฟ้ม----------
        dt.Columns.Add(New DataColumn("found", GetType(String))) '--------------ID สถานที่---------

        Dim dr As DataRow
        Dim line, lineTemp As String
        Dim ckLine As String()
        Dim ValueAppno, ValueFound As String
        Dim sr As New StreamReader(strFilePath)
        Try
            ' Dim sr As New StreamReader(strFilePath)
            While (sr.Peek() > -1)
                lineTemp = sr.ReadLine
                ckLine = lineTemp.Split(",") 'app_no/location
                If ckLine.Length > 0 Then
                    ValueAppno = ckLine(0)
                    ValueFound = ckLine(1)
                End If

                dr = dt.NewRow
                dr("app_no") = ValueAppno
                dr("found") = ValueFound
                dt.Rows.Add(dr)


            End While


        Catch e As Exception
            'Console.WriteLine("The file could not be read:")
            'Console.WriteLine(e.Message)
        Finally
            sr.Close()
        End Try
        Return dt

    End Function

    Function ReadTextFileDeliverSign(ByVal strFilePath As String) As DataTable
        If File.Exists(strFilePath) = False Then
            Return New DataTable
        End If
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("fileborrow_code", GetType(String))) '------------เลขที่ใบยืม----------
        dt.Columns.Add(New DataColumn("sign_date", GetType(String))) '--------------วันที่ เวลาที่ ลงชื่อรับ---------

        Dim dr As DataRow
        Dim lineTemp As String
        Dim ckLine As String()
        Dim sr As New StreamReader(strFilePath)
        Try
            While (sr.Peek() > -1)
                lineTemp = sr.ReadLine
                ckLine = lineTemp.Split("|") 'fileborrow_code/sign_date
                If ckLine.Length = 2 Then
                    dr = dt.NewRow
                    dr("fileborrow_code") = ckLine(0)
                    dr("sign_date") = ckLine(1)
                    dt.Rows.Add(dr)
                End If
            End While
        Catch e As Exception

        Finally
            sr.Close()
        End Try

        Return dt
    End Function
End Class
