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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBoxNHKMODE = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxServiceID = New System.Windows.Forms.TextBox()
        Me.TextBoxBonDriver = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxChSpace = New System.Windows.Forms.TextBox()
        Me.TextBoxLog = New System.Windows.Forms.TextBox()
        Me.ButtonShowChannels = New System.Windows.Forms.Button()
        Me.ButtonShowStreams = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ButtonServerStatus = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComboBoxResolution = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ComboBoxStreamMode = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ButtonRunVLC = New System.Windows.Forms.Button()
        Me.TextBoxVLCURL = New System.Windows.Forms.TextBox()
        Me.TextBoxVLCPATH = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(142, 259)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(98, 23)
        Me.ButtonStart.TabIndex = 0
        Me.ButtonStart.Text = "接続"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'TextBoxServerUsername
        '
        Me.TextBoxServerUsername.Location = New System.Drawing.Point(87, 37)
        Me.TextBoxServerUsername.Name = "TextBoxServerUsername"
        Me.TextBoxServerUsername.Size = New System.Drawing.Size(100, 19)
        Me.TextBoxServerUsername.TabIndex = 1
        '
        'TextBoxServerPassword
        '
        Me.TextBoxServerPassword.Location = New System.Drawing.Point(87, 62)
        Me.TextBoxServerPassword.Name = "TextBoxServerPassword"
        Me.TextBoxServerPassword.Size = New System.Drawing.Size(100, 19)
        Me.TextBoxServerPassword.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "ユーザー名"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "PASS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "サーバーIP"
        '
        'TextBoxServerIP
        '
        Me.TextBoxServerIP.Location = New System.Drawing.Point(87, 12)
        Me.TextBoxServerIP.Name = "TextBoxServerIP"
        Me.TextBoxServerIP.Size = New System.Drawing.Size(100, 19)
        Me.TextBoxServerIP.TabIndex = 5
        Me.TextBoxServerIP.Text = "127.0.0.1:40003"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 264)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 12)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "ストリーム番号"
        '
        'ComboBoxNum
        '
        Me.ComboBoxNum.FormattingEnabled = True
        Me.ComboBoxNum.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.ComboBoxNum.Location = New System.Drawing.Point(87, 261)
        Me.ComboBoxNum.Name = "ComboBoxNum"
        Me.ComboBoxNum.Size = New System.Drawing.Size(51, 20)
        Me.ComboBoxNum.TabIndex = 68
        Me.ComboBoxNum.TabStop = False
        Me.ComboBoxNum.Text = "1"
        '
        'ButtonStop
        '
        Me.ButtonStop.Location = New System.Drawing.Point(246, 259)
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(98, 23)
        Me.ButtonStop.TabIndex = 70
        Me.ButtonStop.Text = "切断"
        Me.ButtonStop.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 191)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 12)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "NHKMODE"
        '
        'ComboBoxNHKMODE
        '
        Me.ComboBoxNHKMODE.FormattingEnabled = True
        Me.ComboBoxNHKMODE.Items.AddRange(New Object() {"0", "1", "2", "9"})
        Me.ComboBoxNHKMODE.Location = New System.Drawing.Point(87, 188)
        Me.ComboBoxNHKMODE.Name = "ComboBoxNHKMODE"
        Me.ComboBoxNHKMODE.Size = New System.Drawing.Size(51, 20)
        Me.ComboBoxNHKMODE.TabIndex = 71
        Me.ComboBoxNHKMODE.TabStop = False
        Me.ComboBoxNHKMODE.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 12)
        Me.Label5.TabIndex = 76
        Me.Label5.Text = "ServiceID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 12)
        Me.Label6.TabIndex = 75
        Me.Label6.Text = "BonDriver"
        '
        'TextBoxServiceID
        '
        Me.TextBoxServiceID.Location = New System.Drawing.Point(87, 112)
        Me.TextBoxServiceID.Name = "TextBoxServiceID"
        Me.TextBoxServiceID.Size = New System.Drawing.Size(51, 19)
        Me.TextBoxServiceID.TabIndex = 74
        Me.TextBoxServiceID.Text = "101"
        '
        'TextBoxBonDriver
        '
        Me.TextBoxBonDriver.Location = New System.Drawing.Point(87, 87)
        Me.TextBoxBonDriver.Name = "TextBoxBonDriver"
        Me.TextBoxBonDriver.Size = New System.Drawing.Size(257, 19)
        Me.TextBoxBonDriver.TabIndex = 73
        Me.TextBoxBonDriver.Text = "bondriver_spinel_pt3_s1.dll"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(26, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 12)
        Me.Label8.TabIndex = 78
        Me.Label8.Text = "Ch.Space"
        '
        'TextBoxChSpace
        '
        Me.TextBoxChSpace.Location = New System.Drawing.Point(87, 137)
        Me.TextBoxChSpace.Name = "TextBoxChSpace"
        Me.TextBoxChSpace.Size = New System.Drawing.Size(51, 19)
        Me.TextBoxChSpace.TabIndex = 77
        Me.TextBoxChSpace.Text = "0"
        '
        'TextBoxLog
        '
        Me.TextBoxLog.Location = New System.Drawing.Point(2, 296)
        Me.TextBoxLog.Multiline = True
        Me.TextBoxLog.Name = "TextBoxLog"
        Me.TextBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxLog.Size = New System.Drawing.Size(843, 343)
        Me.TextBoxLog.TabIndex = 79
        '
        'ButtonShowChannels
        '
        Me.ButtonShowChannels.Location = New System.Drawing.Point(576, 62)
        Me.ButtonShowChannels.Name = "ButtonShowChannels"
        Me.ButtonShowChannels.Size = New System.Drawing.Size(151, 23)
        Me.ButtonShowChannels.TabIndex = 80
        Me.ButtonShowChannels.Text = "BonDriver＆チャンネル一覧"
        Me.ButtonShowChannels.UseVisualStyleBackColor = True
        '
        'ButtonShowStreams
        '
        Me.ButtonShowStreams.Location = New System.Drawing.Point(576, 93)
        Me.ButtonShowStreams.Name = "ButtonShowStreams"
        Me.ButtonShowStreams.Size = New System.Drawing.Size(151, 23)
        Me.ButtonShowStreams.TabIndex = 81
        Me.ButtonShowStreams.Text = "配信中ストリーム"
        Me.ButtonShowStreams.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(517, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 82
        Me.Label9.Text = "情報表示"
        '
        'ButtonServerStatus
        '
        Me.ButtonServerStatus.Location = New System.Drawing.Point(576, 33)
        Me.ButtonServerStatus.Name = "ButtonServerStatus"
        Me.ButtonServerStatus.Size = New System.Drawing.Size(151, 23)
        Me.ButtonServerStatus.TabIndex = 83
        Me.ButtonServerStatus.Text = "サーバーステータス"
        Me.ButtonServerStatus.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(144, 191)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(146, 12)
        Me.Label11.TabIndex = 85
        Me.Label11.Text = "0=主・副　1=主　2=副　9=vlc"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(576, 123)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(196, 23)
        Me.Button1.TabIndex = 89
        Me.Button1.Text = "fileroot\mystream%NUM%*.tsの数"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(584, 150)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(175, 12)
        Me.Label10.TabIndex = 90
        Me.Label10.Text = "VLC HTTPストリームの場合は常に0"
        '
        'ComboBoxResolution
        '
        Me.ComboBoxResolution.FormattingEnabled = True
        Me.ComboBoxResolution.Items.AddRange(New Object() {"360x180", "480x270", "640x360", "720x480", "960x540", "1280x720", "無変換"})
        Me.ComboBoxResolution.Location = New System.Drawing.Point(87, 162)
        Me.ComboBoxResolution.Name = "ComboBoxResolution"
        Me.ComboBoxResolution.Size = New System.Drawing.Size(78, 20)
        Me.ComboBoxResolution.TabIndex = 91
        Me.ComboBoxResolution.TabStop = False
        Me.ComboBoxResolution.Text = "640x360"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(26, 165)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 12)
        Me.Label15.TabIndex = 92
        Me.Label15.Text = "解像度"
        '
        'ComboBoxStreamMode
        '
        Me.ComboBoxStreamMode.FormattingEnabled = True
        Me.ComboBoxStreamMode.Items.AddRange(New Object() {"0", "1", "2", "3"})
        Me.ComboBoxStreamMode.Location = New System.Drawing.Point(87, 214)
        Me.ComboBoxStreamMode.Name = "ComboBoxStreamMode"
        Me.ComboBoxStreamMode.Size = New System.Drawing.Size(51, 20)
        Me.ComboBoxStreamMode.TabIndex = 93
        Me.ComboBoxStreamMode.TabStop = False
        Me.ComboBoxStreamMode.Text = "2"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(26, 191)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 12)
        Me.Label16.TabIndex = 72
        Me.Label16.Text = "NHKMODE"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(14, 217)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 12)
        Me.Label17.TabIndex = 94
        Me.Label17.Text = "StreamMode"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(144, 217)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(289, 12)
        Me.Label18.TabIndex = 95
        Me.Label18.Text = "0=HLS　1=HLSファイル　2=HTTPストリーム　9=HTTPファイル"
        '
        'ButtonRunVLC
        '
        Me.ButtonRunVLC.Location = New System.Drawing.Point(576, 258)
        Me.ButtonRunVLC.Name = "ButtonRunVLC"
        Me.ButtonRunVLC.Size = New System.Drawing.Size(98, 23)
        Me.ButtonRunVLC.TabIndex = 96
        Me.ButtonRunVLC.Text = "VLCで視聴"
        Me.ButtonRunVLC.UseVisualStyleBackColor = True
        '
        'TextBoxVLCURL
        '
        Me.TextBoxVLCURL.Location = New System.Drawing.Point(576, 233)
        Me.TextBoxVLCURL.Name = "TextBoxVLCURL"
        Me.TextBoxVLCURL.Size = New System.Drawing.Size(257, 19)
        Me.TextBoxVLCURL.TabIndex = 97
        Me.TextBoxVLCURL.Text = "http://127.0.0.1:42465/mystream1.ts"
        '
        'TextBoxVLCPATH
        '
        Me.TextBoxVLCPATH.Location = New System.Drawing.Point(576, 208)
        Me.TextBoxVLCPATH.Name = "TextBoxVLCPATH"
        Me.TextBoxVLCPATH.Size = New System.Drawing.Size(257, 19)
        Me.TextBoxVLCPATH.TabIndex = 98
        Me.TextBoxVLCPATH.Text = "D:\TvRemoteViewer\vlc\vlc.exe"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(524, 212)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 12)
        Me.Label13.TabIndex = 99
        Me.Label13.Text = "VLCパス"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(497, 236)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 12)
        Me.Label19.TabIndex = 100
        Me.Label19.Text = "VLC再生URL"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(845, 638)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TextBoxVLCPATH)
        Me.Controls.Add(Me.TextBoxVLCURL)
        Me.Controls.Add(Me.ButtonRunVLC)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.ComboBoxStreamMode)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.ComboBoxResolution)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.ButtonServerStatus)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ButtonShowStreams)
        Me.Controls.Add(Me.ButtonShowChannels)
        Me.Controls.Add(Me.TextBoxLog)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBoxChSpace)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBoxServiceID)
        Me.Controls.Add(Me.TextBoxBonDriver)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label4)
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
    Private WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxNHKMODE As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBoxServiceID As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxBonDriver As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBoxChSpace As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxLog As System.Windows.Forms.TextBox
    Friend WithEvents ButtonShowChannels As System.Windows.Forms.Button
    Friend WithEvents ButtonShowStreams As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ButtonServerStatus As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxResolution As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxStreamMode As System.Windows.Forms.ComboBox
    Private WithEvents Label16 As System.Windows.Forms.Label
    Private WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ButtonRunVLC As System.Windows.Forms.Button
    Friend WithEvents TextBoxVLCURL As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxVLCPATH As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label

End Class
