Imports System.Collections
Module ModuleReport
    Public vrSearchName As String = ""
    Public vrSearchGroup As String = ""
    Public checkOut_Checked As String 'เก็บตัวแปร Checked ยืม
    Public checkInn_checked As String 'เก็บตัวแปร Checked คืน
    Public Valueed As String = ""
    Public graphValueed As String = ""
    Public date_timestart As String 'เก็บตัวแปร DateTimePicker เริ่ม
    Public date_timestop As String 'เก็บตัวแปร DateTimePicker สิ้นสุด
    Public pattened As String = ""
    Public borrowfile As String = ""
    Public returnfile As String = ""

    Public Function dateconvart(ByVal str As String) As String
        Dim datein As String = ""
        Dim d As String = ""
        Dim m As String = ""
        Dim y As String = ""
        datein = Microsoft.VisualBasic.Left(str, 6)
        y = Microsoft.VisualBasic.Left(str, 4)
        m = Microsoft.VisualBasic.Right(datein, 2)
        d = Microsoft.VisualBasic.Right(str, 2)
        datein = d & "/" & m & "/" & y + 543
        Return datein
    End Function
    Public Function monthconvartrp(ByVal str As String) As String
        Dim monthin As String = ""
        Dim m As String = ""
        Dim cm As String = ""
        Dim y As String = ""
        y = Microsoft.VisualBasic.Left(str, 4)
        m = Microsoft.VisualBasic.Right(str, 2)
        Select Case m
            Case "01" : cm = "มกราคม"
            Case "02" : cm = "กุมภาพันธ์"
            Case "03" : cm = "มีนาคม"
            Case "04" : cm = "เมษายน"
            Case "05" : cm = "พฤษภาคม"
            Case "06" : cm = "มิถุนายน"
            Case "07" : cm = "กรกฎาคม"
            Case "08" : cm = "สิงหาคม"
            Case "09" : cm = "กันยายน"
            Case "10" : cm = "ตุลมคม"
            Case "11" : cm = "พฤศจิกายน"
            Case "12" : cm = "ธันวาคม"
        End Select
        monthin = cm & "  " & y + 543
        Return monthin
    End Function
End Module
