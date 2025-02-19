namespace PROJE
{
    partial class FormRecete
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblRecete = new Label();
            lblilac = new Label();
            lblKacKutu = new Label();
            lblKullanımPeriyodu = new Label();
            lblKacDoz = new Label();
            lblKullanımSekli = new Label();
            lblilacAcıklama = new Label();
            cmbKullanımPeriyodu = new ComboBox();
            cmbKullanımSekli = new ComboBox();
            txtilacBarkod = new TextBox();
            txtKacKutu = new TextBox();
            txtKacDoz = new TextBox();
            txtAciklama = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            lblilacListesi = new Label();
            dataGridilacListesi = new DataGridView();
            txtIlac = new TextBox();
            dataGridHastaILac = new DataGridView();
            lblHastaİlaç = new Label();
            lblilacAdı = new Label();
            txtilacAdi = new TextBox();
            lblTc = new Label();
            lblHasta = new Label();
            lblTcAl = new Label();
            lblAdSoyad = new Label();
            lblAdYazdır = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridilacListesi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridHastaILac).BeginInit();
            SuspendLayout();
            // 
            // lblRecete
            // 
            lblRecete.AutoSize = true;
            lblRecete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblRecete.Location = new Point(38, 94);
            lblRecete.Name = "lblRecete";
            lblRecete.Size = new Size(117, 23);
            lblRecete.TabIndex = 0;
            lblRecete.Text = "Reçete Bilgisi";
            // 
            // lblilac
            // 
            lblilac.AutoSize = true;
            lblilac.Location = new Point(37, 184);
            lblilac.Name = "lblilac";
            lblilac.Size = new Size(95, 20);
            lblilac.TabIndex = 1;
            lblilac.Text = "İlaç Barkodu ";
            // 
            // lblKacKutu
            // 
            lblKacKutu.AutoSize = true;
            lblKacKutu.Location = new Point(37, 226);
            lblKacKutu.Name = "lblKacKutu";
            lblKacKutu.Size = new Size(67, 20);
            lblKacKutu.TabIndex = 2;
            lblKacKutu.Text = "Kaç Kutu";
            // 
            // lblKullanımPeriyodu
            // 
            lblKullanımPeriyodu.AutoSize = true;
            lblKullanımPeriyodu.Location = new Point(37, 269);
            lblKullanımPeriyodu.Name = "lblKullanımPeriyodu";
            lblKullanımPeriyodu.Size = new Size(128, 20);
            lblKullanımPeriyodu.TabIndex = 3;
            lblKullanımPeriyodu.Text = "Kullanım Periyodu";
            // 
            // lblKacDoz
            // 
            lblKacDoz.AutoSize = true;
            lblKacDoz.Location = new Point(37, 314);
            lblKacDoz.Name = "lblKacDoz";
            lblKacDoz.Size = new Size(64, 20);
            lblKacDoz.TabIndex = 4;
            lblKacDoz.Text = "Kaç Doz";
            // 
            // lblKullanımSekli
            // 
            lblKullanımSekli.AutoSize = true;
            lblKullanımSekli.Location = new Point(37, 359);
            lblKullanımSekli.Name = "lblKullanımSekli";
            lblKullanımSekli.Size = new Size(102, 20);
            lblKullanımSekli.TabIndex = 5;
            lblKullanımSekli.Text = "Kullanım Şekli";
            // 
            // lblilacAcıklama
            // 
            lblilacAcıklama.AutoSize = true;
            lblilacAcıklama.Location = new Point(37, 402);
            lblilacAcıklama.Name = "lblilacAcıklama";
            lblilacAcıklama.Size = new Size(111, 20);
            lblilacAcıklama.TabIndex = 6;
            lblilacAcıklama.Text = "İlaç Açıklaması ";
            // 
            // cmbKullanımPeriyodu
            // 
            cmbKullanımPeriyodu.FormattingEnabled = true;
            cmbKullanımPeriyodu.Location = new Point(180, 266);
            cmbKullanımPeriyodu.Name = "cmbKullanımPeriyodu";
            cmbKullanımPeriyodu.Size = new Size(291, 28);
            cmbKullanımPeriyodu.TabIndex = 8;
            // 
            // cmbKullanımSekli
            // 
            cmbKullanımSekli.FormattingEnabled = true;
            cmbKullanımSekli.Location = new Point(180, 356);
            cmbKullanımSekli.Name = "cmbKullanımSekli";
            cmbKullanımSekli.Size = new Size(291, 28);
            cmbKullanımSekli.TabIndex = 9;
            cmbKullanımSekli.SelectedIndexChanged += cmbKullanımSekli_SelectedIndexChanged;
            // 
            // txtilacBarkod
            // 
            txtilacBarkod.Location = new Point(180, 181);
            txtilacBarkod.Name = "txtilacBarkod";
            txtilacBarkod.Size = new Size(291, 27);
            txtilacBarkod.TabIndex = 10;
            // 
            // txtKacKutu
            // 
            txtKacKutu.Location = new Point(180, 223);
            txtKacKutu.Name = "txtKacKutu";
            txtKacKutu.Size = new Size(291, 27);
            txtKacKutu.TabIndex = 11;
            // 
            // txtKacDoz
            // 
            txtKacDoz.Location = new Point(180, 311);
            txtKacDoz.Name = "txtKacDoz";
            txtKacDoz.Size = new Size(291, 27);
            txtKacDoz.TabIndex = 12;
            // 
            // txtAciklama
            // 
            txtAciklama.Location = new Point(180, 395);
            txtAciklama.Multiline = true;
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Size = new Size(291, 79);
            txtAciklama.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(27, 513);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 14;
            button1.Text = "Reçetem";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(248, 513);
            button2.Name = "button2";
            button2.Size = new Size(110, 29);
            button2.TabIndex = 15;
            button2.Text = "Reçeteye Ekle";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(377, 513);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 16;
            button3.Text = "Print ";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(138, 513);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 17;
            button4.Text = "Sil";
            button4.UseVisualStyleBackColor = true;
            // 
            // lblilacListesi
            // 
            lblilacListesi.AutoSize = true;
            lblilacListesi.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblilacListesi.Location = new Point(870, 94);
            lblilacListesi.Name = "lblilacListesi";
            lblilacListesi.Size = new Size(91, 23);
            lblilacListesi.TabIndex = 18;
            lblilacListesi.Text = "İlaç Listesi";
            // 
            // dataGridilacListesi
            // 
            dataGridilacListesi.BackgroundColor = Color.White;
            dataGridilacListesi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridilacListesi.Location = new Point(870, 161);
            dataGridilacListesi.Name = "dataGridilacListesi";
            dataGridilacListesi.RowHeadersWidth = 51;
            dataGridilacListesi.Size = new Size(612, 367);
            dataGridilacListesi.TabIndex = 19;
            dataGridilacListesi.CellClick += dataGridilacListesi_CellClick;
            dataGridilacListesi.CellContentClick += dataGridilacListesi_CellContentClick;
            // 
            // txtIlac
            // 
            txtIlac.Location = new Point(870, 128);
            txtIlac.Name = "txtIlac";
            txtIlac.Size = new Size(612, 27);
            txtIlac.TabIndex = 20;
            txtIlac.TextChanged += txtIlac_TextChanged;
            // 
            // dataGridHastaILac
            // 
            dataGridHastaILac.BackgroundColor = Color.White;
            dataGridHastaILac.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridHastaILac.Location = new Point(12, 610);
            dataGridHastaILac.Name = "dataGridHastaILac";
            dataGridHastaILac.RowHeadersWidth = 51;
            dataGridHastaILac.Size = new Size(1470, 367);
            dataGridHastaILac.TabIndex = 21;
            // 
            // lblHastaİlaç
            // 
            lblHastaİlaç.AutoSize = true;
            lblHastaİlaç.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblHastaİlaç.Location = new Point(12, 575);
            lblHastaİlaç.Name = "lblHastaİlaç";
            lblHastaİlaç.Size = new Size(87, 23);
            lblHastaİlaç.TabIndex = 22;
            lblHastaİlaç.Text = "Hasta İlaç";
            // 
            // lblilacAdı
            // 
            lblilacAdı.AutoSize = true;
            lblilacAdı.Location = new Point(37, 137);
            lblilacAdı.Name = "lblilacAdı";
            lblilacAdı.Size = new Size(59, 20);
            lblilacAdı.TabIndex = 23;
            lblilacAdı.Text = "İlaç Adı";
            // 
            // txtilacAdi
            // 
            txtilacAdi.Location = new Point(180, 134);
            txtilacAdi.Name = "txtilacAdi";
            txtilacAdi.Size = new Size(291, 27);
            txtilacAdi.TabIndex = 24;
            // 
            // lblTc
            // 
            lblTc.AutoSize = true;
            lblTc.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblTc.Location = new Point(535, 15);
            lblTc.Name = "lblTc";
            lblTc.Size = new Size(96, 20);
            lblTc.TabIndex = 25;
            lblTc.Text = "TC Kimlik No";
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblHasta.Location = new Point(180, 12);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(66, 23);
            lblHasta.TabIndex = 25;
            lblHasta.Text = "HASTA";
            // 
            // lblTcAl
            // 
            lblTcAl.AutoSize = true;
            lblTcAl.Location = new Point(637, 12);
            lblTcAl.Name = "lblTcAl";
            lblTcAl.Size = new Size(12, 20);
            lblTcAl.TabIndex = 27;
            lblTcAl.Text = ".";
            // 
            // lblAdSoyad
            // 
            lblAdSoyad.AutoSize = true;
            lblAdSoyad.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblAdSoyad.Location = new Point(330, 15);
            lblAdSoyad.Name = "lblAdSoyad";
            lblAdSoyad.Size = new Size(74, 20);
            lblAdSoyad.TabIndex = 29;
            lblAdSoyad.Text = "Ad Soyad";
            // 
            // lblAdYazdır
            // 
            lblAdYazdır.AutoSize = true;
            lblAdYazdır.Location = new Point(409, 14);
            lblAdYazdır.Name = "lblAdYazdır";
            lblAdYazdır.Size = new Size(12, 20);
            lblAdYazdır.TabIndex = 27;
            lblAdYazdır.Text = ".";
            // 
            // FormRecete
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1494, 1038);
            Controls.Add(lblAdSoyad);
            Controls.Add(lblAdYazdır);
            Controls.Add(lblTcAl);
            Controls.Add(lblHasta);
            Controls.Add(lblTc);
            Controls.Add(txtilacAdi);
            Controls.Add(lblilacAdı);
            Controls.Add(lblHastaİlaç);
            Controls.Add(dataGridHastaILac);
            Controls.Add(txtIlac);
            Controls.Add(dataGridilacListesi);
            Controls.Add(lblilacListesi);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtAciklama);
            Controls.Add(txtKacDoz);
            Controls.Add(txtKacKutu);
            Controls.Add(txtilacBarkod);
            Controls.Add(cmbKullanımSekli);
            Controls.Add(cmbKullanımPeriyodu);
            Controls.Add(lblilacAcıklama);
            Controls.Add(lblKullanımSekli);
            Controls.Add(lblKacDoz);
            Controls.Add(lblKullanımPeriyodu);
            Controls.Add(lblKacKutu);
            Controls.Add(lblilac);
            Controls.Add(lblRecete);
            Name = "FormRecete";
            Text = "FormRecete";
            Load += FormRecete_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridilacListesi).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridHastaILac).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRecete;
        private Label lblilac;
        private Label lblKacKutu;
        private Label lblKullanımPeriyodu;
        private Label lblKacDoz;
        private Label lblKullanımSekli;
        private Label lblilacAcıklama;
        private ComboBox cmbKullanımPeriyodu;
        private ComboBox cmbKullanımSekli;
        private TextBox txtilacBarkod;
        private TextBox txtKacKutu;
        private TextBox txtKacDoz;
        private TextBox txtAciklama;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label lblilacListesi;
        private DataGridView dataGridilacListesi;
        private TextBox txtIlac;
        private DataGridView dataGridHastaILac;
        private Label lblHastaİlaç;
        private Label lblilacAdı;
        private TextBox txtilacAdi;
        private Label lblTc;
        private Label lblHasta;
        private Label lblTcAl;
        private Label lblAdSoyad;
        private Label lblAdYazdır;
    }
}