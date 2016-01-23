Imports DIP_RFID.DAL.Common.Utilities
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL
Imports System.IO.Ports

Public Class frmAlarm

    Dim api As New RfidApiLib.RfidApi
    Public TagCnt As Integer = 0
    Dim ReadMinute As Integer = Func.GetSetupValue("RFID_Read_Minute", Nothing)
    Dim ReadTime As Double
    Dim dt_RFID As DataTable

    Private Sub frmAlarm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ClearAlarm()
        api.CloseCommPort()
        frmMain.Visible = True
        frmMain.tmrChkAlarm.Enabled = True
        frmMain.Focus()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        For Each gr As DataGridViewRow In DataGridView1.Rows
            ClearConsole(gr.Cells("id").Value)
        Next
        ClearAlarm()
        DataGridView1.DataSource = Nothing
        Me.Close()
    End Sub

    Private Sub ClearAlarm()
        Dim trans As New SqlTransactionDB
        trans.CreateTransaction()
        Dim dal As New TbSetAlarmDAL
        dal.GetDataByid(ReadBarcodeFromTextFile.GetReaderId, trans.Trans)
        'dal.GetDataByid(1, trans.Trans)
        dal.SETALARM = "N"
        If dal.UpdateByid(frmMain.txtUserName.Text.Trim, trans.Trans) = True Then
            trans.CommitTransaction()
        Else
            trans.RollbackTransaction()
        End If
        DataGridView1.DataSource = Nothing
    End Sub

    Private Sub OpenReaderComport()
        Dim ini As New IniReader(INIFlieName)
        ini.Section = "SETTING"

        'Read RFID
        api.OpenCommPort(Trim("COM" + ini.ReadString("CR_ComPort")))
        api.ClearIdBuf()
        TagCnt = 0
        ReadTime = 0
        dt_RFID = New DataTable
        dt_RFID.Columns.Add("APP_NO")
        dt_RFID.Columns.Add("APP_NO10")
    End Sub

    Private Sub ClearConsole(ByVal LogID As String)
        'อัพเดทข้อมูลการแจ้ง Alarm ที่ส่งมาจาก Console
        Dim trans As New SqlTransactionDB
        trans.CreateTransaction()
        Dim dal As New TbGateConsoleLogDAL
        dal.GetDataByid(LogID, trans.Trans)
        If dal.HaveData = True Then
            dal.ISALARM = "N"
            dal.ALARM_DISABLE_TIME = DateTime.Now
            dal.READERID = ReadBarcodeFromTextFile.GetReaderId
            If dal.UpdateByid(frmMain.txtUserName.Text, trans.Trans) = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'For Mifare Reader
        Dim ini As New IniReader(INIFlieName)
        ini.Section = "SETTING"

        Dim ctl As New MifareControl
        Dim port As Int32 = ini.ReadString("MF_ComPort")
        Dim bund As Int32 = ini.ReadString("MF_BaudRate")
        If ctl.Connect(port, bund) = True Then
            Dim act As MifareControl.ActivityStatus
            act = ctl.SelectTag()

            If act.Available = True Then
                Dim dal As New TbOfficerDAL
                dal.GetDataByMIFARE_CARD_ID(act.Result, Nothing)
                If dal.HaveData = True Then
                    For Each gr As DataGridViewRow In DataGridView1.Rows
                        ClearConsole(gr.Cells("id").Value)
                    Next
                    DataGridView1.DataSource = Nothing
                    Me.Close()
                Else
                    txtMsg.Visible = True
                    txtMsg.Text = "ไม่พบข้อมูลผู้ใช้"
                End If
            End If
            ctl.DisConnect()
        End If

        'For RFID Reader
        Dim rfid As New RFIDReader
        Dim dt As New DataTable
        'dt.Columns.Add("app_no")
        dt = rfid.ReadRFID(dt_RFID, api)
        If dt.Rows.Count > 0 Then
            Dim GridDT As DataTable = DataGridView1.DataSource
            For i As Integer = DataGridView1.Rows.Count - 1 To 0 Step -1
                With DataGridView1
                    Dim gr As DataGridViewRow = .Rows(i)

                    dt.DefaultView.RowFilter = "app_no10 = '" & gr.Cells("app_no").Value & "'"
                    If dt.DefaultView.Count > 0 Then
                        ClearConsole(GridDT.Rows(i)("id"))
                        'GridDT.Rows.RemoveAt(i)
                    End If
                End With
            Next
            'If DataGridView1.RowCount = 0 Then
            '    Me.Close()
            'End If
        End If
    End Sub

    Private Sub frmAlarm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Read RFID
        OpenReaderComport()

        'สั่งให้ Timer ทำงาน
        Timer1.Enabled = True
    End Sub

    Private Sub frmAlarm_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        'SetGridView()
    End Sub

    Public Sub SetGridView()
        Dim lDal As New TbGateConsoleLogDAL
        Dim dt As DataTable = lDal.GetDataList("isalarm='Y' and alarm_disable_time is null And Readerid=" & ReadBarcodeFromTextFile.GetReaderId, "app_no", Nothing)   'ค่าที่ได้มากจาก Gate
        DataGridView1.AutoGenerateColumns = False
        If dt.Rows.Count > 0 Then
            DataGridView1.DataSource = dt
        Else
            Me.Close()
            'DataGridView1.DataSource = Nothing
        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        SetGridView()
    End Sub

    Private Function GetAppNoNotBorrow() As DataTable
        Return SqlDB.ExecuteTable("Select id,app_no FROM dbo.TB_GATE_CONSOLE_LOG where ISALARM='Y' And Reader_id=" & ReadBarcodeFromTextFile.GetReaderId)
    End Function
End Class