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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecete));
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
            btnReceteEkle = new Button();
            btnSil = new Button();
            lblilacListesi = new Label();
            dataGridilacListesi = new DataGridView();
            txtIlac = new TextBox();
            dataGridHastaILac = new DataGridView();
            lblHastaİlaç = new Label();
            lblilacAdı = new Label();
            txtilacAdi = new TextBox();
            lblTc = new Label();
            lblTcAl = new Label();
            lblAdSoyad = new Label();
            lblAd = new Label();
            lblDosyaNo = new Label();
            lblD = new Label();
            HASTA = new GroupBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridilacListesi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridHastaILac).BeginInit();
            HASTA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblRecete
            // 
            lblRecete.AutoSize = true;
            lblRecete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblRecete.ForeColor = Color.FromArgb(0, 49, 83);
            lblRecete.Location = new Point(42, 139);
            lblRecete.Name = "lblRecete";
            lblRecete.Size = new Size(117, 23);
            lblRecete.TabIndex = 0;
            lblRecete.Text = "Reçete Bilgisi";
            // 
            // lblilac
            // 
            lblilac.AutoSize = true;
            lblilac.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblilac.Location = new Point(42, 231);
            lblilac.Name = "lblilac";
            lblilac.Size = new Size(98, 20);
            lblilac.TabIndex = 1;
            lblilac.Text = "İlaç Barkodu ";
            // 
            // lblKacKutu
            // 
            lblKacKutu.AutoSize = true;
            lblKacKutu.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblKacKutu.Location = new Point(42, 273);
            lblKacKutu.Name = "lblKacKutu";
            lblKacKutu.Size = new Size(69, 20);
            lblKacKutu.TabIndex = 2;
            lblKacKutu.Text = "Kaç Kutu";
            // 
            // lblKullanımPeriyodu
            // 
            lblKullanımPeriyodu.AutoSize = true;
            lblKullanımPeriyodu.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblKullanımPeriyodu.Location = new Point(42, 316);
            lblKullanımPeriyodu.Name = "lblKullanımPeriyodu";
            lblKullanımPeriyodu.Size = new Size(134, 20);
            lblKullanımPeriyodu.TabIndex = 3;
            lblKullanımPeriyodu.Text = "Kullanım Periyodu";
            // 
            // lblKacDoz
            // 
            lblKacDoz.AutoSize = true;
            lblKacDoz.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblKacDoz.Location = new Point(42, 361);
            lblKacDoz.Name = "lblKacDoz";
            lblKacDoz.Size = new Size(64, 20);
            lblKacDoz.TabIndex = 4;
            lblKacDoz.Text = "Kaç Doz";
            // 
            // lblKullanımSekli
            // 
            lblKullanımSekli.AutoSize = true;
            lblKullanımSekli.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblKullanımSekli.Location = new Point(42, 406);
            lblKullanımSekli.Name = "lblKullanımSekli";
            lblKullanımSekli.Size = new Size(105, 20);
            lblKullanımSekli.TabIndex = 5;
            lblKullanımSekli.Text = "Kullanım Şekli";
            // 
            // lblilacAcıklama
            // 
            lblilacAcıklama.AutoSize = true;
            lblilacAcıklama.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblilacAcıklama.Location = new Point(42, 449);
            lblilacAcıklama.Name = "lblilacAcıklama";
            lblilacAcıklama.Size = new Size(112, 20);
            lblilacAcıklama.TabIndex = 6;
            lblilacAcıklama.Text = "İlaç Açıklaması ";
            // 
            // cmbKullanımPeriyodu
            // 
            cmbKullanımPeriyodu.FormattingEnabled = true;
            cmbKullanımPeriyodu.Location = new Point(195, 316);
            cmbKullanımPeriyodu.Name = "cmbKullanımPeriyodu";
            cmbKullanımPeriyodu.Size = new Size(347, 28);
            cmbKullanımPeriyodu.TabIndex = 8;
            cmbKullanımPeriyodu.SelectedIndexChanged += cmbKullanımPeriyodu_SelectedIndexChanged;
            // 
            // cmbKullanımSekli
            // 
            cmbKullanımSekli.FormattingEnabled = true;
            cmbKullanımSekli.Location = new Point(195, 406);
            cmbKullanımSekli.Name = "cmbKullanımSekli";
            cmbKullanımSekli.Size = new Size(347, 28);
            cmbKullanımSekli.TabIndex = 9;
            cmbKullanımSekli.SelectedIndexChanged += cmbKullanımSekli_SelectedIndexChanged;
            // 
            // txtilacBarkod
            // 
            txtilacBarkod.Location = new Point(195, 231);
            txtilacBarkod.Name = "txtilacBarkod";
            txtilacBarkod.Size = new Size(347, 27);
            txtilacBarkod.TabIndex = 10;
            // 
            // txtKacKutu
            // 
            txtKacKutu.Location = new Point(195, 273);
            txtKacKutu.Name = "txtKacKutu";
            txtKacKutu.Size = new Size(347, 27);
            txtKacKutu.TabIndex = 11;
            // 
            // txtKacDoz
            // 
            txtKacDoz.Location = new Point(195, 361);
            txtKacDoz.Name = "txtKacDoz";
            txtKacDoz.Size = new Size(347, 27);
            txtKacDoz.TabIndex = 12;
            // 
            // txtAciklama
            // 
            txtAciklama.Location = new Point(195, 449);
            txtAciklama.Multiline = true;
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Size = new Size(347, 79);
            txtAciklama.TabIndex = 13;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(242, 248, 251);
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.Location = new Point(165, 572);
            button1.Name = "button1";
            button1.Size = new Size(128, 35);
            button1.TabIndex = 14;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnReceteEkle
            // 
            btnReceteEkle.BackColor = Color.FromArgb(242, 248, 251);
            btnReceteEkle.BackgroundImageLayout = ImageLayout.Center;
            btnReceteEkle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnReceteEkle.Image = (Image)resources.GetObject("btnReceteEkle.Image");
            btnReceteEkle.ImageAlign = ContentAlignment.MiddleRight;
            btnReceteEkle.Location = new Point(449, 572);
            btnReceteEkle.Name = "btnReceteEkle";
            btnReceteEkle.Size = new Size(128, 35);
            btnReceteEkle.TabIndex = 15;
            btnReceteEkle.Text = "Reçete Ekle   ";
            btnReceteEkle.UseVisualStyleBackColor = false;
            btnReceteEkle.Click += btnReceteEkle_Click;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.FromArgb(242, 248, 251);
            btnSil.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSil.Image = (Image)resources.GetObject("btnSil.Image");
            btnSil.ImageAlign = ContentAlignment.MiddleRight;
            btnSil.Location = new Point(309, 572);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(128, 35);
            btnSil.TabIndex = 17;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click_1;
            // 
            // lblilacListesi
            // 
            lblilacListesi.AutoSize = true;
            lblilacListesi.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblilacListesi.ForeColor = Color.FromArgb(0, 49, 83);
            lblilacListesi.Location = new Point(836, 139);
            lblilacListesi.Name = "lblilacListesi";
            lblilacListesi.Size = new Size(91, 23);
            lblilacListesi.TabIndex = 18;
            lblilacListesi.Text = "İlaç Listesi";
            // 
            // dataGridilacListesi
            // 
            dataGridilacListesi.BackgroundColor = Color.White;
            dataGridilacListesi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridilacListesi.Location = new Point(836, 208);
            dataGridilacListesi.Name = "dataGridilacListesi";
            dataGridilacListesi.RowHeadersWidth = 51;
            dataGridilacListesi.Size = new Size(1054, 381);
            dataGridilacListesi.TabIndex = 19;
            dataGridilacListesi.CellClick += dataGridilacListesi_CellClick;
            // 
            // txtIlac
            // 
            txtIlac.ForeColor = SystemColors.GrayText;
            txtIlac.Location = new Point(836, 167);
            txtIlac.Name = "txtIlac";
            txtIlac.Size = new Size(1054, 27);
            txtIlac.TabIndex = 20;
            txtIlac.TextChanged += txtIlac_TextChanged;
            // 
            // dataGridHastaILac
            // 
            dataGridHastaILac.BackgroundColor = Color.White;
            dataGridHastaILac.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridHastaILac.Location = new Point(12, 663);
            dataGridHastaILac.Name = "dataGridHastaILac";
            dataGridHastaILac.RowHeadersWidth = 51;
            dataGridHastaILac.Size = new Size(1887, 363);
            dataGridHastaILac.TabIndex = 21;
            dataGridHastaILac.CellClick += dataGridHastaILac_CellClick;
            // 
            // lblHastaİlaç
            // 
            lblHastaİlaç.AutoSize = true;
            lblHastaİlaç.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblHastaİlaç.ForeColor = Color.FromArgb(0, 49, 83);
            lblHastaİlaç.Location = new Point(12, 628);
            lblHastaİlaç.Name = "lblHastaİlaç";
            lblHastaİlaç.Size = new Size(139, 23);
            lblHastaİlaç.TabIndex = 22;
            lblHastaİlaç.Text = "Hasta Reçeteleri";
            // 
            // lblilacAdı
            // 
            lblilacAdı.AutoSize = true;
            lblilacAdı.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblilacAdı.Location = new Point(42, 184);
            lblilacAdı.Name = "lblilacAdı";
            lblilacAdı.Size = new Size(59, 20);
            lblilacAdı.TabIndex = 23;
            lblilacAdı.Text = "İlaç Adı";
            // 
            // txtilacAdi
            // 
            txtilacAdi.Location = new Point(195, 181);
            txtilacAdi.Name = "txtilacAdi";
            txtilacAdi.Size = new Size(347, 27);
            txtilacAdi.TabIndex = 24;
            // 
            // lblTc
            // 
            lblTc.AutoSize = true;
            lblTc.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblTc.Location = new Point(623, 42);
            lblTc.Name = "lblTc";
            lblTc.Size = new Size(99, 20);
            lblTc.TabIndex = 25;
            lblTc.Text = "TC Kimlik No";
            // 
            // lblTcAl
            // 
            lblTcAl.AutoSize = true;
            lblTcAl.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblTcAl.ForeColor = Color.Black;
            lblTcAl.Location = new Point(728, 40);
            lblTcAl.Name = "lblTcAl";
            lblTcAl.Size = new Size(14, 23);
            lblTcAl.TabIndex = 27;
            lblTcAl.Text = ".";
            // 
            // lblAdSoyad
            // 
            lblAdSoyad.AutoSize = true;
            lblAdSoyad.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblAdSoyad.Location = new Point(309, 42);
            lblAdSoyad.Name = "lblAdSoyad";
            lblAdSoyad.Size = new Size(75, 20);
            lblAdSoyad.TabIndex = 29;
            lblAdSoyad.Text = "Ad Soyad";
            // 
            // lblAd
            // 
            lblAd.AutoSize = true;
            lblAd.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblAd.ForeColor = Color.Black;
            lblAd.Location = new Point(390, 40);
            lblAd.Name = "lblAd";
            lblAd.Size = new Size(14, 23);
            lblAd.TabIndex = 27;
            lblAd.Text = ".";
            // 
            // lblDosyaNo
            // 
            lblDosyaNo.AutoSize = true;
            lblDosyaNo.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblDosyaNo.ForeColor = Color.Black;
            lblDosyaNo.Location = new Point(967, 39);
            lblDosyaNo.Name = "lblDosyaNo";
            lblDosyaNo.Size = new Size(14, 23);
            lblDosyaNo.TabIndex = 30;
            lblDosyaNo.Text = ".";
            // 
            // lblD
            // 
            lblD.AutoSize = true;
            lblD.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblD.Location = new Point(884, 40);
            lblD.Name = "lblD";
            lblD.Size = new Size(77, 20);
            lblD.TabIndex = 31;
            lblD.Text = "Dosya No";
            // 
            // HASTA
            // 
            HASTA.BackColor = Color.FromArgb(242, 248, 251);
            HASTA.Controls.Add(pictureBox1);
            HASTA.Controls.Add(lblAdSoyad);
            HASTA.Controls.Add(lblDosyaNo);
            HASTA.Controls.Add(lblD);
            HASTA.Controls.Add(lblAd);
            HASTA.Controls.Add(lblTcAl);
            HASTA.Controls.Add(lblTc);
            HASTA.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            HASTA.ForeColor = Color.FromArgb(0, 49, 83);
            HASTA.Location = new Point(0, 5);
            HASTA.Name = "HASTA";
            HASTA.Size = new Size(1943, 65);
            HASTA.TabIndex = 33;
            HASTA.TabStop = false;
            HASTA.Text = "HASTA BILGILERI";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(183, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(57, 49);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 34;
            pictureBox1.TabStop = false;
            // 
            // FormRecete
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 248, 251);
            ClientSize = new Size(1911, 1038);
            Controls.Add(HASTA);
            Controls.Add(txtilacAdi);
            Controls.Add(lblilacAdı);
            Controls.Add(lblHastaİlaç);
            Controls.Add(dataGridHastaILac);
            Controls.Add(txtIlac);
            Controls.Add(dataGridilacListesi);
            Controls.Add(lblilacListesi);
            Controls.Add(btnSil);
            Controls.Add(btnReceteEkle);
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
            HASTA.ResumeLayout(false);
            HASTA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private Button btnReceteEkle;
        private Button button3;
        private Button btnSil;
        private Label lblilacListesi;
        private DataGridView dataGridilacListesi;
        private TextBox txtIlac;
        private DataGridView dataGridHastaILac;
        private Label lblHastaİlaç;
        private Label lblilacAdı;
        private TextBox txtilacAdi;
        private Label lblTc;
        private Label lblTcAl;
        private Label lblAdSoyad;
        private Label lblAd;
        private Label lblDosyaNo;
        private Label lblD;
        private GroupBox HASTA;
        private PictureBox pictureBox1;
    }
}