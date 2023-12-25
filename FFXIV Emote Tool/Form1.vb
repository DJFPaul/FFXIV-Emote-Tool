Imports System.IO
Public Class Form1
    Dim patchenabled As Boolean = False

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



    'Form Load code to show initial info message.
    'Additionally it checks if it can automatically detect the FFXIV Config folder, and preconfigures it as a path.
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox("This Utility will modify HOTBAR.DAT to add 2 hidden emotes." & vbNewLine & vbNewLine & "Usage of this utility is at your own risk." & vbNewLine & vbNewLine & "- Make sure your hotbar 8 is set to shared." & vbNewLine & "- Log out of the character the HOTBAR.DAT belongs to." & vbNewLine & vbNewLine & "Please make a backup of your HOTBAR.DAT", MsgBoxStyle.Information)
        If My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Games\FINAL FANTASY XIV - A Realm Reborn") Then
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Games\FINAL FANTASY XIV - A Realm Reborn"
        End If
    End Sub


    'This codes is for the "OPEN" button.
    'It handles the open file dialogue and enables patch button after successful selection.
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            If OpenFileDialog1.SafeFileName = "HOTBAR.DAT" Then
                TextBox1.Text = OpenFileDialog1.FileName
                patchenabled = True
                PictureBox1.Show()
            Else
                MsgBox(OpenFileDialog1.SafeFileName & " is not a valid filename.", MsgBoxStyle.Critical)
                patchenabled = False
                PictureBox1.Hide()
            End If
        Else
        End If
    End Sub


    'This code is for the "PATCH" button.
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        'Check if patchbutton is unlocked.
        If patchenabled = True Then

            'Show Yes/No confirmation messagebox.
            Dim Buttons As MessageBoxButtons = MessageBoxButtons.YesNo
            Dim Result As DialogResult
            Result = MessageBox.Show("Reminder: Useage is at your own risk!" & vbNewLine & vbNewLine & "- Make sure your hotbar 8 is set to shared." & vbNewLine & "- Log out of the character the HOTBAR.DAT belongs to." & vbNewLine & vbNewLine & "Please make a backup of your HOTBAR.DAT" & vbNewLine & vbNewLine & "Do you want to apply the patch?", "Patch HOTBAR.DAT?", Buttons, MessageBoxIcon.Exclamation)

            'Confirmation denied, do not patch.
            If Result = DialogResult.No Then
                MsgBox("Patching has been aborted.", MsgBoxStyle.Exclamation)
            End If

            'Confirmation accepted, try patching HOTBAR.DAT
            If Result = DialogResult.Yes Then
                Try
                    'This HEX edits the HOTBAR.DAT while keeping all other data intact.
                    Dim fs As New FileStream(OpenFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite)
                    Dim strHex As String = "6931313131363B375131313131363A37"
                    fs.Position = &H3E0
                    For j As Integer = 0 To strHex.Length - 1 Step 2
                        fs.WriteByte(CByte(Conversion.Val("&H" & strHex.Substring(j, 2))))
                    Next
                    fs.Close()
                    fs.Dispose()
                    MsgBox("HOTBAR.DAT has been edited." & vbNewLine & vbNewLine & "You can now log in to your character." & vbNewLine & "The emotes should be on menu 8 slot 11 and 12.", MsgBoxStyle.Information)
                Catch Ex As Exception
                    MsgBox("An error occured: " & Ex.Message, MsgBoxStyle.Critical)
                Finally
                    'Disable patchbuton and false the check value.
                    patchenabled = False
                    PictureBox1.Hide()
                End Try
            End If
        Else
            'Button has been pressed while checkvalue is not True.
            patchenabled = False
            PictureBox1.Hide()
            MsgBox("An error occured: Patchcheck returned false.", MsgBoxStyle.Critical)
        End If

    End Sub


    'This prints a path hint when the blue ? is pressed.
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        MsgBox("You can find the HOTBAR.DAT at the following example path." & vbNewLine & vbNewLine & "C:\Users\<User>\Documents\My Games\ " & vbNewLine & "FINAL FANTASY XIV - A Realm Reborn\" & vbNewLine & "FFXIV_CHR################\HOTBAR.DAT", MsgBoxStyle.Information)
    End Sub


    'Close button.
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub

    'UI Visual Shenanigans.
    Private Sub PictureBox1_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.BackgroundImage = My.Resources.Patch_Lit
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BackgroundImage = My.Resources.Patch
    End Sub

    Private Sub PictureBox2_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox2.MouseEnter
        PictureBox2.BackgroundImage = My.Resources.Open
    End Sub

    Private Sub PictureBox2_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.BackgroundImage = My.Resources.Transparent
    End Sub

    Private Sub PictureBox3_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox3.MouseEnter
        PictureBox3.BackgroundImage = My.Resources.X_Lit
    End Sub

    Private Sub PictureBox3_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.BackgroundImage = My.Resources.Transparent
    End Sub

    Private Sub Label1_MouseEnter(sender As Object, e As EventArgs) Handles Label1.MouseEnter
        Label1.ForeColor = Color.DeepSkyBlue
    End Sub

    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = Color.DodgerBlue
    End Sub
End Class