TvRemoteViewer_VB_client 0.06

TvRemoteViewer_VB 0.72�ȍ~�ɑΉ�

���T�[�o�[���ݒ�
�E�T�[�o�[����TvRemoteViewer_VB.ini�̈ȉ��̍��ڂ�ݒ肵�Ă�������
HTTPSTREAM_App=1�@�Ȃ�VLC�ɂ��z�M
HTTPSTREAM_App=2�@�Ȃ�ffmpeg�ɂ��z�M�i�����j
�E�z�M�I�v�V������
HLS_option_ffmpeg_http.txt
����ǂݍ��܂ꂽ���̂��g�p����܂�

���N���C�A���g���ݒ�
�������̗D��BonDriver��ݒ肵�����ꍇ��TvRemoteViewer_VB_Client.ini���C�����Ă�������

������N����
�ݒ�^�u�ŃT�[�o�[IP��ݒ肵����ɍċN�����Ă�������

������
�E�����炭VLC���̕s����Ǝv���̂ł������̂Ƃ���VLC�X�g���[���̕��������z�M�͂ł��Ȃ��Ǝv���܂�
�Effmpeg�̃I�v�V�����������̂����ϊ��ł̎����J�n�Ɏ��s���邱�Ƃ�����܂�


������
	0.01	�T���v���N���C�A���g
	0.02	�܂Ƃ��ȃN���C�A���g
	0.03	VLC�I�����@�̕ύX
		�`�����l���ύX����x�ɔz�M���~���Ă����o�O���C��
	0.04	�ԑg�\����̎����ɑΉ�
		���[�U�[�C���^�[�t�F�[�X�̏C��
		�D��BonDriver�̎w���ini�ɒǉ�
	0.05	ffmpeg��HTTP�X�g���[���ɑΉ�
	0.06	�t�H�[�����NHKMODE�I���{�b�N�X��z�u
		�D��BonDriver���ݒ肳��Ă���ƃt�H�[����̑I���𖳎����Ă��܂��o�O���C��









WEB�C���^�[�t�F�[�X�ꗗ
�u�T�[�o�[�v�^�u�Q�Ƃ̂���
�T�[�o�[��WEB�A�N�Z�X���邱�ƂŊe�햽�߁����擾���ł��܂��B

    '�z�M�X�^�[�g
    Public Function WI_START_STREAM(ByVal num As Integer, ByVal BonDriver As String, ByVal ServiceID As Integer, ByVal chspace As Integer, ByVal resolution As String, ByVal NHKMODE As Integer, ByVal stream_mode As Integer, ByVal VideoFilename As String) As String

    '�z�M��~
    Public Function WI_STOP_STREAM(ByVal num As Integer) As String

    '�����ǈꗗ
    Public Function WI_GET_CHANNELS() As String

    '�z�M�����X�g�擾
    Public Function WI_GET_LIVE_STREAM() As String

   '�T�[�o�[�ݒ���擾
    Public Function WI_GET_TVRV_STATUS() As String

    '�ł���������ts�t�@�C�����iHTTP�X�g���[���ł͏��0���Ԃ��Ă��܂��j
    Public Function WI_GET_TSFILE_COUNT(ByVal num As Integer) As String

    '�𑜓x�擾
    Public Function WI_GET_RESOLUTION() As String

    '�t�@�C���ꗗ
    Public Function WI_GET_VIDEOFILES() As String

    '�ċN�����Ă���X�g���[���ԍ����擾
    Public Function WI_GET_ERROR_STREAM() As String

    '�ԑg�\�擾
    Public Function WI_GET_PROGRAM_D() As String
    Public Function WI_GET_PROGRAM_TVROCK() As String
    Public Function WI_GET_PROGRAM_EDCB() As String
