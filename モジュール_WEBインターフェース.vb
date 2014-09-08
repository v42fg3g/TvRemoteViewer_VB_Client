Imports System.Net
Imports System.Text
Imports System
Imports System.IO

Module モジュール_WEBインターフェース
    'TvRemoteViewer_VB WEBインターフェースへの窓口
    Public Function GET_HTML_REPLY(ByVal url As String, ByVal para As String, Optional ByVal enc_str As String = "Shift_JIS") As String
        Dim r As String = ""

        'パラメーターをurlに追加
        Dim st_str As String = url
        If para.Length > 0 Then
            If url.IndexOf("?") > 0 Then
                st_str = url & " &" & para
            Else
                st_str = url & " ?" & para
            End If
        End If

        Try
            'HttpWebRequestの作成
            Dim webreq As System.Net.HttpWebRequest = _
                CType(System.Net.WebRequest.Create(st_str), System.Net.HttpWebRequest)

            '認証の設定 パスワードが設定されていれば username,password
            If M_username.Length > 0 And M_password.Length > 0 Then
                webreq.Credentials = New System.Net.NetworkCredential(M_username, M_password)
            End If

            'HttpWebResponseの取得
            Dim webres As System.Net.HttpWebResponse = CType(webreq.GetResponse(), System.Net.HttpWebResponse)

            '受信
            Dim st As System.IO.Stream = webres.GetResponseStream()
            'Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding(932)
            Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding(enc_str)
            Dim sr As New System.IO.StreamReader(st, enc)
            r = sr.ReadToEnd()
            '閉じる
            sr.Close()
            st.Close()
        Catch ex As Exception
            r = ex.Message
        End Try

        Return r
    End Function

    '配信スタート
    Public Function WI_START_STREAM(ByVal num As Integer, ByVal BonDriver As String, ByVal ServiceID As Integer, ByVal chspace As Integer, ByVal resolution As String, ByVal NHKMODE As Integer, ByVal stream_mode As Integer, ByVal VideoFilename As String) As String
        'TvRemoteViewer_VB->WebRemocon.vb->Web_Start
        Dim r As String = ""
        Dim para As String = ""

        para &= "num=" & num.ToString & "&"
        para &= "BonDriver=" & BonDriver & "&"
        para &= "ServiceID=" & ServiceID.ToString & "&"
        para &= "ChSpace=" & chspace.ToString & "&"
        para &= "resolution=" & resolution & "&"
        para &= "NHKMODE=" & NHKMODE.ToString & "&"
        para &= "StreamMode=" & stream_mode.ToString

        'Dim VideoFullpathFileName As String = "C:\VIDEO\test.ts"
        ''なぜかそのまま渡すと返ってきたときに文字化けするのでURLエンコードしておく
        'Dim VideoFullpathFileName_enc As String = System.Web.HttpUtility.UrlEncode(VideoFullpathFileName)
        'para &= "VideoName=" & VideoFullpathFileName_enc

        r = GET_HTML_REPLY(M_TVRV_URL & "WI_START_STREAM.html", para, "Shift_JIS")

        Return r
    End Function

    '配信停止
    Public Function WI_STOP_STREAM(ByVal num As Integer) As String
        'TvRemoteViewer_VB->WebRemocon.vb->Web_Start
        Dim r As String = ""
        Dim para As String = ""
        para = "num=" & num.ToString
        r = GET_HTML_REPLY(M_TVRV_URL & "WI_STOP_STREAM.html", para, "Shift_JIS")
        Return r
    End Function

    '放送局一覧
    Public Function WI_GET_CHANNELS() As String
        'TvRemoteViewer_VB->WebRemocon.vb->Web_Start
        'TvRemoteViewer_VB->ProcessManager.vb->WI_GET_CHANNELS
        Dim r As String = ""
        r = GET_HTML_REPLY(M_TVRV_URL & "WI_GET_CHANNELS.html", "")
        Return r
    End Function

    '配信中リスト取得
    Public Function WI_GET_LIVE_STREAM() As String
        'TvRemoteViewer_VB->WebRemocon.vb->Web_Start
        'TvRemoteViewer_VB->ProcessManager.vb->WI_GET_LIVE_STREAM
        Dim r As String = ""
        r = GET_HTML_REPLY(M_TVRV_URL & "WI_GET_LIVE_STREAM.html", "")
        Return r
    End Function

    'サーバー設定を取得
    Public Function WI_GET_TVRV_STATUS() As String
        'TvRemoteViewer_VB->WebRemocon.vb->Web_Start
        'TvRemoteViewer_VB->WebRemocon.vb->WI_GET_TVRV_STATUS()
        Dim r As String = ""
        r = GET_HTML_REPLY(M_TVRV_URL & "WI_GET_TVRV_STATUS.html", "")
        Return r
    End Function

    Public Function WI_GET_TSFILE_COUNT(ByVal num As Integer) As String
        'TvRemoteViewer_VB->WebRemocon.vb->Web_Start
        'TvRemoteViewer_VB->WebRemocon.vb->WI_GET_TSFILE_COUNT()
        Dim r As String = ""
        Dim para As String = ""
        para = "num=" & num.ToString
        r = GET_HTML_REPLY(M_TVRV_URL & "WI_GET_TSFILE_COUNT.html", para)
        Return r
    End Function

End Module
