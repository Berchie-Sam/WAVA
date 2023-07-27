Public Class frmSetPassword
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSetPassword.Click
        My.Settings.Password = txtPassword.Text 'Assigns the content of the
        'New password textbox to Password in the application configuration file

        My.Settings.Save() 'Saves the password
        frmResetPassword.ConfirmPassword() 'Calls the ConfirmPassword subprocedure
        frmMain.Show()
        Close() 'Closes the form
    End Sub

    Private Sub frmSetPassword_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        frmPassword.Close()
    End Sub
End Class