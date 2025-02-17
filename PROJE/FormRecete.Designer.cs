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
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            lblilacListesi = new Label();
            dataGridilacListesi = new DataGridView();
            txtIlac = new TextBox();
            dataGridHastaILac = new DataGridView();
            lblHastaİlaç = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridilacListesi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridHastaILac).BeginInit();
            SuspendLayout();
            // 
            // lblRecete
            // 
            lblRecete.AutoSize = true;
            lblRecete.Location = new Point(22, 13);
            lblRecete.Name = "lblRecete";
            lblRecete.Size = new Size(98, 20);
            lblRecete.TabIndex = 0;
            lblRecete.Text = "Reçete Bilgisi";
            // 
            // lblilac
            // 
            lblilac.AutoSize = true;
            lblilac.Location = new Point(22, 94);
            lblilac.Name = "lblilac";
            lblilac.Size = new Size(95, 20);
            lblilac.TabIndex = 1;
            lblilac.Text = "İlaç Barkodu ";
            // 
            // lblKacKutu
            // 
            lblKacKutu.AutoSize = true;
            lblKacKutu.Location = new Point(22, 133);
            lblKacKutu.Name = "lblKacKutu";
            lblKacKutu.Size = new Size(67, 20);
            lblKacKutu.TabIndex = 2;
            lblKacKutu.Text = "Kaç Kutu";
            // 
            // lblKullanımPeriyodu
            // 
            lblKullanımPeriyodu.AutoSize = true;
            lblKullanımPeriyodu.Location = new Point(22, 176);
            lblKullanımPeriyodu.Name = "lblKullanımPeriyodu";
            lblKullanımPeriyodu.Size = new Size(128, 20);
            lblKullanımPeriyodu.TabIndex = 3;
            lblKullanımPeriyodu.Text = "Kullanım Periyodu";
            // 
            // lblKacDoz
            // 
            lblKacDoz.AutoSize = true;
            lblKacDoz.Location = new Point(22, 221);
            lblKacDoz.Name = "lblKacDoz";
            lblKacDoz.Size = new Size(64, 20);
            lblKacDoz.TabIndex = 4;
            lblKacDoz.Text = "Kaç Doz";
            // 
            // lblKullanımSekli
            // 
            lblKullanımSekli.AutoSize = true;
            lblKullanımSekli.Location = new Point(22, 266);
            lblKullanımSekli.Name = "lblKullanımSekli";
            lblKullanımSekli.Size = new Size(102, 20);
            lblKullanımSekli.TabIndex = 5;
            lblKullanımSekli.Text = "Kullanım Şekli";
            // 
            // lblilacAcıklama
            // 
            lblilacAcıklama.AutoSize = true;
            lblilacAcıklama.Location = new Point(22, 309);
            lblilacAcıklama.Name = "lblilacAcıklama";
            lblilacAcıklama.Size = new Size(111, 20);
            lblilacAcıklama.TabIndex = 6;
            lblilacAcıklama.Text = "İlaç Açıklaması ";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(22, 36);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(514, 28);
            comboBox1.TabIndex = 7;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(165, 173);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(236, 28);
            comboBox2.TabIndex = 8;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(165, 258);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(236, 28);
            comboBox3.TabIndex = 9;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(165, 91);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(236, 27);
            textBox1.TabIndex = 10;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(165, 130);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(236, 27);
            textBox2.TabIndex = 11;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(165, 218);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(236, 27);
            textBox3.TabIndex = 12;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(165, 302);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(236, 86);
            textBox4.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(12, 420);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 14;
            button1.Text = "Reçetem";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(233, 420);
            button2.Name = "button2";
            button2.Size = new Size(110, 29);
            button2.TabIndex = 15;
            button2.Text = "Reçeteye Ekle";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(362, 420);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 16;
            button3.Text = "Print ";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(123, 420);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 17;
            button4.Text = "Sil";
            button4.UseVisualStyleBackColor = true;
            // 
            // lblilacListesi
            // 
            lblilacListesi.AutoSize = true;
            lblilacListesi.Location = new Point(847, 15);
            lblilacListesi.Name = "lblilacListesi";
            lblilacListesi.Size = new Size(76, 20);
            lblilacListesi.TabIndex = 18;
            lblilacListesi.Text = "İlaç Listesi";
            // 
            // dataGridilacListesi
            // 
            dataGridilacListesi.BackgroundColor = Color.White;
            dataGridilacListesi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridilacListesi.Location = new Point(847, 82);
            dataGridilacListesi.Name = "dataGridilacListesi";
            dataGridilacListesi.RowHeadersWidth = 51;
            dataGridilacListesi.Size = new Size(612, 367);
            dataGridilacListesi.TabIndex = 19;
            // 
            // txtIlac
            // 
            txtIlac.Location = new Point(847, 49);
            txtIlac.Name = "txtIlac";
            txtIlac.Size = new Size(612, 27);
            txtIlac.TabIndex = 20;
            txtIlac.TextChanged += txtIlac_TextChanged;
            // 
            // dataGridHastaILac
            // 
            dataGridHastaILac.BackgroundColor = Color.White;
            dataGridHastaILac.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridHastaILac.Location = new Point(12, 621);
            dataGridHastaILac.Name = "dataGridHastaILac";
            dataGridHastaILac.RowHeadersWidth = 51;
            dataGridHastaILac.Size = new Size(1447, 367);
            dataGridHastaILac.TabIndex = 21;
            // 
            // lblHastaİlaç
            // 
            lblHastaİlaç.AutoSize = true;
            lblHastaİlaç.Location = new Point(12, 587);
            lblHastaİlaç.Name = "lblHastaİlaç";
            lblHastaİlaç.Size = new Size(74, 20);
            lblHastaİlaç.TabIndex = 22;
            lblHastaİlaç.Text = "Hasta İlaç";
            // 
            // FormRecete
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1494, 1038);
            Controls.Add(lblHastaİlaç);
            Controls.Add(dataGridHastaILac);
            Controls.Add(txtIlac);
            Controls.Add(dataGridilacListesi);
            Controls.Add(lblilacListesi);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
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
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label lblilacListesi;
        private DataGridView dataGridilacListesi;
        private TextBox txtIlac;
        private DataGridView dataGridHastaILac;
        private Label lblHastaİlaç;
    }
}