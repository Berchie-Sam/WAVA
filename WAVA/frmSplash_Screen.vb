Public Class frmSplash_Screen
    Private Sub Spk()
        'declaring variable, SAPI(Speech Application Interface), as an object
        Dim SAPI As Object
        'Initializing SAPI
        SAPI = CreateObject("SAPI.spvoice")

        If (Visible = True) Then
            'Causing SAPI to read the content of labels on form 1
            SAPI.speak("WEB ACCESS FOR VISUALLY-IMPAIRED APPLICATION (WAVA)")
            SAPI.Speak(Label2.Text)
        End If
    End Sub

    Private Sub trWava_Tick(sender As Object, e As EventArgs) Handles trWAVA.Tick
        pgbWava.Increment(1) 'Increases the va value of pgbWava by 1


        If (pgbWava.Value() < 2) Then
            Spk() 'Calls Spk subprocedure
        Else
            Exit Sub
        End If
        frmPassword.Show()
        Close()
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            '  frmCover_Screen.Show()
        Catch ex As Exception
        End Try
    End Sub

End Class


