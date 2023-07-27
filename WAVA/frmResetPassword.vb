Public Class frmResetPassword
    Private Data As String
    Private Sub txtBoxVisible()
        'This block shows the textbox and label for old password
        lblOldPassword.Visible = True
        txtOldPassword.Visible = True
    End Sub

    Public Sub ConfirmPassword()

        'Taking the user's input via an inputbox, then the input is then 
        'assigned to the variable 'Data' 
        Data = InputBox("Confirm Password")
        'Checking the validity of the user's input
        If Data <> My.Settings.Password Then
            MessageBox.Show("The password you just entered does not match the new password", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        My.Settings.Save() 'Saves the password
        frmMain.Show()
    End Sub
    Private Sub frmChangePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If IsNothing(frmPassword.password) Then
            'This block hides the textbox and label for old password
            lblOldPassword.Visible = False
            txtOldPassword.Visible = False
        Else
            txtBoxVisible() 'Calls the txtBoxVisible subprocedure
        End If
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        frmPassword.PasswordValidation(Data) 'Calls the password validation function 
        ' of frmPassword form

        If txtOldPassword.Text = My.Settings.Password Then
            My.Settings.Password = txtNewPassword.Text 'Assigns the content of the
            'New password textbox to Password in the application configuration file
        Else
            MessageBox.Show("Old password is required in order to set a new password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If txtOldPassword.Visible = False Then
            My.Settings.Password = txtNewPassword.Text 'Assigns the content of the
            'New password textbox to Password in the application configuration file
        End If
        My.Settings.Save() 'Saves the password
        ConfirmPassword() 'Calls the ConfirmPassword subprocedure
        Close() 'Closes the form
        frmPassword.Close() 'Closes frmPassword form
    End Sub
End Class