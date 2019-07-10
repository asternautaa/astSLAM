<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class YTDLImport
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
        Me.ImportAllButton = New System.Windows.Forms.Button()
        Me.TextBoxUrls = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBoxVideoOnly = New System.Windows.Forms.CheckBox()
        Me.OpenDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'ImportAllButton
        '
        Me.ImportAllButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImportAllButton.Location = New System.Drawing.Point(361, 132)
        Me.ImportAllButton.Name = "ImportAllButton"
        Me.ImportAllButton.Size = New System.Drawing.Size(86, 23)
        Me.ImportAllButton.TabIndex = 0
        Me.ImportAllButton.Text = "Import"
        Me.ImportAllButton.UseVisualStyleBackColor = True
        '
        'TextBoxUrls
        '
        Me.TextBoxUrls.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxUrls.Location = New System.Drawing.Point(12, 25)
        Me.TextBoxUrls.Multiline = True
        Me.TextBoxUrls.Name = "TextBoxUrls"
        Me.TextBoxUrls.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxUrls.Size = New System.Drawing.Size(435, 101)
        Me.TextBoxUrls.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(327, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Enter the URLs of videos separated by space or new line character."
        '
        'CheckBoxVideoOnly
        '
        Me.CheckBoxVideoOnly.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxVideoOnly.AutoSize = True
        Me.CheckBoxVideoOnly.Checked = True
        Me.CheckBoxVideoOnly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxVideoOnly.Location = New System.Drawing.Point(12, 136)
        Me.CheckBoxVideoOnly.Name = "CheckBoxVideoOnly"
        Me.CheckBoxVideoOnly.Size = New System.Drawing.Size(340, 17)
        Me.CheckBoxVideoOnly.TabIndex = 12
        Me.CheckBoxVideoOnly.Text = "Download only the video, if the URL refers to a video and a playlist"
        Me.CheckBoxVideoOnly.UseVisualStyleBackColor = True
        '
        'OpenDialog
        '
        Me.OpenDialog.Multiselect = True
        '
        'YTDLImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(459, 167)
        Me.Controls.Add(Me.ImportAllButton)
        Me.Controls.Add(Me.CheckBoxVideoOnly)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxUrls)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(475, 135)
        Me.Name = "YTDLImport"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import via youtube-dl"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ImportAllButton As Button
    Friend WithEvents TextBoxUrls As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckBoxVideoOnly As CheckBox
    Friend WithEvents OpenDialog As OpenFileDialog
End Class
