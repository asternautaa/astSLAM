Imports NAudio
Imports NAudio.Wave
Imports System.Threading
Imports System.IO

Public Class TrimForm
    Public WavFile As String
    Public Startpos As Integer
    Public Endpos As Integer
    Private outputPlayer As New WaveOutEvent
    Private WaveFloatToPlay

    Private Sub TrimForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(WavFile) Then
            Using reader As New Wave.WaveFileReader(WavFile)
                AdvWaveViewer1.WaveStream = New Wave.WaveFileReader(WavFile)
                'reader.WaveFormat.SampleRate
            End Using

            NumericRightS.Maximum = Decimal.MaxValue
            NumericRight.Maximum = AdvWaveViewer1.MaxSamples
            NumericRight.Increment = AdvWaveViewer1.SamplesPerPixel

            NumericLeftS.Maximum = Decimal.MaxValue
            NumericLeft.Maximum = Decimal.MaxValue
            NumericLeft.Increment = AdvWaveViewer1.SamplesPerPixel

            If Startpos = Endpos And Endpos = 0 Then
                NumericRight.Value = AdvWaveViewer1.MaxSamples
            Else
                AdvWaveViewer1.rightpos = Endpos
                AdvWaveViewer1.leftpos = Startpos
                NumericRight.Value = AdvWaveViewer1.rightSample
                NumericLeft.Value = AdvWaveViewer1.leftSample
            End If
        End If
    End Sub

    Public ReadOnly Property TrimPermanently
        Get
            Return CheckBoxTrimPermanently.Checked
        End Get
    End Property

    Private Sub TrimForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        StopIfPlaying()
        AdvWaveViewer1.WaveStream.Close()
        outputPlayer.Dispose()
    End Sub

    Private Sub StopIfPlaying()
        If (outputPlayer.PlaybackState = PlaybackState.Playing) Then
            outputPlayer.Stop()
        End If
    End Sub

    Private Sub AdvWaveViewer1_MouseUp(sender As Object, e As MouseEventArgs) Handles AdvWaveViewer1.MouseUp
        NumericRight.Value = AdvWaveViewer1.rightSample
        NumericLeft.Value = AdvWaveViewer1.leftSample
    End Sub

    Private Sub NumericLeft_ValueChanged(sender As Object, e As EventArgs) Handles NumericLeft.ValueChanged
        If NumericLeft.Value >= AdvWaveViewer1.rightSample Then
            NumericLeft.Value = NumericRight.Value - 1
        End If
        AdvWaveViewer1.leftSample = NumericLeft.Value
        NumericLeftS.Value = NumericLeft.Value / AdvWaveViewer1.SampleRate
    End Sub

    Private Sub NumericRight_ValueChanged(sender As Object, e As EventArgs) Handles NumericRight.ValueChanged
        If NumericRight.Value <= AdvWaveViewer1.leftSample Then
            NumericRight.Value = NumericLeft.Value + 1
        End If
        AdvWaveViewer1.rightSample = NumericRight.Value
        NumericRightS.Value = NumericRight.Value / AdvWaveViewer1.SampleRate

    End Sub

    Private Sub DoneButton_Click(sender As Object, e As EventArgs) Handles DoneButton.Click
        Dim ContinueOp As Boolean = True
        If (TrimPermanently) Then
            If (MessageBox.Show("Trim permanently?" & vbCrLf & "This cannot be undone!", "Trim", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No) Then
                ContinueOp = False
            End If
        End If

        If (ContinueOp) Then
            Startpos = AdvWaveViewer1.leftpos

            If AdvWaveViewer1.rightSample = AdvWaveViewer1.MaxSamples And AdvWaveViewer1.leftpos = 0 Then
                Endpos = 0
            Else
                Endpos = AdvWaveViewer1.rightpos
            End If

            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub TrimForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        NumericLeft.Increment = AdvWaveViewer1.SamplesPerPixel
        NumericRight.Increment = AdvWaveViewer1.SamplesPerPixel
    End Sub

    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        NumericLeft.Value = 0
        NumericRight.Value = AdvWaveViewer1.MaxSamples
    End Sub

    Private Sub NumericLeftS_ValueChanged(sender As Object, e As EventArgs) Handles NumericLeftS.ValueChanged
        NumericLeft.Value = NumericLeftS.Value * AdvWaveViewer1.SampleRate
    End Sub

    Private Sub NumericRightS_ValueChanged(sender As Object, e As EventArgs) Handles NumericRightS.ValueChanged
        If (NumericRightS.Value * AdvWaveViewer1.SampleRate) <= NumericRight.Maximum Then
            NumericRight.Value = NumericRightS.Value * AdvWaveViewer1.SampleRate
        Else
            NumericRight.Value = NumericRight.Maximum
            NumericRightS.Value = NumericRight.Value / AdvWaveViewer1.SampleRate
        End If
    End Sub

    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click
        StopIfPlaying()

        Dim bytes((AdvWaveViewer1.rightpos - AdvWaveViewer1.leftpos)) As Byte

        AdvWaveViewer1.WaveStream.Position = AdvWaveViewer1.leftpos
        AdvWaveViewer1.WaveStream.Read(bytes, 0, (AdvWaveViewer1.rightpos - AdvWaveViewer1.leftpos))

        WaveFloatToPlay = New RawSourceWaveStream(New MemoryStream(bytes), AdvWaveViewer1.WaveStream.WaveFormat)

        outputPlayer.Init(WaveFloatToPlay)
        outputPlayer.Play()
        TimerPlayerState.Start()
        EnableGUI(False)
    End Sub

    Private Sub TimerPlayerState_Tick(sender As Object, e As EventArgs) Handles TimerPlayerState.Tick
        Dim CurrentPos = (outputPlayer.GetPosition() / (WaveFloatToPlay.WaveFormat.BitsPerSample / 8))
        AdvWaveViewer1.marker = CurrentPos
        TextBoxPlayback.Text = AdvWaveViewer1.leftSample + CurrentPos
        TextBoxPlaybackS.Text = Math.Round((AdvWaveViewer1.leftSample + CurrentPos) / AdvWaveViewer1.SampleRate, 3)

        If outputPlayer.PlaybackState = PlaybackState.Stopped Then
            StopButton_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        outputPlayer.Stop()
        TimerPlayerState.Stop()
        EnableGUI()
    End Sub

    Private Sub EnableGUI(Optional enable As Boolean = True)
        EnableGroupBoxes(enable)
        AdvWaveViewer1.Enabled = enable
        ResetButton.Enabled = enable
    End Sub

    Private Sub EnableGroupBoxes(Optional enable As Boolean = True)
        GroupBox1.Enabled = enable
        GroupBox2.Enabled = enable
        GroupBox3.Enabled = enable
    End Sub

    Private Sub StopResetPosButton_Click(sender As Object, e As EventArgs) Handles StopResetPosButton.Click
        StopButton_Click(sender, e)
        AdvWaveViewer1.marker = 0
        TextBoxPlayback.Text = NumericLeft.Value
        TextBoxPlaybackS.Text = Math.Round(NumericLeftS.Value, 3)
    End Sub

    Private Sub ButtonMarkLeft_Click(sender As Object, e As EventArgs) Handles ButtonMarkLeft.Click
        NumericLeft.Value = AdvWaveViewer1.leftSample + AdvWaveViewer1.marker
        AdvWaveViewer1.marker = 0
    End Sub

    Private Sub ButtonMarkRight_Click(sender As Object, e As EventArgs) Handles ButtonMarkRight.Click
        NumericRight.Value = AdvWaveViewer1.leftSample + AdvWaveViewer1.marker
        AdvWaveViewer1.marker = 0
    End Sub

    Private Sub TrackBarVolume_Scroll(sender As Object, e As EventArgs) Handles TrackBarVolume.Scroll
        outputPlayer.Volume = TrackBarVolume.Value / 100
        GroupBoxVolume.Text = String.Format("Playback volume ({0})", TrackBarVolume.Value)
    End Sub
End Class