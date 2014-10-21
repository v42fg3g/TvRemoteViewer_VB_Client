TvRemoteViewer_VB_client 0.06

TvRemoteViewer_VB 0.72以降に対応

■サーバー側設定
・サーバー側のTvRemoteViewer_VB.iniの以下の項目を設定してください
HTTPSTREAM_App=1　ならVLCによる配信
HTTPSTREAM_App=2　ならffmpegによる配信（推奨）
・配信オプションは
HLS_option_ffmpeg_http.txt
から読み込まれたものが使用されます

■クライアント側設定
視聴時の優先BonDriverを設定したい場合はTvRemoteViewer_VB_Client.iniを修正してください

■初回起動時
設定タブでサーバーIPを設定した後に再起動してください

■注意
・おそらくVLC側の不具合だと思うのですが今のところVLCストリームの複数同時配信はできないと思います
・ffmpegのオプションが悪いのか無変換での視聴開始に失敗することがあります


■履歴
	0.01	サンプルクライアント
	0.02	まともなクライアント
	0.03	VLC終了方法の変更
		チャンネル変更する度に配信を停止していたバグを修正
	0.04	番組表からの視聴に対応
		ユーザーインターフェースの修正
		優先BonDriverの指定をiniに追加
	0.05	ffmpegのHTTPストリームに対応
	0.06	フォーム上にNHKMODE選択ボックスを配置
		優先BonDriverが設定されているとフォーム上の選択を無視してしまうバグを修正









WEBインターフェース一覧
「サーバー」タブ参照のこと
サーバーにWEBアクセスすることで各種命令＆情報取得ができます。

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

    'できあがったtsファイル数（HTTPストリームでは常に0が返ってきます）
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
