Module モジュール_番組表
    '番組表にて優先するBonDriver
    Public TvProgramD_BonDriver1st As String = "" '地デジ優先BonDriver
    Public TvProgramS_BonDriver1st As String = "" 'BS/CS優先BonDriver

    '番組表にてログを一時表示するための変数
    Public textboxlog_temp As Integer = 0
    Public textboxlog_temp_left As Integer = 0
    Public textboxlog_temp_width As Integer = 0
    Public textboxlog_temp_howlong As Integer = 10 '10秒表示しておく
    Public textboxlog_temp_stratstop As Integer = 0 '0=start 1=stop
End Module
