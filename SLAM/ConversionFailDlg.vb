Public Class ConversionFailDlg
    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        DialogResult = DialogResult.OK
    End Sub

    Public WriteOnly Property Message As String
        Set(value As String)
            LabelMsg.Text = value
        End Set
    End Property

    Public WriteOnly Property FailedFiles As String
        Set(value As String)
            TextBoxFailedFiles.Text = value
        End Set
    End Property

End Class