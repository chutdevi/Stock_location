Module Query_string
    Sub Query_string()

        Console.WriteLine("Test")

        'MsgBox("TESS")
    End Sub
    Friend Function STRING_PODETAIL(ByRef str_cond As String, ByRef str_seq As String) As String
        Return String.Format("SELECT PUCH_ODR_CD, ITEM_CD, TAG_SEQ, LOCATION_PART FROM FA_RECEIVE_TAG WHERE PUCH_ODR_CD = '{0}' AND TAG_SEQ = '{1}'", str_cond, str_seq)
    End Function
    Friend Function STRING_PODETAIL_FIX(ByRef str_cond As String, ByRef str_loct As String) As String
        Return String.Format("SELECT PUCH_ODR_CD, ITEM_CD, TAG_QTY, RECEIVE_TOTAL, TAG_SEQ, LOCATION_PART, MAX_TAG FROM FA_RECEIVE_TAG " _
                           & "WHERE PUCH_ODR_CD = '{0}' AND LOCATION_PART = '{1}' ORDER BY 5" _
                           , str_cond, str_loct)
    End Function
    Friend Function STRING_LOCATIONDETAIL(ByRef str_cond As String) As String
        Return String.Format("SELECT PUCH_ODR_CD, ITEM_CD, TAG_QTY, RECEIVE_TOTAL, TAG_SEQ, MAX_TAG FROM FA_RECEIVE_TAG WHERE PUCH_ODR_CD = '{0}' ORDER BY 5" _
                            , str_cond)
    End Function

End Module
