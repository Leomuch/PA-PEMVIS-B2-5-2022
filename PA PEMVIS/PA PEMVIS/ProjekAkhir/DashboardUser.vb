Imports MySql.Data.MySqlClient

Public Class DashboardUser
    Public connStr As String = "server=localhost;userid=root;password=;database=dbmozaaapetshop"
    Public Shared CurrentUsername As String
    Dim selectedRowIndex As Integer = -1

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

    Private Sub user()
        CurrentUsername = Login.txtuname.Text
        Label6.Text = CurrentUsername
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

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        SearchItemByCode(txtsearch.Text)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            selectedRowIndex = e.RowIndex
            txtKodeBarang.Text = DataGridView1.Rows(selectedRowIndex).Cells("KodeBarang").Value.ToString()
        End If
    End Sub

    Private Function GetHarga(kodeBarang As String) As Decimal
        Dim query As String = "SELECT Harga FROM tbpetshop WHERE KodeBarang = @KodeBarang"

        Using connection As New MySqlConnection(connStr)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@KodeBarang", kodeBarang)

                Try
                    connection.Open()
                    Dim harga As Decimal = Convert.ToDecimal(command.ExecuteScalar())
                    Return harga
                Catch ex As Exception
                    MessageBox.Show("Error while retrieving harga barang: " & ex.Message)
                    clear()
                    Return 0
                End Try
            End Using
        End Using
    End Function

    Private Sub UndoUpdateStok(kodeBarang As String, jumlah As Integer)
        Dim query As String = "UPDATE tbpetshop SET JumlahStok = JumlahStok + @jumlah WHERE KodeBarang = @KodeBarang"

        Using connection As New MySqlConnection(connStr)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@jumlah", jumlah)
                command.Parameters.AddWithValue("@KodeBarang", kodeBarang)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("Error while undoing stock update: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private orderTimestamp As DateTime

    Private Sub btnOrder_Click(sender As Object, e As EventArgs) Handles btnOrder.Click
        Dim kodeBarang As String = txtKodeBarang.Text
        Dim jumlah As Integer

        ' Menyimpan timestamp pemesanan
        orderTimestamp = DateTime.Now

        If String.IsNullOrWhiteSpace(kodeBarang) OrElse String.IsNullOrWhiteSpace(txtJumlah.Text) Then
            MessageBox.Show("Kode barang dan jumlah harus diisi.")
            Return
        End If

        If Not Integer.TryParse(txtJumlah.Text, jumlah) OrElse txtJumlah.Text < 1 Then
            MessageBox.Show("Jumlah harus berupa angka dan Minimal 1.")
            clear()
            Return
        End If

        If Not IsKodeBarangValid(kodeBarang) Then
            MessageBox.Show("Kode barang tidak valid.")
            clear()
            Return
        End If

        If UpdateStok(kodeBarang, jumlah) Then
            If SimpanPesanan(kodeBarang, jumlah) Then
                Me.PrintPreviewDialog1.ShowDialog()
                MessageBox.Show("Pesanan Berhasil")
                clear()
            Else
                MessageBox.Show("Pesanan Anda Gagal")
                UndoUpdateStok(kodeBarang, jumlah)
                clear()
            End If
        Else
            MessageBox.Show("Pesanan Anda Gagal")
            clear()
        End If

    End Sub

    Private Function IsKodeBarangValid(kodeBarang As String) As Boolean
        Dim connStr As String = "server=localhost;userid=root;password=;database=dbmozaaapetshop"
        Dim query As String = "SELECT COUNT(*) FROM tbpetshop WHERE KodeBarang = @KodeBarang"

        Using connection As New MySqlConnection(connStr)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@KodeBarang", kodeBarang)

                Try
                    connection.Open()
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                    Return count > 0
                Catch ex As Exception
                    MessageBox.Show("Error while validating kode barang: " & ex.Message)
                    clear()
                    Return False
                End Try
            End Using
        End Using
    End Function

    Private Function UpdateStok(kodeBarang As String, jumlah As Integer) As Boolean
        Dim connStr As String = "server=localhost;userid=root;password=;database=dbmozaaapetshop"
        Dim query As String = "UPDATE tbpetshop SET JumlahStok = JumlahStok - @jumlah WHERE KodeBarang = @KodeBarang"

        Using connection As New MySqlConnection(connStr)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@jumlah", jumlah)
                command.Parameters.AddWithValue("@KodeBarang", kodeBarang)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    Return True
                Catch ex As Exception
                    MessageBox.Show("Error while updating stok: " & ex.Message)
                    clear()
                    Return False
                End Try
            End Using
        End Using
    End Function

    Private Function SimpanPesanan(kodeBarang As String, jumlah As Integer) As Boolean
        Dim query As String = "INSERT INTO tbOrder (NamaPemesan, KodeBarang, NamaBarang, JumlahBarang, TotalHarga) VALUES (@NamaPemesan, @KodeBarang, @NamaBarang, @JumlahBarang, @TotalHarga)"

        Using connection As New MySqlConnection(connStr)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@NamaPemesan", CurrentUsername)
                command.Parameters.AddWithValue("@KodeBarang", kodeBarang)
                command.Parameters.AddWithValue("@NamaBarang", GetNamaBarang(kodeBarang))
                command.Parameters.AddWithValue("@JumlahBarang", jumlah)
                command.Parameters.AddWithValue("@TotalHarga", GetHarga(kodeBarang) * jumlah)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    Return True
                Catch ex As Exception
                    MessageBox.Show("Error while saving order: " & ex.Message)
                    clear()
                    Return False
                End Try
            End Using
        End Using
    End Function

    Private Function GetNamaBarang(kodeBarang As String) As String
        Dim connStr As String = "server=localhost;userid=root;password=;database=dbmozaaapetshop"
        Dim query As String = "SELECT NamaBarang FROM tbpetshop WHERE KodeBarang = @KodeBarang"

        Using connection As New MySqlConnection(connStr)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@KodeBarang", kodeBarang)

                Try
                    connection.Open()
                    Dim namaBarang As String = Convert.ToString(command.ExecuteScalar())
                    Return If(String.IsNullOrEmpty(namaBarang), "Barang tidak ditemukan", namaBarang)
                    clear()
                Catch ex As Exception
                    Return "Error: " & ex.Message
                    clear()
                End Try
            End Using
        End Using
    End Function


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        Login.Show()
    End Sub

    Sub clear()
        txtsearch.Clear()
        txtKodeBarang.Clear()
        txtJumlah.Clear()
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReloadGridView()
        koneksi()
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        AddHandler PrintDocument1.PrintPage, AddressOf Me.PrintDocument1_PrintPage
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        txtKodeBarang.Focus()
        user()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        Keranjang.Show()
    End Sub

    Private Sub btnCart_Click(sender As Object, e As EventArgs) Handles btnCart.Click
        Dim kodeBarang As String = txtKodeBarang.Text
        Dim jumlah As Integer
        If Not Integer.TryParse(txtJumlah.Text, jumlah) OrElse txtJumlah.Text < 1 Then
            MessageBox.Show("Jumlah harus berupa angka dan Minimal 1.")
            clear()
            Return
        End If

        Dim idRegis As Integer = GetIdRegisByCurrentUsername()
        If idRegis = 0 Then
            MessageBox.Show("ID Regis tidak ditemukan.")
            Return
        End If

        Dim query As String = "INSERT INTO tbCart (idRegis, KodeBarang, NamaBarang, JumlahBarang, TotalHarga) VALUES (@idRegis, @KodeBarang, @NamaBarang, @JumlahBarang, @TotalHarga)"

        Using connection As New MySqlConnection(connStr)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@idRegis", idRegis)
                command.Parameters.AddWithValue("@KodeBarang", kodeBarang)
                command.Parameters.AddWithValue("@NamaBarang", GetNamaBarang(kodeBarang))
                command.Parameters.AddWithValue("@JumlahBarang", jumlah)
                command.Parameters.AddWithValue("@TotalHarga", GetHarga(kodeBarang) * jumlah)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    MessageBox.Show("Pesanan berhasil ditambahkan ke keranjang.")
                    clear()
                Catch ex As Exception
                    MessageBox.Show("Error while saving order: " & ex.Message)
                    clear()
                End Try
            End Using
        End Using
    End Sub


    Private Function GetIdRegisByCurrentUsername() As Integer
        Dim idRegis As Integer = 0
        Dim query As String = "SELECT idRegis FROM tbRegis WHERE username = @username"

        Using connection As New MySqlConnection(connStr)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@username", DashboardUser.CurrentUsername)

                Try
                    connection.Open()
                    idRegis = Convert.ToInt32(command.ExecuteScalar())
                Catch ex As Exception
                    MessageBox.Show("Error while retrieving idRegis: " & ex.Message)
                End Try
            End Using
        End Using

        Return idRegis
    End Function

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim kodeBarang As String = txtKodeBarang.Text
        Dim jumlah As Integer = Integer.Parse(txtJumlah.Text) ' Pastikan jumlah diambil dari input yang benar
        Dim fontReg As New Font("Courier New", 15)
        Dim fontJudul As New Font("Courier New", 15, FontStyle.Bold)
        Dim fontHeader As New Font("Courier New", 30, FontStyle.Bold)
        Dim brushBlack As New SolidBrush(Color.Black)
        Dim brushHeader As New SolidBrush(Color.Brown) ' Mengubah warna tulisan header
        Dim pen As New Pen(Color.Black)

        ' Ambil data dari database
        Dim namaBarang As String = GetNamaBarang(kodeBarang)
        Dim hargaBarang As Decimal = GetHarga(kodeBarang)
        Dim totalHarga As Decimal = hargaBarang * jumlah

        ' Mengatur posisi awal pencetakan
        Dim startX As Integer = 20
        Dim startY As Integer = 60
        Dim offset As Integer = 20
        Dim largerOffset As Integer = 40 ' Offset lebih besar untuk jarak antar tulisan pemesan
        Dim lineLength As Integer = 800

        ' Membuat string untuk dicetak
        Dim header As String = "STRUK PEMBELIAN MOZAA PET SHOP"
        Dim pemesan As String = "Nama Pemesan: " & CurrentUsername
        Dim tanggalPemesanan As String = "Tanggal Pemesanan: " & orderTimestamp.ToString("dd/MM/yyyy HH:mm")
        Dim itemHeader As String = String.Format("{0,-25}{1,10}{2,20}", "Nama Barang", "Jumlah", "Harga")
        Dim itemDetail As String = String.Format("{0,-25}{1,10}{2,20:N2}", namaBarang, jumlah, totalHarga)
        Dim footer As String = "Terima kasih atas kunjungan Anda!"

        ' Mencetak header
        e.Graphics.DrawString(header, fontHeader, brushHeader, startX, startY)
        startY += 70

        ' Mencetak tanggal pemesanan
        e.Graphics.DrawString(tanggalPemesanan, fontJudul, brushBlack, startX, startY)
        startY += 30

        ' Menambah offset tambahan antara header dan garis
        startY += 20

        ' Mencetak garis pembatas
        e.Graphics.DrawLine(pen, startX, startY, startX + lineLength, startY)
        startY += 30

        ' Menambah offset tambahan untuk pemesan
        startY += 5

        ' Mencetak informasi pemesan
        e.Graphics.DrawString(pemesan, fontJudul, brushBlack, startX, startY)
        startY += largerOffset

        ' Mencetak header detail barang
        e.Graphics.DrawString(itemHeader, fontJudul, brushBlack, startX, startY)
        startY += largerOffset

        ' Mencetak detail barang
        e.Graphics.DrawString(itemDetail, fontReg, brushBlack, startX, startY)
        startY += largerOffset

        ' Mencetak garis pembatas
        e.Graphics.DrawLine(pen, startX, startY, startX + lineLength, startY)
        startY += 30

        ' Mencetak footer
        e.Graphics.DrawString(footer, fontReg, brushBlack, startX, startY)
    End Sub

End Class