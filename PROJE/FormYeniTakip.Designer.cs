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
            lblKurumAdi = new Label();
            lblGeldigiTarih = new Label();
            lblBölüm = new Label();
            lblDoktor = new Label();
            btnHesapAc = new Button();
            cmbKurumAdi = new ComboBox();
            cmbBolum = new ComboBox();
            cmbDr = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // lblKurumAdi
            // 
            lblKurumAdi.AutoSize = true;
            lblKurumAdi.Location = new Point(75, 70);
            lblKurumAdi.Name = "lblKurumAdi";
            lblKurumAdi.Size = new Size(83, 20);
            lblKurumAdi.TabIndex = 0;
            lblKurumAdi.Text = "Kurum Adı ";
            // 
            // lblGeldigiTarih
            // 
            lblGeldigiTarih.AutoSize = true;
            lblGeldigiTarih.Location = new Point(75, 117);
            lblGeldigiTarih.Name = "lblGeldigiTarih";
            lblGeldigiTarih.Size = new Size(92, 20);
            lblGeldigiTarih.TabIndex = 1;
            lblGeldigiTarih.Text = "Geldiği Tarih";
            // 
            // lblBölüm
            // 
            lblBölüm.AutoSize = true;
            lblBölüm.Location = new Point(75, 160);
            lblBölüm.Name = "lblBölüm";
            lblBölüm.Size = new Size(52, 20);
            lblBölüm.TabIndex = 2;
            lblBölüm.Text = "Bölüm";
            // 
            // lblDoktor
            // 
            lblDoktor.AutoSize = true;
            lblDoktor.Location = new Point(75, 211);
            lblDoktor.Name = "lblDoktor";
            lblDoktor.Size = new Size(55, 20);
            lblDoktor.TabIndex = 3;
            lblDoktor.Text = "Doktor";
            // 
            // btnHesapAc
            // 
            btnHesapAc.Location = new Point(449, 293);
            btnHesapAc.Name = "btnHesapAc";
            btnHesapAc.Size = new Size(97, 29);
            btnHesapAc.TabIndex = 4;
            btnHesapAc.Text = "Hesap Aç";
            btnHesapAc.UseVisualStyleBackColor = true;
            btnHesapAc.Click += btnHesapAc_Click;
            // 
            // cmbKurumAdi
            // 
            cmbKurumAdi.FormattingEnabled = true;
            cmbKurumAdi.Location = new Point(201, 62);
            cmbKurumAdi.Name = "cmbKurumAdi";
            cmbKurumAdi.Size = new Size(267, 28);
            cmbKurumAdi.TabIndex = 5;
            cmbKurumAdi.SelectedIndexChanged += cmbKurumAdi_SelectedIndexChanged;
            // 
            // cmbBolum
            // 
            cmbBolum.FormattingEnabled = true;
            cmbBolum.Location = new Point(201, 157);
            cmbBolum.Name = "cmbBolum";
            cmbBolum.Size = new Size(267, 28);
            cmbBolum.TabIndex = 6;
            cmbBolum.SelectedIndexChanged += cmbBolum_SelectedIndexChanged;
            cmbBolum.Click += cmbBolum_Click;
            // 
            // cmbDr
            // 
            cmbDr.FormattingEnabled = true;
            cmbDr.Location = new Point(201, 208);
            cmbDr.Name = "cmbDr";
            cmbDr.Size = new Size(267, 28);
            cmbDr.TabIndex = 7;
            cmbDr.SelectedIndexChanged += cmbDr_SelectedIndexChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(201, 110);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(267, 27);
            dateTimePicker1.TabIndex = 8;
            // 
            // FormYeniTakip
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dateTimePicker1);
            Controls.Add(cmbDr);
            Controls.Add(cmbBolum);
            Controls.Add(cmbKurumAdi);
            Controls.Add(btnHesapAc);
            Controls.Add(lblDoktor);
            Controls.Add(lblBölüm);
            Controls.Add(lblGeldigiTarih);
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
    }
}