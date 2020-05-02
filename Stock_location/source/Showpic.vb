Public Class Showpic
    Public flg = 0
    Private pros As Process1
    Public Sub New(ByVal id As String)
        InitializeComponent()
        PictureBox1.Image = Api.DownloadImage("http://192.168.82.23/member/photo/" & id & ".jpg")
        Refresh()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        LOGOUT()
        Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Close()
        'flg = 2
    End Sub

    Private Sub Showpic_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'MessageBox.Show(Me.Size.Width & " => " & Size.Height)
        Panel2.Location = New Point(10, 453)
    End Sub
End Class