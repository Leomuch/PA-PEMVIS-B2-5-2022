Imports MySql.Data.MySqlClient

Public Class PendataanBarang
    Dim selectedJenisHewan As String = ""

    Private Sub cbAnjing_CheckedChanged(sender As Object, e As EventArgs) Handles cbAnjing.CheckedChanged
        If cbAnjing.Checked Then
            selectedJenisHewan = AddSelectedHewan("Anjing")
        Else
            selectedJenisHewan = RemoveSelectedHewan("Anjing")
        End If
    End Sub

    Private Sub cbKucing_CheckedChanged(sender As Object, e As EventArgs) Handles cbKucing.CheckedChanged
        If cbKucing.Checked Then
            selectedJenisHewan = AddSelectedHewan("Kucing")
        Else
            selectedJenisHewan = RemoveSelectedHewan("Kucing")
        End If
    End Sub

    Private Sub cbKelinci_CheckedChanged(sender As Object, e As EventArgs) Handles cbKelinci.CheckedChanged
        If cbKelinci.Checked Then
            selectedJenisHewan = AddSelectedHewan("Kelinci")
        Else
            selectedJenisHewan = RemoveSelectedHewan("Kelinci")
        End If
    End Sub

    Private Sub cbHamster_CheckedChanged(sender As Object, e As EventArgs) Handles cbHamster.CheckedChanged
        If cbHamster.Checked Then
            selectedJenisHewan = AddSelectedHewan("Hamster")
        Else
            selectedJenisHewan = RemoveSelectedHewan("Hamster")
        End If
    End Sub

    Private Function AddSelectedHewan(hewan As String) As String
        If Not selectedJenisHewan.Contains(hewan) Then
            If String.IsNullOrEmpty(selectedJenisHewan) Then
                Return hewan
            Else
                Return selectedJenisHewan & ", " & hewan
            End If
        Else
            Return selectedJenisHewan
        End If
    End Function

    Private Function RemoveSelectedHewan(hewan As String) As String
        Return selectedJenisHewan.Replace(hewan & ", ", "").Replace(", " & hewan, "").Replace(hewan, "")
    End Function

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        If String.IsNullOrWhiteSpace(txtkode.Text) OrElse String.IsNullOrWhiteSpace(txtnama.Text) OrElse
            cbjenisbarang.SelectedItem Is Nothing OrElse String.IsNullOrWhiteSpace(selectedJenisHewan) OrElse
            String.IsNullOrWhiteSpace(txtjumlahstok.Text) OrElse String.IsNullOrWhiteSpace(txtharga.Text) OrElse
            cbExp.SelectedItem Is Nothing OrElse
            (Not rbready.Checked AndAlso Not rbpo.Checked) Then
            MessageBox.Show("Harap lengkapi semua data", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ClearInputFields()
            txtkode.Focus()
            Return
        End If

        If Not IsNumeric(txtkode.Text) OrElse Not IsNumeric(txtjumlahstok.Text) OrElse Not IsNumeric(txtharga.Text) Then
            MessageBox.Show("Inputan untuk Kode Barang, Jumlah Stok, dan Harga Barang Harus berupa Angka!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ClearInputFields()
            txtkode.Focus()
            Return
        End If

        If IsDataExists(txtkode.Text, txtnama.Text, cbjenisbarang.SelectedItem.ToString(), selectedJenisHewan.TrimEnd(", "), If(rbready.Checked, "Ready", "PO")) Then
            MessageBox.Show("Data sudah tersedia", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ClearInputFields()
            txtkode.Focus()
            Return
        End If
        Try
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If
            Dim query As String = "INSERT INTO tbpetshop (KodeBarang, NamaBarang, JenisBarang, JenisHewan, JumlahStok, Harga, Status, TahunExp) VALUES (@KodeBarang, @NamaBarang, @JenisBarang, @JenisHewan, @JumlahStok, @Harga, @Status, @TahunExp)"
            CMD = New MySqlCommand(query, CONN)
            CMD.Parameters.AddWithValue("@KodeBarang", txtkode.Text)
            CMD.Parameters.AddWithValue("@namabarang", txtnama.Text)
            CMD.Parameters.AddWithValue("@jenisbarang", cbjenisbarang.SelectedItem.ToString())
            CMD.Parameters.AddWithValue("@jenishewan", selectedJenisHewan.TrimEnd(", "))
            CMD.Parameters.AddWithValue("@jumlahstok", Convert.ToInt32(txtjumlahstok.Text))
            CMD.Parameters.AddWithValue("@harga", Convert.ToDecimal(txtharga.Text))
            CMD.Parameters.AddWithValue("@status", If(rbready.Checked, "Ready", "Pre Order"))
            CMD.Parameters.AddWithValue("@tahunexp", cbExp.SelectedItem.ToString)
            CMD.ExecuteNonQuery()
            MessageBox.Show("Data berhasil disimpan ke database.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearInputFields()
            txtkode.Focus()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsDataExists(kodeBarang As String, namaBarang As String, jenisBarang As String, jenisHewan As String, status As String) As Boolean
        Try
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If
            Dim query As String = "SELECT COUNT(*) FROM tbpetshop WHERE KodeBarang = @KodeBarang AND NamaBarang = @NamaBarang AND JenisBarang = @JenisBarang AND JenisHewan = @JenisHewan AND Status = @Status"
            CMD = New MySqlCommand(query, CONN)
            cmd.Parameters.AddWithValue("@KodeBarang", kodeBarang)
            CMD.Parameters.AddWithValue("@NamaBarang", namaBarang)
            CMD.Parameters.AddWithValue("@JenisBarang", jenisBarang)
            CMD.Parameters.AddWithValue("@JenisHewan", jenisHewan)
            CMD.Parameters.AddWithValue("@Status", status)
            Dim count As Integer = Convert.ToInt32(CMD.ExecuteScalar())
            Return count > 0
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub ClearInputFields()
        txtkode.Clear()
        txtnama.Clear()
        cbjenisbarang.SelectedIndex = -1
        ClearCheckBoxes()
        txtjumlahstok.Clear()
        txtharga.Clear()
        rbready.Checked = False
        rbpo.Checked = False
        cbExp.SelectedIndex = -1
    End Sub

    Private Sub ClearCheckBoxes()
        cbAnjing.Checked = False
        cbKucing.Checked = False
        cbKelinci.Checked = False
        cbHamster.Checked = False
        selectedJenisHewan = ""
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub PendataanBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        txtkode.Focus()
    End Sub
End Class
