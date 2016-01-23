Imports System.Text
Imports ReaderB
Imports DIP_RFID.DAL.Table

Namespace Common.Utilities
    Public Class GateConsoles

        Dim _err As String = ""
        'Private IF2TagCount As Integer
        Dim fIsInventoryScan As Boolean
        Private fCmdRet As Integer = 30
        'Private fComAdr As Byte = &HFF
        'Private frmcomportindex As Integer
        Private fInventory_EPC_List As String

        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property

        'Dim dt As New DataTable

        Public Function GetConsole(ByVal dt As DataTable, ByVal fComAdr As Byte, ByVal frmcomportindex As Integer) As DataTable

            For i As Integer = 0 To 10
                'dt = Inventory(fComAdr, frmcomportindex)
                Inventory(dt, fComAdr, frmcomportindex)
            Next

            Return dt
        End Function

        Private Sub Inventory(ByVal dt As DataTable, ByVal fComAdr As Byte, ByVal frmcomportindex As Integer) 'As DataTable
            Try
                Dim i As Integer
                Dim CardNum As Integer = 0
                Dim Totallen As Integer = 0
                Dim EPClen, m As Integer
                Dim EPC(5000) As Byte
                Dim CardIndex As Integer
                Dim temps As String
                Dim s, sEPC As String
                Dim isonlistview As Boolean
                Dim MaskMem As Byte = 0
                Dim MaskAdr(2) As Byte
                Dim MaskLen As Byte = 0
                Dim MaskData(100) As Byte
                Dim MaskFlag As Byte = 0
                Dim Ant As Byte = 0
                Dim antstr As String = ""
                fIsInventoryScan = True
                MaskFlag = 0  'Disable
                MaskMem = 1   'EPC
                MaskAdr = HexStringToByteArray("0000")
                MaskLen = Convert.ToByte("00")
                MaskData = HexStringToByteArray("00")
                Dim drItem As DataRow
                fCmdRet = StaticClassReaderB.Inventory_G2(fComAdr, MaskMem, MaskAdr, MaskLen, MaskData, MaskFlag, EPC, Ant, Totallen, CardNum, frmcomportindex)
                If ((fCmdRet = 1) Or (fCmdRet = 2) Or (fCmdRet = 3) Or (fCmdRet = 4) Or (fCmdRet = &HFB)) Then
                    Dim daw(Totallen) As Byte
                    Array.Copy(EPC, daw, Totallen)
                    temps = ByteArrayToHexString(daw)
                    fInventory_EPC_List = temps
                    m = 0
                    If CardNum = 0 Then
                        fIsInventoryScan = False
                        'Return dt
                        Exit Sub
                    End If
                    antstr = Convert.ToString(Ant, 2)
                    For CardIndex = 0 To CardNum - 1
                        EPClen = daw(m)
                        temps = Replace(temps, " ", "")
                        sEPC = temps.Substring((m * 2) + 2, EPClen * 2)
                        m = m + EPClen + 1
                        If sEPC.Length <> EPClen * 2 Then
                            'Return dt
                            Exit Sub
                        End If
                        isonlistview = False


                        If isonlistview = False Then
                            Dim AppNo As String = GetAppNoFromGate(sEPC)
                            Dim rqDal As New TbRequisitionDAL
                            'If rqDal.ChkDataByAPP_NO(AppNo, Nothing) = True Then
                            'If rqDal.ChkDataFromGete("APP_NO = '" & AppNo & "' ", Nothing) = True Then
                            If IsNumeric(AppNo) = True Then
                                'dt.DefaultView.RowFilter = "app_no = '" & AppNo & "'"
                                'If dt.DefaultView.Count = 0 Then  'ถ้ามีข้อมูลอยู่แล้วก็ไม่ต้องแสดงซ้ำ
                                drItem = dt.NewRow
                                drItem("timestamp") = Today.Now
                                drItem("app_no") = GetAppNoFromGate(sEPC)
                                dt.Rows.Add(drItem)
                                'End If
                            End If
                        End If

                    Next
                Else

                End If
            Catch ex As Exception
                'Return dt
            End Try
            'Return dt
        End Sub

        Private Function GetAppNoFromGate(ByVal vAppNo As String) As String
            'เอา RFID ที่อ่านได้ ไปหา APP_NO
            Dim ret As String
            Dim strNo As String = ""
            'Dim intNo As Integer = 0
            strNo = Left(vAppNo.Replace(" ", ""), 12)
            'intno = cint(strno)
            'strno = intno.tostring
            'intNo = CInt(Left(vAppNo.Replace(" ", ""), 2))
            'If intNo = 0 Then
            '    ret = strNo.Substring(2, 10)
            'Else

            'End If
            ret = Left(strNo.Replace(" ", ""), 10)

            Return ret
        End Function

        Private Sub ChangeSubItem(ByVal dr As DataRow, ByVal subItemIndex As Integer, ByVal ItemText As String)
            If subItemIndex = 1 Then
                If ItemText = "" Then  'ถ้าเป็นค่าใหม่ที่ไม่เคยอ่านเจอ
                    dr.Item(subItemIndex) = ItemText
                    'If dr.Item(subItemIndex + 3).ToString = "" Then
                    '    dr.Item(subItemIndex + 3) = "1"
                    'Else
                    '    dr.Item(subItemIndex + 3) = Convert.ToString(Convert.ToInt32(dr.Item(subItemIndex + 3)) + 1)
                    'End If
                ElseIf dr.Item(subItemIndex).ToString <> ItemText Then
                    dr.Item(subItemIndex) = ItemText
                    'dr.Item(subItemIndex + 3) = "1"
                Else
                    'dr.Item(subItemIndex + 3) = Convert.ToString(Convert.ToInt32(dr.Item(subItemIndex + 3).Text) + 1)
                    'If Convert.ToUInt32(dr.Item(subItemIndex + 3).Text) > 9999 Then
                    '    dr.Item(subItemIndex + 3) = "1"
                    'End If
                End If
            End If
            If subItemIndex = 2 Then
                If dr.Item(subItemIndex) <> ItemText Then
                    dr.Item(subItemIndex) = ItemText
                End If
            End If
            If subItemIndex = 3 Then
                If dr.Item(subItemIndex).ToString = "" Then
                    dr.Item(subItemIndex) = ItemText
                Else
                    dr.Item(subItemIndex) = Convert.ToString(Convert.ToInt32(dr.Item(subItemIndex).Text, 2) Or Convert.ToInt32(ItemText, 2), 2)
                End If
            End If
        End Sub

        

        'Public Function checkIF2DataCRC(ByVal cmd() As Byte) As Boolean
        '    ' Dim s(17) As Byte
        '    Dim crcL, crcH As Byte
        '    Dim i As Integer
        '    If cmd.Length < 5 Then
        '        Return False
        '    End If
        '    Dim data1(cmd.Length - 3) As Byte
        '    For i = 0 To cmd.Length - 3
        '        data1(i) = cmd(i)
        '    Next i
        '    If Not getCRC(data1, crcL, crcH) Then
        '        Return False
        '    End If
        '    If crcH <> CByte(cmd(cmd.Length - 1)) Then
        '        Return False
        '    End If
        '    If crcL <> CByte(cmd(cmd.Length - 2)) Then
        '        Return False
        '    End If
        '    Return True
        'End Function

        'Public Function getCRC(ByVal s() As Byte, ByRef crcL As Byte, ByRef crcH As Byte) As Boolean
        '    Dim i, j As Integer
        '    Dim current_crc_value As Integer
        '    'Dim IngText As Long
        '    Dim data(s.Length - 1) As Byte
        '    current_crc_value = &HFFFF
        '    For i = 0 To (s.Length - 1)
        '        data(i) = s(i)
        '        current_crc_value = current_crc_value Xor Val(data(i))
        '        For j = 0 To 7
        '            If ((current_crc_value And &H1) <> 0) Then
        '                current_crc_value = (current_crc_value >> 1) Xor &H8408
        '            Else
        '                current_crc_value = (current_crc_value >> 1)
        '            End If
        '        Next j
        '    Next i
        '    crcL = (current_crc_value And &HFF)
        '    crcH = ((current_crc_value >> 8) And &HFF)

        '    Return True
        'End Function

        'private byte[] HexStringToByteArray(string s)
        '{
        '    s = s.Replace(" ", "");
        '    byte[] buffer = new byte[s.Length / 2];
        '    for (int i = 0; i < s.Length; i += 2)
        '        buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
        '    return buffer;
        '}

        Private Function HexStringToByteArray(ByVal s As String) As Byte()
            s = s.Replace(" ", "")
            Dim buffer((s.Length / 2) - 1) As Byte
            For i As Integer = 0 To s.Length - 1 Step 2
                buffer(i / 2) = CByte(Convert.ToByte(s.Substring(i, 2), 16))
            Next
            Return buffer
        End Function



        Public Function ByteArrayToHexString(ByVal data() As Byte) As String
            Dim sb As New StringBuilder(data.Length * 3)
            Dim b As Byte
            For Each b In data
                sb.Append(Convert.ToString(b, 16).PadLeft(2, "0").PadRight(3, " "))
            Next

            Return sb.ToString().ToUpper()
        End Function
    End Class
End Namespace