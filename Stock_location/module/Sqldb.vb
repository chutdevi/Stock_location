'Imports System.Net
'Imports System.IO
Imports Newtonsoft.Json.Linq
'Imports Newtonsoft.Json
Imports System.Windows.Forms
'Imports System.Threading
Imports System.Data
Imports System.Data.SqlClient


Module Sqldb
    Public con As SqlConnection
    Public cmd As SqlCommand
    Public crd As SqlDataReader
    Public var_temp As Integer


    Public Function SESSION_ON() As Integer
        Try
            con = New SqlConnection("Server=192.168.161.101; user id=pcs_admin; password=P@ss!fa; database=FASYSTEM;")
            con.Open()
            SESSION_ON = 1

        Catch ex As Exception
            Console.WriteLine(var_temp & " error SESSION_ON : " & ex.Message)
            SESSION_ON = 0
        End Try
    End Function

    Public Function GETDATA_PODETAIL(ByRef po_str As String) As DataTable
        Try
            If Not (con.State = ConnectionState.Open) Then

                SESSION_ON()

            End If

            'MsgBox(Sql)
            'Console.WriteLine(Sql)
            ''sql = "SELECT RECEIVE_TOTAL,PUCH_ODR_CD FROM FA_RECEIVE_TAG WHERE PUCH_ODR_CD = " & "'" & formScan_Or.orderno.Text & "'"
            'cmd = New SqlCommand(Sql, con)

            'crd = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            'Dim num As Integer = 0
            Dim da = New SqlDataAdapter(po_str, con)
            Dim dt = New DataTable()
            da.Fill(dt)
            'MsgBox(dt.Rows(0).Item(1))
            'Console.Write(dt.Rows(0).Item(1))


            Return dt
        Catch ex As Exception
            'Console.WriteLine(var_temp & " error GETDATA_PODETAIL : " & ex.Message)
        Finally
            'cmd.Dispose()
            'con.Close()
        End Try
        GETDATA_PODETAIL = Nothing
    End Function
    Public Function GETDATA_PODETAIL_DS(ByRef sql As String) As DataSet
        Try

            'Dim Sql = STRING_PODETAIL(po_str)

            'Console.WriteLine(Sql)
            ''sql = "SELECT RECEIVE_TOTAL,PUCH_ODR_CD FROM FA_RECEIVE_TAG WHERE PUCH_ODR_CD = " & "'" & formScan_Or.orderno.Text & "'"
            'cmd = New SqlCommand(Sql, con)

            'crd = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            'Dim num As Integer = 0
            Dim da = New SqlDataAdapter(Sql, con)
            Dim ds = New DataSet
            da.Fill(ds, "DETAIL")
            Console.Write(ds)


            GETDATA_PODETAIL_DS = ds
        Catch ex As Exception
            Console.WriteLine(var_temp & " error GETDATA_PODETAIL_DS : " & ex.Message)
        Finally
            'cmd.Dispose()
            'con.Close()
        End Try
        GETDATA_PODETAIL_DS = Nothing
    End Function

End Module
