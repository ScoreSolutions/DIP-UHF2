
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.Common.Utilities
Imports ReaderB
Imports System.IO.Ports

Public Class frmGateConsole

    Dim _err As String = ""
    Private fComAdr As Byte = &HFF
    Private fBaud As Byte
    Private frmcomportindex As Integer
    Private fOpenComIndex As Integer
    Private fCmdRet As Integer = 30
    'Dim Alarm_NoOff As Boolean = False
    'Dim Alarm_Status As Boolean = False

    Private Sub SetGridview(ByVal dr As DataRow)
        If DataGridView1.Rows.Count > 0 Then
            Dim haveData As Boolean = False
            For Each gr As DataGridViewRow In DataGridView1.Rows
                If gr.Cells("app_no").Value = dr("app_no") Then
                    haveData = True
                End If
            Next
            If haveData = False Then
                DataGridView1.Rows.Add(1)
                Dim ggr As DataGridViewRow
                ggr = DataGridView1.Rows(DataGridView1.RowCount - 1)
                ggr.Cells("rowno").Value = DataGridView1.RowCount
                ggr.Cells("timestamp").Value = dr("timestamp")
                ggr.Cells("app_no").Value = dr("app_no")
            End If
        Else
            DataGridView1.Rows.Add(1)
            Dim ggr As DataGridViewRow
            ggr = DataGridView1.Rows(DataGridView1.RowCount - 1)
            ggr.Cells("rowno").Value = 1
            ggr.Cells("timestamp").Value = dr("timestamp")
            ggr.Cells("app_no").Value = dr("app_no")
        End If
    End Sub
    Private Sub frmGateConsole_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        CloseGateComport()
        CloseAlarmComport()
    End Sub
    Private Sub frmGateConsole_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cbOnOff.Checked = False
        cbAlarmStatus.Checked = False
        OpenGateComport()
        'OpenAlarmComport()
    End Sub
    Private Sub OpenGateComport()
        Dim port As Integer = 0
        Dim openresult, i As Integer
        openresult = 30
        Dim temp As String
        Cursor = Cursors.WaitCursor

        fComAdr = Convert.ToByte("FF", 16)

        Try
            port = 3       'Com port number
            For i = 6 To 0 Step -1
                fBaud = Convert.ToByte(i)
                If fBaud = 3 Then
                    Continue For
                End If
                'frmcomportindex = 3
                openresult = StaticClassReaderB.OpenComPort(port, fComAdr, fBaud, frmcomportindex)
                fOpenComIndex = frmcomportindex
                If openresult = 0 Then
                    'MsgBox("Comport Open")
                    Timer1.Enabled = True
                    Label1.Text = "Comport : OPEN"
                    Exit Sub
                Else
                    Timer1.Enabled = False
                    StaticClassReaderB.CloseSpecComPort(frmcomportindex)
                    'MsgBox("Serial Communication Error")
                    'Return
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

        '*************** New ****************
        If Label1.Text = "Comport : CLOSE" Then
            Try
                StaticClassReaderB.OpenComPort(3, fComAdr, fBaud, frmcomportindex)
                Timer1.Enabled = True
                Label1.Text = "Comport : OPEN"

            Catch ex As Exception
                Timer1.Enabled = False
                StaticClassReaderB.CloseSpecComPort(frmcomportindex)
                Label1.Text = "Comport : CLOSE"
            End Try
        End If
        '************************************
        
    End Sub
    Private Sub OpenAlarmComport()
        Try
            If SerialPort1.IsOpen = False Then
                SerialPort1.Open()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CloseAlarmComport()
        Try
            If SerialPort1.IsOpen = True Then
                SerialPort1.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CloseGateComport()
        Dim port As Integer = 3
        Try
            fCmdRet = StaticClassReaderB.CloseSpecComPort(port)
            If fCmdRet = 0 Then
                'Comport Closed
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnOpenComport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenComport.Click
        CloseGateComport()
        OpenGateComport()
    End Sub
    Private Sub btnReadGate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadGate.Click
        Dim gc As New GateConsoles
        Dim dtg As New DataTable
        dtg.Columns.Add("timestamp")
        dtg.Columns.Add("app_no")
        dtg.Columns.Add("tmp2")
        dtg.Columns.Add("tmp3")
        dtg = gc.GetConsole(dtg, fComAdr, frmcomportindex)
        If dtg IsNot Nothing And dtg.Rows.Count > 0 Then
            For Each dtr As DataRow In dtg.Rows
                SetGridview(dtr)
            Next
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub btnAlarmON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlarmON.Click
        OpenAlarmComport()
        Try
            If SerialPort1.IsOpen = True Then
                SerialPort1.Write("ON" & Chr(&HD))
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnAlarmOFF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlarmOFF.Click
        Try
            If SerialPort1.IsOpen = True Then
                SerialPort1.Write("OFF" & Chr(&HD))
            End If
        Catch ex As Exception

        End Try
        CloseAlarmComport()
        'Timer1.Enabled = False
    End Sub


    Dim gc As New GateConsoles


    

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim trans As New SqlTransactionDB
            trans.CreateTransaction()
            Dim isAlarm As Boolean = False
            Dim dal As New TbSetAlarmDAL
            If dal.ChkDataByid(1, trans.Trans) = True Then

                If dal.SETALARM = "N" Then
                    cbOnOff.Checked = False
                    'SetGateAlarmOFF()
                    'CloseAlarmComport()
                    'DataGridView1.Rows.Clear()
                End If

                Dim dt As New DataTable
                dt.Columns.Add("timestamp")
                dt.Columns.Add("app_no")
                dt.Columns.Add("tmp2")
                dt.Columns.Add("tmp3")

                dt = gc.GetConsole(dt, fComAdr, frmcomportindex)   'รายการแฟ้มทั้งหมดใน Console

                If dt IsNot Nothing Then
                    If dt.Rows.Count > 0 Then
                        DataGridView1.AutoGenerateColumns = False

                        For Each dr As DataRow In dt.Rows
                            SetGridview(dr)
                            Dim transLog As New SqlTransactionDB
                            transLog.CreateTransaction()
                            Dim ret As Boolean = True
                            Dim log As New TbGateConsoleLogDAL
                            Dim dtLog As DataTable = log.GetDataList("convert(varchar(10),timestamp,103)= convert(varchar(10),getdate(),103) and app_no = '" & dr("app_no") & "'", "", transLog.Trans)
                            If dtLog.Rows.Count > 0 Then
                                log.GetDataByid(dtLog.Rows(0)("id").ToString, transLog.Trans)
                                log.APP_NO = dr("app_no")
                                log.TIMESTAMP = DateTime.Now
                                log.ALARM_DISABLE_TIME = New Date(1, 1, 1)
                                log.ISALARM = "N"
                                ret = log.UpdateByid("GATE_CONSOLE", transLog.Trans)
                            Else
                                log.APP_NO = dr("app_no")
                                log.TIMESTAMP = DateTime.Now
                                log.ISALARM = "N"
                                ret = log.InsertData("GATE_CONSOLE", transLog.Trans)
                            End If

                            If ret = True Then
                                Dim tmp As New TmpFileborrowItemDAL
                                Dim chkAppNo As Boolean = True
                                chkAppNo = tmp.ChkDataByAPP_NO(dr("app_no"), transLog.Trans)
                                If chkAppNo = False Then   'ถ้ารายการใน Console เป็นรายการที่ไม่ได้ยืม
                                    log.ISALARM = "Y"
                                    log.UpdateByid("GATE_CONSOLE", transLog.Trans)
                                    isAlarm = True
                                End If
                                transLog.CommitTransaction()
                            Else
                                transLog.RollbackTransaction()
                                Exit For
                            End If
                        Next

                        If isAlarm = True Then
                            dal.SETALARM = "Y"
                            If dal.UpdateByid("GATE_CONSOLE", trans.Trans) = True Then
                                trans.CommitTransaction()
                                cbOnOff.Checked = True
                                'OpenAlarmComport()
                                'SetGateAlarmON()
                            Else
                                trans.RollbackTransaction()
                            End If
                        Else
                            trans.RollbackTransaction()
                        End If
                    End If
                End If


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetGateAlarmON()
        Try
            If SerialPort1.IsOpen = True Then
                If cbAlarmStatus.Checked = False Then
                    SerialPort1.Write("ON" & Chr(&HD))
                    cbAlarmStatus.Checked = True
                End If
            End If
        Catch ex As Exception
            cbAlarmStatus.Checked = False
        End Try
   
    End Sub

    Private Sub SetGateAlarmOFF()
        Try
            If SerialPort1.IsOpen = True Then
                If cbAlarmStatus.Checked = True Then
                    SerialPort1.Write("OFF" & Chr(&HD))
                    cbOnOff.Checked = False
                    cbAlarmStatus.Checked = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If cbOnOff.Checked = True Then
            OpenAlarmComport()
            SetGateAlarmON()
        Else
            SetGateAlarmOFF()
            CloseAlarmComport()
            DataGridView1.Rows.Clear()
        End If
    End Sub

End Class
