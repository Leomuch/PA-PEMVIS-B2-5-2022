Imports MySql.Data.MySqlClient

Public Class Login

    Public Function ValidateLogin(username As String, password As String) As Boolean
        Dim query As String = "SELECT idregis FROM tbregis WHERE username = @username AND password = @password"

        CMD = New MySqlCommand(query, CONN)
        CMD.Parameters.AddWithValue("@username", username)
        CMD.Parameters.AddWithValue("@password", password)
        Try
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If
            RD = CMD.ExecuteReader()

            If RD.HasRows Then
                While RD.Read()
                    LoggedUserId = RD.GetInt32(0)
                End While
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show("Error while validating login: " & ex.Message)
            Return False
        Finally
            CONN.Close()
        End Try
    End Function

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If String.IsNullOrWhiteSpace(txtuname.Text) OrElse String.IsNullOrWhiteSpace(txtpw.Text) Then
            MessageBox.Show("Username dan password harus diisi. Silakan coba lagi.")
            Return
        End If

        If ValidateLogin(txtuname.Text, txtpw.Text) Then
            DashboardUser.Show()
            Me.Hide()
            txtuname.Clear()
            txtpw.Clear()
        Else
            If txtuname.Text = "admin" AndAlso txtpw.Text = "admin" Then
                MenuAdmin.Show()
                Me.Hide()
                txtuname.Clear()
                txtpw.Clear()
            Else
                MessageBox.Show("Invalid username or password. Please try again.")
                txtpw.Clear()
                txtuname.Clear()
            End If
        End If
    End Sub

    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        Regis.Show()
        Me.Hide()
        txtuname.Clear()
        txtpw.Clear()
    End Sub

    Private Sub txtpw_TextChanged(sender As Object, e As EventArgs) Handles txtpw.TextChanged
        txtpw.PasswordChar = "*"
    End Sub

    Private Sub cbshow_CheckedChanged(sender As Object, e As EventArgs) Handles cbshow.CheckedChanged
        If cbshow.Checked Then
            txtpw.PasswordChar = ""
        Else
            txtpw.PasswordChar = "*"
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        txtuname.Focus()
        txtuname.Clear()
        txtpw.Clear()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
