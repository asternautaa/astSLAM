Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Xml

Class YoutubeDL
    Private Shared YTDLProcess As New Process

    Private Shared YTDLModuleName = "youtube-dl.exe"
    Private Shared YTDLHomepage = "https://ytdl-org.github.io/youtube-dl/index.html"
    Private Shared YTDLDownloadModuleLink = "http://yt-dl.org/downloads/latest/youtube-dl.exe"
    Private Shared YTDLDownloadLink = "http://ytdl-org.github.io/youtube-dl/download.html"

    Private Shared ArgVersion As String = "--version"
    Private Shared ArgNoPlaylist As String = "--no-playlist"
    Private Shared ArgFormat As String = "-f"
    Private Shared ArgOutput As String = "-o"
    Private Shared ArgIgnoreErrors As String = "-i"
    Private Shared ArgUpdate As String = "-U"

    Public Shared FormatBest As String = "best"
    Public Shared FormatWorst As String = "worst"
    Public Shared FormatBestAudio As String = "bestaudio"
    Public Shared FormatWorstAudio As String = "worstaudio"
    Public Shared FormatBestVideo As String = "bestvideo"
    Public Shared FormatWorstVideo As String = "worstvideo"

    Private Shared LastEx As Exception = Nothing

    Public Shared ReadOnly Property LastException As Exception
        Get
            Return LastEx
        End Get
    End Property

    Shared Sub New()
        YTDLProcess.StartInfo.CreateNoWindow = True
        YTDLProcess.StartInfo.FileName = YTDLModuleName
        YTDLProcess.StartInfo.UseShellExecute = False
        YTDLProcess.StartInfo.RedirectStandardOutput = True
    End Sub

    Public Shared ReadOnly Property ModuleExists As Boolean
        Get
            Return IO.File.Exists(YTDLModuleName)
        End Get
    End Property

    Public Shared ReadOnly Property OperationInProgress As Boolean
        Get
            Return Not YTDLProcess.HasExited
        End Get
    End Property

    Public Shared Sub OpenHomepage()
        Process.Start(YTDLHomepage)
    End Sub

    Public Shared Sub StopOperation()
        If OperationInProgress Then YTDLProcess.Kill()
    End Sub

    Public Shared Function GetLatestVersionString(ByRef outputVersion As String) As Boolean
        Dim result As Boolean = True
        Dim webClient As New WebClient
        Dim htmlCode As String = ""
        Dim xmlDocument As New XmlDocument
        Try
            htmlCode = webClient.DownloadString(YTDLDownloadLink)
            Dim regex As New Regex("\d{4}\.\d{2}\.\d{2}")
            Dim match As Match = regex.Match(htmlCode)
            outputVersion = match.ToString()
        Catch ex As Exception
            LastEx = ex
            result = False
        End Try
        Return result
    End Function
    Public Shared Function DownloadModule() As Boolean
        Dim result As Boolean = True
        Dim webClient As New WebClient
        Try
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            webClient.DownloadFile(YTDLDownloadModuleLink, YTDLModuleName)
        Catch ex As Exception
            result = False
            LastEx = ex
        End Try
        Return result
    End Function

    Public Shared Function GetVersionString(ByRef output As String) As Boolean
        Dim result As Boolean = True
        YTDLProcess.StartInfo.Arguments = ArgVersion
        Try
            YTDLProcess.Start()
            While Not YTDLProcess.HasExited
                output += YTDLProcess.StandardOutput.ReadLine()
            End While
        Catch ex As Exception
            LastEx = ex
            result = False
        End Try
        Return result
    End Function

    Public Shared Function DownloadVideo(ByVal url As String, ByVal format As String, ByVal outputFilename As String, Optional ByVal noPlaylist As Boolean = True, Optional ByVal showConsole As Boolean = True) As Boolean
        Dim result As Boolean = True
        YTDLProcess.StartInfo.Arguments = ArgIgnoreErrors & " " & ArgFormat & " " & format & " " & ArgOutput & " " & outputFilename _
            & " " & If(noPlaylist, ArgNoPlaylist, "") & " """ & url & """"

        If (showConsole) Then
            YTDLProcess.StartInfo.CreateNoWindow = False
            YTDLProcess.StartInfo.RedirectStandardOutput = False
        End If

        Try
            YTDLProcess.Start()
            YTDLProcess.WaitForExit()
        Catch ex As Exception
            LastEx = ex
            result = False
        End Try

        If (showConsole) Then
            YTDLProcess.StartInfo.CreateNoWindow = True
            YTDLProcess.StartInfo.RedirectStandardOutput = True
        End If
        Return result
    End Function

    Public Shared Function DownloadVideos(ByVal urls As String(), ByVal format As String, ByVal outputFilename As String, Optional ByVal noPlaylist As Boolean = True, Optional ByVal showConsole As Boolean = True) As Boolean
        Dim result As Boolean = True
        YTDLProcess.StartInfo.Arguments = ArgIgnoreErrors & " " & If(noPlaylist, ArgNoPlaylist, "") & " " & ArgFormat & " " & format & " " & ArgOutput & " " & outputFilename _
            & " " & String.Join(" ", urls)

        If (showConsole) Then
            YTDLProcess.StartInfo.CreateNoWindow = False
            YTDLProcess.StartInfo.RedirectStandardOutput = False
        End If

        Try
            YTDLProcess.Start()
            YTDLProcess.WaitForExit()
        Catch ex As Exception
            LastEx = ex
            result = False
        End Try

        If (showConsole) Then
            YTDLProcess.StartInfo.CreateNoWindow = True
            YTDLProcess.StartInfo.RedirectStandardOutput = True
        End If
        Return result
    End Function
End Class
