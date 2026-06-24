namespace ObatKlinikADO
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtJenis = new System.Windows.Forms.TextBox();
            this.txtSatuan = new System.Windows.Forms.TextBox();
            this.txtStok = new System.Windows.Forms.TextBox();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnTampilkan = new System.Windows.Forms.Button();
            this.btnCari = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnDemoInjection = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelJenis = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvObat = new System.Windows.Forms.DataGridView();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.chartStok = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.btnExportPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStok)).BeginInit();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(145, 49);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(140, 26);
            this.txtID.TabIndex = 0;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(145, 95);
            this.txtNama.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(140, 26);
            this.txtNama.TabIndex = 1;
            // 
            // txtJenis
            // 
            this.txtJenis.Location = new System.Drawing.Point(145, 141);
            this.txtJenis.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtJenis.Name = "txtJenis";
            this.txtJenis.Size = new System.Drawing.Size(140, 26);
            this.txtJenis.TabIndex = 2;
            // 
            // txtSatuan
            // 
            this.txtSatuan.Location = new System.Drawing.Point(145, 188);
            this.txtSatuan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSatuan.Name = "txtSatuan";
            this.txtSatuan.Size = new System.Drawing.Size(140, 26);
            this.txtSatuan.TabIndex = 3;
            // 
            // txtStok
            // 
            this.txtStok.Location = new System.Drawing.Point(145, 234);
            this.txtStok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new System.Drawing.Size(140, 26);
            this.txtStok.TabIndex = 4;
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(145, 290);
            this.txtCari.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(140, 26);
            this.txtCari.TabIndex = 5;
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(22, 462);
            this.btnTambah.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(92, 38);
            this.btnTambah.TabIndex = 6;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(124, 462);
            this.btnHapus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(92, 38);
            this.btnHapus.TabIndex = 7;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(225, 462);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(92, 38);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnTampilkan
            // 
            this.btnTampilkan.Location = new System.Drawing.Point(326, 462);
            this.btnTampilkan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTampilkan.Name = "btnTampilkan";
            this.btnTampilkan.Size = new System.Drawing.Size(101, 38);
            this.btnTampilkan.TabIndex = 9;
            this.btnTampilkan.Text = "Tampilkan";
            this.btnTampilkan.UseVisualStyleBackColor = true;
            this.btnTampilkan.Click += new System.EventHandler(this.btnTampilkan_Click);
            // 
            // btnCari
            // 
            this.btnCari.Location = new System.Drawing.Point(436, 462);
            this.btnCari.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(84, 38);
            this.btnCari.TabIndex = 10;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(530, 462);
            this.btnBackup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(90, 38);
            this.btnBackup.TabIndex = 11;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnDemoInjection
            // 
            this.btnDemoInjection.Location = new System.Drawing.Point(629, 462);
            this.btnDemoInjection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDemoInjection.Name = "btnDemoInjection";
            this.btnDemoInjection.Size = new System.Drawing.Size(124, 38);
            this.btnDemoInjection.TabIndex = 12;
            this.btnDemoInjection.Text = "Demo Injection";
            this.btnDemoInjection.UseVisualStyleBackColor = true;
            this.btnDemoInjection.Click += new System.EventHandler(this.btnDemoInjection_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "ID Obat :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Nama Obat :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Satuan :";
            // 
            // labelJenis
            // 
            this.labelJenis.AutoSize = true;
            this.labelJenis.Location = new System.Drawing.Point(37, 145);
            this.labelJenis.Name = "labelJenis";
            this.labelJenis.Size = new System.Drawing.Size(93, 20);
            this.labelJenis.TabIndex = 22;
            this.labelJenis.Text = "Jenis Obat :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Stok Obat :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Cari Obat :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(349, 20);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(56, 20);
            this.lblTotal.TabIndex = 26;
            this.lblTotal.Text = "Hasil : ";
            // 
            // dgvObat
            // 
            this.dgvObat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObat.Location = new System.Drawing.Point(342, 49);
            this.dgvObat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvObat.Name = "dgvObat";
            this.dgvObat.RowHeadersWidth = 51;
            this.dgvObat.RowTemplate.Height = 24;
            this.dgvObat.Size = new System.Drawing.Size(360, 362);
            this.dgvObat.TabIndex = 27;
            this.dgvObat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObat_CellClick);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 524);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(1116, 38);
            this.bindingNavigator1.TabIndex = 28;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(784, 462);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 38);
            this.button1.TabIndex = 13;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chartStok
            // 
            chartArea1.Name = "ChartArea1";
            this.chartStok.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartStok.Legends.Add(legend1);
            this.chartStok.Location = new System.Drawing.Point(724, 49);
            this.chartStok.Name = "chartStok";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartStok.Series.Add(series1);
            this.chartStok.Size = new System.Drawing.Size(380, 362);
            this.chartStok.TabIndex = 29;
            this.chartStok.Text = "chart1";
            this.chartStok.Click += new System.EventHandler(this.chartStok_Click);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Location = new System.Drawing.Point(884, 462);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(102, 38);
            this.btnImportExcel.TabIndex = 30;
            this.btnImportExcel.Text = "Import";
            this.btnImportExcel.UseVisualStyleBackColor = true;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Location = new System.Drawing.Point(1001, 462);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(85, 38);
            this.btnExportPDF.TabIndex = 31;
            this.btnExportPDF.Text = "Cetak";
            this.btnExportPDF.UseVisualStyleBackColor = true;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 562);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.btnImportExcel);
            this.Controls.Add(this.chartStok);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.dgvObat);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnDemoInjection);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.btnTampilkan);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelJenis);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.txtStok);
            this.Controls.Add(this.txtSatuan);
            this.Controls.Add(this.txtJenis);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Sistem Pencatatan Obat Klinik";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStok)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtJenis;
        private System.Windows.Forms.TextBox txtSatuan;
        private System.Windows.Forms.TextBox txtStok;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnTampilkan;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnDemoInjection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelJenis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvObat;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStok;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.Button btnExportPDF;
    }
}