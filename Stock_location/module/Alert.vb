Module Alert

    Dim stBuz As New Bt.LibDef.BT_BUZZER_PARAM()
    Dim stVib As New Bt.LibDef.BT_VIBRATOR_PARAM()
    Dim stLed As New Bt.LibDef.BT_LED_PARAM()

    Sub BUZZER_ALERT(Optional ByVal bzOn As Integer = 200, Optional ByVal bzOff As Integer = 100, _
                     Optional ByVal bzCount As Integer = 2, Optional ByVal bzVolume As Integer = 3, _
                     Optional ByVal bzTone As Integer = 1, Optional ByVal rn As Integer = 0)
        'DWORD dwOn;    ' Activated period (ms; 1 to 5,000)
        'DWORD dwOff;   ' Stopped period (ms; 0 to 5,000)
        'DWORD dwCount; ' Number of activations (0 to 100)
        'BYTE  bTone;   ' Tone (1 [low] to 16 [high])
        'BYTE  bVolume; ' Buzzer volume (1 [low] to 3 [high])
        stBuz.dwOn = bzOn
        stBuz.dwOff = bzOff
        stBuz.dwCount = bzCount
        stBuz.bVolume = bzVolume
        stBuz.bTone = bzTone
        If rn = 1 Then
            Application.DoEvents()
            Bt.SysLib.Device.btBuzzer(1, stBuz)
        End If
    End Sub
    Sub VIBRATOR_ALERT(Optional ByVal viOn As Integer = 200, Optional ByVal viOff As Integer = 100, _
                       Optional ByVal viCount As Integer = 2, Optional ByVal rn As Integer = 0)
        'DWORD dwOn;    ' Activated period (ms; 1 to 5,000)
        'DWORD dwOff;   ' Stopped period (ms; 0 to 5,000)
        'DWORD dwCount; ' Number of activations (0 to 100)
        stVib.dwOn = viOn
        stVib.dwOff = viOff
        stVib.dwCount = viCount
        If rn = 1 Then
            Application.DoEvents()
            Bt.SysLib.Device.btVibrator(1, stVib)
        End If

    End Sub
    Sub LED_ALERT(Optional ByVal ldOn As Integer = 200, Optional ByVal ldOff As Integer = 100, _
                  Optional ByVal ldCount As Integer = 2, Optional ByVal ldColor As Integer = 2, Optional ByVal rn As Integer = 0)
        'DWORD dwOn;    ' Activated period (ms; 1 to 5,000)
        'DWORD dwOff;   ' Stopped period (ms; 0 to 5,000)
        'DWORD dwCount; ' Number of activations (0 to 100)
        'BYTE bColor;   ' Lit color (red, green, yellow, blue, cyan, magenta, or white)
        stLed.dwOn = ldOn
        stLed.dwOff = ldOff
        stLed.dwCount = ldCount
        stLed.bColor = GETING_COLOR(ldColor)
        'BT_LED_RED 
        'BT_LED_ GREEN 
        'BT_LED_BLUE
        'BT_LED_ YELLOW 
        'BT_LED_ CYAN
        'BT_LED_ MAGENTA
        'BT_LED_ WHITE
        If rn = 1 Then
            Application.DoEvents()
            Bt.SysLib.Device.btLED(1, stLed)
        End If
    End Sub
    Private Function GETING_COLOR(Optional ByVal cor As Integer = 1) As Byte
        Select Case cor
            Case 1
                Return Bt.LibDef.BT_LED_RED
            Case 2
                Return Bt.LibDef.BT_LED_GREEN
            Case 3
                Return Bt.LibDef.BT_LED_BLUE
            Case 4
                Return Bt.LibDef.BT_LED_YELLOW
            Case 5
                Return Bt.LibDef.BT_LED_CYAN
            Case 6
                Return Bt.LibDef.BT_LED_MAGENTA
            Case 7
                Return Bt.LibDef.BT_LED_WHITE
            Case Else
                Return Bt.LibDef.BT_LED_RED
        End Select

    End Function


    Public Sub PROGRAM_ALERT()
        Bt.SysLib.Device.btBuzzer(1, stBuz)
        Bt.SysLib.Device.btVibrator(1, stVib)
        Bt.SysLib.Device.btLED(1, stLed)
    End Sub






End Module
