Imports System.IO
Imports System.Threading
Imports SLAM.SourceGame
Imports System.Management

Public Class MainForm
    Dim Games As New List(Of SourceGame)
    Dim CurrentGame As SourceGame
    Dim ClosePending As Boolean = False
    Dim SteamAppsPath As String
    Dim Status As AppStatus = AppStatus.Idle
    Dim TracksToHighlight As New List(Of String)

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If My.Settings.UpdateCheck Then
        '    CheckForUpdate()
        'End If

        InitSourceGames()
        InitGameSelector()
        ReloadTracks(CurrentGame) 'CurrentGame here is already set by GameSelector.SelectedIndexChanged event
        RefreshTrackList()

        If My.Settings.StartEnabled Then
            StartPoll()
        End If

        If My.Settings.StartMinimized Then
            WindowState = FormWindowState.Minimized
        End If

        If My.Settings.AutoUpdateYTDL Then
            YTDLUpdateWorker_Start()
        End If
    End Sub

    Private Sub InitGameSelector()
        For Each Game In Games
            GameSelector.Items.Add(Game.name)
        Next

        If GameSelector.Items.Contains(My.Settings.LastGame) Then
            GameSelector.SelectedIndex = GameSelector.Items.IndexOf(My.Settings.LastGame)
        Else
            GameSelector.SelectedIndex = 0
        End If
    End Sub

    Private Sub InitSourceGames()
        Dim csgo As New SourceGame
        csgo.name = "Counter-Strike: Global Offensive"
        csgo.WindowTitle = "Counter-Strike: Global Offensive"
        csgo.id = 730
        csgo.directory = "common\Counter-Strike Global Offensive\"
        csgo.ToCfg = "csgo\cfg\"
        csgo.libraryname = "csgo\"
        csgo.exename = "csgo"
        csgo.blacklist.AddRange({"attack", "attack2", "autobuy", "back", "buy", "buyammo1", "buyammo2", "buymenu", "callvote", "cancelselect", "cheer", "compliment", "coverme", "drop", "duck", "enemydown", "enemyspot", "fallback", "followme", "forward", "getout", "go", "holdpos", "inposition", "invnext", "invprev", "jump", "lastinv", "messagemode", "messagemode2", "moveleft", "moveright", "mute", "negative", "quit", "radio1", "radio2", "radio3", "rebuy", "regroup", "reload", "report", "reportingin", "roger", "sectorclear", "showscores", "slot1", "slot10", "slot2", "slot3", "slot4", "slot5", "slot6", "slot7", "slot8", "slot9", "speed", "sticktog", "takepoint", "takingfire", "teammenu", "thanks", "toggleconsole", "use", "voicerecord"})
        csgo.VoiceFadeOut = False
        Games.Add(csgo)

        Dim css As New SourceGame
        css.RelayInUserData = False
        css.id = 240
        css.name = "Counter-Strike: Source"
        css.WindowTitle = "Counter-Strike Source"
        css.directory = "common\Counter-Strike Source\"
        css.ToCfg = "cstrike\cfg\"
        css.libraryname = "css\"
        css.blacklist.AddRange({"attack", "attack2", "back", "boom", "buyammo1", "buyammo2", "buyequip", "buymenu", "cancelselect", "cheer", "chooseteam", "commandmenu", "disconnect", "drop", "duck", "forward", "invnext", "invprev", "jump", "messagemode", "messagemode2", "moveleft", "moveright", "pause", "reload", "showbriefing", "showscores", "slot1", "slot10", "slot2", "slot3", "slot4", "slot5", "slot6", "slot7", "slot8", "slot9", "speed", "toggleconsole", "use"})
        Games.Add(css)

        Dim tf2 As New SourceGame
        tf2.name = "Team Fortress 2"
        tf2.WindowTitle = "Team Fortress 2"
        tf2.id = 440
        tf2.RelayInUserData = False
        tf2.RelayCfgRemote = True
        tf2.RelayCfgNeedFullWrite = True
        tf2.id =
        tf2.directory = "common\Team Fortress 2\"
        tf2.ToCfg = "tf\cfg\"
        tf2.libraryname = "tf2\"
        tf2.blacklist.AddRange({"attack", "attack2", "attack3", "back", "build", "cancelselect", "centerview", "changeclass", "changeteam", "disguiseteam", "duck", "forward", "grab", "invnext", "invprev", "jump", "kill", "klook", "lastdisguise", "lookdown", "lookup", "moveleft", "moveright", "moveup", "pause", "quit", "reload", "say", "screenshot", "showmapinfo", "showroundinfo", "showscores", "slot1", "slot10", "slot2", "slot3", "slot4", "slot5", "slot6", "slot7", "slot8", "slot9", "strafe", "toggleconsole", "voicerecord"})
        Games.Add(tf2)

        Dim gmod As New SourceGame
        gmod.samplerate = SampleRate.Rate11kHz
        gmod.id = 4000
        gmod.RelayInUserData = False
        gmod.name = "Garry's Mod"
        gmod.WindowTitle = "Garry's Mod"
        gmod.directory = "common\GarrysMod\"
        gmod.ToCfg = "garrysmod\cfg\"
        gmod.libraryname = "gmod\"
        Games.Add(gmod)

        Dim hl2dm As New SourceGame
        hl2dm.id = 320
        hl2dm.RelayInUserData = False
        hl2dm.name = "Half-Life 2 Deathmatch"
        hl2dm.WindowTitle = "Half-Life 2 DM"
        hl2dm.directory = "common\Half-Life 2 Deathmatch\"
        hl2dm.ToCfg = "hl2mp\cfg\"
        hl2dm.libraryname = "hl2dm\"
        Games.Add(hl2dm)

        Dim l4d As New SourceGame
        l4d.samplerate = SampleRate.Rate11kHz
        l4d.id = 500
        l4d.RelayInUserData = False
        l4d.name = "Left 4 Dead"
        l4d.WindowTitle = "Left 4 Dead"
        l4d.directory = "common\Left 4 Dead\"
        l4d.ToCfg = "left4dead\cfg\"
        l4d.libraryname = "l4d\"
        l4d.exename = "left4dead"
        l4d.VoiceFadeOut = False
        Games.Add(l4d)

        Dim l4d2 As New SourceGame
        l4d2.samplerate = SampleRate.Rate11kHz
        l4d2.id = 550
        l4d2.RelayInUserData = False
        l4d2.name = "Left 4 Dead 2"
        l4d2.WindowTitle = "Left 4 Dead 2"
        l4d2.directory = "common\Left 4 Dead 2\"
        l4d2.ToCfg = "left4dead2\cfg\"
        l4d2.libraryname = "l4d2\"
        l4d2.exename = "left4dead2"
        l4d2.VoiceFadeOut = False
        Games.Add(l4d2)

        Dim dods As New SourceGame
        dods.RelayInUserData = False
        dods.id = 300
        dods.name = "Day of Defeat Source"
        dods.WindowTitle = "Day of Defeat Source"
        dods.directory = "common\day of defeat source\"
        dods.ToCfg = "dod\cfg\"
        dods.libraryname = "dods\"
        Games.Add(dods)

        'NEEDS EXENAME!!!
        'Dim goldeye As New SourceGame
        'goldeye.name = "Goldeneye Source"
        'goldeye.directory = "sourcemods\"
        'goldeye.ToCfg = "gesource\cfg\"
        'goldeye.libraryname = "goldeye\"
        'Games.Add(goldeye)

        Dim insurg As New SourceGame
        insurg.id = 222880
        insurg.RelayInUserData = False
        insurg.name = "Insurgency"
        insurg.WindowTitle = "Insurgency"
        insurg.directory = "common\insurgency2\"
        insurg.ToCfg = "insurgency\cfg\"
        insurg.libraryname = "insurgen\"
        insurg.exename = "insurgency"
        Games.Add(insurg)

        Dim cure As New SourceGame
        cure.RelayInUserData = False
        cure.name = "Codename CURE"
        cure.WindowTitle = "Codename CURE"
        cure.directory = "common\Codename CURE\"
        cure.ToCfg = "cure\cfg\"
        cure.libraryname = "cure\"
        cure.exename = "cure"
        cure.id = 355180
        cure.RelayCfgRemote = True
        Games.Add(cure)
    End Sub

    Private ReadOnly Property Running As Boolean
        Get
            Return PollRelayWorker.IsBusy
        End Get
    End Property

    Private Sub YTDLUpdateWorker_Start()
        Dim now = Date.Now
        Dim days = DateDiff("d", now, My.Settings.AutoUpdateYTDLLastDateCheck)
        If (days >= 3 Or days < 0) Then
            My.Settings.AutoUpdateYTDLLastDateCheck = now
            My.Settings.Save()
            ViaYoutubedlToolStripMenuItem.Enabled = False
            YTDLUpdateWorker.RunWorkerAsync()
        End If
    End Sub

    Private Sub YTDLUpdateWorker_DoDownload(Optional update As Boolean = True)
        YTDLUpdateWorker.ReportProgress(0, "Downloading youtube-dl...")

        If YoutubeDL.DownloadModule() Then
            YTDLUpdateWorker.ReportProgress(0, If(update, "youtube-dl updated sucessfully.", "youtube-dl downloaded sucessfully."))
        Else
            YTDLUpdateWorker.ReportProgress(0, If(update, "Cannot update youtube-dl.", "Cannot download youtube-dl."))
        End If
    End Sub

    'Yeah, I know youtube-dl has a command line option to update itself, but why not, if I write my own one :)
    Private Sub YTDLUpdateWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles YTDLUpdateWorker.DoWork
        If (YoutubeDL.ModuleExists) Then
            Dim currVersion As String = ""
            Dim newVersion As String = ""

            YTDLUpdateWorker.ReportProgress(0, "Checking current version of youtube-dl...")

            If (YoutubeDL.GetVersionString(currVersion)) Then
                YTDLUpdateWorker.ReportProgress(0, "Checking latest version...of youtube-dl")

                If (YoutubeDL.GetLatestVersionString(newVersion)) Then
                    If Not (currVersion = newVersion) Then
                        YTDLUpdateWorker_DoDownload()
                    Else
                        YTDLUpdateWorker.ReportProgress(0, "youtube-dl is up-to-date.")
                    End If
                Else
                    YTDLUpdateWorker.ReportProgress(0, "Cannot get latest version of youtube-dl from download homepage.")
                End If
            Else
                YTDLUpdateWorker.ReportProgress(0, "Cannot get version of youtube-dl.")
            End If
        Else
            YTDLUpdateWorker_DoDownload(False)
        End If
    End Sub

    Private Sub YTDLUpdateWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles YTDLUpdateWorker.ProgressChanged
        ToolStripStatusLabelAppStatus.Text = e.UserState.ToString()
    End Sub

    Private Sub YTDLUpdateWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles YTDLUpdateWorker.RunWorkerCompleted
        ViaYoutubedlToolStripMenuItem.Enabled = True
    End Sub

    Private Sub GameSelector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GameSelector.SelectedIndexChanged
        CurrentGame = GetCurrentGame()

        ReloadTracks(CurrentGame)
        RefreshTrackList()
        My.Settings.LastGame = GameSelector.Text
        My.Settings.Save()
    End Sub

    Private Sub StatusImportShow(Optional show As Boolean = True)
        ToolStripProgressBarImport.Visible = show
        ToolStripStatusLabelSeparator3.Visible = show
        ToolStripStatusLabelImportProgress.Visible = show
        ToolStripStatusLabelStopImport.Visible = show

        ToolStripStatusLabelSeparator2.Visible = Not show
        ToolStripStatusLabelLoaded.Visible = Not show
        ToolStripStatusLabelLoadedTrackName.Visible = Not show
    End Sub

    Private Sub DoImportFiles(ByRef Files As String())
        Dim WorkerParams As New WavWorkerParams
        WorkerParams.Game = CurrentGame
        WorkerParams.Files = Files

        WavWorker.RunWorkerAsync(WorkerParams)
        StatusImportShow()
        DisableInterface()
        StatusStrip1.Enabled = True
    End Sub

    Private Sub DoImportFilesFromURls(ByRef URls As String, ByRef NoPlaylist As Boolean)
        Dim WorkerParams As New WavWorkerParams
        WorkerParams.Game = CurrentGame
        WorkerParams.DeleteSource = True
        WorkerParams.Urls = URls
        WorkerParams.NoPlaylist = NoPlaylist

        WavWorker.RunWorkerAsync(WorkerParams)
        StatusImportShow()
        DisableInterface()
        StatusStrip1.Enabled = True
    End Sub

    Private Sub ShowImportErrorMissingFile(ByVal name)
        MessageBox.Show(String.Format("You are missing {0}!" & vbCrLf & "Cannot import without it!", name), "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub ImportButton_Click(sender As Object, e As EventArgs) Handles ToolStripSplitButtonImport.ButtonClick
        Dim MissingFile As String = ""
        If My.Settings.UseFFMPEG = True And Not NRecoModuleExists Then
            MissingFile = NRecoModuleName
        ElseIf My.Settings.UseFFMPEG = False And Not NAudioModuleExists Then
            MissingFile = NAudioModuleName
        End If

        If MissingFile.Length > 0 Then
            ShowImportErrorMissingFile(MissingFile)
        Else
            If ImportDialog.ShowDialog() = DialogResult.OK Then
                DoImportFiles(ImportDialog.FileNames)
            End If
        End If
    End Sub

    Private Sub YTButton_Click(sender As Object, e As EventArgs) Handles ViaYoutubedlToolStripMenuItem.Click
        Dim MissingFile As String = "" 'New List(Of String)
        Dim ContinueOperation = True

        If Not YoutubeDL.ModuleExists Then
            Dim msgboxresult = MessageBox.Show("You are missing youtube-dl. Would you like to download it now? If not, import dialog will not show.", "", MessageBoxButtons.YesNo)
            If (msgboxresult = DialogResult.Yes) Then
                If (Not YoutubeDL.DownloadModule()) Then
                    MessageBox.Show("Cannot download youtube-dl." & vbCrLf & vbCrLf & YoutubeDL.LastException.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ContinueOperation = False
                End If
            Else
                ContinueOperation = False
            End If
        End If

        If ContinueOperation Then
            If My.Settings.UseFFMPEG = True And Not NRecoModuleExists Then
                MissingFile = NRecoModuleName
            ElseIf My.Settings.UseFFMPEG = False And Not NAudioModuleExists Then
                MissingFile = NAudioModuleName
            End If

            If (MissingFile.Length > 0) Then
                ShowImportErrorMissingFile(MissingFile)
            Else
                Dim YTDLImporter As New YTDLImport
                IO.Directory.CreateDirectory("temp")
                If YTDLImporter.ShowDialog() = DialogResult.OK Then
                    DoImportFilesFromURls(YTDLImporter.URLs, YTDLImporter.NoPlaylist)
                End If
            End If
        End If
    End Sub

    Private Sub WavWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles WavWorker.DoWork
        Dim Params As WavWorkerParams = e.Argument
        Dim Result As New WavWorkerResult
        Result.FailedFiles = New List(Of String)

        Dim ShortFilename As String = ""

        If Params.Urls IsNot Nothing Then
            Dim FilteredList As List(Of String) = URLsToList(Params.Urls)
            WavWorker.ReportProgress(WavWorkerProgressCode.Downloading)
            If (YoutubeDL.DownloadVideos(FilteredList.ToArray(), YoutubeDL.FormatBestAudio, Constants.YTDLOutputTemplate, Params.NoPlaylist)) Then
                Params.Files = IO.Directory.GetFiles("temp\")
            Else
                Params.Files = Nothing
                Result.Exception = YoutubeDL.LastException
                Result.Code = WavWorkerResultCode.YTDLFail
            End If
        End If

        TracksToHighlight.Clear()

        If (Params.Files IsNot Nothing) Then
            WavWorker.ReportProgress(WavWorkerProgressCode.MaxFiles, Params.Files.Count)
            For Each File In Params.Files
                ShortFilename = Path.GetFileNameWithoutExtension(File)
                WavWorker.ReportProgress(WavWorkerProgressCode.NextFile, ShortFilename)
                Try
                    Dim OutFile As String = Path.Combine(Params.Game.libraryname, ShortFilename & ".wav")

                    If My.Settings.UseFFMPEG Then
                        FFMPEG_WaveCreator(File, OutFile, Params.Game)
                    Else
                        WaveCreator(File, OutFile, Params.Game)
                    End If

                    If Params.DeleteSource Then
                        IO.File.Delete(File)
                    End If

                    TracksToHighlight.Add(ShortFilename)
                Catch ex As Exception
                    Logger.LogError(ex)
                    Result.FailedFiles.Add(Path.GetFileName(File))
                End Try

                If (WavWorker.CancellationPending) Then
                    Result.Code = WavWorkerResultCode.Cancelled
                    Exit For
                End If
            Next
        End If

        e.Result = Result
    End Sub

    Private Sub WavWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles WavWorker.ProgressChanged
        Select Case e.ProgressPercentage
            Case WavWorkerProgressCode.NextFile
                ToolStripProgressBarImport.PerformStep()
                ToolStripStatusLabelImportProgress.Text = String.Format("Import progress: {0}/{1} ({2})", ToolStripProgressBarImport.Value, ToolStripProgressBarImport.Maximum, e.UserState)
            Case WavWorkerProgressCode.MaxFiles
                ToolStripProgressBarImport.Value = 0
                ToolStripProgressBarImport.Maximum = e.UserState
            Case WavWorkerProgressCode.Downloading
                ToolStripStatusLabelImportProgress.Text = "Import progress: Downloading..."
        End Select
    End Sub
    Private Sub WavWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles WavWorker.RunWorkerCompleted
        Dim Result As WavWorkerResult = e.Result

        Dim MsgBoxText As String = ""
        ToolStripProgressBarImport.Value = 0
        ToolStripStatusLabelImportProgress.Text = "Import progress"
        StatusImportShow(False)

        Select Case Result.Code
            Case WavWorkerResultCode.Success
                MsgBoxText = "Conversion complete!"
            Case WavWorkerResultCode.Cancelled
                MsgBoxText = "Conversion stopped!"
            Case WavWorkerResultCode.YTDLFail
                MsgBoxText = "Download failed:" & vbCrLf & Result.Exception.ToString()
        End Select

        If Result.FailedFiles.Count > 0 Then
            MsgBoxText = MsgBoxText & " However, the following files failed to convert:  " & String.Join(", ", Result.FailedFiles)
        End If

        ReloadTracks(CurrentGame)
        RefreshTrackList()
        MessageBox.Show(MsgBoxText, "SLAM", MessageBoxButtons.OK, MessageBoxIcon.Information)
        UpdateTracksInGame()
        EnableInterface()
        Misc.DeleteTempFiles()
    End Sub
    Private Sub UpdateTracksInGame(Optional AlsoUpdateHotkeys As Boolean = False)
        If Running And status = AppStatus.Working Then
            Configs.CreateTracksConfig(CurrentGame, SteamAppsPath)
        End If
    End Sub

    Private Function GetCurrentGame() As SourceGame
        For Each Game In Games
            If Game.name = GameSelector.SelectedItem.ToString Then
                Return Game
            End If
        Next
        Return Nothing 'Null if nothing found
    End Function

    Private Sub ReloadTracks(Game As SourceGame)
        If IO.Directory.Exists(Game.libraryname) Then
            Game.tracks.Clear()
            For Each File In System.IO.Directory.GetFiles(Game.libraryname)

                If Game.FileExtension = Path.GetExtension(File) Then
                    Dim track As New track
                    track.name = Path.GetFileNameWithoutExtension(File)
                    Game.tracks.Add(track)
                End If
            Next

            CreateTags(Game)
            LoadTrackKeys(Game)
            SaveTrackKeys(Game) 'To prune hotkeys from non-existing tracks
        Else
            System.IO.Directory.CreateDirectory(Game.libraryname)
        End If
    End Sub

    Private Sub UpdateTrackCount()
        If Me.Created Then
            ToolStripStatusLabelTrackCount.Text = TrackList.Items.Count
        End If
    End Sub

    Private Sub RefreshTrackList()
        TrackList.Items.Clear()

        For Each Track In CurrentGame.tracks
            Dim trimmed As String = If(Track.Trimmed, "Yes", "")
            Dim lvitem = TrackList.Items.Add(New ListViewItem({"False", Track.name, Track.hotkey, Track.volume & "%", trimmed, """" & String.Join(""", """, Track.tags) & """"}))
            If My.Settings.HighlightRecentImportedTracks Then
                Dim index As Integer = TracksToHighlight.IndexOf(Track.name)
                If index > -1 Then
                    lvitem.BackColor = My.Settings.HighlightBackColor
                End If
            End If
        Next

        TrackList.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize)
        TrackList.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent)
        TrackList.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
        TrackList.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize)
        TrackList.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize)
        TrackList.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.ColumnContent)

        UpdateTrackCount()
    End Sub

    Private Sub StartStopPoll()
        If Running Then
            StopPoll()
        Else
            StartPoll()
        End If
    End Sub

    Private Sub StartPoll()
        If Not Running Then
            PollRelayWorker.RunWorkerAsync(CurrentGame)
        End If
    End Sub

    Private Sub StopPoll()
        If Running Then
            PollRelayWorker.CancelAsync()
        End If
    End Sub

    Private Sub SetupInterfaceWorking(ByVal Work As Boolean)
        SystemTrayMenuStart.Visible = Not Work
        SystemTrayMenuStop.Visible = Work
        GameSelector.Enabled = Not Work
        ToolStripButtonSettings.Enabled = Not Work
        ToolStripButtonStartWork.Visible = Not Work
        ToolStripButtonStopWork.Visible = Work
        If (WindowState = FormWindowState.Minimized And My.Settings.MinimizeToSysTray) Then
            SystemTrayIcon.BalloonTipText = If(Work, "Working...", "Stopped.")
            SystemTrayIcon.ShowBalloonTip(5000)
        End If
    End Sub

    Private Sub PollRelayWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles PollRelayWorker.DoWork
        PollRelayWorker.ReportProgress(PollRelayWorkerProgressCode.SetupInterface)
        PollRelayWorker.ReportProgress(PollRelayWorkerProgressCode.Searching) 'Report that SLAM is searching.

        Dim Game As SourceGame = e.Argument
        Dim GameDir As String = Game.GamePath

        SteamAppsPath = vbNullString
        Dim UserDataPath As String = vbNullString

        Try
            If Not My.Settings.OverrideFolders Then

                While Not PollRelayWorker.CancellationPending

                    Dim GameProcess As String = GetFilepath(Game.exename)
                    If Not String.IsNullOrEmpty(GameProcess) AndAlso GameProcess.EndsWith(GameDir, StringComparison.OrdinalIgnoreCase) Then
                        SteamAppsPath = GameProcess.Remove(GameProcess.Length - GameDir.Length)
                    End If

                    Dim SteamProcess As String = GetFilepath("Steam")
                    If Not String.IsNullOrEmpty(SteamProcess) Then
                        UserDataPath = SteamProcess.Remove(SteamProcess.Length - "Steam.exe".Length) & "userdata\"
                    End If

                    If IO.Directory.Exists(SteamAppsPath) Then
                        If Not Game.id = 0 Then
                            If IO.Directory.Exists(UserDataPath) Then
                                Exit While
                            End If
                        Else
                            Exit While
                        End If
                    End If

                    Thread.Sleep(Game.PollInterval)
                End While

            Else
                SteamAppsPath = My.Settings.steamapps
                If IO.Directory.Exists(My.Settings.userdata) Then
                    UserDataPath = My.Settings.userdata
                Else
                    Throw New System.Exception("Userdata folder does not exist. Disable ""override folder detection"", or select a correct folder.")
                End If
            End If

            If Not String.IsNullOrEmpty(SteamAppsPath) Then
                Configs.CreateCfgFiles(Game, SteamAppsPath)
            End If
        Catch ex As Exception
            Logger.LogError(ex)
            e.Result = ex
            Return
        End Try

        Dim FindingWindow = True
        Dim Stopwatch As New Stopwatch
        Dim GameHWND As IntPtr = IntPtr.Zero

        If My.Settings.StopWorkingIfGameClosed Then
            Stopwatch.Start()
            While (GameHWND = IntPtr.Zero) And (FindingWindow) And (Not PollRelayWorker.CancellationPending)
                GameHWND = Win32.FindWindowByCaption(IntPtr.Zero, Game.WindowTitle)
                If Stopwatch.Elapsed.Seconds >= Constants.FindWindowTimeoutSeconds Then
                    FindingWindow = False
                    Stopwatch.Stop()
                End If
                Thread.Sleep(Game.PollInterval)
            End While

            If (GameHWND = IntPtr.Zero) And (Not PollRelayWorker.CancellationPending) Then
                Logger.LogError("Cannot find handle of """ & Game.name & """ window.")
            End If
        End If

        Dim GameFolder As String = "", GameCfg As String = ""
        PollRelayWorker.ReportProgress(PollRelayWorkerProgressCode.Working) 'Report that SLAM is working.
        If SteamAppsPath IsNot Nothing Then
            GameFolder = Path.Combine(SteamAppsPath, Game.directory)
            GameCfg = Path.Combine(GameFolder, Game.ToCfg) & "slam_relay.cfg"
        End If
        'If File.Exists(GameCfg) Then
        'File.Delete(GameCfg)
        'End If
        Dim steamuserdir As String = ""
        Dim StopWorking As Boolean = False

        Dim command As String = ""
        Dim value As String
        Dim NumTrack As Integer = -1
        Dim DoLoadTrack As Boolean = False
        Dim RelayCfg As String = ""
        Dim Rnd As New Random()

        Do While Not PollRelayWorker.CancellationPending And Not StopWorking
            Try
                If Game.RelayInUserData Then
                    GameCfg = UserDataCFG(Game, UserDataPath, steamuserdir)
                End If

                If File.Exists(GameCfg) Then
                    Using reader As StreamReader = New StreamReader(GameCfg)
                        RelayCfg = reader.ReadToEnd()
                    End Using

                    command = Misc.recog(RelayCfg, String.Format("bind ""{0}"" ""(.*?)""", My.Settings.Hotkeys(KeysMisc.KeysIndex.RelayKey)))

                    If Not String.IsNullOrEmpty(command) Then
                        If command = "slstop" Then
                            StopWorking = True
                        ElseIf command = "slquit" Then
                            StopWorking = True
                            ClosePending = True
                        ElseIf command.StartsWith("trx") Then 'set track
                            value = command.Remove(0, 3)
                            If IsNumeric(value) Then
                                NumTrack = Convert.ToInt32(value) - 1
                                DoLoadTrack = True
                            End If
                        ElseIf command = "trr" Then 'random track
                            NumTrack = Rnd.Next(0, Game.tracks.Count - 1)
                            DoLoadTrack = True
                        ElseIf command = "trp" Then 'prev track
                            NumTrack -= 1
                            If (NumTrack < 0) Then
                                NumTrack = Game.tracks.Count - 1
                            End If
                            DoLoadTrack = True
                        ElseIf command = "trn" Then 'next track
                            NumTrack += 1
                            If (NumTrack >= Game.tracks.Count) Then
                                NumTrack = 0
                            End If
                            DoLoadTrack = True
                        ElseIf command = "trf" Then 'first track
                            NumTrack = 0
                            DoLoadTrack = True
                        ElseIf command = "trl" Then 'last track
                            NumTrack = Game.tracks.Count - 1
                            DoLoadTrack = True
                        End If
                    End If 'Not String.IsNullOrEmpty(command)
                    File.Delete(GameCfg)
                End If 'File.Exists(GameCfg)

                If DoLoadTrack Then
                    If LoadTrack(Game, NumTrack, SteamAppsPath) Then
                        PollRelayWorker.ReportProgress(PollRelayWorkerProgressCode.TrackChanged, NumTrack)
                    End If
                    DoLoadTrack = False
                End If

                If My.Settings.StopWorkingIfGameClosed Then
                    If (GameHWND <> IntPtr.Zero) Then
                        If (Not Win32.IsWindow(GameHWND)) Then
                            StopWorking = True
                        End If
                    End If
                End If

                Thread.Sleep(Game.PollInterval)
            Catch ex As Exception
                If Not ex.HResult = -2147024864 Then '-2147024864 = "System.IO.IOException: The process cannot access the file because it is being used by another process."
                    Logger.LogError(ex)
                    e.Result = ex
                    Return
                End If
            End Try
        Loop

        If Not String.IsNullOrEmpty(SteamAppsPath) Then
            Configs.DeleteCFGs(Game, SteamAppsPath)
            DeleteVoiceFile(Game, SteamAppsPath)
        End If

    End Sub

    Private Sub DeleteVoiceFile(ByRef Game As SourceGame, ByRef _SteamAppsPath As String)
        Dim voicefile As String = Path.Combine(_SteamAppsPath, Game.directory) & "voice_input.wav"
        Try
            If File.Exists(voicefile) Then
                File.Delete(voicefile)
            End If
        Catch ex As Exception
            Logger.LogError(ex)
        End Try
    End Sub

    Public Function UserDataCFG(Game As SourceGame, UserdataPath As String, ByRef steamuserdir As String) As String
        Dim CFGPath As String = vbNullString
        Dim ConfigPaths() As String = {"\remote\cfg\slam_relay.cfg", "\local\cfg\slam_relay.cfg"}
        Dim RelayPath = If(Game.RelayCfgRemote, ConfigPaths(0), ConfigPaths(1))
        If IO.Directory.Exists(UserdataPath) Then
            If steamuserdir.Length = 0 Then
                For Each userdir As String In System.IO.Directory.GetDirectories(UserdataPath)
                    CFGPath = Path.Combine(userdir, Game.id.ToString) & RelayPath
                    If IO.File.Exists(CFGPath) Then
                        steamuserdir = userdir
                        Exit For
                    End If
                Next
            Else
                CFGPath = Path.Combine(steamuserdir, Game.id.ToString) & RelayPath
            End If
        End If
        Return CFGPath
    End Function

    Private Function GetFilepath(ProcessName As String) As String
        Dim wmiQueryString As String = "Select * from Win32_Process Where Name = """ & ProcessName & ".exe"""

        Using searcher = New ManagementObjectSearcher(wmiQueryString)
            Using results = searcher.Get()

                Dim Process As ManagementObject = results.Cast(Of ManagementObject)().FirstOrDefault()
                If Process IsNot Nothing Then
                    Dim exePath = Process("ExecutablePath")
                    ' Check Process("ExecutablePath") for null before calling ToString.
                    ' Fixes error that occurs if you start steam / csgo while SLAM is searching.
                    Dim procPath = If(exePath IsNot Nothing, exePath.ToString(), vbNullString)
                    If Not String.IsNullOrWhiteSpace(procPath) Then
                        Return Process("ExecutablePath").ToString
                    End If
                End If

            End Using
        End Using

        Return Nothing
    End Function

    Private Sub PollRelayWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles PollRelayWorker.ProgressChanged
        Select Case e.ProgressPercentage
            Case PollRelayWorkerProgressCode.SetupInterface
                SetupInterfaceWorking(True)
            Case PollRelayWorkerProgressCode.Searching
                status = AppStatus.Searching
                ToolStripStatusLabelAppStatus.Text = "Searching..."
            Case PollRelayWorkerProgressCode.Working
                status = AppStatus.Working
                ToolStripStatusLabelAppStatus.Text = "Working."
            Case PollRelayWorkerProgressCode.TrackChanged
                DisplayLoaded(e.UserState)
                Configs.UpdateLoadedTrackInfo(CurrentGame, SteamAppsPath, e.UserState)
        End Select
    End Sub

    Private Sub PollRelayWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles PollRelayWorker.RunWorkerCompleted
        SetupInterfaceWorking(False)
        status = AppStatus.Idle
        ToolStripStatusLabelAppStatus.Text = "Idle."
        ToolStripStatusLabelLoadedTrackName.Text = "No file"
        RefreshTrackList()

        If Not IsNothing(e.Result) Then 'Result is always an exception
            MessageBox.Show(e.Result.Message & " See errorlog.txt for more info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If ClosePending Then
            Me.Close()
        End If
    End Sub

    Private Sub EnableInterface()
        For Each Control In Me.Controls
            Control.Enabled = True
        Next
    End Sub

    Private Sub DisableInterface()
        For Each Control In Me.Controls
            Control.Enabled = False
        Next
    End Sub

    Private Sub DisplayLoaded(ByVal track As Integer)
        For i As Integer = 0 To TrackList.Items.Count - 1
            TrackList.Items(i).SubItems(0).Text = "False"
        Next
        TrackList.Items(track).SubItems(0).Text = "True"

        ToolStripStatusLabelLoadedTrackName.Text = CurrentGame.tracks(track).name
    End Sub

    Private Sub TrackList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TrackList.MouseDoubleClick
        If TrackList.FocusedItem.Bounds.Contains(e.Location) AndAlso status = AppStatus.Working Then
            LoadTrack(CurrentGame, TrackList.SelectedItems(0).Index, SteamAppsPath)
            DisplayLoaded(TrackList.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub ContextRefresh_Click(sender As Object, e As EventArgs) Handles ContextRefresh.Click
        ReloadTracks(CurrentGame)
        RefreshTrackList()
    End Sub

    Private Sub ContextDelete_Click(sender As Object, e As EventArgs) Handles ContextDelete.Click
        If MessageBox.Show("Are you sure you want to delete selected track(s)?", "Delete Track?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            For Each item In TrackList.SelectedItems
                Dim trackname = item.SubItems(1).Text
                Dim FilePath As String = Path.Combine(CurrentGame.libraryname, trackname & CurrentGame.FileExtension)

                If File.Exists(FilePath) Then
                    Try
                        File.Delete(FilePath)
                    Catch ex As Exception
                        Logger.LogError(ex)
                        MsgBox(String.Format("Failed To delete {0}.", FilePath))
                    End Try
                End If
            Next
            ReloadTracks(CurrentGame)
            RefreshTrackList()
            UpdateTracksInGame()
        End If

    End Sub

    Private Sub ContextHotKey_Click(sender As Object, e As EventArgs) Handles ContextHotKey.Click
        Dim SelectKeyDialog As New SelectKey
        If TrackList.SelectedItems.Count = 1 Then
            Dim SelectedIndex = TrackList.SelectedItems(0).Index
            If SelectKeyDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim KeyIsFree As Boolean = True
                If (KeysMisc.CheckKeyIsFreeInSettings(SelectKeyDialog.ChosenKey)) Then
                    For Each track In CurrentGame.tracks
                        If track.hotkey = SelectKeyDialog.ChosenKey Then 'Checking to see if any other track is already using this key
                            KeyIsFree = False
                        End If
                    Next
                Else
                    KeyIsFree = False
                End If

                If KeyIsFree Then
                    CurrentGame.tracks(SelectedIndex).hotkey = SelectKeyDialog.ChosenKey
                    SaveTrackKeys(CurrentGame)
                    ReloadTracks(CurrentGame)
                    RefreshTrackList()
                    UpdateTracksInGame()
                Else
                    MessageBox.Show(String.Format("""{0}"" has already been assigned!", SelectKeyDialog.ChosenKey), "Invalid Key")
                End If

                If CurrentGame.tracks(SelectedIndex).name = RecentLoadedTrackName Then
                    DisplayLoaded(SelectedIndex)
                End If
            End If
        End If
    End Sub

    Private Sub RemoveHotkeyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveHotkeyToolStripMenuItem.Click
        Dim NeedToFakeReload = False
        Dim FakeReloadIndex = -1
        For Each SelectedIndex In TrackList.SelectedItems
            CurrentGame.tracks(SelectedIndex.index).hotkey = vbNullString
            SaveTrackKeys(CurrentGame)
            ReloadTracks(CurrentGame)

            If (CurrentGame.tracks(SelectedIndex.index).name = RecentLoadedTrackName) Then
                NeedToFakeReload = True
                FakeReloadIndex = SelectedIndex.index
            End If
        Next

        RefreshTrackList()
        If (NeedToFakeReload) Then
            DisplayLoaded(FakeReloadIndex)
        End If
        UpdateTracksInGame()
    End Sub

    Private Sub GoToToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoToToolStripMenuItem.Click
        Dim FilePath As String = Path.Combine(CurrentGame.libraryname, CurrentGame.tracks(TrackList.SelectedItems(0).Index).name & CurrentGame.FileExtension)

        Dim Args As String = String.Format("/Select, ""{0}""", FilePath)
        Dim pfi As New ProcessStartInfo("Explorer.exe", Args)

        System.Diagnostics.Process.Start(pfi)
    End Sub

    Private Sub SetVolumeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetVolumeToolStripMenuItem.Click
        Dim SetVolumeDialog As New SetVolume
        Dim NeedToReload As Boolean = False
        Dim ReloadIndex As Integer = -1

        If TrackList.SelectedItems.Count = 1 Then
            SetVolumeDialog.Volume = CurrentGame.tracks(TrackList.SelectedIndices(0)).volume
        End If

        If SetVolumeDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each index In TrackList.SelectedIndices
                CurrentGame.tracks(index).volume = SetVolumeDialog.Volume
                If CurrentGame.tracks(index).name = RecentLoadedTrackName Then
                    NeedToReload = True
                    ReloadIndex = index
                End If
            Next
            SaveTrackKeys(CurrentGame)
            ReloadTracks(CurrentGame)
            RefreshTrackList()
        End If

        If NeedToReload And Running And Status = AppStatus.Working Then
            ReloadLoadedTrack(CurrentGame, SteamAppsPath)
            DisplayLoaded(ReloadIndex)
        End If
    End Sub

    Private Sub TrimToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrimToolStripMenuItem.Click
        If TrackList.SelectedItems.Count = 1 Then
            If File.Exists(NAudioModuleName) Then
                Dim TrimDialog As New TrimForm
                Dim TrackIndex = TrackList.SelectedIndices(0)

                TrimDialog.WavFile = Path.Combine(CurrentGame.libraryname, CurrentGame.tracks(TrackIndex).name & CurrentGame.FileExtension)
                TrimDialog.startpos = CurrentGame.tracks(TrackIndex).startpos
                TrimDialog.endpos = CurrentGame.tracks(TrackIndex).endpos


                If TrimDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                    CurrentGame.tracks(TrackIndex).startpos = TrimDialog.startpos
                    CurrentGame.tracks(TrackIndex).endpos = TrimDialog.endpos
                    SaveTrackKeys(CurrentGame)
                    ReloadTracks(CurrentGame)
                    RefreshTrackList()
                End If

                If CurrentGame.tracks(TrackIndex).name = RecentLoadedTrackName And Running And Status = AppStatus.Working Then
                    ReloadLoadedTrack(CurrentGame, SteamAppsPath)
                    DisplayLoaded(TrackIndex)
                End If
            Else
                MessageBox.Show("You are missing " & NAudioModuleName & vbCrLf & " Cannot trim without it!", "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub RenameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenameToolStripMenuItem.Click
        If (TrackList.SelectedItems.Count = 1) Then
            Dim SelectedTrack As SourceGame.track = CurrentGame.tracks(TrackList.SelectedIndices(0))

            Dim newName As String = InputBox("New name:  ", "Rename track", SelectedTrack.name)

            If newName.Length > 0 Then
                If String.Compare(newName, SelectedTrack.name, StringComparison.OrdinalIgnoreCase) <> 0 Then
                    Try
                        Dim OldFilePath = Path.Combine(CurrentGame.libraryname, SelectedTrack.name & CurrentGame.FileExtension)
                        Dim NewFilePath = Path.Combine(CurrentGame.libraryname, newName & CurrentGame.FileExtension)
                        FileSystem.Rename(OldFilePath, NewFilePath)
                        CurrentGame.tracks(TrackList.SelectedIndices(0)).name = newName

                        SaveTrackKeys(CurrentGame)
                        ReloadTracks(CurrentGame)
                        RefreshTrackList()

                    Catch ex As Exception
                        Select Case ex.HResult
                            Case -2147024809
                                MessageBox.Show("""" & newName & """ contains invalid characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            Case -2146232800
                                MessageBox.Show("A track with that name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            Case -2147024690
                                MessageBox.Show("New track name is too long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            Case Else
                                MessageBox.Show(ex.Message & " See errorlog.txt for more info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Select

                    End Try
                End If
            End If
        End If

        UpdateTracksInGame()
    End Sub

    'Private Async Sub CheckForUpdate()
    '    Dim UpdateText As String

    '    Dim NeatVersion As String = My.Application.Info.Version.ToString.Remove(My.Application.Info.Version.ToString.LastIndexOf("."))

    '    Try

    '        Using client As New HttpClient
    '            Dim UpdateTextTask As Task(Of String) = client.GetStringAsync("http://slam.flankers.net/updates.php?version=" & NeatVersion)
    '            UpdateText = Await UpdateTextTask
    '        End Using

    '    Catch ex As Exception
    '        Return
    '    End Try

    '    Dim NewVersion As New Version("0.0.0.0") 'generic
    '    Dim UpdateURL As String = UpdateText.Split()(1)
    '    If Version.TryParse(UpdateText.Split()(0), NewVersion) Then
    '        If My.Application.Info.Version.CompareTo(NewVersion) < 0 Then
    '            If MessageBox.Show(String.Format("An update ({0}) is available! Click ""OK"" to be taken to the download page.", NewVersion.ToString), "SLAM Update", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
    '                Process.Start(UpdateURL)
    '            End If
    '        End If
    '    End If
    'End Sub
    Private Sub ChangeDirButton_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSettings.Click
        SettingsForm.ShowDialog()
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If (WavWorker.IsBusy) Then
            MessageBox.Show("Importing is in progress. Click ""Stop import"" and close application.")
            e.Cancel = True
        End If

        If Running Then
            StopPoll()
            ClosePending = True
            e.Cancel = True
        End If
    End Sub

    Private Sub LoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadToolStripMenuItem.Click
        If (TrackList.SelectedItems.Count = 1) Then
            LoadTrack(CurrentGame, TrackList.SelectedItems(0).Index, SteamAppsPath)
            DisplayLoaded(TrackList.SelectedItems(0).Index)
            Configs.UpdateLoadedTrackInfo(CurrentGame, SteamAppsPath, TrackList.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If My.Settings.MinimizeToSysTray Then
            If WindowState = FormWindowState.Minimized Then
                SystemTrayIcon.Visible = True
                SystemTrayIcon.BalloonTipText = "Minimized to tray"
                SystemTrayIcon.ShowBalloonTip(50000)
                Hide()
                ShowInTaskbar = False
            End If
        End If
    End Sub

    Private Sub SystemTrayIcon_DoubleClick(sender As Object, e As EventArgs) Handles SystemTrayIcon.DoubleClick
        Show()
        ShowInTaskbar = True
        WindowState = FormWindowState.Normal
        SystemTrayIcon.Visible = False
    End Sub

    Private Sub SystemTrayMenu_OpenHandler(sender As Object, e As EventArgs) Handles SystemTrayMenu_Open.Click
        Show()
        ShowInTaskbar = True
        WindowState = FormWindowState.Normal
        SystemTrayIcon.Visible = False
    End Sub

    Private Sub SystemTrayMenu_ExitHandler(sender As Object, e As EventArgs) Handles SystemTrayMenu_Exit.Click
        If Running Then
            ClosePending = True
            StopPoll()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub ToolStripButtonStartWork_Click(sender As Object, e As EventArgs) Handles ToolStripButtonStartWork.Click
        StartPoll()

        If Not My.Settings.NoHint Then
            Dim HintDlg As New HintDialog
            HintDlg.ShowDialog()

            My.Settings.NoHint = HintDlg.DontShowAgain
            My.Settings.Save()
            '    If MessageBox.Show("Don't forget to type ""exec slam"" in console! Click ""Cancel"" if you don't ever want to see this message again.", "SLAM", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
            '        My.Settings.NoHint = True
            '        My.Settings.Save()
            '    End If
        End If
    End Sub

    Private Sub ToolStripButtonStopWork_Click(sender As Object, e As EventArgs) Handles ToolStripButtonStopWork.Click
        StopPoll()
    End Sub

    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.O And e.Control And Not e.Shift Then
            ImportButton_Click(Nothing, EventArgs.Empty)
        ElseIf e.KeyCode = Keys.Y And e.Control And Not e.Shift Then
            YTButton_Click(Nothing, EventArgs.Empty)
        ElseIf e.KeyCode = Keys.S And e.Control And Not e.Shift Then
            StartStopPoll()
        ElseIf e.KeyCode = Keys.F1 And Not e.Control And Not e.Shift Then
            ShowAboutDlg()
        End If
    End Sub

    Private Sub TrackList_KeyDown(sender As Object, e As KeyEventArgs) Handles TrackList.KeyDown
        If e.KeyCode = Keys.Delete Then
            ContextDelete_Click(ContextDelete, New EventArgs)

        ElseIf e.KeyCode = Keys.Enter And Not e.Control Then
            LoadToolStripMenuItem_Click(LoadToolStripMenuItem, New EventArgs)

        ElseIf e.KeyCode = Keys.Enter And e.Control Then
            GoToToolStripMenuItem_Click(GoToToolStripMenuItem, New EventArgs)

        ElseIf e.KeyCode = Keys.B And e.Control And Not e.Shift Then
            ContextHotKey_Click(ContextHotKey, New EventArgs)

        ElseIf e.KeyCode = Keys.B And e.Control And e.Shift Then
            RemoveHotkeyToolStripMenuItem_Click(RemoveHotkeyToolStripMenuItem, New EventArgs)

        ElseIf (e.KeyCode = Keys.R And e.Control) Or e.KeyCode = Keys.F2 Then
            RenameToolStripMenuItem_Click(RenameToolStripMenuItem, New EventArgs)

        ElseIf e.KeyCode = Keys.V And e.Control And Not e.Shift Then
            SetVolumeToolStripMenuItem_Click(SetVolumeToolStripMenuItem, New EventArgs)

        ElseIf e.KeyCode = Keys.V And e.Control And e.Shift Then
            ResetVolumeToolStripMenuItem_Click(ResetVolumeToolStripMenuItem, New EventArgs)

        ElseIf e.KeyCode = Keys.T And e.Control And Not e.Shift Then
            TrimToolStripMenuItem_Click(TrimToolStripMenuItem, New EventArgs)

        ElseIf e.KeyCode = Keys.T And e.Control And e.Shift Then
            ClearTrimToolStripMenuItem_Click(TrimToolStripMenuItem, New EventArgs)

        ElseIf e.KeyCode = Keys.F5 Then
            ContextRefresh_Click(ContextRefresh, New EventArgs)

        ElseIf e.KeyCode = Keys.A And e.Control Then
            SelectAllToolStripMenuItem_Click(SelectAllToolStripMenuItem, New EventArgs)
        End If
    End Sub

    Private Sub ResetVolumeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetVolumeToolStripMenuItem.Click
        Dim NeedToReload = False
        Dim ReloadIndex = -1

        For Each index In TrackList.SelectedIndices
            CurrentGame.tracks(index).volume = 100
            If CurrentGame.tracks(index).name = RecentLoadedTrackName Then
                NeedToReload = True
                ReloadIndex = index
            End If
        Next
        SaveTrackKeys(CurrentGame)
        ReloadTracks(CurrentGame)
        RefreshTrackList()
        If NeedToReload And Running And Status = AppStatus.Working Then
            ReloadLoadedTrack(CurrentGame, SteamAppsPath)
            DisplayLoaded(ReloadIndex)
        End If
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        For Each Item In TrackList.Items
            Item.Selected = True
        Next
    End Sub

    Private Sub TrackList_MouseUp(sender As Object, e As MouseEventArgs) Handles TrackList.MouseUp
        If e.Button = MouseButtons.Right Then
            For Each Item In TrackContextMenu.Items 'everything invisible
                Item.Visible = False
            Next

            If TrackList.FocusedItem IsNot Nothing Then
                If TrackList.FocusedItem.Bounds.Contains(e.Location) Then
                    SetVolumeToolStripMenuItem.Visible = True 'always visible
                    ResetVolumeToolStripMenuItem.Visible = True
                    ContextDelete.Visible = True
                    ClearTrimToolStripMenuItem.Visible = True
                    RemoveHotkeyToolStripMenuItem.Visible = True
                    GoToToolStripMenuItem.Visible = True

                    If TrackList.SelectedItems.Count = 1 Then
                        ContextHotKey.Visible = True
                        TrimToolStripMenuItem.Visible = True
                        RenameToolStripMenuItem.Visible = True
                    End If

                    If Running And status = AppStatus.Working Then
                        'visible when only one selected AND is running
                        LoadToolStripMenuItem.Visible = True
                    End If

                End If
            End If
            SelectAllToolStripMenuItem.Visible = True
            ContextRefresh.Visible = True
            TrackContextMenu.Show(Cursor.Position)
        End If
    End Sub

    Private Sub ShowAboutDlg()
        Dim about_dlg = New AboutBox
        about_dlg.ShowDialog()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        ShowAboutDlg()
    End Sub

    Private Sub ShortcutsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShortcutsToolStripMenuItem.Click
        MessageBox.Show(String.Join(vbCrLf, HelpShortcuts), "SLAM shortcuts")
    End Sub

    Private Sub IngameCommandsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngameCommandsToolStripMenuItem.Click
        MessageBox.Show(String.Join(vbNewLine, HelpInGame), "In-game commands", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub YoutubedlHomepageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YoutubedlHomepageToolStripMenuItem.Click
        YoutubeDL.OpenHomepage()
    End Sub

    Private Sub YoutubedlCheckVersionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YoutubedlCheckVersionToolStripMenuItem.Click
        Dim version As String = ""
        If (YoutubeDL.GetVersionString(version)) Then
            MessageBox.Show("Version of youtube-dl is: " & version, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Cannot get version of youtube-dl, because: " & vbCrLf & vbCrLf & YoutubeDL.LastException.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ClearTrimToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearTrimToolStripMenuItem.Click
        Dim NeedToReload = False
        Dim ReloadIndex = -1
        For Each i In TrackList.SelectedIndices
            CurrentGame.tracks(i).startpos = 0
            CurrentGame.tracks(i).endpos = 0

            If (CurrentGame.tracks(i).name = RecentLoadedTrackName) Then
                NeedToReload = True
                ReloadIndex = i
            End If
        Next
        SaveTrackKeys(CurrentGame)
        ReloadTracks(CurrentGame)
        RefreshTrackList()

        If NeedToReload And Running And Status = AppStatus.Working Then
            ReloadLoadedTrack(CurrentGame, SteamAppsPath)
            DisplayLoaded(ReloadIndex)
        End If
    End Sub

    Private Sub ToolStripStatusLabelStopImport_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabelStopImport.Click
        WavWorker.CancelAsync()
    End Sub

    Private Sub TrackList_DragDrop(sender As Object, e As DragEventArgs) Handles TrackList.DragDrop
        Dim FileList() As String = e.Data.GetData(DataFormats.FileDrop)
        Dim URLs As String = e.Data.GetData(DataFormats.UnicodeText)
        Dim FileListToImport As New List(Of String)
        Dim NoPlaylist As Boolean = False

        If (FileList IsNot Nothing) Then
            For Each file In FileList
                If Not IO.Directory.Exists(file) Then
                    FileListToImport.Add(file)
                End If
            Next
            DoImportFiles(FileListToImport.ToArray())
        ElseIf (URLs IsNot Nothing) Then
            If (My.Settings.DragAndDropNoPlaylist = DragAndDropNoPlaylist.Ask) Then
                Dim msgboxresult As DialogResult = MessageBox.Show("Do you want to download entire playlist, if video link contains playlist ID?", "Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If msgboxresult = DialogResult.Yes Then
                    NoPlaylist = True
                End If
            ElseIf My.Settings.DragAndDropNoPlaylist = DragAndDropNoPlaylist.Yes Then
                NoPlaylist = True
            End If

            DoImportFilesFromURls(URLs, NoPlaylist)
        End If
    End Sub

    Private Sub TrackList_DragEnter(sender As Object, e As DragEventArgs) Handles TrackList.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Or e.Data.GetDataPresent(DataFormats.UnicodeText) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub SystemTrayMenuStop_Click(sender As Object, e As EventArgs) Handles SystemTrayMenuStop.Click
        StopPoll()
    End Sub

    Private Sub SystemTrayMenuStartClick(sender As Object, e As EventArgs) Handles SystemTrayMenuStart.Click
        StartPoll()
    End Sub
End Class
