Public Class Scan_or
    Private proc_f1 As Process1
    Private txt_use As TextBox

    Public Sub New(ByVal prg As Process1)
        InitializeComponent()
        proc_f1 = prg
    End Sub
    Public Sub New(ByVal txt As TextBox)
        InitializeComponent()
        txt_use = txt
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles orderno.TextChanged
        If orderno.Text.Length = 62 Then
            If orderno.Text.Substring(0, 2) = "GD" Then
                txt_use.Text = orderno.Text.Substring(2, 10) & Microsoft.VisualBasic.Right(orderno.Text, 3)

                BUZZER_ALERT(200, 0, 1, 3, 6, 1)
                System.Threading.Thread.Sleep(100)
                BUZZER_ALERT(200, 0, 1, 3, 15, 1)
                VIBRATOR_ALERT(200, 50, 3, 1)
                LED_ALERT(200, 50, 3, 3, 1)
                Me.Close()
            ElseIf IsNumeric(orderno.Text.Substring(0, 3)) And orderno.Text.Substring(0, 2) = "51" Then
                txt_use.Text = orderno.Text.Substring(0, 10) & "001"
                BUZZER_ALERT(200, 0, 1, 3, 6, 1)
                System.Threading.Thread.Sleep(100)
                BUZZER_ALERT(200, 0, 1, 3, 15, 1)
                VIBRATOR_ALERT(200, 50, 3, 1)
                LED_ALERT(200, 50, 3, 3, 1)
                Me.Close()
            Else
                orderno.Text = ""
                BUZZER_ALERT(200, 0, 1, 3, 5, 1)
                System.Threading.Thread.Sleep(100)
                BUZZER_ALERT(200, 0, 1, 3, 3, 1)
                System.Threading.Thread.Sleep(100)
                BUZZER_ALERT(200, 0, 1, 3, 1, 1)

                VIBRATOR_ALERT(200, 50, 3, 1)
                LED_ALERT(200, 50, 3, 3, 1)
            End If
        End If
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub
    Private Sub Move_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles orderno.KeyDown, MyBase.KeyDown

        'Console.WriteLine(e.KeyChar & " = " & Convert.ToInt32(e.KeyChar) & " = " & Convert.ToChar(Keys.F1))
        'MsgBox(e.KeyValue & " = " & Convert.ToInt32(e.KeyValue) & " = " & Keys.F1)
        Select Case e.KeyValue
            Case Keys.F1
                Me.Close()
            Case Keys.F2
                'Set_scan()
            Case Keys.F3
                'Move_loc()
            Case Keys.F4
                'Set_scan()
        End Select
    End Sub
End Class