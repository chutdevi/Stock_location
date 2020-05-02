Module Evk

    Dim _keyData = 0
    Sub Main()

    End Sub

    Public Sub KeyDown_even(ByVal key_cd As Integer)
        Select Case key_cd
            Case Keys.F1
                _keyData = _keyData + key_cd
            Case Keys.F3
                _keyData = _keyData + key_cd
        End Select
    End Sub
    Public Sub Keyup_even()
        Select Case _keyData
            Case (Keys.F1 + Keys.F3)
                Application.Exit()
        End Select

        _keyData = 0
    End Sub

End Module
