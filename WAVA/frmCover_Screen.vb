Imports System.Speech.Synthesis
Public Class frmCover_Screen
    Public Shared voice As New SpeechSynthesizer

    Private Sub btnWebBrowser_Click(sender As Object, e As EventArgs) Handles btnWebBrowser.Click

        If (MessageBox.Show("Do you really want to proceed to web browser?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            frmPassword.Show() 'Displays password form or window
        End If
    End Sub

    Private Sub btnWebBrowser_MouseHover(sender As Object, e As EventArgs) Handles btnWebBrowser.MouseHover
        voice.SpeakAsync(btnWebBrowser.ButtonText) 'Reads text on the 'proceed to web browser' button 
    End Sub

    Private Sub btnExit_MouseHover(sender As Object, e As EventArgs) Handles btnExit.MouseHover
        voice.SpeakAsync(btnExit.ButtonText) 'Reads text on the exit button 
    End Sub

    Public Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        If (MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK) Then
            Close() 'closes the application
        End If
    End Sub

    Private Sub frmCover_Screen_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.ExitThread()
    End Sub
End Class
