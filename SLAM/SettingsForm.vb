Public Class SettingsForm

    Dim MsgKeyAlreadyAssigned = "Chosen key is already assgined."

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Settings2Form()
    End Sub

    Private Sub Settings2Form()
        'UpdateCheckBox.Checked = My.Settings.UpdateCheck
        HintCheckBox.Checked = My.Settings.NoHint
        LogCheckBox.Checked = My.Settings.LogError
        StartEnabledCheckBox.Checked = My.Settings.StartEnabled
        ConTagsCheckBox.Checked = My.Settings.WriteTags
        HoldToPlay.Checked = My.Settings.HoldToPlay
        EnableOverrideBox.Checked = My.Settings.OverrideFolders
        MinimizeToSysTrayCheckBox.Checked = My.Settings.MinimizeToSysTray
        StartMinimizedCheckBox.Checked = My.Settings.StartMinimized
        FFMPEGRadio.Checked = My.Settings.UseFFMPEG
        NAudioRadio.Checked = Not My.Settings.UseFFMPEG
        CheckBoxAutoUpdateYTDL.Checked = My.Settings.AutoUpdateYTDL
        CheckBoxHighlightRecentImportedTracks.Checked = My.Settings.HighlightRecentImportedTracks
        CheckBoxStopWorkingIfGameClosed.Checked = My.Settings.StopWorkingIfGameClosed
        CheckBoxForceConvertTo11kHz.Checked = My.Settings.ForceConvertTo11kHz
        CheckBoxRememberLastWndState.Checked = My.Settings.RememberLastWndPos
        CheckBoxAddPrefixToName.Checked = My.Settings.AddPrefixToName
        CheckBoxNoImportIfYTDLInterrupt.Checked = My.Settings.NoImportYTDLInterrupted

        Select Case My.Settings.DragAndDropNoPlaylist
            Case DragAndDropNoPlaylist.Ask
                RadioButtonNoPlaylistAsk.Checked = True
            Case DragAndDropNoPlaylist.Yes
                RadioButtonNoPlaylistYes.Checked = True
            Case DragAndDropNoPlaylist.No
                RadioButtonNoPlaylistNo.Checked = True
        End Select

        userdatatext.Text = My.Settings.userdata
        steamappstext.Text = My.Settings.steamapps

        For i As Integer = 0 To My.Settings.Hotkeys.Count - 1
            Try
                ListViewHotkeys.Items(i).SubItems(1).Text = My.Settings.Hotkeys(i)
            Catch
            End Try
        Next

        ButtonChangeHighlightBackColor.BackColor = My.Settings.HighlightBackColor
        ButtonChangeHighlightForeColor.BackColor = My.Settings.HighlightBackColor

        ButtonChangeHighlightBackColor.ForeColor = My.Settings.HighlightForeColor
        ButtonChangeHighlightForeColor.ForeColor = My.Settings.HighlightForeColor

    End Sub

    'Private Sub UpdateCheckBox_CheckedChanged(sender As Object, e As EventArgs)
    '    My.Settings.UpdateCheck = UpdateCheckBox.Checked
    '    My.Settings.Save()
    'End Sub

    Private Sub ConTagsCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ConTagsCheckBox.CheckedChanged
        My.Settings.WriteTags = Me.ConTagsCheckBox.Checked
        My.Settings.Save()
    End Sub


    Private Sub HintCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles HintCheckBox.CheckedChanged
        My.Settings.NoHint = HintCheckBox.Checked
        My.Settings.Save()
    End Sub

    Private Sub LogCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles LogCheckBox.CheckedChanged
        My.Settings.LogError = LogCheckBox.Checked
        My.Settings.Save()
    End Sub

    Private Sub StartEnabledCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles StartEnabledCheckBox.CheckedChanged
        My.Settings.StartEnabled = StartEnabledCheckBox.Checked
        My.Settings.Save()
    End Sub

    Private Sub HoldToPlay_CheckedChanged(sender As Object, e As EventArgs) Handles HoldToPlay.CheckedChanged
        My.Settings.HoldToPlay = HoldToPlay.Checked
        My.Settings.Save()
    End Sub

    Private Sub EnableOverrideBox_CheckedChanged(sender As Object, e As EventArgs) Handles EnableOverrideBox.CheckedChanged
        My.Settings.OverrideFolders = EnableOverrideBox.Checked
        My.Settings.Save()

        For Each control In OverrideGroup.Controls
            control.enabled = EnableOverrideBox.Checked
        Next
        EnableOverrideBox.Enabled = True
    End Sub

    Private Sub ShowFolderSelector(name As String, ByRef setting As String)
        Dim ChangeDirDialog As New FolderBrowserDialog
        ChangeDirDialog.Description = String.Format("Select your {0} folder:", name)
        ChangeDirDialog.ShowNewFolderButton = False

        If ChangeDirDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            setting = ChangeDirDialog.SelectedPath & "\"
            My.Settings.Save()
        End If

    End Sub

    Private Sub FindsteamappsButton_Click(sender As Object, e As EventArgs) Handles FindsteamappsButton.Click
        ShowFolderSelector("steamapps", My.Settings.steamapps)
        steamappstext.Text = My.Settings.steamapps
    End Sub

    Private Sub FinduserdataButton_Click(sender As Object, e As EventArgs) Handles FinduserdataButton.Click
        ShowFolderSelector("userdata", My.Settings.userdata)
        userdatatext.Text = My.Settings.userdata
    End Sub

    Private Sub MinimizeToSysTrayCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles MinimizeToSysTrayCheckBox.CheckedChanged
        My.Settings.MinimizeToSysTray = MinimizeToSysTrayCheckBox.Checked
        My.Settings.Save()
    End Sub

    Private Sub StartMinimizedCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles StartMinimizedCheckBox.CheckedChanged
        My.Settings.StartMinimized = StartMinimizedCheckBox.Checked
        My.Settings.Save()
    End Sub

    Private Sub FFMPEGRadio_CheckedChanged(sender As Object, e As EventArgs) Handles FFMPEGRadio.CheckedChanged
        My.Settings.UseFFMPEG = FFMPEGRadio.Checked
        My.Settings.Save()
    End Sub

    Private Sub ButtonClearKey_Click(sender As Object, e As EventArgs) Handles ButtonClearKey.Click
        For Each i In ListViewHotkeys.SelectedIndices
            If (i <> 0) Then
                ListViewHotkeys.Items(i).SubItems(1).Text = ""
                My.Settings.Hotkeys(i) = ""
            End If
        Next
        My.Settings.Save()
    End Sub

    Private Sub ButtonResetKey_Click(sender As Object, e As EventArgs) Handles ButtonResetKey.Click
        For Each i In ListViewHotkeys.SelectedIndices
            ListViewHotkeys.Items(i).SubItems(1).Text = ListViewHotkeys.Items(i).Tag
            My.Settings.Hotkeys(i) = ListViewHotkeys.Items(i).Tag
        Next
        My.Settings.Save()
    End Sub

    Private Sub ListViewHotkeys_DoubleClick(sender As Object, e As EventArgs) Handles ListViewHotkeys.DoubleClick
        If ListViewHotkeys.SelectedItems.Count = 1 Then
            Dim SelectKeyDialog As New SelectKey
            If SelectKeyDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                If Not SelectKeyDialog.ChosenKey = My.Settings.Hotkeys(ListViewHotkeys.SelectedIndices(0)) Then
                    If KeysMisc.CheckKeyIsFreeInSettings(SelectKeyDialog.ChosenKey) Then
                        My.Settings.Hotkeys(ListViewHotkeys.SelectedIndices(0)) = SelectKeyDialog.ChosenKey
                        My.Settings.Save()
                        ListViewHotkeys.SelectedItems(0).SubItems(1).Text = SelectKeyDialog.ChosenKey
                    Else
                        MessageBox.Show(MsgKeyAlreadyAssigned)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub CheckBoxAutoUpdateYTDL_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAutoUpdateYTDL.CheckedChanged
        My.Settings.AutoUpdateYTDL = CheckBoxAutoUpdateYTDL.Checked
        My.Settings.Save()
    End Sub

    Private Sub CheckBoxHighlightNewTracks_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxHighlightRecentImportedTracks.CheckedChanged
        My.Settings.HighlightRecentImportedTracks = CheckBoxHighlightRecentImportedTracks.Checked
        My.Settings.Save()
    End Sub

    Private Sub RadioButtonNoPlaylistYes_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonNoPlaylistYes.CheckedChanged
        My.Settings.DragAndDropNoPlaylist = DragAndDropNoPlaylist.Yes
        My.Settings.Save()
    End Sub

    Private Sub RadioButtonNoPlaylistAsk_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonNoPlaylistAsk.CheckedChanged
        My.Settings.DragAndDropNoPlaylist = DragAndDropNoPlaylist.Ask
        My.Settings.Save()
    End Sub

    Private Sub RadioButtonNoPlaylistNo_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonNoPlaylistNo.CheckedChanged
        My.Settings.DragAndDropNoPlaylist = DragAndDropNoPlaylist.No
        My.Settings.Save()
    End Sub

    Private Sub CheckBoxStopWorkingIfGameClosed_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxStopWorkingIfGameClosed.CheckedChanged
        My.Settings.StopWorkingIfGameClosed = CheckBoxStopWorkingIfGameClosed.Checked
        My.Settings.Save()
    End Sub
    Private Sub ButtonResetSettings_Click(sender As Object, e As EventArgs) Handles ButtonResetSettings.Click
        Dim result = MessageBox.Show("Are you sure?", "Reset SLAM settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            My.Settings.Reset()
            Settings2Form()
        End If
    End Sub

    Private Sub CheckBoxForceConvertTo11K_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForceConvertTo11kHz.CheckedChanged
        My.Settings.ForceConvertTo11kHz = CheckBoxForceConvertTo11kHz.Checked
        My.Settings.Save()
    End Sub
    Private Sub ButtonChangeHighlightColor_Click(sender As Object, e As EventArgs) Handles ButtonChangeHighlightBackColor.Click
        Dim ColorDlg As New ColorDialog
        ColorDlg.Color = My.Settings.HighlightBackColor
        ColorDlg.FullOpen = True
        If ColorDlg.ShowDialog() = DialogResult.OK Then
            ButtonChangeHighlightBackColor.BackColor = ColorDlg.Color
            ButtonChangeHighlightForeColor.BackColor = ColorDlg.Color
            My.Settings.HighlightBackColor = ColorDlg.Color
            My.Settings.Save()
        End If
    End Sub

    Private Sub ButtonChangeHighlightForeColor_Click(sender As Object, e As EventArgs) Handles ButtonChangeHighlightForeColor.Click
        Dim ColorDlg As New ColorDialog
        ColorDlg.Color = My.Settings.HighlightBackColor
        ColorDlg.FullOpen = True
        If ColorDlg.ShowDialog() = DialogResult.OK Then
            ButtonChangeHighlightBackColor.ForeColor = ColorDlg.Color
            ButtonChangeHighlightForeColor.ForeColor = ColorDlg.Color
            My.Settings.HighlightForeColor = ColorDlg.Color
            My.Settings.Save()
        End If
    End Sub

    Private Sub CheckBoxRememberLastWndState_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRememberLastWndState.CheckedChanged
        My.Settings.RememberLastWndPos = CheckBoxRememberLastWndState.Checked
        My.Settings.Save()
    End Sub

    Private Sub CheckBoxAddPrefixToName_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAddPrefixToName.CheckedChanged
        My.Settings.AddPrefixToName = CheckBoxAddPrefixToName.Checked
        My.Settings.Save()
    End Sub

    Private Sub CheckBoxNoImportIfYTDLInterrupt_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxNoImportIfYTDLInterrupt.CheckedChanged
        My.Settings.NoImportYTDLInterrupted = CheckBoxNoImportIfYTDLInterrupt.Checked
        My.Settings.Save()
    End Sub
End Class