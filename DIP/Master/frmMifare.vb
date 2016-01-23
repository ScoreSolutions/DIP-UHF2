Imports DIP_RFID.DAL.Common.Utilities
Imports System.IO.Ports

Public Class frmMifare

    Public EventOpenProgram As Boolean = False
    Public ButtonClick As Boolean = False

    Private Sub frmMifare_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If EventOpenProgram = True Then
            If ButtonClick = False Then
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub frmMifare_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Dim myComPort As New SerialPort
            For i As Int32 = 0 To My.Computer.Ports.SerialPortNames.Count - 1
                cbComport.Items.Add(My.Computer.Ports.SerialPortNames(i))
            Next
        Catch ex As Exception
            'Case ที่ไม่มี Comport ใดเปิดใช้งานอยู่เลย จึง Add Port Com1 เข้าไปก่อน
            cbComport.Items.Add("COM1")
        End Try

        Dim ini As New IniReader(INIFlieName)
        ini.Section = "SETTING"
        If Dir(INIFlieName) <> "" Then
            cbComport.SelectedIndex = cbComport.FindString("COM" & ini.ReadString("MF_ComPort"))
            cbRaudRate.SelectedIndex = cbRaudRate.FindString(ini.ReadString("MF_BaudRate"))
        Else
            cbComport.SelectedIndex = 0
            cbRaudRate.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim ini As New IniReader(INIFlieName)
            ini.Section = "SETTING"
            ini.Write("MF_ComPort", cbComport.SelectedItem.ToString.Replace("COM", ""))
            ini.Write("MF_BaudRate", cbRaudRate.SelectedItem.ToString)
            If EventOpenProgram = False Then
                MsgBox("บันทึกข้อมูลเรียบร้อย")
            End If
        Catch ex As Exception

        End Try
        
        ButtonClick = True
        Me.Close()
    End Sub
End Class