Public NotInheritable Class AboutBox
    Private Sub AboutBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = "Version: " & My.Application.Info.Version.ToString()
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        Me.Close()
    End Sub

    Private Sub ButtonSupport_Click(sender As Object, e As EventArgs) Handles ButtonSupport.Click
        Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=RVLLPGWJUG6CY")
    End Sub
End Class
