
TvRemoteViewer_VB 0.66以降に対応

サーバーIPを設定して再起動してください


















WEBインターフェース一覧

    '配信スタート
    Public Function WI_START_STREAM(ByVal num As Integer, ByVal BonDriver As String, ByVal ServiceID As Integer, ByVal chspace As Integer, ByVal resolution As String, ByVal NHKMODE As Integer, ByVal stream_mode As Integer, ByVal VideoFilename As String) As String

    '配信停止
    Public Function WI_STOP_STREAM(ByVal num As Integer) As String

    '放送局一覧
    Public Function WI_GET_CHANNELS() As String

    '配信中リスト取得
    Public Function WI_GET_LIVE_STREAM() As String

   'サーバー設定を取得
    Public Function WI_GET_TVRV_STATUS() As String

    'できあがったtsファイル数
    Public Function WI_GET_TSFILE_COUNT(ByVal num As Integer) As String

    '解像度取得
    Public Function WI_GET_RESOLUTION() As String

    'ファイル一覧
    Public Function WI_GET_VIDEOFILES() As String

    '再起動しているストリーム番号を取得
    Public Function WI_GET_ERROR_STREAM() As String

    '番組表取得
    Public Function WI_GET_PROGRAM_D() As String
    Public Function WI_GET_PROGRAM_TVROCK() As String
    Public Function WI_GET_PROGRAM_EDCB() As String
