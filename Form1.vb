Public Class Form1
    '番組表表示
    Public Sub show_TvProgram(ByVal pn As Integer)
        '0=地デジ 998=EDCB 999=TvRock
        Dim i As Integer

        Dim s As String = ""
        Select Case pn
            Case 0
                s = WI_GET_PROGRAM_D()
            Case 998
                s = WI_GET_PROGRAM_EDCB()
            Case 999
                s = WI_GET_PROGRAM_TVROCK()
        End Select

        Dim line() As String = Split(s, vbCrLf)

        DataGridView1.Rows.Clear()
        Dim cnt As Integer = 0
        For i = 0 To line.Length - 1
            Dim d() As String = line(i).Split(",")
            If d.Length = 8 Then
                DataGridView1.Rows.Add(1)
                DataGridView1.Rows(cnt).Cells(0).Value = d(0) & "　　　　　　　" & d(4) & " ～ " & d(5) & vbCrLf & d(6) & vbCrLf & "　" & d(7)
                DataGridView1.Rows(cnt).Cells(1).Value = d(2) & "," & d(3) 'サービスID,ChSpace
                cnt += 1
            End If
        Next

        Select Case pn
            Case 0
                log1write("地デジ番組表を更新しました")
            Case 998
                log1write("EDCB番組表を更新しました")
            Case 999
                log1write("TvRock番組表を更新しました")
        End Select

        DataGridView1.BringToFront()
    End Sub

    'DataGridView1の手動描画
    Private Sub DataGridView1_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 AndAlso _
            (e.PaintParts And DataGridViewPaintParts.Background) = _
                DataGridViewPaintParts.Background Then

            '選択されているか調べ、色を決定する
            'bColor1が開始色、bColor2が終了色
            Dim bColor1, bColor2 As Color
            If (e.PaintParts And DataGridViewPaintParts.SelectionBackground) = _
                    DataGridViewPaintParts.SelectionBackground AndAlso _
                (e.State And DataGridViewElementStates.Selected) = _
                    DataGridViewElementStates.Selected Then
                bColor1 = Color.LemonChiffon 'e.CellStyle.SelectionBackColor
                bColor2 = Color.White 'Color.Black
            Else
                If e.RowIndex Mod 2 = 1 Then
                    bColor1 = Color.FromArgb(&HF0, &HF0, &HF0) 'e.CellStyle.BackColor
                    bColor2 = Color.FromArgb(&HFF, &HFF, &HFF)
                Else
                    bColor1 = Color.FromArgb(&HFF, &HFF, &HFF) 'e.CellStyle.BackColor
                    bColor2 = Color.FromArgb(&HFF, &HFF, &HFF)
                End If
            End If

            'グラデーションブラシを作成
            Dim b As New System.Drawing.Drawing2D.LinearGradientBrush( _
                e.CellBounds, bColor1, bColor2, _
                System.Drawing.Drawing2D.LinearGradientMode.Horizontal)
            Try
                'セルを塗りつぶす
                e.Graphics.FillRectangle(b, e.CellBounds)
            Finally
                b.Dispose()
            End Try

            '背景以外が描画されるようにする
            'Dim paintParts As DataGridViewPaintParts = e.PaintParts And Not DataGridViewPaintParts.Background
            'セルを描画する
            'e.Paint(e.ClipBounds, paintParts)
        End If

        Try
            Dim s As String = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            Dim sp1 As Integer
            Dim sp2 As Integer

            sp1 = s.IndexOf(vbCrLf) '1つめの改行
            sp2 = s.IndexOf(vbCrLf, sp1 + 2) '2つめの改行

            Dim g = e.Graphics
            Dim sf As New StringFormat()
            sf.SetMeasurableCharacterRanges({New CharacterRange(0, sp1 + 2),
                                             New CharacterRange(sp1 + 2, sp2 - sp1),
                                             New CharacterRange(sp2 + 2, s.Length - sp2 - 2)})

            'e.CellStyle.Font
            Dim Font1 As Font = New Font("MS UI Gothic", 10)
            Dim Font2 As Font = New Font("MS UI Gothic", 10, FontStyle.Bold)
            Dim Font3 As Font = New Font("MS UI Gothic", 9)
            Dim Font_dummy As Font = New Font("MS UI Gothic", 12)

            'Dim rgs = g.MeasureCharacterRanges(s, e.CellStyle.Font, e.CellBounds, sf)
            Dim rgs = g.MeasureCharacterRanges(s, Font_dummy, e.CellBounds, sf)

            g.DrawString(s.Substring(0, sp1 + 2), Font1, Brushes.Black, rgs(0).GetBounds(g).Location)
            g.DrawString(s.Substring(sp1 + 2, sp2 - sp1), Font2, Brushes.Black, rgs(1).GetBounds(g).Location)
            g.DrawString(s.Substring(sp2 + 2, s.Length - sp2 - 2), Font3, Brushes.Gray, rgs(2).GetBounds(g).Location)
            e.Handled = True

        Catch ex As Exception
        End Try

        '描画が完了したことを知らせる
        e.Handled = True

    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '二重起動をチェックする
        If Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName).Length > 1 Then
            'すでに起動していると判断する
            Close()
        End If

        'DataGridView1
        DataGridView1.RowTemplate.Height = 70
    End Sub

    Private Sub Form1_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        log1write(version)

        '全てのvlc停止
        stopProcName("vlc")

        '初期設定読み込み
        read_ini()

        'フォーム項目を復元
        F_window_set()

        'サーバーの状態
        S_server_status_str = WI_GET_TVRV_STATUS() 'サーバーの状態

        If S_server_status_str.IndexOf("接続できません") > 0 Or S_server_status_str.IndexOf("形式を決定できませんでした") > 0 Then
            '失敗
            TabControl1.SelectedIndex = 5
            TextBoxServerIP.Focus()
            log1write("【警告】サーバーと接続できません。サーバーの起動を確認し、サーバーIPを設定して再起動してください")
            MsgBox("サーバーと接続できません。サーバーの起動を確認し、サーバーIPを設定して再起動してください")
        ElseIf S_server_status_str.IndexOf("許可されていません") > 0 Then
            '失敗
            TabControl1.SelectedIndex = 5
            TextBoxServerUsername.Focus()
            log1write("【警告】サーバーから認証を求められました。IDとPASSWORDを設定して再起動してください")
            MsgBox("サーバーから認証を求められました。IDとPASSWORDを設定して再起動してください")
        ElseIf S_server_status_str.Length < 100 Then
            TabControl1.SelectedIndex = 5
            TextBoxServerIP.Focus()
            log1write(S_server_status_str)
            log1write("【警告】サーバーとの通信に失敗しました。サーバーの状態を確認して再起動してください")
            MsgBox("サーバーとの通信に失敗しました。サーバーの状態を確認して再起動してください")
        Else
            Dim sp As Integer = S_server_status_str.IndexOf("HTTPSTREAM_App=")
            If sp >= 0 Then
                S_HTTPSTREAM_App = Val(S_server_status_str.Substring(sp + "HTTPSTREAM_App=".Length))
                'If HTTPSTREAM_App <> 1 Then
                'MsgBox("サーバー TvRemoteViewer_VB.ini内のHTTPSTREAM_Appを1に設定してくだい。")
                'Close()
                'End If
            End If
            Dim BS1_hlsApp As String = Instr_pickup(S_server_status_str, "BS1_hlsApp=", vbCrLf, 0)
            If S_HTTPSTREAM_App = 1 And BS1_hlsApp.IndexOf("vlc.exe") < 0 Then
                log1write("【警告】サーバー TvRemoteViewer_VB.ini内のBS1_hlsAppにvlc.exeへのパスを設定してくだい。")
            End If
            If S_HTTPSTREAM_App = 0 Then
                log1write("【警告】サーバー TvRemoteViewer_VB.ini内のHTTPSTREAM_Appを1か2に設定してくだい。")
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
            make_vlcURL() 'ローカルVLCに渡すURLをセット
            'NHKMODE
            If ComboBoxNHKMODE.Text.ToString.Length = 0 Then
                ComboBoxNHKMODE.SelectedIndex = 0
            End If

            If file_exist(TextBoxVLCPATH.Text.ToString) = 0 Then
                log1write("プレーヤーの指定が不正です")
                MsgBox("プレーヤーの指定が不正です")
                TabControl1.SelectedIndex = 5
                TextBoxVLCPATH.Focus()
            End If
        End If

        '無事に起動した
        TvRemoteViewer_VB_client_start = 1

        Select Case TabControl1.SelectedIndex
            Case 0
                show_TvProgram(0)
            Case 1
                show_TvProgram(998)
            Case 2
                show_TvProgram(999)
        End Select

        'VLCならば1パス視聴開始は無効にする
        If S_HTTPSTREAM_App = 1 And direct_WatchTV = 1 Then
            direct_WatchTV = 0
            log1write("【2パス再生】サーバーのHTTP配信アプリがVLCなので1パス再生は出来ません。2パス再生に変更しました")
        End If

        Timer1.Enabled = True
    End Sub

    Private Sub Form1_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'VLCを消してストリームも停止する
        For i = 0 To 29
            If player(i).proc > 0 Then
                Try
                    stop_stream(i)
                Catch ex As Exception
                End Try
            End If
        Next

        '全てのvlc停止
        stopProcName("vlc")

        'フォーム項目を保存
        If TvRemoteViewer_VB_client_start = 1 Then
            save_form_status()
        End If
    End Sub

    'ファイル再生用パスを読み込む
    Public Sub read_ini()
        Dim errstr As String = ""
        Dim line() As String = Nothing

        'カレントディレクトリ変更
        F_set_ppath4program()

        line = file2line("TvRemoteViewer_VB_client.ini")
        log1write("設定ファイルとして TvRemoteViewer_VB_client.ini を読み込みました")

        Dim i, j As Integer

        If line Is Nothing Then
        ElseIf line.Length > 0 Then
            '読み込み完了
            For i = 0 To line.Length - 1
                line(i) = trim8(line(i))
                'コメント削除
                If line(i).IndexOf(";") >= 0 Then
                    line(i) = line(i).Substring(0, line(i).IndexOf(";"))
                End If
                If line(i).IndexOf("#") >= 0 Then
                    line(i) = line(i).Substring(0, line(i).IndexOf("#"))
                End If
                Dim youso() As String = line(i).Split("=")
                Try
                    If youso Is Nothing Then
                    ElseIf youso.Length > 1 Then
                        For j = 0 To youso.Length - 1
                            youso(j) = trim8(youso(j))
                        Next
                        Select Case youso(0)
                            Case "TvProgramD_BonDriver1st"
                                TvProgramD_BonDriver1st = trim8(youso(1).ToString)
                            Case "TvProgramS_BonDriver1st"
                                TvProgramS_BonDriver1st = trim8(youso(1).ToString)
                        End Select
                    End If
                Catch ex As Exception
                    log1write("パラメーター " & youso(0) & " の読み込みに失敗しました。" & ex.Message)
                End Try
            Next
        Else
            log1write("設定ファイル TvRemoteViewer_VB_client.ini の読み込みに失敗しました")
        End If

    End Sub

    '=========================================================================
    'タイマー
    '=========================================================================

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Dim i As Integer = 0
        'Dim result1 As String = ""
        Dim result2 As String = ""

        'VLCのcrashダイアログが出ていたら消す
        check_crash_dialog()

        If time1_ng = 0 Then
            time1_ng = 1

            'VLCが消されたら停止する
            For i = 0 To 29
                If player(i).proc > 0 And player(i).Seeking = 0 Then
                    'result1 = Trim(VLC_remote("is_playing", VLC_rc_port + i - 1))
                    ''status change: ( new input: ttp://127.0.0.1:40003/WatchTV1.ts )～と返ってくることがある
                    'If result1.Length > 0 Then
                    'result1 = Val(result1.Substring(result1.Length - 1, 1)) '0か1のみ取り出す
                    'If result1 = "1" Then
                    'If player(i).start_utime = 0 Then
                    'player(i).start_utime = time2unix(Now())
                    'log1write("player_start(" & i & ")=" & Now())
                    'End If
                    'End If
                    'Else
                    'result1 = "0"
                    'End If

                    'VLCにHTTPコマンドで問い合わせてis_playing=0なら停止
                    result2 = Trim(VLC_remote("info", VLC_rc_port + i - 1))
                    If result2.Length > 100 Then
                        If player(i).start_utime = 0 Then
                            player(i).start_utime = time2unix(Now())
                            log1write("player_start(" & i & ")=" & Now())
                        End If
                    End If
                    'If player(i).start_utime > 0 And (result2.IndexOf("no input") >= 0 Or result2.Length < 20 Or Val(result1) = 0) Then
                    If player(i).start_utime > 0 And (result2.IndexOf("no input") >= 0 Or result2.Length < 15) Then
                        'If result2.IndexOf("no input") >= 0 Or result2.Length < 20 Then
                        '再生されていない
                        log1write("VLCが閉じられたのでストリームを停止します")
                        'ローカルVCLを停止する
                        stop_vlc(i)
                        'サーバーに停止命令を送る
                        stop_stream(i)
                        log1write("VLCが閉じられたのでストリームを停止しました[1]")
                    ElseIf player(i).start_utime > 0 And time2unix(Now()) - player(i).start_utime > 7 Then
                        If Second(Now()) Mod 5 = 0 Then
                            '5秒に一度チェック
                            Dim result3 As String = Trim(VLC_remote("stats", VLC_rc_port + i - 1))
                            If result3.Length > 0 Then
                                result3 = Trim(Instr_pickup(result3, ":", "KiB", 0))
                            End If
                            If result3 = "0" Then
                                'vlcは起動しているがプレーヤーが反応しない場合
                                '再生されていない
                                log1write("プレーヤー再生に失敗しています")
                                'ローカルVCLを停止する
                                stop_vlc(i)
                                'サーバーに停止命令を送る
                                stop_stream(i)
                                log1write("プレーヤー再生に失敗したのでストリームを停止しました")
                            End If
                        End If
                    End If

                    '旧方式rcを使用するようにしたら使えない
                    'VLCプロセスをチェック
                    'Try
                    'Dim ps As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessById(player_proc(i))
                    'If ps.HasExited = True Then
                    'player_proc(i) = 0
                    'log1write("VLCが閉じられたのでストリームを停止します")
                    'stop_stream(i)
                    'log1write("VLCが閉じられたのでストリームを停止しました[1]")
                    'End If
                    'Catch ex As Exception
                    'player_proc(i) = 0
                    'log1write("VLCが閉じられたのでストリームを停止します")
                    'stop_stream(i)
                    'log1write("VLCが閉じられたのでストリームを停止しました[2] " & ex.Message)
                    'End Try
                End If
            Next
            time1_ng = 0
        End If

        '一時表示していたtextboxlogを消す
        textboxlog_temp_do()

        '10秒に一度配信状況を表示
        'If (Second(Now()) Mod 10) = 5 Then '10秒毎に
        'show_LabelStream() '現在稼働中のプロセスを表示
        'End If

        '番組表を表示中ならば1分毎に更新
        If TabControl1.SelectedIndex <= 2 Then
            If Second(Now()) = 2 Then 'X分02秒ならば
                Try
                    '選択されているセルを記憶
                    Dim slctd As Integer = -1
                    For Each c As DataGridViewCell In DataGridView1.SelectedCells
                        slctd = c.RowIndex
                        Exit For
                    Next c
                    'スクロールバーの位置を記憶
                    Dim scrb As Integer = DataGridView1.FirstDisplayedScrollingRowIndex
                    Select Case TabControl1.SelectedIndex
                        Case 0
                            show_TvProgram(0)
                        Case 1
                            show_TvProgram(998)
                        Case 2
                            show_TvProgram(999)
                    End Select
                    If slctd > 0 Then
                        '選択解除して戻す
                        DataGridView1.ClearSelection()
                        DataGridView1(0, slctd).Selected = True
                    End If
                    'スクロールバーの位置を戻す
                    DataGridView1.FirstDisplayedScrollingRowIndex = scrb
                Catch ex As Exception
                    '更新した結果　番組表がなくなった
                    log1write("番組表更新に失敗しました")
                End Try
            End If
        End If

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

    Public Sub textboxlog_temp_do()
        '一時表示していたtextboxlogを消す
        If textboxlog_temp > 0 Then
            textboxlog_temp -= 1
            If textboxlog_temp = 0 Then
                '終了秒数になった
                TextBoxLog.Width = textboxlog_temp_width
                TextBoxLog.Left = textboxlog_temp_left
                If TabControl1.SelectedIndex <= 2 Then
                    DataGridView1.BringToFront()
                Else
                    TextBoxLog.BringToFront()
                End If
            Else
                If textboxlog_temp_stratstop = 0 Then
                    '起動中なら状況を表示
                    Dim error_numbers As String = WI_GET_ERROR_STREAM()
                    If error_numbers.IndexOf(":" & ComboBoxNum.Text.ToString & ":") < 0 Then
                        '成功している
                        log1write("成功")
                    Else
                        log1write("再起動中")
                    End If
                End If
            End If
        End If
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
        ComboBoxBonDriver.Items.Add("---")

        Dim sp As Integer = html.ToLower.IndexOf("[bondriver")
        While sp >= 0
            Dim b As String = Instr_pickup(html, "[", "]", sp)
            If b.ToLower.IndexOf("bondriver") >= 0 Then
                ComboBoxBonDriver.Items.Add(b)
            End If
            sp = html.ToLower.IndexOf("[bondriver", sp + 1)
        End While
        If ComboBoxBonDriver.Text.Length = 0 Then
            Try
                ComboBoxBonDriver.SelectedIndex = 0
            Catch ex As Exception
            End Try
        End If
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
                    lr(1) = Trim(lr(1))
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
                        Case "ComboBoxServiceID"
                            ComboBoxServiceID.Text = lr(1)
                        Case "TextBoxVLCPATH"
                            TextBoxVLCPATH.Text = lr(1)
                        Case "TextBoxVLCURL"
                            TextBoxVLCURL.Text = lr(1)
                        Case "TextBoxSuccessSecond"
                            TextBoxSuccessSecond.Text = lr(1)
                        Case "TabControl1_SelectedIndex"
                            TabControl1.SelectedIndex = Val(lr(1))
                        Case "TextBoxFirstSeek"
                            TextBoxFirstSeek.Text = lr(1)
                        Case "TextBoxSeek"
                            TextBoxSeek.Text = lr(1)
                        Case "window_location"
                            'ウィンドウの位置復元
                            Dim h As IntPtr
                            Dim w() As String = trim8(lr(1)).Split(",")
                            If w.Length = 4 Then
                                h = FindWindow(vbNullString, "TvRemoteViewer_VB_Client")
                                If h <> 0 Then
                                    Try
                                        MoveWindow(h, trim8(w(0)), trim8(w(1)), trim8(w(2)), trim8(w(3)), 1)
                                    Catch ex As Exception
                                    End Try
                                End If
                            End If
                        Case "NoHardSub"
                            NoHardSub = Val(lr(1))
                            If NoHardSub = 1 Then
                                CheckBoxHardSub.Checked = False
                            Else
                                CheckBoxHardSub.Checked = True
                            End If
                    End Select
                End If
            Next
        End If
    End Sub

    'フォーム上の項目を保存
    Private Sub save_form_status()
        Dim s As String = ""

        'ウィンドウの位置、大きさを記録
        Dim h As IntPtr
        Dim w As RECT
        h = FindWindow(vbNullString, "TvRemoteViewer_VB_Client")
        If h <> 0 Then
            If GetWindowRect(h, w) = 1 Then
                's = "window_location = " & w.Left & "," & w.Top & "," & (w.Right - w.Left + 1) & "," & (w.Bottom - w.Top + 1) & vbCrLf
                '↑のままだと幅と高さが１ずつ増えてしまう
                s = "window_location = " & w.Left & "," & w.Top & "," & (w.Right - w.Left) & "," & (w.Bottom - w.Top) & vbCrLf
            End If
        End If

        'フォーム　コントロール
        s &= "TextBoxServerIP=" & TextBoxServerIP.Text & vbCrLf
        s &= "TextBoxServerUsername=" & TextBoxServerUsername.Text & vbCrLf
        s &= "TextBoxServerPassword=" & TextBoxServerPassword.Text & vbCrLf
        s &= "ComboBoxResolution=" & ComboBoxResolution.Text & vbCrLf
        s &= "ComboBoxNHKMODE=" & ComboBoxNHKMODE.Text & vbCrLf
        s &= "ComboBoxNum=" & ComboBoxNum.Text & vbCrLf
        s &= "ComboBoxBonDriver=" & ComboBoxBonDriver.Text & vbCrLf
        s &= "TextBoxChSpace=" & TextBoxChSpace.Text & vbCrLf
        s &= "ComboBoxServiceID=" & ComboBoxServiceID.Text & vbCrLf
        s &= "TextBoxVLCPATH=" & TextBoxVLCPATH.Text & vbCrLf
        s &= "TextBoxVLCURL=" & TextBoxVLCURL.Text & vbCrLf
        s &= "TextBoxSuccessSecond=" & TextBoxSuccessSecond.Text & vbCrLf
        s &= "TabControl1_SelectedIndex=" & TabControl1.SelectedIndex & vbCrLf
        s &= "TextBoxSeek=" & TextBoxSeek.Text.ToString & vbCrLf
        s &= "TextBoxFirstSeek=" & TextBoxFirstSeek.Text.ToString & vbCrLf
        s &= "NoHardSub=" & NoHardSub & vbCrLf

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

            ComboBoxVideo.Items.Add(name & Space(120) & ":" & value)

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
        If ComboBoxResolution.Text.Length = 0 Then
            Try
                ComboBoxResolution.SelectedIndex = 0
            Catch ex As Exception
            End Try
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
        If ComboBoxNum.Text.Length = 0 Then
            Try
                ComboBoxNum.SelectedIndex = 0
            Catch ex As Exception
            End Try
        End If
    End Sub

    '配信中を更新
    Public Sub show_LabelStream()
        Dim r As String = ""
        Dim chk As Integer = 0
        Dim response As String = WI_GET_LIVE_STREAM()
        Dim d() As String = Split(response, vbCrLf)
        Dim i As Integer = 0
        If d IsNot Nothing Then
            For i = 0 To d.Length - 1
                Dim youso() As String = d(i).Split(",")
                Try
                    If youso.Length > 3 Then
                        r &= youso(1) & " "
                        chk += 1
                    End If
                Catch ex As Exception
                End Try
            Next
        End If
        If chk = 0 Then
            r = "待機中"
        Else
            r = "配信中：" & r
        End If
        LabelStream.Text = r
    End Sub

    '=========================================================================
    'フォーム上のボタン、テキスト、コンボボックス等が操作されたとき
    '=========================================================================

    '手動配信スタート
    Private Sub ButtonStart_Click(sender As System.Object, e As System.EventArgs) Handles ButtonStart.Click
        Start_Stream(0, "", 0, 0, "", 0)
    End Sub

    'ファイル配信スタート
    Private Sub ButtonStart_file_Click(sender As System.Object, e As System.EventArgs) Handles ButtonStart_file.Click
        Dim SeekSeconds As Integer = Val(TextBoxFirstSeek.Text.ToString)
        Dim fullpathfilename As String = ComboBoxVideo.Text.ToString
        Dim d() As String = fullpathfilename.Split(",")
        If d.Length = 2 Then
            fullpathfilename = d(1)
        End If
        If fullpathfilename.IndexOf(".") > 0 Then
            Start_Stream(1, "", 0, 0, fullpathfilename, SeekSeconds)
        End If
    End Sub

    Private Sub Start_Stream(ByVal HandFile As Integer, ByVal bondriver As String, ByVal sid As Integer, ByVal chspace As Integer, ByVal fullpathfilename As String, ByVal SeekSeconds As Integer)
        'SeekSeconds=ファイル再生時の開始秒数
        'StreamMode 0=HLS再生 1=HLSファイル再生 2=HTTPストリーム再生　3=HTTPストリームファイル再生
        Dim response As String = ""

        Dim num As Integer = Val(ComboBoxNum.Text)

        '既存のVLCを停止する
        stop_vlc(num)

        If HandFile = 0 Then
            'テレビ視聴
            If ComboBoxBonDriver.Text.IndexOf("---") < 0 Then
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
                                        "", _
                                        0 _
                                        )
                Else
                    log1write("サービスIDが不正です")
                    Exit Sub
                End If
            Else
                log1write("BonDriverが指定されていません")
                Exit Sub
            End If
        ElseIf HandFile = 1 Then
            'ファイル再生
            fullpathfilename = trim8(fullpathfilename) 'サーバーに渡す文字列
            If fullpathfilename.Length > 0 Then
                Dim StremMode As Integer = 3
                response = WI_START_STREAM( _
                                        num.ToString, _
                                        "", _
                                        0, _
                                        0, _
                                        ComboBoxResolution.Text, _
                                        0, _
                                        StremMode, _
                                        fullpathfilename, _
                                        SeekSeconds _
                                        )
            End If
        ElseIf HandFile = 2 Then
            '番組表から
            Dim StremMode As Integer = 2
            response = WI_START_STREAM( _
                                    num.ToString, _
                                    bondriver, _
                                    sid, _
                                    chspace, _
                                    ComboBoxResolution.Text, _
                                    Val(ComboBoxNHKMODE.Text), _
                                    StremMode, _
                                    "", _
                                    0 _
                                    )
        End If

        log1write("=============================================")
        log1write(response)

        '稼働中ナンバー
        show_LabelStream() '現在稼働中のプロセスを表示

        If direct_WatchTV = 0 Then
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
                    'あらかじめVLCを起動しておく
                    view_by_VLC(num, fullpathfilename, SeekSeconds)

                    If SeekSeconds = 0 Then
                        log1write("配信が開始されました")
                    Else
                        log1write("動画冒頭から" & SeekSeconds & "秒の地点から配信が開始されました")
                    End If
                Else
                    'いつまで経っても配信が開始されない
                    log1write("いつまで経っても配信が開始されません")
                End If
            Else
                log1write("【エラー】配信開始が確認できませんでした")
            End If
        ElseIf direct_WatchTV = 1 And response.Length > 0 Then
            If response.Length > 0 Then
                log1write("VLCによるダイレクト視聴を開始しました")
                view_by_VLC(num, fullpathfilename, 0, response)
            Else
                log1write("【エラー】VLCへのパラメーターが指定されていません")
            End If
        End If

        '稼働中ナンバー
        show_LabelStream() '現在稼働中のプロセスを表示

    End Sub

    '手動配信停止ボタン
    Private Sub ButtonStop_Click(sender As System.Object, e As System.EventArgs) Handles ButtonStop.Click
        Dim num As Integer = Val(ComboBoxNum.Text)
        stop_stream(num)
    End Sub

    'ファイル配信停止ボタン
    Private Sub ButtonStop_file_Click(sender As System.Object, e As System.EventArgs) Handles ButtonStop_file.Click
        Dim num As Integer = Val(ComboBoxNum.Text)
        stop_stream(num)
    End Sub

    'ストリームを停止する
    Public Sub stop_stream(ByVal num As Integer)
        If TabControl1.SelectedIndex <= 2 Then
            If textboxlog_temp = 0 Then
                textboxlog_temp_left = TextBoxLog.Left
                textboxlog_temp_width = TextBoxLog.Width
                TextBoxLog.Left = Int(TextBoxLog.Width / 2)
                TextBoxLog.Width = Int(TextBoxLog.Width / 2) - 6
            End If
            TextBoxLog.BringToFront()
            textboxlog_temp = textboxlog_temp_howlong 'ログ表示秒数
            textboxlog_temp_stratstop = 1
            TextBoxLog.Refresh()
        End If

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
        Dim i As Integer = 0
        Dim result As String = ""
        If player(num).proc > 0 Then
            Try
                While result.IndexOf("returned 0") < 0 And i < 10
                    result = VLC_remote("quit", VLC_rc_port + num - 1)
                    '↓正常終了の場合resultは下のように返ってくる
                    'quit: returned 0 (no error)
                    System.Threading.Thread.Sleep(300)
                    i += 1
                End While
                If i = 10 Then
                    '失敗

                End If
            Catch ex As Exception
                log1write("VLCの終了に失敗しました")
            End Try
            player(num).proc = 0
            player(num).start_utime = 0
        End If

        '旧方式
        'Try
        'Dim ps As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessById(player_proc(num))
        'ps.CloseMainWindow()
        'Catch ex As Exception
        'End Try
    End Sub

    'プロセスを名前指定で停止
    Public Sub stopProcName(ByVal name As String)
        Dim p As New System.Diagnostics.Process
        Dim inst As Process
        Dim myProcess() As Process
        myProcess = System.Diagnostics.Process.GetProcessesByName(name)
        For Each inst In myProcess
            Try
                p = System.Diagnostics.Process.GetProcessById(inst.Id)
                p.Kill()
            Catch ex As Exception
                log1write(name & "の名前指定によるプロセス終了に失敗しました")
            End Try
        Next
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
        view_by_VLC(Val(ComboBoxNum.Text.ToString), "", 0)
        '稼働中ナンバー
        show_LabelStream() '現在稼働中のプロセスを表示
    End Sub

    'VLCで視聴
    Private Sub view_by_VLC(ByVal num As Integer, ByVal fullpathfilename As String, ByVal SeekSeconds As Integer, Optional ByVal para_str As String = "")
        Dim vlc_path As String = TextBoxVLCPATH.Text.ToString
        Dim vlc_url As String = TextBoxVLCURL.Text.ToString() 'フォーム上の設定タブにVLCでアクセスすべきURLが作成されている・・なんだかなぁ

        'パスワードがあればVLC_URLに追加
        vlc_url = add_userpass2url(vlc_url, M_username, M_password)
        If para_str.Length > 0 Then
            If vlc_url.IndexOf("?") < 0 Then
                vlc_url &= "?" & para_str
            Else
                vlc_url &= "&" & para_str
            End If
        End If

        Dim rc_port As Integer = VLC_rc_port + num - 1 'VLC listen port

        '★VLCを実行
        'ProcessStartInfoオブジェクトを作成する
        Dim udpPsi As New System.Diagnostics.ProcessStartInfo()
        '起動するファイルのパスを指定する
        udpPsi.FileName = vlc_path
        'コマンドライン引数を指定する
        'udpPsi.Arguments = vlc_url
        'udpPsi.Arguments = "-I rc " & vlc_url & " --intf=""rc"" --rc-quiet --rc-host=localhost:8080 vlc://quit"
        'udpPsi.Arguments = "-I rc " & vlc_url & " --intf=""rc"" --rc-host=localhost:" & rc_port & " vlc://quit"
        'udpPsi.Arguments = "-I dummy " & vlc_url & " --intf=""rc"" --rc-host=localhost:" & rc_port & " vlc://quit"
        'udpPsi.Arguments = "-I dummy " & vlc_url & " --intf=""rc"" --rc-quiet --rc-host=localhost:" & rc_port & " vlc://quit"
        'udpPsi.Arguments = "-I dummy " & vlc_url & " --extraintf=""rc"" --rc-quiet --rc-host=127.0.0.1:" & rc_port & " vlc://quit"
        udpPsi.Arguments = "-I dummy --dummy-quiet " & vlc_url & " --extraintf=""rc"" --rc-quiet --rc-host=127.0.0.1:" & rc_port & " vlc://quit"
        'udpPsi.Arguments = "-I dummy " & vlc_url & " --extraintf=""rc"" --rc-quiet --rc-host=127.0.0.1:" & rc_port & " vlc://quit"
        'アプリケーションを起動する
        Dim udpProc As System.Diagnostics.Process = System.Diagnostics.Process.Start(udpPsi)
        'udpProc.PriorityClass = System.Diagnostics.ProcessPriorityClass.High

        '起動したプロセスIDを記録しておく
        player(num).start_utime = 0 '後でタイマーでプレーヤーの再生が確認されたときに値が入る
        player(num).proc = udpProc.Id
        player(num).fullpathfilename = fullpathfilename
        player(num).last_SeekSeconds = SeekSeconds
        player(num).Seeking = 0
        player(num).stop1_utime = 0

        'log1write("==============================================")
        'log1write("start_utime=" & unix2time(player(num).start_utime))
        'log1write("fullpathfilename=" & player(num).fullpathfilename)
        'log1write("last_SeekSeconds=" & player(num).last_SeekSeconds)
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
        'If ComboBoxVideo.Text = ComboBoxVideo.Items(0) Then
        'ComboBoxBonDriver.Enabled = True
        'ComboBoxServiceID.Enabled = True
        ''ComboBoxNHKMODE.Enabled = True
        'TextBoxChSpace.Enabled = True
        'Else
        'ComboBoxBonDriver.Enabled = False
        'ComboBoxServiceID.Enabled = False
        ''ComboBoxNHKMODE.Enabled = False
        'TextBoxChSpace.Enabled = False
        'End If
    End Sub

    '配信ナンバー選択
    Private Sub ComboBoxNum_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxNum.SelectedIndexChanged
        make_vlcURL()
    End Sub

    'ローカル再生用　VLCに渡すURLをTextBoxVLCURLにセット
    Private Sub make_vlcURL()
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
                Try
                    server = server.Substring(0, server.Length - 1)
                Catch ex As Exception
                    server = ""
                End Try
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
            Select Case S_HTTPSTREAM_App
                Case 1
                    'VLC配信
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
                Case 2
                    'ffmpeg配信
                    'VLC配信
                    sp = S_server_status_str.IndexOf("_wwwport=")
                    If sp >= 0 Then
                        port = Val(S_server_status_str.Substring(sp + "_wwwport=".Length))
                    Else
                        port = 40003 'デフォルト
                    End If
                    '最後に合成
                    Dim num2 As String = Val(ComboBoxNum.Text.ToString).ToString
                    TextBoxVLCURL.Text = protcol & "://" & server & ":" & port.ToString & "/WatchTV" & num2 & ".ts"
            End Select
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

    '配信中放送局
    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        log1write("=============================================")
        log1write(WI_GET_PROGRAM_NUM())
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

    'タブ 番組表　地デジ
    Private Sub TabPage1_Enter(sender As System.Object, e As System.EventArgs) Handles TabPage1.Enter
        If TvRemoteViewer_VB_client_start = 1 Then
            show_TvProgram(0)
        End If
    End Sub

    'タブ 番組表　EDCB
    Private Sub TabPage2_Enter(sender As System.Object, e As System.EventArgs) Handles TabPage2.Enter
        If TvRemoteViewer_VB_client_start = 1 Then
            show_TvProgram(998)
        End If
    End Sub

    'タブ 番組表　TvRock
    Private Sub TabPage3_Enter(sender As System.Object, e As System.EventArgs) Handles TabPage3.Enter
        If TvRemoteViewer_VB_client_start = 1 Then
            show_TvProgram(999)
        End If
    End Sub

    'タブ ファイル再生
    Private Sub TabPage4_Enter(sender As System.Object, e As System.EventArgs) Handles TabPage4.Enter
        textboxlog_bringtofront()
        Form1Resize()
    End Sub

    'タブ 手動再生
    Private Sub TabPage5_Enter(sender As System.Object, e As System.EventArgs) Handles TabPage5.Enter
        textboxlog_bringtofront()
        Form1Resize()
    End Sub

    'タブ 設定
    Private Sub TabPage6_Enter(sender As System.Object, e As System.EventArgs) Handles TabPage6.Enter
        textboxlog_bringtofront()
        Form1Resize()
    End Sub

    'タブ　サーバー
    Private Sub TabPage7_Enter(sender As System.Object, e As System.EventArgs) Handles TabPage7.Enter
        textboxlog_bringtofront()
        Form1Resize()
    End Sub

    'タブ　番組表以外を押された場合にログを最前面に
    Private Sub textboxlog_bringtofront()
        If textboxlog_temp > 0 Then
            textboxlog_temp = 1 'すぐ0になる
            textboxlog_temp_do()
        End If
        TabControl1.BringToFront()
        TextBoxLog.BringToFront()
    End Sub

    'リサイズ
    Private Sub Form1_Resize(sender As System.Object, e As System.EventArgs) Handles MyBase.Resize
        Form1Resize()
    End Sub

    Private Sub Form1Resize()
        'タブコントロール
        TabControl1.Width = Me.Width
        TabControl1.Height = Me.Height - 24 - 40
        '番組表
        DataGridView1.Left = TabControl1.Location.X
        DataGridView1.Top = TabControl1.Location.Y + TabControl1.ItemSize.Height + 2
        DataGridView1.Width = TabControl1.Width - 20
        DataGridView1.Height = TabControl1.Height - TabControl1.ItemSize.Height - 2
        DataGridView1.Columns(0).Width = DataGridView1.Width
        'ログ
        TextBoxLog.Height = Int(Me.Height / 2.5)
        If TextBoxLog.Height > 300 Then
            TextBoxLog.Height = 300
        End If
        TextBoxLog.Left = TabControl1.Location.X + 4
        TextBoxLog.Top = TabControl1.Location.Y + TabControl1.Height - TextBoxLog.Height
        TextBoxLog.Width = TabControl1.Width - 8
    End Sub

    '配信可能かどうか .stoppingの状態を返す
    Private Function CanStartMovie(ByVal num As Integer) As Integer
        '可能ならば0が返る
        Dim r As Integer = 0
        '再起動中かどうか
        'Dim error_numbers As String = WI_GET_ERROR_STREAM()
        'If error_numbers.IndexOf(":" & ComboBoxNum.Text.ToString & ":") >= 0 Then
        ''再起動中
        'r = 8
        'Else
        '起動中なら状況を表示
        Dim s2 As String = WI_GET_LIVE_STREAM() 'stopping=7個目
        Dim line() As String = Split(s2, vbCrLf)
        For i As Integer = 0 To line.Length - 1
            Dim d() As String = line(i).Split(",")
            If d.Length >= 8 Then
                If d(1) = num Then
                    r = d(8) 'stopping
                    Exit For
                End If
            End If
        Next
        'End If

        Return r
    End Function

    Private Sub DataGridView1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles DataGridView1.DoubleClick
        '配信開始
        '■まず配信可能かどうか調べる
        Dim num As Integer = Val(ComboBoxNum.Text.ToString)
        Dim csm As Integer = CanStartMovie(num)
        If csm = 0 Then
            If textboxlog_temp = 0 Then
                textboxlog_temp_left = TextBoxLog.Left
                textboxlog_temp_width = TextBoxLog.Width
                TextBoxLog.Left = Int(TextBoxLog.Width / 2)
                TextBoxLog.Width = Int(TextBoxLog.Width / 2) - 6
            End If
            TextBoxLog.BringToFront()
            textboxlog_temp_stratstop = 0
            textboxlog_temp = textboxlog_temp_howlong 'ログ表示秒数

            For Each c As DataGridViewCell In DataGridView1.SelectedCells
                Dim bondriver As String = ComboBoxBonDriver.Text
                Dim s As String = DataGridView1.Rows(c.RowIndex).Cells(1).Value
                Dim d() As String = s.Split(",")
                If d.Length = 2 Then
                    '優先指定があればそれに切り替える
                    If bondriver.Length = 0 Or bondriver.IndexOf("---") = 0 Then
                        If Val(d(1)) = 1 Or Val(d(0)) < 1024 Then
                            If TvProgramS_BonDriver1st.Length > 0 Then
                                bondriver = TvProgramS_BonDriver1st
                            End If
                        Else
                            '地デジ
                            If TvProgramD_BonDriver1st.Length > 0 Then
                                bondriver = TvProgramD_BonDriver1st
                            End If
                        End If
                    End If
                    If bondriver.Length > 0 And bondriver.IndexOf("---") < 0 Then
                        log1write(bondriver & "を使用します")
                        Start_Stream(2, bondriver, Val(d(0)), Val(d(1)), "", 0)
                    Else
                        log1write("BonDriverを選択してください")
                    End If
                End If
                Exit For '複数選択には対応せず
            Next c
        Else
            log1write("サーバー側の配信準備ができていません stopping=" & csm)
        End If
    End Sub

    '使用できない番組表を選択できなくする
    Private Sub TabControl1_Selecting(sender As System.Object, e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If e.TabPageIndex = 0 And S_server_status_str.Length < 100 Then
            e.Cancel = True
        ElseIf e.TabPageIndex = 1 And Instr_pickup(S_server_status_str, "TvProgram_EDCB_url=", vbCrLf, 0).length = 0 Then
            e.Cancel = True
        ElseIf e.TabPageIndex = 2 And Instr_pickup(S_server_status_str, "TvProgram_tvrock_url=", vbCrLf, 0).length = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        'テストボタン
    End Sub

    Private Sub skip_movie(ByVal skip_seconds As Integer)
        Dim num As Integer = Val(ComboBoxNum.Text.ToString)
        If num > 0 Then
            player(num).Seeking = 1 'シーク中
            Dim now_utime As Integer = time2unix(Now()) '現在の時間
            Dim start_utime As Integer = player(num).start_utime 'プレーヤーがスタートした時間
            Dim last_SeekSeconds As Integer = player(num).last_SeekSeconds 'プレーヤースタート時にシークされていた秒数
            Dim SeekSeconds As Integer = 0
            Dim fullpathfilename As String = ""
            If start_utime > 0 Then
                SeekSeconds = last_SeekSeconds + (now_utime - start_utime) + skip_seconds
                fullpathfilename = player(num).fullpathfilename 'ビデオファイルを示す文字列
                Start_Stream(1, "", 0, 0, fullpathfilename, SeekSeconds)
            Else
                log1write("プレーヤーでの再生が開始されていません")
            End If
            player(num).Seeking = 0 'シーク終了

            'log1write("===============================")
            'log1write("skip_seconds=" & skip_seconds)
            'log1write("now_utime=" & unix2time(now_utime))
            'log1write("start_utime=" & unix2time(start_utime))
            'log1write("last_SeekSeconds=" & last_SeekSeconds)
            'log1write("fullpathfilename=" & fullpathfilename)
            'log1write("SeekSeconds=" & SeekSeconds)
        End If
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        '一時停止ボタン
        Dim result As String = ""
        Dim status As Integer = 0
        Dim num As Integer = Val(ComboBoxNum.Text.ToString)
        Dim start_utime As Integer = player(num).start_utime 'プレーヤーがスタートした時間
        If Button8.Text = "＞" Then
            Button8.Text = "||"
            status = 0
        Else
            Button8.Text = "＞"
            status = 1
        End If
        If num > 0 Then
            If start_utime > 0 Then
                If status = 1 Then
                    '一時停止にする
                    player(num).Seeking = 1 'シーク中
                    'vlc一時停止
                    result = VLC_remote("pause", VLC_rc_port + num - 1)
                    player(num).stop1_utime = time2unix(Now())
                Else
                    '再生
                    Dim SeekSeconds As Integer = player(num).last_SeekSeconds + (player(num).stop1_utime - player(num).start_utime)
                    Dim fullpathfilename As String = player(num).fullpathfilename 'ビデオファイルを示す文字列
                    Start_Stream(1, "", 0, 0, fullpathfilename, SeekSeconds - 1)
                    player(num).Seeking = 0 'シーク終了
                End If
            Else
                log1write("プレーヤーでの再生が開始されていません")
                Button8.Text = "||"
            End If
        End If
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        '秒スキップ
        skip_movie(15)
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        '秒スキップ
        skip_movie(30)
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        '秒スキップ
        skip_movie(60)
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        '秒スキップ
        skip_movie(90)
    End Sub

    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        '秒スキップ
        skip_movie(-15)
    End Sub

    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
        '秒スキップ
        skip_movie(-30)
    End Sub

    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click
        '秒スキップ
        skip_movie(-60)
    End Sub

    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        '秒スキップ
        skip_movie(-90)
    End Sub

    Private Sub Button16_Click(sender As System.Object, e As System.EventArgs) Handles Button16.Click
        Dim num As Integer = Val(ComboBoxNum.Text.ToString)
        If num > 0 Then
            player(num).Seeking = 1 'シーク中
            Dim start_utime As Integer = player(num).start_utime 'プレーヤーがスタートした時間
            Dim fullpathfilename As String = ""
            If start_utime > 0 Then
                Dim SeekSeconds As Integer = Val(TextBoxSeek.Text.ToString)
                fullpathfilename = player(num).fullpathfilename 'ビデオファイルを示す文字列
                Start_Stream(1, "", 0, 0, fullpathfilename, SeekSeconds)
            Else
                log1write("プレーヤーでの再生が開始されていません")
            End If
            player(num).Seeking = 0 'シーク終了

        End If
    End Sub

    Private Sub CheckBoxHardSub_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxHardSub.CheckedChanged
        If CheckBoxHardSub.Checked = True Then
            NoHardSub = 0
        Else
            NoHardSub = 1
        End If
    End Sub

End Class
