Public Class YTDLImport


    Public ReadOnly Property URLs As String
        Get
            Return TextBoxUrls.Text
        End Get
    End Property

    Public ReadOnly Property NoPlaylist As Boolean
        Get
            Return CheckBoxVideoOnly.Checked
        End Get
    End Property


    Private Sub ImportAllButton_Click(sender As Object, e As EventArgs) Handles ImportAllButton.Click
        DialogResult = DialogResult.OK
    End Sub
    Private Sub YTImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBoxUrls.Select()
    End Sub

End Class