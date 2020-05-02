Public Class Welcome

    Dim proc As Process1
    Dim str_key = 0

    Private Sub Welcome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Focus()
        'proc = New Process1(Me)
        'proc.Set_Op(proc)
        Timer1.Enabled = True
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Label5.Text = TextBox1.Text
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Application.DoEvents()
        If TextBox1.Text.Length >= 5 Then
            Application.DoEvents()
            Label6.Text = "กรุณารอสักครู่ กำลังเข้าสู่ระบบ..."
            Label6.Visible = True
            'Dim ckUser = Api.Get_http("http://192.168.0.5/api_system/api_emptransfer/user_ck?user=" & TextBox1.Text)
            Dim ckUser = Api.Get_httpJ("http://192.168.161.102/api_system/api_emptransfer/user_ck?user=" & TextBox1.Text)

            If ckUser.Count > 0 Then
                Timer1.Enabled = False
                Timer1.Dispose()
                SETFORM_LOGIN(Me, ckUser)
                'proc.Login_Menu(ckUser)
            Else
                Label6.Text = "รหัส บัตรผิดพลาด กรุณา สแกนใหม่อีกครั้ง"
                TextBox1.Text = ""
            End If
            Label6.Visible = True
        End If
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown, MyBase.KeyDown
        'MsgBox(e.KeyCode)
        Evk.KeyDown_even(e.KeyValue)
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp, MyBase.KeyUp
        Evk.Keyup_even()
    End Sub

    Public Sub SET_SHOW()
        TextBox1.Focus()
        TextBox1.Text = ""
        Label6.Text = ""
        'proc = New Process1(Me)
        'proc.Set_Op(proc)
        Timer1.Enabled = True
    End Sub

    Private Sub Label5_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.ParentChanged

    End Sub
End Class