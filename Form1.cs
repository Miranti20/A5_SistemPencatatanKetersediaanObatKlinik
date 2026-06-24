using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace ObatKlinikADO
{
    public partial class Form1 : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["KlinikObatKoneksi"]?.ConnectionString ?? @"Data Source=.\MIRANTI;Initial Catalog=KlinikObatDB;Integrated Security=True;TrustServerCertificate=True;";
        SqlConnection con;
        string roleLogin;
        string usernameLogin;

        private BindingSource bindingSource = new BindingSource();
        private DataTable dtObat = new DataTable();

        public Form1(string role, string username = "")
        {
            InitializeComponent();
            this.roleLogin = role;
            this.usernameLogin = username;
            con = new SqlConnection(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = bindingSource;
            dgvObat.DataSource = bindingSource;
            bindingSource.PositionChanged += new EventHandler(bindingSource_PositionChanged);
            TampilkanData();
            BuatGrafikDashboard();

            if (roleLogin == "Pemilik")
            {
                btnTambah.Enabled = false;
                btnHapus.Enabled = false;
                btnUpdate.Enabled = false;
                btnBackup.Enabled = false;
                this.Text = "Sistem Pencatatan Obat Klinik — Mode Monitoring (Pemilik)";
            }
            else
            {
                this.Text = "Sistem Pencatatan Obat Klinik — " + roleLogin;
            }
        }

        void TampilkanData()
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM v_DataObat", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                dtObat.Clear();
                adapter.Fill(dtObat);
                bindingSource.DataSource = dtObat;
                con.Close();

                con.Open();
                SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM Obat", con);
                lblTotal.Text = "Total Jenis Obat: " + cmdCount.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open) con.Close();
                MessageBox.Show("Gagal memuat data:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvObat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvObat.Rows[e.RowIndex];
                txtID.Text = row.Cells["id_obat"].Value?.ToString() ?? "";
                txtNama.Text = row.Cells["nama_obat"].Value?.ToString() ?? "";
                txtJenis.Text = row.Cells["jenis_obat"].Value?.ToString() ?? "";
                txtSatuan.Text = row.Cells["satuan"].Value?.ToString() ?? "";
                txtStok.Text = row.Cells["stok_total"].Value?.ToString() ?? "";
            }
        }

        private void bindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (bindingSource.Current is DataRowView drv)
            {
                txtID.Text = drv["id_obat"]?.ToString() ?? "";
                txtNama.Text = drv["nama_obat"]?.ToString() ?? "";
                txtJenis.Text = drv["jenis_obat"]?.ToString() ?? "";
                txtSatuan.Text = drv["satuan"]?.ToString() ?? "";
                txtStok.Text = drv["stok_total"]?.ToString() ?? "";
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == "" || txtNama.Text.Trim() == "")
            {
                MessageBox.Show("ID dan Nama Obat wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtStok.Text, out int stok) || stok < 0)
            {
                MessageBox.Show("Stok harus berupa angka dan tidak boleh negatif!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_TambahObat", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_obat", txtID.Text.Trim());
                cmd.Parameters.AddWithValue("@nama_obat", txtNama.Text.Trim());
                cmd.Parameters.AddWithValue("@jenis_obat", txtJenis.Text.Trim());
                cmd.Parameters.AddWithValue("@satuan", txtSatuan.Text.Trim());
                cmd.Parameters.AddWithValue("@stok_total", stok);
                cmd.Parameters.AddWithValue("@id_akun", GetIdAkun());
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data obat berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TampilkanData();
                BuatGrafikDashboard();
                BersihkanInput();
            }
            catch (SqlException ex)
            {
                if (con.State == ConnectionState.Open) con.Close();
                MessageBox.Show(ex.Message, "Gagal Tambah", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == "")
            {
                MessageBox.Show("Pilih data dari tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtStok.Text, out int stok) || stok < 0)
            {
                MessageBox.Show("Stok harus berupa angka dan tidak boleh negatif!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Yakin ingin mengubah data obat ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_UpdateObat", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_obat", txtID.Text.Trim());
                    cmd.Parameters.AddWithValue("@nama_obat", txtNama.Text.Trim());
                    cmd.Parameters.AddWithValue("@jenis_obat", txtJenis.Text.Trim());
                    cmd.Parameters.AddWithValue("@satuan", txtSatuan.Text.Trim());
                    cmd.Parameters.AddWithValue("@stok_total", stok);
                    cmd.Parameters.AddWithValue("@id_akun", GetIdAkun());
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TampilkanData();
                    BuatGrafikDashboard();
                    BersihkanInput();
                }
                catch (SqlException ex)
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    MessageBox.Show(ex.Message, "Gagal Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == "")
            {
                MessageBox.Show("Pilih data dari tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Yakin hapus obat ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_HapusObat", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_obat", txtID.Text.Trim());
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TampilkanData();
                    BuatGrafikDashboard();
                    BersihkanInput();
                }
                catch (SqlException ex)
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    MessageBox.Show(ex.Message, "Gagal Hapus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_CariObat", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@keyword", txtCari.Text.Trim());
                cmd.Parameters.AddWithValue("@jenis_obat", "");
                cmd.Parameters.AddWithValue("@status", "");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                dtObat.Clear();
                adapter.Fill(dtObat);
                bindingSource.DataSource = dtObat;
                lblTotal.Text = "Hasil Pencarian: " + dtObat.Rows.Count + " data";
                con.Close();
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open) con.Close();
                MessageBox.Show("Gagal mencari data:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            TampilkanData();
            BersihkanInput();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Backup semua data obat sekarang?", "Konfirmasi Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_BackupDataObat", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@backup_oleh", usernameLogin);
                    SqlDataReader reader = cmd.ExecuteReader();
                    string pesan = "";
                    if (reader.Read()) pesan = reader["pesan"].ToString();
                    reader.Close();
                    con.Close();
                    MessageBox.Show(pesan, "Backup Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    MessageBox.Show("Gagal backup:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDemoInjection_Click(object sender, EventArgs e)
        {
            string pesan =
                "=== DEMO SQL INJECTION ===\n\n" +
                "Query RENTAN (raw string):\n" +
                "  SELECT * FROM Akun WHERE username = '" + "' OR '1'='1" + "'\n\n" +
                "Hasil: semua data akun terbaca → bypass login!\n\n" +
                "Query AMAN (parameterized):\n" +
                "  cmd.Parameters.AddWithValue(\"@u\", txtUser.Text)\n\n" +
                "Input user TIDAK dieksekusi sebagai SQL.\n" +
                "Lihat detail skenario di README GitHub.";

            MessageBox.Show(pesan, "Demo SQL Injection", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ingin logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form2 login = new Form2();
                login.Show();
                this.Close();
            }
        }

        void BersihkanInput()
        {
            txtID.Clear();
            txtNama.Clear();
            txtJenis.Clear();
            txtSatuan.Clear();
            txtStok.Clear();
        }

        string GetIdAkun()
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT id_akun FROM Akun WHERE username = @u", con);
                cmd.Parameters.AddWithValue("@u", usernameLogin);
                object result = cmd.ExecuteScalar();
                con.Close();
                return result?.ToString() ?? "";
            }
            catch { if (con.State == ConnectionState.Open) con.Close(); return ""; }
        }

        private void txtID_TextChanged(object sender, EventArgs e) { }
        private void chartStok_Click(object sender, EventArgs e) { }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (dtObat.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk diekspor!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "Simpan Laporan Data Obat"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 30, 30);
                    iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new System.IO.FileStream(sfd.FileName, System.IO.FileMode.Create));
                    doc.Open();

                    iTextSharp.text.Font titleFont = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 18, iTextSharp.text.BaseColor.BLACK);
                    iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("Laporan Inventaris Obat Klinik", titleFont)
                    {
                        Alignment = iTextSharp.text.Element.ALIGN_CENTER,
                        SpacingAfter = 20
                    };
                    doc.Add(title);

                    iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(dtObat.Columns.Count);
                    table.WidthPercentage = 100;

                    iTextSharp.text.Font headerFont = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 12, iTextSharp.text.BaseColor.WHITE);
                    foreach (DataColumn column in dtObat.Columns)
                    {
                        iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(column.ColumnName, headerFont))
                        {
                            BackgroundColor = new iTextSharp.text.BaseColor(41, 128, 185),
                            HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                            Padding = 5
                        };
                        table.AddCell(cell);
                    }

                    iTextSharp.text.Font rowFont = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 10, iTextSharp.text.BaseColor.BLACK);
                    foreach (DataRow row in dtObat.Rows)
                    {
                        foreach (object item in row.ItemArray)
                        {
                            iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(item.ToString(), rowFont))
                            {
                                HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                                Padding = 4
                            };
                            table.AddCell(cell);
                        }
                    }

                    doc.Add(table);
                    doc.Close();
                    MessageBox.Show("Laporan PDF berhasil dibuat!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal membuat PDF:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm",
                Title = "Pilih File Excel Data Obat"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OfficeOpenXml.ExcelPackage.License.SetNonCommercialPersonal("M. Gyan Hendriansyah");

                    using (OfficeOpenXml.ExcelPackage package = new OfficeOpenXml.ExcelPackage(new System.IO.FileInfo(openFileDialog.FileName)))
                    {
                        OfficeOpenXml.ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        int rowCount = worksheet.Dimension.Rows;

                        if (con.State == ConnectionState.Open) con.Close();
                        con.Open();

                        for (int row = 2; row <= rowCount; row++)
                        {
                            string id_obat = worksheet.Cells[row, 1].Value?.ToString();
                            string nama_obat = worksheet.Cells[row, 2].Value?.ToString();
                            string jenis_obat = worksheet.Cells[row, 3].Value?.ToString();
                            string satuan = worksheet.Cells[row, 4].Value?.ToString();
                            string stokStr = worksheet.Cells[row, 5].Value?.ToString();

                            if (!string.IsNullOrEmpty(id_obat) && !string.IsNullOrEmpty(nama_obat))
                            {
                                int stok = int.TryParse(stokStr, out int s) ? s : 0;
                                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Obat WHERE id_obat = @id", con);
                                checkCmd.Parameters.AddWithValue("@id", id_obat);
                                int exists = (int)checkCmd.ExecuteScalar();

                                if (exists == 0)
                                {
                                    SqlCommand insertCmd = new SqlCommand("INSERT INTO Obat (id_obat, nama_obat, jenis_obat, satuan, stok_total) VALUES (@id, @nama, @jenis, @satuan, @stok)", con);
                                    insertCmd.Parameters.AddWithValue("@id", id_obat);
                                    insertCmd.Parameters.AddWithValue("@nama", nama_obat);
                                    insertCmd.Parameters.AddWithValue("@jenis", jenis_obat ?? (object)DBNull.Value);
                                    insertCmd.Parameters.AddWithValue("@satuan", satuan ?? (object)DBNull.Value);
                                    insertCmd.Parameters.AddWithValue("@stok", stok);
                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                        }
                        con.Close();
                        MessageBox.Show("Import Excel berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TampilkanData();
                        BuatGrafikDashboard();
                    }
                }
                catch (Exception ex)
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    MessageBox.Show("Gagal Import Excel:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BuatGrafikDashboard()
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT jenis_obat, SUM(stok_total) as total_stok FROM Obat GROUP BY jenis_obat", con);
                SqlDataReader reader = cmd.ExecuteReader();

                chartStok.Series.Clear();
                chartStok.Titles.Clear();
                chartStok.Titles.Add("Komposisi Stok Berdasarkan Jenis Obat");

                System.Windows.Forms.DataVisualization.Charting.Series series = chartStok.Series.Add("Stok Obat");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                series.IsValueShownAsLabel = true;

                while (reader.Read())
                {
                    string jenis = reader["jenis_obat"]?.ToString() ?? "Tidak Diketahui";
                    int stok = Convert.ToInt32(reader["total_stok"]);
                    series.Points.AddXY(jenis, stok);
                }

                reader.Close();
                con.Close();
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }
    }
}