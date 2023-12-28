Public Class charfinder

    Private Sub charfinder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitialLoad()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CompareLists()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        CompareLists()
    End Sub


    'Populate list with inital values, or update it after denied detection dialogue.
    Private Function InitialLoad()
        RichTextBox1.Text = ""
        RichTextBox2.Text = ""
        Try
            Dim Folder As New IO.DirectoryInfo(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Games\FINAL FANTASY XIV - A Realm Reborn")
            For Each File As IO.FileInfo In Folder.GetFiles("*HOTBAR.DAT", IO.SearchOption.AllDirectories)
                RichTextBox1.Text = RichTextBox1.Text & File.FullName & vbNewLine
                RichTextBox2.Text = RichTextBox2.Text & System.IO.File.GetLastWriteTime(File.FullName).ToLongDateString() & " " & System.IO.File.GetLastWriteTime(File.FullName).ToLongTimeString() & vbNewLine
            Next
        Catch ex As Exception
            MsgBox("Error during initialisation routine." & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & "Exiting Charfinder.", MsgBoxStyle.Critical)
            Timer1.Stop()
            Me.Close()
        Finally
        End Try
        Me.Select()
        Me.BringToFront()
    End Function

    'Gather new list and compare old vs new to detect updated HOTBAR.DAT file.
    Private Function CompareLists()
        Try
            Dim Folder As New IO.DirectoryInfo(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Games\FINAL FANTASY XIV - A Realm Reborn")
            RichTextBox3.Text = ""


            For Each File As IO.FileInfo In Folder.GetFiles("*HOTBAR.DAT", IO.SearchOption.AllDirectories)
                RichTextBox3.Text = RichTextBox3.Text & System.IO.File.GetLastWriteTime(File.FullName).ToLongDateString() & " " & System.IO.File.GetLastWriteTime(File.FullName).ToLongTimeString() & vbNewLine
            Next

            'If creation date differs, print message box showing path to the last changed file.
            For i As Integer = 0 To RichTextBox2.Lines.Length - 1
                If RichTextBox3.Lines(i).Length > 2 Then
                    If String.Compare(RichTextBox2.Lines(i), RichTextBox3.Lines(i)) <> 0 Then

                        Timer1.Stop()
                        Me.BringToFront()
                        Dim Buttons As MessageBoxButtons = MessageBoxButtons.YesNo
                        Dim Result As DialogResult
                        Result = MessageBox.Show("Found char at: " & RichTextBox1.Lines(i) & vbNewLine & vbNewLine & "Load into Emote Tool?", "Load to Emote Tool?", Buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)

                        'Load into EmoteTool and close
                        If Result = DialogResult.Yes Then
                            EmoteTool.TextBox1.Text = RichTextBox1.Lines(i)
                            EmoteTool.OpenFileDialog1.FileName = RichTextBox1.Lines(i)
                            EmoteTool.patchenabled = True
                            EmoteTool.PictureBox1.Show()
                            Me.Close()

                            Exit For


                        Else
                            InitialLoad()
                            Timer1.Start()

                        End If
                    Else
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("Error during comparison check." & vbNewLine & ex.Message & vbNewLine & vbNewLine & "Exiting Charfinder.", MsgBoxStyle.Critical)
            Timer1.Stop()
            Me.Close()
        Finally
        End Try
    End Function

    'Show EmoteTool again and bring it to the front.
    Private Sub charfinder_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        EmoteTool.Show()
        EmoteTool.WindowState = FormWindowState.Normal
        EmoteTool.BringToFront()
        EmoteTool.Select()
        EmoteTool.Activate()
    End Sub
End Class