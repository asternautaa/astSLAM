Imports System.IO
Imports System.Text.RegularExpressions
Imports NAudio.Wave
Imports NReco.VideoConverter
Imports SLAM.SourceGame
Imports SLAM.XmlSerialization

Module Misc
    Enum SampleRate As Integer
        Rate11kHz = 11025
        Rate22kHz = 22050
        Rate44kHz = 44100
        Rate48kHz = 48000
        Rate96kHz = 96000
    End Enum
    Structure WavWorkerParams
        Public Game As SourceGame
        Public Files As String()
        Public DeleteSource As Boolean
        Public Urls As String
        Public NoPlaylist As Boolean
        Public AddPrefix As Boolean
    End Structure

    Structure WavWorkerResult
        Public Code As WavWorkerResultCode
        Public FailedFiles As List(Of String)
        Public Exception As Exception
    End Structure

    Enum AppStatus
        Idle
        Searching
        Working
    End Enum
    Enum PollRelayWorkerProgressCode
        SetupInterface
        Searching
        Working
        TrackChanged
        UpdatePlayCounter
        ShowSLAMWnd
    End Enum
    Enum DragAndDropNoPlaylist
        Ask
        Yes
        No
    End Enum

    Enum WavWorkerResultCode
        Success
        Cancelled
        YTDLFail
    End Enum

    Enum WavWorkerProgressCode
        NextFile
        MaxFiles
        Downloading
    End Enum

    Public Class LoadedTrackInfo
        Shared _track As SourceGame.track
        Shared _index As Integer = -1
        Public Shared ReadOnly Property Track As SourceGame.track
            Get
                Return _track
            End Get
        End Property

        Public Shared ReadOnly Property Index As Integer
            Get
                Return _index
            End Get
        End Property

        Public Shared ReadOnly Property Name As String
            Get
                Return _track.name
            End Get
        End Property

        Public Shared Sub SetInfo(ByRef tr As SourceGame.track, index As Integer)
            _track = tr
            _index = index
        End Sub
    End Class

    Public ReadOnly Property NAudioModuleExists
        Get
            Return File.Exists(NAudioModuleName)
        End Get
    End Property

    Public ReadOnly Property NRecoModuleExists
        Get
            Return File.Exists(NRecoModuleName)
        End Get
    End Property

    Public Function ReloadLoadedTrack(ByRef Game As SourceGame, ByRef SteamAppsPath As String) As Boolean
        Dim Result As Boolean = False
        Dim Index As Integer = Game.GetTrackIndexByName(LoadedTrackInfo.Index)
        If Index > -1 Then
            Result = LoadTrack(Game, Index, SteamAppsPath)
        End If
        Return Result
    End Function
    Public Sub DeleteVoiceFile(ByRef Game As SourceGame, ByRef _SteamAppsPath As String)
        Dim voicefile As String = Path.Combine(_SteamAppsPath, Game.directory) & "voice_input.wav"
        Try
            If File.Exists(voicefile) Then
                File.Delete(voicefile)
            End If
        Catch ex As Exception
            Logger.LogError(ex)
        End Try
    End Sub

    Public Function ConvertTrimTrack(ByRef Game As SourceGame, ByRef Track As track, ByVal StartPos As Integer, ByVal EndPos As Integer, Optional outputFile As String = "", Optional SampleRate As Integer = -1) As Boolean
        'Dim Track As track
        'If Index > -1 And Index < Game.tracks.Count Then
        'Track = Game.tracks(Index)
        Try
            Dim trackFile As String = Game.libraryname & Track.name & Game.FileExtension
            If (outputFile.Length = 0) Then
                outputFile = trackFile
            End If
            If SampleRate = -1 Then
                SampleRate = Game.samplerate
            End If
            If File.Exists(trackFile) Then
                If My.Settings.UseFFMPEG Then
                    FFMPEG_ConvertAndTrim(trackFile, outputFile, SampleRate, Game.channels, StartPos / SampleRate / (Game.bits / 8),
                                                  (EndPos - StartPos) / SampleRate / (Game.bits / 8), (Track.volume / 100) ^ 6, True)
                Else
                    Dim WaveFloat As New WaveChannel32(New WaveFileReader(trackFile))

                    If Not StartPos = EndPos And EndPos > 0 Then
                        Dim bytes((EndPos - StartPos) * 4) As Byte

                        WaveFloat.Position = StartPos * 4
                        WaveFloat.Read(bytes, 0, (EndPos - StartPos) * 4)
                        WaveFloat.Close()

                        WaveFloat = New WaveChannel32(New RawSourceWaveStream(New MemoryStream(bytes), WaveFloat.WaveFormat))
                    End If

                    WaveFloat.PadWithZeroes = False
                    Dim outFormat = New WaveFormat(SampleRate, Game.bits, Game.channels)
                    Dim resampler = New MediaFoundationResampler(WaveFloat, outFormat)
                    resampler.ResamplerQuality = 60
                    WaveFileWriter.CreateWaveFile(outputFile, resampler) 'wav

                    resampler.Dispose()
                    WaveFloat.Dispose()
                End If
            End If
        Catch ex As Exception
            Logger.LogError(ex)
            Return False
        End Try
        'Else
        '    Return False
        'End If
        Return True
    End Function

    Public Function LoadTrack(ByRef Game As SourceGame, ByVal index As Integer, ByRef SteamAppsPath As String) As Boolean
        Dim Track As track
        If index > -1 And index < Game.tracks.Count Then
            Track = Game.tracks(index)
            Try
                Dim voicefile As String = Path.Combine(SteamAppsPath, Game.directory) & "voice_input.wav"
                Dim trackfile As String = Game.libraryname & Track.name & Game.FileExtension
                DeleteVoiceFile(Game, SteamAppsPath)
                If File.Exists(trackfile) Then
                    If Track.volume = 100 And Track.startpos <= 0 And Track.endpos <= 0 And Not My.Settings.ForceConvertTo11kHz Then
                        File.Copy(trackfile, voicefile)
                    Else
                        Dim rate = If(My.Settings.ForceConvertTo11kHz, SampleRate.Rate11kHz, Game.samplerate)

                        'If My.Settings.UseFFMPEG Then
                        '    FFMPEG_ConvertAndTrim(trackfile, voicefile, rate, Game.channels, Track.startpos / rate / (Game.bits / 8),
                        '                          (Track.endpos - Track.startpos) / rate / (Game.bits / 8), (Track.volume / 100) ^ 6)
                        '    ' /2 because SLAM stores Track.startpos and Track.endpos as # of bytes not sample. With 16-bit audio, there are 2 bytes per sample.
                        '    ' changed to (Game.bits / 8)
                        'Else
                        '    Dim WaveFloat As New WaveChannel32(New WaveFileReader(trackfile))
                        '    If Not Track.volume = 100 Then
                        '        WaveFloat.Volume = (Track.volume / 100) ^ 6
                        '    End If

                        '    If Not Track.startpos = Track.endpos And Track.endpos > 0 Then
                        '        Dim bytes((Track.endpos - Track.startpos) * 4) As Byte

                        '        WaveFloat.Position = Track.startpos * 4
                        '        WaveFloat.Read(bytes, 0, (Track.endpos - Track.startpos) * 4)

                        '        WaveFloat = New WaveChannel32(New RawSourceWaveStream(New MemoryStream(bytes), WaveFloat.WaveFormat))
                        '    End If

                        '    WaveFloat.PadWithZeroes = False
                        '    Dim outFormat = New WaveFormat(rate, Game.bits, Game.channels)
                        '    Dim resampler = New MediaFoundationResampler(WaveFloat, outFormat)
                        '    resampler.ResamplerQuality = 60
                        '    WaveFileWriter.CreateWaveFile(voicefile, resampler) 'wav

                        '    resampler.Dispose()
                        '    WaveFloat.Dispose()
                        ConvertTrimTrack(Game, Track, Track.startpos, Track.endpos, voicefile, rate)
                    End If
                    LoadedTrackInfo.SetInfo(Track, index)
                End If
            Catch ex As Exception
                Logger.LogError(ex)
                Return False
            End Try
        Else
            Return False
        End If
        Return True
    End Function

    Public Function URLsToList(ByRef urls As String) As List(Of String)
        Dim ResultList As New List(Of String)
        Dim UrlArray As String() = urls.Split({" ", vbCrLf, vbLf, vbCr}, StringSplitOptions.RemoveEmptyEntries)

        For Each Url In UrlArray
            If (Uri.IsWellFormedUriString(Url, UriKind.Absolute)) Then
                ResultList.Add(Url)
            End If
        Next

        Return ResultList
    End Function

    Public Sub LoadTrackSettings(ByVal Game As SourceGame)
        Dim SettingsList As New List(Of track)
        Dim SettingsFile As String = Path.Combine(Game.libraryname, "TrackSettings.xml")

        If File.Exists(SettingsFile) Then
            Dim XmlFile As String
            Using reader As StreamReader = New StreamReader(SettingsFile)
                XmlFile = reader.ReadToEnd
            End Using
            SettingsList = Deserialize(Of List(Of track))(XmlFile)
        End If


        For Each Track In Game.tracks
            For Each SetTrack In SettingsList
                If Track.name = SetTrack.name Then
                    'Please tell me that there is a better way to do the following...
                    Track.hotkey = SetTrack.hotkey
                    Track.volume = SetTrack.volume
                    Track.startpos = SetTrack.startpos
                    Track.endpos = SetTrack.endpos
                    Track.PlayCounter = SetTrack.PlayCounter
                End If
            Next
        Next

    End Sub

    Public Sub SaveTrackSettings(ByVal Game As SourceGame)
        Dim SettingsList As New List(Of track)
        Dim SettingsFile As String = Path.Combine(Game.libraryname, "TrackSettings.xml")

        For Each Track In Game.tracks
            'If Not String.IsNullOrEmpty(Track.hotkey) Or Not Track.volume = 100 Or Track.endpos > 0 Then
            SettingsList.Add(Track)
            'End If
        Next

        If SettingsList.Count > 0 Then
            Using writer As StreamWriter = New StreamWriter(SettingsFile)
                writer.Write(Serialize(SettingsList))
            End Using
        Else
            If File.Exists(SettingsFile) Then
                File.Delete(SettingsFile)
            End If
        End If
    End Sub

    Public Sub CreateTags(ByVal Game As SourceGame)
        Dim NameWords As New Dictionary(Of String, Integer)

        Dim index As Integer
        For Each Track In Game.tracks
            Dim Words As List(Of String) = Track.name.Split({" "c, "."c, "-"c, "_"c}).ToList()

            For Each Word In Words
                If Not IsNumeric(Word) And Not Game.blacklist.Contains(Word.ToLower()) And (Word.Length > 2 And Word.Length < 32) Then
                    If NameWords.ContainsKey(Word) Then
                        NameWords.Remove(Word)
                    Else
                        NameWords.Add(Word, index)
                    End If
                End If

            Next
            index += 1
        Next

        For Each Tag As KeyValuePair(Of String, Integer) In NameWords
            Game.tracks(Tag.Value).tags.Add(Tag.Key)
        Next
    End Sub

    Public Sub WaveCreator(File As String, outputFile As String, Game As SourceGame)
        Dim reader As New MediaFoundationReader(File)
        Dim outFormat = New WaveFormat(Game.samplerate, Game.bits, Game.channels)
        Dim resampler = New MediaFoundationResampler(reader, outFormat)
        resampler.ResamplerQuality = 60
        WaveFileWriter.CreateWaveFile(outputFile, resampler)
        resampler.Dispose()
    End Sub

    Public Sub FFMPEG_WaveCreator(inputFile As String, outputFile As String, Game As SourceGame)
        Dim convert As New FFMpegConverter()
        convert.ExtractFFmpeg()

        Dim command As String = String.Format("-i ""{0}"" -n -f wav -flags bitexact -map_metadata -1 -vn -acodec pcm_s16le -ar {1} -ac {2} ""{3}""", Path.GetFullPath(inputFile), Game.samplerate, Game.channels, Path.GetFullPath(outputFile))
        convert.Invoke(command)
    End Sub

    Public Sub FFMPEG_ConvertAndTrim(inputFile As String, outputFile As String, samplerate As Integer, channels As Integer, starttrim As Double, length As Double, volume As Double, Optional overwrite As Boolean = False)
        Dim convert As New FFMpegConverter()
        convert.ExtractFFmpeg()

        Dim trimstring As String = ""
        If length > 0 Then
            trimstring = String.Format("-ss {0} -t {1} ", starttrim.ToString("F5", Globalization.CultureInfo.InvariantCulture), length.ToString("F5", Globalization.CultureInfo.InvariantCulture))
        End If

        Dim command As String = String.Format("-i ""{0}"" {6} -f wav -flags bitexact -map_metadata -1 -vn -acodec pcm_s16le -ar {1} -ac {2} {3}-af ""volume={4}"" {6} ""{5}""", Path.GetFullPath(inputFile), samplerate, channels, trimstring, volume.ToString("F5", Globalization.CultureInfo.InvariantCulture), Path.GetFullPath(outputFile), If(overwrite, "-y", "-n"))
        convert.Invoke(command)
    End Sub

    Public Function recog(ByVal str As String, ByVal reg As String) As String
        Dim keyd As Match = Regex.Match(str, reg, RegexOptions.IgnoreCase) 'RegexOptions.IgnoreCase because bind could be saved as lowercase
        Return (keyd.Groups(1).ToString)
    End Function

    Public Sub DeleteTempFiles()
        If (IO.Directory.Exists("temp")) Then
            IO.Directory.Delete("temp", True)
        End If
    End Sub

    Public Function GetWavDuration(ByVal WavPath As String) As TimeSpan
        Dim duration As TimeSpan = Nothing
        If (NAudioModuleExists) Then
            Dim WaveReader As New NAudio.Wave.WaveFileReader(WavPath)
            duration = WaveReader.TotalTime
            WaveReader.Close()
        End If
        Return duration
    End Function

    Public Sub DoStartSteamGame(ByRef Game As SourceGame)
        Dim pfi As New ProcessStartInfo(String.Format("steam://run/{0}", Game.id))
        System.Diagnostics.Process.Start(pfi)
    End Sub
    Public Sub ScanAndFixKeyCollision()
        For i As Integer = 0 To My.Settings.Hotkeys.Count - 1
            For j As Integer = i + 1 To My.Settings.Hotkeys.Count - 1
                If Not (KeysMisc.KeyIsEmpty(i) Or KeysMisc.KeyIsEmpty(j)) Then
                    If My.Settings.Hotkeys(i) = My.Settings.Hotkeys(j) Then
                        My.Settings.Hotkeys(j) = ""
                    End If
                End If
            Next
        Next
        My.Settings.Save()
    End Sub

    Public Function FindTrackIndexByHotkey(ByRef Game As SourceGame, hotkey As String) As Integer
        Dim FoundIndex As Integer = -1
        If Not (String.IsNullOrEmpty(hotkey) And String.IsNullOrWhiteSpace(hotkey)) Then
            hotkey = hotkey.ToUpper()
            For i As Integer = 0 To Game.tracks.Count - 1
                If (Game.tracks(i).hotkey = hotkey) Then
                    FoundIndex = i
                    Exit For
                End If
            Next
        End If
        Return FoundIndex
    End Function
End Module
