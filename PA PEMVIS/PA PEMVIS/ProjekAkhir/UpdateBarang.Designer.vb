<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateBarang
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gbjenishewan = New System.Windows.Forms.GroupBox()
        Me.cbKelinci = New System.Windows.Forms.CheckBox()
        Me.cbAnjing = New System.Windows.Forms.CheckBox()
        Me.cbKucing = New System.Windows.Forms.CheckBox()
        Me.cbHamster = New System.Windows.Forms.CheckBox()
        Me.cbExp = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbstatus = New System.Windows.Forms.GroupBox()
        Me.rbready = New System.Windows.Forms.RadioButton()
        Me.rbpo = New System.Windows.Forms.RadioButton()
        Me.txtharga = New System.Windows.Forms.TextBox()
        Me.txtjumlahstok = New System.Windows.Forms.TextBox()
        Me.cbjenisbarang = New System.Windows.Forms.ComboBox()
        Me.txtnama = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnsubmit = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gbjenishewan.SuspendLayout()
        Me.gbstatus.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbjenishewan
        '
        Me.gbjenishewan.Controls.Add(Me.cbKelinci)
        Me.gbjenishewan.Controls.Add(Me.cbAnjing)
        Me.gbjenishewan.Controls.Add(Me.cbKucing)
        Me.gbjenishewan.Controls.Add(Me.cbHamster)
        Me.gbjenishewan.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbjenishewan.ForeColor = System.Drawing.Color.SaddleBrown
        Me.gbjenishewan.Location = New System.Drawing.Point(63, 233)
        Me.gbjenishewan.Name = "gbjenishewan"
        Me.gbjenishewan.Size = New System.Drawing.Size(505, 102)
        Me.gbjenishewan.TabIndex = 95
        Me.gbjenishewan.TabStop = False
        Me.gbjenishewan.Text = "Jenis Hewan"
        '
        'cbKelinci
        '
        Me.cbKelinci.AutoSize = True
        Me.cbKelinci.Location = New System.Drawing.Point(215, 65)
        Me.cbKelinci.Name = "cbKelinci"
        Me.cbKelinci.Size = New System.Drawing.Size(90, 29)
        Me.cbKelinci.TabIndex = 3
        Me.cbKelinci.Text = "Kelinci"
        Me.cbKelinci.UseVisualStyleBackColor = True
        '
        'cbAnjing
        '
        Me.cbAnjing.AutoSize = True
        Me.cbAnjing.Location = New System.Drawing.Point(216, 30)
        Me.cbAnjing.Name = "cbAnjing"
        Me.cbAnjing.Size = New System.Drawing.Size(89, 29)
        Me.cbAnjing.TabIndex = 2
        Me.cbAnjing.Text = "Anjing"
        Me.cbAnjing.UseVisualStyleBackColor = True
        '
        'cbKucing
        '
        Me.cbKucing.AutoSize = True
        Me.cbKucing.Location = New System.Drawing.Point(50, 65)
        Me.cbKucing.Name = "cbKucing"
        Me.cbKucing.Size = New System.Drawing.Size(93, 29)
        Me.cbKucing.TabIndex = 1
        Me.cbKucing.Text = "Kucing"
        Me.cbKucing.UseVisualStyleBackColor = True
        '
        'cbHamster
        '
        Me.cbHamster.AutoSize = True
        Me.cbHamster.Location = New System.Drawing.Point(50, 30)
        Me.cbHamster.Name = "cbHamster"
        Me.cbHamster.Size = New System.Drawing.Size(106, 29)
        Me.cbHamster.TabIndex = 0
        Me.cbHamster.Text = "Hamster"
        Me.cbHamster.UseVisualStyleBackColor = True
        '
        'cbExp
        '
        Me.cbExp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbExp.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbExp.ForeColor = System.Drawing.Color.SaddleBrown
        Me.cbExp.FormattingEnabled = True
        Me.cbExp.Items.AddRange(New Object() {"-", "2025", "2026", "2027", "2028", "2029", "2030"})
        Me.cbExp.Location = New System.Drawing.Point(279, 510)
        Me.cbExp.Name = "cbExp"
        Me.cbExp.Size = New System.Drawing.Size(289, 33)
        Me.cbExp.TabIndex = 97
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Label4.Location = New System.Drawing.Point(70, 510)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 25)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "Tahun Exp"
        '
        'gbstatus
        '
        Me.gbstatus.Controls.Add(Me.rbready)
        Me.gbstatus.Controls.Add(Me.rbpo)
        Me.gbstatus.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbstatus.ForeColor = System.Drawing.Color.SaddleBrown
        Me.gbstatus.Location = New System.Drawing.Point(63, 426)
        Me.gbstatus.Name = "gbstatus"
        Me.gbstatus.Size = New System.Drawing.Size(505, 71)
        Me.gbstatus.TabIndex = 94
        Me.gbstatus.TabStop = False
        Me.gbstatus.Text = "Status Barang"
        '
        'rbready
        '
        Me.rbready.AutoSize = True
        Me.rbready.Location = New System.Drawing.Point(50, 31)
        Me.rbready.Name = "rbready"
        Me.rbready.Size = New System.Drawing.Size(87, 29)
        Me.rbready.TabIndex = 12
        Me.rbready.TabStop = True
        Me.rbready.Text = "Ready"
        Me.rbready.UseVisualStyleBackColor = True
        '
        'rbpo
        '
        Me.rbpo.AutoSize = True
        Me.rbpo.Location = New System.Drawing.Point(215, 31)
        Me.rbpo.Name = "rbpo"
        Me.rbpo.Size = New System.Drawing.Size(116, 29)
        Me.rbpo.TabIndex = 11
        Me.rbpo.TabStop = True
        Me.rbpo.Text = "Pre Order"
        Me.rbpo.UseVisualStyleBackColor = True
        '
        'txtharga
        '
        Me.txtharga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtharga.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtharga.ForeColor = System.Drawing.Color.SaddleBrown
        Me.txtharga.Location = New System.Drawing.Point(279, 384)
        Me.txtharga.Name = "txtharga"
        Me.txtharga.Size = New System.Drawing.Size(289, 31)
        Me.txtharga.TabIndex = 93
        '
        'txtjumlahstok
        '
        Me.txtjumlahstok.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtjumlahstok.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtjumlahstok.ForeColor = System.Drawing.Color.SaddleBrown
        Me.txtjumlahstok.Location = New System.Drawing.Point(279, 339)
        Me.txtjumlahstok.Name = "txtjumlahstok"
        Me.txtjumlahstok.Size = New System.Drawing.Size(289, 31)
        Me.txtjumlahstok.TabIndex = 92
        '
        'cbjenisbarang
        '
        Me.cbjenisbarang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbjenisbarang.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbjenisbarang.ForeColor = System.Drawing.Color.SaddleBrown
        Me.cbjenisbarang.FormattingEnabled = True
        Me.cbjenisbarang.Items.AddRange(New Object() {"Umum", "Aksesoris", "Makanan", "Suplemen", "Mainan"})
        Me.cbjenisbarang.Location = New System.Drawing.Point(279, 192)
        Me.cbjenisbarang.Name = "cbjenisbarang"
        Me.cbjenisbarang.Size = New System.Drawing.Size(289, 33)
        Me.cbjenisbarang.TabIndex = 91
        '
        'txtnama
        '
        Me.txtnama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnama.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnama.ForeColor = System.Drawing.Color.SaddleBrown
        Me.txtnama.Location = New System.Drawing.Point(279, 149)
        Me.txtnama.Name = "txtnama"
        Me.txtnama.Size = New System.Drawing.Size(289, 31)
        Me.txtnama.TabIndex = 89
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Label10.Location = New System.Drawing.Point(70, 109)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(239, 25)
        Me.Label10.TabIndex = 88
        Me.Label10.Text = "Kode Barang yang di ubah :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Label6.Location = New System.Drawing.Point(70, 384)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 25)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "Harga Barang"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Label5.Location = New System.Drawing.Point(70, 339)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 25)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "Jumlah Stok"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Label3.Location = New System.Drawing.Point(70, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 25)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "Jenis Barang"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Label2.Location = New System.Drawing.Point(70, 149)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 25)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "Nama Barang"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Tan
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(-61, -5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(952, 88)
        Me.Panel1.TabIndex = 98
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Malgun Gothic", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(140, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(447, 38)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Update Barang Mozaa Pet Shop"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label7.Location = New System.Drawing.Point(573, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 64)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "🐈‍⬛"
        '
        'btnsubmit
        '
        Me.btnsubmit.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsubmit.ForeColor = System.Drawing.Color.SaddleBrown
        Me.btnsubmit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnsubmit.Location = New System.Drawing.Point(209, 565)
        Me.btnsubmit.Name = "btnsubmit"
        Me.btnsubmit.Size = New System.Drawing.Size(168, 45)
        Me.btnsubmit.TabIndex = 100
        Me.btnsubmit.Text = "Update"
        Me.btnsubmit.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.SaddleBrown
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnClose.Location = New System.Drawing.Point(400, 565)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(168, 45)
        Me.btnClose.TabIndex = 99
        Me.btnClose.Text = "Cancel"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Label8.Location = New System.Drawing.Point(303, 109)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 25)
        Me.Label8.TabIndex = 101
        Me.Label8.Text = "Label8"
        '
        'UpdateBarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(656, 634)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnsubmit)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gbjenishewan)
        Me.Controls.Add(Me.cbExp)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.gbstatus)
        Me.Controls.Add(Me.txtharga)
        Me.Controls.Add(Me.txtjumlahstok)
        Me.Controls.Add(Me.cbjenisbarang)
        Me.Controls.Add(Me.txtnama)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Name = "UpdateBarang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Update Barang"
        Me.gbjenishewan.ResumeLayout(False)
        Me.gbjenishewan.PerformLayout()
        Me.gbstatus.ResumeLayout(False)
        Me.gbstatus.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbjenishewan As System.Windows.Forms.GroupBox
    Friend WithEvents cbKelinci As System.Windows.Forms.CheckBox
    Friend WithEvents cbAnjing As System.Windows.Forms.CheckBox
    Friend WithEvents cbKucing As System.Windows.Forms.CheckBox
    Friend WithEvents cbHamster As System.Windows.Forms.CheckBox
    Friend WithEvents cbExp As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbstatus As System.Windows.Forms.GroupBox
    Friend WithEvents rbready As System.Windows.Forms.RadioButton
    Friend WithEvents rbpo As System.Windows.Forms.RadioButton
    Friend WithEvents txtharga As System.Windows.Forms.TextBox
    Friend WithEvents txtjumlahstok As System.Windows.Forms.TextBox
    Friend WithEvents cbjenisbarang As System.Windows.Forms.ComboBox
    Friend WithEvents txtnama As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnsubmit As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
