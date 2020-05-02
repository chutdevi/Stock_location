Imports System.Data.SqlClient
Imports System.Data
Imports System.Threading
Imports Newtonsoft.Json.Linq

Public Class Move
    Private proc_f1 As Process1
    Private tag_table As DataTable
    Private flg_movl As Integer = 1
    Public dit As Integer
    Private item_mov As String
    Private thread_loc As Thread
    Private mainloc_data As JArray
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal prg As Process1)
        InitializeComponent()
        proc_f1 = prg
    End Sub
    Public Sub Set_load()
        TextBox1.Visible = False
        TextBox1.Focus()
        If flg_movl = 0 Then
            PictureBox4.Enabled = False
        End If
    End Sub
    Public Sub Set_load_afs()
        InitializeComponent()
        Set_load()
        Set_scan()
    End Sub
    Public Sub Set_scan()
        ListView1.View = View.Details
        ListView1.Items.Clear()
        ListView1.Columns(4).Width = 102
        ListView1.Visible = True
        Label5.Text = ""
        TextBox1.Text = ""
        Label2.Visible = False
        PictureBox4.Enabled = False
        Label2.Location = New Point(14, 355)
        Dim formScan = New Scan_or(TextBox1)
        formScan.ShowDialog()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Set_load()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Label4.Text = Microsoft.VisualBasic.Left(TextBox1.Text, 10)
        If Label4.Text.Length = 10 Then
            'Sqldb.var_temp = proc_f1.flg_con
            Dim Sql = STRING_PODETAIL(Label4.Text, CInt(Microsoft.VisualBasic.Right(TextBox1.Text, 3)).ToString)
            Dim datB As DataTable = Sqldb.GETDATA_PODETAIL(Sql)
            If datB.Rows.Count > 0 Then
                Sql = STRING_PODETAIL_FIX(Label4.Text, datB.Rows(0).Item(3).ToString)
                datB = Sqldb.GETDATA_PODETAIL(Sql)
                Listview_set(datB)
            Else
                Listview_set(datB)
            End If

        End If
    End Sub

    Private Sub back(ByVal sender As System.Object, ByVal e As System.EventArgs)
        proc_f1.Back_Main()
    End Sub
    Private Sub Move_loc()
        Dim mv As Move_location = New Move_location(tag_table, Me)
        thread_loc.Abort()
        mv.main_loc = mainloc_data
        mv.Label5.Text = Label4.Text
        mv.Label7.Text = LinkLabel_cur.Text
        mv.Show()
        Me.Hide()
        mv.Set_scan()
        'mv.Set_scan()
    End Sub

    Private Sub Footer_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click, PictureBox3.Click, PictureBox4.Click, PictureBox5.Click
        Dim sn = DirectCast(sender, PictureBox)
        Select Case sn.Name
            Case "PictureBox2"
                EXIT_FORM_MOVE(Me)
            Case "PictureBox3"
                Set_scan()
            Case "PictureBox4"
                Move_loc()
            Case "PictureBox5"
                'Set_scan()
        End Select
    End Sub


    Private Sub Listview_set(ByRef data_table As DataTable)
        Dim count_data As Integer = data_table.Rows.Count
        'MsgBox(count_data & " & " & count_data - 1)
        Dim amt As Integer = 0
        If count_data > 0 Then

            If count_data > 10 Then
                ListView1.Columns(4).Width = 84
            Else
                ListView1.Columns(4).Width = 102
            End If

            Dim num As Integer = 0

            tag_table = data_table
            ListView1.View = View.Details
            ListView1.Items.Clear()

            LinkLabel_cur.Text = data_table.Rows(0).Item(5).ToString
            item_mov = data_table.Rows(0).Item(1).ToString
            thread_setLink()

            For i As Integer = 0 To count_data - 1
                num = num + 1
                'Console.WriteLine(data_table.Rows(i).Item(4).ToString.PadLeft(3, "0") & " SEQ")
                Dim x = New ListViewItem(num)
                x.SubItems.Add(num)
                x.SubItems.Add(data_table.Rows(i).Item(1).ToString)
                x.SubItems.Add(data_table.Rows(i).Item(4).ToString.PadLeft(3, "0"))
                x.SubItems.Add(data_table.Rows(i).Item(2).ToString)
                If num Mod 2 = 0 Then
                    x.BackColor = Color.FromArgb(192, 255, 255)
                Else
                    x.BackColor = Color.FromArgb(119, 222, 255)
                End If
                ListView1.Items.Add(x)
                amt = amt + CInt(data_table.Rows(i).Item(2))
            Next
            Label5.Text = amt.ToString("#,##0")
        Else
            ListView1.Items.Clear()
            amt = 0
            ListView1.Columns(4).Width = 102
            ListView1.Visible = False
            Label5.Text = "0"
            Label2.Location = New Point(0, 0)
            Label2.Visible = True
        End If


    End Sub
    Private Sub thread_setLink()
        thread_loc = New Thread(AddressOf setThread)
        thread_loc.IsBackground = True
        thread_loc.Start()
    End Sub
    Private Delegate Sub DoStuffDelegate()
    Private Sub setThread()
        Dim ckUser = Get_httpJ("http://192.168.161.102/api_system/api_forscan/scna_ckitemlocation?imt=" & item_mov)
        mainloc_data = ckUser
        If mainloc_data.Count > 0 Then
            If LinkLabel1.InvokeRequired Then
                LinkLabel1.Invoke(New Action(Of String)(AddressOf setThread), mainloc_data(0)("LOCT").ToString)
            Else
                LinkLabel1.Text = mainloc_data(0)("LOCT")
            End If

            Dim methodInvoker As DoStuffDelegate = AddressOf updateUI
            Invoke(methodInvoker)
        End If
    End Sub

    Sub updateUI()
        LinkLabel1.Enabled = True
        PictureBox4.Enabled = True
    End Sub

    Private Sub Move_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown, ListView1.KeyDown, MyBase.KeyDown

        'Console.WriteLine(e.KeyChar & " = " & Convert.ToInt32(e.KeyChar) & " = " & Convert.ToChar(Keys.F1))
        'MsgBox(e.KeyValue & " = " & Convert.ToInt32(e.KeyValue) & " = " & Keys.F1)
        Select Case e.KeyValue
            Case Keys.F1
                EXIT_FORM_MOVE(Me)
            Case Keys.F2
                Set_scan()
            Case Keys.F3
                Move_loc()
            Case Keys.F4
                'Set_scan()
        End Select
    End Sub
End Class
