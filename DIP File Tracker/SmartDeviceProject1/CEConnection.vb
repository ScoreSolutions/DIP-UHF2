Imports System.Data
Imports System.Data.SqlServerCe
Imports System.Xml

Public Class CEConnection

    Public PDAConnString As String
    Public ServerConnString As String
    Public SQLQuery As String
    Public AgentServiceURL As String
    Public CurrentUsingTables As String ' Split With Comma
    Public TrackingOption As Boolean = False

    Private UsingTable() As String

    Public Sub CreateDataBase()
        Try
            Dim En As New SqlCeEngine
            With En
                .LocalConnectionString = PDAConnString
                .CreateDatabase()
            End With
            'Run Create Table
            En.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub CreateDataBase(ByVal PDAConnection As String)
        PDAConnString = PDAConnection
        CreateDataBase()
    End Sub

    Public Sub ClearUsingTables()
        Try
            While Right(CurrentUsingTables, 1) = ","
                CurrentUsingTables = CurrentUsingTables.Substring(0, CurrentUsingTables.Length - 1)
            End While
            UsingTable = CurrentUsingTables.Split(",")
            Dim i As Integer
            For i = 0 To UsingTable.Length - 1
                DropTable(UsingTable(i))
            Next
        Catch : End Try
    End Sub

    Public Sub ClearUsingTables(ByVal TableNames As String, ByVal PDAConnection As String)
        CurrentUsingTables = TableNames
        PDAConnString = PDAConnection
        ClearUsingTables()
    End Sub

    Private Sub DropTable(ByVal TableName As String)
        Try
            Dim Conn As New System.Data.SqlServerCe.SqlCeConnection(PDAConnString) : Conn.Open()
            Dim Command As New SqlCeCommand
            With Command
                .Connection = Conn
                .CommandType = Data.CommandType.Text
                .CommandText = "Drop Table " & TableName
                .ExecuteNonQuery()
                .Dispose()
            End With
            Conn.Close()
            Conn.Dispose()
        Catch : End Try
    End Sub

    Public Sub PullData()
        CreateDataBase()
        ClearUsingTables()
        Dim RDA As New SqlCeRemoteDataAccess
        With RDA
            .InternetUrl = AgentServiceURL
            .LocalConnectionString = PDAConnString
            .ConnectionRetryTimeout = 25
            If TrackingOption Then
                .Pull(CurrentUsingTables, SQLQuery, ServerConnString, RdaTrackOption.TrackingOn)
            Else
                .Pull(CurrentUsingTables, SQLQuery, ServerConnString)
            End If
            .Dispose()
        End With
    End Sub

    Public Sub PullData(ByVal PDATable As String, ByVal ServerSQLQuery As String, ByVal PDAPath As String, ByVal InternetServiceURL As String, ByVal ServerConnection As String, Optional ByVal Track As Boolean = False)
        CurrentUsingTables = PDATable
        SQLQuery = ServerSQLQuery
        PDAConnString = PDAPath
        AgentServiceURL = InternetServiceURL
        ServerConnString = ServerConnection
        TrackingOption = Track
        PullData()
    End Sub

    Public Function SelectData() As DataTable

        Dim DT As New DataTable
        Dim Conn As New SqlCeConnection(PDAConnString)
        Dim Adaptor As New SqlCeDataAdapter(SQLQuery, Conn)
        DT.Rows.Clear()
        Adaptor.Fill(DT)
        Adaptor.Dispose()
        Conn.Close()
        Conn.Dispose()
        Return DT
    End Function

    Public Function SelectDataFromPulling() As DataTable
        Dim DT As New DataTable
        Dim Conn As New SqlCeConnection(PDAConnString)
        Dim Adaptor As New SqlCeDataAdapter("Select * From " & CurrentUsingTables, Conn)
        DT.Rows.Clear()
        Adaptor.Fill(DT)
        Adaptor.Dispose()
        Conn.Close()
        Conn.Dispose()
        Return DT
    End Function

    Public Function SelectData(ByVal PDASQLQuery As String, ByVal PDAConnection As String) As DataTable
        PDAConnString = PDAConnection
        SQLQuery = PDASQLQuery
        Return SelectData()
    End Function

    Public Sub ExecuteCommandQuery()
        Dim RDA As New SqlCeRemoteDataAccess
        With RDA
            .ConnectionRetryTimeout = 25
            .InternetUrl = AgentServiceURL
            .SubmitSql(SQLQuery, ServerConnString)
            .Dispose()
        End With
    End Sub

    Public Sub ExecuteCommandQuery(ByVal ServerSQLQuery As String, ByVal InternetServiceURL As String, ByVal ServerConnection As String)
        AgentServiceURL = InternetServiceURL
        SQLQuery = ServerSQLQuery
        ServerConnString = ServerConnection
        ExecuteCommandQuery()
    End Sub

    Public Sub ExecuteLocalCommand(ByVal SQLQuery As String, ByVal PDAConnection As String)
        Dim Conn As New SqlCeConnection(PDAConnection)
        Dim Comm As New SqlCeCommand
        Conn.Open()
        With Comm
            .Connection = Conn
            .CommandType = CommandType.Text
            .CommandText = SQLQuery
            .ExecuteNonQuery()
        End With
        Conn.Close()
        Conn.Dispose()
        Comm.Dispose()
    End Sub

End Class
