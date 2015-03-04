Module モジュール_設定
    '================================================
    '共通で使用する変数
    '================================================
    Public version As String = "TvRemoteViewer_VB_client v0.08"

    Public time1_ng As Integer = 0

    Public TvRemoteViewer_VB_client_start As Integer = 0 '無事起動したときに１になる

    'TvRemoteViewer_VBのＩＤとパスワード
    Public M_username As String = ""
    Public M_password As String = ""

    Public M_TVRV_URL As String = "" 'WEBインターフェース用サーバーURL末尾「/」 'フォーム上のサーバーIPから自動作成

    'VLCプレーヤー
    Public player(30) As playerstructure
    Public Structure playerstructure
        Public proc As Integer 'プレーヤーのプロセスID(VLC)を記録しておく
        Public start_utime As Integer 'プレーヤーが再生スタートしたunixtime
        Public fullpathfilename As String 'ファイル再生プルパス　URLエンコード済のものも可
        Public last_SeekSeconds As Integer '前回再生したときのシーク秒数
        Public Seeking As Integer '今シーキング中なら1
        Public stop1_utime As Integer 'プレーヤーが一時停止したunixtime
    End Structure
    'Public player_proc(30) As Integer
    'Public player_start(30) As Integer

    Public VLC_rc_port As Integer = 42525 'VLC rcポートの先頭 +num-1

    'サーバーの状態を記録しておく
    Public S_server_status_str As String = "" '=WI_GET_TVRV_STATUS
    Public S_BonDriver_Channel_str As String = "" '=WI_GET_CHANNELS
    Public S_HTTPSTREAM_App As Integer = 0 '1=VLC 2=ffmpeg
End Module
