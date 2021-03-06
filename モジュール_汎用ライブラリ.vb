﻿Module モジュール_汎用ライブラリ
    Public Function time2unix(ByVal t As DateTime) As Integer
        Dim ut As Integer = DateDiff("s", #1/1/1970#, t)
        ut = ut - (60 * 60 * 9) '日本
        Return ut
    End Function

    Public Function unix2time(ByVal u As Integer) As DateTime
        u = u + (60 * 60 * 9) '日本
        Dim unixTimeStamp As Integer = u
        Dim unixDate As DateTime = (New DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(unixTimeStamp) '.ToLocalTime()
        Return CDate(unixDate.ToShortDateString & " " & unixDate.ToLongTimeString)
    End Function

    '文字列から、文字列と文字列に挟まれた文字列を抽出する。
    Public Function Instr_pickup(ByRef strdat As String, ByVal findstr As String, ByVal endstr As String, ByVal startpos As Integer, Optional ByVal endpos As Integer = 2147483647) As Object
        Dim r As String = ""

        Try
            Dim sp As Integer
            Dim ep As Integer
            sp = strdat.IndexOf(findstr, startpos)
            ep = strdat.IndexOf(endstr, sp + findstr.Length)
            If sp >= 0 And ep > sp And ep <= endpos Then
                r = strdat.Substring(sp + findstr.Length, ep - sp - findstr.Length)
            End If
        Catch ex As Exception
        End Try

        Return r
    End Function

    '余計な改行等を削除
    Public Function trim8(ByVal s As String) As String
        s = Trim(s)
        s = s.Replace(vbTab, "").Replace(vbCrLf, "").Replace("""", "")
        s = Trim(s)
        Return s
    End Function

End Module
