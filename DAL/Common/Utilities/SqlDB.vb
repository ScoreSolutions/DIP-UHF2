﻿Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports DIP_RFID.Data.Common.Utilities

Namespace Common.Utilities
    Public Class SqlDB

        Protected Shared ErrorConnectionString As String = MessageResources.MSGEC001
        Protected Shared ErrorConnection As String = MessageResources.MSGEC002
        Protected Shared ErrorSetCommandConnection As String = MessageResources.MSGEC003
        Protected Shared ErrorInvalidCommandType As String = MessageResources.MSGEC004
        Protected Shared ErrorDuplicateParameter As String = MessageResources.MSGEC006
        Protected Shared ErrorNullParameter As String = MessageResources.MSGEC005
        Protected Shared ErrorExecuteNonQuery As String = MessageResources.MSGEC010
        Protected Shared ErrorExecuteReader As String = MessageResources.MSGEC011
        Protected Shared ErrorExecuteTable As String = MessageResources.MSGEC012
        Protected Shared ErrorExecuteScalar As String = MessageResources.MSGEC013
        Protected Shared ErrorDatabaseOther As String = MessageResources.MSGEC901
        Protected Shared ErrorUndefined As String = MessageResources.MSGEC902

        Public Shared Function SetDouble(ByVal number As Double) As String
            Return number.ToString()
        End Function
        Public Shared Function SetDecimal(ByVal number As Decimal) As String
            Return number.ToString()
        End Function
        Public Shared Function SetString(ByVal str As String) As String
            Dim ret As String = ""
            If str.Trim() = "" Then
                ret = "NULL"
            Else
                ret = Chr(39) & str.Trim().Replace("'", "''") & Chr(39)
            End If
            Return ret
        End Function
        Public Shared Function SetDate() As String
            Return SetDateTime(DateTime.Today)
        End Function
        Public Function SetDate(ByVal DateIn As DateTime) As String
            Return SetDateTime(DateIn)
        End Function
        Public Shared Function SetDateTime() As String
            Return SetDateTime(DateTime.Today)
        End Function
        Public Shared Function SetDateTime(ByVal DateIn As DateTime) As String
            Dim ret As String = ""
            If DateIn.Year = 1 Then
                ret = "NULL"
            ElseIf DateIn.Year > 2500 Then
                Dim vYear As String = DateIn.Year - 543
                ret = "'" & vYear & "-" & DateIn.ToString("MM-dd HH:mm:ss") & "'"
            Else
                ret = "'" & DateIn.Year & "-" & DateIn.ToString("MM-dd HH:mm:ss") & "'"
            End If
            Return ret
        End Function

        Public Shared Function GetExceptionMessage(ByVal ex As SqlException) As String
            Return String.Format(ErrorDatabaseOther, ex.ErrorCode.ToString(), ex.Message)
        End Function

        'Public Const DataSource As String = "T"
        'Public Const DbName As String = "DIPSQL"
        'Public Const UserID As String = "DIP"
        'Public Const Password As String = "fuwvru"

        Private Shared ReadOnly Property INIFileName() As IniReader
            Get
                Dim INIFlie As String = "C:\Windows\DIP.ini"
                Dim ini As New IniReader(INIFlie)
                ini.Section = "SETTING"
                Return ini
            End Get
        End Property

        Public Shared ReadOnly Property DataSource() As String
            Get
                'Dim INIFlieName As String = "C:\Windows\DIP.ini"
                Dim ini As IniReader = INIFileName
                'ini.Section = "SETTING"
                Return ini.ReadString("Server")
            End Get
        End Property

        Public Shared ReadOnly Property DbName() As String
            Get
                'Dim INIFlieName As String = "C:\Windows\DIP.ini"
                'Dim ini As New IniReader(INIFlieName)
                'ini.Section = "SETTING"
                Dim ini As IniReader = INIFileName
                Return ini.ReadString("Database")
            End Get
        End Property

        Public Shared ReadOnly Property UserID() As String
            Get
                'Dim INIFlieName As String = "C:\Windows\DIP.ini"
                'Dim ini As New IniReader(INIFlieName)
                'ini.Section = "SETTING"
                Dim ini As IniReader = INIFileName
                Return ini.ReadString("Username")
            End Get
        End Property

        Public Shared ReadOnly Property Password() As String
            Get
                'Dim INIFlieName As String = "C:\Windows\DIP.ini"
                'Dim ini As New IniReader(INIFlieName)
                'ini.Section = "SETTING"
                Dim ini As IniReader = INIFileName
                Return ini.ReadString("Password")
            End Get
        End Property

        Protected Shared ReadOnly Property ConnectionString() As String
            Get
                Try
                    'Return "Data Source=AngelMan;Initial Catalog=DIPSQL;User ID=DIP;Password=fuwvru"
                    Return "Data Source=" & DataSource & ";Initial Catalog=" & DbName & ";User ID=" & UserID & ";Password=" & Password
                Catch ex As Exception
                    Throw New ApplicationException(ErrorConnectionString, ex)
                End Try
            End Get
        End Property

        Public Shared Function GetConnection() As SqlConnection
            Dim conn As SqlConnection
            Try
                conn = New SqlConnection(ConnectionString)
                conn.Open()

                Return conn
            Catch ex As Exception
                Throw New ApplicationException(GetExceptionMessage(ex), ex)
            Catch ex As ApplicationException
                Throw ex
            Catch ex As SqlException
                Throw New ApplicationException(ErrorConnection, ex)
            End Try
        End Function

        Public Shared Function GetConnection(ByVal connString As String) As SqlConnection
            Dim conn As SqlConnection
            Try
                conn = New SqlConnection(connString)
                conn.Open()
                Return conn
            Catch ex As Exception
                Throw New ApplicationException(GetExceptionMessage(ex), ex)
            Catch ex As ApplicationException
                Throw ex
            Catch ex As SqlException
                Throw New ApplicationException(ErrorConnection, ex)
            End Try
        End Function

        Public Shared Function ChkConnection() As Boolean
            Dim ret As Boolean = False
            Dim conn As SqlConnection
            Try
                conn = New SqlConnection(ConnectionString)
                conn.Open()

                ret = True
            Catch ex As Exception
                'Throw New ApplicationException(GetExceptionMessage(ex), ex)
                ret = False
            Catch ex As ApplicationException
                'Throw ex
                ret = False
            Catch ex As SqlException
                'Throw New ApplicationException(ErrorConnection, ex)
                ret = False
            End Try

            Return ret
        End Function

        Public Shared Function GetNextID(ByVal fldName As String, ByVal tbName As String, ByVal trans As SqlTransaction) As Long
            Dim ret As Long
            Dim Sql As String = "select max(" & fldName & ") maxID from " & tbName
            Dim dt As DataTable = ExecuteTable(Sql, trans)
            If Convert.IsDBNull(dt.Rows(0)("maxID")) = False Then
                ret = Convert.ToInt64(dt.Rows(0)("maxID").ToString()) + 1
            Else
                ret = 1
            End If

            Return ret
        End Function

        Public Shared Function GetDateNow(ByVal rtType As String, ByVal trans As SqlTransaction) As String
            'rtType = D  ให้คืนค่าเป็นวันที่ในรูปแบบ yyyy-MM-dd
            'rtType = T  ให้คืนค่าเป็นเวลาปัจจุบัน hh:mm
            Dim ret As String
            Dim dt As DataTable = ExecuteTable("select convert(varchar(10),getdate(),120) date_now, CONVERT(varchar(5),getdate(),108) time_now", trans)
            If rtType = "D" Then
                ret = dt.Rows(0)("date_now")
            Else
                ret = dt.Rows(0)("time_now")
            End If

            Return ret

        End Function

        Public Shared Function ExecuteTable(ByVal sql As String) As DataTable
            Return ExecuteTable(sql, Nothing, Nothing)
        End Function
        Public Shared Function ExecuteTable(ByVal sql As String, ByVal conn As SqlConnection) As DataTable
            Return ExecuteTable(sql, conn, Nothing)
        End Function
        Public Shared Function ExecuteTable(ByVal sql As String, ByVal trans As SqlTransaction) As DataTable
            Return ExecuteTable(sql, Nothing, trans)
        End Function
        Public Shared Function ExecuteTable(ByVal sql As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As DataTable
            Dim cmd As New SqlCommand
            Dim adapter As New SqlDataAdapter
            adapter.SelectCommand = cmd

            Dim dt As New DataTable

            Try
                If conn Is Nothing And trans Is Nothing Then
                    conn = New SqlConnection(ConnectionString)
                ElseIf trans IsNot Nothing And conn Is Nothing Then
                    conn = trans.Connection
                End If

                BuildCommand(cmd, conn, trans, CommandType.Text, sql, Nothing)
                adapter.Fill(dt)
                adapter.Dispose()
            Catch ex As ApplicationException
                adapter.Dispose()
                Throw ex
            Catch ex As SqlException
                adapter.Dispose()
                'Throw New ApplicationException(GetExceptionMessage(ex), ex)
            Catch ex As Exception
                adapter.Dispose()
                'Throw New ApplicationException(ErrorExecuteTable, ex)
            End Try

            Return dt
        End Function

        Public Shared Function ExecuteReader(ByVal Sql As String) As SqlDataReader
            Return ExecuteReader(Sql, Nothing, Nothing)
        End Function
        Public Shared Function ExecuteReader(ByVal Sql As String, ByVal trans As SqlTransaction) As SqlDataReader
            Return ExecuteReader(Sql, Nothing, trans)
        End Function

        Public Shared Function ExecuteReader(ByVal Sql As String, ByVal conn As SqlConnection) As SqlDataReader
            Return ExecuteReader(Sql, conn, Nothing)
        End Function

        Public Shared Function ExecuteReader(ByVal Sql As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SqlDataReader
            Dim command As New SqlCommand()
            Dim reader As SqlDataReader
            Dim LetClose As Boolean = False

            Try
                If trans IsNot Nothing And conn Is Nothing Then
                    conn = trans.Connection
                ElseIf conn Is Nothing Then
                    conn = GetConnection()
                    LetClose = True
                End If

                BuildCommand(command, conn, trans, CommandType.Text, Sql, Nothing)
                'reader = IIf(LetClose = True, command.ExecuteReader(CommandBehavior.CloseConnection), command.ExecuteReader())
                reader = command.ExecuteReader()
            Catch ex As ApplicationException
                Throw ex
            Catch ex As SqlException
                Throw New ApplicationException(GetExceptionMessage(ex), ex)
            Catch ex As Exception
                Throw New ApplicationException(ErrorExecuteReader, ex)
            End Try

            Return reader
        End Function


        Public Shared Function ExecuteNonQuery(ByVal Sql As String) As Integer
            Return ExecuteNonQuery(Sql, Nothing, Nothing, Nothing)
        End Function
        Public Shared Function ExecuteNonQuery(ByVal Sql As String, ByVal trans As SqlTransaction, ByVal cmdParms() As SqlParameter) As Integer
            Return ExecuteNonQuery(Sql, Nothing, trans, cmdParms)
        End Function
        Public Shared Function ExecuteNonQuery(ByVal Sql As String, ByVal conn As SqlConnection) As Integer
            Return ExecuteNonQuery(Sql, conn, Nothing, Nothing)
        End Function
        Public Shared Function ExecuteNonQuery(ByVal Sql As String, ByVal trans As SqlTransaction) As Integer
            Return ExecuteNonQuery(Sql, Nothing, trans, Nothing)
        End Function
        Public Shared Function ExecuteNonQuery(ByVal Sql As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal cmdParms() As SqlParameter) As Integer
            Dim retval As Integer
            Dim command As New SqlCommand

            Try
                If trans Is Nothing Then
                    conn = New SqlConnection(ConnectionString)
                    BuildCommand(command, conn, trans, CommandType.Text, Sql, cmdParms)
                    retval = command.ExecuteNonQuery
                Else
                    If trans IsNot Nothing And conn Is Nothing Then
                        conn = trans.Connection
                    End If

                    BuildCommand(command, trans.Connection, trans, CommandType.Text, Sql, cmdParms)
                    retval = command.ExecuteNonQuery
                End If
            Catch ex As ApplicationException
                Throw ex
            Catch ex As SqlException
                Throw New ApplicationException(GetExceptionMessage(ex), ex)
            Catch ex As Exception
                Throw New ApplicationException(ErrorExecuteNonQuery, ex)
            End Try

            Return retval
        End Function

        Private Shared Sub BuildCommand(ByVal cmd As SqlCommand, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal cmdParms() As SqlParameter)
            If conn.State <> ConnectionState.Open Then
                Try
                    conn.Open()
                Catch ex As SqlException
                    Throw New ApplicationException(GetExceptionMessage(ex), ex)
                Catch ex As ApplicationException
                    Throw (ex)
                Catch ex As Exception
                    Throw New ApplicationException(ErrorConnection, ex)
                End Try
            End If

            Try
                cmd.Connection = conn
            Catch ex As Exception
                Throw New ApplicationException(ErrorSetCommandConnection, ex)
            End Try
            cmd.CommandText = cmdText

            If trans IsNot Nothing Then
                cmd.Transaction = trans
            End If

            Try
                cmd.CommandType = cmdType
                cmd.CommandTimeout = 120
            Catch ex As ArgumentException
                Throw New ApplicationException(ErrorInvalidCommandType, ex)
            End Try

            If cmdParms IsNot Nothing Then
                For Each parm As SqlParameter In cmdParms
                    Try
                        cmd.Parameters.Add(parm)
                    Catch ex As ArgumentNullException
                        Throw New ApplicationException(ErrorNullParameter, ex)
                    Catch ex As ArgumentException
                        Throw New ApplicationException(ErrorDuplicateParameter, ex)
                    End Try
                Next
            End If
        End Sub
    End Class
End Namespace

