Imports MySql.Data.MySqlClient

Public Class ModifikasiBarang
    Private connStr As String = "server=localhost;userid=root;password=;database=dbmozaaapetshop"
    Private selectedItemId As Integer = -1

    Private Sub ReloadGridView()
        Using conn As New MySqlConnection(connStr)
            Try
                conn.Open()
                Dim sql As String = "SELECT * FROM tbpetshop"
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

    Public Sub SearchItemByCode(itemCode As String)
        If Not String.IsNullOrEmpty(itemCode) Then
            Using conn As New MySqlConnection(connStr)
                Try
                    conn.Open()
                    Dim sql As String = "SELECT * FROM tbpetshop WHERE KodeBarang LIKE @itemCode"
                    Dim dt As New DataTable
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@itemCode", "%" & itemCode & "%")
                        Dim adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                    DataGridView1.Columns.Clear()
                    DataGridView1.DataSource = dt

                Catch ex As Exception
                    MsgBox("Error: " & ex.Message)
                End Try
            End Using
        Else
            ReloadGridView()
        End If
    End Sub

    Private Sub Form2_Shown(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        btnclose.Focus()
        ReloadGridView()
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        SearchItemByCode(txtsearch.Text)
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If selectedItemId <> -1 Then
            Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data dengan kode barang " & selectedItemId & " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                DeleteItem(selectedItemId)
                MsgBox("Data dengan kode barang " & selectedItemId & " telah dihapus.")
                ReloadGridView()
                txtsearch.Clear()
            End If
        Else
            MsgBox("Pilih kode barang yang ingin dihapus terlebih dahulu.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub datagridview1_cellclick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.rowindex >= 0 Then
            Dim row As datagridviewrow = datagridview1.rows(e.rowindex)
            selecteditemid = convert.toint32(row.cells("kodebarang").value)
        End If
    End Sub

    Private Sub DeleteItem(itemId As Integer)
        Using conn As New MySqlConnection(connStr)
            Try
                conn.Open()
                Dim sql As String = "DELETE FROM tbpetshop WHERE KodeBarang = @itemId"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@itemId", itemId)
                    cmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        If selectedItemId <> -1 Then
            Dim form3 As New UpdateBarang(selectedItemId)
            form3.ShowDialog()
            ReloadGridView()
            txtsearch.Clear()
        Else
            MsgBox("Pilih kode barang yang ingin diubah terlebih dahulu.", MsgBoxStyle.Exclamation)
        End If
    End Sub

End Class