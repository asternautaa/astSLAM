<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.TrackList = New System.Windows.Forms.ListView()
        Me.LoadedCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TrackCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HotKeyCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.VolumeCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Trimmed = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TagsCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImportDialog = New System.Windows.Forms.OpenFileDialog()
        Me.WavWorker = New System.ComponentModel.BackgroundWorker()
        Me.PollRelayWorker = New System.ComponentModel.BackgroundWorker()
        Me.TrackContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LoadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.GoToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextHotKey = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveHotkeyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetVolumeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetVolumeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrimToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearTrimToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemTrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.SystemTrayMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SystemTrayMenu_Open = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemTrayMenuStart = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemTrayMenuStop = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SystemTrayMenu_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelTrackCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelSeparator1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelAppStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelSeparator2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelLoaded = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelLoadedTrackName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelSeparator3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelImportProgress = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBarImport = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabelStopImport = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.GameSelector = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSplitButtonImport = New System.Windows.Forms.ToolStripSplitButton()
        Me.ViaYoutubedlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButtonStartWork = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonStopWork = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSettings = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ShortcutsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngameCommandsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.YoutubedlHomepageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.YoutubedlCheckVersionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.YTDLUpdateWorker = New System.ComponentModel.BackgroundWorker()
        Me.TrackContextMenu.SuspendLayout()
        Me.SystemTrayMenu.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrackList
        '
        Me.TrackList.AllowDrop = True
        Me.TrackList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrackList.AutoArrange = False
        Me.TrackList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.LoadedCol, Me.TrackCol, Me.HotKeyCol, Me.VolumeCol, Me.Trimmed, Me.TagsCol})
        Me.TrackList.FullRowSelect = True
        Me.TrackList.HideSelection = False
        Me.TrackList.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TrackList.Location = New System.Drawing.Point(10, 41)
        Me.TrackList.Margin = New System.Windows.Forms.Padding(1)
        Me.TrackList.Name = "TrackList"
        Me.TrackList.Size = New System.Drawing.Size(564, 396)
        Me.TrackList.TabIndex = 4
        Me.TrackList.UseCompatibleStateImageBehavior = False
        Me.TrackList.View = System.Windows.Forms.View.Details
        '
        'LoadedCol
        '
        Me.LoadedCol.Text = "Loaded"
        '
        'TrackCol
        '
        Me.TrackCol.Text = "Track"
        Me.TrackCol.Width = 137
        '
        'HotKeyCol
        '
        Me.HotKeyCol.Text = "Bind"
        '
        'VolumeCol
        '
        Me.VolumeCol.Text = "Volume"
        Me.VolumeCol.Width = 100
        '
        'Trimmed
        '
        Me.Trimmed.Text = "Trimmed"
        '
        'TagsCol
        '
        Me.TagsCol.Text = "Tags"
        Me.TagsCol.Width = 43
        '
        'ImportDialog
        '
        Me.ImportDialog.Filter = "Media files|*.mp3;*.wav;*.aac;*.wma;*.m4a;*.mp4;*.ogg;*.wmv;*.avi;*.m4v;*.mov;*.w" &
    "ebm|Audio files|*.mp3;*.wav;*.aac;*.wma;*.m4a;*.ogg|Video files|*.mp4;*.wmv;*.av" &
    "i;*.m4v;*.mov;*.webm|All files|*.*"
        Me.ImportDialog.Multiselect = True
        '
        'WavWorker
        '
        Me.WavWorker.WorkerReportsProgress = True
        Me.WavWorker.WorkerSupportsCancellation = True
        '
        'PollRelayWorker
        '
        Me.PollRelayWorker.WorkerReportsProgress = True
        Me.PollRelayWorker.WorkerSupportsCancellation = True
        '
        'TrackContextMenu
        '
        Me.TrackContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadToolStripMenuItem, Me.ContextDelete, Me.GoToToolStripMenuItem, Me.SelectAllToolStripMenuItem, Me.ContextRefresh, Me.RenameToolStripMenuItem, Me.ContextHotKey, Me.RemoveHotkeyToolStripMenuItem, Me.SetVolumeToolStripMenuItem, Me.ResetVolumeToolStripMenuItem, Me.TrimToolStripMenuItem, Me.ClearTrimToolStripMenuItem})
        Me.TrackContextMenu.Name = "TrackContextMenu"
        Me.TrackContextMenu.Size = New System.Drawing.Size(219, 268)
        '
        'LoadToolStripMenuItem
        '
        Me.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem"
        Me.LoadToolStripMenuItem.ShortcutKeyDisplayString = "Enter"
        Me.LoadToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.LoadToolStripMenuItem.Text = "Load"
        '
        'ContextDelete
        '
        Me.ContextDelete.Image = CType(resources.GetObject("ContextDelete.Image"), System.Drawing.Image)
        Me.ContextDelete.Name = "ContextDelete"
        Me.ContextDelete.ShortcutKeyDisplayString = "Del"
        Me.ContextDelete.Size = New System.Drawing.Size(218, 22)
        Me.ContextDelete.Text = "Delete"
        '
        'GoToToolStripMenuItem
        '
        Me.GoToToolStripMenuItem.Name = "GoToToolStripMenuItem"
        Me.GoToToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Enter"
        Me.GoToToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.GoToToolStripMenuItem.Text = "Go To"
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+A"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select all"
        '
        'ContextRefresh
        '
        Me.ContextRefresh.Image = CType(resources.GetObject("ContextRefresh.Image"), System.Drawing.Image)
        Me.ContextRefresh.Name = "ContextRefresh"
        Me.ContextRefresh.ShortcutKeyDisplayString = "F5"
        Me.ContextRefresh.Size = New System.Drawing.Size(218, 22)
        Me.ContextRefresh.Text = "Refresh list"
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        Me.RenameToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+R, F2"
        Me.RenameToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.RenameToolStripMenuItem.Text = "Rename"
        '
        'ContextHotKey
        '
        Me.ContextHotKey.Name = "ContextHotKey"
        Me.ContextHotKey.ShortcutKeyDisplayString = "Ctrl+B"
        Me.ContextHotKey.Size = New System.Drawing.Size(218, 22)
        Me.ContextHotKey.Text = "Set Bind"
        '
        'RemoveHotkeyToolStripMenuItem
        '
        Me.RemoveHotkeyToolStripMenuItem.Name = "RemoveHotkeyToolStripMenuItem"
        Me.RemoveHotkeyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+B"
        Me.RemoveHotkeyToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.RemoveHotkeyToolStripMenuItem.Text = "Remove Bind"
        '
        'SetVolumeToolStripMenuItem
        '
        Me.SetVolumeToolStripMenuItem.Image = CType(resources.GetObject("SetVolumeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SetVolumeToolStripMenuItem.Name = "SetVolumeToolStripMenuItem"
        Me.SetVolumeToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V"
        Me.SetVolumeToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.SetVolumeToolStripMenuItem.Text = "Set Volume"
        '
        'ResetVolumeToolStripMenuItem
        '
        Me.ResetVolumeToolStripMenuItem.Name = "ResetVolumeToolStripMenuItem"
        Me.ResetVolumeToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+V"
        Me.ResetVolumeToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.ResetVolumeToolStripMenuItem.Text = "Reset volume"
        '
        'TrimToolStripMenuItem
        '
        Me.TrimToolStripMenuItem.Image = CType(resources.GetObject("TrimToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TrimToolStripMenuItem.Name = "TrimToolStripMenuItem"
        Me.TrimToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+T"
        Me.TrimToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.TrimToolStripMenuItem.Text = "Trim"
        '
        'ClearTrimToolStripMenuItem
        '
        Me.ClearTrimToolStripMenuItem.Name = "ClearTrimToolStripMenuItem"
        Me.ClearTrimToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+T"
        Me.ClearTrimToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.ClearTrimToolStripMenuItem.Text = "Clear trim"
        '
        'SystemTrayIcon
        '
        Me.SystemTrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.SystemTrayIcon.BalloonTipTitle = "SLAM"
        Me.SystemTrayIcon.ContextMenuStrip = Me.SystemTrayMenu
        Me.SystemTrayIcon.Icon = CType(resources.GetObject("SystemTrayIcon.Icon"), System.Drawing.Icon)
        Me.SystemTrayIcon.Text = "SLAM"
        '
        'SystemTrayMenu
        '
        Me.SystemTrayMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SystemTrayMenu_Open, Me.SystemTrayMenuStart, Me.SystemTrayMenuStop, Me.ToolStripSeparator1, Me.SystemTrayMenu_Exit})
        Me.SystemTrayMenu.Name = "SystemTrayMenu"
        Me.SystemTrayMenu.Size = New System.Drawing.Size(104, 98)
        '
        'SystemTrayMenu_Open
        '
        Me.SystemTrayMenu_Open.Name = "SystemTrayMenu_Open"
        Me.SystemTrayMenu_Open.Size = New System.Drawing.Size(103, 22)
        Me.SystemTrayMenu_Open.Text = "Open"
        '
        'SystemTrayMenuStart
        '
        Me.SystemTrayMenuStart.Image = CType(resources.GetObject("SystemTrayMenuStart.Image"), System.Drawing.Image)
        Me.SystemTrayMenuStart.Name = "SystemTrayMenuStart"
        Me.SystemTrayMenuStart.Size = New System.Drawing.Size(103, 22)
        Me.SystemTrayMenuStart.Text = "Start"
        '
        'SystemTrayMenuStop
        '
        Me.SystemTrayMenuStop.Image = CType(resources.GetObject("SystemTrayMenuStop.Image"), System.Drawing.Image)
        Me.SystemTrayMenuStop.Name = "SystemTrayMenuStop"
        Me.SystemTrayMenuStop.Size = New System.Drawing.Size(103, 22)
        Me.SystemTrayMenuStop.Text = "Stop"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(100, 6)
        '
        'SystemTrayMenu_Exit
        '
        Me.SystemTrayMenu_Exit.Image = CType(resources.GetObject("SystemTrayMenu_Exit.Image"), System.Drawing.Image)
        Me.SystemTrayMenu_Exit.Name = "SystemTrayMenu_Exit"
        Me.SystemTrayMenu_Exit.Size = New System.Drawing.Size(103, 22)
        Me.SystemTrayMenu_Exit.Text = "Exit"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelCount, Me.ToolStripStatusLabelTrackCount, Me.ToolStripStatusLabelSeparator1, Me.ToolStripStatusLabelStatus, Me.ToolStripStatusLabelAppStatus, Me.ToolStripStatusLabelSeparator2, Me.ToolStripStatusLabelLoaded, Me.ToolStripStatusLabelLoadedTrackName, Me.ToolStripStatusLabelSeparator3, Me.ToolStripStatusLabelImportProgress, Me.ToolStripProgressBarImport, Me.ToolStripStatusLabelStopImport})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 439)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(584, 22)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabelCount
        '
        Me.ToolStripStatusLabelCount.Name = "ToolStripStatusLabelCount"
        Me.ToolStripStatusLabelCount.Size = New System.Drawing.Size(43, 17)
        Me.ToolStripStatusLabelCount.Text = "Count:"
        '
        'ToolStripStatusLabelTrackCount
        '
        Me.ToolStripStatusLabelTrackCount.Name = "ToolStripStatusLabelTrackCount"
        Me.ToolStripStatusLabelTrackCount.Size = New System.Drawing.Size(13, 17)
        Me.ToolStripStatusLabelTrackCount.Text = "0"
        '
        'ToolStripStatusLabelSeparator1
        '
        Me.ToolStripStatusLabelSeparator1.Name = "ToolStripStatusLabelSeparator1"
        Me.ToolStripStatusLabelSeparator1.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabelSeparator1.Text = "|"
        '
        'ToolStripStatusLabelStatus
        '
        Me.ToolStripStatusLabelStatus.Name = "ToolStripStatusLabelStatus"
        Me.ToolStripStatusLabelStatus.Size = New System.Drawing.Size(42, 17)
        Me.ToolStripStatusLabelStatus.Text = "Status:"
        '
        'ToolStripStatusLabelAppStatus
        '
        Me.ToolStripStatusLabelAppStatus.Name = "ToolStripStatusLabelAppStatus"
        Me.ToolStripStatusLabelAppStatus.Size = New System.Drawing.Size(26, 17)
        Me.ToolStripStatusLabelAppStatus.Text = "Idle"
        '
        'ToolStripStatusLabelSeparator2
        '
        Me.ToolStripStatusLabelSeparator2.Name = "ToolStripStatusLabelSeparator2"
        Me.ToolStripStatusLabelSeparator2.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabelSeparator2.Text = "|"
        '
        'ToolStripStatusLabelLoaded
        '
        Me.ToolStripStatusLabelLoaded.Name = "ToolStripStatusLabelLoaded"
        Me.ToolStripStatusLabelLoaded.Size = New System.Drawing.Size(49, 17)
        Me.ToolStripStatusLabelLoaded.Text = "Loaded:"
        '
        'ToolStripStatusLabelLoadedTrackName
        '
        Me.ToolStripStatusLabelLoadedTrackName.Name = "ToolStripStatusLabelLoadedTrackName"
        Me.ToolStripStatusLabelLoadedTrackName.Size = New System.Drawing.Size(376, 17)
        Me.ToolStripStatusLabelLoadedTrackName.Spring = True
        Me.ToolStripStatusLabelLoadedTrackName.Text = "No file"
        Me.ToolStripStatusLabelLoadedTrackName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabelSeparator3
        '
        Me.ToolStripStatusLabelSeparator3.Name = "ToolStripStatusLabelSeparator3"
        Me.ToolStripStatusLabelSeparator3.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabelSeparator3.Text = "|"
        Me.ToolStripStatusLabelSeparator3.Visible = False
        '
        'ToolStripStatusLabelImportProgress
        '
        Me.ToolStripStatusLabelImportProgress.Name = "ToolStripStatusLabelImportProgress"
        Me.ToolStripStatusLabelImportProgress.Size = New System.Drawing.Size(102, 17)
        Me.ToolStripStatusLabelImportProgress.Spring = True
        Me.ToolStripStatusLabelImportProgress.Text = "Import progress"
        Me.ToolStripStatusLabelImportProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripStatusLabelImportProgress.Visible = False
        '
        'ToolStripProgressBarImport
        '
        Me.ToolStripProgressBarImport.Name = "ToolStripProgressBarImport"
        Me.ToolStripProgressBarImport.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripProgressBarImport.Step = 1
        Me.ToolStripProgressBarImport.Visible = False
        '
        'ToolStripStatusLabelStopImport
        '
        Me.ToolStripStatusLabelStopImport.IsLink = True
        Me.ToolStripStatusLabelStopImport.Name = "ToolStripStatusLabelStopImport"
        Me.ToolStripStatusLabelStopImport.Size = New System.Drawing.Size(70, 17)
        Me.ToolStripStatusLabelStopImport.Text = "Stop import"
        Me.ToolStripStatusLabelStopImport.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.GameSelector, Me.ToolStripSeparator2, Me.ToolStripSplitButtonImport, Me.ToolStripButtonStartWork, Me.ToolStripButtonStopWork, Me.ToolStripButtonSettings, Me.ToolStripDropDownButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(7, 0, 0, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(584, 38)
        Me.ToolStrip1.TabIndex = 14
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(41, 35)
        Me.ToolStripLabel1.Text = "Game:"
        '
        'GameSelector
        '
        Me.GameSelector.BackColor = System.Drawing.SystemColors.Window
        Me.GameSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GameSelector.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GameSelector.Name = "GameSelector"
        Me.GameSelector.Size = New System.Drawing.Size(200, 38)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 38)
        '
        'ToolStripSplitButtonImport
        '
        Me.ToolStripSplitButtonImport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViaYoutubedlToolStripMenuItem})
        Me.ToolStripSplitButtonImport.Image = CType(resources.GetObject("ToolStripSplitButtonImport.Image"), System.Drawing.Image)
        Me.ToolStripSplitButtonImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButtonImport.Name = "ToolStripSplitButtonImport"
        Me.ToolStripSplitButtonImport.Size = New System.Drawing.Size(59, 35)
        Me.ToolStripSplitButtonImport.Text = "Import"
        Me.ToolStripSplitButtonImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ViaYoutubedlToolStripMenuItem
        '
        Me.ViaYoutubedlToolStripMenuItem.Name = "ViaYoutubedlToolStripMenuItem"
        Me.ViaYoutubedlToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ViaYoutubedlToolStripMenuItem.Text = "Via youtube-dl"
        '
        'ToolStripButtonStartWork
        '
        Me.ToolStripButtonStartWork.Image = CType(resources.GetObject("ToolStripButtonStartWork.Image"), System.Drawing.Image)
        Me.ToolStripButtonStartWork.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonStartWork.Name = "ToolStripButtonStartWork"
        Me.ToolStripButtonStartWork.Size = New System.Drawing.Size(35, 35)
        Me.ToolStripButtonStartWork.Text = "Start"
        Me.ToolStripButtonStartWork.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButtonStopWork
        '
        Me.ToolStripButtonStopWork.Image = CType(resources.GetObject("ToolStripButtonStopWork.Image"), System.Drawing.Image)
        Me.ToolStripButtonStopWork.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonStopWork.Name = "ToolStripButtonStopWork"
        Me.ToolStripButtonStopWork.Size = New System.Drawing.Size(35, 35)
        Me.ToolStripButtonStopWork.Text = "Stop"
        Me.ToolStripButtonStopWork.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButtonStopWork.Visible = False
        '
        'ToolStripButtonSettings
        '
        Me.ToolStripButtonSettings.Image = CType(resources.GetObject("ToolStripButtonSettings.Image"), System.Drawing.Image)
        Me.ToolStripButtonSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSettings.Name = "ToolStripButtonSettings"
        Me.ToolStripButtonSettings.Size = New System.Drawing.Size(53, 35)
        Me.ToolStripButtonSettings.Text = "Settings"
        Me.ToolStripButtonSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShortcutsToolStripMenuItem, Me.IngameCommandsToolStripMenuItem, Me.ToolStripSeparator3, Me.YoutubedlHomepageToolStripMenuItem, Me.YoutubedlCheckVersionToolStripMenuItem, Me.ToolStripMenuItem1, Me.AboutToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(45, 35)
        Me.ToolStripDropDownButton1.Text = "Help"
        Me.ToolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ShortcutsToolStripMenuItem
        '
        Me.ShortcutsToolStripMenuItem.Name = "ShortcutsToolStripMenuItem"
        Me.ShortcutsToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.ShortcutsToolStripMenuItem.Text = "Shortcuts"
        '
        'IngameCommandsToolStripMenuItem
        '
        Me.IngameCommandsToolStripMenuItem.Name = "IngameCommandsToolStripMenuItem"
        Me.IngameCommandsToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.IngameCommandsToolStripMenuItem.Text = "In-game commands"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(205, 6)
        '
        'YoutubedlHomepageToolStripMenuItem
        '
        Me.YoutubedlHomepageToolStripMenuItem.Name = "YoutubedlHomepageToolStripMenuItem"
        Me.YoutubedlHomepageToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.YoutubedlHomepageToolStripMenuItem.Text = "youtube-dl homepage"
        '
        'YoutubedlCheckVersionToolStripMenuItem
        '
        Me.YoutubedlCheckVersionToolStripMenuItem.Name = "YoutubedlCheckVersionToolStripMenuItem"
        Me.YoutubedlCheckVersionToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.YoutubedlCheckVersionToolStripMenuItem.Text = "youtube-dl check version"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(205, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = CType(resources.GetObject("AboutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.ShortcutKeyDisplayString = "F1"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'YTDLUpdateWorker
        '
        Me.YTDLUpdateWorker.WorkerReportsProgress = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 461)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TrackList)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(600, 500)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Source Live Audio Mixer (asternauta mod)"
        Me.TrackContextMenu.ResumeLayout(False)
        Me.SystemTrayMenu.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrackList As System.Windows.Forms.ListView
    Friend WithEvents LoadedCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents TrackCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents TagsCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImportDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents WavWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents PollRelayWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents TrackContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextHotKey As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HotKeyCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents RemoveHotkeyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GoToToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VolumeCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents SetVolumeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrimToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Trimmed As System.Windows.Forms.ColumnHeader
    Friend WithEvents RenameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SystemTrayIcon As NotifyIcon
    Friend WithEvents SystemTrayMenu As ContextMenuStrip
    Friend WithEvents SystemTrayMenu_Open As ToolStripMenuItem
    Friend WithEvents SystemTrayMenuStart As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SystemTrayMenu_Exit As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabelStatus As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelAppStatus As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelLoaded As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelLoadedTrackName As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelCount As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelTrackCount As ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents GameSelector As ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSplitButtonImport As ToolStripSplitButton
    Friend WithEvents ViaYoutubedlToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButtonStartWork As ToolStripButton
    Friend WithEvents ToolStripButtonStopWork As ToolStripButton
    Friend WithEvents ToolStripButtonSettings As ToolStripButton
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetVolumeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabelSeparator1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelSeparator2 As ToolStripStatusLabel
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents ShortcutsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IngameCommandsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents YoutubedlHomepageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents YoutubedlCheckVersionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearTrimToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents YTDLUpdateWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStripStatusLabelSeparator3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelImportProgress As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBarImport As ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabelStopImport As ToolStripStatusLabel
    Friend WithEvents SystemTrayMenuStop As ToolStripMenuItem
End Class
