Imports DbAgent.Org.Mentalis.Files
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data
Imports System.Threading


Public Class frmDBA

    Sub uplog(ByVal argTXT As String)
        If argTXT.Trim <> "" Then
            If txtLog.Text.Length > 20000 Then
                WriteLogFile(txtLog)
                txtLog.Text = ""
            End If
            txtLog.Text &= Now & vbTab & argTXT & vbCrLf
            txtLog.SelectionStart = Len(txtLog.Text)
            txtLog.ScrollToCaret()
        End If
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        btnStart.Enabled = False
        btnStop.Enabled = True
        ' tlActive.Image = frmMain.imgLst.Images("active")
        statusBar.Text = "Begin Transection..."

       

        If (Not bw7.IsBusy) And chkInclude7.Checked Then
            bw7.RunWorkerAsync()
        End If

        If (Not bw8.IsBusy) And chkInclude8.Checked Then
            bw8.RunWorkerAsync()
        End If

        If (Not bw9.IsBusy) And chkInclude9.Checked Then
            bw9.RunWorkerAsync()
        End If

        If (Not bw10.IsBusy) And chkInclude10.Checked Then
            bw10.RunWorkerAsync()
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

    Private Sub CancelThread()
        If Not bw7.CancellationPending Then
            Try
                bw7.CancelAsync()
            Catch ex As Exception

            End Try
        End If

        If Not bw8.CancellationPending Then
            Try
                bw8.CancelAsync()
            Catch ex As Exception

            End Try
        End If

        If Not bw9.CancellationPending Then
            Try
                bw9.CancelAsync()
            Catch ex As Exception

            End Try
        End If

        If Not bw10.CancellationPending Then
            Try
                bw10.CancelAsync()
            Catch ex As Exception

            End Try
        End If

        ' tlActive.Image = frmMain.imgLst.Images("noActivity")
    End Sub

    Private Sub frmDBA_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        CancelThread()
    End Sub

    Private Sub frmDBA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StrconnInnova = GetConnectionString(1)
        StrconnScore = GetConnectionString(2)
        checkAll(True)
        btnStart_Click(sender, e)
    End Sub

    Private Sub checkAll(Optional ByVal b As Boolean = True)
        chkInclude7.Checked = b
        chkInclude8.Checked = b
        chkInclude9.Checked = b
        chkInclude10.Checked = b
    End Sub

    Private Function isThreadAlive() As Boolean
        Return bw7.IsBusy Or bw8.IsBusy Or bw9.IsBusy Or bw10.IsBusy
    End Function


    Private Sub bw7_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw7.DoWork
        e.Result = Me.backgrounInsertRequisition
    End Sub
    Private Sub bw7_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw7.ProgressChanged
        pg7.Value = e.ProgressPercentage
        lblPct7.Text = pg7.Value & "%"
    End Sub
    Private Sub bw7_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw7.RunWorkerCompleted
        uplog(e.Result)

        pg7.Value = 0
        lblPct7.Text = pg7.Value & "%"
        bw7.Dispose()
        If Not isThreadAlive() Then
            statusBar.Text = "Ready"
            ' tlActive.Image = frmMain.imgLst.Images("noActivity")
        End If
    End Sub
    '==================
    Private Sub bw8_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw8.DoWork
        e.Result = Me.backgrounUpdateRequisition
    End Sub
    Private Sub bw8_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw8.ProgressChanged
        pg8.Value = e.ProgressPercentage
        lblPct8.Text = pg8.Value & "%"
    End Sub
    Private Sub bw8_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw8.RunWorkerCompleted
        uplog(e.Result)

        pg8.Value = 0
        lblPct8.Text = pg8.Value & "%"
        bw8.Dispose()
        If Not isThreadAlive() Then
            statusBar.Text = "Ready"
            'tlActive.Image = frmMain.imgLst.Images("noActivity")
        End If
    End Sub
    '==================
    Private Sub bw9_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw9.DoWork
        e.Result = Me.backgrounInsertFileBorrowItem
    End Sub
    Private Sub bw9_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw9.ProgressChanged
        pg9.Value = e.ProgressPercentage
        lblPct9.Text = pg9.Value & "%"
    End Sub
    Private Sub bw9_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw9.RunWorkerCompleted
        uplog(e.Result)

        pg9.Value = 0
        lblPct9.Text = pg9.Value & "%"
        bw9.Dispose()
        If Not isThreadAlive() Then
            statusBar.Text = "Ready"
            ' tlActive.Image = frmMain.imgLst.Images("noActivity")
        End If
    End Sub
    '==================
    Private Sub bw10_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw10.DoWork
        e.Result = Me.backgrounUpdateFileBorrowItem
    End Sub
    Private Sub bw10_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw10.ProgressChanged
        pg10.Value = e.ProgressPercentage
        lblPct10.Text = pg10.Value & "%"
    End Sub
    Private Sub bw10_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw10.RunWorkerCompleted
        uplog(e.Result)

        pg10.Value = 0
        lblPct10.Text = pg10.Value & "%"
        bw10.Dispose()
        If Not isThreadAlive() Then
            statusBar.Text = "Ready"
            ' tlActive.Image = frmMain.imgLst.Images("noActivity")
        End If
    End Sub
    '==================
    Private Sub chkCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'checkAll(chkCheckAll.Checked)
    End Sub

    Private Sub chkInclude_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInclude7.CheckedChanged, chkInclude8.CheckedChanged, chkInclude9.CheckedChanged, chkInclude10.CheckedChanged
        Dim Obj As CheckBox = sender
        'chkCheckAll.Checked = chkInclude1.Checked And chkInclude3.Checked 'And chkInclude3.Checked

        '------------Update ini--------------
        Dim ini As New IniReader(INIfName)
        ini.Section = "SETTING"
        Dim ObjNo As Integer = Int(Val(Replace(Obj.Name, "chkInclude", "")))
        ini.Write("worker" & ObjNo, Math.Abs(CInt(Obj.Checked)))
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtLog.Text = ""
    End Sub

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


    Private Function backgrounInsertRequisition() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim tmpc As New Color
        tmpc = lblTask7.ForeColor
        lblTask7.ForeColor = Color.Red

        Dim yy2 As String = Date.Now.Year.ToString.Substring(2, 2)
        Dim yy1 As String = CStr(CInt(yy2) - 1).PadLeft(2, "0")
        Dim yy3 As String = CStr(CInt(yy2) + 1).PadLeft(2, "0")
        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct app_no,[app_name],patent_type_id from TB_REQUISTION where app_no like '" & yy1 & "%' or app_no like '" & yy2 & "%' or app_no like '" & yy3 & "%'"
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

        If bw7.CancellationPending Then
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
                   
                    sql = "insert into TB_REQUISTION(id,app_no,[app_name],patent_type_id,qty,createby,createon) values('" & NewId & "','" & dtTemp.Rows(i).Item("app_no") & "',"
                    If Not IsDBNull(dtTemp.Rows(i).Item("app_name")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("app_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("patent_type_id")) Then sql &= "'" & dtTemp.Rows(i).Item("patent_type_id").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "1,'DbAgent',getdate())"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If

                    NewId += 1
                    cnt += 1
                    bw7.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
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

        lblTask7.ForeColor = Color.DarkBlue
        tmpc = Nothing
        Return "[New Requisition.]" & vbTab & txtStatus

    End Function

    Private Function backgrounUpdateRequisition() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim tmpc As New Color
        tmpc = lblTask8.ForeColor
        lblTask8.ForeColor = Color.Red

        Dim txtStatus As String = ""
        Dim yy2 As String = Date.Now.Year.ToString.Substring(2, 2)
        Dim yy1 As String = CStr(CInt(yy2) - 1).PadLeft(2, "0")
        Dim yy3 As String = CStr(CInt(yy2) + 1).PadLeft(2, "0")

        Dim sqlScore As String = "select distinct app_no,[app_name],patent_type_id from TB_REQUISTION where app_no like '" & yy1 & "%' or app_no like '" & yy2 & "%' or app_no like '" & yy3 & "%'"
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

        If bw8.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Update ***************
        dtCompare.DefaultView.RowFilter = "app_no_Second is not null and app_name <> app_name_Second and patent_type_id <> patent_type_id_Second"
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
                    sql &= "patent_type_id = " & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("patent_type_id")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("patent_type_id").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "updateby = 'DbAgent',updateon = getdate() where app_no = '" & dtTemp.Rows(i).Item("app_no") & "'"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If

                    NewId += 1
                    cnt += 1
                    bw8.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
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

        lblTask8.ForeColor = Color.DarkBlue
        tmpc = Nothing
        Return "[Update Requisition.]" & vbTab & txtStatus

    End Function

    Private Function backgrounInsertFileBorrowItem() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim tmpc As New Color
        tmpc = lblTask9.ForeColor
        lblTask9.ForeColor = Color.Red
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

        If bw9.CancellationPending Then
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
                    bw9.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
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

        lblTask9.ForeColor = Color.DarkBlue
        tmpc = Nothing
        Return "[New FileBorrowItem.]" & vbTab & txtStatus

    End Function

    Private Function backgrounUpdateFileBorrowItem() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim tmpc As New Color
        tmpc = lblTask10.ForeColor
        lblTask10.ForeColor = Color.Red
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

        If bw10.CancellationPending Then
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
                    bw10.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
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

        lblTask10.ForeColor = Color.DarkBlue
        tmpc = Nothing
        Return "[Update FileBorrowItem.]" & txtStatus

    End Function

    Private Sub CheckExit(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw7.RunWorkerCompleted, bw8.RunWorkerCompleted, bw9.RunWorkerCompleted, bw10.RunWorkerCompleted
        If Not (bw7.IsBusy) And Not (bw8.IsBusy) And Not (bw9.IsBusy) And Not (bw10.IsBusy) Then
            'Application.Exit()
        End If
    End Sub

End Class