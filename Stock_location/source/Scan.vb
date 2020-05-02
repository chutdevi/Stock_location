Imports Newtonsoft.Json.Linq
'Imports Newtonsoft.Json
Imports System.Windows.Forms
Public Class Scan
    Private proc_f1 As Process1
    Private txt_use As Label
    Private txt_cmp As Label
    Private flg_scan As Integer = 0
    Private flg_form As Integer = 0
    Private Declare Function HideCaret Lib "user32.dll" (ByVal hwnd As Int32) As Int32
    'Private Declare Function ShowCaret Lib "user32.dll" (ByVal hwnd As Int32) As Int32
    Public Sub New(ByVal prg As Process1)
        InitializeComponent()
        proc_f1 = prg
    End Sub
    Public Sub New(ByVal txt As Label)
        InitializeComponent()
        txt_use = txt
        'ShowDialog()
        'proc_f1 = prg
    End Sub
    Public Sub New(ByVal txt As Label, ByVal cmp As Label)
        InitializeComponent()
        txt_use = txt
        txt_cmp = cmp
        'ShowDialog()
        'proc_f1 = prg
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        If TextBox1.Text.Length > 18 Then
            Label15.Text = Microsoft.VisualBasic.Right(TextBox1.Text, 8)
        End If
        If TextBox1.Text <> "" And Timer1.Enabled = True Then
            Timer1.Enabled = False
            Timer1.Enabled = True
            flg_scan = 0
        Else
            Timer1.Enabled = True
        End If

                If flg_form = 0 Then
                    MyBase.Height = 190
                    Clear_detail()
                    flg_form = 1
                End If

    End Sub
    Private Sub PictureBox3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Close()
    End Sub

    Private Sub Scan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MyBase.Height = 190
        TextBox1.Visible = False
        'Clear_detail()
        TextBox1.Focus()
        'Timer1.Enabled = True
    End Sub



    Private Sub Move_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown, MyBase.KeyDown

        'Console.WriteLine(e.KeyChar & " = " & Convert.ToInt32(e.KeyChar) & " = " & Convert.ToChar(Keys.F1))
        'MsgBox(e.KeyValue & " = " & Convert.ToInt32(e.KeyValue) & " = " & Keys.F1)
        Select Case e.KeyValue
            Case Keys.Enter
                Check_confirm()
            Case Keys.F1
                txt_use.Text = "ไม่มีตำแหน่ง"
                Timer1.Enabled = False
                Close()
            Case Keys.F3
                MyBase.Height = 415
            Case Keys.F4
                Clear_detail()
                'TextBox1.Visible = True
        End Select
    End Sub

    Private Sub Clear_detail()
        Label7.Text = ""
        Label10.Text = ""
        Label11.Text = ""
        Label15.Text = ""
        Timer1.Enabled = False
        MyBase.Height = 190
        'Application.DoEvents()
        TextBox1.Focus()
    End Sub

    Private Sub Check_confirm()
        If txt_use.Text = txt_cmp.Text Then
            MsgBox("Part ที่ต้องการจะย้ายอยู่ ตำแหน่งที่ต้องการแล้ว!")
            BUZZER_ALERT(200, 0, 1, 3, 6, 1)
            System.Threading.Thread.Sleep(100)
            BUZZER_ALERT(500, 0, 1, 3, 3, 1)
            VIBRATOR_ALERT(500, 80, 3, 1)
            LED_ALERT(200, 50, 3, 1, 1)
            Clear_detail()
        Else
            Timer1.Enabled = False
            Close()
        End If
    End Sub
    Private Sub Setting_detail(ByRef loc As String, Optional ByRef qty As String = "0", Optional ByRef box As String = "0")
        Label7.Text = loc
        Label10.Text = CInt(qty).ToString("#,##0")
        Label11.Text = CInt(box).ToString("#,##0")

        Label15.Text = ""
        TextBox1.Focus()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        flg_scan = flg_scan + 1
        If Label15.Text <> "ไม่พบข้อมูล" And Label15.Text <> String.Empty And flg_scan = 3 Then
            'Label15.Text = Microsoft.VisualBasic.Right(TextBox1.Text, 8)
            'MsgBox(Microsoft.VisualBasic.Left(Label5.Text, 5))
            Dim ckUser = Get_httpJ("http://192.168.161.102/api_system/api_forscan/scna_cklocation_fa?loc=" & Label15.Text.Trim())
            If ckUser.Count > 0 Then
                Timer1.Enabled = False
                txt_use.Text = Label15.Text
                MyBase.Height = 415
                flg_form = 0
                BUZZER_ALERT(200, 0, 1, 3, 6, 1)
                System.Threading.Thread.Sleep(100)
                BUZZER_ALERT(200, 0, 1, 3, 15, 1)
                VIBRATOR_ALERT(200, 50, 3, 1)
                LED_ALERT(200, 50, 3, 3, 1)
                Setting_detail(ckUser(0)("LOCT"), ckUser(0)("QTY"), ckUser(0)("TAG_BOX"))
                TextBox1.Focus()
            ElseIf Microsoft.VisualBasic.Left(Label15.Text, 5) = "OVERL" Then
                Timer1.Enabled = False
                txt_use.Text = Label15.Text
                MyBase.Height = 415
                flg_form = 0
                BUZZER_ALERT(200, 0, 1, 3, 6, 1)
                System.Threading.Thread.Sleep(100)
                BUZZER_ALERT(200, 0, 1, 3, 15, 1)
                VIBRATOR_ALERT(200, 50, 3, 1)
                LED_ALERT(200, 50, 3, 3, 1)
                Setting_detail(Label15.Text)
                TextBox1.Focus()
            Else
                Timer1.Enabled = False
                TextBox1.Text = ""
                Label15.Text = "ไม่พบข้อมูล"
                BUZZER_ALERT(200, 0, 1, 3, 6, 1)
                System.Threading.Thread.Sleep(100)
                BUZZER_ALERT(500, 0, 1, 3, 3, 1)
                VIBRATOR_ALERT(500, 80, 3, 1)
                LED_ALERT(200, 50, 3, 1, 1)
                TextBox1.Focus()
            End If

            flg_scan = 0
        End If
    End Sub
End Class