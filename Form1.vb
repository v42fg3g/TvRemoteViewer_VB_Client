Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        log1write(version)

        'フォーム項目を復元
        F_window_set()

        'サーバーの状態
        S_server_status_str = WI_GET_TVRV_STATUS() 'サーバーの状態
        If S_server_status_str.IndexOf("接続できません") < 0 Then
            Dim sp As Integer = S_server_status_str.IndexOf("HTTPSTREAM_App=")
            If sp >= 0 Then
                Dim HTTPSTREAM_App As Integer = Val(S_server_status_str.Substring(sp + "HTTPSTREAM_App=".Length))
                If HTTPSTREAM_App <> 1 Then
                    MsgBox("サーバー TvRemoteViewer_VB.ini内のHTTPSTREAM_Appを1に設定してくだい。")
                    Close()
                End If
            End If
            '成功
            log1write("サーバーに接続しました")
            S_BonDriver_Channel_str = WI_GET_CHANNELS() 'BonDriverとチャンネル一覧を取得
            'フォーム上の項目をセット
            search_BonDriver() 'BonDriverをセット
            search_ServiceID() 'サービスIDをセット
            set_selectnumber() 'SELECTナンバーをセット
            set_resolution() '解像度をセット
            set_videofiles() 'ファイル一覧をセット
            show_LabelStream() '現在稼働中のプロセスを表示
        Else
            Debug.Print("[" & S_server_status_str & "]")
            '失敗
            log1write("サーバーと接続できません。サーバーIPを設定して再起動してください")
        End If

        '無事に起動した
        TvRemoteViewer_VB_client_start = 1
        Timer1.Enabled = True
    End Sub

    Private Sub Form1_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'VLCを消してストリームも停止する
        For i = 0 To 29
            If player_proc(i) > 0 Then
                Try
                    stop_stream(i)
                Catch ex As Exception
                End Try
            End If
        Next

        'フォーム項目を保存
        If TvRemoteViewer_VB_client_start = 1 Then
            save_form_status()
        End If
    End Sub

    '=========================================================================
    'タイマー
    '=========================================================================

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Dim i As Integer = 0

        'VLCのcrashダイアログが出ていたら消す
        check_crash_dialog()

        'VLCが消されたら停止する
        For i = 0 To 29
            If player_proc(i) > 0 Then
                Try
                    Dim ps As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessById(player_proc(i))
                    If ps.HasExited = True Then
                        player_proc(i) = 0
                        log1write("VLCが閉じられたのでストリームを停止します")
                        stop_stream(i)
                        log1write("VLCが閉じられたのでストリームを停止しました[1]")
                    End If
                Catch ex As Exception
                    player_proc(i) = 0
                    log1write("VLCが閉じられたのでストリームを停止します")
                    stop_stream(i)
                    log1write("VLCが閉じられたのでストリームを停止しました[2] " & ex.Message)
                End Try
            End If
        Next

        'ログ処理 'モジュール_ログでその都度更新することにした
        'If log1.Length > 20000 Then
        ''10000文字以上になったらカット
        'log1 = log1.Substring(0, 20000)
        'End If
        'If log1 <> TextBoxLog.Text Then
        'TextBoxLog.Text = log1
        'End If
        'Refresh()
        'TextBoxLog.Refresh()
    End Sub

    'VLCのcrashダイアログが表示されていれば消す
    Public Sub check_crash_dialog()
        Dim h As IntPtr
        Dim w As RECT

        h = FindWindow(vbNullString, "VLC crash reporting")
        If GetWindowRect(h, w) = 1 Then
            '最前面にする
            SetForegroundWindow(h)
            F_sendkeycode(&H9) 'VK_TAB = &H9 'TAB key
            System.Threading.Thread.Sleep(30)
            F_sendkeycode(&HD) 'VK_RETURN = &HD 'ENTER key
            log1write("VLC crash reportingウィンドウを消しました。")
        End If
    End Sub

    '=========================================================================
    'フォーム上の項目をセット等
    '=========================================================================

    'BonDriverを探してコンボボックスに追加
    Private Sub search_BonDriver()
        ComboBoxBonDriver.Items.Clear()
        Dim html As String = S_BonDriver_Channel_str

        Dim sp As Integer = html.IndexOf("[bondriver")
        While sp >= 0
            Dim b As String = Instr_pickup(html, "[", "]", sp)
            If b.IndexOf("bondriver") >= 0 Then
                ComboBoxBonDriver.Items.Add(b)
            End If
            sp = html.IndexOf("[bondriver", sp + 1)
        End While
    End Sub

    'フォーム上の項目を復元
    Public Sub F_window_set()
        'カレントディレクトリ変更
        F_set_ppath4program()

        Dim line() As String = file2line("form_status.txt")
        If line IsNot Nothing Then
            Dim i As Integer
            For i = 0 To line.Length - 1
                Dim lr() As String = line(i).Split("=")
                If lr.Length = 2 Then
                    Select Case trim8(lr(0))
                        Case "TextBoxServerIP"
                            TextBoxServerIP.Text = lr(1)
                        Case "TextBoxServerUsername"
                            TextBoxServerUsername.Text = lr(1)
                        Case "TextBoxServerPassword"
                            TextBoxServerPassword.Text = lr(1)
                        Case "ComboBoxResolution"
                            ComboBoxResolution.Text = lr(1)
                        Case "ComboBoxNHKMODE"
                            ComboBoxNHKMODE.Text = lr(1)
                        Case "ComboBoxNum"
                            ComboBoxNum.Text = lr(1)
                        Case "ComboBoxBonDriver"
                            ComboBoxBonDriver.Text = lr(1)
                        Case "TextBoxChSpace"
                            TextBoxChSpace.Text = lr(1)
                        Case "ComboBoxBonDriver"
                            ComboBoxBonDriver.Text = lr(1)
                        Case "TextBoxChSpace"
                            TextBoxChSpace.Text = lr(1)
                        Case "ComboBoxServiceID"
                            ComboBoxServiceID.Text = lr(1)
                        Case "TextBoxVLCPATH"
                            TextBoxVLCPATH.Text = lr(1)
                        Case "TextBoxVLCURL"
                            TextBoxVLCURL.Text = lr(1)
                        Case "TextBoxSuccessSecond"
                            TextBoxSuccessSecond.Text = lr(1)
                    End Select
                End If
            Next
        End If
    End Sub

    'フォーム上の項目を保存
    Private Sub save_form_status()
        Dim s As String = ""

        s &= "TextBoxServerIP=" & TextBoxServerIP.Text & vbCrLf
        s &= "TextBoxServerUsername=" & TextBoxServerUsername.Text & vbCrLf
        s &= "TextBoxServerPassword=" & TextBoxServerPassword.Text & vbCrLf
        s &= "ComboBoxResolution=" & ComboBoxResolution.Text & vbCrLf
        s &= "ComboBoxNHKMODE=" & ComboBoxNHKMODE.Text & vbCrLf
        s &= "ComboBoxNum=" & ComboBoxNum.Text & vbCrLf
        s &= "ComboBoxBonDriver=" & ComboBoxBonDriver.Text & vbCrLf
        s &= "TextBoxChSpace=" & TextBoxChSpace.Text & vbCrLf
        s &= "ComboBoxBonDriver=" & ComboBoxBonDriver.Text & vbCrLf
        s &= "TextBoxChSpace=" & TextBoxChSpace.Text & vbCrLf
        s &= "ComboBoxServiceID=" & ComboBoxServiceID.Text & vbCrLf
        s &= "TextBoxVLCPATH=" & TextBoxVLCPATH.Text & vbCrLf
        s &= "TextBoxVLCURL=" & TextBoxVLCURL.Text & vbCrLf
        s &= "TextBoxSuccessSecond=" & TextBoxSuccessSecond.Text & vbCrLf

        'カレントディレクトリ変更
        F_set_ppath4program()
        'ステータスファイル書き込み
        str2file("form_status.txt", s)
    End Sub

    'フォーム上のファイル一覧をセット
    Private Sub set_videofiles()
        ComboBoxVideo.Items.Clear()
        Dim html As String = WI_GET_VIDEOFILES()

        Dim sp As Integer = html.IndexOf("<option value=""", 0)
        While sp >= 0
            Dim value As String = Instr_pickup(html, "<option value=""", """>", sp)
            Dim name As String = Instr_pickup(html, """>", "</option>", sp)

            ComboBoxVideo.Items.Add(name & Space(100) & ":" & value)

            sp = html.IndexOf("<option value=""", sp + 1)
        End While

        If ComboBoxVideo.Items.Count > 0 Then
            ComboBoxVideo.Text = ComboBoxVideo.Items(0)
        End If
    End Sub

    'フォーム上の解像度をセット
    Private Sub set_resolution()
        ComboBoxResolution.Items.Clear()
        Dim html As String = WI_GET_RESOLUTION()
        'stream_mode=2を取得
        Dim sp As Integer = html.IndexOf("[stream_mode=2]")
        If sp >= 0 Then
            html = Trim(html.Substring(sp + "[stream_mode=2]".Length))
            Dim line() As String = Split(html, vbCrLf)
            If line IsNot Nothing Then
                Dim s As String = ""
                For i As Integer = 0 To line.Length - 1
                    If Trim(line(i).Length) > 0 Then
                        Try
                            If line(i).Substring(0, 1) <> "[" Then
                                ComboBoxResolution.Items.Add(Trim(line(i)))
                            Else
                                '次の[stream_mode=x]に来たよう
                                Exit For
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next
            End If
        End If
    End Sub

    'フォーム上のナンバーセレクトをセット
    Public Sub set_selectnumber()
        ComboBoxNum.Items.Clear()
        Dim sp As Integer = S_server_status_str.IndexOf("MAX_STREAM_NUMBER=")
        If sp >= 0 Then
            Dim max As Integer = Val(S_server_status_str.Substring(sp + "MAX_STREAM_NUMBER=".Length))
            If max <= 0 Then
                max = 8 '標準
            End If
            For i As Integer = 0 To max - 1
                ComboBoxNum.Items.Add(i + 1)
            Next
        End If
    End Sub

    '配信中を更新
    Public Sub show_LabelStream()
        Dim r As String = "配信中："
        Dim response As String = WI_GET_LIVE_STREAM()
        Dim d() As String = Split(response, vbCrLf)
        Dim i As Integer = 0
        If d IsNot Nothing Then
            For i = 0 To d.Length - 1
                Dim youso() As String = d(i).Split(",")
                Try
                    r &= youso(1) & " "
                Catch ex As Exception
                End Try
            Next
        End If
        LabelStream.Text = r
    End Sub

    '=========================================================================
    'フォーム上のボタン、テキスト、コンボボックス等が操作されたとき
    '=========================================================================

    '配信スタート
    Private Sub ButtonStart_Click(sender As System.Object, e As System.EventArgs) Handles ButtonStart.Click
        'StreamMode 0=HLS再生 1=HLSファイル再生 2=HTTPストリーム再生　3=HTTPストリームファイル再生
        Dim response As String = ""

        Dim num As Integer = Val(ComboBoxNum.Text)

        '既存のVLCを停止する
        stop_stream(num)

        If ComboBoxVideo.Text.IndexOf("---") = 0 Or ComboBoxVideo.Text.ToString.Length = 0 Then
            'テレビ視聴
            Dim StremMode As Integer = 2
            Dim s() As String = ComboBoxServiceID.Text.Split(",")
            If s.Length = 3 Then
                response = WI_START_STREAM( _
                                    num.ToString, _
                                    ComboBoxBonDriver.Text.ToString, _
                                    Val(s(1)), _
                                    Val(TextBoxChSpace.Text), _
                                    ComboBoxResolution.Text, _
                                    Val(ComboBoxNHKMODE.Text), _
                                    StremMode, _
                                    "" _
                                    )
            Else
                log1write("サービスIDが不正です")
            End If
        Else
            'ファイル再生
            Dim d() As String = ComboBoxVideo.Text.ToString.Split(",")
            If d.Length = 2 Then
                d(1) = Trim(d(1)) 'サーバーに渡す文字列
                If d(1).Length > 0 Then
                    Dim StremMode As Integer = 3
                    response = WI_START_STREAM( _
                                            num.ToString, _
                                            "", _
                                            0, _
                                            0, _
                                            ComboBoxResolution.Text, _
                                            0, _
                                            StremMode, _
                                            d(1) _
                                            )
                End If
            Else
                log1write("ファイル指定が不正です")
            End If
        End If

        log1write("=============================================")
        log1write(response)

        '稼働中ナンバー
        show_LabelStream() '現在稼働中のプロセスを表示

        If response.IndexOf("開始されました<br>") > 0 Then
            '指定秒数配信成功していればVLC起動
            Dim success As Integer = Val(TextBoxSuccessSecond.Text.ToString) '秒数
            Dim success_count As Integer = 0
            Dim count As Integer = 30
            While count > 0
                Dim error_numbers As String = WI_GET_ERROR_STREAM()
                If error_numbers.IndexOf(":" & num.ToString & ":") < 0 Then
                    '成功している
                    log1write("成功")
                    success_count += 1
                    If success_count >= success Then
                        '規定秒数に達した
                        Exit While
                    End If
                Else
                    log1write("再起動中")
                    success_count = 0
                End If
                System.Threading.Thread.Sleep(1000)
                count -= 1
            End While

            If count > 0 Then
                log1write("配信が開始されました")
                'あらかじめVLCを起動しておく
                view_by_VLC(num)
            Else
                'いつまで経っても配信が開始されない
                log1write("いつまで経っても配信が開始されません")
            End If
        End If

        '稼働中ナンバー
        show_LabelStream() '現在稼働中のプロセスを表示
    End Sub

    '配信停止ボタン
    Private Sub ButtonStop_Click(sender As System.Object, e As System.EventArgs) Handles ButtonStop.Click
        Dim num As Integer = Val(ComboBoxNum.Text)
        stop_stream(num)
    End Sub

    'ストリームを停止する
    Public Sub stop_stream(ByVal num As Integer)
        'VLCを閉じる
        stop_vlc(num)
        'サーバーに停止信号を送る
        Dim response As String = WI_STOP_STREAM(num)
        log1write("=============================================")
        log1write(response)
        show_LabelStream() '現在稼働中のプロセスを表示
    End Sub

    'VLC停止
    Private Sub stop_vlc(ByVal num As Integer)
        Try
            Dim ps As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessById(player_proc(num))
            ps.Kill()
        Catch ex As Exception
        End Try
    End Sub

    'サーバーＩＰ変更
    Private Sub TextBoxServerIP_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxServerIP.TextChanged
        'サーバーhttp作成
        Dim url As String = TextBoxServerIP.Text.ToString
        If url.Length > 0 Then
            Dim sp As Integer
            '先頭にhttp://が無ければ追加する
            If url.IndexOf("://") < 0 Then
                url = "http://" & url
            End If
            '末尾に/が無ければ追加する
            sp = url.LastIndexOf("/")
            If sp < 0 Or (sp >= 0 And sp <> url.Length - 1) Then
                url &= "/"
            End If
        End If
        M_TVRV_URL = url 'WEBインターフェース用URL
    End Sub

    'usernameセット
    Private Sub TextBoxServerUsername_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxServerUsername.TextChanged
        M_username = TextBoxServerUsername.Text.ToString
    End Sub

    'passwordセット
    Private Sub TextBoxServerPassword_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxServerPassword.TextChanged
        M_password = TextBoxServerPassword.Text.ToString
    End Sub

    'VLC起動ボタン
    Private Sub ButtonRunVLC_Click(sender As System.Object, e As System.EventArgs) Handles ButtonRunVLC.Click
        view_by_VLC(Val(ComboBoxNum.Text.ToString))
        '稼働中ナンバー
        show_LabelStream() '現在稼働中のプロセスを表示
    End Sub

    'VLCで視聴
    Private Sub view_by_VLC(ByVal num As Integer)
        Dim vlc_path As String = TextBoxVLCPATH.Text.ToString
        Dim vlc_url As String = TextBoxVLCURL.Text.ToString

        'パスワードがあればVLC_URLに追加
        vlc_url = add_userpass2url(vlc_url, M_username, M_password)

        '★VLCを実行
        'ProcessStartInfoオブジェクトを作成する
        Dim udpPsi As New System.Diagnostics.ProcessStartInfo()
        '起動するファイルのパスを指定する
        udpPsi.FileName = vlc_path
        'コマンドライン引数を指定する
        udpPsi.Arguments = vlc_url
        'アプリケーションを起動する
        Dim udpProc As System.Diagnostics.Process = System.Diagnostics.Process.Start(udpPsi)
        'udpProc.PriorityClass = System.Diagnostics.ProcessPriorityClass.High

        '起動したプロセスIDを記録しておく
        player_proc(num) = udpProc.Id
    End Sub

    'パスワードをURLに追加
    Private Function add_userpass2url(ByVal vlc_url As String, ByVal username As String, ByVal password As String) As String
        Try
            If username.Length > 0 And password.Length > 0 Then
                Dim sp As Integer = vlc_url.IndexOf("://")
                If sp > 0 And username.Length > 0 And password.Length > 0 Then
                    vlc_url = vlc_url.Substring(0, sp) & "://" & username & ":" & password & "@" & vlc_url.Substring(sp + "://".Length)
                End If
            End If
        Catch ex As Exception
        End Try
        Return vlc_url
    End Function

    'BonDriver選択
    Private Sub ComboBoxBonDriver_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxBonDriver.SelectedIndexChanged
        search_ServiceID()
    End Sub

    'ComboBoxBonDriverの値にしたがってComboBoxServiceIDを変更
    Private Sub search_ServiceID()
        ComboBoxServiceID.Items.Clear()
        Dim html As String = S_BonDriver_Channel_str 'WI_GET_CHANNELS() 'BonDriverとチャンネル一覧を取得
        Dim BonName As String = ComboBoxBonDriver.Text.ToString
        Dim sp As Integer = html.IndexOf("[" & BonName & "]")
        If sp >= 0 Then
            Dim ep As Integer = html.IndexOf("[", sp + 1)
            If ep > 0 Then
                html = html.Substring(sp, ep - sp)
            Else
                html = html.Substring(sp)
            End If
            Dim line() As String = Split(html, vbCrLf)

            If line IsNot Nothing Then
                For i As Integer = 0 To line.Length - 1
                    If line(i).IndexOf(";") < 0 Then
                        Dim s() As String = line(i).Split(",")
                        If s.Length = 4 Then
                            ComboBoxServiceID.Items.Add(s(3) & " ," & s(1) & "," & s(2))
                        End If
                    End If
                Next
                Try
                    ComboBoxServiceID.SelectedIndex = 0
                Catch ex As Exception
                    ComboBoxServiceID.Text = ""
                End Try
            Else
                ComboBoxServiceID.Text = ""
            End If
        Else
            '該当するBonDriverがみつかりません
        End If
    End Sub

    'サービスID(放送局）選択
    Private Sub ComboBoxServiceID_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxServiceID.SelectedIndexChanged
        Dim s() As String = ComboBoxServiceID.Text.ToString.Split(",")
        If s.Length = 3 Then
            TextBoxChSpace.Text = s(2) 'ChSpaceセット
        End If
    End Sub

    'ファイル選択
    Private Sub ComboBoxVideo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxVideo.SelectedIndexChanged
        SendKeys.Send("{Tab}") '全選択を外す
        If ComboBoxVideo.Text.ToString.Length = 0 Then
            ComboBoxVideo.Text = ComboBoxVideo.Items(0)
        End If
        If ComboBoxVideo.Text = ComboBoxVideo.Items(0) Then
            ComboBoxBonDriver.Enabled = True
            ComboBoxServiceID.Enabled = True
            'ComboBoxNHKMODE.Enabled = True
            TextBoxChSpace.Enabled = True
        Else
            ComboBoxBonDriver.Enabled = False
            ComboBoxServiceID.Enabled = False
            'ComboBoxNHKMODE.Enabled = False
            TextBoxChSpace.Enabled = False
        End If
    End Sub

    '配信ナンバー選択
    Private Sub ComboBoxNum_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxNum.SelectedIndexChanged
        If Val(ComboBoxNum.Text.ToString) >= 30 Then
            ComboBoxNum.Text = 29
        End If

        If Val(ComboBoxNum.Text.ToString) >= 0 Then
            'VLC用ストリームURLを作成

            'サーバー
            Dim server As String = Trim(TextBoxServerIP.Text.ToString)
            '末尾が/なら取り除く
            Dim sp As Integer = server.LastIndexOf("/")
            If sp = server.Length - 1 Then
                server = server.Substring(0, server.Length - 1)
            End If
            'URL
            Dim protcol As String = "http"
            Dim d() As String = server.Split(":")
            If d.Length = 3 Then
                If d(1).IndexOf("//") < 0 Then
                    'エラー
                    MsgBox("サーバーIPが不正です[1]")
                    Exit Sub
                Else
                    server = d(1).Replace("//", "")
                    protcol = d(0)
                End If
            ElseIf d.Length = 2 Then
                server = d(0)
            Else
                'エラー
                MsgBox("サーバーIPが不正です[2]")
                Exit Sub
            End If
            'ポート
            Dim port As Integer = 0
            sp = S_server_status_str.IndexOf("HTTPSTREAM_VLC_port=")
            If sp >= 0 Then
                port = Val(S_server_status_str.Substring(sp + "HTTPSTREAM_VLC_port=".Length))
            Else
                port = 42465 'デフォルト
            End If
            port = port + Val(ComboBoxNum.Text.ToString) - 1
            '最後に合成
            Dim num2 As String = Val(ComboBoxNum.Text.ToString).ToString
            TextBoxVLCURL.Text = protcol & "://" & server & ":" & port.ToString & "/mystream" & num2 & ".ts"
        End If

    End Sub

    'ローカルVLC選択
    Private Sub ButtonVLCapp_Click(sender As System.Object, e As System.EventArgs) Handles ButtonVLCapp.Click
        Dim s As String = F_get_filename(TextBoxVLCPATH.Text.ToString)
        Try
            If s.Length > 0 Then
                TextBoxVLCPATH.Text = s
            End If
        Catch ex As Exception
        End Try
    End Sub

    'ファイル選択
    Private Function F_get_filename(ByVal s As String) As Object
        Dim r As Object = Nothing

        If s.LastIndexOf("\") > 0 Then
            s = s.Substring(0, s.LastIndexOf("\"))
        End If

        ' ダイアログボックスのタイトル
        OpenFileDialog1.Title = "コメントファイルを開く"
        ' 初期表示するディレクトリ
        OpenFileDialog1.InitialDirectory = s
        ' デフォルトの選択ファイル名
        OpenFileDialog1.FileName = ""
        ' [ファイルの種類]に表示するフィルタ
        OpenFileDialog1.Filter = _
            "実行ファイル (*.exe)|*.exe" '|すべてのファイル(*.*)|*.*"
        ' [ファイルの種類]の初期表示インデックス
        OpenFileDialog1.FilterIndex = 1
        ' ファイル名に拡張子を自動設定するかどうか
        OpenFileDialog1.AddExtension = True
        ' 複数のファイルを選択するかどうか
        OpenFileDialog1.Multiselect = False
        ' ファイルが存在しない時に警告メッセージを表示するかどうか
        OpenFileDialog1.CheckFileExists = True
        ' PATHが存在しない時に警告メッセージを表示するかどうか
        OpenFileDialog1.CheckPathExists = True
        ' [読み取り専用ファイルとして開く]チェックボックスを表示するかどうか
        OpenFileDialog1.ShowReadOnly = False
        ' [読み取り専用ファイルとして開く]チェックボックスのデフォルト値
        OpenFileDialog1.ReadOnlyChecked = False
        ' ダイアログを閉じる時に、カレントディレクトリを元に戻すかどうか
        OpenFileDialog1.RestoreDirectory = True
        ' [ヘルプ]ボタンを表示するかどうか
        OpenFileDialog1.ShowHelp = False
        ' ダイアログボックスを表示する
        Dim btn As DialogResult = OpenFileDialog1.ShowDialog()
        If btn = Windows.Forms.DialogResult.OK Then
            ' 選択した一つのファイルPATHを取得する
            'MessageBox.Show(OpenFileDialog1.FileName & "が選択されました")
            ' 選択した複数のファイルPATHを取得する
            'MessageBox.Show(OpenFileDialog1.FileNames(0) & "が選択されました")

            r = OpenFileDialog1.FileName

        ElseIf btn = Windows.Forms.DialogResult.Cancel Then
            'MessageBox.Show("キャンセルされました")
        End If

        Return r
    End Function

    'サーバーステータス表示
    Private Sub ButtonServerStatus_Click(sender As System.Object, e As System.EventArgs) Handles ButtonServerStatus.Click
        log1write("=============================================")
        log1write(WI_GET_TVRV_STATUS())
    End Sub

    'BonDriver＆チャンネル一覧
    Private Sub ButtonShowChannels_Click(sender As System.Object, e As System.EventArgs) Handles ButtonShowChannels.Click
        log1write("=============================================")
        log1write(WI_GET_CHANNELS())
        '結果
        'BonDriver名, ServiceID, ChSpace, 放送局名
    End Sub

    '配信中ストリームの状態
    Private Sub ButtonShowStreams_Click(sender As System.Object, e As System.EventArgs) Handles ButtonShowStreams.Click
        log1write("=============================================")
        log1write(WI_GET_LIVE_STREAM())
        '結果
        '内部_List番号, 配信ナンバー, RecTaskUDPポート, BonDriver名, ServiceID, ChSpace, Stream_mode, NHKMODE, 停止中=1, 放送局名, HlsAppファイル名
    End Sub

    '解像度一覧
    Private Sub ButtonShowResolution_Click(sender As System.Object, e As System.EventArgs) Handles ButtonShowResolution.Click
        log1write("=============================================")
        log1write(WI_GET_RESOLUTION())
    End Sub

    Private Sub ButtonProgram_D_Click(sender As System.Object, e As System.EventArgs) Handles ButtonProgram_D.Click
        log1write("=============================================")
        log1write(WI_GET_PROGRAM_D())
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        log1write("=============================================")
        log1write(WI_GET_PROGRAM_TVROCK())
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        log1write("=============================================")
        log1write(WI_GET_PROGRAM_EDCB())
    End Sub

    Private Sub ButtonVideoFiles_Click(sender As System.Object, e As System.EventArgs) Handles ButtonVideoFiles.Click
        log1write("=============================================")
        log1write(WI_GET_VIDEOFILES())
    End Sub

    '指定numberのmystream%NUM%*.tsの数
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        log1write("=============================================")
        log1write(WI_GET_TSFILE_COUNT(Val(ComboBoxNum.Text)))
        'VLC HTTPストリームの場合はファイルが作成されないので常に0
    End Sub

    '再起動中ストリーム
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        log1write("=============================================")
        log1write(WI_GET_ERROR_STREAM())
    End Sub

End Class
