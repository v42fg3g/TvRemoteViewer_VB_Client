<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.TextBoxServerUsername = New System.Windows.Forms.TextBox()
        Me.TextBoxServerPassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxServerIP = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBoxNum = New System.Windows.Forms.ComboBox()
        Me.ButtonStop = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxChSpace = New System.Windows.Forms.TextBox()
        Me.TextBoxLog = New System.Windows.Forms.TextBox()
        Me.ButtonShowChannels = New System.Windows.Forms.Button()
        Me.ButtonShowStreams = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ButtonServerStatus = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBoxResolution = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ButtonRunVLC = New System.Windows.Forms.Button()
        Me.TextBoxVLCURL = New System.Windows.Forms.TextBox()
        Me.TextBoxVLCPATH = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.LabelStream = New System.Windows.Forms.Label()
        Me.ComboBoxServiceID = New System.Windows.Forms.ComboBox()
        Me.ComboBoxBonDriver = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ButtonProgram_D = New System.Windows.Forms.Button()
        Me.ButtonShowResolution = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ButtonVideoFiles = New System.Windows.Forms.Button()
        Me.ComboBoxVideo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxSuccessSecond = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBoxNHKMODE = New System.Windows.Forms.ComboBox()
        Me.ButtonVLCapp = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(88, 419)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(98, 23)
        Me.ButtonStart.TabIndex = 8
        Me.ButtonStart.TabStop = False
        Me.ButtonStart.Text = "接続"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'TextBoxServerUsername
        '
        Me.TextBoxServerUsername.Location = New System.Drawing.Point(89, 61)
        Me.TextBoxServerUsername.Name = "TextBoxServerUsername"
        Me.TextBoxServerUsername.Size = New System.Drawing.Size(100, 19)
        Me.TextBoxServerUsername.TabIndex = 11
        '
        'TextBoxServerPassword
        '
        Me.TextBoxServerPassword.Location = New System.Drawing.Point(89, 82)
        Me.TextBoxServerPassword.Name = "TextBoxServerPassword"
        Me.TextBoxServerPassword.Size = New System.Drawing.Size(100, 19)
        Me.TextBoxServerPassword.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "PASS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "サーバーIP (*)"
        '
        'TextBoxServerIP
        '
        Me.TextBoxServerIP.Location = New System.Drawing.Point(89, 40)
        Me.TextBoxServerIP.Name = "TextBoxServerIP"
        Me.TextBoxServerIP.Size = New System.Drawing.Size(212, 19)
        Me.TextBoxServerIP.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 240)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 12)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "ストリーム番号"
        '
        'ComboBoxNum
        '
        Me.ComboBoxNum.FormattingEnabled = True
        Me.ComboBoxNum.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.ComboBoxNum.Location = New System.Drawing.Point(89, 237)
        Me.ComboBoxNum.Name = "ComboBoxNum"
        Me.ComboBoxNum.Size = New System.Drawing.Size(51, 20)
        Me.ComboBoxNum.TabIndex = 1
        '
        'ButtonStop
        '
        Me.ButtonStop.Location = New System.Drawing.Point(192, 419)
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(46, 23)
        Me.ButtonStop.TabIndex = 9
        Me.ButtonStop.TabStop = False
        Me.ButtonStop.Text = "切断"
        Me.ButtonStop.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 286)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 12)
        Me.Label8.TabIndex = 78
        Me.Label8.Text = "Ch.Space"
        '
        'TextBoxChSpace
        '
        Me.TextBoxChSpace.Location = New System.Drawing.Point(89, 283)
        Me.TextBoxChSpace.Name = "TextBoxChSpace"
        Me.TextBoxChSpace.Size = New System.Drawing.Size(51, 19)
        Me.TextBoxChSpace.TabIndex = 3
        '
        'TextBoxLog
        '
        Me.TextBoxLog.Location = New System.Drawing.Point(-1, 466)
        Me.TextBoxLog.Multiline = True
        Me.TextBoxLog.Name = "TextBoxLog"
        Me.TextBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxLog.Size = New System.Drawing.Size(598, 207)
        Me.TextBoxLog.TabIndex = 79
        '
        'ButtonShowChannels
        '
        Me.ButtonShowChannels.Location = New System.Drawing.Point(446, 56)
        Me.ButtonShowChannels.Name = "ButtonShowChannels"
        Me.ButtonShowChannels.Size = New System.Drawing.Size(151, 23)
        Me.ButtonShowChannels.TabIndex = 80
        Me.ButtonShowChannels.Text = "BonDriver＆チャンネル一覧"
        Me.ButtonShowChannels.UseVisualStyleBackColor = True
        '
        'ButtonShowStreams
        '
        Me.ButtonShowStreams.Location = New System.Drawing.Point(446, 80)
        Me.ButtonShowStreams.Name = "ButtonShowStreams"
        Me.ButtonShowStreams.Size = New System.Drawing.Size(151, 23)
        Me.ButtonShowStreams.TabIndex = 81
        Me.ButtonShowStreams.Text = "配信中ストリーム"
        Me.ButtonShowStreams.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(444, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 82
        Me.Label9.Text = "情報表示"
        '
        'ButtonServerStatus
        '
        Me.ButtonServerStatus.Location = New System.Drawing.Point(446, 32)
        Me.ButtonServerStatus.Name = "ButtonServerStatus"
        Me.ButtonServerStatus.Size = New System.Drawing.Size(151, 23)
        Me.ButtonServerStatus.TabIndex = 83
        Me.ButtonServerStatus.Text = "サーバーステータス"
        Me.ButtonServerStatus.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(446, 246)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(151, 23)
        Me.Button1.TabIndex = 89
        Me.Button1.Text = "mystream%NUM%*.tsの数"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBoxResolution
        '
        Me.ComboBoxResolution.FormattingEnabled = True
        Me.ComboBoxResolution.Location = New System.Drawing.Point(89, 351)
        Me.ComboBoxResolution.Name = "ComboBoxResolution"
        Me.ComboBoxResolution.Size = New System.Drawing.Size(78, 20)
        Me.ComboBoxResolution.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(14, 354)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 12)
        Me.Label15.TabIndex = 92
        Me.Label15.Text = "解像度"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(14, 331)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 12)
        Me.Label16.TabIndex = 72
        Me.Label16.Text = "NHKMODE"
        '
        'ButtonRunVLC
        '
        Me.ButtonRunVLC.Location = New System.Drawing.Point(360, 172)
        Me.ButtonRunVLC.Name = "ButtonRunVLC"
        Me.ButtonRunVLC.Size = New System.Drawing.Size(69, 21)
        Me.ButtonRunVLC.TabIndex = 96
        Me.ButtonRunVLC.Text = "VLC起動"
        Me.ButtonRunVLC.UseVisualStyleBackColor = True
        '
        'TextBoxVLCURL
        '
        Me.TextBoxVLCURL.Enabled = False
        Me.TextBoxVLCURL.Location = New System.Drawing.Point(89, 173)
        Me.TextBoxVLCURL.Name = "TextBoxVLCURL"
        Me.TextBoxVLCURL.Size = New System.Drawing.Size(267, 19)
        Me.TextBoxVLCURL.TabIndex = 12
        Me.TextBoxVLCURL.TabStop = False
        '
        'TextBoxVLCPATH
        '
        Me.TextBoxVLCPATH.Location = New System.Drawing.Point(89, 152)
        Me.TextBoxVLCPATH.Name = "TextBoxVLCPATH"
        Me.TextBoxVLCPATH.Size = New System.Drawing.Size(317, 19)
        Me.TextBoxVLCPATH.TabIndex = 21
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 155)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 12)
        Me.Label13.TabIndex = 99
        Me.Label13.Text = "VLC.exe"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 176)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 12)
        Me.Label19.TabIndex = 100
        Me.Label19.Text = "VLCソース"
        '
        'LabelStream
        '
        Me.LabelStream.AutoSize = True
        Me.LabelStream.Location = New System.Drawing.Point(146, 240)
        Me.LabelStream.Name = "LabelStream"
        Me.LabelStream.Size = New System.Drawing.Size(47, 12)
        Me.LabelStream.TabIndex = 111
        Me.LabelStream.Text = "配信中："
        '
        'ComboBoxServiceID
        '
        Me.ComboBoxServiceID.FormattingEnabled = True
        Me.ComboBoxServiceID.Location = New System.Drawing.Point(89, 305)
        Me.ComboBoxServiceID.Name = "ComboBoxServiceID"
        Me.ComboBoxServiceID.Size = New System.Drawing.Size(249, 20)
        Me.ComboBoxServiceID.TabIndex = 4
        '
        'ComboBoxBonDriver
        '
        Me.ComboBoxBonDriver.FormattingEnabled = True
        Me.ComboBoxBonDriver.Location = New System.Drawing.Point(89, 260)
        Me.ComboBoxBonDriver.Name = "ComboBoxBonDriver"
        Me.ComboBoxBonDriver.Size = New System.Drawing.Size(210, 20)
        Me.ComboBoxBonDriver.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 308)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 12)
        Me.Label14.TabIndex = 107
        Me.Label14.Text = "ServiceID"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(14, 263)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 12)
        Me.Label20.TabIndex = 106
        Me.Label20.Text = "BonDriver"
        '
        'ButtonProgram_D
        '
        Me.ButtonProgram_D.Location = New System.Drawing.Point(446, 152)
        Me.ButtonProgram_D.Name = "ButtonProgram_D"
        Me.ButtonProgram_D.Size = New System.Drawing.Size(151, 23)
        Me.ButtonProgram_D.TabIndex = 112
        Me.ButtonProgram_D.Text = "番組表　地デジ"
        Me.ButtonProgram_D.UseVisualStyleBackColor = True
        '
        'ButtonShowResolution
        '
        Me.ButtonShowResolution.Location = New System.Drawing.Point(446, 128)
        Me.ButtonShowResolution.Name = "ButtonShowResolution"
        Me.ButtonShowResolution.Size = New System.Drawing.Size(151, 23)
        Me.ButtonShowResolution.TabIndex = 113
        Me.ButtonShowResolution.Text = "解像度"
        Me.ButtonShowResolution.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(446, 175)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(151, 23)
        Me.Button2.TabIndex = 114
        Me.Button2.Text = "番組表　TvRock"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(446, 198)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(151, 23)
        Me.Button3.TabIndex = 115
        Me.Button3.Text = "番組表　EDCB"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ButtonVideoFiles
        '
        Me.ButtonVideoFiles.Location = New System.Drawing.Point(446, 222)
        Me.ButtonVideoFiles.Name = "ButtonVideoFiles"
        Me.ButtonVideoFiles.Size = New System.Drawing.Size(151, 23)
        Me.ButtonVideoFiles.TabIndex = 116
        Me.ButtonVideoFiles.Text = "ファイル一覧"
        Me.ButtonVideoFiles.UseVisualStyleBackColor = True
        '
        'ComboBoxVideo
        '
        Me.ComboBoxVideo.FormattingEnabled = True
        Me.ComboBoxVideo.Location = New System.Drawing.Point(89, 374)
        Me.ComboBoxVideo.Name = "ComboBoxVideo"
        Me.ComboBoxVideo.Size = New System.Drawing.Size(340, 20)
        Me.ComboBoxVideo.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 377)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 12)
        Me.Label5.TabIndex = 119
        Me.Label5.Text = "ファイル再生"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(446, 104)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(151, 23)
        Me.Button4.TabIndex = 120
        Me.Button4.Text = "再起動中ストリーム"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 399)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 122
        Me.Label4.Text = "成功判断"
        '
        'TextBoxSuccessSecond
        '
        Me.TextBoxSuccessSecond.Location = New System.Drawing.Point(89, 396)
        Me.TextBoxSuccessSecond.Name = "TextBoxSuccessSecond"
        Me.TextBoxSuccessSecond.Size = New System.Drawing.Size(25, 19)
        Me.TextBoxSuccessSecond.TabIndex = 121
        Me.TextBoxSuccessSecond.Text = "3"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(120, 399)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "秒"
        '
        'ComboBoxNHKMODE
        '
        Me.ComboBoxNHKMODE.Enabled = False
        Me.ComboBoxNHKMODE.FormattingEnabled = True
        Me.ComboBoxNHKMODE.Items.AddRange(New Object() {"0", "1", "2", "9", "11", "12"})
        Me.ComboBoxNHKMODE.Location = New System.Drawing.Point(89, 328)
        Me.ComboBoxNHKMODE.Name = "ComboBoxNHKMODE"
        Me.ComboBoxNHKMODE.Size = New System.Drawing.Size(51, 20)
        Me.ComboBoxNHKMODE.TabIndex = 5
        Me.ComboBoxNHKMODE.Text = "0"
        '
        'ButtonVLCapp
        '
        Me.ButtonVLCapp.Location = New System.Drawing.Point(410, 150)
        Me.ButtonVLCapp.Name = "ButtonVLCapp"
        Me.ButtonVLCapp.Size = New System.Drawing.Size(19, 21)
        Me.ButtonVLCapp.TabIndex = 124
        Me.ButtonVLCapp.Text = "..."
        Me.ButtonVLCapp.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(4, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 12)
        Me.Label10.TabIndex = 125
        Me.Label10.Text = "サーバー設定"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 215)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 12)
        Me.Label11.TabIndex = 126
        Me.Label11.Text = "ストリーム"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 130)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 12)
        Me.Label12.TabIndex = 127
        Me.Label12.Text = "ローカル設定"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(307, 43)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(97, 12)
        Me.Label17.TabIndex = 128
        Me.Label17.Text = "例：127.0.0.1:40003"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 674)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.ButtonVLCapp)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxSuccessSecond)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboBoxVideo)
        Me.Controls.Add(Me.ButtonVideoFiles)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ButtonShowResolution)
        Me.Controls.Add(Me.ButtonProgram_D)
        Me.Controls.Add(Me.LabelStream)
        Me.Controls.Add(Me.ComboBoxServiceID)
        Me.Controls.Add(Me.ComboBoxBonDriver)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TextBoxVLCPATH)
        Me.Controls.Add(Me.TextBoxVLCURL)
        Me.Controls.Add(Me.ButtonRunVLC)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.ComboBoxResolution)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ButtonServerStatus)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ButtonShowStreams)
        Me.Controls.Add(Me.ButtonShowChannels)
        Me.Controls.Add(Me.TextBoxLog)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBoxChSpace)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.ComboBoxNHKMODE)
        Me.Controls.Add(Me.ButtonStop)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ComboBoxNum)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxServerIP)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxServerPassword)
        Me.Controls.Add(Me.TextBoxServerUsername)
        Me.Controls.Add(Me.ButtonStart)
        Me.Name = "Form1"
        Me.Text = "TvRemoteViewer_VB_Client"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents TextBoxServerUsername As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxServerPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxServerIP As System.Windows.Forms.TextBox
    Private WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxNum As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonStop As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBoxChSpace As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxLog As System.Windows.Forms.TextBox
    Friend WithEvents ButtonShowChannels As System.Windows.Forms.Button
    Friend WithEvents ButtonShowStreams As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ButtonServerStatus As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboBoxResolution As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Private WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ButtonRunVLC As System.Windows.Forms.Button
    Friend WithEvents TextBoxVLCURL As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxVLCPATH As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Private WithEvents LabelStream As System.Windows.Forms.Label
    Friend WithEvents ComboBoxServiceID As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxBonDriver As System.Windows.Forms.ComboBox
    Private WithEvents Label14 As System.Windows.Forms.Label
    Private WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ButtonProgram_D As System.Windows.Forms.Button
    Friend WithEvents ButtonShowResolution As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ButtonVideoFiles As System.Windows.Forms.Button
    Friend WithEvents ComboBoxVideo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSuccessSecond As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxNHKMODE As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonVLCapp As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label

End Class
