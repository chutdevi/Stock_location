Public Class Check
    Private proc_f1 As Process1
    Public Sub New(ByVal prg As Process1)
        InitializeComponent()
        proc_f1 = prg
    End Sub
    Public Sub Set_load()
        TextBox1.Visible = False
        TextBox1.Focus()

    End Sub
    Private Sub back(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Scan(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        proc_f1.Scan_To_Scan()
    End Sub

    Private Sub Check_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        proc_f1.Back_Main()
    End Sub
End Class
