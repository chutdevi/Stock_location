Imports System.Data
Imports Newtonsoft.Json.Linq
Imports System.Threading

Public Class Save_move

    Private lSave As ListBox
    Private sLoct As String
    Private sPonm As String
    Public mvl As Move_location

    Private thread_sav As Thread
    Private cnt As Integer
    Private compt As Integer = 0
    Private url
    Public Sub New(ByVal listSave As ListBox, ByVal loct As String, ByVal pon As String)
        lSave = listSave
        sLoct = loct
        sPonm = pon
        InitializeComponent()
    End Sub
    Private Sub Save_move_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cnt = lSave.Items.Count
        compt = 0
        url = "http://192.168.161.102/api_system/Api_forscan/scna_mvlocation_fa?lc=" & sLoct & "&po=" & sPonm
        Label2.Text = cnt.ToString("#,##0")
        thread_sav = New Thread(AddressOf Move_loct)
        thread_sav.IsBackground = True
        thread_sav.Start()
        'Move_loct()
    End Sub
    Private Delegate Sub DoStuffDelegate1()
    Private Delegate Sub DoStuffDelegate2()
    Private Delegate Sub DoStuffDelegate3()
    Private Sub Update_ui1()
        'Application.DoEvents()
        compt = compt + 1
        Label5.Text = compt.ToString("#,##0")
        Dim prg = (compt / cnt) * 100
        Label8.Text = prg.ToString("#,##0.00")
        ProgressBar1.Value = Math.Floor(prg)
    End Sub
    Private Sub Update_ui2()
        Label8.Text = "ข้อมูลขัดข้อง"
        Label8.ForeColor = Color.Red
        BUZZER_ALERT(200, 0, 1, 3, 13, 1)
        System.Threading.Thread.Sleep(100)
        BUZZER_ALERT(200, 0, 1, 3, 3, 1)
        VIBRATOR_ALERT(200, 50, 3, 1)
        LED_ALERT(200, 50, 3, 3, 1)
    End Sub
    Private Sub Update_ui3()
        If ProgressBar1.Value = 100 Then
            Label8.Text = "บันทึกสำเร็จ"
            Label8.ForeColor = Color.Green

            VIBRATOR_ALERT(200, 80, 5, 1)
            LED_ALERT(300, 50, 5, 2, 1)
            BUZZER_ALERT(300, 0, 1, 3, 9, 1)
            System.Threading.Thread.Sleep(100)
            BUZZER_ALERT(400, 0, 1, 3, 13, 1)
        End If
        Button1.Enabled = True
    End Sub
    Private Sub Move_loct()

        For ind As Integer = 0 To cnt - 1
            Dim regx = New System.Text.RegularExpressions.Regex(" +")
            Dim data_list As String() = regx.Split(lSave.Items(ind).ToString())
            Dim str_url As String = url & "&im=" & data_list(0) & "&sq=" & data_list(2)
            'Console.WriteLine(str_url)
            'Console.WriteLine(data_list(0) & " " & data_list(1) & " " & data_list(2) & " " & data_list(3))
            'Console.WriteLine(Get_httpJ(str_url))
            'MsgBox(url & "&im=" & data_list(0) & "&sq=" & Microsoft.VisualBasic.Right(lSave.Items(ind).ToString, 3))
            Dim sv = Get_httpJ(str_url)
            Dim Jflg As String = sv(0)("FLG")
            'Console.WriteLine(sv(0)("FLG"))
            If sv.Count > 0 Then
                If Integer.Parse(Jflg) > 0 Then
                    Dim methodInvoker1 As DoStuffDelegate1 = AddressOf Update_ui1
                    Invoke(methodInvoker1)
                End If
            Else
                Dim methodInvoker2 As DoStuffDelegate2 = AddressOf Update_ui2
                Invoke(methodInvoker2)
            End If

        Next
        Dim methodInvoker3 As DoStuffDelegate3 = AddressOf Update_ui3
        Invoke(methodInvoker3)
    End Sub
    Public Sub Setprogress_save()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
        mvl.CLOSE_AFTER_SAVE()
    End Sub

End Class