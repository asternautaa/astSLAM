<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TrimForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TrimForm))
        Me.NumericRight = New System.Windows.Forms.NumericUpDown()
        Me.DoneButton = New System.Windows.Forms.Button()
        Me.NumericLeft = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NumericLeftS = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumericRightS = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBoxPlaybackS = New System.Windows.Forms.TextBox()
        Me.TextBoxPlayback = New System.Windows.Forms.TextBox()
        Me.ButtonMarkRight = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ButtonMarkLeft = New System.Windows.Forms.Button()
        Me.TimerPlayerState = New System.Windows.Forms.Timer(Me.components)
        Me.StopButton = New System.Windows.Forms.Button()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.StopResetPosButton = New System.Windows.Forms.Button()
        Me.PlayButton = New System.Windows.Forms.Button()
        Me.CheckBoxTrimPermanently = New System.Windows.Forms.CheckBox()
        Me.TrackBarVolume = New System.Windows.Forms.TrackBar()
        Me.GroupBoxVolume = New System.Windows.Forms.GroupBox()
        Me.AdvWaveViewer1 = New SLAM.AdvWaveViewer()
        CType(Me.NumericRight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericLeftS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NumericRightS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TrackBarVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxVolume.SuspendLayout()
        Me.SuspendLayout()
        '
        'NumericRight
        '
        Me.NumericRight.Location = New System.Drawing.Point(57, 19)
        Me.NumericRight.Name = "NumericRight"
        Me.NumericRight.Size = New System.Drawing.Size(150, 20)
        Me.NumericRight.TabIndex = 2
        Me.NumericRight.ThousandsSeparator = True
        '
        'DoneButton
        '
        Me.DoneButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DoneButton.Location = New System.Drawing.Point(674, 4)
        Me.DoneButton.Name = "DoneButton"
        Me.DoneButton.Size = New System.Drawing.Size(167, 23)
        Me.DoneButton.TabIndex = 5
        Me.DoneButton.Text = "Done"
        Me.DoneButton.UseVisualStyleBackColor = True
        '
        'NumericLeft
        '
        Me.NumericLeft.Location = New System.Drawing.Point(57, 19)
        Me.NumericLeft.Name = "NumericLeft"
        Me.NumericLeft.Size = New System.Drawing.Size(150, 20)
        Me.NumericLeft.TabIndex = 6
        Me.NumericLeft.ThousandsSeparator = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.NumericLeftS)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.NumericLeft)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 144)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(215, 75)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Start"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Second:"
        '
        'NumericLeftS
        '
        Me.NumericLeftS.DecimalPlaces = 3
        Me.NumericLeftS.Location = New System.Drawing.Point(57, 45)
        Me.NumericLeftS.Name = "NumericLeftS"
        Me.NumericLeftS.Size = New System.Drawing.Size(150, 20)
        Me.NumericLeftS.TabIndex = 8
        Me.NumericLeftS.ThousandsSeparator = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Sample:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.NumericRightS)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.NumericRight)
        Me.GroupBox2.Location = New System.Drawing.Point(233, 144)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(215, 75)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "End"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Second:"
        '
        'NumericRightS
        '
        Me.NumericRightS.DecimalPlaces = 3
        Me.NumericRightS.Location = New System.Drawing.Point(57, 45)
        Me.NumericRightS.Name = "NumericRightS"
        Me.NumericRightS.Size = New System.Drawing.Size(150, 20)
        Me.NumericRightS.TabIndex = 9
        Me.NumericRightS.ThousandsSeparator = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Sample:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.TextBoxPlaybackS)
        Me.GroupBox3.Controls.Add(Me.TextBoxPlayback)
        Me.GroupBox3.Controls.Add(Me.ButtonMarkRight)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.ButtonMarkLeft)
        Me.GroupBox3.Location = New System.Drawing.Point(454, 144)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(237, 75)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Playback"
        '
        'TextBoxPlaybackS
        '
        Me.TextBoxPlaybackS.Location = New System.Drawing.Point(57, 44)
        Me.TextBoxPlaybackS.Name = "TextBoxPlaybackS"
        Me.TextBoxPlaybackS.ReadOnly = True
        Me.TextBoxPlaybackS.Size = New System.Drawing.Size(86, 20)
        Me.TextBoxPlaybackS.TabIndex = 14
        Me.TextBoxPlaybackS.Text = "0"
        '
        'TextBoxPlayback
        '
        Me.TextBoxPlayback.Location = New System.Drawing.Point(57, 19)
        Me.TextBoxPlayback.Name = "TextBoxPlayback"
        Me.TextBoxPlayback.ReadOnly = True
        Me.TextBoxPlayback.Size = New System.Drawing.Size(86, 20)
        Me.TextBoxPlayback.TabIndex = 13
        Me.TextBoxPlayback.Text = "0"
        '
        'ButtonMarkRight
        '
        Me.ButtonMarkRight.Location = New System.Drawing.Point(149, 42)
        Me.ButtonMarkRight.Name = "ButtonMarkRight"
        Me.ButtonMarkRight.Size = New System.Drawing.Size(76, 23)
        Me.ButtonMarkRight.TabIndex = 12
        Me.ButtonMarkRight.Text = "Mark end"
        Me.ButtonMarkRight.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Second:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Sample:"
        '
        'ButtonMarkLeft
        '
        Me.ButtonMarkLeft.Location = New System.Drawing.Point(149, 16)
        Me.ButtonMarkLeft.Name = "ButtonMarkLeft"
        Me.ButtonMarkLeft.Size = New System.Drawing.Size(76, 23)
        Me.ButtonMarkLeft.TabIndex = 11
        Me.ButtonMarkLeft.Text = "Mark start"
        Me.ButtonMarkLeft.UseVisualStyleBackColor = True
        '
        'TimerPlayerState
        '
        Me.TimerPlayerState.Interval = 50
        '
        'StopButton
        '
        Me.StopButton.Location = New System.Drawing.Point(71, 4)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(44, 23)
        Me.StopButton.TabIndex = 12
        Me.StopButton.Text = "Stop"
        Me.StopButton.UseVisualStyleBackColor = True
        '
        'ResetButton
        '
        Me.ResetButton.Location = New System.Drawing.Point(233, 4)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(118, 23)
        Me.ResetButton.TabIndex = 7
        Me.ResetButton.Text = "Reset start and end"
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'StopResetPosButton
        '
        Me.StopResetPosButton.Location = New System.Drawing.Point(121, 4)
        Me.StopResetPosButton.Name = "StopResetPosButton"
        Me.StopResetPosButton.Size = New System.Drawing.Size(106, 23)
        Me.StopResetPosButton.TabIndex = 13
        Me.StopResetPosButton.Text = "Stop and zero pos"
        Me.StopResetPosButton.UseVisualStyleBackColor = True
        '
        'PlayButton
        '
        Me.PlayButton.Location = New System.Drawing.Point(12, 4)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(53, 23)
        Me.PlayButton.TabIndex = 10
        Me.PlayButton.Text = "Play"
        Me.PlayButton.UseVisualStyleBackColor = True
        '
        'CheckBoxTrimPermanently
        '
        Me.CheckBoxTrimPermanently.AutoSize = True
        Me.CheckBoxTrimPermanently.Location = New System.Drawing.Point(357, 8)
        Me.CheckBoxTrimPermanently.Name = "CheckBoxTrimPermanently"
        Me.CheckBoxTrimPermanently.Size = New System.Drawing.Size(106, 17)
        Me.CheckBoxTrimPermanently.TabIndex = 14
        Me.CheckBoxTrimPermanently.Text = "Trim permanently"
        Me.CheckBoxTrimPermanently.UseVisualStyleBackColor = True
        '
        'TrackBarVolume
        '
        Me.TrackBarVolume.Location = New System.Drawing.Point(6, 19)
        Me.TrackBarVolume.Maximum = 100
        Me.TrackBarVolume.Name = "TrackBarVolume"
        Me.TrackBarVolume.Size = New System.Drawing.Size(129, 45)
        Me.TrackBarVolume.TabIndex = 15
        Me.TrackBarVolume.TickFrequency = 10
        Me.TrackBarVolume.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.TrackBarVolume.Value = 100
        '
        'GroupBoxVolume
        '
        Me.GroupBoxVolume.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxVolume.Controls.Add(Me.TrackBarVolume)
        Me.GroupBoxVolume.Location = New System.Drawing.Point(697, 144)
        Me.GroupBoxVolume.Name = "GroupBoxVolume"
        Me.GroupBoxVolume.Size = New System.Drawing.Size(141, 75)
        Me.GroupBoxVolume.TabIndex = 16
        Me.GroupBoxVolume.TabStop = False
        Me.GroupBoxVolume.Text = "Playback volume (100)"
        '
        'AdvWaveViewer1
        '
        Me.AdvWaveViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AdvWaveViewer1.BackColor = System.Drawing.Color.White
        Me.AdvWaveViewer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AdvWaveViewer1.leftpos = 0
        Me.AdvWaveViewer1.leftSample = 0
        Me.AdvWaveViewer1.Location = New System.Drawing.Point(0, 33)
        Me.AdvWaveViewer1.marker = CType(0, Long)
        Me.AdvWaveViewer1.Name = "AdvWaveViewer1"
        Me.AdvWaveViewer1.rightpos = 0
        Me.AdvWaveViewer1.rightSample = 0
        Me.AdvWaveViewer1.SamplesPerPixel = 128
        Me.AdvWaveViewer1.Size = New System.Drawing.Size(847, 105)
        Me.AdvWaveViewer1.StartPosition = CType(0, Long)
        Me.AdvWaveViewer1.TabIndex = 0
        Me.AdvWaveViewer1.WaveStream = Nothing
        '
        'TrimForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(847, 231)
        Me.Controls.Add(Me.GroupBoxVolume)
        Me.Controls.Add(Me.CheckBoxTrimPermanently)
        Me.Controls.Add(Me.ResetButton)
        Me.Controls.Add(Me.StopResetPosButton)
        Me.Controls.Add(Me.PlayButton)
        Me.Controls.Add(Me.StopButton)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.DoneButton)
        Me.Controls.Add(Me.AdvWaveViewer1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(863, 270)
        Me.Name = "TrimForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Trim"
        CType(Me.NumericRight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericLeftS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NumericRightS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.TrackBarVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxVolume.ResumeLayout(False)
        Me.GroupBoxVolume.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AdvWaveViewer1 As SLAM.AdvWaveViewer
    Friend WithEvents NumericRight As System.Windows.Forms.NumericUpDown
    Friend WithEvents DoneButton As System.Windows.Forms.Button
    Friend WithEvents NumericLeft As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NumericLeftS As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NumericRightS As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TimerPlayerState As Timer
    Friend WithEvents ButtonMarkRight As Button
    Friend WithEvents ButtonMarkLeft As Button
    Friend WithEvents TextBoxPlaybackS As TextBox
    Friend WithEvents TextBoxPlayback As TextBox
    Friend WithEvents StopButton As Button
    Friend WithEvents ResetButton As Button
    Friend WithEvents StopResetPosButton As Button
    Friend WithEvents PlayButton As Button
    Friend WithEvents CheckBoxTrimPermanently As CheckBox
    Friend WithEvents TrackBarVolume As TrackBar
    Friend WithEvents GroupBoxVolume As GroupBox
End Class
