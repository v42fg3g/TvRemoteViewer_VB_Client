Module モジュール_設定
    '================================================
    '共通で使用する変数
    '================================================
    Public version As String = "TvRemoteViewer_VB_client v0.06"

    Public TvRemoteViewer_VB_client_start As Integer = 0 '無事起動したときに１になる

    'TvRemoteViewer_VBのＩＤとパスワード
    Public M_username As String = ""
    Public M_password As String = ""

    Public M_TVRV_URL As String = "" 'WEBインターフェース用サーバーURL末尾「/」 'フォーム上のサーバーIPから自動作成

    Public player_proc(30) As Integer 'プレーヤーのプロセスID(VLC)を記録しておく

    'サーバーの状態を記録しておく
    Public S_server_status_str As String = "" '=WI_GET_TVRV_STATUS
    Public S_BonDriver_Channel_str As String = "" '=WI_GET_CHANNELS
    Public S_HTTPSTREAM_App As Integer = 0 '1=VLC 2=ffmpeg
End Module
