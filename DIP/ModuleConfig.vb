Imports System.Data.SqlClient
Imports DIP_RFID.DAL.Common.Utilities

Module ModuleConfig

    Public INIFlieName As String = "C:\Windows\DIP.ini"
    Public IPINNOVA As String = "[" & ServerName() & "]." '"[192.168.180.75]."
    Public Function CheckConn(ByVal ConnectionString As String) As Boolean
        Dim Conn As New SqlConnection
        Try
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
            Conn.ConnectionString = ConnectionString
            Conn.Open()
            Conn.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function FixDate(ByVal StringDate As String) As String
        Dim d As String = ""
        Dim m As String = ""
        Dim y As String = ""
        If IsDate(StringDate) Then
            Dim dmy As Date = CDate(StringDate)
            d = dmy.Day
            m = dmy.Month
            y = dmy.Year
            If y > 2500 Then
                y = y - 543
            End If
            Return y.ToString & m.ToString.PadLeft(2, "0") & d.ToString.PadLeft(2, "0")
        Else
            Return ""
        End If
    End Function

    Public Function DateNowCondition() As String
        Dim d As String = ""
        Dim m As String = ""
        Dim y As String = ""
        Dim dmy As Date = Date.Now
        d = dmy.Day
        m = dmy.Month
        y = dmy.Year
        If y < 2500 Then
            y = y + 543
        End If
        Return d.ToString.PadLeft(2, "0") & "/" & m.ToString.PadLeft(2, "0") & "/" & y.ToString
    End Function

    Public Function ServerName() As String
        Dim ini As New IniReader(INIFlieName)
        ini.Section = "SETTING"
        If ini.ReadString("LinkServer") & "" <> "" Then
            Return ini.ReadString("LinkServer") & ""
        Else
            Return ""
        End If
    End Function

    Public Function GetRoomInfo(ByVal LocationID As String) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select fc.ms_room_id, r.room_name "
            sql += " from TB_FILELOCATION fc "
            sql += " inner join MS_ROOM r on r.id=fc.ms_room_id"
            sql += " where fc.id='" & LocationID & "'"
            ret = SqlDB.ExecuteTable(sql)
            If ret.Rows.Count > 0 Then
                For i As Integer = 0 To ret.Rows.Count - 1
                    If Convert.IsDBNull(ret.Rows(i)("ms_room_id")) = True Then
                        ret.Rows(i)("ms_room_id") = 0
                        ret.Rows(i)("room_name") = ""
                    End If
                Next
            End If
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

End Module
