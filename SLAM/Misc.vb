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

    Public RecentLoadedTrackName = ""

    Public Function ReloadLoadedTrack(ByRef Game As SourceGame, ByRef SteamAppsPath As String) As Boolean
        Dim Result As Boolean = False
        Dim Index As Integer = Game.GetTrackIndexByName(RecentLoadedTrackName)
        If Index > -1 Then
            Result = LoadTrack(Game, Index, SteamAppsPath)
        End If
        Return Result
    End Function

    Public Function LoadTrack(ByRef Game As SourceGame, ByVal index As Integer, ByRef SteamAppsPath As String) As Boolean
        Dim Track As track
        'If Game.tracks.Count > index Then
        If index > -1 And index < Game.tracks.Count Then
            Track = Game.tracks(index)
            Dim voicefile As String = Path.Combine(SteamAppsPath, Game.directory) & "voice_input.wav"
            Try
                If File.Exists(voicefile) Then
                    File.Delete(voicefile)
                End If

                Dim trackfile As String = Game.libraryname & Track.name & Game.FileExtension
                If File.Exists(trackfile) Then
                    If Track.volume = 100 And Track.startpos <= 0 And Track.endpos <= 0 And Not My.Settings.ForceConvertTo11kHz Then
                        File.Copy(trackfile, voicefile)
                    Else
                        Dim rate = If(My.Settings.ForceConvertTo11kHz, SampleRate.Rate11kHz, Game.samplerate)

                        If My.Settings.UseFFMPEG Then
                            FFMPEG_ConvertAndTrim(trackfile, voicefile, rate, Game.channels, Track.startpos / rate / (Game.bits / 8),
                                                  (Track.endpos - Track.startpos) / rate / (Game.bits / 8), (Track.volume / 100) ^ 6)
                            ' /2 because SLAM stores Track.startpos and Track.endpos as # of bytes not sample. With 16-bit audio, there are 2 bytes per sample.
                            ' changed to (Game.bits / 8)
                        Else
                            Dim WaveFloat As New WaveChannel32(New WaveFileReader(trackfile))
                            If Not Track.volume = 100 Then
                                WaveFloat.Volume = (Track.volume / 100) ^ 6
                            End If

                            If Not Track.startpos = Track.endpos And Track.endpos > 0 Then
                                Dim bytes((Track.endpos - Track.startpos) * 4) As Byte

                                WaveFloat.Position = Track.startpos * 4
                                WaveFloat.Read(bytes, 0, (Track.endpos - Track.startpos) * 4)

                                WaveFloat = New WaveChannel32(New RawSourceWaveStream(New MemoryStream(bytes), WaveFloat.WaveFormat))
                            End If

                            WaveFloat.PadWithZeroes = False
                            Dim outFormat = New WaveFormat(rate, Game.bits, Game.channels)
                            Dim resampler = New MediaFoundationResampler(WaveFloat, outFormat)
                            resampler.ResamplerQuality = 60
                            WaveFileWriter.CreateWaveFile(voicefile, resampler) 'wav

                            resampler.Dispose()
                            WaveFloat.Dispose()
                        End If
                    End If
                    RecentLoadedTrackName = Track.name
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

    Public Sub LoadTrackKeys(ByVal Game As SourceGame)
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
                End If
            Next
        Next

    End Sub

    Public Sub SaveTrackKeys(ByVal Game As SourceGame)
        Dim SettingsList As New List(Of track)
        Dim SettingsFile As String = Path.Combine(Game.libraryname, "TrackSettings.xml")

        For Each Track In Game.tracks
            If Not String.IsNullOrEmpty(Track.hotkey) Or Not Track.volume = 100 Or Track.endpos > 0 Then
                SettingsList.Add(Track)
            End If
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

    Public Sub FFMPEG_WaveCreator(File As String, outputFile As String, Game As SourceGame)
        Dim convert As New FFMpegConverter()
        convert.ExtractFFmpeg()

        Dim command As String = String.Format("-i ""{0}"" -n -f wav -flags bitexact -map_metadata -1 -vn -acodec pcm_s16le -ar {1} -ac {2} ""{3}""", Path.GetFullPath(File), Game.samplerate, Game.channels, Path.GetFullPath(outputFile))
        convert.Invoke(command)
    End Sub

    Public Sub FFMPEG_ConvertAndTrim(inpath As String, outpath As String, samplerate As Integer, channels As Integer, starttrim As Double, length As Double, volume As Double)
        Dim convert As New FFMpegConverter()
        convert.ExtractFFmpeg()

        Dim trimstring As String = ""
        If length > 0 Then
            trimstring = String.Format("-ss {0} -t {1} ", starttrim.ToString("F5", Globalization.CultureInfo.InvariantCulture), length.ToString("F5", Globalization.CultureInfo.InvariantCulture))
        End If

        Dim command As String = String.Format("-i ""{0}"" -n -f wav -flags bitexact -map_metadata -1 -vn -acodec pcm_s16le -ar {1} -ac {2} {3}-af ""volume={4}"" ""{5}""", Path.GetFullPath(inpath), samplerate, channels, trimstring, volume.ToString("F5", Globalization.CultureInfo.InvariantCulture), Path.GetFullPath(outpath))
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
End Module
