Imports MySql.Data.MySqlClient
Public Class ListPesanan
    Private connStr As String = "server=localhost;userid=root;password=;database=dbmozaaapetshop"

    Private Sub ReloadGridView()
        Using conn As New MySqlConnection(connStr)
            Try
                conn.Open()
                Dim sql As String = "SELECT * FROM tbOrder"
                Dim dt As New DataTable
                Using cmd As New MySqlCommand(sql, conn)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
                DataGridView1.Columns.Clear()
                DataGridView1.DataSource = dt

            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        ReloadGridView()
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

End Class