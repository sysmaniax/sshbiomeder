Public Class Form1
    Private PLinkProcess As Process
    Private objStartInfo As System.Diagnostics.ProcessStartInfo
    Private bIsRunning As Boolean
    Private strButtonConnect = "&Connect"
    Private strButtonDisconnect = "&Disconnect"

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = My.Settings.SettingFormName
        tbUsername.Text = My.Settings.SettingUsername
        tbHostNameIP.Text = My.Settings.SettingHostIP
        tbTunelIP.Text = My.Settings.SettingTunnelPort
        bIsRunning = False
        Button1.Text = strButtonConnect
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Dim objStartInfo As System.Diagnostics.ProcessStartInfo
        If My.Settings.SettingPLinkPath = "" Or Len(My.Settings.SettingPLinkPath) < 8 Then
            MessageBox.Show("Please specify location of PLINK.EXE", Application.ProductName, MessageBoxButtons.OK)
        End If
        ' strShell = 
        ' Shell("PLINK.EXE -N -ssh -l biomederde -pw dSaCKK5Zn5vAm6vwBu6k -L 3306:127.0.0.1:3306 -batch 62.141.36.187", AppWinStyle.Hide, True, 1500)


        If bIsRunning = False Then
            PLinkProcess = New Process()
            objStartInfo = New System.Diagnostics.ProcessStartInfo
            objStartInfo.FileName = "PLINK.EXE"
            objStartInfo.Arguments = "-N -ssh -l biomederdev -pw dSaCKK5Zn5vAm6vwBu6k -L 3306:127.0.0.1:3306 -batch 62.141.36.187"
            objStartInfo.WindowStyle = ProcessWindowStyle.Hidden
            PLinkProcess = Process.Start(objStartInfo)
            Button1.Enabled = False
            System.Threading.Thread.CurrentThread.Sleep(5000)
            Button1.Enabled = True
            If PLinkProcess.HasExited = False Then
                bIsRunning = True
                Button1.Text = strButtonDisconnect
            Else
                MessageBox.Show("Cannot establish connection. Please check your login details!")
            End If
            Exit Sub ' Exit Sub when isRunning was set to true
        End If

        If bIsRunning = True Then
            PLinkProcess.Kill()
            bIsRunning = False
            Button1.Text = strButtonConnect
        End If


        ' Me.WindowState = FormWindowState.Minimized
        ' PLinkProcess.WaitForExit()
        'If PLinkProcess.HasExited = True Then
        'Button1.Enabled = True
        'Me.WindowState = FormWindowState.Normal
        'MessageBox.Show("Exited!")
        ' End If



    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Form_Close(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.SettingFormName = Me.Text
        My.Settings.SettingUsername = tbUsername.Text
        My.Settings.SettingHostIP = tbHostNameIP.Text
        My.Settings.SettingTunnelPort = tbTunelIP.Text
        ' If Not PLinkProcess Is Nothing Then
        ' PLinkProcess.Kill()
        ' End If
    End Sub
End Class
