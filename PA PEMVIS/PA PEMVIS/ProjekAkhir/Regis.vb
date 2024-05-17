Imports MySql.Data.MySqlClient

Public Class Regis
    Private Sub txtpw1_TextChanged(sender As Object, e As EventArgs) Handles txtpw1.TextChanged
        ' Jika checkbox cbshowpass tidak dicentang, maka mask password dengan bintang
        If Not cbshow.Checked Then
            txtpw1.PasswordChar = "*"
        End If
    End Sub

    Private Sub txtpw2_TextChanged(sender As Object, e As EventArgs) Handles txtpw2.TextChanged
        ' Jika checkbox cbshowpass tidak dicentang, maka mask password dengan bintang
        If Not cbshow.Checked Then
            txtpw2.PasswordChar = "*"
        End If
    End Sub

    Private Sub cbshowpass_CheckedChanged(sender As Object, e As EventArgs) Handles cbshow.CheckedChanged
        ' Jika checkbox cbshowpass dicentang, maka tampilkan password
        If cbshow.Checked Then
            txtpw1.PasswordChar = ""
            txtpw2.PasswordChar = ""
        Else
            txtpw1.PasswordChar = "*"
            txtpw2.PasswordChar = "*"
        End If
    End Sub

    Private Function IsUsernameExist(username As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM tbregis WHERE username = @username"
        CMD = New MySqlCommand(query, CONN)
        CMD.Parameters.AddWithValue("@username", username)

        Try
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If
            Dim count As Integer = Convert.ToInt32(CMD.ExecuteScalar())
            Return count > 0
        Catch ex As Exception
            MessageBox.Show("Error while validating username: " & ex.Message)
            Clear()
            Return False
        Finally
            CONN.Close()
        End Try
    End Function


    Private Function IsEmailExist(email As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM tbregis WHERE email = @email"
        CMD = New MySqlCommand(query, CONN)
        CMD.Parameters.AddWithValue("@email", email)
        Try
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If
            Dim count As Integer = Convert.ToInt32(CMD.ExecuteScalar())
            Return count > 0
        Catch ex As Exception
            MessageBox.Show("Error while validating email: " & ex.Message)
            Clear()
            Return False
        Finally
            CONN.Close()
        End Try
    End Function

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        If String.IsNullOrWhiteSpace(txtuname.Text) OrElse String.IsNullOrWhiteSpace(txtemail.Text) OrElse String.IsNullOrWhiteSpace(txtpw1.Text) OrElse String.IsNullOrWhiteSpace(txtpw2.Text) Then
            MessageBox.Show("Semua kolom harus diisi. Silakan lengkapi form registrasi.")
            Return
        End If

        Dim username As String = txtuname.Text
        Dim email As String = txtemail.Text
        Dim alamat As String = txtalamat.Text
        Dim password As String = txtpw1.Text

        If txtpw1.Text <> txtpw2.Text Then
            MessageBox.Show("Password harus sama.")
            Return
        End If

        If IsUsernameExist(username) Then
            MessageBox.Show("Username sudah digunakan. Silakan pilih username lain.")
            Clear()
            Return
        End If

        If IsEmailExist(email) Then
            MessageBox.Show("Email sudah digunakan. Silakan gunakan email lain.")
            Clear()
            Return
        End If

        Dim success As Boolean = SaveToDatabase(username, email, alamat, password)
        If success Then
            MessageBox.Show("Berhasil Menyimpan Data.")
            Login.Show()
            Me.Hide()
        Else
            MessageBox.Show("Gagal menyimpan informasi registrasi.")
            Clear()
        End If
    End Sub

    Private Function SaveToDatabase(username As String, email As String, alamat As String, password As String) As Boolean
        Try
            Dim query As String = "INSERT INTO tbregis (username, email, alamat, password) VALUES (@username, @email, @alamat, @password)"
            CMD = New MySqlCommand(query, CONN)
            CMD.Parameters.AddWithValue("@username", username)
            CMD.Parameters.AddWithValue("@email", email)
            CMD.Parameters.AddWithValue("@alamat", alamat)
            CMD.Parameters.AddWithValue("@password", password)
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If
            CMD.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MessageBox.Show("Error while saving registration information: " & ex.Message)
            Return False
        Finally
            CONN.Close()
        End Try
    End Function


    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Login.Show()
        Me.Hide()
    End Sub

    Sub Clear()
        txtuname.Clear()
        txtemail.Clear()
        txtalamat.Clear()
        txtpw1.Clear()
        txtpw2.Clear()
    End Sub

    Function ValidateLogin(username As String, password As String) As Boolean
        Throw New NotImplementedException
    End Function

    Private Sub Regis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        txtuname.Focus()
    End Sub
End Class
