
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports PsionTeklogix.Keyboard
Imports PsionTeklogix.Trigger
Imports com.caen.RFIDLibrary
Imports PsionTeklogix.RFID

Public Class CAEN_READ

    Public Enum MEMORY_BANK
        NONE = 0
        RESERVED = 1
        EPC = 2
        TID = 3
        USER = 4
    End Enum

    Public Structure RFID_STATUS
        Public Available As Boolean
        Public Detail As String
        Public Tags() As CAENRFIDTag
    End Structure


#Region "Psion Trigger Members and Functions"

    Private tc As TriggerControl = Nothing
    Const TemporaryClient As String = "CAEN_TRIGGER"

    Private Sub TriggerClose()
        If tc IsNot Nothing Then
            Try
                AddHandler tc.triggerEvent, AddressOf OnTriggerEvent
                tc.DeregisterFromEvents(TemporaryClient)
                tc.DeregisterConsumer(TemporaryClient)
            Catch ex As Exception
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
        Catch ex As Exception
            TriggerClose()
            Return False
        End Try

        ' Initialize Trigger Control
        Try
            tc.Initialize()
        Catch ex As Exception
            TriggerClose()
            Return False
        End Try

        Dim names As New ArrayList()
        Try
            tc.GetRegisteredConsumers(names)
        Catch ex As Exception
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
            Catch ex As Exception
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
        Catch ex As Exception
            TriggerClose()
            Return False
        End Try

        ' Register for events
        Try
            tc.RegisterForEvents(TemporaryClient)
        Catch ex As Exception
            TriggerClose()
            Return False
        End Try

        ' Add delegate
        Try
            AddHandler tc.triggerEvent, AddressOf OnTriggerEvent
        Catch ex As Exception
            TriggerClose()
            Return False
        End Try
        Return True
    End Function

    Private Sub OnTriggerEvent(ByVal sender As Object, ByVal e As TriggerEvent)
        Select Case e.EventFlags
            Case TriggerEvent.TriggerUp
                m_tags.Clear()
            Case TriggerEvent.TriggerDown

        End Select
    End Sub

#End Region

#Region "CAEN SDK Members and Functions"

    Private ComPort As Integer = 1
    Private Reader As CAENRFIDReader = Nothing
    Private m_Source0 As CAENRFIDLogicalSource = Nothing
    Private m_tags As List(Of String)
    Private rfidDriver As New RFIDDriver()

    Private membank_bytes As Short()

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
        membank_bytes = New Short(4) {}
        membank_bytes(0) = 0
        ' no bank
        membank_bytes(1) = 8
        ' reserved bank 
        membank_bytes(2) = 16
        ' EPC bank
        membank_bytes(3) = 4
        ' TID bank
        membank_bytes(4) = 2
        ' user bank


        m_tags = New List(Of String)()
        Reader = New CAENRFIDReader()
        Try
            rfidDriver.Enable()
            Reader.Connect(CAENRFIDPort.CAENRFID_RS232, "COM" & rfidDriver.ComPort.ToString() & ":115200")
        Catch ex As Exception
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

#End Region

    Public Function Open() As RFID_STATUS
        Dim Result As New RFID_STATUS
        If rfidDriver.IsInstalled Then
            If CAEN_Init() Then
                If Not TriggerInit() Then
                    Result.Available = False
                    Result.Detail = "Trigger Init"
                Else
                    Result.Available = True
                    Result.Detail = "OPENED"
                End If
            Else
                Result.Available = False
                Result.Detail = "CAEN Init"
            End If
        Else
            Result.Available = False
            Result.Detail = "RFID Driver"
        End If
        Return Result
    End Function

    Public Sub Close()
        TriggerClose()
        CAEN_Close()
    End Sub

    Public Function Read() As RFID_STATUS

        Dim Result As New RFID_STATUS

        If m_Source0 IsNot Nothing Then
            Dim tags As CAENRFIDTag() = Nothing
            Dim tempMask As Byte() = New Byte(15) {}

            Try
                tags = m_Source0.InventoryTag(tempMask, 0, 0, 1)
            Catch
                Result.Available = False
                Result.Detail = "InventoryTag Fail"
                Return Result
            End Try

            If Not IsNothing(tags) AndAlso tags.Length > 0 Then

                Result.Available = True
                Result.Detail = "Tags Found"
                Result.Tags = tags
                'For Each tag As CAENRFIDTag In tags
                '    Dim IDTag As String = System.BitConverter.ToString(tag.GetId()).Replace("-", "")

                '    Dim tagRecorded As Boolean = False
                '    If m_tags.Count > 0 Then
                '        For i As Integer = 0 To m_tags.Count - 1
                '            If m_tags(i) = IDTag Then
                '                tagRecorded = True
                '                Exit For
                '            End If
                '        Next
                '    End If
                '    If Not tagRecorded Then
                '        m_tags.Add(IDTag)
                '        listBox1.Items.Add(IDTag)
                '        Dim rssi As String = "   RSSI: " & tag.GetRSSI().ToString()
                '        listBox1.Items.Add(rssi)

                '        If comboBox1.SelectedIndex > 0 Then
                '            Try
                '                Dim read As Byte() = Nothing
                '                Select Case comboBox1.SelectedIndex
                '                    Case 1
                '                        ' Reserved
                '                        Read = m_Source0.ReadTagData_EPC_C1G2(tag, 0, 0, membank_bytes(comboBox1.SelectedIndex))
                '                        Exit Select
                '                    Case 2
                '                        ' EPC
                '                        Read = m_Source0.ReadTagData_EPC_C1G2(tag, 1, 0, membank_bytes(comboBox1.SelectedIndex))
                '                        Exit Select
                '                    Case 3
                '                        ' TID
                '                        Read = m_Source0.ReadTagData_EPC_C1G2(tag, 2, 0, membank_bytes(comboBox1.SelectedIndex))
                '                        Exit Select
                '                    Case 4
                '                        ' User
                '                        Read = m_Source0.ReadTagData_EPC_C1G2(tag, 3, 0, membank_bytes(comboBox1.SelectedIndex))
                '                        Exit Select
                '                End Select

                '                Dim exData As String = "   " & comboBox1.SelectedItem.ToString() & ": " & System.BitConverter.ToString(Read).Replace("-", "")
                '                listBox1.Items.Add(exData)
                '            Catch
                '                Dim [error] As String = "   FAIL: Read Bank: " & comboBox1.SelectedItem.ToString()
                '                listBox1.Items.Add([error])
                '                Return
                '            End Try
                '        End If
                '    End If
                'Next
            Else
                Result.Available = False
                Result.Detail = "Tag not found"
                Return Result
            End If
        End If

        Return Result
    End Function

End Class



