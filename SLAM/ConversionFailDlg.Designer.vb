<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConversionFailDlg
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.LabelMsg = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxFailedFiles = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.Location = New System.Drawing.Point(12, 191)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(274, 23)
        Me.ButtonOK.TabIndex = 0
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'LabelMsg
        '
        Me.LabelMsg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelMsg.AutoSize = True
        Me.LabelMsg.Location = New System.Drawing.Point(9, 9)
        Me.LabelMsg.Name = "LabelMsg"
        Me.LabelMsg.Size = New System.Drawing.Size(27, 13)
        Me.LabelMsg.TabIndex = 1
        Me.LabelMsg.Text = "Msg"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "However, the following files failed to convert:"
        '
        'TextBoxFailedFiles
        '
        Me.TextBoxFailedFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxFailedFiles.Location = New System.Drawing.Point(12, 40)
        Me.TextBoxFailedFiles.Multiline = True
        Me.TextBoxFailedFiles.Name = "TextBoxFailedFiles"
        Me.TextBoxFailedFiles.ReadOnly = True
        Me.TextBoxFailedFiles.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxFailedFiles.Size = New System.Drawing.Size(274, 145)
        Me.TextBoxFailedFiles.TabIndex = 3
        Me.TextBoxFailedFiles.WordWrap = False
        '
        'ConversionFailDlg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(298, 226)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBoxFailedFiles)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelMsg)
        Me.Controls.Add(Me.ButtonOK)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConversionFailDlg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SLAM"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonOK As Button
    Friend WithEvents LabelMsg As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxFailedFiles As TextBox
End Class
