Public Class frmAbout
    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtName.Text = Application.ProductName.ToString
        txtVersion.Text = Application.ProductVersion.ToString
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Close()
    End Sub

    Private Sub frmAbout_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If frmMain.Visible = False Then
            Close()
        End If
    End Sub
End Class