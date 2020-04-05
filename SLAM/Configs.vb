Imports System.IO

Class Configs
    Private Enum SlamFilesIndex As Integer
        Main
        TrackList
        TrackListTags
        TrackListEcho
        Help
        Relay
        CurrentTrack
        SayCurrentTrack
        SayTeamCurrentTrack
    End Enum

    Private Shared SlamFiles As String() = {
            "slam.cfg",
            "slam_tracklist.cfg",
            "slam_tracklist_tags.cfg",
            "slam_tracklist_echo.cfg",
            "slam_help.cfg",
            "slam_relay.cfg",
            "slam_curtrack.cfg",
            "slam_saycurtrack.cfg",
            "slam_sayteamcurtrack.cfg"
    }

    Public Shared Sub GetDirAndConfigFolder(ByRef Game As SourceGame, SteamAppsPath As String, ByRef GameDir As String, ByRef GameCfgFolder As String)
        GameDir = Path.Combine(SteamAppsPath, Game.directory)
        GameCfgFolder = Path.Combine(GameDir, Game.ToCfg)
    End Sub

    Public Shared Sub CreateTracksConfig(ByRef Game As SourceGame, SteamAppsPath As String)
        Dim GameDir As String = "", GameCfgFolder As String = ""
        GetDirAndConfigFolder(Game, SteamAppsPath, GameDir, GameCfgFolder)
        CreateTrackListCfg(Game, GameCfgFolder & SlamFiles(SlamFilesIndex.TrackList))
        If My.Settings.WriteTags Then
            CreateTrackListTagsCfg(Game, GameCfgFolder & SlamFiles(SlamFilesIndex.TrackListTags))
        End If
        CreateTrackListEchoCfg(Game, GameCfgFolder & SlamFiles(SlamFilesIndex.TrackListEcho))
    End Sub
    Private Shared Sub CreateTrackListCfg(ByRef Game As SourceGame, path As String)
        Using slam_all_tracks_cfg As StreamWriter = New StreamWriter(path)
            For i As Integer = 0 To Game.tracks.Count() - 1
                slam_all_tracks_cfg.WriteLine("alias {0} ""bind {1} trx{0}; slam_updatecfg; echo [SLAM] Loaded: {2}""", i + 1, My.Settings.Hotkeys(KeysMisc.KeysIndex.RelayKey), Game.tracks(i).name)
                If (KeysMisc.CheckKeyIsFreeInSettings(Game.tracks(i).hotkey)) Then
                    slam_all_tracks_cfg.WriteLine("bind {0} ""bind {1} key{0}; slam_updatecfg; echo [SLAM] Loaded: {3}""", Game.tracks(i).hotkey, My.Settings.Hotkeys(KeysMisc.KeysIndex.RelayKey), i + 1, Game.tracks(i).name)
                End If
            Next
            slam_all_tracks_cfg.WriteLine("")
        End Using
    End Sub

    Private Shared Sub CreateTrackListTagsCfg(ByRef Game As SourceGame, path As String)
        Using slam_all_tracks_cfg As StreamWriter = New StreamWriter(path)
            For i As Integer = 0 To Game.tracks.Count() - 1
                For Each TrackTag In Game.tracks(i).tags
                    slam_all_tracks_cfg.WriteLine("alias {0} ""bind {1} trx{2}; slam_updatecfg; echo [SLAM] Loaded: {3}""", TrackTag, My.Settings.Hotkeys(KeysMisc.KeysIndex.RelayKey), i + 1, Game.tracks(i).name)
                Next
            Next
            slam_all_tracks_cfg.WriteLine("")
        End Using
    End Sub

    Private Shared Sub CreateTrackListEchoCfg(ByRef Game As SourceGame, path As String)
        Using slam_tracklist_cfg As StreamWriter = New StreamWriter(path)
            slam_tracklist_cfg.WriteLine("echo ""-------------------- Tracks --------------------""")
            For i As Integer = 0 To Game.tracks.Count() - 1
                slam_tracklist_cfg.WriteLine("echo ""{0}. {1}""", i + 1, Game.tracks(i).name)
            Next
            slam_tracklist_cfg.WriteLine("echo ""----------------------------------------------""")
        End Using
    End Sub

    Private Shared Sub CreateHelpCfg(ByRef Game As SourceGame, path As String)
        Using slam_help As StreamWriter = New StreamWriter(path)
            slam_help.WriteLine("echo ""----------------------------------------------""")
            For Each Line In HelpInGame
                slam_help.WriteLine("echo ""{0}""", Line)
            Next
            slam_help.WriteLine("echo ""----------------------------------------------""")
        End Using
    End Sub
    Public Shared Sub CreateCfgFiles(Game As SourceGame, SteamappsPath As String)
        Dim GameDir As String = "", GameCfgFolder As String = ""
        GetDirAndConfigFolder(Game, SteamappsPath, GameDir, GameCfgFolder)

        If Not IO.Directory.Exists(GameCfgFolder) Then
            Throw New System.Exception("Steamapps folder is incorrect. Disable ""override folder detection"", or select a correct folder.")
        End If

        CreateTracksConfig(Game, SteamappsPath)
        CreateHelpCfg(Game, GameCfgFolder & SlamFiles(SlamFilesIndex.Help))

        'slam.cfg
        Using slam_cfg As StreamWriter = New StreamWriter(GameCfgFolder & SlamFiles(SlamFilesIndex.Main))
            slam_cfg.WriteLine("exec {0}", SlamFiles(SlamFilesIndex.TrackList))
            If My.Settings.WriteTags Then
                slam_cfg.WriteLine("exec {0}", SlamFiles(SlamFilesIndex.TrackListTags))
            End If
            slam_cfg.WriteLine("alias slam_listtracks ""exec {0}""", SlamFiles(SlamFilesIndex.TrackListEcho))
            slam_cfg.WriteLine("alias list slam_listtracks")
            slam_cfg.WriteLine("alias tracks slam_listtracks")
            slam_cfg.WriteLine("alias la slam_listtracks")
            slam_cfg.WriteLine("alias slist slam_listtracks")
            slam_cfg.WriteLine("alias slam_play slam_play_on")
            slam_cfg.WriteLine("alias slam_play_on ""alias slam_play slam_play_off; voice_inputfromfile 1; voice_loopback 1; +voicerecord; bind {0} slplaying; slam_updatecfg;""", My.Settings.Hotkeys(KeysMisc.KeysIndex.RelayKey))
            slam_cfg.WriteLine("alias slam_play_off ""alias slam_play slam_play_on; -voicerecord; voice_inputfromfile 0; voice_loopback 0;""")
            slam_cfg.WriteLine("alias slam_stop ""bind {0} slstop; slam_updatecfg;""", My.Settings.Hotkeys(KeysMisc.KeysIndex.RelayKey))
            slam_cfg.WriteLine("alias slam_quit ""bind {0} slquit; slam_updatecfg;""", My.Settings.Hotkeys(KeysMisc.KeysIndex.RelayKey))
            slam_cfg.WriteLine("alias slam_updatecfg ""host_writeconfig {1} {0}""", If(Game.RelayCfgNeedFullWrite, "full", ""), SlamFiles(SlamFilesIndex.Relay).Replace(".cfg", ""))
            If My.Settings.HoldToPlay Then
                slam_cfg.WriteLine("alias +slam_hold_play slam_play_on")
                slam_cfg.WriteLine("alias -slam_hold_play slam_play_off")
                slam_cfg.WriteLine("bind {0} +slam_hold_play", My.Settings.Hotkeys(KeysMisc.KeysIndex.PlayTrack))
            Else
                slam_cfg.WriteLine("bind {0} slam_play", My.Settings.Hotkeys(KeysMisc.KeysIndex.PlayTrack))
            End If
            slam_cfg.WriteLine("")
            slam_cfg.WriteLine("alias slam_curtrack ""exec {0}""", SlamFiles(SlamFilesIndex.CurrentTrack))
            slam_cfg.WriteLine("alias slam_saycurtrack ""exec {0}""", SlamFiles(SlamFilesIndex.SayCurrentTrack))
            slam_cfg.WriteLine("alias slam_sayteamcurtrack ""exec {0}""", SlamFiles(SlamFilesIndex.SayTeamCurrentTrack))
            slam_cfg.WriteLine("alias slam_help ""exec {0}""", SlamFiles(SlamFilesIndex.Help))
            slam_cfg.WriteLine("")
            slam_cfg.WriteLine("alias slam_random ""bind {0} trr; slam_updatecfg;""", My.Settings.Hotkeys(KeysMisc.KeysIndex.RelayKey))
            slam_cfg.WriteLine("alias slam_prev ""bind {0} trp; slam_updatecfg;""", My.Settings.Hotkeys(KeysMisc.KeysIndex.RelayKey))
            slam_cfg.WriteLine("alias slam_next ""bind {0} trn; slam_updatecfg;""", My.Settings.Hotkeys(KeysMisc.KeysIndex.RelayKey))
            slam_cfg.WriteLine("alias slam_first ""bind {0} trf; slam_updatecfg;""", My.Settings.Hotkeys(KeysMisc.KeysIndex.RelayKey))
            slam_cfg.WriteLine("alias slam_last ""bind {0} trl; slam_updatecfg;""", My.Settings.Hotkeys(KeysMisc.KeysIndex.RelayKey))
            slam_cfg.WriteLine("alias srndm ""slam_random""")
            slam_cfg.WriteLine("alias sprev ""slam_prev""")
            slam_cfg.WriteLine("alias snext ""slam_next""")
            slam_cfg.WriteLine("alias sfirst ""slam_first""")
            slam_cfg.WriteLine("alias slast ""slam_last""")

            slam_cfg.WriteLine("")

            If Not KeysMisc.KeyIsEmpty(KeysMisc.KeysIndex.PrevTrack) Then
                slam_cfg.WriteLine("bind {0} slam_prev", My.Settings.Hotkeys(KeysMisc.KeysIndex.PrevTrack))
            End If

            If Not KeysMisc.KeyIsEmpty(KeysMisc.KeysIndex.NextTrack) Then
                slam_cfg.WriteLine("bind {0} slam_next", My.Settings.Hotkeys(KeysMisc.KeysIndex.NextTrack))
            End If

            If Not KeysMisc.KeyIsEmpty(KeysMisc.KeysIndex.FirstTrack) Then
                slam_cfg.WriteLine("bind {0} slam_first", My.Settings.Hotkeys(KeysMisc.KeysIndex.FirstTrack))
            End If

            If Not KeysMisc.KeyIsEmpty(KeysMisc.KeysIndex.LastTrack) Then
                slam_cfg.WriteLine("bind {0} slam_last", My.Settings.Hotkeys(KeysMisc.KeysIndex.LastTrack))
            End If

            If Not KeysMisc.KeyIsEmpty(KeysMisc.KeysIndex.RandomTrack) Then
                slam_cfg.WriteLine("bind {0} slam_random", My.Settings.Hotkeys(KeysMisc.KeysIndex.RandomTrack))
            End If

            If Not KeysMisc.KeyIsEmpty(KeysMisc.KeysIndex.ShowSLAM) Then
                slam_cfg.WriteLine("bind {0} slam_show", My.Settings.Hotkeys(KeysMisc.KeysIndex.ShowSLAM))
            End If

            slam_cfg.WriteLine("alias slam_show ""bind {0} slshow; slam_updatecfg;""", My.Settings.Hotkeys(KeysMisc.KeysIndex.RelayKey))
            slam_cfg.WriteLine("alias slam_11khz_on ""bind {0} sl11on; slam_updatecfg;""", My.Settings.Hotkeys(KeysMisc.KeysIndex.RelayKey))
            slam_cfg.WriteLine("alias slam_11khz_off ""bind {0} sl11off; slam_updatecfg;""", My.Settings.Hotkeys(KeysMisc.KeysIndex.RelayKey))
            slam_cfg.WriteLine("voice_enable 1; voice_modenable 1; voice_forcemicrecord 0; con_enable 1{0}", If(Game.VoiceFadeOut, "; voice_fadeouttime 0.0", ""))
            slam_cfg.WriteLine("echo ""[SLAM] Initialised""")
        End Using

        'other cfgs
        UpdateLoadedTrackInfo(Game, SteamappsPath)
    End Sub

    Public Shared Sub UpdateLoadedTrackInfo(ByRef Game As SourceGame, SteamappsPath As String, Optional i As Integer = -1)
        'Dim GameDir As String = Path.Combine(SteamAppsPath, Game.directory)
        'Dim GameCfgFolder As String = Path.Combine(GameDir, Game.ToCfg)
        Dim GameDir As String = "", GameCfgFolder As String = "", TrackName As String = If(i = -1, "", Game.tracks(i).name)
        GetDirAndConfigFolder(Game, SteamappsPath, GameDir, GameCfgFolder)
        Using slam_curtrack As StreamWriter = New StreamWriter(GameCfgFolder & SlamFiles(SlamFilesIndex.CurrentTrack))
            slam_curtrack.WriteLine("echo ""[SLAM] {0}""", If(TrackName = "", "No track loaded", "Current track: " & TrackName))
        End Using
        Using slam_saycurtrack As StreamWriter = New StreamWriter(GameCfgFolder & SlamFiles(SlamFilesIndex.SayCurrentTrack))
            slam_saycurtrack.WriteLine("say ""{0}""", If(TrackName = "", "No track loaded", TrackName))
        End Using
        Using slam_sayteamcurtrack As StreamWriter = New StreamWriter(GameCfgFolder & SlamFiles(SlamFilesIndex.SayTeamCurrentTrack))
            slam_sayteamcurtrack.WriteLine("say_team ""{0}""", If(TrackName = "", "No track loaded", TrackName))
        End Using
    End Sub

    Public Shared Sub DeleteCFGs(ByRef Game As SourceGame, ByVal SteamappsPath As String)
        'Dim GameDir As String = Path.Combine(SteamAppsPath, Game.directory)
        'Dim GameCfgFolder As String = Path.Combine(GameDir, Game.ToCfg)
        Dim GameDir As String = "", GameCfgFolder As String = ""
        GetDirAndConfigFolder(Game, SteamappsPath, GameDir, GameCfgFolder)

        Try
            For Each FileName In SlamFiles
                If File.Exists(GameCfgFolder & FileName) Then
                    File.Delete(GameCfgFolder & FileName)
                End If
            Next
        Catch ex As Exception
            Logger.LogError(ex)
        End Try

    End Sub
End Class
