Public Class Form1
    'サーバーステータス表示
    Private Sub ButtonServerStatus_Click(sender As System.Object, e As System.EventArgs) Handles ButtonServerStatus.Click
        TextBoxLog.Text = WI_GET_TVRV_STATUS()
        '結果

    End Sub

    'BonDriver＆チャンネル一覧
    Private Sub ButtonShowChannels_Click(sender As System.Object, e As System.EventArgs) Handles ButtonShowChannels.Click
        TextBoxLog.Text = WI_GET_CHANNELS()
        '結果
        'BonDriver名, ServiceID, ChSpace, 放送局名
    End Sub

    '配信中ストリームの状態
    Private Sub ButtonShowStreams_Click(sender As System.Object, e As System.EventArgs) Handles ButtonShowStreams.Click
        TextBoxLog.Text = WI_GET_LIVE_STREAM()
        '結果
        '内部_List番号, 配信ナンバー, RecTaskUDPポート, BonDriver名, ServiceID, ChSpace, Stream_mode, NHKMODE, 停止中=1, 放送局名, HlsAppファイル名
    End Sub

    '配信スタート
    Private Sub ButtonStart_Click(sender As System.Object, e As System.EventArgs) Handles ButtonStart.Click
        'StreamMode 0=HLS再生 1=HLSファイル再生 2=HTTPストリーム再生　3=HTTPストリームファイル再生
        TextBoxLog.Text = WI_START_STREAM( _
                            Val(ComboBoxNum.Text), _
                            TextBoxBonDriver.Text.ToString, _
                            Val(TextBoxServiceID.Text), _
                            Val(TextBoxChSpace.Text), _
                            ComboBoxResolution.Text, _
                            Val(ComboBoxNHKMODE.Text), _
                            Val(ComboBoxStreamMode.Text), _
                            "" _
                            )
    End Sub

    '配信停止
    Private Sub ButtonStop_Click(sender As System.Object, e As System.EventArgs) Handles ButtonStop.Click
        TextBoxLog.Text = WI_STOP_STREAM(Val(ComboBoxNum.Text))
    End Sub

    'サーバーhttp作成
    Private Sub TextBoxServerIP_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxServerIP.TextChanged
        Dim url As String = TextBoxServerIP.Text.ToString
        If url.Length > 0 Then
            Dim sp As Integer
            '先頭にhttp://が無ければ追加する
            If url.IndexOf("http://") < 0 Then
                url = "http://" & url
            End If
            '末尾に/が無ければ追加する
            sp = url.LastIndexOf("/")
            If sp < 0 Or (sp >= 0 And sp <> url.Length - 1) Then
                url &= "/"
            End If
        End If
        M_TVRV_URL = url
    End Sub

    'usernameセット
    Private Sub TextBoxServerUsername_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxServerUsername.TextChanged
        M_username = TextBoxServerUsername.Text.ToString
    End Sub

    'passwordセット
    Private Sub TextBoxServerPassword_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxServerPassword.TextChanged
        M_password = TextBoxServerPassword.Text.ToString
    End Sub

    '指定numberのmystream%NUM%*.tsの数
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        TextBoxLog.Text = WI_GET_TSFILE_COUNT(Val(ComboBoxNum.Text))
    End Sub

    'VLCで視聴
    Private Sub ButtonRunVLC_Click(sender As System.Object, e As System.EventArgs) Handles ButtonRunVLC.Click
        Dim vlc_path As String = TextBoxVLCPATH.Text.ToString
        Dim vlc_url As String = TextBoxVLCURL.Text.ToString

        '★VLCを実行
        'ProcessStartInfoオブジェクトを作成する
        Dim udpPsi As New System.Diagnostics.ProcessStartInfo()
        '起動するファイルのパスを指定する
        udpPsi.FileName = vlc_path
        'コマンドライン引数を指定する
        udpPsi.Arguments = vlc_url
        'アプリケーションを起動する
        Dim udpProc As System.Diagnostics.Process = System.Diagnostics.Process.Start(udpPsi)
        udpProc.PriorityClass = System.Diagnostics.ProcessPriorityClass.High

    End Sub
End Class
