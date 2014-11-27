Imports System.Text
Imports System.Net.Sockets

'
'+----[ Remote control commands ]
'|
'| add XYZ . . . . . . . . . . . . add XYZ to playlist
'| enqueue XYZ . . . . . . . . . queue XYZ to playlist
'| playlist . . . . . show items currently in playlist
'| play . . . . . . . . . . . . . . . . . . play stream
'| stop . . . . . . . . . . . . . . . . . . stop stream
'| next . . . . . . . . . . . . . . next playlist item
'| prev . . . . . . . . . . . . previous playlist item
'| goto . . . . . . . . . . . . . . goto item at index
'| repeat [on|off] . . . . toggle playlist item repeat
'| loop [on|off] . . . . . . . . . toggle playlist loop
'| random [on|off] . . . . . . . toggle random jumping
'| clear . . . . . . . . . . . . . . clear the playlist
'| status . . . . . . . . . . . current playlist status
'| title [X] . . . . . . set/get title in current item
'| title_n . . . . . . . . next title in current item
'| title_p . . . . . . previous title in current item
'| chapter [X] . . . . set/get chapter in current item
'| chapter_n . . . . . . next chapter in current item
'| chapter_p . . . . previous chapter in current item
'|
'| seek X . . . seek in seconds, for instance `seek 12'
'| pause . . . . . . . . . . . . . . . . toggle pause
'| fastforward . . . . . . . . . set to maximum rate
'| rewind . . . . . . . . . . . . set to minimum rate
'| faster . . . . . . . . . . faster playing of stream
'| slower . . . . . . . . . . slower playing of stream
'| normal . . . . . . . . . . normal playing of stream
'| f [on|off] . . . . . . . . . . . . toggle fullscreen
'| info . . . . . information about the current stream
'| stats . . . . . . . . show statistical information
'| get_time . . seconds elapsed since stream's beginning
'| is_playing . . . . 1 if a stream plays, 0 otherwise
'| get_title . . . . . the title of the current stream
'| get_length . . . . the length of the current stream
'|
'| volume [X] . . . . . . . . . . set/get audio volume
'| volup [X] . . . . . . . raise audio volume X steps
'| voldown [X] . . . . . . lower audio volume X steps
'| adev [X] . . . . . . . . . . . set/get audio device
'| achan [X]. . . . . . . . . . set/get audio channels
'| atrack [X] . . . . . . . . . . . set/get audio track
'| vtrack [X] . . . . . . . . . . . set/get video track
'| vratio [X] . . . . . . . set/get video aspect ratio
'| vcrop [X] . . . . . . . . . . . set/get video crop
'| vzoom [X] . . . . . . . . . . . set/get video zoom
'| snapshot . . . . . . . . . . . . take video snapshot
'| strack [X] . . . . . . . . . set/get subtitles track
'| key [hotkey name] . . . . . . simulate hotkey press
'| menu . . [on|off|up|down|left|right|select] use menu
'|
'| help . . . . . . . . . . . . . . . this help message
'| longhelp . . . . . . . . . . . a longer help message
'| logout . . . . . . . exit (if in socket connection)
'| quit . . . . . . . . . . . . . . . . . . . quit vlc
'|
'+----[ end of help ]
'

Module VLCリモート操作
    Const WaitTimeout As Integer = 2000
    Public ASCIIEncoding As New ASCIIEncoding()
    Private client As TcpClient

    'VLCに命令を送って返事を受け取る
    Public Function VLC_remote(ByVal command As String, ByVal port As Integer) As String
        Dim result As String = ""
        Try
            client = New TcpClient("127.0.0.1", port) 'VLCが起動していないとここでエラー
            SendCommand(command)
            result = WaitForResult().Trim()
        Catch ex As Exception
        Finally
            Try
                client.Close()
            Catch ex As Exception
            End Try
        End Try

        Return result
    End Function

    Private Function WaitForResult() As String
        Dim result As String = ""
        Dim start As DateTime = DateTime.Now
        While (DateTime.Now - start).TotalMilliseconds < WaitTimeout
            result = ReadTillEnd()
            If Not String.IsNullOrEmpty(result) Then
                Exit While
            End If
        End While
        Return result
    End Function

    Private Sub SendCommand(command As String)
        SendCommand(command, Nothing)
    End Sub

    Private Sub SendCommand(command As String, param As String)
        ' flush old stuff
        ReadTillEnd()

        Dim packet As String = command.ToLower
        If param IsNot Nothing Then
            packet += " " & param
        End If
        packet += Environment.NewLine

        Dim buffer = ASCIIEncoding.GetBytes(packet)
        client.GetStream().Write(buffer, 0, buffer.Length)
        client.GetStream().Flush()

        Trace.Write(packet)
    End Sub

    Public Function ReadTillEnd() As String
        Dim bytes As Byte() = Nothing

        Try
            Dim i As Integer = 0
            While client.GetStream().DataAvailable
                Dim b As Integer = client.GetStream().ReadByte()
                If b >= 0 Then
                    ReDim Preserve bytes(i)
                    bytes(i) = b 'sb.Append(ChrW(b))
                    i += 1
                Else
                    Exit While
                End If
            End While
        Catch ex As Exception
            'おそらくオーバーフロー
        End Try

        'Dim Str As String = System.Text.Encoding.GetEncoding(932).GetString(bytes)
        Dim Str As String = ""

        Try
            Str = System.Text.Encoding.UTF8.GetString(bytes)
        Catch ex As Exception
            Str = ""
        End Try

        Return Str
    End Function

    Public Function ReadTillEnd_org() As String
        Dim sb As New StringBuilder()
        While client.GetStream().DataAvailable
            Dim b As Integer = client.GetStream().ReadByte()
            If b >= 0 Then
                sb.Append(ChrW(b))
            Else
                Exit While
            End If
        End While

        Return sb.ToString()
    End Function

    '=================================================
    '旧来のコマンド　送信のみ
    '=================================================

    'TCPコマンドを送る
    Public Function rc_VLC(ByVal cmd As String, ByVal port As Integer) As Integer
        Dim r As Integer = 0
        Try

            Dim tcpPort As Integer = port

            ' ソケット生成
            Dim objSck As New System.Net.Sockets.TcpClient
            Dim objStm As System.Net.Sockets.NetworkStream

            ' TCP/IP接続
            objSck.Connect("127.0.0.1", tcpPort)
            objStm = objSck.GetStream()

            ' TCP/IP接続待ち
            Do While objSck.Connected = False
                System.Threading.Thread.Sleep(500)
            Loop

            ' データ送信(文字列をByte配列に変換して送信)
            'Dim sdat As Byte() = System.Text.Encoding.GetEncoding("SHIFT-JIS").GetBytes(cmd)
            Dim sdat As Byte() = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(cmd)
            objStm.Write(sdat, 0, sdat.GetLength(0))

            ' TCP/IP切断
            objStm.Close()
            objSck.Close()

            r = 1 '成功
        Catch ex As Exception
            r = 0
        End Try

        Return r
    End Function

End Module
