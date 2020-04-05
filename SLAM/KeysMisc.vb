Class KeysMisc
    Public Shared Function CheckKeyIsFreeInSettings(ByVal key As String) As Boolean
        Dim result As Boolean = True
        For Each hotkey In My.Settings.Hotkeys
            If hotkey = key Then
                result = False
                Exit For
            End If
        Next
        Return result
    End Function

    Public Shared Function KeyIsEmpty(ByVal keyindex As KeysIndex)
        Return (String.IsNullOrEmpty(My.Settings.Hotkeys(keyindex)) Or String.IsNullOrWhiteSpace(My.Settings.Hotkeys(keyindex)))
    End Function

    Public Enum KeysIndex
        RelayKey
        PlayTrack
        RandomTrack
        PrevTrack
        NextTrack
        FirstTrack
        LastTrack
        ShowSLAM
    End Enum

End Class
