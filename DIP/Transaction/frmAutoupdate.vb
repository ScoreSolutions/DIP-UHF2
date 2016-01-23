Imports DbAgent.Org.Mentalis.Files
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data
Imports System.Threading
Imports DIP_RFID.DAL.Table


Public Class frmAutoupdate

    Private Sub CancelThread()
        If Not bw1.CancellationPending Then
            Try
                bw1.CancelAsync()
            Catch ex As Exception

            End Try
        End If
        ' tlActive.Image = frmMain.imgLst.Images("noActivity")
    End Sub

    Private Sub frmDBA_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        CancelThread()
    End Sub

    Private Sub frmDBA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CenterToParent()

        StrconnInnova = GetConnectionString(1)
        StrconnScore = GetConnectionString(2)
        btnStart_Click(sender, e)
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        btnStart.Enabled = False
        btnStop.Enabled = True
        ' tlActive.Image = frmMain.imgLst.Images("active")
        statusBar.Text = "Begin Transection..."
        If (Not bw1.IsBusy) Then
            bw1.RunWorkerAsync()
        End If
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        Dim ini As New IniReader(INIfName)
        CancelThread()
        ini.Section = "SETTING"
        ini.Write("state", "0")
        btnStart.Enabled = True
        btnStop.Enabled = False
    End Sub



    Private Function isThreadAlive() As Boolean
        Return bw1.IsBusy
    End Function



    Private Sub bw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw1.DoWork
        e.Result = Me.backgrounInsertStatus
        statusBar.Text = e.Result
        e.Result = Me.backgrounUpdateStatus
        statusBar.Text = e.Result
        e.Result = Me.backgrounInsertFileLocation
        statusBar.Text = e.Result
        e.Result = Me.backgrounUpdateFileLocation
        statusBar.Text = e.Result
        e.Result = Me.backgrounInsertFileStore
        statusBar.Text = e.Result
        e.Result = Me.backgrounUpdateFileStore
        statusBar.Text = e.Result
        e.Result = Me.backgrounInsertPosition
        statusBar.Text = e.Result
        e.Result = Me.backgrounUpdatePosition
        statusBar.Text = e.Result
        e.Result = Me.backgrounInsertDepartment
        statusBar.Text = e.Result
        e.Result = Me.backgrounUpdateDepartment
        statusBar.Text = e.Result
        e.Result = Me.backgrounInsertOfficer
        statusBar.Text = e.Result
        e.Result = Me.backgrounUpdateOfficer
        statusBar.Text = e.Result
        e.Result = Me.backgrounInsertRequisition
        statusBar.Text = e.Result
        e.Result = Me.backgrounUpdateRequisition
        statusBar.Text = e.Result
        e.Result = Me.backgrounInsertFileBorrowItem
        statusBar.Text = e.Result
        e.Result = Me.backgrounUpdateFileBorrowItem
        statusBar.Text = e.Result
    End Sub
    Private Sub bw1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw1.ProgressChanged
        pg1.Value = e.ProgressPercentage
        lblPct1.Text = pg1.Value & "%"
    End Sub
    Private Sub bw1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw1.RunWorkerCompleted

        pg1.Value = 0
        lblPct1.Text = pg1.Value & "%"
        bw1.Dispose()
        If Not isThreadAlive() Then
            statusBar.Text = "Ready"
            'tlActive.Image = frmMain.imgLst.Images("noActivity")
        End If
    End Sub
    '==================
    'Private Sub chkInclude_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInclude7.CheckedChanged, chkInclude8.CheckedChanged, chkInclude9.CheckedChanged, chkInclude10.CheckedChanged
    '    Dim Obj As CheckBox = sender
    '    'chkCheckAll.Checked = chkInclude1.Checked And chkInclude3.Checked 'And chkInclude3.Checked

    '    '------------Update ini--------------
    '    Dim ini As New IniReader(INIfName)
    '    ini.Section = "SETTING"
    '    Dim ObjNo As Integer = Int(Val(Replace(Obj.Name, "chkInclude", "")))
    '    ini.Write("worker" & ObjNo, Math.Abs(CInt(Obj.Checked)))
    'End Sub



    Function GetNewId(ByVal TbName As String, ByVal FieldName As String) As Int64
        Dim NewId As Int64
        Dim Conn As New SqlConnection
        Dim sql As String = ""
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        Conn.ConnectionString = StrconnScore
        Conn.Open()
        sql = "select isnull(max(" & FieldName & ") + 1,1) as NewId from " & TbName
        da = New SqlDataAdapter(sql, StrconnScore)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            NewId = dt.Rows(0).Item("NewId").ToString
        Else
            NewId = 1
        End If
        Conn.Dispose()
        Return NewId
    End Function

    Function GetIdAPP_NO(ByVal APP_NO As String) As Int64
        Dim NewId As Int64 = 0
        Dim Conn As New SqlConnection
        Dim sql As String = ""
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        Conn.ConnectionString = StrconnScore
        Conn.Open()
        sql = "select ID from TB_REQUISTION where rtrim(ltrim(app_no)) = '" & Trim(APP_NO) & "'"
        da = New SqlDataAdapter(sql, StrconnScore)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            NewId = dt.Rows(0).Item("ID").ToString
        End If
        Conn.Dispose()
        Return NewId
    End Function

    Function CheckStatusFile(ByVal APP_NO As String) As Boolean
        Dim ret As Boolean = False
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim sql As String = ""
        sql = "EXEC CHECKFILESTATUS " & APP_NO
        da = New SqlDataAdapter(sql, StrconnScore)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            ret = True
        End If
        Return ret
    End Function

#Region "ConnectDatabase"

    Public Structure EXESQL
        Dim STATUS As Boolean
        Dim EX As String
    End Structure

    Public Function executeSQL(ByVal sql As String) As EXESQL
        ' Try
        Dim Conn As New SqlConnection(StrconnScore)
        Try
            Conn.Open()
        Catch ex As Exception
            executeSQL.EX = ex.Message
            executeSQL.STATUS = False
        End Try

        If sql.Trim <> "" Then
            Dim cmd As New SqlCommand(sql)
            cmd.Connection = Conn
            Try
                cmd.ExecuteNonQuery()
                executeSQL.STATUS = True
                executeSQL.EX = ""
            Catch ex As Exception
                executeSQL.STATUS = False
                executeSQL.EX = ex.Message
            End Try
        Else
            executeSQL.STATUS = False
            executeSQL.EX = "EMPTY SQL!"
        End If
        Conn.Close()
        Conn.Dispose()
    End Function

#End Region

    Private Function backgrounInsertPosition() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as position_code,position_name from TB_POSITION"
        Dim sqlInnova As String = "exec POSITION"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "position_code", "position_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Insert ***************
        dtCompare.DefaultView.RowFilter = "position_code_Second is null"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " New Position."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0

            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "insert into TB_POSITION(id,position_code,position_name,createby,createon) values('" & dtTemp.Rows(i).Item("position_code").ToString & "','" & dtTemp.Rows(i).Item("position_code").ToString & "',"
                    If Not IsDBNull(dtTemp.Rows(i).Item("position_name")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("position_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "'DbAgent',getdate())"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        '' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        Return "[New Position.]" & vbTab & vbTab & txtStatus
    End Function

    Private Function backgrounUpdatePosition() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as position_code,position_name from TB_POSITION"
        Dim sqlInnova As String = "exec POSITION"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "position_code", "position_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Update ***************
        dtCompare.DefaultView.RowFilter = "isnull(position_name_Second,'') <> '' and position_name <> position_name_Second"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " Update Position."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0

            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "update TB_POSITION set "
                    sql &= "position_name = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("position_name")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("position_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "updateby = 'DbAgent',updateon = getdate() where id ='" & dtTemp.Rows(i).Item("position_code").ToString & "'"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        '' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        Return "[Update Position.]" & vbTab & txtStatus
    End Function

    Private Function backgrounInsertDepartment() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as department_code,department_name from TB_DEPARTMENT"
        Dim sqlInnova As String = "exec WORKGROUP"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "department_code", "department_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Insert ***************
        dtCompare.DefaultView.RowFilter = "department_code_Second is null"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " New Department."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "insert into TB_DEPARTMENT(id,department_code,department_name,createby,createon) values('" & dtTemp.Rows(i).Item("department_code").ToString & "','" & dtTemp.Rows(i).Item("department_code").ToString & "',"
                    If Not IsDBNull(dtTemp.Rows(i).Item("department_name")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("department_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "'DbAgent',getdate())"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        Return "[New Department.]" & vbTab & txtStatus

    End Function

    Private Function backgrounUpdateDepartment() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as department_code,department_name from TB_DEPARTMENT"
        Dim sqlInnova As String = "exec WORKGROUP"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "department_code", "department_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Update ***************
        dtCompare.DefaultView.RowFilter = "department_code_Second is not null and department_name <> department_name_Second"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " Update Department."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "update TB_DEPARTMENT set "
                    sql &= "department_name = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("department_name")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("department_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "updateby = 'DbAgent',updateon = getdate() where id ='" & dtTemp.Rows(i).Item("department_code").ToString & "'"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        Return "[Update Department.]" & vbTab & txtStatus

    End Function

    Private Function backgrounInsertOfficer() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal


        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as officer_no,title_id,fname,lname,department_id,position_id  from TB_OFFICER"
        Dim sqlInnova As String = "exec OFFICER"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "officer_no", "officer_no")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Insert ***************
        dtCompare.DefaultView.RowFilter = "officer_no_Second is null"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " New Officer."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "insert into TB_OFFICER(id,officer_no,fname,lname,department_id,position_id,title_id,createby,createon) values('" & dtTemp.Rows(i).Item("officer_no").ToString & "','" & dtTemp.Rows(i).Item("officer_no").ToString & "',"
                    If Not IsDBNull(dtTemp.Rows(i).Item("fname")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("fname").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("lname")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("lname").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("department_id")) Then sql &= "'" & dtTemp.Rows(i).Item("department_id").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("position_id")) Then sql &= "'" & dtTemp.Rows(i).Item("position_id").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("title_id")) Then sql &= "'" & dtTemp.Rows(i).Item("title_id").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "'DbAgent',getdate())"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        Return "[New Officer.]" & vbTab & vbTab & txtStatus

    End Function

    Private Function backgrounUpdateOfficer() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as officer_no,title_id,fname,lname,department_id,position_id  from TB_OFFICER"
        Dim sqlInnova As String = "exec OFFICER"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "officer_no", "officer_no")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Update ***************
        dtCompare.DefaultView.RowFilter = "officer_no_Second is not null and ((fname <> fname_second) or (lname <> lname_second) or (title_id <> title_id_second) or (department_id <> department_id_second) or (position_id <> position_id_second))"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " Update Officer."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "update TB_OFFICER set fname = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("fname")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("fname").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "lname = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("lname")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("lname").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "department_id = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("department_id")) Then sql &= "'" & dtTemp.Rows(i).Item("department_id").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "position_id = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("position_id")) Then sql &= "'" & dtTemp.Rows(i).Item("position_id").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "title_id = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("title_id")) Then sql &= "'" & dtTemp.Rows(i).Item("title_id").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "updateby = 'DbAgent',updateon = getdate() where id = '" & dtTemp.Rows(i).Item("officer_no").ToString & "'"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        Return "[Updeat Officer.]" & vbTab & txtStatus

    End Function


    Private Function backgrounInsertRequisition() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim tmpc As New Color


        Dim yy2 As String = Date.Now.Year.ToString.Substring(2, 2)
        Dim yy1 As String = CStr(CInt(yy2) - 1).PadLeft(2, "0")
        Dim yy3 As String = CStr(CInt(yy2) + 1).PadLeft(2, "0")
        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct app_no,[app_name],patent_type_id,app_status from TB_REQUISTION where app_no like '" & yy1 & "%' or app_no like '" & yy2 & "%' or app_no like '" & yy3 & "%'"
        Dim sqlInnova As String = "exec REQUISITION '" & yy1 & "','" & yy2 & "','" & yy3 & "'"
        'Dim sqlScore As String = "select distinct app_no,[app_name],patent_type_id from TB_REQUISTION"
        'Dim sqlInnova As String = "exec REQUISITION NULL,NULL"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
            Dim cmd As New SqlCommand(sql)
            cmd.Connection = ConnScore
            cmd.CommandTimeout = 10000
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        'ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "app_no", "app_no")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Insert ***************
        dtCompare.DefaultView.RowFilter = "app_no_Second is null"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " New Requisition."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            Dim NewId As Int64 = 0
            NewId = GetNewId("TB_REQUISTION", "id")

            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try

                    sql = "insert into TB_REQUISTION(id,app_no,[app_name],app_status,patent_type_id,qty,createby,createon) values('" & NewId & "','" & dtTemp.Rows(i).Item("app_no") & "',"
                    If Not IsDBNull(dtTemp.Rows(i).Item("app_name")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("app_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("app_status")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("app_status").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("patent_type_id")) Then sql &= "'" & dtTemp.Rows(i).Item("patent_type_id").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "1,'DbAgent',getdate())"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If

                    NewId += 1
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        'If Not isThreadAlive() Then tlActive.Image = frmMain.imgLst.Images("noActivity")

        tmpc = Nothing
        Return "[New Requisition.]" & vbTab & txtStatus

    End Function

    Private Function backgrounUpdateRequisition() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim txtStatus As String = ""
        Dim yy2 As String = Date.Now.Year.ToString.Substring(2, 2)
        Dim yy1 As String = CStr(CInt(yy2) - 1).PadLeft(2, "0")
        Dim yy3 As String = CStr(CInt(yy2) + 1).PadLeft(2, "0")

        Dim sqlScore As String = "select distinct app_no,[app_name],patent_type_id,app_status from TB_REQUISTION where app_no like '" & yy1 & "%' or app_no like '" & yy2 & "%' or app_no like '" & yy3 & "%'"
        Dim sqlInnova As String = "exec REQUISITION '" & yy1 & "','" & yy2 & "','" & yy3 & "'"
        'Dim sqlScore As String = "select distinct app_no,[app_name],patent_type_id from TB_REQUISTION"
        'Dim sqlInnova As String = "exec REQUISITION NULL,NULL,NULL"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "app_no", "app_no")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Update ***************
        dtCompare.DefaultView.RowFilter = "app_no_Second is not null AND app_name <> app_name_Second AND patent_type_id <> patent_type_id_Second AND app_status <> app_status_Second"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " Update Requisition."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            Dim NewId As Int64 = 0

            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try

                    sql = "update TB_REQUISTION set app_name = " & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("app_name")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("app_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "app_status = " & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("app_status")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("app_status").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "patent_type_id = " & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("patent_type_id")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("patent_type_id").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "updateby = 'DbAgent',updateon = getdate() where app_no = '" & dtTemp.Rows(i).Item("app_no") & "'"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If

                    NewId += 1
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        ' If Not isThreadAlive() Then tlActive.Image = frmMain.imgLst.Images("noActivity")

        Return "[Update Requisition.]" & vbTab & txtStatus

    End Function

    Private Function backgrounInsertFileBorrowItem() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim txtStatus As String = ""
        'Dim sqlScore As String = "select distinct ref_innova_id as ID from TB_RESERVE where datediff(d,reserve_date,getdate()) = 0"
        'Dim sqlInnova As String = "exec FILEBORROWITEM " & fixDate(Date.Now)
        Dim sqlScore As String = "select distinct ref_innova_id as ID from TB_RESERVE"
        Dim sqlInnova As String = "exec FILEBORROWITEM NULL"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "ID", "ID")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Insert ***************
        dtCompare.DefaultView.RowFilter = "ID_Second is null"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " New FileBorrowItem."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            Dim NewId As Int64 = 0
            Dim AppNoId As Int64 = 0

            NewId = GetNewId("TB_RESERVE", "id")

            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    AppNoId = GetIdAPP_NO(dtTemp.Rows(i).Item("app_no").ToString.Trim)

                    sql = "insert into TB_RESERVE(id,requidition_id,ref_innova_id,reserve_date,member_id,member_name,borrowstatus,reserve_order,reserve_status,createby,createon) values('" & NewId & "','" & AppNoId & "',"
                    If Not IsDBNull(dtTemp.Rows(i).Item("ID")) Then sql &= "'" & dtTemp.Rows(i).Item("ID").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("create_date")) Then sql &= "'" & fixDateTime(dtTemp.Rows(i).Item("create_date").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("member_id")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("member_id").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("member_name")) Then sql &= "'" & dtTemp.Rows(i).Item("member_name").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("borrowstatus")) Then sql &= "'" & dtTemp.Rows(i).Item("borrowstatus").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("reserve_order")) Then sql &= "'" & dtTemp.Rows(i).Item("reserve_order").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If CheckStatusFile(dtTemp.Rows(i).Item("app_no").ToString.Trim) = True Then
                        sql &= "'N',"
                    Else
                        sql &= "'Y',"
                    End If
                    sql &= "'DbAgent',getdate())"
                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If

                    NewId += 1
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        ' If Not isThreadAlive() Then tlActive.Image = frmMain.imgLst.Images("noActivity")


        Return "[New FileBorrowItem.]" & vbTab & txtStatus

    End Function

    Private Function backgrounUpdateFileBorrowItem() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal


        Dim txtStatus As String = ""
        'Dim sqlScore As String = "select distinct ref_innova_id as ID,reserve_date,member_id,member_name,borrowstatus,CONVERT(varchar(8),reserve_date,112) as CreateDate,CONVERT(varchar(8),reserve_date,114) as CreateTime  from TB_RESERVE where datediff(d,reserve_date,getdate()) = 0"
        'Dim sqlInnova As String = "exec FILEBORROWITEM " & fixDate(Date.Now)
        Dim sqlScore As String = "select distinct ref_innova_id as ID,reserve_date,member_id,member_name,borrowstatus,CONVERT(varchar(8),reserve_date,112) as CreateDate,CONVERT(varchar(8),reserve_date,114) as CreateTime from TB_RESERVE"
        Dim sqlInnova As String = "exec FILEBORROWITEM NULL"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "ID", "ID")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Update ***************
        dtCompare.DefaultView.RowFilter = "ID_Second is not null and ((trim(borrowstatus) <> trim(borrowstatus_second)) or (trim(borrowstatus) <> trim(borrowstatus_second)) or (trim(member_name) <> trim(member_name_second)) or (member_id <> member_id_second) or (trim(CreateDate) <> trim(CreateDate_second)) or (trim(CreateTime) <> trim(CreateTime_second)))"

        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " Update FileBorrowItem."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            Dim AppNoId As Int64 = 0

            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    AppNoId = GetIdAPP_NO(dtTemp.Rows(i).Item("app_no").ToString)
                    sql = "update TB_RESERVE set requidition_id = '" & AppNoId & "'," & vbNewLine
                    sql &= "reserve_date = " & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("create_date")) Then sql &= "'" & fixDateTime(dtTemp.Rows(i).Item("create_date").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "member_id = " & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("member_id")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("member_id").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "member_name = " & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("member_name")) Then sql &= "'" & dtTemp.Rows(i).Item("member_name").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "borrowstatus = " & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("borrowstatus")) Then sql &= "'" & dtTemp.Rows(i).Item("borrowstatus").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "updateby = 'DbAgent',updateon = getdate() where ref_innova_id = '" & dtTemp.Rows(i).Item("ID").ToString & "'"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If

                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        'If Not isThreadAlive() Then tlActive.Image = frmMain.imgLst.Images("noActivity")


        Return "[Update FileBorrowItem.]" & txtStatus

    End Function


    Private Function backgrounInsertStatus() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as status_code,status_name,description from TB_STATUS"
        Dim sqlInnova As String = "exec [STATUS]"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "status_code", "status_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Insert ***************
        dtCompare.DefaultView.RowFilter = "status_code_Second is null"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " New Status."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "insert into TB_STATUS(id,status_name,description,createby,createon) values('" & dtTemp.Rows(i).Item("status_code").ToString & "','" & dtTemp.Rows(i).Item("status_name").ToString & "','" & dtTemp.Rows(i).Item("description").ToString & "',"
                    sql &= "'DbAgent',getdate())"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        Return "[New Status.]" & vbTab & txtStatus

    End Function

    Private Function backgrounUpdateStatus() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as status_code,status_name,description from TB_STATUS"
        Dim sqlInnova As String = "exec [STATUS]"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "status_code", "status_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Update ***************
        dtCompare.DefaultView.RowFilter = "status_code_Second is not null AND status_name <> status_name_Second AND description <> description_Second"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " Update Status."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "update TB_STATUS set "
                    sql &= "status_name = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("status_name")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("status_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "description = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("description")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("description").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "updateby = 'DbAgent',updateon = getdate() where id ='" & dtTemp.Rows(i).Item("status_code").ToString & "'"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        Return "[Update Status.]" & vbTab & txtStatus

    End Function

    Private Function backgrounInsertFileLocation() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as location_code,location_name,description from TB_FILELOCATION"
        Dim sqlInnova As String = "exec [FILELOCATION]"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "location_code", "location_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Insert ***************
        dtCompare.DefaultView.RowFilter = "location_code_Second is null"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " New FileLocation."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "insert into TB_FILELOCATION(id,location_name,description,createby,createon) values('" & dtTemp.Rows(i).Item("location_code").ToString & "','" & dtTemp.Rows(i).Item("location_name").ToString & "','" & dtTemp.Rows(i).Item("description").ToString & "',"
                    sql &= "'DbAgent',getdate())"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        Return "[New FileLocation.]" & vbTab & txtStatus

    End Function

    Private Function backgrounUpdateFileLocation() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as location_code,location_name,description from TB_FILELOCATION"
        Dim sqlInnova As String = "exec [FILELOCATION]"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "location_code", "location_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Update ***************
        dtCompare.DefaultView.RowFilter = "location_code_Second is not null AND location_name <> location_name_Second AND description <> description_Second"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " Update FileLocation."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "update TB_FILELOCATION set "
                    sql &= "location_name = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("location_name")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("location_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "description = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("description")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("description").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "updateby = 'DbAgent',updateon = getdate() where id ='" & dtTemp.Rows(i).Item("location_code").ToString & "'"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        Return "[Update FileLocation.]" & vbTab & txtStatus

    End Function

    Private Function backgrounInsertFileStore() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as filestore_code,app_no,filelocation from TB_FILESTORE"
        Dim sqlInnova As String = "exec [FILESTORE]"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "filestore_code", "filestore_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Insert ***************
        dtCompare.DefaultView.RowFilter = "filestore_code_Second is null"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " New FileStore"
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "insert into tb_filestore(id,app_no,filelocation,createby,createon) values('" & dtTemp.Rows(i).Item("filestore_code").ToString & "','" & dtTemp.Rows(i).Item("app_no").ToString & "','" & dtTemp.Rows(i).Item("filelocation").ToString & "',"
                    sql &= "'DbAgent',getdate())"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        Return "[New FileStore.]" & vbTab & txtStatus

    End Function

    Private Function backgrounUpdateFileStore() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as filestore_code,app_no,filelocation from TB_FILESTORE"
        Dim sqlInnova As String = "exec [FILESTORE]"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "filestore_code", "filestore_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Update ***************
        dtCompare.DefaultView.RowFilter = "filestore_code_Second is not null AND filelocation <> filelocation_Second"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " Update FileStore."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "update tb_filestore set "
                    'sql &= "app_no = "
                    'If Not IsDBNull(dtTemp.Rows(i).Item("app_no")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("app_no").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "filelocation = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("filelocation")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("filelocation").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "updateby = 'DbAgent',updateon = getdate() where id ='" & dtTemp.Rows(i).Item("filestore_code").ToString & "'"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        Return "[Update FileStore.]" & vbTab & txtStatus

    End Function

    Private Sub CheckExit(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw1.RunWorkerCompleted
        If Not (bw1.IsBusy) Then
            'Application.Exit()
            'Me.Close
            CloseAllForm()
            IsUpdateActionModule(1)
            Dim frmReserve As New frmReserve
            ShowForm(frmReserve)
        End If
    End Sub

    Function IsUpdateActionModule(ByVal Type As String) As Boolean
        Dim IsUpdate As Boolean = True
        Try
            Dim Trans As New DIP_RFID.DAL.Common.Utilities.SqlTransactionDB
            Trans.CreateTransaction()
            Dim dal As New TbSetModuleDAL
            dal.GetDataByID("1", Trans.Trans)
            dal.SETACTION = Type
            dal.UpdateByPK(frmMain.txtIdUser.Text, Trans.Trans)

            Trans.CommitTransaction()
        Catch ex As Exception
            IsUpdate = False
        End Try

        Return IsUpdate
    End Function

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
End Class