Imports System.IO

Class Logger
    Public Shared Sub LogError(ByVal ex As Exception)
        LogError(ex.ToString())
    End Sub

    Public Shared Sub LogError(ByVal str As String)
        If My.Settings.LogError Then
            Using log As StreamWriter = New StreamWriter("errorlog.txt", True)
                log.WriteLine("--------------------{0} UTC--------------------", DateTime.Now.ToUniversalTime)
                log.WriteLine(str)
            End Using
        End If
    End Sub
End Class
