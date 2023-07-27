
Imports System.Speech.Synthesis
Public Class frmFavorites

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
        My.Settings.Favorites.Clear()
        ListBox1.Items.Clear()
        frmMain.txtAddressBar.Items.Clear()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        My.Settings.Favorites.Remove(ListBox1.SelectedItem)
        ListBox1.Items.Remove(ListBox1.SelectedItem)
        frmMain.txtAddressBar.Items.Remove(ListBox1.SelectedItem)
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        frmMain.WebBrowser1.Navigate(ListBox1.SelectedItem)
        frmMain.txtAddressBar.Focus()
        frmMain.txtAddressBar.Text = ListBox1.SelectedItem
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each Item In My.Settings.Favorites
            ListBox1.Items.Add(Item)
        Next
        Me.Visible = False
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        btnSearch_TextChanged(sender, e)
    End Sub

    Private Sub btnSearch_TextChanged(sender As Object, e As EventArgs) Handles btnSearch.TextChanged
        Dim InputData As String = InputBox("Find")

        For x As Integer = 0 To ListBox1.Items.Count - 1
            If ListBox1.Items(x).ToString = InputData Then
                ListBox1.SelectedIndex = x
                voice.SpeakAsync(ListBox1.SelectedItem)
            End If
        Next
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


    Private Sub btnSearch_MouseHover(sender As Object, e As EventArgs) Handles btnSearch.MouseHover
        tooltipMessage = "Search"
        Mouse_Hover()
    End Sub
End Class