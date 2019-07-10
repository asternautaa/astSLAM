Module Constants

    Public Const NAudioModuleName = "NAudio.dll"
    Public Const NRecoModuleName = "NReco.VideoConverter.dll"
    'Public Const JSONModuleName = "Newtonsoft.Json.dll"
    Public Const YoutubeDLModuleName = "youtube-dl.exe"

    Public Const YTDLOutputTemplate = "temp\%(title)s.%(ext)s"

    Public Const FindWindowTimeoutSeconds = 10

    Public Const DefaultExeName = "hl2"
    Public Const DefaultAudioExtension = ".wav"
    Public Const DefaultSampleRate = SampleRate.Rate22kHz
    Public Const DefaultBits = 16
    Public Const DefaultChannels = 1
    Public Const DefaultPollInterval = 100

    Public ReadOnly DefaultTagsBlacklist() As String = {
        "slam",
        "slam_listtracks",
        "list",
        "slist",
        "tracks",
        "la",
        "slam_play",
        "slam_play_on",
        "slam_play_off",
        "slam_updatecfg",
        "slam_curtrack",
        "slam_saycurtrack",
        "slam_sayteamcurtrack",
        "slam_help",
        "slam_prev",
        "slam_next",
        "slam_first",
        "slam_last",
        "slam_random",
        "sprev",
        "snext",
        "sfirst",
        "slast",
        "srndm",
        "slam_stop",
        "slam_quit"
    }

    Public ReadOnly HelpInGame() As String =
       {
           "SLAM commands:",
           "'slam_help' - You're reading this now :D",
           "'slam_listtracks', 'list', 'slist', 'tracks', 'la' - Display track list.",
           "'[num of track]' - Change track by its number.",
           "'slam_curtrack' - Prints current track name.",
           "'slam_saycurtrack' - Prints current track name into chat.",
           "'slam_sayteamcurtrack' - Prints current track name into team chat.",
           "'slam_prev', 'sprev' - Load previous track.",
           "'slam_next', 'snext' - Load next track.",
           "'slam_first', 'sfirst' - Load first track.",
           "'slam_last', 'slast' - Load last track.",
           "'slam_random', 'srndm' - Load random track.",
           "'slam_stop' - Stop work.",
           "'slam_quit' - Stop work and quit SLAM."
       }

    Public ReadOnly HelpShortcuts() As String =
       {
            "F1 - About",
            "F5 - Refresh track list",
            "Del - Remove selected tracks. ",
            "Enter - Load track (if working)",
            "Ctrl+Enter - Open track in file explorer",
            "Ctrl+A - Select all tracks in list",
            "Ctrl+B - Set hotkey",
            "Ctrl+O - Import track locally",
            "Ctrl+R - Rename track",
            "Ctrl+S - Start/stop work",
            "Ctrl+T - Set trim",
            "Ctrl+V - Set volume",
            "Ctrl+Y - Import via youtube-dl",
            "Ctrl+Shift+B - Clear hotkey",
            "Ctrl+Shift+T - Clear trim",
            "Ctrl+Shift+V - Reset volume"
       }

End Module
