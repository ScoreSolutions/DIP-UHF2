Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.Common.Utilities
Imports RfidApiLib

Public Class TestReader

    Dim dt As DataTable
    Dim rea As RFIDReader

    Dim api As New RfidApi
    Public TagCnt As Integer = 0
    Dim ReadMinute As Integer = Func.GetSetupValue("RFID_Read_Minute", Nothing)
    Dim ReadTime As Double

    
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim rea As New RFIDReader
        DataGridView1.DataSource = rea.ReadRFID(dt, api)




        ReadTime += Timer1.Interval
        If ReadTime / 1000 >= ReadMinute Then
            api.CloseCommPort()
            txtIsRead.Text = "0"
            Timer1.Enabled = False
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'If txtIsRead.Text = "0" Then
        'txtIsRead.Text = "1"
        api.OpenCommPort("COM1")
        api.ClearIdBuf()
        TagCnt = 0
        ReadTime = 0

        dt = New DataTable
        dt.Columns.Add("APP_NO")
        Timer1.Enabled = True
        'DataGridView1.DataSource = ReadRFID(dt)
        'Else
        'api.CloseCommPort()
        'Timer1.Enabled = False
        'txtIsRead.Text = "0"
        'End If
    End Sub
End Class