<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XIVDialogue
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.YesBox = New System.Windows.Forms.PictureBox()
        Me.OkBox = New System.Windows.Forms.PictureBox()
        Me.NoBox = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.YesBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OkBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NoBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'YesBox
        '
        Me.YesBox.BackgroundImage = Global.FFXIV_Emote_Tool.My.Resources.Resources.YesUnlit
        Me.YesBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.YesBox.Location = New System.Drawing.Point(27, 159)
        Me.YesBox.Name = "YesBox"
        Me.YesBox.Size = New System.Drawing.Size(96, 22)
        Me.YesBox.TabIndex = 0
        Me.YesBox.TabStop = False
        '
        'OkBox
        '
        Me.OkBox.BackgroundImage = Global.FFXIV_Emote_Tool.My.Resources.Resources.OkUnlit
        Me.OkBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.OkBox.Location = New System.Drawing.Point(151, 159)
        Me.OkBox.Name = "OkBox"
        Me.OkBox.Size = New System.Drawing.Size(96, 22)
        Me.OkBox.TabIndex = 1
        Me.OkBox.TabStop = False
        '
        'NoBox
        '
        Me.NoBox.BackgroundImage = Global.FFXIV_Emote_Tool.My.Resources.Resources.NoUnlit
        Me.NoBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NoBox.Location = New System.Drawing.Point(275, 159)
        Me.NoBox.Name = "NoBox"
        Me.NoBox.Size = New System.Drawing.Size(96, 22)
        Me.NoBox.TabIndex = 2
        Me.NoBox.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(378, 147)
        Me.Label1.TabIndex = 3
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'XIVDialogue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.FFXIV_Emote_Tool.My.Resources.Resources.DialogueBG
        Me.ClientSize = New System.Drawing.Size(398, 193)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NoBox)
        Me.Controls.Add(Me.OkBox)
        Me.Controls.Add(Me.YesBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "XIVDialogue"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "XIVDialogue"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Lime
        CType(Me.YesBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OkBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NoBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents YesBox As PictureBox
    Friend WithEvents OkBox As PictureBox
    Friend WithEvents NoBox As PictureBox
    Friend WithEvents Label1 As Label
End Class
