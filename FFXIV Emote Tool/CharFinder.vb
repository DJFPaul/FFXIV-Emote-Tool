Public Class charfinder

    'This section is for allowing the form to be dragged by the mouse.
    Private CurrentPosition As New System.Drawing.Point
    Private MouseButton As System.Windows.Forms.MouseButtons = Nothing
    Private Overloads Sub OnMouseDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        MyClass.MouseButton = e.Button()
        With MyClass.CurrentPosition
            .X = e.X()
            .Y = e.Y()
        End With
    End Sub
    Private Overloads Sub OnMouseMove(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        Select Case MouseButton
            Case Is = Me.MouseButtons.Left
                MyClass.Top = Me.Cursor.Position.Y() - MyClass.CurrentPosition.Y()
                MyClass.Left = Me.Cursor.Position.X() - MyClass.CurrentPosition.X()
            Case Is = Nothing
                Exit Sub
        End Select
    End Sub
    Private Overloads Sub OnMouseUp(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        MyClass.MouseButton = Nothing
    End Sub
    'End of mouse movement section.

    Private Sub charfinder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitialLoad()
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
                        XIVDialogue.YesNoMode = True
                        XIVDialogue.Label1.Text = "HOTBAR.DAT change detected." & vbNewLine & vbNewLine & RichTextBox1.Lines(i) & vbNewLine & vbNewLine & "Load into Emote Tool?"
                        XIVDialogue.TrueCenter = True
                        XIVDialogue.ShowDialog()

                        'Load into EmoteTool and close
                        If XIVDialogue.YesState = True Then
                            XIVDialogue.YesNoMode = False

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

    'UI Shenanigans
    Private Sub PictureBox3_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox3.MouseEnter
        PictureBox3.BackgroundImage = My.Resources.X_Lit
    End Sub

    Private Sub PictureBox3_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.BackgroundImage = My.Resources.Transparent
    End Sub

    'Show EmoteTool again and bring it to the front.
    Private Sub charfinder_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        EmoteTool.Show()
        EmoteTool.WindowState = FormWindowState.Normal
        EmoteTool.BringToFront()
        EmoteTool.Select()
        EmoteTool.Activate()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub

End Class