using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using OracleDatabaseConnectionExample;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace PROJE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            groupBoxHastaBilgi.Visible = false;
            groupBoxKimlik.Visible = true;
            btnKaydet.Visible = true;
            btnGuncelle.Visible = false;
            dataGridView1.Visible = false;


        }
        // lblDosyaNoo'yu dýþarýya eriþilebilir yapmak için bir property ekleyin
        public string DosyaNo
        {
            get { return lblDosyaNoo.Text; }
            set { lblDosyaNoo.Text = value; }
        }

        private bool menuExpandHasta = false;
        private bool menuExpandHemsire = false;
        private bool menuExpandDoktor = false;
        public void connectdb()
        {
            OracleDbHelper dbHelper = new OracleDbHelper();
            using (OracleConnection conn = dbHelper.GetConnection())

            {
                try
                {
                    conn.Open();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("hata : " + ex.Message);
                }

            }
        }

        // Form kapanmadan önce kullanýcýya onay sorusu göster
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Kapatmaya emin misiniz?", "Uyarý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;  // Kapanmayý iptal et
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OracleDbHelper dbHelper = new OracleDbHelper();

            using (OracleConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM HASTANE.IL";

                using (OracleCommand command = new OracleCommand(sql, conn))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        comboBox3.Items.Clear();

                        while (reader.Read())
                        {
                            string iladi = reader["ILADI"].ToString();
                            comboBox3.Items.Add(iladi);
                        }
                    }
                }
            }

            //enter tuþu için
            this.KeyPreview = true;

            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

            // Form ayarlarý
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            // FormClosing olayýný baðla
            this.FormClosing += Form1_FormClosing;


            // Kan grubu listesi
            List<string> kanGrubu = new List<string>
            {
                "A Rh+", "A Rh-", "B Rh+", "B Rh-", "AB Rh+", "AB Rh-", "O Rh+", "O Rh-"
            };

            comboBox1.Items.Clear(); // Önceden eklenmiþ deðerleri temizle
            comboBox1.Items.AddRange(kanGrubu.ToArray());

            // Tema seçeneklerini ekle
            cmbTema.Items.Clear();
            cmbTema.Items.Add("Ivory");
            cmbTema.Items.Add("Snow");
            cmbTema.Items.Add("Sky");

            // Kaydedilmiþ temayý yükle
            if (!string.IsNullOrEmpty(Properties.Settings.Default.SelectedTheme))
            {
                cmbTema.SelectedItem = Properties.Settings.Default.SelectedTheme;
                cmbTema_SelectedIndexChanged(null, null); // Manuel olarak olayý tetikle
            }


        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                OracleDbHelper dbHelper = new OracleDbHelper();

                using (OracleConnection conn = dbHelper.GetConnection())
                {

                    {
                        conn.Open();
                        // TC Kimlik Numarasý var mý kontrol et
                        if (string.IsNullOrEmpty(txtTC.Text) || txtTC.Text.Length != 11 || !long.TryParse(txtTC.Text, out long tcKimlikNo))
                        {
                            MessageBox.Show("Geçerli bir 11 haneli TC Kimlik Numarasý giriniz!");
                            return;
                        }

                        else
                        {

                            string query = "SELECT COUNT(*) FROM HASTANE.KIMLIK WHERE TC_KIMLIK_NO = :TC_KIMLIK_NO";
                            using (OracleCommand checkCmd = new OracleCommand(query, conn))
                            {
                                checkCmd.Parameters.Add(":TC_KIMLIK_NO", OracleDbType.Int64).Value = tcKimlikNo;

                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                                if (count > 0)
                                {
                                    MessageBox.Show("Bu TC Kimlik Numarasý zaten mevcut!");
                                    return;
                                }
                                else
                                {

                                    string sql = "INSERT INTO HASTANE.KIMLIK (DOSYA_NO, TC_KIMLIK_NO,ADI, SOYADI,ANNE_ADI,BABA_ADI,DOGUMYER,DOGUM_TAR, CEP_TEL,KAN_GRUBU,CINS,MHALI,EV_ADRESI,IL,ILCE,ACIKLAMA,KRONIK_HASTALIK) " +
                                    "VALUES (KIMSEQ.NEXTVAL ,:TC_KIMLIK_NO, :AD ,:SOYAD, :ANNE_ADI , :BABA_ADI , :DOGUMYER ,:DOGUM_TAR ,:CEP_TEL ,:KAN_GRUBU ,:CINS ,:MHALI ,:EV_ADRESI ,:IL ,:ILCE ,:ACIKLAMA , :KRONIK_HASTALIK)";


                                    using (OracleCommand command = new OracleCommand(sql, conn))
                                    {

                                        command.Parameters.Add(":TC_KIMLIK_NO", OracleDbType.Int64).Value = tcKimlikNo;

                                        if (string.IsNullOrEmpty(txtAdi.Text))
                                        {

                                            MessageBox.Show("Hasta adý boþ kalamaz");
                                            return;
                                        }

                                        else
                                        {
                                            command.Parameters.Add(":ADI", OracleDbType.Varchar2).Value = txtAdi.Text;
                                        }


                                        if (string.IsNullOrEmpty(txtSoyadi.Text))
                                        {
                                            MessageBox.Show("Hasta soyadý boþ kalamaz");
                                            return;
                                        }
                                        else
                                        {
                                            command.Parameters.Add(":SOYADI", OracleDbType.Varchar2).Value = txtSoyadi.Text;

                                        }

                                        command.Parameters.Add(":ANNE_ADI", OracleDbType.Varchar2).Value = txtAnneAdý.Text;
                                        command.Parameters.Add(":BABA_ADI", OracleDbType.Varchar2).Value = txtBabaAdý.Text;
                                        command.Parameters.Add(":DOGUMYER", OracleDbType.Varchar2).Value = txtDogumYeri.Text;

                                        command.Parameters.Add(":DOGUM_TAR", OracleDbType.Varchar2).Value = txtDogumTar.Value.ToString("dd/MM/yyyy");


                                        command.Parameters.Add(":CEP_TEL", OracleDbType.Varchar2).Value = txtCepTel.Text;
                                        command.Parameters.Add(":KAN_GRUBU", OracleDbType.Varchar2).Value = comboBox1.SelectedItem;

                                        command.Parameters.Add(":CINS", OracleDbType.Varchar2);
                                        if (radioBtnKadýn.Checked)
                                        {
                                            command.Parameters[":CINS"].Value = "K";
                                        }
                                        else if (radioBtnErkek.Checked)
                                        {
                                            command.Parameters[":CINS"].Value = "E";
                                        }

                                        command.Parameters.Add(":MHALI", OracleDbType.Varchar2);
                                        if (radioBtnEvli.Checked)
                                        {
                                            command.Parameters[":MHALI"].Value = "E";
                                        }
                                        else if (radioBtnBekar.Checked)
                                        {
                                            command.Parameters[":MHALI"].Value = "B";
                                        }

                                        command.Parameters.Add(":EV_ADRESI", OracleDbType.Varchar2).Value = txtAdres.Text;
                                        command.Parameters.Add(":IL", OracleDbType.Varchar2).Value = comboBox3.SelectedItem;
                                        command.Parameters.Add(":ILCE", OracleDbType.Varchar2).Value = comboBox4.SelectedItem;
                                        command.Parameters.Add(":ACIKLAMA", OracleDbType.Varchar2).Value = txtAciklama.Text;
                                        command.Parameters.Add(":KRONIK_HASTALIK", OracleDbType.Varchar2).Value = txtKronik.Text;


                                        int rowsAffected = command.ExecuteNonQuery(); // Sorguyu çalýþtýr ve etkilenen satýr sayýsýný al

                                        if (rowsAffected > 0)
                                        {
                                            MessageBox.Show("Kayýt baþarýyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                            txtTC.Clear();
                                            txtAdi.Clear();
                                            txtSoyadi.Clear();
                                            txtAnneAdý.Clear();
                                            txtBabaAdý.Clear();
                                            txtAdres.Clear();
                                            txtDogumYeri.Clear();
                                            txtCepTel.Clear();
                                            txtAciklama.Clear();
                                            txtKronik.Clear();
                                            txtAciklama.Clear();
                                            txtKronik.Clear();




                                        }
                                        else
                                        {
                                            MessageBox.Show("Kayýt eklenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA : " + ex.ToString());
            }

        }

        private void btnAra_Click_1(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(txtTCArama.Text) && string.IsNullOrEmpty(txtAdýArama.Text))
            {
                MessageBox.Show("Lütfen TC Kimlik No veya Ad-Soyad Giriniz.");
                return;
            }
            else
            {

                groupBoxHastaBilgi.Visible = true;
                groupBoxKimlik.Visible = false;
                dataGridView1.Visible = true;

            }

            OracleDbHelper dbHelper = new OracleDbHelper();
            using (OracleConnection conn = dbHelper.GetConnection())
            {


                {
                    conn.Open();
                    string sql = "SELECT * FROM HASTANE.KIMLIK WHERE TC_KIMLIK_NO=:TC OR ADI= :AD AND SOYADI =:SOYAD ";



                    {

                        using (OracleCommand command = new OracleCommand(sql, conn))
                        {

                            command.Parameters.Add(new OracleParameter("TC", txtTCArama.Text));
                            command.Parameters.Add(new OracleParameter("AD", txtAdýArama.Text));
                            command.Parameters.Add(new OracleParameter("SOYAD", txtSoyadýArama.Text));
                            using (OracleDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // Verileri deðiþkenlere ata
                                    // HASTA BÝLGÝLERÝ GROUPBOX ÝÇÝN VERÝLERÝ ÇEKME ÝÞLEMLERÝ 


                                    long tc = reader.GetInt64(reader.GetOrdinal("TC_KIMLIK_NO"));

                                    string adýBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("ADI")))
                                    {
                                        adýBilgi = "-";
                                    }
                                    else { adýBilgi = reader.GetString(reader.GetOrdinal("ADI")); }

                                    string soyadýBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("SOYADI")))
                                    {
                                        soyadýBilgi = "-";
                                    }
                                    else { soyadýBilgi = reader.GetString(reader.GetOrdinal("SOYADI")); }

                                    string anneAdýBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("ANNE_ADI")))
                                    {
                                        anneAdýBilgi = "-";
                                    }
                                    else { anneAdýBilgi = reader.GetString(reader.GetOrdinal("ANNE_ADI")); }


                                    string babaAdýBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("BABA_ADI")))
                                    {
                                        babaAdýBilgi = "-";
                                    }
                                    else { babaAdýBilgi = reader.GetString(reader.GetOrdinal("BABA_ADI")); }


                                    string dogumYeriBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("DOGUMYER")))
                                    {
                                        dogumYeriBilgi = "-";
                                    }
                                    else
                                    {
                                        dogumYeriBilgi = reader.GetString(reader.GetOrdinal("DOGUMYER"));
                                    }

                                    string dogumTarihiBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("DOGUM_TAR")))
                                    {
                                        dogumTarihiBilgi = "-";
                                    }
                                    else
                                    {
                                        dogumTarihiBilgi = reader.GetString(reader.GetOrdinal("DOGUM_TAR"));
                                    }

                                    string cepTelBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("CEP_TEL")))
                                    {
                                        cepTelBilgi = "-";
                                    }
                                    else
                                    {
                                        cepTelBilgi = reader.GetString(reader.GetOrdinal("CEP_TEL"));
                                    }




                                    string secilenKanGrubu;
                                    try
                                    {
                                        secilenKanGrubu = reader.GetString(reader.GetOrdinal("KAN_GRUBU")); ;// = comboBox1.SelectedItem?.ToString();

                                    }
                                    catch (Exception err)
                                    {
                                        secilenKanGrubu = "-";
                                    }

                                    if (string.IsNullOrEmpty(secilenKanGrubu))
                                    {
                                        secilenKanGrubu = "-";
                                    }


                                    string cinsiyetBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("CINS")))
                                    {
                                        cinsiyetBilgi = "-";
                                    }
                                    else
                                    {
                                        cinsiyetBilgi = reader.GetString(reader.GetOrdinal("CINS"));

                                        if (cinsiyetBilgi == "K")
                                        {
                                            cinsiyetBilgi = "kadýn";
                                            pictureBox2.BackgroundImage = new System.Drawing.Bitmap("C:\\Users\\DELL\\Desktop\\projeResimler\\kadýn_kullanýcý.png");
                                        }
                                        else
                                        {
                                            cinsiyetBilgi = "erkek";
                                            pictureBox2.BackgroundImage = new System.Drawing.Bitmap("C:\\Users\\DELL\\Desktop\\projeResimler\\erkek_kullanýcý.png");
                                        }
                                    }

                                    string medeniHalBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("MHALI")))
                                    {
                                        medeniHalBilgi = "-";
                                    }
                                    else
                                    {
                                        medeniHalBilgi = reader.GetString(reader.GetOrdinal("MHALI"));
                                    }

                                    string adresBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("EV_ADRESI")))
                                    {
                                        adresBilgi = "-";
                                    }
                                    else
                                    {
                                        adresBilgi = reader.GetString(reader.GetOrdinal("EV_ADRESI"));
                                    }

                                    string ilBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("IL")))
                                    {
                                        ilBilgi = "-";
                                    }
                                    else
                                    {
                                        ilBilgi = reader.GetString(reader.GetOrdinal("IL"));
                                    }

                                    string ilceBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("ILCE")))
                                    {
                                        ilceBilgi = "-";
                                    }
                                    else
                                    {
                                        ilceBilgi = reader.GetString(reader.GetOrdinal("ILCE"));
                                    }

                                    string bilgiAciklama;
                                    if (reader.IsDBNull(reader.GetOrdinal("ACIKLAMA")))
                                    {
                                        bilgiAciklama = "-";
                                    }
                                    else
                                    {
                                        bilgiAciklama = reader.GetString(reader.GetOrdinal("ACIKLAMA"));
                                    }

                                    string bilgiKronik;
                                    if (reader.IsDBNull(reader.GetOrdinal("KRONIK_HASTALIK")))
                                    {
                                        bilgiKronik = "-";
                                    }
                                    else
                                    {
                                        bilgiKronik = reader.GetString(reader.GetOrdinal("KRONIK_HASTALIK"));
                                    }


                                    long dosyaNo = reader.GetInt64(reader.GetOrdinal("DOSYA_NO"));



                                    lblTCbilgi.Text = tc.ToString();
                                    lblAdBilgi.Text = adýBilgi;
                                    lblSoyadBilgi.Text = soyadýBilgi;
                                    lblAnneAdiBilgi.Text = anneAdýBilgi;
                                    lblBabaAdiBilgi.Text = babaAdýBilgi;
                                    lblDogumYeriBilgi.Text = dogumYeriBilgi;
                                    lblDogumTarihiBilgi.Text = dogumTarihiBilgi;
                                    lblCepTelBilgi.Text = cepTelBilgi;
                                    lblKanGrubuBilgi.Text = secilenKanGrubu;
                                    lblCinsiyetBilgi.Text = cinsiyetBilgi;
                                    lblMedeniHalBilgi.Text = medeniHalBilgi;
                                    lblAdresBilgi.Text = adresBilgi;
                                    lblilBilgi.Text = ilBilgi;
                                    lblilçeBilgi.Text = ilceBilgi;
                                    lblBilgiAcýklama.Text = bilgiAciklama;
                                    lblBilgiK.Text = bilgiKronik;
                                    lblDosyaNoo.Text = dosyaNo.ToString();


                                    DateTime dogumTarihi;

                                    if (reader.IsDBNull(reader.GetOrdinal("DOGUM_TAR")))
                                    {
                                        dogumTarihi = DateTime.MinValue;
                                    }
                                    else
                                    {
                                        dogumTarihi = reader.GetDateTime(reader.GetOrdinal("DOGUM_TAR"));
                                    }


                                    if (dogumTarihi != DateTime.MinValue)
                                    {
                                        DateTime bugun = DateTime.Today;


                                        int yas = bugun.Year - dogumTarihi.Year;


                                        if (bugun.Month < dogumTarihi.Month || (bugun.Month == dogumTarihi.Month && bugun.Day < dogumTarihi.Day))
                                        {
                                            yas--;
                                        }

                                        lblBilgiYas.Text = "Yaþý: " + yas.ToString();
                                    }
                                    else
                                    {
                                        lblBilgiYas.Text = "Geçersiz doðum tarihi!";
                                    }

                                }
                            }

                        }


                        FillDataGridView(txtTCArama.Text);

                    }
                }
            }
        }



        private void cmbTema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTema.SelectedItem != null)
            {
                string selectedTheme = cmbTema.SelectedItem.ToString();

                switch (cmbTema.SelectedItem.ToString())

                {

                    case "Ivory":
                        groupBoxKimlik.BackColor = ColorTranslator.FromHtml("#eeeee0");
                        groupBoxHastaBilgi.BackColor = ColorTranslator.FromHtml("#eeeee0");
                        sideBar.BackColor = ColorTranslator.FromHtml("#cdcdc1");
                        groupBoxAra.BackColor = ColorTranslator.FromHtml("#eeeee0");
                        Form1.ActiveForm.BackColor = ColorTranslator.FromHtml("#fffff0");

                        btnVezne.BackColor = ColorTranslator.FromHtml("#eeeee0");
                        btnOdemeGecmisi.BackColor = ColorTranslator.FromHtml("#eeeee0");
                        btnMuayene.BackColor = ColorTranslator.FromHtml("#eeeee0");
                        btnTani.BackColor = ColorTranslator.FromHtml("#eeeee0");
                        btnRecete.BackColor = ColorTranslator.FromHtml("#eeeee0");
                        btnGebelikTakibi.BackColor = ColorTranslator.FromHtml("#eeeee0");


                        btnHasta.BackColor = ColorTranslator.FromHtml("#cdcdc1");
                        btnDoktor.BackColor = ColorTranslator.FromHtml("#cdcdc1");
                        btnHemsire.BackColor = ColorTranslator.FromHtml("#cdcdc1");
                        flowPanelHasta.BackColor = ColorTranslator.FromHtml("#cdcdc1");
                        flowPanelHemsire.BackColor = ColorTranslator.FromHtml("#cdcdc1");
                        flowPanelDoktor.BackColor = ColorTranslator.FromHtml("#cdcdc1");

                        dataGridView1.BackgroundColor = ColorTranslator.FromHtml("#eeeee0");

                        pictureBox1.Dock = DockStyle.None;
                        pictureBox1.Anchor = AnchorStyles.None;
                        pictureBox1.Size = new Size(118, 100);
                        pictureBox1.Location = new Point(532, 15);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.BackgroundImage = new System.Drawing.Bitmap("C:\\Users\\DELL\\Desktop\\projeResimler\\ývory.png");
                        break;

                    case "Snow":
                        groupBoxKimlik.BackColor = ColorTranslator.FromHtml("#eee9e9");
                        groupBoxHastaBilgi.BackColor = ColorTranslator.FromHtml("#eee9e9");
                        sideBar.BackColor = ColorTranslator.FromHtml("#cdc9c9");
                        groupBoxAra.BackColor = ColorTranslator.FromHtml("#eee9e9");
                        Form1.ActiveForm.BackColor = ColorTranslator.FromHtml("#fffafa");

                        btnVezne.BackColor = ColorTranslator.FromHtml("#eee9e9");
                        btnOdemeGecmisi.BackColor = ColorTranslator.FromHtml("#eee9e9");
                        btnMuayene.BackColor = ColorTranslator.FromHtml("#eee9e9");
                        btnTani.BackColor = ColorTranslator.FromHtml("#eee9e9");
                        btnRecete.BackColor = ColorTranslator.FromHtml("#eee9e9");
                        btnGebelikTakibi.BackColor = ColorTranslator.FromHtml("#eee9e9");

                        dataGridView1.BackgroundColor = ColorTranslator.FromHtml("#eee9e9");

                        btnHasta.BackColor = ColorTranslator.FromHtml("#cdc9c9");
                        btnDoktor.BackColor = ColorTranslator.FromHtml("#cdc9c9");
                        btnHemsire.BackColor = ColorTranslator.FromHtml("#cdc9c9");
                        flowPanelHasta.BackColor = ColorTranslator.FromHtml("#cdc9c9");
                        flowPanelHemsire.BackColor = ColorTranslator.FromHtml("#cdc9c9");
                        flowPanelDoktor.BackColor = ColorTranslator.FromHtml("#cdc9c9");

                        pictureBox1.Dock = DockStyle.None;
                        pictureBox1.Anchor = AnchorStyles.None;
                        pictureBox1.Size = new Size(118, 100);
                        pictureBox1.Location = new Point(532, 15);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.BackgroundImage = new System.Drawing.Bitmap("C:\\Users\\DELL\\Desktop\\projeResimler\\snow.png");
                        break;

                    case "Sky":

                        //175; 190; 210 
                        groupBoxKimlik.BackColor = ColorTranslator.FromHtml("#F2F8FB");
                        groupBoxHastaBilgi.BackColor = ColorTranslator.FromHtml("#F2F8FB");
                        sideBar.BackColor = Color.FromArgb(190, 200, 215);
                        groupBoxAra.BackColor = ColorTranslator.FromHtml("#F2F8FB");
                        Form1.ActiveForm.BackColor = ColorTranslator.FromHtml("#FFFFFF");

                        btnVezne.BackColor = ColorTranslator.FromHtml("#F2F8FB");
                        btnOdemeGecmisi.BackColor = ColorTranslator.FromHtml("#F2F8FB");
                        btnMuayene.BackColor = ColorTranslator.FromHtml("#F2F8FB");
                        btnTani.BackColor = ColorTranslator.FromHtml("#F2F8FB");
                        btnRecete.BackColor = ColorTranslator.FromHtml("#F2F8FB");
                        btnGebelikTakibi.BackColor = ColorTranslator.FromHtml("#F2F8FB");

                        btnHasta.BackColor = Color.FromArgb(190, 200, 215);
                        btnDoktor.BackColor = Color.FromArgb(190, 200, 215);
                        btnHemsire.BackColor = Color.FromArgb(190, 200, 215);
                        flowPanelHasta.BackColor = Color.FromArgb(190, 200, 215);
                        flowPanelHemsire.BackColor = Color.FromArgb(190, 200, 215);
                        flowPanelDoktor.BackColor = Color.FromArgb(190, 200, 215);


                        dataGridView1.BackgroundColor = ColorTranslator.FromHtml("#F2F8FB");

                        pictureBox1.Dock = DockStyle.None;
                        pictureBox1.Anchor = AnchorStyles.None;
                        pictureBox1.Size = new Size(130, 120);
                        pictureBox1.Location = new Point(532, 15);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.BackgroundImage = new System.Drawing.Bitmap("C:\\Users\\DELL\\Desktop\\projeResimler\\mavi.png");
                        break;

                    default:
                        this.BackColor = SystemColors.Control;
                        break;
                }

                Properties.Settings.Default.SelectedTheme = selectedTheme;
                Properties.Settings.Default.Save();


            }
        }

        private void txtCepTel_Click(object sender, EventArgs e)
        {

            DateTime dogumTarihi = txtDogumTar.Value;

            DateTime bugun = DateTime.Today;

            int yas = bugun.Year - dogumTarihi.Year;

            if (bugun.Month < dogumTarihi.Month || (bugun.Month == dogumTarihi.Month && bugun.Day < dogumTarihi.Day))
            {
                yas--;
            }

            lblYas.Text = "Yaþý: " + yas.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleDbHelper dbHelper = new OracleDbHelper();
            {
                comboBox4.Items.Clear();

                // Baðlantýyý açýyoruz
                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string il = comboBox3.SelectedItem.ToString();
                    string sql1 = "SELECT KODU FROM HASTANE.IL WHERE ILADI=:IL";

                    using (OracleCommand command = new OracleCommand(sql1, connection))
                    {
                        command.Parameters.Add(new OracleParameter("IL", il));
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) // Verileri satýr satýr oku
                            {
                                string kodu = reader["KODU"].ToString();
                                string sql2 = "SELECT ILCEADI FROM HASTANE.ILCE WHERE ILKODU=:ILKODU";
                                using (OracleCommand command2 = new OracleCommand(sql2, connection))
                                {
                                    command2.Parameters.Add(new OracleParameter("ILKODU", kodu));
                                    using (OracleDataReader reader2 = command2.ExecuteReader())
                                    {
                                        while (reader2.Read())
                                        {
                                            string ilceAdi = reader2["ILCEADI"].ToString();

                                            comboBox4.Items.Add(ilceAdi);
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            btnKaydet.Visible = false;
            btnGuncelle.Visible = true;
            OracleDbHelper dbHelper = new OracleDbHelper();
            groupBoxHastaBilgi.Visible = false;
            groupBoxKimlik.Visible = true;
            using (OracleConnection conn = dbHelper.GetConnection())
            {

                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM HASTANE.KIMLIK WHERE TC_KIMLIK_NO=:TC OR ADI= :AD AND SOYADI =:SOYAD ";


                    try
                    {

                        using (OracleCommand command = new OracleCommand(sql, conn))
                        {

                            command.Parameters.Add(new OracleParameter("TC", txtTCArama.Text));
                            command.Parameters.Add(new OracleParameter("AD", txtAdýArama.Text));
                            command.Parameters.Add(new OracleParameter("SOYAD", txtSoyadýArama.Text));
                            using (OracleDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // Verileri deðiþkenlere ata
                                    // HASTA BÝLGÝLERÝ GROUPBOX ÝÇÝN VERÝLERÝ ÇEKME ÝÞLEMLERÝ 


                                    long tc = reader.GetInt64(reader.GetOrdinal("TC_KIMLIK_NO"));

                                    string adýBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("ADI")))
                                    {
                                        adýBilgi = "-";
                                    }
                                    else { adýBilgi = reader.GetString(reader.GetOrdinal("ADI")); }

                                    string soyadýBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("SOYADI")))
                                    {
                                        soyadýBilgi = "-";
                                    }
                                    else { soyadýBilgi = reader.GetString(reader.GetOrdinal("SOYADI")); }

                                    string anneAdýBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("ANNE_ADI")))
                                    {
                                        anneAdýBilgi = "-";
                                    }
                                    else { anneAdýBilgi = reader.GetString(reader.GetOrdinal("ANNE_ADI")); }


                                    string babaAdýBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("BABA_ADI")))
                                    {
                                        babaAdýBilgi = "-";
                                    }
                                    else { babaAdýBilgi = reader.GetString(reader.GetOrdinal("BABA_ADI")); }


                                    string dogumYeriBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("DOGUMYER")))
                                    {
                                        dogumYeriBilgi = "-";
                                    }
                                    else
                                    {
                                        dogumYeriBilgi = reader.GetString(reader.GetOrdinal("DOGUMYER"));
                                    }

                                    string dogumTarihiBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("DOGUM_TAR")))
                                    {
                                        dogumTarihiBilgi = "-";
                                    }
                                    else
                                    {
                                        dogumTarihiBilgi = reader.GetString(reader.GetOrdinal("DOGUM_TAR"));
                                    }

                                    string cepTelBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("CEP_TEL")))
                                    {
                                        cepTelBilgi = "-";
                                    }
                                    else
                                    {
                                        cepTelBilgi = reader.GetString(reader.GetOrdinal("CEP_TEL"));
                                    }




                                    string secilenKanGrubu;

                                    if (reader.IsDBNull(reader.GetOrdinal("KAN_GRUBU")))
                                    {
                                        secilenKanGrubu = "-";
                                    }
                                    else
                                    {
                                        secilenKanGrubu = reader.GetString(reader.GetOrdinal("KAN_GRUBU"));
                                    }


                                    //comboBox1.SelectedItem = secilenKanGrubu;

                                    string cinsiyetBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("CINS")))
                                    {
                                        cinsiyetBilgi = "-";
                                    }
                                    else
                                    {
                                        cinsiyetBilgi = reader.GetString(reader.GetOrdinal("CINS"));

                                        if (cinsiyetBilgi == "K")
                                        {
                                            // Kadýn için radyo butonunu iþaretle
                                            radioBtnKadýn.Checked = true;
                                            radioBtnErkek.Checked = false;
                                        }
                                        else
                                        {
                                            // Erkek için radyo butonunu iþaretle
                                            radioBtnKadýn.Checked = false;
                                            radioBtnErkek.Checked = true;
                                        }
                                    }

                                    // Medeni Hal bilgisi, label yerine baþka bir yerde kullanabilirsiniz
                                    string medeniHalBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("MHALI")))
                                    {
                                        medeniHalBilgi = "-";
                                    }
                                    else
                                    {
                                        medeniHalBilgi = reader.GetString(reader.GetOrdinal("MHALI"));
                                    }

                                    // Eðer medeni hal de radyo butonlarýyla gösterilecekse:
                                    if (medeniHalBilgi == "E")
                                    {
                                        radioBtnEvli.Checked = true;  // Evli için radyo butonunu iþaretle
                                        radioBtnBekar.Checked = false;
                                    }
                                    else
                                    {
                                        radioBtnEvli.Checked = false;
                                        radioBtnBekar.Checked = true; // Bekar için radyo butonunu iþaretle
                                    }

                                    string adresBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("EV_ADRESI")))
                                    {
                                        adresBilgi = "-";
                                    }
                                    else
                                    {
                                        adresBilgi = reader.GetString(reader.GetOrdinal("EV_ADRESI"));
                                    }

                                    string ilBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("IL")))
                                    {
                                        ilBilgi = "-";
                                    }
                                    else
                                    {
                                        ilBilgi = reader.GetString(reader.GetOrdinal("IL"));
                                    }

                                    string ilceBilgi;
                                    if (reader.IsDBNull(reader.GetOrdinal("ILCE")))
                                    {
                                        ilceBilgi = "-";
                                    }
                                    else
                                    {
                                        ilceBilgi = reader.GetString(reader.GetOrdinal("ILCE"));
                                    }

                                    string bilgiAciklama;
                                    if (reader.IsDBNull(reader.GetOrdinal("ACIKLAMA")))
                                    {
                                        bilgiAciklama = "-";
                                    }
                                    else
                                    {
                                        bilgiAciklama = reader.GetString(reader.GetOrdinal("ACIKLAMA"));
                                    }

                                    string bilgiKronik;
                                    if (reader.IsDBNull(reader.GetOrdinal("KRONIK_HASTALIK")))
                                    {
                                        bilgiKronik = "-";
                                    }
                                    else
                                    {
                                        bilgiKronik = reader.GetString(reader.GetOrdinal("KRONIK_HASTALIK"));
                                    }

                                    txtTC.Text = tc.ToString();
                                    txtAdi.Text = adýBilgi;
                                    txtSoyadi.Text = soyadýBilgi;
                                    txtAnneAdý.Text = anneAdýBilgi;
                                    txtBabaAdý.Text = babaAdýBilgi;
                                    txtDogumYeri.Text = dogumYeriBilgi;
                                    txtDogumTar.Text = dogumTarihiBilgi;
                                    txtCepTel.Text = cepTelBilgi;
                                    comboBox1.Text = secilenKanGrubu;
                                    lblCinsiyetBilgi.Text = cinsiyetBilgi;
                                    lblMedeniHalBilgi.Text = medeniHalBilgi;
                                    txtAdres.Text = adresBilgi;
                                    comboBox3.Text = ilBilgi;
                                    comboBox4.Text = ilceBilgi;
                                    txtAciklama.Text = bilgiAciklama;
                                    txtKronik.Text = bilgiKronik;


                                    // Yaþý lblYas yazdýrma
                                    DateTime dogumTarihi;

                                    if (reader.IsDBNull(reader.GetOrdinal("DOGUM_TAR")))
                                    {
                                        dogumTarihi = DateTime.MinValue;
                                    }
                                    else
                                    {
                                        dogumTarihi = reader.GetDateTime(reader.GetOrdinal("DOGUM_TAR"));
                                    }


                                    if (dogumTarihi != DateTime.MinValue)
                                    {
                                        DateTime bugun = DateTime.Today;


                                        int yas = bugun.Year - dogumTarihi.Year;


                                        if (bugun.Month < dogumTarihi.Month || (bugun.Month == dogumTarihi.Month && bugun.Day < dogumTarihi.Day))
                                        {
                                            yas--;
                                        }

                                        lblBilgiYas.Text = "Yaþý: " + yas.ToString();
                                    }
                                    else
                                    {
                                        lblBilgiYas.Text = "Geçersiz doðum tarihi!";
                                    }

                                }
                            }

                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("hata : " + ex.Message);
                }

            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            {
                OracleDbHelper dbHelper = new OracleDbHelper();

                using (OracleConnection conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "UPDATE HASTANE.KIMLIK SET " +
                                 "DOSYA_NO = KIMSEQ.NEXTVAL," +
                                 "ADI = :ADI, " +
                                 "SOYADI = :SOYADI, " +
                                 "ANNE_ADI = :ANNE_ADI, " +
                                 "BABA_ADI = :BABA_ADI, " +
                                 "DOGUMYER = :DOGUMYER, " +
                                 "DOGUM_TAR = TO_DATE(:DOGUM_TAR, 'DD/MM/YYYY'), " +
                                 "CEP_TEL = :CEP_TEL, " +
                                 "KAN_GRUBU = :KAN_GRUBU, " +
                                 "CINS = :CINS, " +
                                 "MHALI = :MHALI, " +
                                 "EV_ADRESI = :EV_ADRESI, " +
                                 "IL = :IL, " +
                                 "ILCE = :ILCE, " +
                                 "ACIKLAMA = :ACIKLAMA, " +
                                 "KRONIK_HASTALIK = :KRONIK_HASTALIK " +
                                 "WHERE TC_KIMLIK_NO = :TC_KIMLIK_NO";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        try
                        {

                            if (string.IsNullOrEmpty(txtTC.Text) || txtTC.Text.Length != 11)
                            {
                                MessageBox.Show("Geçerli bir 11 haneli TC Kimlik Numarasý giriniz!");
                                return;
                            }
                            else
                            {
                                cmd.Parameters.Add(":TC_KIMLIK_NO", OracleDbType.Int64).Value = Convert.ToInt64(txtTC.Text);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString()); return;
                        }


                        if (string.IsNullOrEmpty(txtAdi.Text))
                        {
                            MessageBox.Show("Hasta adý boþ kalamaz");
                            return;
                        }
                        cmd.Parameters.Add(":ADI", OracleDbType.Varchar2).Value = txtAdi.Text;

                        if (string.IsNullOrEmpty(txtSoyadi.Text))
                        {
                            MessageBox.Show("Hasta soyadý boþ kalamaz");
                            return;
                        }
                        cmd.Parameters.Add(":SOYADI", OracleDbType.Varchar2).Value = txtSoyadi.Text;

                        cmd.Parameters.Add(":ANNE_ADI", OracleDbType.Varchar2).Value = txtAnneAdý.Text;
                        cmd.Parameters.Add(":BABA_ADI", OracleDbType.Varchar2).Value = txtBabaAdý.Text;
                        cmd.Parameters.Add(":DOGUMYER", OracleDbType.Varchar2).Value = txtDogumYeri.Text;
                        cmd.Parameters.Add(":DOGUM_TAR", OracleDbType.Varchar2).Value = txtDogumTar.Value.ToString("dd/MM/yyyy");
                        cmd.Parameters.Add(":CEP_TEL", OracleDbType.Varchar2).Value = txtCepTel.Text;
                        cmd.Parameters.Add(":KAN_GRUBU", OracleDbType.Varchar2).Value = comboBox1.SelectedItem;

                        cmd.Parameters.Add(":CINS", OracleDbType.Varchar2);
                        if (radioBtnKadýn.Checked)
                        {
                            cmd.Parameters[":CINS"].Value = "K";
                        }
                        else if (radioBtnErkek.Checked)
                        {
                            cmd.Parameters[":CINS"].Value = "E";
                        }

                        cmd.Parameters.Add(":MHALI", OracleDbType.Varchar2);
                        if (radioBtnEvli.Checked)
                        {
                            cmd.Parameters[":MHALI"].Value = "E";
                        }
                        else if (radioBtnBekar.Checked)
                        {
                            cmd.Parameters[":MHALI"].Value = "B";
                        }

                        cmd.Parameters.Add(":EV_ADRESI", OracleDbType.Varchar2).Value = txtAdres.Text;
                        cmd.Parameters.Add(":IL", OracleDbType.Varchar2).Value = comboBox3.SelectedItem;
                        cmd.Parameters.Add(":ILCE", OracleDbType.Varchar2).Value = comboBox4.SelectedItem;
                        cmd.Parameters.Add(":ACIKLAMA", OracleDbType.Varchar2).Value = txtAciklama.Text;
                        cmd.Parameters.Add(":KRONIK_HASTALIK", OracleDbType.Varchar2).Value = txtKronik.Text;

                        try
                        {
                            cmd.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata oluþtu: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string dosyaNo = lblDosyaNoo.Text;
            FormYeniTakip yeniTakipFormu = new FormYeniTakip(dosyaNo); // Parametreli constructor ile açýyoruz
            yeniTakipFormu.ShowDialog();

        }

        private void flowPanelHastaTrans_Tick(object sender, EventArgs e)
        {
            if (!menuExpandHasta == false)
            {
                flowPanelHasta.Height += 10;
                if (flowPanelHasta.Height >= 128)
                {

                    flowPanelHastaTrans.Stop();
                    menuExpandHasta = true;
                }
            }
            else
            {
                flowPanelHasta.Height -= 10;
                if (flowPanelHasta.Height <= 45)
                {
                    flowPanelHastaTrans.Stop();
                    menuExpandHasta = false;

                }
            }
        }

        private void btnHasta_Click(object sender, EventArgs e)
        {
            menuExpandHasta = !menuExpandHasta;
            flowPanelHastaTrans.Start();
        }

        bool sideBarExpand = true;
        private void sideBarTransition_Tick(object sender, EventArgs e)
        {
            if (sideBarExpand)
            {
                sideBar.Width -= 10;
                if (sideBar.Width <= 58)
                {
                    sideBarExpand = false;
                    sideBarTransition.Stop();
                }
            }
            else
            {
                sideBar.Width += 10;
                if (sideBar.Width >= 231)
                {
                    sideBarExpand = true;
                    sideBarTransition.Stop();
                }
            }
        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            if (sideBar.Width <= 58)
            {
                groupBoxHastaBilgi.Location = new Point(264, 103);
                groupBoxKimlik.Location = new Point(264, 103);
                dataGridView1.Location = new Point(980, 103);
            }
            else
            {
                groupBoxHastaBilgi.Location = new Point(90, 103);
                groupBoxKimlik.Location = new Point(90, 103);
                dataGridView1.Location = new Point(803, 103);
            }

            if (menuExpandHemsire)
            {
                menuExpandHemsire = false;
                flowPanelHemsireTrans.Start();
            }

            if (menuExpandDoktor)
            {
                menuExpandDoktor = false;
                flowPanelDoktorTrans.Start();
            }


            if (menuExpandHasta)
            {
                menuExpandHasta = false;
                flowPanelHastaTrans.Start();
            }

            sideBarTransition.Start();

        }

        private void flowPanelHemsireTrans_Tick(object sender, EventArgs e)
        {
            if (!menuExpandHemsire == false)
            {
                flowPanelHemsire.Height += 10;
                if (flowPanelHemsire.Height >= 88)
                {

                    flowPanelHemsireTrans.Stop();
                    menuExpandHemsire = true;
                }
            }
            else
            {
                flowPanelHemsire.Height -= 10;
                if (flowPanelHemsire.Height <= 45)
                {
                    flowPanelHemsireTrans.Stop();
                    menuExpandHemsire = false;

                }
            }

        }

        private void btnHemsire_Click(object sender, EventArgs e)
        {
            menuExpandHemsire = !menuExpandHemsire;
            flowPanelHemsireTrans.Start();
        }

        private void flowPanelDoktorTrans_Tick(object sender, EventArgs e)
        {
            if (!menuExpandDoktor == false)
            {
                flowPanelDoktor.Height += 10;
                if (flowPanelDoktor.Height >= 171)
                {

                    flowPanelDoktorTrans.Stop();
                    menuExpandDoktor = true;
                }
            }
            else
            {
                flowPanelDoktor.Height -= 10;
                if (flowPanelDoktor.Height <= 45)
                {
                    flowPanelDoktorTrans.Stop();
                    menuExpandDoktor = false;

                }
            }
        }

        private void btnDoktor_Click(object sender, EventArgs e)
        {
            menuExpandDoktor = !menuExpandDoktor;
            flowPanelDoktorTrans.Start();
        }

        private void btnYeniHasta_Click(object sender, EventArgs e)
        {
            groupBoxKimlik.Visible = true;
            groupBoxHastaBilgi.Visible = false;
            dataGridView1.Visible = false;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRecete_Click(object sender, EventArgs e)
        {

            FormRecete receteForm = new FormRecete(lblTCbilgi.Text, lblAdBilgi.Text, lblSoyadBilgi.Text);
            receteForm.Show();

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)  // Enter tuþuna basýldýðýnda
            {
                btnAra_Click_1(sender, e); // Ara butonunun click olayýný çaðýr
                e.SuppressKeyPress = true; // Enter tuþunun formda baþka bir etki yaratmasýný engelle
            }
        }
        private void FillDataGridView(string tcKimlikNo)
        {

            OracleDbHelper dbHelper = new OracleDbHelper();
            {
                using (OracleConnection conn = dbHelper.GetConnection())
                {
                    conn.Open();

                    string sql2 = "SELECT k.DOSYA_NO, p.PROTOKOL_NO, p.GTARIH, b.BOLUM_ADI, i.ODENEN, i.KALAN, d.ADI_SOYADI " +
                          "FROM HASTANE.KIMLIK k, HASTANE.PROTOKOL p, HASTANE.BOLUM b, HASTANE.ISLEMYAP i, HASTANE.DRADI d " +
                          "WHERE p.dosya_no = k.dosya_no(+) " +
                          "AND p.bolum = b.bolum(+) " +
                          "AND p.protokol_no = i.protokol_no(+) " +
                          "AND d.bolum = b.bolum " +
                          "AND k.TC_KIMLIK_NO = :TC";

                    using (OracleCommand cmd = new OracleCommand(sql2, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("TC", tcKimlikNo));

                        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            decimal toplamOdenen = 0;
                            decimal toplamKalan = 0;

                            foreach (DataRow row in dataTable.Rows)
                            {
                                if (!Convert.IsDBNull(row["ODENEN"]))
                                    toplamOdenen += Convert.ToDecimal(row["ODENEN"]);

                                if (!Convert.IsDBNull(row["KALAN"]))
                                    toplamKalan += Convert.ToDecimal(row["KALAN"]);
                            }

                            DataRow baslikRow = dataTable.NewRow();
                            baslikRow["ODENEN"] = DBNull.Value;
                            baslikRow["KALAN"] = DBNull.Value;

                            dataTable.Rows.Add(baslikRow); // Baþlýk satýrýný ekle

                            DataRow toplamRow = dataTable.NewRow();
                            toplamRow["ODENEN"] = toplamOdenen;
                            toplamRow["KALAN"] = toplamKalan;

                            dataTable.Rows.Add(toplamRow); // Yeni satýrý ekle

                            dataGridView1.DataSource = dataTable;
                            dataGridView1.AllowUserToAddRows = false;
                            dataGridView1.RowHeadersVisible = false;

                            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
                            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;

                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                if (i % 2 == 0)
                                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fbf2fb");
                                else
                                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f8fbf2");

                                if (dataTable.Columns.Count > 0)
                                {
                                    dataGridView1.Columns[0].HeaderText = "PROTOKOL";
                                    dataGridView1.Columns[0].DataPropertyName = "PROTOKOL_NO";

                                    dataGridView1.Columns[1].HeaderText = "DOSYA NO";
                                    dataGridView1.Columns[1].DataPropertyName = "DOSYA_NO";

                                    dataGridView1.Columns[2].HeaderText = "GELIS TARIHI";
                                    dataGridView1.Columns[2].DataPropertyName = "GTARIH";
                                    dataGridView1.Columns[2].DefaultCellStyle.Format = "dd-MM-yyyy";

                                    dataGridView1.Columns[3].HeaderText = "POLIKINLIK";
                                    dataGridView1.Columns[3].DataPropertyName = "BOLUM_ADI";

                                    dataGridView1.Columns[4].HeaderText = "DOKTOR ADI";
                                    dataGridView1.Columns[4].DataPropertyName = "ADI_SOYADI";

                                    dataGridView1.Columns[5].HeaderText = "ÖDENEN";
                                    dataGridView1.Columns[5].DataPropertyName = "ODENEN";

                                    dataGridView1.Columns[6].HeaderText = "KALAN";
                                    dataGridView1.Columns[6].DataPropertyName = "KALAN";
                                }
                            }

                            // Kolon sýralamalarýný sabitle
                            dataGridView1.Columns[0].DisplayIndex = 0;
                            dataGridView1.Columns[1].DisplayIndex = 1;
                            dataGridView1.Columns[2].DisplayIndex = 2;
                            dataGridView1.Columns[3].DisplayIndex = 3;
                            dataGridView1.Columns[4].DisplayIndex = 4;
                            dataGridView1.Columns[5].DisplayIndex = 5;
                            dataGridView1.Columns[6].DisplayIndex = 6;

                            // Kolon geniþlikleri
                            dataGridView1.Columns[0].Width = 90;
                            dataGridView1.Columns[1].Width = 70;
                            dataGridView1.Columns[2].Width = 100;
                            dataGridView1.Columns[3].Width = 230;
                            dataGridView1.Columns[4].Width = 210;
                            dataGridView1.Columns[5].Width = 80;
                            dataGridView1.Columns[6].Width = 70;
                        }
                    }
                }

            }
        }
    }
}