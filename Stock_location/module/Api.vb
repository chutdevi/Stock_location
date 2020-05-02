Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json
Imports System.Windows.Forms.Form


Module Api

    Public Function Get_httpJ(ByVal url As String) As JArray
        Try
            Dim requestUrl As String = url
            'Dim requestUrl As String = "http://192.168.0.2/api_system/api_receiveinsystem/json_re"
            Dim request As HttpWebRequest = TryCast(WebRequest.Create(requestUrl), HttpWebRequest)
            Dim response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            Dim result = responseFromServer
            'Dim jsonResulttodict = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(result)
            'Dim firstItem = jsonResulttodict.Item("USER_CD")
            'Console.WriteLine(firstItem)

            Dim json = JArray.Parse(result)
            reader.Close()
            response.Close()
            Get_httpJ = json
        Catch ex As Exception
            'Console.WriteLine(ex.Message)
            Get_httpJ = JArray.Parse("[]")
        End Try

    End Function

    Public Function Get_httpO(ByVal url As String) As JObject
        Try
            Dim requestUrl As String = url
            'Dim requestUrl As String = "http://192.168.0.2/api_system/api_receiveinsystem/json_re"
            Dim request As HttpWebRequest = TryCast(WebRequest.Create(requestUrl), HttpWebRequest)
            Dim response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            Dim result = responseFromServer
            'Dim jsonResulttodict = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(result)
            'Dim firstItem = jsonResulttodict.Item("USER_CD")
            'Console.WriteLine(firstItem)

            Dim json = JObject.Parse(result)
            reader.Close()
            response.Close()
            Get_httpO = json
        Catch ex As Exception
            'Console.WriteLine(ex.Message)
            Get_httpO = JObject.Parse("{}")
        End Try

    End Function



    Public Function DownloadImage1(ByVal imageUrl As String) As System.Drawing.Image
        'Dim img = New Imaging
        Dim temp As System.Drawing.Image = My.Resources.ResourceManager.GetObject("Stock_location/ing")


        'Console.WriteLine(image.ToString());
        DownloadImage1 = temp
    End Function
    Public Function DownloadImage(ByVal _URL As String) As Image
        Dim _tmpImage As Image = Nothing

        Try
            ' Open a connection
            Dim _HttpWebRequest As System.Net.HttpWebRequest = CType(System.Net.HttpWebRequest.Create(_URL), System.Net.HttpWebRequest)

            _HttpWebRequest.AllowWriteStreamBuffering = True

            ' You can also specify additional header values like the user agent or the referer: (Optional)
            _HttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)"
            _HttpWebRequest.Referer = "http://www.google.com/"

            ' set timeout for 20 seconds (Optional)
            _HttpWebRequest.Timeout = 20000

            ' Request response:
            Dim _WebResponse As System.Net.WebResponse = _HttpWebRequest.GetResponse()

            ' Open data stream:
            Dim _WebStream As System.IO.Stream = _WebResponse.GetResponseStream()

            ' convert webstream to image
            _tmpImage = New System.Drawing.Bitmap(_WebStream)


            ' Cleanup
            _WebResponse.Close()
            _WebResponse.Close()
        Catch _Exception As Exception
            ' Error
            Console.WriteLine("Exception caught in process: {0}", _Exception.ToString())
            Return Nothing
        End Try

        Return _tmpImage
    End Function




End Module