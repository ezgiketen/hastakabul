namespace PROJE
{
    partial class FormTani
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTani));
            txtTaniAra = new TextBox();
            cmbTani = new ComboBox();
            dataGridViewTani = new DataGridView();
            dataGridViewGöster = new DataGridView();
            label1 = new Label();
            btnTaniEkle = new Button();
            btnTaniSil = new Button();
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            lblDosyaNo = new Label();
            label7 = new Label();
            lblTc = new Label();
            lbl1 = new Label();
            lblAd = new Label();
            lbl2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTani).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGöster).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtTaniAra
            // 
            txtTaniAra.ForeColor = Color.DarkGray;
            txtTaniAra.Location = new Point(959, 161);
            txtTaniAra.Name = "txtTaniAra";
            txtTaniAra.Size = new Size(657, 27);
            txtTaniAra.TabIndex = 0;
            txtTaniAra.Text = "Hızlı Arama";
            txtTaniAra.TextChanged += txtTaniAra_TextChanged;
            // 
            // cmbTani
            // 
            cmbTani.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            cmbTani.ForeColor = Color.DimGray;
            cmbTani.FormattingEnabled = true;
            cmbTani.Location = new Point(260, 160);
            cmbTani.Name = "cmbTani";
            cmbTani.Size = new Size(629, 28);
            cmbTani.TabIndex = 1;
            cmbTani.Text = "Tanı Grubu";
            cmbTani.SelectedIndexChanged += cmbTani_SelectedIndexChanged;
            // 
            // dataGridViewTani
            // 
            dataGridViewTani.BackgroundColor = Color.White;
            dataGridViewTani.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTani.Location = new Point(260, 195);
            dataGridViewTani.Name = "dataGridViewTani";
            dataGridViewTani.RowHeadersWidth = 51;
            dataGridViewTani.Size = new Size(1356, 297);
            dataGridViewTani.TabIndex = 2;
            // 
            // dataGridViewGöster
            // 
            dataGridViewGöster.BackgroundColor = Color.FromArgb(221, 221, 221);
            dataGridViewGöster.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewGöster.Location = new Point(260, 588);
            dataGridViewGöster.Name = "dataGridViewGöster";
            dataGridViewGöster.RowHeadersWidth = 51;
            dataGridViewGöster.Size = new Size(1356, 257);
            dataGridViewGöster.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.FromArgb(0, 49, 83);
            label1.Location = new Point(260, 562);
            label1.Name = "label1";
            label1.Size = new Size(119, 23);
            label1.TabIndex = 4;
            label1.Text = "Hasta Tanıları";
            // 
            // btnTaniEkle
            // 
            btnTaniEkle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnTaniEkle.Image = (Image)resources.GetObject("btnTaniEkle.Image");
            btnTaniEkle.ImageAlign = ContentAlignment.MiddleRight;
            btnTaniEkle.Location = new Point(1481, 498);
            btnTaniEkle.Name = "btnTaniEkle";
            btnTaniEkle.Size = new Size(135, 29);
            btnTaniEkle.TabIndex = 5;
            btnTaniEkle.Text = "Tanı Ekle";
            btnTaniEkle.UseVisualStyleBackColor = true;
            btnTaniEkle.Click += btnTaniEkle_Click;
            // 
            // btnTaniSil
            // 
            btnTaniSil.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnTaniSil.Image = (Image)resources.GetObject("btnTaniSil.Image");
            btnTaniSil.ImageAlign = ContentAlignment.MiddleRight;
            btnTaniSil.Location = new Point(1516, 851);
            btnTaniSil.Name = "btnTaniSil";
            btnTaniSil.Size = new Size(100, 29);
            btnTaniSil.TabIndex = 6;
            btnTaniSil.Text = "Sil   ";
            btnTaniSil.UseVisualStyleBackColor = true;
            btnTaniSil.Click += btnTaniSil_Click;
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
            groupBox1.Location = new Point(260, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1356, 68);
            groupBox1.TabIndex = 36;
            groupBox1.TabStop = false;
            groupBox1.Text = "HASTA BİLGİLERİ";
            groupBox1.Enter += groupBox1_Enter;
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
            // FormTani
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 248, 251);
            ClientSize = new Size(1924, 1055);
            Controls.Add(groupBox1);
            Controls.Add(btnTaniSil);
            Controls.Add(btnTaniEkle);
            Controls.Add(label1);
            Controls.Add(dataGridViewGöster);
            Controls.Add(dataGridViewTani);
            Controls.Add(cmbTani);
            Controls.Add(txtTaniAra);
            Name = "FormTani";
            Text = "FormTani";
            Load += FormTani_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTani).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGöster).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbTani;
        private DataGridView dataGridViewTani;
        private DataGridView dataGridViewGöster;
        private Label label1;
        private Button btnTaniEkle;
        private Button btnTaniSil;
        private GroupBox groupBox1;
        private Label lblDosyaNo;
        private Label label7;
        private Label lblTc;
        private Label lbl1;
        private Label lblAd;
        private Label lbl2;
        private PictureBox pictureBox1;
        internal TextBox txtTaniAra;
    }
}