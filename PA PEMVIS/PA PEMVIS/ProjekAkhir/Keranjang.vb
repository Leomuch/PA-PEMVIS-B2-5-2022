Imports MySql.Data.MySqlClient

Public Class Keranjang
    Public connStr As String = "server=localhost;userid=root;password=;database=dbmozaaapetshop"
    Private selectedItemId As Integer = -1
    Dim selectedRowIndex As Integer = -1

    Private Sub ReloadGridView()
        Try
            Dim idRegis As Integer = GetIdRegisByCurrentUsername()

            Using CONN As New MySqlConnection(connStr)
                CONN.Open()
                Dim query As String = "SELECT * FROM tbcart WHERE idregis = @idRegis"
                Using CMD As New MySqlCommand(query, CONN)
                    CMD.Parameters.AddWithValue("@idRegis", idRegis)
                    Using DA As New MySqlDataAdapter(CMD)
                        Dim DT As New DataTable()
                        DA.Fill(DT)
                        DataGridView1.Columns.Clear()
                        DataGridView1.DataSource = DT
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Keranjang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReloadGridView()
        koneksi()
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        AddHandler PrintDocument1.PrintPage, AddressOf Me.PrintDocument1_PrintPage
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
    End Sub

    Private Sub DeleteItem(itemId As Integer)
        Try
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If
            Dim query As String = "DELETE FROM tbcart WHERE idCart = @itemId"
            CMD = New MySqlCommand(query, CONN)
            CMD.Parameters.AddWithValue("@itemId", itemId)
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim cellValue As Object = DataGridView1.SelectedRows(0).Cells(0).Value
            If Not IsDBNull(cellValue) Then
                selectedItemId = Convert.ToInt32(cellValue)
            Else
                selectedItemId = -1
            End If
        Else
            selectedItemId = -1
        End If
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If selectedItemId <> -1 Then
            Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data dengan kode barang " & selectedItemId & " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                DeleteItem(selectedItemId)
                MsgBox("Data dengan kode barang " & selectedItemId & " telah dihapus.")
                ReloadGridView()
            End If
        Else
            MsgBox("Pilih kode barang yang ingin dihapus terlebih dahulu.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Me.Hide()
        DashboardUser.Show()
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

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ReloadGridView()
        If e.RowIndex >= 0 Then
            ' Menyimpan indeks kolom dari sel yang dipilih
            selectedRowIndex = e.RowIndex
        End If
    End Sub

    Private listPesanan As New List(Of String())

    Private orderTimestamp As DateTime

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

    Private Function UpdateStok(kodeBarang As String, jumlah As Integer) As Boolean
        Dim query As String = "UPDATE tbpetshop SET JumlahStok = JumlahStok - @jumlah WHERE KodeBarang = @KodeBarang AND JumlahStok >= @jumlah"

        Using connection As New MySqlConnection(connStr)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@jumlah", jumlah)
                command.Parameters.AddWithValue("@KodeBarang", kodeBarang)

                Try
                    connection.Open()
                    Dim affectedRows As Integer = command.ExecuteNonQuery()
                    Return affectedRows > 0
                Catch ex As Exception
                    MessageBox.Show("Error while updating stock: " & ex.Message)
                    Return False
                End Try
            End Using
        End Using
    End Function

    Private Function SimpanPesanan(kodeBarang As String, namaBarang As String, jumlah As Integer, totalHarga As Decimal) As Boolean
        Dim query As String = "INSERT INTO tborder (NamaPemesan, KodeBarang, NamaBarang, JumlahBarang, TotalHarga) VALUES (@NamaPemesan, @KodeBarang, @NamaBarang, @JumlahBarang, @TotalHarga)"

        Using connection As New MySqlConnection(connStr)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@NamaPemesan", DashboardUser.CurrentUsername)
                command.Parameters.AddWithValue("@KodeBarang", kodeBarang)
                command.Parameters.AddWithValue("@NamaBarang", namaBarang)
                command.Parameters.AddWithValue("@JumlahBarang", jumlah)
                command.Parameters.AddWithValue("@TotalHarga", totalHarga)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    Return True
                Catch ex As Exception
                    MessageBox.Show("Error while saving order: " & ex.Message)
                    Return False
                End Try
            End Using
        End Using
    End Function

    Private Sub btnOrder_Click(sender As Object, e As EventArgs) Handles btnOrder.Click
        ' Menyimpan timestamp pemesanan
        orderTimestamp = DateTime.Now

        ' Memilih semua baris pada DataGridView
        DataGridView1.SelectAll()

        For Each row As DataGridViewRow In DataGridView1.SelectedRows
            Dim kodeBarang As String = row.Cells("KodeBarang").Value.ToString()
            Dim namaBarang As String = row.Cells("NamaBarang").Value.ToString()
            Dim jumlah As Integer = Convert.ToInt32(row.Cells("JumlahBarang").Value)
            Dim hargaSatuan As Decimal = GetHarga(kodeBarang)
            Dim totalHarga As Decimal = hargaSatuan * jumlah

            If UpdateStok(kodeBarang, jumlah) Then
                If SimpanPesanan(kodeBarang, namaBarang, jumlah, totalHarga) Then
                    listPesanan.Add(New String() {kodeBarang, namaBarang, jumlah.ToString(), hargaSatuan.ToString(), totalHarga.ToString()})
                    DeleteItem(Convert.ToInt32(row.Cells("idCart").Value))
                Else
                    UndoUpdateStok(kodeBarang, jumlah)
                End If
            Else
                MessageBox.Show("Gagal memperbarui stok untuk barang: " & namaBarang)
            End If
        Next

        ReloadGridView()
        PrintPreviewDialog1.ShowDialog()
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
                    Return 0
                End Try
            End Using
        End Using
    End Function

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim fontReg As New Font("Courier New", 15)
        Dim fontJudul As New Font("Courier New", 15, FontStyle.Bold)
        Dim fontHeader As New Font("Courier New", 24, FontStyle.Bold)
        Dim brushBlack As New SolidBrush(Color.Black)
        Dim brushHeader As New SolidBrush(Color.Brown)
        Dim pen As New Pen(Color.Black)

        ' Mengatur posisi awal pencetakan
        Dim startX As Integer = 20
        Dim startY As Integer = 60
        Dim offset As Integer = 20
        Dim largerOffset As Integer = 40
        Dim lineLength As Integer = 800

        ' Membuat string untuk dicetak
        Dim header As String = "STRUK PEMBELIAN MOZAA PET SHOP"
        Dim pemesan As String = "Nama Pemesan: " & DashboardUser.CurrentUsername
        Dim tanggalPemesanan As String = "Tanggal Pemesanan: " & orderTimestamp.ToString("dd/MM/yyyy HH:mm")
        Dim itemHeader As String = String.Format("{0,-20}{1,-10}{2,-15}{3,-20}", "Nama Barang", "Jumlah", "Harga Satuan", "Harga Total")

        ' Mengambil data dari listPesanan
        Dim items As New List(Of String)
        Dim totalHarga As Decimal = 0

        For Each pesanan As String() In listPesanan
            Dim namaBarang As String = pesanan(1)
            Dim jumlah As Integer = Convert.ToInt32(pesanan(2))
            Dim hargaBarang As Decimal = Convert.ToDecimal(pesanan(3))
            Dim itemTotal As Decimal = Convert.ToDecimal(pesanan(4))
            items.Add(String.Format("{0,-20}{1,-10}{2,-15:N2}{3,-20:N2}", namaBarang, jumlah, hargaBarang, itemTotal))
            totalHarga += itemTotal
        Next

        Dim footer As String = "Total Harga: " & totalHarga.ToString("N2")
        Dim thankYou As String = "Terima kasih atas kunjungan Anda!"

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

        ' Mencetak informasi pemesan
        e.Graphics.DrawString(pemesan, fontJudul, brushBlack, startX, startY)
        startY += largerOffset

        ' Mencetak header detail barang
        e.Graphics.DrawString(itemHeader, fontJudul, brushBlack, startX, startY)
        startY += largerOffset

        ' Mencetak detail barang
        For Each item As String In items
            e.Graphics.DrawString(item, fontReg, brushBlack, startX, startY)
            startY += 30
        Next

        ' Mencetak garis pembatas
        e.Graphics.DrawLine(pen, startX, startY, startX + lineLength, startY)
        startY += largerOffset

        ' Mencetak footer
        e.Graphics.DrawString(footer, fontReg, brushBlack, startX, startY)
        startY += 50

        ' Mencetak terima kasih
        e.Graphics.DrawString(thankYou, fontReg, brushBlack, startX, startY)
    End Sub
End Class