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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TextBoxServerUsername = New System.Windows.Forms.TextBox()
        Me.TextBoxServerPassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxServerIP = New System.Windows.Forms.TextBox()
        Me.ComboBoxNum = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxChSpace = New System.Windows.Forms.TextBox()
        Me.TextBoxLog = New System.Windows.Forms.TextBox()
        Me.ButtonShowStreams = New System.Windows.Forms.Button()
        Me.ButtonServerStatus = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ButtonRunVLC = New System.Windows.Forms.Button()
        Me.TextBoxVLCURL = New System.Windows.Forms.TextBox()
        Me.TextBoxVLCPATH = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.LabelStream = New System.Windows.Forms.Label()
        Me.ComboBoxServiceID = New System.Windows.Forms.ComboBox()
        Me.ComboBoxBonDriver = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ButtonProgram_D = New System.Windows.Forms.Button()
        Me.ButtonShowResolution = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ButtonVideoFiles = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxSuccessSecond = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ButtonVLCapp = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ButtonStop_file = New System.Windows.Forms.Button()
        Me.ButtonStart_file = New System.Windows.Forms.Button()
        Me.ComboBoxVideo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.ButtonStop = New System.Windows.Forms.Button()
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ButtonShowChannels = New System.Windows.Forms.Button()
        Me.ComboBoxResolution = New System.Windows.Forms.ComboBox()
        Me.ComboBoxNHKMODE = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabControl1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBoxServerUsername
        '
        Me.TextBoxServerUsername.Location = New System.Drawing.Point(88, 53)
        Me.TextBoxServerUsername.Name = "TextBoxServerUsername"
        Me.TextBoxServerUsername.Size = New System.Drawing.Size(100, 19)
        Me.TextBoxServerUsername.TabIndex = 11
        '
        'TextBoxServerPassword
        '
        Me.TextBoxServerPassword.Location = New System.Drawing.Point(88, 74)
        Me.TextBoxServerPassword.Name = "TextBoxServerPassword"
        Me.TextBoxServerPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxServerPassword.Size = New System.Drawing.Size(100, 19)
        Me.TextBoxServerPassword.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "PASS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "サーバーIP (*)"
        '
        'TextBoxServerIP
        '
        Me.TextBoxServerIP.Location = New System.Drawing.Point(88, 32)
        Me.TextBoxServerIP.Name = "TextBoxServerIP"
        Me.TextBoxServerIP.Size = New System.Drawing.Size(212, 19)
        Me.TextBoxServerIP.TabIndex = 10
        '
        'ComboBoxNum
        '
        Me.ComboBoxNum.FormattingEnabled = True
        Me.ComboBoxNum.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.ComboBoxNum.Location = New System.Drawing.Point(2, 3)
        Me.ComboBoxNum.Name = "ComboBoxNum"
        Me.ComboBoxNum.Size = New System.Drawing.Size(40, 20)
        Me.ComboBoxNum.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 123)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 12)
        Me.Label8.TabIndex = 78
        Me.Label8.Text = "Ch.Space"
        '
        'TextBoxChSpace
        '
        Me.TextBoxChSpace.Location = New System.Drawing.Point(88, 120)
        Me.TextBoxChSpace.Name = "TextBoxChSpace"
        Me.TextBoxChSpace.Size = New System.Drawing.Size(51, 19)
        Me.TextBoxChSpace.TabIndex = 3
        '
        'TextBoxLog
        '
        Me.TextBoxLog.Location = New System.Drawing.Point(179, 315)
        Me.TextBoxLog.Multiline = True
        Me.TextBoxLog.Name = "TextBoxLog"
        Me.TextBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxLog.Size = New System.Drawing.Size(598, 300)
        Me.TextBoxLog.TabIndex = 79
        '
        'ButtonShowStreams
        '
        Me.ButtonShowStreams.Location = New System.Drawing.Point(14, 75)
        Me.ButtonShowStreams.Name = "ButtonShowStreams"
        Me.ButtonShowStreams.Size = New System.Drawing.Size(151, 23)
        Me.ButtonShowStreams.TabIndex = 81
        Me.ButtonShowStreams.TabStop = False
        Me.ButtonShowStreams.Text = "配信中ストリーム"
        Me.ButtonShowStreams.UseVisualStyleBackColor = True
        '
        'ButtonServerStatus
        '
        Me.ButtonServerStatus.Location = New System.Drawing.Point(14, 27)
        Me.ButtonServerStatus.Name = "ButtonServerStatus"
        Me.ButtonServerStatus.Size = New System.Drawing.Size(151, 23)
        Me.ButtonServerStatus.TabIndex = 83
        Me.ButtonServerStatus.TabStop = False
        Me.ButtonServerStatus.Text = "サーバーステータス"
        Me.ButtonServerStatus.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(14, 241)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(151, 23)
        Me.Button1.TabIndex = 89
        Me.Button1.TabStop = False
        Me.Button1.Text = "mystream%NUM%*.tsの数"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ButtonRunVLC
        '
        Me.ButtonRunVLC.Location = New System.Drawing.Point(337, 163)
        Me.ButtonRunVLC.Name = "ButtonRunVLC"
        Me.ButtonRunVLC.Size = New System.Drawing.Size(69, 21)
        Me.ButtonRunVLC.TabIndex = 96
        Me.ButtonRunVLC.Text = "VLC起動"
        Me.ButtonRunVLC.UseVisualStyleBackColor = True
        '
        'TextBoxVLCURL
        '
        Me.TextBoxVLCURL.Enabled = False
        Me.TextBoxVLCURL.Location = New System.Drawing.Point(88, 165)
        Me.TextBoxVLCURL.Name = "TextBoxVLCURL"
        Me.TextBoxVLCURL.Size = New System.Drawing.Size(245, 19)
        Me.TextBoxVLCURL.TabIndex = 12
        Me.TextBoxVLCURL.TabStop = False
        '
        'TextBoxVLCPATH
        '
        Me.TextBoxVLCPATH.Location = New System.Drawing.Point(88, 144)
        Me.TextBoxVLCPATH.Name = "TextBoxVLCPATH"
        Me.TextBoxVLCPATH.Size = New System.Drawing.Size(295, 19)
        Me.TextBoxVLCPATH.TabIndex = 21
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(14, 147)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 12)
        Me.Label13.TabIndex = 99
        Me.Label13.Text = "VLC.exe"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(14, 168)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 12)
        Me.Label19.TabIndex = 100
        Me.Label19.Text = "VLCソース"
        '
        'LabelStream
        '
        Me.LabelStream.AutoSize = True
        Me.LabelStream.Location = New System.Drawing.Point(4, 29)
        Me.LabelStream.Name = "LabelStream"
        Me.LabelStream.Size = New System.Drawing.Size(47, 12)
        Me.LabelStream.TabIndex = 111
        Me.LabelStream.Text = "配信中："
        '
        'ComboBoxServiceID
        '
        Me.ComboBoxServiceID.FormattingEnabled = True
        Me.ComboBoxServiceID.Location = New System.Drawing.Point(88, 94)
        Me.ComboBoxServiceID.Name = "ComboBoxServiceID"
        Me.ComboBoxServiceID.Size = New System.Drawing.Size(249, 20)
        Me.ComboBoxServiceID.TabIndex = 4
        '
        'ComboBoxBonDriver
        '
        Me.ComboBoxBonDriver.FormattingEnabled = True
        Me.ComboBoxBonDriver.Location = New System.Drawing.Point(48, 3)
        Me.ComboBoxBonDriver.Name = "ComboBoxBonDriver"
        Me.ComboBoxBonDriver.Size = New System.Drawing.Size(175, 20)
        Me.ComboBoxBonDriver.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 97)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 12)
        Me.Label14.TabIndex = 107
        Me.Label14.Text = "ServiceID"
        '
        'ButtonProgram_D
        '
        Me.ButtonProgram_D.Location = New System.Drawing.Point(14, 147)
        Me.ButtonProgram_D.Name = "ButtonProgram_D"
        Me.ButtonProgram_D.Size = New System.Drawing.Size(151, 23)
        Me.ButtonProgram_D.TabIndex = 112
        Me.ButtonProgram_D.TabStop = False
        Me.ButtonProgram_D.Text = "番組表　地デジ"
        Me.ButtonProgram_D.UseVisualStyleBackColor = True
        '
        'ButtonShowResolution
        '
        Me.ButtonShowResolution.Location = New System.Drawing.Point(14, 123)
        Me.ButtonShowResolution.Name = "ButtonShowResolution"
        Me.ButtonShowResolution.Size = New System.Drawing.Size(151, 23)
        Me.ButtonShowResolution.TabIndex = 113
        Me.ButtonShowResolution.TabStop = False
        Me.ButtonShowResolution.Text = "解像度"
        Me.ButtonShowResolution.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(14, 170)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(151, 23)
        Me.Button2.TabIndex = 114
        Me.Button2.TabStop = False
        Me.Button2.Text = "番組表　TvRock"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(14, 193)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(151, 23)
        Me.Button3.TabIndex = 115
        Me.Button3.TabStop = False
        Me.Button3.Text = "番組表　EDCB"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ButtonVideoFiles
        '
        Me.ButtonVideoFiles.Location = New System.Drawing.Point(14, 217)
        Me.ButtonVideoFiles.Name = "ButtonVideoFiles"
        Me.ButtonVideoFiles.Size = New System.Drawing.Size(151, 23)
        Me.ButtonVideoFiles.TabIndex = 116
        Me.ButtonVideoFiles.TabStop = False
        Me.ButtonVideoFiles.Text = "ファイル一覧"
        Me.ButtonVideoFiles.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(14, 99)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(151, 23)
        Me.Button4.TabIndex = 120
        Me.Button4.TabStop = False
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
        Me.Label4.Location = New System.Drawing.Point(16, 239)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 122
        Me.Label4.Text = "成功判断"
        '
        'TextBoxSuccessSecond
        '
        Me.TextBoxSuccessSecond.Location = New System.Drawing.Point(88, 236)
        Me.TextBoxSuccessSecond.Name = "TextBoxSuccessSecond"
        Me.TextBoxSuccessSecond.Size = New System.Drawing.Size(25, 19)
        Me.TextBoxSuccessSecond.TabIndex = 121
        Me.TextBoxSuccessSecond.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(122, 239)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "秒"
        '
        'ButtonVLCapp
        '
        Me.ButtonVLCapp.Location = New System.Drawing.Point(387, 141)
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
        Me.Label10.Location = New System.Drawing.Point(6, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 12)
        Me.Label10.TabIndex = 125
        Me.Label10.Text = "サーバー設定"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 12)
        Me.Label11.TabIndex = 126
        Me.Label11.Text = "ストリーム"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 122)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 12)
        Me.Label12.TabIndex = 127
        Me.Label12.Text = "ローカル設定"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(305, 35)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(97, 12)
        Me.Label17.TabIndex = 128
        Me.Label17.Text = "例：127.0.0.1:40003"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.ItemSize = New System.Drawing.Size(44, 18)
        Me.TabControl1.Location = New System.Drawing.Point(2, 48)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(622, 662)
        Me.TabControl1.TabIndex = 129
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(614, 636)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "　地デジ　"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(614, 655)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "　EDCB　"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(614, 655)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "　TvRock　"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage4.Controls.Add(Me.Label23)
        Me.TabPage4.Controls.Add(Me.ButtonStop_file)
        Me.TabPage4.Controls.Add(Me.ButtonStart_file)
        Me.TabPage4.Controls.Add(Me.ComboBoxVideo)
        Me.TabPage4.Controls.Add(Me.Label5)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(614, 655)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "　ファイル　"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.Location = New System.Drawing.Point(6, 9)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(69, 12)
        Me.Label23.TabIndex = 139
        Me.Label23.Text = "ファイル再生"
        '
        'ButtonStop_file
        '
        Me.ButtonStop_file.Location = New System.Drawing.Point(192, 216)
        Me.ButtonStop_file.Name = "ButtonStop_file"
        Me.ButtonStop_file.Size = New System.Drawing.Size(46, 23)
        Me.ButtonStop_file.TabIndex = 134
        Me.ButtonStop_file.TabStop = False
        Me.ButtonStop_file.Text = "切断"
        Me.ButtonStop_file.UseVisualStyleBackColor = True
        '
        'ButtonStart_file
        '
        Me.ButtonStart_file.Location = New System.Drawing.Point(88, 216)
        Me.ButtonStart_file.Name = "ButtonStart_file"
        Me.ButtonStart_file.Size = New System.Drawing.Size(98, 23)
        Me.ButtonStart_file.TabIndex = 133
        Me.ButtonStart_file.TabStop = False
        Me.ButtonStart_file.Text = "接続"
        Me.ButtonStart_file.UseVisualStyleBackColor = True
        '
        'ComboBoxVideo
        '
        Me.ComboBoxVideo.FormattingEnabled = True
        Me.ComboBoxVideo.Location = New System.Drawing.Point(88, 94)
        Me.ComboBoxVideo.Name = "ComboBoxVideo"
        Me.ComboBoxVideo.Size = New System.Drawing.Size(311, 20)
        Me.ComboBoxVideo.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 12)
        Me.Label5.TabIndex = 119
        Me.Label5.Text = "ファイル再生"
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage5.Controls.Add(Me.Label11)
        Me.TabPage5.Controls.Add(Me.ButtonStop)
        Me.TabPage5.Controls.Add(Me.Label14)
        Me.TabPage5.Controls.Add(Me.ButtonStart)
        Me.TabPage5.Controls.Add(Me.Label8)
        Me.TabPage5.Controls.Add(Me.TextBoxChSpace)
        Me.TabPage5.Controls.Add(Me.ComboBoxServiceID)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(614, 655)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "　手動　"
        '
        'ButtonStop
        '
        Me.ButtonStop.Location = New System.Drawing.Point(192, 216)
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(46, 23)
        Me.ButtonStop.TabIndex = 9
        Me.ButtonStop.TabStop = False
        Me.ButtonStop.Text = "切断"
        Me.ButtonStop.UseVisualStyleBackColor = True
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(88, 216)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(98, 23)
        Me.ButtonStart.TabIndex = 8
        Me.ButtonStart.TabStop = False
        Me.ButtonStart.Text = "接続"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage6.Controls.Add(Me.Label18)
        Me.TabPage6.Controls.Add(Me.Label17)
        Me.TabPage6.Controls.Add(Me.TextBoxServerUsername)
        Me.TabPage6.Controls.Add(Me.TextBoxVLCPATH)
        Me.TabPage6.Controls.Add(Me.Label6)
        Me.TabPage6.Controls.Add(Me.Label12)
        Me.TabPage6.Controls.Add(Me.Label4)
        Me.TabPage6.Controls.Add(Me.TextBoxSuccessSecond)
        Me.TabPage6.Controls.Add(Me.TextBoxVLCURL)
        Me.TabPage6.Controls.Add(Me.Label13)
        Me.TabPage6.Controls.Add(Me.ButtonRunVLC)
        Me.TabPage6.Controls.Add(Me.TextBoxServerPassword)
        Me.TabPage6.Controls.Add(Me.Label10)
        Me.TabPage6.Controls.Add(Me.Label19)
        Me.TabPage6.Controls.Add(Me.Label3)
        Me.TabPage6.Controls.Add(Me.TextBoxServerIP)
        Me.TabPage6.Controls.Add(Me.Label2)
        Me.TabPage6.Controls.Add(Me.Label1)
        Me.TabPage6.Controls.Add(Me.ButtonVLCapp)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(614, 655)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "　設定　"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(6, 214)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 12)
        Me.Label18.TabIndex = 129
        Me.Label18.Text = "配信成功判断"
        '
        'TabPage7
        '
        Me.TabPage7.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage7.Controls.Add(Me.Label21)
        Me.TabPage7.Controls.Add(Me.ButtonShowStreams)
        Me.TabPage7.Controls.Add(Me.Button4)
        Me.TabPage7.Controls.Add(Me.ButtonServerStatus)
        Me.TabPage7.Controls.Add(Me.Button1)
        Me.TabPage7.Controls.Add(Me.Button3)
        Me.TabPage7.Controls.Add(Me.ButtonProgram_D)
        Me.TabPage7.Controls.Add(Me.ButtonShowResolution)
        Me.TabPage7.Controls.Add(Me.Button2)
        Me.TabPage7.Controls.Add(Me.ButtonShowChannels)
        Me.TabPage7.Controls.Add(Me.ButtonVideoFiles)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(614, 655)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "サーバー"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 9)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(57, 12)
        Me.Label21.TabIndex = 130
        Me.Label21.Text = "情報表示"
        '
        'ButtonShowChannels
        '
        Me.ButtonShowChannels.Location = New System.Drawing.Point(14, 51)
        Me.ButtonShowChannels.Name = "ButtonShowChannels"
        Me.ButtonShowChannels.Size = New System.Drawing.Size(151, 23)
        Me.ButtonShowChannels.TabIndex = 80
        Me.ButtonShowChannels.TabStop = False
        Me.ButtonShowChannels.Text = "BonDriver＆チャンネル一覧"
        Me.ButtonShowChannels.UseVisualStyleBackColor = True
        '
        'ComboBoxResolution
        '
        Me.ComboBoxResolution.FormattingEnabled = True
        Me.ComboBoxResolution.Location = New System.Drawing.Point(229, 3)
        Me.ComboBoxResolution.Name = "ComboBoxResolution"
        Me.ComboBoxResolution.Size = New System.Drawing.Size(78, 20)
        Me.ComboBoxResolution.TabIndex = 6
        '
        'ComboBoxNHKMODE
        '
        Me.ComboBoxNHKMODE.FormattingEnabled = True
        Me.ComboBoxNHKMODE.Items.AddRange(New Object() {"0 主･副", "1 主", "2 副", "9 VLC", "11 主", "12 副"})
        Me.ComboBoxNHKMODE.Location = New System.Drawing.Point(347, 3)
        Me.ComboBoxNHKMODE.Name = "ComboBoxNHKMODE"
        Me.ComboBoxNHKMODE.Size = New System.Drawing.Size(68, 20)
        Me.ComboBoxNHKMODE.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(317, 6)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(28, 12)
        Me.Label16.TabIndex = 72
        Me.Label16.Text = "NHK"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Column2"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 400
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ColumnHeadersVisible = False
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.DataGridView1.Location = New System.Drawing.Point(166, 554)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.Size = New System.Drawing.Size(611, 156)
        Me.DataGridView1.TabIndex = 130
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 709)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ComboBoxNum)
        Me.Controls.Add(Me.ComboBoxResolution)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TextBoxLog)
        Me.Controls.Add(Me.LabelStream)
        Me.Controls.Add(Me.ComboBoxBonDriver)
        Me.Controls.Add(Me.ComboBoxNHKMODE)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "TvRemoteViewer_VB_Client"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxServerUsername As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxServerPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxServerIP As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxNum As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBoxChSpace As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxLog As System.Windows.Forms.TextBox
    Friend WithEvents ButtonShowStreams As System.Windows.Forms.Button
    Friend WithEvents ButtonServerStatus As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ButtonRunVLC As System.Windows.Forms.Button
    Friend WithEvents TextBoxVLCURL As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxVLCPATH As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Private WithEvents LabelStream As System.Windows.Forms.Label
    Friend WithEvents ComboBoxServiceID As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxBonDriver As System.Windows.Forms.ComboBox
    Private WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ButtonProgram_D As System.Windows.Forms.Button
    Friend WithEvents ButtonShowResolution As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ButtonVideoFiles As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSuccessSecond As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ButtonVLCapp As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ButtonStop_file As System.Windows.Forms.Button
    Friend WithEvents ButtonStart_file As System.Windows.Forms.Button
    Friend WithEvents ComboBoxVideo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxResolution As System.Windows.Forms.ComboBox
    Private WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ButtonStop As System.Windows.Forms.Button
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents ComboBoxNHKMODE As System.Windows.Forms.ComboBox
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents ButtonShowChannels As System.Windows.Forms.Button

End Class
