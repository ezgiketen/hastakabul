namespace PROJE
{
    partial class FormYeniTakip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormYeniTakip));
            lblKurumAdi = new Label();
            lblGeldigiTarih = new Label();
            lblBölüm = new Label();
            lblDoktor = new Label();
            btnHesapAc = new Button();
            cmbKurumAdi = new ComboBox();
            cmbBolum = new ComboBox();
            cmbDr = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblKurumAdi
            // 
            lblKurumAdi.AutoSize = true;
            lblKurumAdi.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblKurumAdi.ForeColor = Color.FromArgb(0, 49, 83);
            lblKurumAdi.Location = new Point(197, 158);
            lblKurumAdi.Name = "lblKurumAdi";
            lblKurumAdi.Size = new Size(96, 23);
            lblKurumAdi.TabIndex = 0;
            lblKurumAdi.Text = "Kurum Adı ";
            // 
            // lblGeldigiTarih
            // 
            lblGeldigiTarih.AutoSize = true;
            lblGeldigiTarih.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblGeldigiTarih.ForeColor = Color.FromArgb(0, 49, 83);
            lblGeldigiTarih.Location = new Point(197, 208);
            lblGeldigiTarih.Name = "lblGeldigiTarih";
            lblGeldigiTarih.Size = new Size(104, 23);
            lblGeldigiTarih.TabIndex = 1;
            lblGeldigiTarih.Text = "Geldiği Tarih";
            // 
            // lblBölüm
            // 
            lblBölüm.AutoSize = true;
            lblBölüm.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblBölüm.ForeColor = Color.FromArgb(0, 49, 83);
            lblBölüm.Location = new Point(197, 252);
            lblBölüm.Name = "lblBölüm";
            lblBölüm.Size = new Size(59, 23);
            lblBölüm.TabIndex = 2;
            lblBölüm.Text = "Bölüm";
            // 
            // lblDoktor
            // 
            lblDoktor.AutoSize = true;
            lblDoktor.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblDoktor.ForeColor = Color.FromArgb(0, 49, 83);
            lblDoktor.Location = new Point(197, 302);
            lblDoktor.Name = "lblDoktor";
            lblDoktor.Size = new Size(63, 23);
            lblDoktor.TabIndex = 3;
            lblDoktor.Text = "Doktor";
            // 
            // btnHesapAc
            // 
            btnHesapAc.BackgroundImageLayout = ImageLayout.Stretch;
            btnHesapAc.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnHesapAc.ForeColor = Color.FromArgb(0, 49, 83);
            btnHesapAc.Image = (Image)resources.GetObject("btnHesapAc.Image");
            btnHesapAc.ImageAlign = ContentAlignment.MiddleRight;
            btnHesapAc.Location = new Point(499, 368);
            btnHesapAc.Name = "btnHesapAc";
            btnHesapAc.Size = new Size(130, 35);
            btnHesapAc.TabIndex = 4;
            btnHesapAc.Text = "Hesap Aç     ";
            btnHesapAc.UseVisualStyleBackColor = true;
            btnHesapAc.Click += btnHesapAc_Click;
            // 
            // cmbKurumAdi
            // 
            cmbKurumAdi.FormattingEnabled = true;
            cmbKurumAdi.Location = new Point(323, 157);
            cmbKurumAdi.Name = "cmbKurumAdi";
            cmbKurumAdi.Size = new Size(306, 28);
            cmbKurumAdi.TabIndex = 5;
            cmbKurumAdi.SelectedIndexChanged += cmbKurumAdi_SelectedIndexChanged;
            // 
            // cmbBolum
            // 
            cmbBolum.FormattingEnabled = true;
            cmbBolum.Location = new Point(323, 252);
            cmbBolum.Name = "cmbBolum";
            cmbBolum.Size = new Size(306, 28);
            cmbBolum.TabIndex = 6;
            cmbBolum.SelectedIndexChanged += cmbBolum_SelectedIndexChanged;
            cmbBolum.Click += cmbBolum_Click;
            // 
            // cmbDr
            // 
            cmbDr.FormattingEnabled = true;
            cmbDr.Location = new Point(323, 301);
            cmbDr.Name = "cmbDr";
            cmbDr.Size = new Size(306, 28);
            cmbDr.TabIndex = 7;
            cmbDr.SelectedIndexChanged += cmbDr_SelectedIndexChanged_1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(323, 205);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(306, 27);
            dateTimePicker1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.FromArgb(0, 49, 83);
            label1.Location = new Point(352, 51);
            label1.Name = "label1";
            label1.Size = new Size(165, 28);
            label1.TabIndex = 0;
            label1.Text = "YENİ PROTOKOL";
            // 
            // FormYeniTakip
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 248, 251);
            ClientSize = new Size(898, 510);
            Controls.Add(dateTimePicker1);
            Controls.Add(cmbDr);
            Controls.Add(cmbBolum);
            Controls.Add(cmbKurumAdi);
            Controls.Add(btnHesapAc);
            Controls.Add(lblDoktor);
            Controls.Add(lblBölüm);
            Controls.Add(lblGeldigiTarih);
            Controls.Add(label1);
            Controls.Add(lblKurumAdi);
            Name = "FormYeniTakip";
            Text = "FormYeniTakip";
            Load += FormYeniTakip_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblKurumAdi;
        private Label lblGeldigiTarih;
        private Label lblBölüm;
        private Label lblDoktor;
        private Button btnHesapAc;
        private ComboBox cmbKurumAdi;
        private ComboBox cmbBolum;
        private ComboBox cmbDr;
        private DateTimePicker dateTimePicker1;
        private Label label1;
    }
}