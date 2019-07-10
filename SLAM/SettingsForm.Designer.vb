<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SettingsForm
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
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Additional", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Relay key", ""}, -1)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Play track", ""}, -1)
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Random track", ""}, -1)
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Previous track", ""}, -1)
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Next track", ""}, -1)
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"First track", ""}, -1)
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Last track", ""}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsForm))
        Me.GroupBoxModule = New System.Windows.Forms.GroupBox()
        Me.FFMPEGRadio = New System.Windows.Forms.RadioButton()
        Me.NAudioRadio = New System.Windows.Forms.RadioButton()
        Me.OverrideGroup = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FinduserdataButton = New System.Windows.Forms.Button()
        Me.userdatatext = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FindsteamappsButton = New System.Windows.Forms.Button()
        Me.steamappstext = New System.Windows.Forms.TextBox()
        Me.EnableOverrideBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonResetSettings = New System.Windows.Forms.Button()
        Me.HintCheckBox = New System.Windows.Forms.CheckBox()
        Me.LogCheckBox = New System.Windows.Forms.CheckBox()
        Me.StartEnabledCheckBox = New System.Windows.Forms.CheckBox()
        Me.StartMinimizedCheckBox = New System.Windows.Forms.CheckBox()
        Me.MinimizeToSysTrayCheckBox = New System.Windows.Forms.CheckBox()
        Me.HoldToPlay = New System.Windows.Forms.CheckBox()
        Me.ConTagsCheckBox = New System.Windows.Forms.CheckBox()
        Me.CheckBoxHighlightRecentImportedTracks = New System.Windows.Forms.CheckBox()
        Me.CheckBoxAutoUpdateYTDL = New System.Windows.Forms.CheckBox()
        Me.ButtonChangeHighlightColor = New System.Windows.Forms.Button()
        Me.CheckBoxStopWorkingIfGameClosed = New System.Windows.Forms.CheckBox()
        Me.CheckBoxForceConvertTo11kHz = New System.Windows.Forms.CheckBox()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPageHotKeys = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonResetKey = New System.Windows.Forms.Button()
        Me.ButtonClearKey = New System.Windows.Forms.Button()
        Me.ListViewHotkeys = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPageOther = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButtonNoPlaylistNo = New System.Windows.Forms.RadioButton()
        Me.RadioButtonNoPlaylistYes = New System.Windows.Forms.RadioButton()
        Me.RadioButtonNoPlaylistAsk = New System.Windows.Forms.RadioButton()
        Me.GroupBoxModule.SuspendLayout()
        Me.OverrideGroup.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPageHotKeys.SuspendLayout()
        Me.TabPageOther.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxModule
        '
        Me.GroupBoxModule.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxModule.Controls.Add(Me.FFMPEGRadio)
        Me.GroupBoxModule.Controls.Add(Me.NAudioRadio)
        Me.GroupBoxModule.Location = New System.Drawing.Point(6, 108)
        Me.GroupBoxModule.Name = "GroupBoxModule"
        Me.GroupBoxModule.Size = New System.Drawing.Size(358, 46)
        Me.GroupBoxModule.TabIndex = 6
        Me.GroupBoxModule.TabStop = False
        Me.GroupBoxModule.Text = "Module used to import/load tracks"
        '
        'FFMPEGRadio
        '
        Me.FFMPEGRadio.AutoSize = True
        Me.FFMPEGRadio.Location = New System.Drawing.Point(6, 19)
        Me.FFMPEGRadio.Name = "FFMPEGRadio"
        Me.FFMPEGRadio.Size = New System.Drawing.Size(90, 17)
        Me.FFMPEGRadio.TabIndex = 4
        Me.FFMPEGRadio.TabStop = True
        Me.FFMPEGRadio.Text = "Use FFMPEG"
        Me.FFMPEGRadio.UseVisualStyleBackColor = True
        '
        'NAudioRadio
        '
        Me.NAudioRadio.AutoSize = True
        Me.NAudioRadio.Location = New System.Drawing.Point(102, 19)
        Me.NAudioRadio.Name = "NAudioRadio"
        Me.NAudioRadio.Size = New System.Drawing.Size(126, 17)
        Me.NAudioRadio.TabIndex = 5
        Me.NAudioRadio.Text = "Use NAudio (Legacy)"
        Me.NAudioRadio.UseVisualStyleBackColor = True
        '
        'OverrideGroup
        '
        Me.OverrideGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OverrideGroup.Controls.Add(Me.Label2)
        Me.OverrideGroup.Controls.Add(Me.FinduserdataButton)
        Me.OverrideGroup.Controls.Add(Me.userdatatext)
        Me.OverrideGroup.Controls.Add(Me.Label1)
        Me.OverrideGroup.Controls.Add(Me.FindsteamappsButton)
        Me.OverrideGroup.Controls.Add(Me.steamappstext)
        Me.OverrideGroup.Controls.Add(Me.EnableOverrideBox)
        Me.OverrideGroup.Location = New System.Drawing.Point(6, 6)
        Me.OverrideGroup.Name = "OverrideGroup"
        Me.OverrideGroup.Size = New System.Drawing.Size(358, 96)
        Me.OverrideGroup.TabIndex = 3
        Me.OverrideGroup.TabStop = False
        Me.OverrideGroup.Text = "Override folder detection"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(6, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "userdata:"
        '
        'FinduserdataButton
        '
        Me.FinduserdataButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FinduserdataButton.Enabled = False
        Me.FinduserdataButton.Location = New System.Drawing.Point(328, 66)
        Me.FinduserdataButton.Name = "FinduserdataButton"
        Me.FinduserdataButton.Size = New System.Drawing.Size(24, 23)
        Me.FinduserdataButton.TabIndex = 5
        Me.FinduserdataButton.Text = "..."
        Me.FinduserdataButton.UseVisualStyleBackColor = True
        '
        'userdatatext
        '
        Me.userdatatext.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.userdatatext.Enabled = False
        Me.userdatatext.Location = New System.Drawing.Point(73, 68)
        Me.userdatatext.Name = "userdatatext"
        Me.userdatatext.ReadOnly = True
        Me.userdatatext.Size = New System.Drawing.Size(249, 20)
        Me.userdatatext.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(6, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "steamapps:"
        '
        'FindsteamappsButton
        '
        Me.FindsteamappsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FindsteamappsButton.Enabled = False
        Me.FindsteamappsButton.Location = New System.Drawing.Point(328, 40)
        Me.FindsteamappsButton.Name = "FindsteamappsButton"
        Me.FindsteamappsButton.Size = New System.Drawing.Size(24, 23)
        Me.FindsteamappsButton.TabIndex = 2
        Me.FindsteamappsButton.Text = "..."
        Me.FindsteamappsButton.UseVisualStyleBackColor = True
        '
        'steamappstext
        '
        Me.steamappstext.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.steamappstext.Enabled = False
        Me.steamappstext.Location = New System.Drawing.Point(73, 42)
        Me.steamappstext.Name = "steamappstext"
        Me.steamappstext.ReadOnly = True
        Me.steamappstext.Size = New System.Drawing.Size(249, 20)
        Me.steamappstext.TabIndex = 1
        '
        'EnableOverrideBox
        '
        Me.EnableOverrideBox.AutoSize = True
        Me.EnableOverrideBox.Location = New System.Drawing.Point(6, 19)
        Me.EnableOverrideBox.Name = "EnableOverrideBox"
        Me.EnableOverrideBox.Size = New System.Drawing.Size(59, 17)
        Me.EnableOverrideBox.TabIndex = 0
        Me.EnableOverrideBox.Text = "Enable"
        Me.EnableOverrideBox.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 206)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(358, 179)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Other"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoScroll = True
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonResetSettings, 0, 14)
        Me.TableLayoutPanel3.Controls.Add(Me.HintCheckBox, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.LogCheckBox, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.StartEnabledCheckBox, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.StartMinimizedCheckBox, 0, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.MinimizeToSysTrayCheckBox, 0, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.HoldToPlay, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.ConTagsCheckBox, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.CheckBoxHighlightRecentImportedTracks, 0, 7)
        Me.TableLayoutPanel3.Controls.Add(Me.CheckBoxAutoUpdateYTDL, 0, 9)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonChangeHighlightColor, 0, 8)
        Me.TableLayoutPanel3.Controls.Add(Me.CheckBoxStopWorkingIfGameClosed, 0, 12)
        Me.TableLayoutPanel3.Controls.Add(Me.CheckBoxForceConvertTo11kHz, 0, 13)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 15
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(352, 160)
        Me.TableLayoutPanel3.TabIndex = 7
        '
        'ButtonResetSettings
        '
        Me.ButtonResetSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ButtonResetSettings.Location = New System.Drawing.Point(3, 285)
        Me.ButtonResetSettings.Name = "ButtonResetSettings"
        Me.ButtonResetSettings.Size = New System.Drawing.Size(321, 23)
        Me.ButtonResetSettings.TabIndex = 8
        Me.ButtonResetSettings.Text = "Reset all settings"
        Me.ButtonResetSettings.UseVisualStyleBackColor = True
        '
        'HintCheckBox
        '
        Me.HintCheckBox.AutoSize = True
        Me.HintCheckBox.Location = New System.Drawing.Point(3, 3)
        Me.HintCheckBox.Name = "HintCheckBox"
        Me.HintCheckBox.Size = New System.Drawing.Size(65, 17)
        Me.HintCheckBox.TabIndex = 3
        Me.HintCheckBox.Text = "No hints"
        Me.HintCheckBox.UseVisualStyleBackColor = True
        '
        'LogCheckBox
        '
        Me.LogCheckBox.AutoSize = True
        Me.LogCheckBox.Location = New System.Drawing.Point(3, 26)
        Me.LogCheckBox.Name = "LogCheckBox"
        Me.LogCheckBox.Size = New System.Drawing.Size(73, 17)
        Me.LogCheckBox.TabIndex = 2
        Me.LogCheckBox.Text = "Log errors"
        Me.LogCheckBox.UseVisualStyleBackColor = True
        '
        'StartEnabledCheckBox
        '
        Me.StartEnabledCheckBox.AutoSize = True
        Me.StartEnabledCheckBox.Location = New System.Drawing.Point(3, 49)
        Me.StartEnabledCheckBox.Name = "StartEnabledCheckBox"
        Me.StartEnabledCheckBox.Size = New System.Drawing.Size(89, 17)
        Me.StartEnabledCheckBox.TabIndex = 4
        Me.StartEnabledCheckBox.Text = "Start enabled"
        Me.StartEnabledCheckBox.UseVisualStyleBackColor = True
        '
        'StartMinimizedCheckBox
        '
        Me.StartMinimizedCheckBox.AutoSize = True
        Me.StartMinimizedCheckBox.Location = New System.Drawing.Point(3, 141)
        Me.StartMinimizedCheckBox.Name = "StartMinimizedCheckBox"
        Me.StartMinimizedCheckBox.Size = New System.Drawing.Size(96, 17)
        Me.StartMinimizedCheckBox.TabIndex = 13
        Me.StartMinimizedCheckBox.Text = "Start minimized"
        Me.StartMinimizedCheckBox.UseVisualStyleBackColor = True
        '
        'MinimizeToSysTrayCheckBox
        '
        Me.MinimizeToSysTrayCheckBox.AutoSize = True
        Me.MinimizeToSysTrayCheckBox.Location = New System.Drawing.Point(3, 118)
        Me.MinimizeToSysTrayCheckBox.Name = "MinimizeToSysTrayCheckBox"
        Me.MinimizeToSysTrayCheckBox.Size = New System.Drawing.Size(133, 17)
        Me.MinimizeToSysTrayCheckBox.TabIndex = 12
        Me.MinimizeToSysTrayCheckBox.Text = "Minimize to system tray"
        Me.MinimizeToSysTrayCheckBox.UseVisualStyleBackColor = True
        '
        'HoldToPlay
        '
        Me.HoldToPlay.AutoSize = True
        Me.HoldToPlay.Location = New System.Drawing.Point(3, 95)
        Me.HoldToPlay.Name = "HoldToPlay"
        Me.HoldToPlay.Size = New System.Drawing.Size(82, 17)
        Me.HoldToPlay.TabIndex = 11
        Me.HoldToPlay.Text = "Hold to play"
        Me.HoldToPlay.UseVisualStyleBackColor = True
        '
        'ConTagsCheckBox
        '
        Me.ConTagsCheckBox.AutoSize = True
        Me.ConTagsCheckBox.Location = New System.Drawing.Point(3, 72)
        Me.ConTagsCheckBox.Name = "ConTagsCheckBox"
        Me.ConTagsCheckBox.Size = New System.Drawing.Size(101, 17)
        Me.ConTagsCheckBox.TabIndex = 21
        Me.ConTagsCheckBox.Text = "Tags in console"
        Me.ConTagsCheckBox.UseVisualStyleBackColor = True
        '
        'CheckBoxHighlightRecentImportedTracks
        '
        Me.CheckBoxHighlightRecentImportedTracks.AutoSize = True
        Me.CheckBoxHighlightRecentImportedTracks.Location = New System.Drawing.Point(3, 164)
        Me.CheckBoxHighlightRecentImportedTracks.Name = "CheckBoxHighlightRecentImportedTracks"
        Me.CheckBoxHighlightRecentImportedTracks.Size = New System.Drawing.Size(182, 17)
        Me.CheckBoxHighlightRecentImportedTracks.TabIndex = 20
        Me.CheckBoxHighlightRecentImportedTracks.Text = "Highlight recently imported tracks"
        Me.CheckBoxHighlightRecentImportedTracks.UseVisualStyleBackColor = True
        '
        'CheckBoxAutoUpdateYTDL
        '
        Me.CheckBoxAutoUpdateYTDL.AutoSize = True
        Me.CheckBoxAutoUpdateYTDL.Location = New System.Drawing.Point(3, 216)
        Me.CheckBoxAutoUpdateYTDL.Name = "CheckBoxAutoUpdateYTDL"
        Me.CheckBoxAutoUpdateYTDL.Size = New System.Drawing.Size(246, 17)
        Me.CheckBoxAutoUpdateYTDL.TabIndex = 19
        Me.CheckBoxAutoUpdateYTDL.Text = "Update youtube-dl automatically (every 3 days)"
        Me.CheckBoxAutoUpdateYTDL.UseVisualStyleBackColor = True
        '
        'ButtonChangeHighlightColor
        '
        Me.ButtonChangeHighlightColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonChangeHighlightColor.Location = New System.Drawing.Point(3, 187)
        Me.ButtonChangeHighlightColor.Name = "ButtonChangeHighlightColor"
        Me.ButtonChangeHighlightColor.Size = New System.Drawing.Size(133, 23)
        Me.ButtonChangeHighlightColor.TabIndex = 25
        Me.ButtonChangeHighlightColor.Text = "Change highlight color"
        Me.ButtonChangeHighlightColor.UseVisualStyleBackColor = True
        '
        'CheckBoxStopWorkingIfGameClosed
        '
        Me.CheckBoxStopWorkingIfGameClosed.AutoSize = True
        Me.CheckBoxStopWorkingIfGameClosed.Location = New System.Drawing.Point(3, 239)
        Me.CheckBoxStopWorkingIfGameClosed.Name = "CheckBoxStopWorkingIfGameClosed"
        Me.CheckBoxStopWorkingIfGameClosed.Size = New System.Drawing.Size(206, 17)
        Me.CheckBoxStopWorkingIfGameClosed.TabIndex = 22
        Me.CheckBoxStopWorkingIfGameClosed.Text = "Stop working if game has been closed"
        Me.CheckBoxStopWorkingIfGameClosed.UseVisualStyleBackColor = True
        '
        'CheckBoxForceConvertTo11kHz
        '
        Me.CheckBoxForceConvertTo11kHz.AutoSize = True
        Me.CheckBoxForceConvertTo11kHz.Location = New System.Drawing.Point(3, 262)
        Me.CheckBoxForceConvertTo11kHz.Name = "CheckBoxForceConvertTo11kHz"
        Me.CheckBoxForceConvertTo11kHz.Size = New System.Drawing.Size(206, 17)
        Me.CheckBoxForceConvertTo11kHz.TabIndex = 24
        Me.CheckBoxForceConvertTo11kHz.Text = "Force convert to 11 kHz on load track"
        Me.CheckBoxForceConvertTo11kHz.UseVisualStyleBackColor = True
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPageHotKeys)
        Me.TabControl.Controls.Add(Me.TabPageOther)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Margin = New System.Windows.Forms.Padding(1)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(378, 417)
        Me.TabControl.TabIndex = 7
        '
        'TabPageHotKeys
        '
        Me.TabPageHotKeys.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageHotKeys.Controls.Add(Me.Label3)
        Me.TabPageHotKeys.Controls.Add(Me.ButtonResetKey)
        Me.TabPageHotKeys.Controls.Add(Me.ButtonClearKey)
        Me.TabPageHotKeys.Controls.Add(Me.ListViewHotkeys)
        Me.TabPageHotKeys.Location = New System.Drawing.Point(4, 22)
        Me.TabPageHotKeys.Name = "TabPageHotKeys"
        Me.TabPageHotKeys.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageHotKeys.Size = New System.Drawing.Size(370, 391)
        Me.TabPageHotKeys.TabIndex = 2
        Me.TabPageHotKeys.Text = "Keys"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(245, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Double click to change"
        '
        'ButtonResetKey
        '
        Me.ButtonResetKey.Location = New System.Drawing.Point(87, 6)
        Me.ButtonResetKey.Name = "ButtonResetKey"
        Me.ButtonResetKey.Size = New System.Drawing.Size(75, 23)
        Me.ButtonResetKey.TabIndex = 2
        Me.ButtonResetKey.Text = "Reset key"
        Me.ButtonResetKey.UseVisualStyleBackColor = True
        '
        'ButtonClearKey
        '
        Me.ButtonClearKey.Location = New System.Drawing.Point(6, 6)
        Me.ButtonClearKey.Name = "ButtonClearKey"
        Me.ButtonClearKey.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClearKey.TabIndex = 1
        Me.ButtonClearKey.Text = "Clear key"
        Me.ButtonClearKey.UseVisualStyleBackColor = True
        '
        'ListViewHotkeys
        '
        Me.ListViewHotkeys.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewHotkeys.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListViewHotkeys.FullRowSelect = True
        ListViewGroup1.Header = "Additional"
        ListViewGroup1.Name = "ListViewGroupAdditional"
        Me.ListViewHotkeys.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1})
        Me.ListViewHotkeys.HideSelection = False
        ListViewItem1.StateImageIndex = 0
        ListViewItem1.Tag = "="
        ListViewItem2.StateImageIndex = 0
        ListViewItem2.Tag = "X"
        ListViewItem3.Group = ListViewGroup1
        ListViewItem3.StateImageIndex = 0
        ListViewItem4.Group = ListViewGroup1
        ListViewItem4.StateImageIndex = 0
        ListViewItem5.Group = ListViewGroup1
        ListViewItem5.StateImageIndex = 0
        ListViewItem6.Group = ListViewGroup1
        ListViewItem6.StateImageIndex = 0
        ListViewItem7.Group = ListViewGroup1
        ListViewItem7.StateImageIndex = 0
        Me.ListViewHotkeys.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7})
        Me.ListViewHotkeys.Location = New System.Drawing.Point(6, 35)
        Me.ListViewHotkeys.Name = "ListViewHotkeys"
        Me.ListViewHotkeys.Size = New System.Drawing.Size(358, 350)
        Me.ListViewHotkeys.TabIndex = 0
        Me.ListViewHotkeys.UseCompatibleStateImageBehavior = False
        Me.ListViewHotkeys.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Action"
        Me.ColumnHeader1.Width = 198
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Assigned key"
        Me.ColumnHeader2.Width = 114
        '
        'TabPageOther
        '
        Me.TabPageOther.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageOther.Controls.Add(Me.GroupBox1)
        Me.TabPageOther.Controls.Add(Me.OverrideGroup)
        Me.TabPageOther.Controls.Add(Me.GroupBoxModule)
        Me.TabPageOther.Controls.Add(Me.GroupBox2)
        Me.TabPageOther.Location = New System.Drawing.Point(4, 22)
        Me.TabPageOther.Name = "TabPageOther"
        Me.TabPageOther.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageOther.Size = New System.Drawing.Size(370, 391)
        Me.TabPageOther.TabIndex = 1
        Me.TabPageOther.Text = "Misc"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.RadioButtonNoPlaylistNo)
        Me.GroupBox1.Controls.Add(Me.RadioButtonNoPlaylistYes)
        Me.GroupBox1.Controls.Add(Me.RadioButtonNoPlaylistAsk)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 160)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(358, 43)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Drag && drop URLs - no playlist:"
        '
        'RadioButtonNoPlaylistNo
        '
        Me.RadioButtonNoPlaylistNo.AutoSize = True
        Me.RadioButtonNoPlaylistNo.Location = New System.Drawing.Point(104, 19)
        Me.RadioButtonNoPlaylistNo.Name = "RadioButtonNoPlaylistNo"
        Me.RadioButtonNoPlaylistNo.Size = New System.Drawing.Size(39, 17)
        Me.RadioButtonNoPlaylistNo.TabIndex = 2
        Me.RadioButtonNoPlaylistNo.TabStop = True
        Me.RadioButtonNoPlaylistNo.Text = "No"
        Me.RadioButtonNoPlaylistNo.UseVisualStyleBackColor = True
        '
        'RadioButtonNoPlaylistYes
        '
        Me.RadioButtonNoPlaylistYes.AutoSize = True
        Me.RadioButtonNoPlaylistYes.Location = New System.Drawing.Point(55, 19)
        Me.RadioButtonNoPlaylistYes.Name = "RadioButtonNoPlaylistYes"
        Me.RadioButtonNoPlaylistYes.Size = New System.Drawing.Size(43, 17)
        Me.RadioButtonNoPlaylistYes.TabIndex = 1
        Me.RadioButtonNoPlaylistYes.TabStop = True
        Me.RadioButtonNoPlaylistYes.Text = "Yes"
        Me.RadioButtonNoPlaylistYes.UseVisualStyleBackColor = True
        '
        'RadioButtonNoPlaylistAsk
        '
        Me.RadioButtonNoPlaylistAsk.AutoSize = True
        Me.RadioButtonNoPlaylistAsk.Location = New System.Drawing.Point(6, 19)
        Me.RadioButtonNoPlaylistAsk.Name = "RadioButtonNoPlaylistAsk"
        Me.RadioButtonNoPlaylistAsk.Size = New System.Drawing.Size(43, 17)
        Me.RadioButtonNoPlaylistAsk.TabIndex = 0
        Me.RadioButtonNoPlaylistAsk.TabStop = True
        Me.RadioButtonNoPlaylistAsk.Text = "Ask"
        Me.RadioButtonNoPlaylistAsk.UseVisualStyleBackColor = True
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 417)
        Me.Controls.Add(Me.TabControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SettingsForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.GroupBoxModule.ResumeLayout(False)
        Me.GroupBoxModule.PerformLayout()
        Me.OverrideGroup.ResumeLayout(False)
        Me.OverrideGroup.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TabControl.ResumeLayout(False)
        Me.TabPageHotKeys.ResumeLayout(False)
        Me.TabPageHotKeys.PerformLayout()
        Me.TabPageOther.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OverrideGroup As GroupBox
    Friend WithEvents FindsteamappsButton As Button
    Friend WithEvents steamappstext As TextBox
    Friend WithEvents EnableOverrideBox As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents FinduserdataButton As Button
    Friend WithEvents userdatatext As TextBox
    Friend WithEvents NAudioRadio As RadioButton
    Friend WithEvents FFMPEGRadio As RadioButton
    Friend WithEvents GroupBoxModule As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents StartMinimizedCheckBox As CheckBox
    Friend WithEvents MinimizeToSysTrayCheckBox As CheckBox
    Friend WithEvents HoldToPlay As CheckBox
    Friend WithEvents StartEnabledCheckBox As CheckBox
    Friend WithEvents LogCheckBox As CheckBox
    Friend WithEvents HintCheckBox As CheckBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TabControl As TabControl
    Friend WithEvents TabPageOther As TabPage
    Friend WithEvents TabPageHotKeys As TabPage
    Friend WithEvents ListViewHotkeys As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ButtonResetKey As Button
    Friend WithEvents ButtonClearKey As Button
    Friend WithEvents CheckBoxAutoUpdateYTDL As CheckBox
    Friend WithEvents CheckBoxHighlightRecentImportedTracks As CheckBox
    Friend WithEvents ConTagsCheckBox As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButtonNoPlaylistNo As RadioButton
    Friend WithEvents RadioButtonNoPlaylistYes As RadioButton
    Friend WithEvents RadioButtonNoPlaylistAsk As RadioButton
    Friend WithEvents ButtonResetSettings As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents CheckBoxForceConvertTo11kHz As CheckBox
    Friend WithEvents ButtonChangeHighlightColor As Button
    Friend WithEvents CheckBoxStopWorkingIfGameClosed As CheckBox
End Class
