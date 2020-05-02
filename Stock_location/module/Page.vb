Imports Newtonsoft.Json.Linq
Module Page
    Public formLogin As Welcome
    Public formMenu As Main
    Public formMove As Move = Nothing

    Private jUSER As JArray = Nothing
    'SETTING MAIN ======================================================*
    Public Sub SETFORM_LOGIN(ByVal form As Welcome, ByVal jay As JArray)
        formLogin = form
        jUSER = jay
        SETFORM_MAIN(New Main())
        SHOW_MAINFORM()
    End Sub
    Public Sub SETFORM_MAIN(ByVal form As Main)
        formMenu = form
    End Sub
    Public Sub SHOW_MAINFORM()
        Sqldb.var_temp = Sqldb.SESSION_ON()
        Dim str_cd As String = jUSER(0)("USER_CD")
        Dim str_name As String = jUSER(0)("USER_TNAME")
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

    'MENU MOVE LOCATION MANAGE ======================================================*
    Public Sub SETFORM_MOVE()
        formMove = New Move()
        SHOW_FORM_MOVE()
    End Sub
    Public Sub SHOW_FORM_MOVE()
        formMove.Show()
        formMove.Set_scan()
    End Sub
    Public Sub EXIT_FORM_MOVE(ByVal sender As Object)
        formMenu.Show()
        DirectCast(sender, Form).Close()
    End Sub
    'LOGOUT=========================================================================*
    Public Sub LOGOUT()
        formLogin.Show()
        formLogin.SET_SHOW()
        formMenu.Close()
    End Sub
End Module
