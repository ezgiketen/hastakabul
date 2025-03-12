namespace PROJE
{
    partial class FormIslemTetkik
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIslemTetkik));
            dataGridTetkik = new DataGridView();
            cmbTetkikAra = new ComboBox();
            txtTetkikAra = new TextBox();
            dataGridHtetkik = new DataGridView();
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            lblDosyaNo = new Label();
            label7 = new Label();
            lblTc = new Label();
            lbl1 = new Label();
            lblAd = new Label();
            lbl2 = new Label();
            btnTetkikEkle = new Button();
            btnTaniSil = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridTetkik).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridHtetkik).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridTetkik
            // 
            dataGridTetkik.BackgroundColor = Color.White;
            dataGridTetkik.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridTetkik.Location = new Point(240, 196);
            dataGridTetkik.Name = "dataGridTetkik";
            dataGridTetkik.RowHeadersWidth = 51;
            dataGridTetkik.Size = new Size(1377, 274);
            dataGridTetkik.TabIndex = 0;
            // 
            // cmbTetkikAra
            // 
            cmbTetkikAra.ForeColor = Color.DimGray;
            cmbTetkikAra.FormattingEnabled = true;
            cmbTetkikAra.Location = new Point(240, 152);
            cmbTetkikAra.Name = "cmbTetkikAra";
            cmbTetkikAra.Size = new Size(605, 28);
            cmbTetkikAra.TabIndex = 1;
            cmbTetkikAra.Text = "Tetkik Grubu";
            cmbTetkikAra.SelectedIndexChanged += cmbTetkikAra_SelectedIndexChanged;
            cmbTetkikAra.Click += cmbTetkikAra_Click;
            // 
            // txtTetkikAra
            // 
            txtTetkikAra.ForeColor = Color.DimGray;
            txtTetkikAra.Location = new Point(902, 153);
            txtTetkikAra.Name = "txtTetkikAra";
            txtTetkikAra.Size = new Size(715, 27);
            txtTetkikAra.TabIndex = 2;
            txtTetkikAra.Text = "Hızlı Arama";
            txtTetkikAra.Click += txtTetkikAra_Click;
            txtTetkikAra.TextChanged += txtTetkikAra_TextChanged_1;
            // 
            // dataGridHtetkik
            // 
            dataGridHtetkik.BackgroundColor = Color.White;
            dataGridHtetkik.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridHtetkik.Location = new Point(240, 570);
            dataGridHtetkik.Name = "dataGridHtetkik";
            dataGridHtetkik.RowHeadersWidth = 51;
            dataGridHtetkik.Size = new Size(1377, 306);
            dataGridHtetkik.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(lblDosyaNo);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(lblTc);
            groupBox1.Controls.Add(lbl1);
            groupBox1.Controls.Add(lblAd);
            groupBox1.Controls.Add(lbl2);
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox1.ForeColor = Color.FromArgb(0, 49, 83);
            groupBox1.Location = new Point(240, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1377, 68);
            groupBox1.TabIndex = 37;
            groupBox1.TabStop = false;
            groupBox1.Text = "HASTA BİLGİLERİ";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(177, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(57, 49);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 35;
            pictureBox1.TabStop = false;
            // 
            // lblDosyaNo
            // 
            lblDosyaNo.AutoSize = true;
            lblDosyaNo.Location = new Point(978, 42);
            lblDosyaNo.Name = "lblDosyaNo";
            lblDosyaNo.Size = new Size(15, 23);
            lblDosyaNo.TabIndex = 0;
            lblDosyaNo.Text = ".";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label7.Location = new Point(895, 44);
            label7.Name = "label7";
            label7.Size = new Size(77, 20);
            label7.TabIndex = 0;
            label7.Text = "Dosya No";
            // 
            // lblTc
            // 
            lblTc.AutoSize = true;
            lblTc.Location = new Point(693, 43);
            lblTc.Name = "lblTc";
            lblTc.Size = new Size(15, 23);
            lblTc.TabIndex = 0;
            lblTc.Text = ".";
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lbl1.Location = new Point(588, 45);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(99, 20);
            lbl1.TabIndex = 0;
            lbl1.Text = "TC Kimlik No";
            // 
            // lblAd
            // 
            lblAd.AutoSize = true;
            lblAd.Location = new Point(364, 41);
            lblAd.Name = "lblAd";
            lblAd.Size = new Size(15, 23);
            lblAd.TabIndex = 0;
            lblAd.Text = ".";
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lbl2.Location = new Point(289, 44);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(79, 20);
            lbl2.TabIndex = 0;
            lbl2.Text = "Ad Soyad ";
            // 
            // btnTetkikEkle
            // 
            btnTetkikEkle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnTetkikEkle.Image = (Image)resources.GetObject("btnTetkikEkle.Image");
            btnTetkikEkle.ImageAlign = ContentAlignment.MiddleRight;
            btnTetkikEkle.Location = new Point(1482, 476);
            btnTetkikEkle.Name = "btnTetkikEkle";
            btnTetkikEkle.Size = new Size(135, 29);
            btnTetkikEkle.TabIndex = 38;
            btnTetkikEkle.Text = "Tetkik Ekle     ";
            btnTetkikEkle.UseVisualStyleBackColor = true;
            btnTetkikEkle.Click += btnTetkikEkle_Click;
            // 
            // btnTaniSil
            // 
            btnTaniSil.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnTaniSil.Image = (Image)resources.GetObject("btnTaniSil.Image");
            btnTaniSil.ImageAlign = ContentAlignment.MiddleRight;
            btnTaniSil.Location = new Point(1517, 882);
            btnTaniSil.Name = "btnTaniSil";
            btnTaniSil.Size = new Size(100, 29);
            btnTaniSil.TabIndex = 39;
            btnTaniSil.Text = "Sil   ";
            btnTaniSil.UseVisualStyleBackColor = true;
            btnTaniSil.Click += btnTetkikSil_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.FromArgb(0, 49, 83);
            label1.Location = new Point(240, 544);
            label1.Name = "label1";
            label1.Size = new Size(135, 23);
            label1.TabIndex = 40;
            label1.Text = "Hasta Tetkikleri";
            // 
            // FormIslemTetkik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 248, 251);
            ClientSize = new Size(1764, 963);
            Controls.Add(label1);
            Controls.Add(btnTaniSil);
            Controls.Add(btnTetkikEkle);
            Controls.Add(groupBox1);
            Controls.Add(dataGridHtetkik);
            Controls.Add(txtTetkikAra);
            Controls.Add(cmbTetkikAra);
            Controls.Add(dataGridTetkik);
            Name = "FormIslemTetkik";
            Text = "FormIslemTetkik";
            ((System.ComponentModel.ISupportInitialize)dataGridTetkik).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridHtetkik).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridTetkik;
        private ComboBox cmbTetkikAra;
        private TextBox txtTetkikAra;
        private DataGridView dataGridHtetkik;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private Label lblDosyaNo;
        private Label label7;
        private Label lblTc;
        private Label lbl1;
        private Label lblAd;
        private Label lbl2;
        private Button btnTetkikEkle;
        private Button btnTaniSil;
        private Label label1;
    }
}