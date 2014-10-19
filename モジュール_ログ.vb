Module モジュール_ログ
    'ログ
    Public log1 As String = ""
    Public log1_dummy As String = log1

    'ログを書き込む
    Public Sub log1write(ByVal s As String)
        log1 = Now() & "  " & s & vbCrLf & log1

        'ログ処理
        If log1.Length > 20000 Then
            '10000文字以上になったらカット
            log1 = log1.Substring(0, 20000)
        End If
        Form1.TextBoxLog.Text = log1
        Form1.TextBoxLog.Refresh()

    End Sub
End Module
