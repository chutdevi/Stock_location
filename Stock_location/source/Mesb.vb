Public Class Mesb
    Private msg_title As String
    Private msg_contn As String
    Private flg_con As Integer = 0
    Public Sub New(ByVal msg As String, Optional ByVal til As String = "")
        msg_title = til
        msg_contn = msg

        InitializeComponent()
        MyBase.ShowDialog()
    End Sub
    Private Sub Mesb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Name = msg_title
        Label2.Text = msg_contn

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click
        Dim obj_pm = DirectCast(sender, Button)
        Select Case obj_pm.Name
            Case "Button1"
                flg_con = 1
            Case "Button2"
                flg_con = 0
        End Select
    End Sub
    Public Function Dialog_conm() As Integer
        Return flg_con
    End Function
End Class