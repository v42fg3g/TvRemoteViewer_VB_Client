
TvRemoteViewer_VB 0.66�ȍ~�ɑΉ�

�T�[�o�[IP��ݒ肵�čċN�����Ă�������


















WEB�C���^�[�t�F�[�X�ꗗ

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

    '�ł���������ts�t�@�C����
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
