'Imports System.Net
'Imports System.IO
Imports Newtonsoft.Json.Linq
'Imports Newtonsoft.Json
Imports System.Windows.Forms
'Imports System.Threading
Imports System.Data
Imports System.Data.SqlClient

Public Class Process1
    Public formLogin As Welcome
    Public formMenu As Main
    Public formMove As Move
    Public formScan_Or As Scan_or
    Public formScan As Scan
    Public formCheck As Check

    Public con As New SqlConnection
    Public cmd As SqlCommand
    Public sql As String
    Public dr As SqlDataReader

    Public flg_con As Integer
    'Dim trdRead As Thread
    Dim str_cd As String
    Dim str_name As String



    Public Sub New(ByVal gh As Welcome)
        formLogin = gh
    End Sub
    Public Sub Set_Op(ByVal gh As Process1)
        formMenu = New Main(gh)
        formMove = New Move(gh)
        formScan_Or = New Scan_or(gh)
        'formScan = New Scan(gh)
        formCheck = New Check(gh)

    End Sub

    Public Sub Login_Menu(ByVal udata As JArray)


        'formLogin.Label6.Text = "ID : " & udata(0)("USER_CD").ToString() & " NAME : " & udata(0)("USER_TNAME").ToString()
        'formLogin.Label6.ForeColor = Color.Green
        'formLogin.Label6.Visible = True
        flg_con = Sqldb.SESSION_ON()
        Sqldb.var_temp = flg_con
        str_cd = udata(0)("USER_CD")
        str_name = udata(0)("USER_TNAME")
        formMenu.Label1.Text = "ID : " & str_cd & " NAME : " & str_name
        formMenu.Label1.ForeColor = Color.Green

        formLogin.Timer1.Dispose()
        'formMenu.TopMost = True
        Dim sPic As Showpic = New Showpic(str_cd)
        'trdRead = New Thread(AddressOf ThreadRead)

        'trdRead.Start(formLogin)
        formMenu.Show()
        formLogin.Hide()

        sPic.ShowDialog()

    End Sub

    
    Public Sub M_To_Check()
        formCheck.Show()
        'formCheck.Enabled = False
    End Sub
    Public Sub Logout_Menu()
        formLogin.set_show()
        formLogin.Show()
        formMenu.Hide()
    End Sub
    Public Sub Back_Main()
        formMenu.Show()
        formMove.Hide()
    End Sub
    Public Sub Main_To_Move()
        formMove.Show()
        'formMove.Enabled = False
    End Sub
    Public Sub M_To_Scan()
        'formScan.Show()
    End Sub
    Public Sub M_To_Scanor()
        formScan_Or.Show()
    End Sub
    Public Sub Scan_To_Scanor()
        formScan_Or.Show()
    End Sub
    Public Sub Scan_To_Scan()
        formScan.Show()
    End Sub
   
    Public Sub clear_label4()
        formMove.Label4.Text = ""
    End Sub
    
    Public Sub inputor_to_Move()
        'formScan_Or.orderno.Text = formMove.Label4.Text
        'formMove.Label4.Text = formScan_Or.orderno.Text
        'formMove.ListBox1.Items.Add(formScan_Or.orderno.Text)
        formMove.Label4.Text = formScan_Or.orderno.Text
        formMove.Enabled = True
        formMove.Show()
        'If formScan_Or.orderno.Text = "" Then
        'formMove.Label4.Text = formScan_Or.orderno.Text
        'formMove.Show()
        'Else
        'formMove.Label4.Text = ""
        'formMove.Show()
        'End If
        'formMove.TextBox2.Text = "Connected"
        'formMove.TextBox2.ForeColor = Color.Green
        'conn.Open()
    End Sub
    Public Sub Scan_or_To_M()
        formMenu.Show()
    End Sub
    Public Sub Scan_To_Menu()
        formMenu.Show()
    End Sub
  
    Sub ThreadRead(ByRef atr As Welcome)
        ' Try
        'Thread.Sleep(1000)

        'Catch ex As Exception
        'MsgBox(ex.Message)
        'Finally
        'trdRead.Abort()
        'End Try

    End Sub

    
    Public Sub Scan_Po()
        con = New SqlConnection("Server=192.168.161.101; user id=pcs_admin; password=P@ss!fa; database=FASYSTEM;")
        con.Open()


        Try

            sql = "SELECT * FROM FA_RECEIVE_TAG WHERE PUCH_ODR_CD = " & "'" & formScan_Or.orderno.Text & "'"
            ''sql = "SELECT RECEIVE_TOTAL,PUCH_ODR_CD FROM FA_RECEIVE_TAG WHERE PUCH_ODR_CD = " & "'" & formScan_Or.orderno.Text & "'"
            cmd = New SqlCommand(sql, con)

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            formMove.Label4.Text = formScan_Or.orderno.Text
            formMove.ListView1.View = View.Details
            formMove.ListView1.Items.Clear()
            Dim x As ListViewItem          
            Dim num As Integer = 0


            Do While dr.Read = True
                formMove.Label5.Text = (dr("RECEIVE_TOTAL").ToString())
                num = num + 1
                x = New ListViewItem(num)
                x.SubItems.Add(dr("ITEM_CD").ToString())
                x.SubItems.Add(dr("TAG_QTY").ToString())
                x.SubItems.Add(dr("SEQ").ToString())

                formMove.ListView1.Items.Add(x)           
            Loop
        Catch ex As Exception

        Finally
            cmd.Dispose()
            con.Close()
        End Try
       
        formMove.Show()
        formMove.Enabled = True
    End Sub

End Class