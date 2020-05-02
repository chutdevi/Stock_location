Imports System.Data
Imports Newtonsoft.Json.Linq
Public Class Move_location
    Dim Data_tag As DataTable
    Dim main_mv As Move
    Dim Cntlist1 As Integer = 0
    Dim Cntlist2 As Integer = 0
    Dim flg_firt As Integer = 0
    Public main_loc As JArray
    Public Sub New(ByVal dtb As DataTable, ByRef m As Move)
        InitializeComponent()
        Data_tag = dtb
        main_mv = m
        'Me.ShowDialog()
        'Set_scan()
    End Sub
    Private Sub back(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        main_mv.Show()
        Me.Close()
    End Sub
    Private Sub Scan(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Move_location_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Set_scan()
        Label6.Text = String.Empty
        TextBox1.Focus()
        Set_list_tag()
    End Sub
    Public Sub Set_scan()

        'Label2.Visible = False
        'PictureBox4.Enabled = False
        'Label2.Location = New Point(14, 484)
        Dim formScan = New Scan(Label8, Label7)
        flg_firt = 0
        formScan.ShowDialog()
        'formScan.Set()
    End Sub
    Public Sub Set_load()
        Label5.Text = ""
        Label6.Text = ""
    End Sub
    Private Sub Clear_list()
        Set_list_tag()
        TextBox1.Text = ""
        Label6.Text = ""
        TextBox1.Focus()
    End Sub

    Private Sub Set_list_tag()
        Dim num As Integer = 0
        Dim count_data As Integer = Data_tag.Rows.Count
        ListBox2.Items.Clear()
        For i As Integer = 0 To count_data - 1
            Dim item_strlist = Data_tag.Rows(i).Item(1).ToString.PadRight(Len(Data_tag.Rows(i).Item(1).ToString) + 3, " ")
            Dim seqt_strlist = Data_tag.Rows(i).Item(4).ToString.PadLeft(3, "0")
            Dim qtyt_strlist = Data_tag.Rows(i).Item(2).ToString.PadLeft(5, "0")
            ListBox1.Items.Add(item_strlist & qtyt_strlist & "   " & seqt_strlist)
        Next

        Cntlist1 = count_data
        If Cntlist1 > 18 Then
            ListBox1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
            ListBox2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Else
            ListBox1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
            ListBox2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        End If

        Label1.Text = Cntlist1.ToString("#,##0")

        Label2.Text = Cntlist2.ToString("#,##0")

        'TextBox1.Focused = True

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        If TextBox1.Text.Length = 62 Then
            If TextBox1.Text.Substring(0, 2) = "GD" Then
                Dim im As String = TextBox1.Text.Substring(12, 25).Trim()
                Dim po As String = TextBox1.Text.Substring(2, 10)
                Dim sq As String = Microsoft.VisualBasic.Right(TextBox1.Text, 3)
                Dim qt As String = TextBox1.Text.Substring(54, 5).Trim()
                Dim txt_sh = im.PadRight(Len(im) + 3, " ") & qt & "   " & sq
                Label6.Text = txt_sh
                Move_location_Listbox(txt_sh, po)
            Else
                Label6.Text = "TAG ผิดกรุณาตรวจสอบการสแกน"
            End If
            'MsgBox(TextBox1.Text)

            Application.DoEvents()
            TextBox1.Text = ""
            TextBox1.Focus()
            If (Label8.Text = "ไม่มีตำแหน่ง") Then
                main_mv.Show()
                Me.Close()
            End If
        End If

    End Sub
    Private Sub Move_location_Listbox(ByVal str_txt As String, ByVal str_po As String)
        Dim fg_ind = Ckdata_Listbox(str_txt)
        If fg_ind > -1 And Label5.Text = str_po Then
            ListBox2.Items.Add(ListBox1.Items(fg_ind))
            ListBox1.Items.RemoveAt(fg_ind)

            Label1.Text = ListBox1.Items.Count.ToString("#,##0")
            Label2.Text = ListBox2.Items.Count.ToString("#,##0")

            BUZZER_ALERT(200, 0, 1, 3, 15, 1)
            VIBRATOR_ALERT(200, 50, 1, 1)
            LED_ALERT(200, 50, 1, 2, 1)
        Else
            Label6.Text = "TAG ผิดกรุณาตรวจสอบการสแกน"
            BUZZER_ALERT(200, 0, 1, 3, 6, 1)
            System.Threading.Thread.Sleep(100)
            BUZZER_ALERT(200, 0, 1, 3, 15, 1)
            VIBRATOR_ALERT(200, 50, 3, 1)
            LED_ALERT(200, 50, 3, 3, 1)
        End If
        Application.DoEvents()
        TextBox1.Text = ""
        TextBox1.Focus()
    End Sub
    Private Function Ckdata_Listbox(ByVal str_txt As String) As Integer
        For i As Integer = 0 To ListBox1.Items.Count - 1
            If ListBox1.Items(i) = str_txt Then
                Return i
            End If
        Next
        Return -1
    End Function
    Private Sub Save_movelocation()
        Dim savForm As Save_move = New Save_move(ListBox2, Label8.Text, Label5.Text)
        savForm.mvl = Me
        savForm.ShowDialog()

    End Sub


    Private Sub Move_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown, ListBox1.KeyDown, ListBox2.KeyDown, MyBase.KeyDown

        'Console.WriteLine(e.KeyChar & " = " & Convert.ToInt32(e.KeyChar) & " = " & Convert.ToChar(Keys.F1))
        'MsgBox(e.KeyValue & " = " & Convert.ToInt32(e.KeyValue) & " = " & Keys.F1)
        Select Case e.KeyValue
            Case Keys.F1
                main_mv.Show()
                Me.Close()
            Case Keys.F2
                Set_scan()
            Case Keys.F3
                Clear_list()
            Case Keys.F4
                Save_movelocation()
        End Select
    End Sub
    Public Sub CLOSE_AFTER_SAVE()
        Me.Close()
        main_mv.Close()
        SETFORM_MOVE()
    End Sub

    Private Sub ListBox1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.GotFocus, ListBox2.GotFocus
        TextBox1.Focus()
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Save_movelocation()
    End Sub
End Class