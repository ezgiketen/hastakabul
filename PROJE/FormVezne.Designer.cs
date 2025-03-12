namespace PROJE
{
    partial class FormVezne
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVezne));
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            lblDosyaNo = new Label();
            label7 = new Label();
            lblTc = new Label();
            lbl1 = new Label();
            lblAd = new Label();
            lbl2 = new Label();
            dataGridVezne = new DataGridView();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridVezne).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
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
            groupBox1.Location = new Point(238, 71);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1423, 75);
            groupBox1.TabIndex = 38;
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
            lbl2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbl2.ForeColor = Color.FromArgb(0, 49, 83);
            lbl2.Location = new Point(289, 44);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(78, 20);
            lbl2.TabIndex = 0;
            lbl2.Text = "Ad Soyad ";
            // 
            // dataGridVezne
            // 
            dataGridVezne.BackgroundColor = Color.White;
            dataGridVezne.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridVezne.Location = new Point(238, 594);
            dataGridVezne.Name = "dataGridVezne";
            dataGridVezne.RowHeadersWidth = 51;
            dataGridVezne.Size = new Size(1423, 435);
            dataGridVezne.TabIndex = 39;
            // 
            // groupBox2
            // 
            groupBox2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox2.ForeColor = Color.FromArgb(0, 49, 83);
            groupBox2.Location = new Point(238, 192);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(495, 168);
            groupBox2.TabIndex = 40;
            groupBox2.TabStop = false;
            groupBox2.Text = "Toplam Ciro Bilgileri";
            // 
            // groupBox3
            // 
            groupBox3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox3.ForeColor = Color.FromArgb(0, 49, 83);
            groupBox3.Location = new Point(238, 366);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(495, 201);
            groupBox3.TabIndex = 41;
            groupBox3.TabStop = false;
            groupBox3.Text = "İndirim Uygula";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(button2);
            groupBox4.Controls.Add(button1);
            groupBox4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox4.ForeColor = Color.FromArgb(0, 49, 83);
            groupBox4.Location = new Point(1167, 341);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(494, 221);
            groupBox4.TabIndex = 41;
            groupBox4.TabStop = false;
            groupBox4.Text = "Ödeme İşlemleri";
            // 
            // button1
            // 
            button1.Location = new Point(186, 157);
            button1.Name = "button1";
            button1.Size = new Size(140, 29);
            button1.TabIndex = 42;
            button1.Text = "Ödeme Geçmişi";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(358, 157);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 42;
            button2.Text = "Ödeme Yap";
            button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 32);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 43;
            label1.Text = "İşlem Tutarı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 74);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 43;
            label2.Text = "label1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 118);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 43;
            label3.Text = "label1";
            // 
            // FormVezne
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 248, 251);
            ClientSize = new Size(1805, 1055);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(dataGridVezne);
            Controls.Add(groupBox1);
            Name = "FormVezne";
            Text = "FormVezne";
            Load += FormVezne_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridVezne).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private Label lblDosyaNo;
        private Label label7;
        private Label lblTc;
        private Label lbl1;
        private Label lblAd;
        private Label lbl2;
        private DataGridView dataGridVezne;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Button button1;
        private Button button2;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}