Imports System.Speech.Synthesis
Public Class frmHistory

    Public Shared tooltipMessage, msg As String
    Public Shared voice As New SpeechSynthesizer

    Public Sub Mouse_Hover()
        Try
            voice.SpeakAsync(tooltipMessage)
        Catch ex As Exception
            msg = ex.Message
        End Try
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        My.Settings.History.Clear()
        ListBox1.Items.Clear()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        My.Settings.History.Remove(ListBox1.SelectedItem)
        ListBox1.Items.Remove(ListBox1.SelectedItem)
    End Sub
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        frmMain.WebBrowser1.Navigate(ListBox1.SelectedItem)
        frmMain.txtAddressBar.Focus()
        frmMain.txtAddressBar.Text = ListBox1.SelectedItem
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        btnLoad.PerformClick()
    End Sub

    Private Sub btnRemove_MouseHover(sender As Object, e As EventArgs) Handles btnRemove.MouseHover
        tooltipMessage = "Remove"
        Mouse_Hover()
    End Sub

    Private Sub btnClear_MouseHover(sender As Object, e As EventArgs) Handles btnClear.MouseHover
        tooltipMessage = "Clear"
        Mouse_Hover()
    End Sub

    Private Sub btnLoad_MouseHover(sender As Object, e As EventArgs) Handles btnLoad.MouseHover
        tooltipMessage = "Navigate to webpage"
        Mouse_Hover()
    End Sub
End Class