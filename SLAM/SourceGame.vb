Public Class SourceGame
    Public name As String
    Public id As Integer
    Public directory As String
    Public ToCfg As String
    Public libraryname As String
    Public VoiceFadeOut As Boolean = True
    Public exename As String = DefaultExeName

    Public FileExtension As String = DefaultAudioExtension
    Public samplerate As Integer = DefaultSampleRate
    Public bits As Integer = DefaultBits                'for FFMPEG this is ignored and is always 16
    Public channels As Integer = DefaultChannels

    Public PollInterval As Integer = DefaultPollInterval

    Public RelayInUserData As Boolean = True
    Public RelayCfgRemote As Boolean = False
    Public RelayCfgNeedFullWrite As Boolean = False
    Public WindowTitle As String

    Public tracks As New List(Of track)
    Public blacklist As New List(Of String)

    Sub New()
        blacklist.AddRange(DefaultTagsBlacklist)
    End Sub
    Public ReadOnly Property GamePath As String
        Get
            Return Me.directory & Me.exename & ".exe"
        End Get
    End Property

    Public Function GetTrackIndexByName(ByVal name As String)
        Dim index = -1
        For i As Integer = 0 To tracks.Count - 1
            If (String.Equals(name, tracks(i).name, StringComparison.OrdinalIgnoreCase)) Then
                index = i
                Exit For
            End If
        Next

        Return index
    End Function
    Public Class track
        Public name As String
        Public tags As New List(Of String)
        Public hotkey As String = vbNullString
        Public volume As Integer = 100
        Public startpos As Integer
        Public endpos As Integer
        Public ReadOnly Property Trimmed As Boolean
            Get
                Return endpos > 0
            End Get
        End Property
    End Class
End Class