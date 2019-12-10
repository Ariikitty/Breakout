Public Class Breakout
    Private intDx As Integer = 4
    Private intDy As Integer = -3
    Private intScore As Integer = 0
    Private intLives As Integer = 3
    ' creates an arry of pictureboxes
    Const Maxbricks As Integer = 13
    Private pbxBricks(Maxbricks + 1) As PictureBox
    Private Sub TmrGame_Tick(sender As Object, e As EventArgs) Handles TmrGame.Tick
        Call MoveBall()
        Call CollisionBallBat()
        Call CollisionBallBricks()
        Call EndOfLevel()
    End Sub
    Private Sub MoveBall()
        pbxBall.Left += intDx
        pbxBall.Top += intDy
        ' ball bounces off the top
        If pbxBall.Top < 0 Then
            intDy = -intDy
        End If
        ' ball bounces off the left
        If pbxBall.Left < 0 Then
            intDx = -intDx
        End If
        If pbxBall.Right > Me.Width - 20 Then
            intDx = -intDx
        End If
        If pbxBall.Bottom > Me.Height - 30 Then
            intLives -= 1
            lblLives.Text = intLives
            pbxBall.Top = Me.Height / 2
            If intLives = 0 Then
                TmrGame.Enabled = False
                MsgBox("Game Over")
            End If
        End If
    End Sub
    Private Sub Breakout_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        pbxBat.Left = e.X
    End Sub
    Private Sub CollisionBallBat()
        If pbxBall.Bounds.IntersectsWith(pbxBat.Bounds) Then
            intDy = -intDy
            ' different between cnetre of the bat and the ball is X speed
            Dim intcenterbat As Integer = pbxBat.Left + pbxBat.Width / 2
            Dim intcenterball As Integer = pbxBall.Left + pbxBall.Width / 2
            Dim intDiff As Integer = intcenterball - intcenterbat
            intDx = intDiff / 2
        End If
    End Sub
    Private Sub Breakout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Creates the bricks
        pbxBricks(0) = PictureBox1
        pbxBricks(1) = PictureBox2
        pbxBricks(2) = PictureBox3
        pbxBricks(3) = PictureBox4
        pbxBricks(4) = PictureBox5
        pbxBricks(5) = PictureBox6
        pbxBricks(6) = PictureBox7
        pbxBricks(7) = PictureBox8
        pbxBricks(8) = PictureBox9
        pbxBricks(9) = PictureBox10
        pbxBricks(10) = PictureBox11
        pbxBricks(11) = PictureBox12
        pbxBricks(12) = PictureBox13
        pbxBricks(13) = PictureBox14
    End Sub
    Private Sub CollisionBallBricks()
        Dim i As Integer
        For i = 0 To Maxbricks
            ' When the ball hits a brick
            If pbxBall.Bounds.IntersectsWith(pbxBricks(i).Bounds) Then
                ' If the brick is visable (not been hit) then make it invisable
                If pbxBricks(i).Visible = True Then
                    pbxBricks(i).Visible = False
                    ' Reverse the current direction of travel
                    intDy = -intDy
                    ' Score counts 1
                    intScore += 1
                    lblScore.Text = intScore
                End If
            End If
        Next
    End Sub
    Private Sub EndOfLevel()
        Dim i As Integer
        ' Loop through all of the bricks
        For i = 0 To Maxbricks
            If pbxBricks(i).Visible = True Then
                Exit Sub
            End If
        Next
        ' No visable bricks found
        For i = 0 To Maxbricks
            pbxBricks(i).Visible = True
        Next
    End Sub
End Class