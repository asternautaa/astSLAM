Public Class HintDialog

    Public ReadOnly Property DontShowAgain As Boolean
        Get
            Return CheckBoxDontShowAgain.Checked
        End Get
    End Property
    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        DialogResult = DialogResult.OK
    End Sub

    Private Sub HintDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Media.SystemSounds.Beep.Play()
    End Sub
End Class