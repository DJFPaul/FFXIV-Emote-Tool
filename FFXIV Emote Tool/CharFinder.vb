Public Class charfinder
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Folder As New IO.DirectoryInfo(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Games\FINAL FANTASY XIV - A Realm Reborn")
        RichTextBox1.Text = ""
        RichTextBox3.Text = ""

        For Each File As IO.FileInfo In Folder.GetFiles("*HOTBAR.DAT", IO.SearchOption.AllDirectories)
            RichTextBox1.Text = RichTextBox1.Text & File.FullName & vbNewLine
            RichTextBox3.Text = RichTextBox3.Text & System.IO.File.GetLastWriteTime(File.FullName).ToLongDateString() & " " & System.IO.File.GetLastWriteTime(File.FullName).ToLongTimeString() & vbNewLine
        Next

        For i As Integer = 0 To RichTextBox2.Lines.Length - 2
            If String.Compare(RichTextBox2.Lines(i), RichTextBox3.Lines(i)) <> 0 Then
                MessageBox.Show("Found char at: " & RichTextBox1.Lines(i))
            Else
            End If

        Next
    End Sub

    Private Sub charfinder_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        EmoteTool.WindowState = WindowState.Normal
    End Sub

    Private Sub charfinder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.Text = ""
        RichTextBox2.Text = ""
        Dim Folder As New IO.DirectoryInfo(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Games\FINAL FANTASY XIV - A Realm Reborn")
        For Each File As IO.FileInfo In Folder.GetFiles("*HOTBAR.DAT", IO.SearchOption.AllDirectories)
            RichTextBox1.Text = RichTextBox1.Text & File.FullName & vbNewLine
            RichTextBox2.Text = RichTextBox2.Text & System.IO.File.GetLastWriteTime(File.FullName).ToLongDateString() & " " & System.IO.File.GetLastWriteTime(File.FullName).ToLongTimeString() & vbNewLine
        Next
    End Sub
End Class