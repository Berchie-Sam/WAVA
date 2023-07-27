Imports System.Speech
Imports System.Speech.Synthesis
Public Class frmPassword
    Public password As String

    Private Sub DisableButtons()
        txtPassword.Enabled = False
        btnLogin.Enabled = False
        btnResetPassword.Enabled = False
    End Sub
    Private Sub PasswordAttempts()
        Dim i As Integer = 0
        For i = 0 To 2

        Next i

        If i > 2 Then
            DisableButtons()
            MessageBox.Show("You've completely exhausted the permitted number of attempts. Please, try agin later", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Public Sub PasswordValidation(passwordstring As String)
        Try
            If My.Settings.Password = Nothing Then
                If password.Count > 8 Then
                    MessageBox.Show("Password cannot exceed 8 characters", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf IsNothing(password) = True Then
                    MessageBox.Show("This field cannot be empty", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                Dim number As String = "0" Or "1" Or "2" Or "3" Or "4" Or "5" Or "6" Or "7" Or "8" Or "9"

                If Not (password.Contains(number)) = True Then
                    MessageBox.Show("Password must contain at one least number", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            Dim msg = ex.Message
        End Try
    End Sub

    Private Sub btnResetPassword_Click(sender As Object, e As EventArgs) Handles btnResetPassword.Click
        If (MessageBox.Show("Do you really want to reset password?", "Reset Password", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            frmResetPassword.Show()
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click, MyBase.KeyDown
        password = txtPassword.Text 'Holds the string entered in the password textbox

        PasswordValidation(password) 'Calls password validation function

        'The if block checks whether the entered password is not equal to 
        'the saved password in the configuration file and displays a message if condition evaluates 
        'to true
        'otherwise control moves to the else part 
        If password = My.Settings.Password Then
            frmMain.Show() 'Reveals the main form or web browser window
        Else
            MessageBox.Show("Password is incorrect", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPassword.Clear()
            txtPassword.Focus()
        End If
    End Sub

    Private Sub frmPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        password = My.Settings.Password
        If password = Nothing Then
            If (MessageBox.Show("Password has not been set.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK) Then
                frmSetPassword.Show()
            End If
        End If
    End Sub

    Private Sub frmPassword_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtPassword.Focus()
    End Sub

    Private Sub LoginTimer_Tick(sender As Object, e As EventArgs) Handles LoginTimer.Tick
        pgbPassword.Increment(10) 'Increases the value of pgbPassword by 10
        If txtPassword.Text <> Nothing Then
            If (pgbPassword.Value() < 18000) Then
                DisableButtons()
            Else
                If (pgbPassword.Value() > 18000) And (pgbPassword.Value() < 36000) Or (pgbPassword.Value() > 36000) Then
                    txtPassword.Enabled = True
                    btnLogin.Enabled = True
                    btnResetPassword.Enabled = False
                End If
                Exit Sub
            End If
        End If
    End Sub
End Class