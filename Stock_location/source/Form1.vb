Imports System.IO
Public Class Main
    Private OorZa
    Private proc_f1 As Process1
    Public Sub New()
        InitializeComponent()

    End Sub
    Public Sub New(ByVal prg As Process1)
        InitializeComponent()
        proc_f1 = prg
        Refresh()
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        'proc_f1.Main_To_Move()
        'proc_f1.formMove.Set_scan()
        SETFORM_MOVE()
        'SHOW_FORM_MOVE()
        ' proc_f1.M_To_Scanor()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        'proc_f1.M_To_Scan()
        'proc_f1.M_To_Check()
        'proc_f1.M_To_Scan()
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click

        'Application.Exit()
    End Sub

    Private Sub Move_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        'Console.WriteLine(e.KeyChar & " = " & Convert.ToInt32(e.KeyChar) & " = " & Convert.ToChar(Keys.F1))
        'MsgBox(e.KeyValue & " = " & Convert.ToInt32(e.KeyValue) & " = " & Keys.F1)
        Select Case e.KeyValue
            Case Keys.F1
                LOGOUT()
            Case Keys.F2
                'Set_scan()
            Case Keys.F3
                'Set_scan()
            Case Keys.F4
                'Set_scan()
            Case Keys.NumPad1
                SETFORM_MOVE()
            Case Else
                ';MsgBox(e.KeyValue)
        End Select
    End Sub


    Private Sub Panel2_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel2.GotFocus

    End Sub
End Class
