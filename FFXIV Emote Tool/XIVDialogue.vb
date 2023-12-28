Public Class XIVDialogue
    Public YesNoMode As String = False
    Public YesState As Boolean = False
    Public TrueCenter As Boolean = False
    Dim InitialLocation As Point
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

    Private Sub XIVDialogue_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'On first launch, log position and call position on each reoccuring launch to stay centered on main screen.
        If InitialLocation.IsEmpty = False Then
            If TrueCenter = True Then
                Me.Location = InitialLocation
                TrueCenter = False
            End If
        Else
            InitialLocation = Me.Location
        End If

        'Configure buttons depending on active mode.
        If YesNoMode = True Then
            YesBox.Show()
            NoBox.Show()
            OkBox.Hide()
        Else
            YesBox.Hide()
            NoBox.Hide()
            OkBox.Show()
        End If
        YesState = False
        YesNoMode = False
    End Sub



    'UI Shenanigans
    Private Sub YesBox_MouseEnter(sender As Object, e As EventArgs) Handles YesBox.MouseEnter
        YesBox.BackgroundImage = My.Resources.YesLit
    End Sub

    Private Sub YesBox_MouseLeave(sender As Object, e As EventArgs) Handles YesBox.MouseLeave
        YesBox.BackgroundImage = My.Resources.YesUnlit
    End Sub

    Private Sub OkBox_MouseEnter(sender As Object, e As EventArgs) Handles OkBox.MouseEnter
        OkBox.BackgroundImage = My.Resources.OkLit
    End Sub

    Private Sub OkBox_MouseLeave(sender As Object, e As EventArgs) Handles OkBox.MouseLeave
        OkBox.BackgroundImage = My.Resources.OkUnlit
    End Sub

    Private Sub NoBox_MouseEnter(sender As Object, e As EventArgs) Handles NoBox.MouseEnter
        NoBox.BackgroundImage = My.Resources.NoLit
    End Sub

    Private Sub NoBox_MouseLeave(sender As Object, e As EventArgs) Handles NoBox.MouseLeave
        NoBox.BackgroundImage = My.Resources.NoUnlit
    End Sub


    'Dialogue buttons
    Private Sub OkBox_Click(sender As Object, e As EventArgs) Handles OkBox.Click
        Me.Close()
    End Sub

    Private Sub YesBox_Click(sender As Object, e As EventArgs) Handles YesBox.Click
        YesState = True
        Me.Close()
    End Sub

    Private Sub NoBox_Click(sender As Object, e As EventArgs) Handles NoBox.Click
        YesState = False
        Me.Close()
    End Sub

    Private Sub XIVDialogue_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        YesNoMode = False
    End Sub
End Class