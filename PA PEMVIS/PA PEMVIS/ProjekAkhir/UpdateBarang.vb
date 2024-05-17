Imports MySql.Data.MySqlClient

Public Class UpdateBarang
    Dim selectedJenisHewan As String = ""
    Private selectedItemId As Integer

    Public Sub New(itemId As Integer)
        InitializeComponent()
        selectedItemId = itemId
        Label8.Text = itemId.ToString()
    End Sub

    Private Sub cbAnjing_CheckedChanged(sender As Object, e As EventArgs) Handles cbAnjing.CheckedChanged
        If cbAnjing.Checked Then
            UpdateSelectedJenisHewan("Anjing")
        Else
            RemoveSelectedHewan("Anjing")
        End If
    End Sub

    Private Sub cbKucing_CheckedChanged(sender As Object, e As EventArgs) Handles cbKucing.CheckedChanged
        If cbKucing.Checked Then
            UpdateSelectedJenisHewan("Kucing")
        Else
            RemoveSelectedHewan("Kucing")
        End If
    End Sub

    Private Sub cbKelinci_CheckedChanged(sender As Object, e As EventArgs) Handles cbKelinci.CheckedChanged
        If cbKelinci.Checked Then
            UpdateSelectedJenisHewan("Kelinci")
        Else
            RemoveSelectedHewan("Kelinci")
        End If
    End Sub

    Private Sub cbHamster_CheckedChanged(sender As Object, e As EventArgs) Handles cbHamster.CheckedChanged
        If cbHamster.Checked Then
            UpdateSelectedJenisHewan("Hamster")
        Else
            RemoveSelectedHewan("Hamster")
        End If
    End Sub

    Private Sub UpdateSelectedJenisHewan(hewan As String)
        If Not selectedJenisHewan.Contains(hewan) Then
            If selectedJenisHewan <> "" Then
                selectedJenisHewan &= ", "
            End If
            selectedJenisHewan &= hewan
        End If
    End Sub

    Private Sub RemoveSelectedHewan(hewan As String)
        selectedJenisHewan = selectedJenisHewan.Replace(hewan, "").Replace(", , ", ", ").Trim(", ")
    End Sub

    Private Sub UpdateItem(itemId As Integer)
        If String.IsNullOrWhiteSpace(txtnama.Text) OrElse
            cbjenisbarang.SelectedItem Is Nothing OrElse String.IsNullOrWhiteSpace(selectedJenisHewan) OrElse
            String.IsNullOrWhiteSpace(txtjumlahstok.Text) OrElse String.IsNullOrWhiteSpace(txtharga.Text) OrElse
            cbExp.SelectedItem Is Nothing OrElse
            (Not rbready.Checked AndAlso Not rbpo.Checked) Then
            MessageBox.Show("Harap lengkapi semua data", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ClearInputFields()
            txtnama.Focus()
            Return
        End If

        If Not IsNumeric(txtjumlahstok.Text) OrElse Not IsNumeric(txtharga.Text) Then
            MessageBox.Show("Inputan untuk Jumlah Stok, dan Harga Barang Harus berupa Angka!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ClearInputFields()
            txtnama.Focus()
            Return
        End If
        Try
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If
            Dim query As String = "UPDATE tbpetshop SET NamaBarang = @NamaBarang, JenisBarang = @JenisBarang, JenisHewan = @JenisHewan, JumlahStok = @JumlahStok, Harga = @Harga, Status = @Status, TahunExp = @TahunExp WHERE KodeBarang = @KodeBarang"
            CMD = New MySqlCommand(query, CONN)
            CMD.Parameters.AddWithValue("@NamaBarang", txtnama.Text)
            CMD.Parameters.AddWithValue("@JenisBarang", cbjenisbarang.SelectedItem.ToString())
            CMD.Parameters.AddWithValue("@JenisHewan", selectedJenisHewan)
            CMD.Parameters.AddWithValue("@JumlahStok", Convert.ToInt32(txtjumlahstok.Text))
            CMD.Parameters.AddWithValue("@Harga", Convert.ToDecimal(txtharga.Text))
            CMD.Parameters.AddWithValue("@Status", If(rbready.Checked, "Ready", "PO"))
            CMD.Parameters.AddWithValue("@TahunExp", cbExp.SelectedItem.ToString)
            CMD.Parameters.AddWithValue("@KodeBarang", itemId)
            CMD.ExecuteNonQuery()
            MessageBox.Show("Data berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsDataExists(namaBarang As String, jenisBarang As String, jenisHewan As String, status As String) As Boolean
        If CONN.State = ConnectionState.Closed Then
            CONN.Open()
        End If
        Dim query As String = "SELECT COUNT(*) FROM tbpetshop WHERE NamaBarang = @NamaBarang AND JenisBarang = @JenisBarang AND JenisHewan = @JenisHewan AND Status = @Status"
        CMD = New MySqlCommand(query, CONN)
        CMD.Parameters.AddWithValue("@NamaBarang", namaBarang)
        CMD.Parameters.AddWithValue("@JenisBarang", jenisBarang)
        CMD.Parameters.AddWithValue("@JenisHewan", jenisHewan)
        CMD.Parameters.AddWithValue("@Status", status)
        Dim count As Integer = Convert.ToInt32(CMD.ExecuteScalar())
        Return count > 0
    End Function

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        UpdateItem(selectedItemId)
        Me.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub UpdateBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        txtnama.Focus()
    End Sub

    Private Sub ClearInputFields()
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
End Class
