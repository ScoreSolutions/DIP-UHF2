Public Class Sound
    Public Declare Function WCE_PlaySound Lib "CoreDll.dll" Alias "PlaySound" _
   (ByVal szSound As String, ByVal hMod As IntPtr, ByVal flags As Integer) As Integer
    Public Declare Function WCE_PlaySoundBytes Lib "CoreDll.dll" Alias "PlaySound" _
     (ByVal szSound() As Byte, ByVal hMod As IntPtr, ByVal flags As Integer) As Integer

    Public Enum PlaySoundFlags
        SND_ALIAS = &H10000
        SND_FILENAME = &H20000
        SND_RESOURCE = &H40004
        SND_SYNC = &H0
        SND_ASYNC = &H1
        SND_NODEFAULT = &H2
        SND_MEMORY = &H4
        SND_LOOP = &H8
        SND_NOSTOP = &H10
        SND_NOWAIT = &H2000
        SND_VALIDFLAGS = &H17201F
        SND_RESERVED = &HFF000000
        SND_TYPE_MASK = &H170007
    End Enum

    Public ReadOnly Property NowPlaying() As Boolean
        Get
            Return Status
        End Get
    End Property

    Public CurrentCauseProblem As Object ' Object That Request To Play Sound

    Public Status As Boolean = False


    Public Sub Play(ByVal WaveFileName As String, ByVal PlayLoop As Boolean)
        If WaveFileName = "" Then Exit Sub
        If PlayLoop Then
            Status = True
            WCE_PlaySound(WaveFileName, IntPtr.Zero, Fix(PlaySoundFlags.SND_LOOP Or PlaySoundFlags.SND_ASYNC Or PlaySoundFlags.SND_FILENAME))
        Else
            Status = False
            WCE_PlaySound(WaveFileName, IntPtr.Zero, Fix(PlaySoundFlags.SND_ASYNC Or PlaySoundFlags.SND_FILENAME))
        End If
    End Sub

    Public Sub StopSound()
        Dim StopFile As String = ApplicationPath() & "\Stop.wav"
        WCE_PlaySound(StopFile, IntPtr.Zero, Fix(PlaySoundFlags.SND_ASYNC Or PlaySoundFlags.SND_FILENAME))
        Status = False
    End Sub



End Class
