Public Class sshtunnel
    Private Const strPLINKEXE As String = "PLINK.EXE"
    Private strUsername As String
    Private strPassword As String
    Private strHostIP As String
    Private iTunnelIP As Integer
    Private strPlinkPath As String
    Private PLinkProcess As Process

    Private Function RunPLINKProcess()
        PLinkProcess = New Process()
        PLinkProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        PLinkProcess = Process.Start("PLINK.EXE", "-N -ssh -l biomederdev -pw dSaCKK5Zn5vAm6vwBu6k -L 3306:127.0.0.1:3306 -batch 62.141.36.187")
        Return 0
    End Function


End Class
