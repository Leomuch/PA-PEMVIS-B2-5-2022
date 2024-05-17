Public Class MenuAdmin
    Private Sub PendataanBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PendataanBarangToolStripMenuItem.Click
        PendataanBarang.Show()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ListBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListBarangToolStripMenuItem.Click
        ModifikasiBarang.Show()
    End Sub

    Private Sub ListPesananToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListPesananToolStripMenuItem.Click
        ListPesanan.Show()
    End Sub

End Class