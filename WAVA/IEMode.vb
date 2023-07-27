Namespace BrowserIE
    Partial Friend Class IEMode
        Public Event Startup(sender As Object, e As EventArgs)
        Public Event Shutdown(sender As Object, e As EventArgs)

        Private Const BrowserKeyPath As String = "\SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER-EMULATION"
        Private Sub CreateBrowserKey(Optional ByVal IgnoreIDocDirective As Boolean = False)
            Dim BaseKey As String = Microsoft.Win32.Registry.CurrentUser.ToString
            Dim value As Int32
            Dim MyAppName As String = My.Application.Info.AssemblyName & ".exe"

            Select Case (New WebBrowser).Version.Major
                Case 8
                    If IgnoreIDocDirective Then
                        value = 8888
                    Else
                        value = 8000
                    End If
                Case 9
                    If IgnoreIDocDirective Then
                        value = 9999
                    Else
                        value = 9000
                    End If
                Case 10
                    If IgnoreIDocDirective Then
                        value = 10001
                    Else
                        value = 10000
                    End If
                Case 11
                    If IgnoreIDocDirective Then
                        value = 11001
                    Else
                        value = 11000
                    End If
                Case Else
                    Exit Sub
            End Select

            Microsoft.Win32.Registry.SetValue(Microsoft.Win32.Registry.CurrentUser.ToString & BrowserKeyPath,
                                              Process.GetCurrentProcess.ProcessName & ".exe", value,
                                              Microsoft.Win32.RegistryValueKind.DWord)
        End Sub

        Private Sub ClearBrowserKey()
            Dim key As Microsoft.Win32.RegistryKey
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(BrowserKeyPath.Substring(1), True)
            key.DeleteValue(Process.GetCurrentProcess.ProcessName & ".exe", False)
        End Sub

        Private Sub StartMyApp(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            CreateBrowserKey()
        End Sub

        Private Sub ShutdownMyApp(sender As Object, e As System.EventArgs) Handles Me.Shutdown
            ClearBrowserKey()
        End Sub
    End Class
End Namespace