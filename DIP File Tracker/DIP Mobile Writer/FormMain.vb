
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports com.caen.RFIDLibrary
Imports PsionTeklogix.Trigger
Imports PsionTeklogix.Keyboard
Imports PsionTeklogix.RFID

Public Class FormMain
    Inherits Form

    Private Enum TIMER_RFID_OPERATION
        NONE
        READ
        WRITE
    End Enum
    Private timer_cmd As TIMER_RFID_OPERATION = TIMER_RFID_OPERATION.NONE

#Region "Psion Trigger Members and Functions"

    Private tc As TriggerControl = Nothing
    Const TemporaryClient As String = "CAEN_TRIGGER"

    Private Sub TriggerClose()
        If tc IsNot Nothing Then
            Try
                RemoveHandler tc.triggerEvent, AddressOf OnTriggerEvent
                AddHandler tc.triggerEvent, AddressOf OnTriggerEvent
                tc.DeregisterFromEvents(TemporaryClient)
                tc.DeregisterConsumer(TemporaryClient)
            Catch
            Finally
                tc.Dispose()
                tc = Nothing
            End Try
        End If
    End Sub

    Private Function TriggerInit() As Boolean
        ' Instantiate Trigger Control
        Try
            tc = New TriggerControl()
        Catch
            TriggerClose()
            Return False
        End Try

        ' Initialize Trigger Control
        Try
            tc.Initialize()
        Catch
            TriggerClose()
            Return False
        End Try

        Dim names As New ArrayList()
        Try
            tc.GetRegisteredConsumers(names)
        Catch
            TriggerClose()
            Return False
        End Try

        Dim ConsumerAlreadExist As [Boolean] = False
        For Each s As String In names
            If s.Equals(TemporaryClient) Then
                ConsumerAlreadExist = True
                Exit For
            End If
        Next

        ' Register the temporary trigger event consumer
        If ConsumerAlreadExist = False Then
            Try
                tc.RegisterConsumer(TemporaryClient)
            Catch
                TriggerClose()
                Return False
            End Try
        End If

        Try
            Dim flags As UInteger = (TriggerControl.Flags.Override Or TriggerControl.Flags.Temporary Or TriggerControl.Flags.WantsTriggerEvents)

            tc.AddMapping(0, TemporaryClient, flags)
            tc.AddMapping(Keyboard.TranslateToTriggerID(Key.HandgripScan), TemporaryClient, flags)
            tc.AddMapping(Keyboard.TranslateToTriggerID(Key.Scan), TemporaryClient, flags)
            tc.AddMapping(Keyboard.TranslateToTriggerID(Key.LeftScan), TemporaryClient, flags)
            tc.AddMapping(Keyboard.TranslateToTriggerID(Key.RightScan), TemporaryClient, flags)
            tc.AddMapping(Keyboard.TranslateToTriggerID(Key.SideLeftScan), TemporaryClient, flags)
            tc.AddMapping(Keyboard.TranslateToTriggerID(Key.SideRightScan), TemporaryClient, flags)
        Catch
            TriggerClose()
            Return False
        End Try

        ' Register for events
        Try
            tc.RegisterForEvents(TemporaryClient)
        Catch
            TriggerClose()
            Return False
        End Try

        ' Add delegate
        Try
            RemoveHandler tc.triggerEvent, AddressOf OnTriggerEvent
            AddHandler tc.triggerEvent, AddressOf OnTriggerEvent
        Catch
            TriggerClose()
            Return False
        End Try
        Return True
    End Function

    Private Sub OnTriggerEvent(ByVal sender As Object, ByVal e As TriggerEvent)
        If e.SourceId = Keyboard.TranslateToTriggerID(Key.Scan) Then
            Select Case e.EventFlags
                Case TriggerEvent.TriggerUp
                    timer1.Enabled = False
                    If timer_cmd = TIMER_RFID_OPERATION.READ Then
                        ShowWarning("Unable to READ any tags; Press Center Scan button(s) to Inventory tags")
                    End If
                    Exit Select
                Case TriggerEvent.TriggerDown
                    timer_cmd = TIMER_RFID_OPERATION.READ
                    timer1.Enabled = True
                    textBox2.Text = ""
                    textBox1.Text = ""
                    ShowInProgress("<<< INVENTORY >>>")
                    Exit Select
            End Select
        ElseIf (e.SourceId = Keyboard.TranslateToTriggerID(Key.SideLeftScan)) OrElse (e.SourceId = Keyboard.TranslateToTriggerID(Key.SideRightScan)) Then
            Select Case e.EventFlags
                Case TriggerEvent.TriggerUp
                    timer1.Enabled = False
                    If timer_cmd = TIMER_RFID_OPERATION.WRITE Then
                        ShowWarning("Unable to WRITE to the specified tag")
                    End If
                    textBox2.Text = ""
                    textBox1.Text = ""
                    Exit Select
                Case TriggerEvent.TriggerDown
                    timer_cmd = TIMER_RFID_OPERATION.WRITE
                    timer1.Enabled = True
                    ShowInProgress("<<< WRITE TAG >>>")
                    Exit Select
            End Select
        End If
    End Sub

#End Region

#Region "CAEN SDK Members and Functions"

    Private ComPort As Integer = 1
    Private Reader As CAENRFIDReader = Nothing
    Private m_Source0 As CAENRFIDLogicalSource = Nothing
    Private m_tag As CAENRFIDTag = Nothing
    Private membank_bytes As Short()
    Private rfidDriver As New RFIDDriver()

    Private Sub CAEN_Close()
        If Reader IsNot Nothing Then
            Try
                Reader.Disconnect()
            Catch
            Finally
                Reader.Dispose()
                Reader = Nothing
            End Try
        End If
        Try
            If rfidDriver.IsEnabled Then
                rfidDriver.Disable()
            End If
        Catch
        End Try
    End Sub

    Private Function CAEN_Init() As Boolean
        membank_bytes = New Short(3) {}
        membank_bytes(0) = 8
        ' reserved bank 
        membank_bytes(1) = 12
        ' EPC bank
        membank_bytes(2) = 4
        ' TID bank
        membank_bytes(3) = 2
        ' user bank
        Reader = New CAENRFIDReader()
        Try
            rfidDriver.Enable()

            Reader.Connect(CAENRFIDPort.CAENRFID_RS232, "COM" & rfidDriver.ComPort.ToString() & ":115200")
        Catch
            CAEN_Close()
            Return False
        End Try
        '
        ' You MUST sleep this amount of time before executing other commands
        '
        System.Threading.Thread.Sleep(250)

        Dim logical_sources As CAENRFIDLogicalSource() = Reader.GetSources()
        If logical_sources.Length = 0 Then
            CAEN_Close()
            Return False
        End If
        m_Source0 = logical_sources(0)

        Return True
    End Function

    Private write_call_count As Integer = 0

    Private Function CAEN_Write() As TIMER_RFID_OPERATION
        If m_Source0 Is Nothing Then
            ShowError("FAIL: m_Source0 == null")
            Return TIMER_RFID_OPERATION.NONE
        End If

        Dim address As Short = 0
        If comboBox1.SelectedIndex = 1 Then
            address = 4
        End If
        Dim length As Short = membank_bytes(comboBox1.SelectedIndex)
        Dim data As Byte() = New Byte(length - 1) {}

        Dim string_data As String = textBox1.Text
        For i As Integer = 0 To string_data.Length - 1 Step 2
            data(i \ 2) = [Byte].Parse(string_data.Substring(i, 2), System.Globalization.NumberStyles.HexNumber)
        Next

        write_call_count += 1

        Try
            m_Source0.WriteTagData_EPC_C1G2(m_tag, CShort(comboBox1.SelectedIndex), address, length, data)
            ' it's common for this method to throw exceptions.  Ignore it
        Catch
        End Try

        System.Threading.Thread.Sleep(500)

        '
        ' check the tag
        ' 
        Dim tags As CAENRFIDTag() = Nothing
        Try
            tags = m_Source0.InventoryTag()
        Catch
            ShowError("FAIL: InventoryTag (check): " & write_call_count.ToString())
            write_call_count = 0
            Return TIMER_RFID_OPERATION.NONE
        End Try

        If tags IsNot Nothing Then
            For Each tag As CAENRFIDTag In tags
                Dim IDTag As String = System.BitConverter.ToString(tag.GetId()).Replace("-", "")

                If comboBox1.SelectedIndex = 1 Then
                    If IDTag = textBox1.Text Then
                        ShowSuccess("TAG WRITE SUCCESS: " & write_call_count.ToString())
                        write_call_count = 0
                        Return TIMER_RFID_OPERATION.NONE
                    End If
                ElseIf IDTag = textBox2.Text Then
                    Try
                        Dim read As Byte() = Nothing
                        Dim exData As String = Nothing
                        Select Case comboBox1.SelectedIndex
                            Case 0
                                ' Reserved
                                read = m_Source0.ReadTagData_EPC_C1G2(tag, 0, 0, membank_bytes(comboBox1.SelectedIndex))
                                Exit Select
                            Case 2
                                ' TID
                                read = m_Source0.ReadTagData_EPC_C1G2(tag, 2, 0, membank_bytes(comboBox1.SelectedIndex))
                                Exit Select
                            Case 3
                                ' User
                                read = m_Source0.ReadTagData_EPC_C1G2(tag, 3, 0, membank_bytes(comboBox1.SelectedIndex))
                                Exit Select
                        End Select

                        Select Case comboBox1.SelectedIndex
                            Case 0, 2, 3
                                exData = System.BitConverter.ToString(read).Replace("-", "")
                                Exit Select
                        End Select

                        If exData = textBox1.Text Then
                            ShowSuccess("TAG WRITE SUCCESS: " & write_call_count.ToString())
                            write_call_count = 0
                            Return TIMER_RFID_OPERATION.NONE
                        End If
                    Catch
                        ShowError("FAIL: ReadTagData_EPC_C1G2 (check): " & write_call_count.ToString())
                        write_call_count = 0
                        Return TIMER_RFID_OPERATION.NONE
                    End Try
                End If
            Next
        End If

        Return TIMER_RFID_OPERATION.WRITE
    End Function

    Private Function CAEN_Inventory() As TIMER_RFID_OPERATION
        If m_Source0 Is Nothing Then
            ShowError("FAIL: m_Source0 == null")
            Return TIMER_RFID_OPERATION.NONE
        End If

        Dim tags As CAENRFIDTag() = Nothing
        Try
            tags = m_Source0.InventoryTag()
        Catch
            ShowError("FAIL: InventoryTag")
            Return TIMER_RFID_OPERATION.NONE
        End Try

        If tags IsNot Nothing Then
            For Each tag As CAENRFIDTag In tags
                Dim IDTag As String = System.BitConverter.ToString(tag.GetId()).Replace("-", "")
                textBox2.Text = IDTag

                m_tag = tag

                Try
                    Dim read As Byte() = Nothing
                    Dim exData As String = Nothing
                    Select Case comboBox1.SelectedIndex
                        Case 0
                            ' Reserved
                            read = m_Source0.ReadTagData_EPC_C1G2(tag, 0, 0, membank_bytes(comboBox1.SelectedIndex))
                            Exit Select
                        Case 2
                            ' TID
                            read = m_Source0.ReadTagData_EPC_C1G2(tag, 2, 0, membank_bytes(comboBox1.SelectedIndex))
                            Exit Select
                        Case 3
                            ' User
                            read = m_Source0.ReadTagData_EPC_C1G2(tag, 3, 0, membank_bytes(comboBox1.SelectedIndex))
                            Exit Select
                    End Select

                    Select Case comboBox1.SelectedIndex
                        Case 0, 2, 3
                            exData = System.BitConverter.ToString(read).Replace("-", "")
                            Exit Select
                        Case Else
                            exData = IDTag
                            Exit Select
                    End Select
                    textBox1.Text = exData
                Catch
                    ShowError("FAIL: ReadTagData_EPC_C1G2")
                    Return TIMER_RFID_OPERATION.NONE
                End Try

                '
                ' Just get one tag at a time for this demo
                '
                ShowSuccess("Press SIDE Left or Right button to WRITE tag")

                Return TIMER_RFID_OPERATION.NONE
            Next
        End If

        Return TIMER_RFID_OPERATION.READ
    End Function

#End Region

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If rfidDriver.IsInstalled Then
            If CAEN_Init() Then
                If Not TriggerInit() Then
                    ShowError("FAIL: Trigger Init")
                Else
                    comboBox1.Items.Add("Reserved")
                    comboBox1.Items.Add("EPC")
                    comboBox1.Items.Add("TID")
                    comboBox1.Items.Add("User")

                    comboBox1.SelectedIndex = 0
                End If
            Else
                ShowError("FAIL: CAEN Init")
            End If
        Else
            label1.BackColor = System.Drawing.Color.Red
            label1.Text = "FAIL: RFID Driver not installed"
        End If
    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As CancelEventArgs) Handles Me.Closing
        TriggerClose()
        CAEN_Close()
    End Sub

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        Select Case timer_cmd
            Case TIMER_RFID_OPERATION.READ
                If True Then
                    timer_cmd = CAEN_Inventory()
                End If
                Exit Select
            Case TIMER_RFID_OPERATION.WRITE
                If True Then
                    timer_cmd = CAEN_Write()
                End If
                Exit Select
            Case TIMER_RFID_OPERATION.NONE
                Exit Select
        End Select
    End Sub

    Private Sub ShowError(ByVal message As String)
        status.BackColor = System.Drawing.Color.Red
        status.Text = message
    End Sub
    Private Sub ShowSuccess(ByVal message As String)
        status.BackColor = System.Drawing.Color.LightGreen
        status.Text = message
    End Sub
    Private Sub ShowInProgress(ByVal message As String)
        status.BackColor = System.Drawing.Color.Yellow
        status.Text = message
    End Sub
    Private Sub ShowWarning(ByVal message As String)
        status.BackColor = System.Drawing.Color.Orange
        status.Text = message
    End Sub

    Private Sub comboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboBox1.SelectedIndexChanged
        textBox1.Text = ""
        textBox2.Text = ""
    End Sub

End Class
