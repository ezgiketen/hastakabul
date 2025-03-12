using Oracle.ManagedDataAccess.Client;
using OracleDatabaseConnectionExample;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace PROJE
{
    public partial class FormGebelikTakip : Form
    {

        public int dosyaNo { get; set; }
        public int protokolNo { get; set; }
        public string hastaAdi { get; set; }
        public string hastaSoyadi { get; set; }
        public long tcKimlikNo { get; set; }
        public string tema { get; set; }

        public FormGebelikTakip()
        {
            InitializeComponent();
        }

        private void FormGebelikTakip_Load(object sender, EventArgs e)
        {

            if (VerilerMevcut())
            {
                DisableControls();
                btnKaydet.Visible = false;
                btnDuzenle.Visible = true;
            }
            else
            {
                EnableControls();
                btnKaydet.Visible = true;
                btnDuzenle.Visible = false;
            }

            btnGuncelle.Visible = false;


            OracleDbHelper dbHelper = new OracleDbHelper();
            using (OracleConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                LoadDataIntoForm(dosyaNo, conn);
            }

            if (tema == "Sky")
            {
                this.BackColor = ColorTranslator.FromHtml("#F2F8FB");
            }

            else if (tema == "Ivory")
            {
                this.BackColor = ColorTranslator.FromHtml("#eeeee0");
            }

            else if (tema == "Snow")
            {
                this.BackColor = ColorTranslator.FromHtml("#eee9e9");
            }

            this.WindowState = FormWindowState.Maximized;

            lblAdSoyad.Text = hastaAdi + " " + hastaSoyadi;
            lblDosyaNo.Text = dosyaNo.ToString();
            lblTC.Text = tcKimlikNo.ToString();



            string[] korunmaYontemleri = {
            "Takvim Yöntemi",
            "Geri Çekme Yöntemi",
            "Doğum Kontrol Hapı",
            "Doğum Kontrol İğnesi",
            "Hormonlu Spiral (Mirena, Kyleena)",
            "Bakır Spiral (Hormonsuz RİA)"
              };

            cmbKorunma.Items.AddRange(korunmaYontemleri);

            string[] akrabalık = {

            "2.Derece" , "3.Derece", "Uzak Akraba", "Akrabalık Yok"

            };
            cmbAkrabalık.Items.AddRange(akrabalık);

            string[] dogumSekli = {
            "Normal Doğum" ,"Sezaryen", "Evde Doğum", "Suda Doğum"

            };
            cmbSonDogumSekil.Items.AddRange(dogumSekli);


            string[] kanGrubu =
            {
                "A Rh+", "A Rh-", "B Rh+", "B Rh-", "AB Rh+", "AB Rh-", "O Rh+", "O Rh-"
            };

            cmbKan.Items.AddRange(kanGrubu);
            cmbKanEs.Items.AddRange(kanGrubu);

            this.Load += new System.EventHandler(this.FormGebelikTakip_Load);

        }

        private void btnYeniTakip_Click(object sender, EventArgs e)
        {

            FormGebelikYeniTakip gebelikYeniTakipForm = new FormGebelikYeniTakip(dosyaNo, protokolNo);

            gebelikYeniTakipForm.Show();
        }



        public void Yenile(int protokolNo)
        {

            OracleDbHelper dbHelper = new OracleDbHelper();
            using (OracleConnection conn = dbHelper.GetConnection())
            {
                conn.Open();

                string sql2 = "SELECT IZLEM_ID, DOSYA_NO, PROTOKOL_NO, BAS_AGRISI, BAS_DONMESI, KILO, ODEM, KANAMA, BULANTI, " +
                              "KACINCI_HAFTA, RISK_DURUMU, DEMIR_DESTEGI, D_VITAMIN_DESTEGI, HEMOGLOBIN, IDRARDA_PROTEIN, NOTLAR " +
                              "FROM HASTANE.PROJE_GEBE_TAKIP " +
                              "WHERE PROTOKOL_NO = :protokolNo";

                using (OracleCommand cmd = new OracleCommand(sql2, conn))
                {

                    cmd.Parameters.Add(":protokolNo", OracleDbType.Int32).Value = protokolNo;

                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gebeGrid.DataSource = dt;

                    gebeGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    gebeGrid.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#008b45");
                    gebeGrid.DefaultCellStyle.SelectionForeColor = Color.White;



                    for (int i = 0; i < gebeGrid.Rows.Count; i++)
                    {

                        if (i % 2 == 0)
                            gebeGrid.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fbf2fb");
                        else
                            gebeGrid.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f8fbf2");

                        gebeGrid.Columns[0].HeaderText = "İZLEM ID"; 
                        gebeGrid.Columns[0].DataPropertyName = "IZLEM_ID"; 

                        gebeGrid.Columns[1].HeaderText = "DOSYA NO";
                        gebeGrid.Columns[1].DataPropertyName = "DOSYA_NO";

                        gebeGrid.Columns[2].HeaderText = "PROTOKOL NO";
                        gebeGrid.Columns[2].DataPropertyName = "PROTOKOL_NO";

                        gebeGrid.Columns[3].HeaderText = "BAŞ AĞRISI";
                        gebeGrid.Columns[3].DataPropertyName = "BAS_AGRISI";

                        gebeGrid.Columns[4].HeaderText = "BAŞ DÖNMESİ";
                        gebeGrid.Columns[4].DataPropertyName = "BAS_DONMESI";

                        gebeGrid.Columns[5].HeaderText = "KİLO";
                        gebeGrid.Columns[5].DataPropertyName = "KILO";

                        gebeGrid.Columns[6].HeaderText = "ÖDEM";
                        gebeGrid.Columns[6].DataPropertyName = "ODEM";

                        gebeGrid.Columns[7].HeaderText = "KANAMA";
                        gebeGrid.Columns[7].DataPropertyName = "KANAMA";

                        gebeGrid.Columns[8].HeaderText = "BULANTI";
                        gebeGrid.Columns[8].DataPropertyName = "BULANTI";

                        gebeGrid.Columns[9].HeaderText = "KACINCI HAFTA";
                        gebeGrid.Columns[9].DataPropertyName = "KACINCI_HAFTA";

                        gebeGrid.Columns[10].HeaderText = "RİSK DURUMU";
                        gebeGrid.Columns[10].DataPropertyName = "RISK_DURUMU";

                        gebeGrid.Columns[11].HeaderText = "DEMİR DESTEKİ";
                        gebeGrid.Columns[11].DataPropertyName = "DEMIR_DESTEGI";

                        gebeGrid.Columns[12].HeaderText = "D VİTAMİN DESTEKİ";
                        gebeGrid.Columns[12].DataPropertyName = "D_VITAMIN_DESTEGI";

                        gebeGrid.Columns[13].HeaderText = "HEMOGLOBİN";
                        gebeGrid.Columns[13].DataPropertyName = "HEMOGLOBIN";

                        gebeGrid.Columns[14].HeaderText = "IDRARDA PROTEİN";
                        gebeGrid.Columns[14].DataPropertyName = "IDRARDA_PROTEIN";

                        gebeGrid.Columns[15].HeaderText = "NOTLAR";
                        gebeGrid.Columns[15].DataPropertyName = "NOTLAR";
                    }
                }


                gebeGrid.Columns[0].Width = 70;
                gebeGrid.Columns[1].Width = 85;
                gebeGrid.Columns[2].Width = 80;
                gebeGrid.Columns[3].Width = 80;
                gebeGrid.Columns[4].Width = 80;
                gebeGrid.Columns[5].Width = 80;
                gebeGrid.Columns[6].Width = 75;
                gebeGrid.Columns[7].Width = 80;
                gebeGrid.Columns[8].Width = 110;
                gebeGrid.Columns[9].Width = 110;
                gebeGrid.Columns[10].Width = 110;
                gebeGrid.Columns[11].Width = 110;
                gebeGrid.Columns[12].Width = 110;
                gebeGrid.Columns[13].Width = 110;
                gebeGrid.Columns[14].Width = 230;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox4.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox1.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                checkBox6.Checked = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                checkBox5.Checked = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                checkBox8.Checked = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                checkBox7.Checked = false;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                checkBox10.Checked = false;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                checkBox9.Checked = false;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                checkBox12.Checked = false;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                checkBox11.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox3.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox2.Checked = false;
            }
        }
        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked)
            {
                checkBox13.Checked = false;
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked)
            {
                checkBox14.Checked = false;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                OracleDbHelper dbHelper = new OracleDbHelper();

                using (OracleConnection conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string checkSql = "SELECT COUNT(*) FROM HASTANE.PROJE_GEBE_BILGI WHERE DOSYA_NO = :DOSYA_NO";
                    using (OracleCommand checkCmd = new OracleCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.Add(":DOSYA_NO", OracleDbType.Int32).Value = dosyaNo;

                        int recordCount = Convert.ToInt32(checkCmd.ExecuteScalar());




                        if (recordCount > 0)
                        {
                            MessageBox.Show("Bu dosya numarası zaten kayıtlı");
                            return;
                        }
                    }


                    string sql = "INSERT INTO HASTANE.PROJE_GEBE_BILGI ( " +
                                 "DOSYA_NO, GEBELIKTEN_KORUNMA, GEBELIK_SAYISI, DOGUM_SAYISI, DUSUK_SAYISI, DILATASYON_KURETAJ, TEHLIKELI_DUSUK, " +
                                 "ILERI_ADET_YASI, ADET_AKINTISI, AKRABALIK_DURUMU, SON_ADET_TARIHI, SON_DOGUM_TARIHI, SON_DOGUM_SEKLI, " +
                                 "KAN_GRUBU, ESININ_KAN_GRUBU, KAN_UYUSMAZLIGI, HEPATIT, DIYABET, HIPERTANSIYON, SIGARA, ALKOL) " +
                                 "VALUES ( " +
                                 ":DOSYA_NO, :GEBELIKTEN_KORUNMA, :GEBELIK_SAYISI, :DOGUM_SAYISI, :DUSUK_SAYISI, :DILATASYON_KURETAJ, :TEHLIKELI_DUSUK, " +
                                 ":ILERI_ADET_YASI, :ADET_AKINTISI, :AKRABALIK_DURUMU, :SON_ADET_TARIHI, :SON_DOGUM_TARIHI, :SON_DOGUM_SEKLI, " +
                                 ":KAN_GRUBU, :ESININ_KAN_GRUBU, :KAN_UYUSMAZLIGI, :HEPATIT, :DIYABET, :HIPERTANSIYON, :SIGARA, :ALKOL)";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {

                        cmd.Parameters.Add(":DOSYA_NO", OracleDbType.Int32).Value = dosyaNo;
                        cmd.Parameters.Add(":GEBELIKTEN_KORUNMA", cmbKorunma.SelectedItem ?? DBNull.Value);
                        cmd.Parameters.Add(":GEBELIK_SAYISI", string.IsNullOrWhiteSpace(txtGebeSayi.Text) ? (object)DBNull.Value : int.Parse(txtGebeSayi.Text));
                        cmd.Parameters.Add(":DOGUM_SAYISI", string.IsNullOrWhiteSpace(txtDogumSayi.Text) ? (object)DBNull.Value : int.Parse(txtDogumSayi.Text));
                        cmd.Parameters.Add(":DUSUK_SAYISI", string.IsNullOrWhiteSpace(txtDusukSayi.Text) ? (object)DBNull.Value : int.Parse(txtDusukSayi.Text));
                        cmd.Parameters.Add(":DILATASYON_KURETAJ", string.IsNullOrWhiteSpace(txtKurtaj.Text) ? (object)DBNull.Value : int.Parse(txtKurtaj.Text));
                        cmd.Parameters.Add(":TEHLIKELI_DUSUK", string.IsNullOrWhiteSpace(txtDusuk.Text) ? (object)DBNull.Value : int.Parse(txtDusuk.Text));
                        cmd.Parameters.Add(":ILERI_ADET_YASI", string.IsNullOrWhiteSpace(txtIleriAdet.Text) ? (object)DBNull.Value : int.Parse(txtIleriAdet.Text));

                        if (checkBox14.Checked)
                            cmd.Parameters.Add(":ADET_AKINTISI", "E");
                        else if (checkBox13.Checked)
                            cmd.Parameters.Add(":ADET_AKINTISI", "H");
                        else
                            cmd.Parameters.Add(":ADET_AKINTISI", DBNull.Value);


                        cmd.Parameters.Add(":AKRABALIK_DURUMU", cmbAkrabalık.SelectedItem ?? DBNull.Value);
                        cmd.Parameters.Add(":SON_ADET_TARIHI", OracleDbType.Date).Value = dateTimeSonAdet.Checked ? dateTimeSonAdet.Value : (object)DBNull.Value;
                        cmd.Parameters.Add(":SON_DOGUM_TARIHI", OracleDbType.Date).Value = dateTimeSonDogum.Checked ? dateTimeSonDogum.Value : (object)DBNull.Value;
                        cmd.Parameters.Add(":SON_DOGUM_SEKLI", cmbSonDogumSekil.SelectedItem ?? DBNull.Value);
                        cmd.Parameters.Add(":KAN_GRUBU", cmbKan.SelectedItem ?? DBNull.Value);
                        cmd.Parameters.Add(":ESININ_KAN_GRUBU", cmbKanEs.SelectedItem ?? DBNull.Value);

                        if (checkBox2.Checked)
                            cmd.Parameters.Add(":KAN_UYUSMAZLIGI", "E");
                        else if (checkBox3.Checked)
                            cmd.Parameters.Add(":KAN_UYUSMAZLIGI", "H");
                        else
                            cmd.Parameters.Add(":KAN_UYUSMAZLIGI", DBNull.Value);


                        if (checkBox1.Checked)
                            cmd.Parameters.Add(":HEPATIT", "E");
                        else if (checkBox4.Checked)
                            cmd.Parameters.Add(":HEPATIT", "H");
                        else
                            cmd.Parameters.Add(":HEPATIT", DBNull.Value);


                        if (checkBox5.Checked)
                            cmd.Parameters.Add(":DIYABET", "E");
                        else if (checkBox6.Checked)
                            cmd.Parameters.Add(":DIYABET", "H");
                        else
                            cmd.Parameters.Add(":DIYABET", DBNull.Value);


                        if (checkBox7.Checked)
                            cmd.Parameters.Add(":HIPERTANSIYON", "E");
                        else if (checkBox8.Checked)
                            cmd.Parameters.Add(":HIPERTANSIYON", "H");
                        else
                            cmd.Parameters.Add(":HIPERTANSIYON", DBNull.Value);


                        if (checkBox9.Checked)
                            cmd.Parameters.Add(":SIGARA", "E");
                        else if (checkBox10.Checked)
                            cmd.Parameters.Add(":SIGARA", "H");
                        else
                            cmd.Parameters.Add(":SIGARA", DBNull.Value);


                        if (checkBox11.Checked)
                            cmd.Parameters.Add(":ALKOL", "E");
                        else if (checkBox12.Checked)
                            cmd.Parameters.Add(":ALKOL", "H");
                        else
                            cmd.Parameters.Add(":ALKOL", DBNull.Value);

                        cmd.ExecuteNonQuery();

                        using (OracleConnection connection = dbHelper.GetConnection())
                        {
                            connection.Open();
                            LoadDataIntoForm(dosyaNo, connection);
                        }

                        MessageBox.Show("Veri başarıyla kaydedildi.");
                    }
                    DisableControls();
                    btnKaydet.Visible = false;
                    btnDuzenle.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }



        private void LoadDataIntoForm(int dosyaNo, OracleConnection conn)
        {
            try
            {

                string selectSql = "SELECT * FROM HASTANE.PROJE_GEBE_BILGI WHERE DOSYA_NO = :DOSYA_NO";

                using (OracleCommand cmd = new OracleCommand(selectSql, conn))
                {
                    cmd.Parameters.Add(":DOSYA_NO", OracleDbType.Int32).Value = dosyaNo;


                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            cmbKorunma.Text = reader["GEBELIKTEN_KORUNMA"] != DBNull.Value ? reader["GEBELIKTEN_KORUNMA"].ToString() : "";
                            txtGebeSayi.Text = reader["GEBELIK_SAYISI"] != DBNull.Value ? reader["GEBELIK_SAYISI"].ToString() : "";
                            txtDogumSayi.Text = reader["DOGUM_SAYISI"] != DBNull.Value ? reader["DOGUM_SAYISI"].ToString() : "";
                            txtDusukSayi.Text = reader["DUSUK_SAYISI"] != DBNull.Value ? reader["DUSUK_SAYISI"].ToString() : "";
                            txtKurtaj.Text = reader["DILATASYON_KURETAJ"] != DBNull.Value ? reader["DILATASYON_KURETAJ"].ToString() : "";
                            txtDusuk.Text = reader["TEHLIKELI_DUSUK"] != DBNull.Value ? reader["TEHLIKELI_DUSUK"].ToString() : "";
                            txtIleriAdet.Text = reader["ILERI_ADET_YASI"] != DBNull.Value ? reader["ILERI_ADET_YASI"].ToString() : "";
                            checkBox14.Checked = reader["ADET_AKINTISI"] != DBNull.Value && reader["ADET_AKINTISI"].ToString() == "E";

                            string akrabalık;
                            if (reader.IsDBNull(reader.GetOrdinal("AKRABALIK_DURUMU")))
                            {

                                akrabalık = "-";
                            }
                            else
                            {
                                akrabalık = reader.GetString(reader.GetOrdinal("AKRABALIK_DURUMU"));
                            }
                            cmbAkrabalık.Text = akrabalık;


                            dateTimeSonAdet.Value = reader["SON_ADET_TARIHI"] != DBNull.Value ? Convert.ToDateTime(reader["SON_ADET_TARIHI"]) : DateTime.Now;
                            dateTimeSonDogum.Value = reader["SON_DOGUM_TARIHI"] != DBNull.Value ? Convert.ToDateTime(reader["SON_DOGUM_TARIHI"]) : DateTime.Now;
                            cmbSonDogumSekil.Text = reader["SON_DOGUM_SEKLI"] != DBNull.Value ? reader["SON_DOGUM_SEKLI"].ToString() : "";
                            cmbKan.Text = reader["KAN_GRUBU"] != DBNull.Value ? reader["KAN_GRUBU"].ToString() : "";
                            cmbKanEs.Text = reader["ESININ_KAN_GRUBU"] != DBNull.Value ? reader["ESININ_KAN_GRUBU"].ToString() : "";

                            checkBox2.Checked = reader["KAN_UYUSMAZLIGI"] != DBNull.Value && reader["KAN_UYUSMAZLIGI"].ToString() == "E";
                            checkBox3.Checked = reader["KAN_UYUSMAZLIGI"] != DBNull.Value && reader["KAN_UYUSMAZLIGI"].ToString() == "H";
                            checkBox1.Checked = reader["HEPATIT"] != DBNull.Value && reader["HEPATIT"].ToString() == "E";
                            checkBox4.Checked = reader["HEPATIT"] != DBNull.Value && reader["HEPATIT"].ToString() == "H";
                            checkBox5.Checked = reader["DIYABET"] != DBNull.Value && reader["DIYABET"].ToString() == "E";
                            checkBox6.Checked = reader["DIYABET"] != DBNull.Value && reader["DIYABET"].ToString() == "H";
                            checkBox7.Checked = reader["HIPERTANSIYON"] != DBNull.Value && reader["HIPERTANSIYON"].ToString() == "E";
                            checkBox8.Checked = reader["HIPERTANSIYON"] != DBNull.Value && reader["HIPERTANSIYON"].ToString() == "H";
                            checkBox9.Checked = reader["SIGARA"] != DBNull.Value && reader["SIGARA"].ToString() == "E";
                            checkBox10.Checked = reader["SIGARA"] != DBNull.Value && reader["SIGARA"].ToString() == "H";
                            checkBox11.Checked = reader["ALKOL"] != DBNull.Value && reader["ALKOL"].ToString() == "E";
                            checkBox12.Checked = reader["ALKOL"] != DBNull.Value && reader["ALKOL"].ToString() == "H";
                        }
                        else
                        {
                            MessageBox.Show("Önce hasta bilgilerini kayıt edin");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }


        private void DisableControls()
        {
            txtGebeSayi.Enabled = false;
            txtDogumSayi.Enabled = false;
            txtDusukSayi.Enabled = false;
            txtKurtaj.Enabled = false;
            txtDusuk.Enabled = false;
            txtIleriAdet.Enabled = false;
            cmbKorunma.Enabled = false;
            cmbAkrabalık.Enabled = false;
            cmbSonDogumSekil.Enabled = false;
            cmbKan.Enabled = false;
            cmbKanEs.Enabled = false;
            dateTimeSonAdet.Enabled = false;
            dateTimeSonDogum.Enabled = false;
            checkBox14.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox1.Enabled = false;
            checkBox4.Enabled = false;
            checkBox5.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;
            checkBox8.Enabled = false;
            checkBox9.Enabled = false;
            checkBox10.Enabled = false;
            checkBox11.Enabled = false;
            checkBox12.Enabled = false;
            checkBox13.Enabled = false;
            checkBox14.Enabled = false;
        }
        private void EnableControls()
        {
            txtGebeSayi.Enabled = true;
            txtDogumSayi.Enabled = true;
            txtDusukSayi.Enabled = true;
            txtKurtaj.Enabled = true;
            txtDusuk.Enabled = true;
            txtIleriAdet.Enabled = true;
            cmbKorunma.Enabled = true;
            cmbAkrabalık.Enabled = true;
            cmbSonDogumSekil.Enabled = true;
            cmbKan.Enabled = true;
            cmbKanEs.Enabled = true;
            dateTimeSonAdet.Enabled = true;
            dateTimeSonDogum.Enabled = true;
            checkBox14.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
            checkBox1.Enabled = true;
            checkBox4.Enabled = true;
            checkBox5.Enabled = true;
            checkBox6.Enabled = true;
            checkBox7.Enabled = true;
            checkBox8.Enabled = true;
            checkBox9.Enabled = true;
            checkBox10.Enabled = true;
            checkBox11.Enabled = true;
            checkBox12.Enabled = true;
            checkBox13.Enabled = true;
            checkBox14.Enabled = true;
        }

        private bool VerilerMevcut()
        {
            try
            {
               
                OracleDbHelper dbHelper = new OracleDbHelper();
                using (OracleConnection conn = dbHelper.GetConnection())
                {
                    conn.Open();

                   
                    string selectSql = "SELECT COUNT(*) FROM HASTANE.PROJE_GEBE_BILGI WHERE DOSYA_NO = :DOSYA_NO";
                    using (OracleCommand cmd = new OracleCommand(selectSql, conn))
                    {
                        cmd.Parameters.Add(":DOSYA_NO", OracleDbType.Int32).Value = dosyaNo;

                       
                        int recordCount = Convert.ToInt32(cmd.ExecuteScalar());

                       
                        return recordCount > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                return false;
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            btnGuncelle.Visible = true;
            btnDuzenle.Visible = false;
            btnKaydet.Visible = false;

            EnableControls();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                OracleDbHelper dbHelper = new OracleDbHelper();

                using (OracleConnection conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string checkSql = "SELECT COUNT(*) FROM HASTANE.PROJE_GEBE_BILGI WHERE DOSYA_NO = :DOSYA_NO";
                    using (OracleCommand checkCmd = new OracleCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.Add(":DOSYA_NO", OracleDbType.Int32).Value = dosyaNo;
                        int recordCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (recordCount == 0)
                        {
                            MessageBox.Show("Veri bulunamadı, güncelleme yapılamaz.");
                            return;
                        }
                    }


                    string updateSql = "UPDATE HASTANE.PROJE_GEBE_BILGI SET " +
                    "GEBELIKTEN_KORUNMA = :GEBELIKTEN_KORUNMA, " +
                    "GEBELIK_SAYISI = :GEBELIK_SAYISI, " +
                    "DOGUM_SAYISI = :DOGUM_SAYISI, " +
                    "DUSUK_SAYISI = :DUSUK_SAYISI, " +
                    "DILATASYON_KURETAJ = :DILATASYON_KURETAJ, " +
                    "TEHLIKELI_DUSUK = :TEHLIKELI_DUSUK, " +
                    "ILERI_ADET_YASI = :ILERI_ADET_YASI, " +
                    "ADET_AKINTISI = :ADET_AKINTISI, " +
                    "AKRABALIK_DURUMU = :AKRABALIK_DURUMU, " +
                    "SON_ADET_TARIHI = :SON_ADET_TARIHI, " +
                    "SON_DOGUM_TARIHI = :SON_DOGUM_TARIHI, " +
                    "SON_DOGUM_SEKLI = :SON_DOGUM_SEKLI, " +
                    "KAN_GRUBU = :KAN_GRUBU, " +
                    "ESININ_KAN_GRUBU = :ESININ_KAN_GRUBU, " +
                    "KAN_UYUSMAZLIGI = :KAN_UYUSMAZLIGI, " +
                    "HEPATIT = :HEPATIT, " +
                    "DIYABET = :DIYABET, " +
                    "HIPERTANSIYON = :HIPERTANSIYON, " +
                    "SIGARA = :SIGARA, " +
                    "ALKOL = :ALKOL " +
                    "WHERE DOSYA_NO = :DOSYA_NO";


                    using (OracleCommand cmd = new OracleCommand(updateSql, conn))
                    {
                        {
                            cmd.Parameters.Add(":GEBELIKTEN_KORUNMA", cmbKorunma.SelectedItem ?? DBNull.Value);
                            cmd.Parameters.Add(":GEBELIK_SAYISI", string.IsNullOrWhiteSpace(txtGebeSayi.Text) ? (object)DBNull.Value : int.Parse(txtGebeSayi.Text));
                            cmd.Parameters.Add(":DOGUM_SAYISI", string.IsNullOrWhiteSpace(txtDogumSayi.Text) ? (object)DBNull.Value : int.Parse(txtDogumSayi.Text));
                            cmd.Parameters.Add(":DUSUK_SAYISI", string.IsNullOrWhiteSpace(txtDusukSayi.Text) ? (object)DBNull.Value : int.Parse(txtDusukSayi.Text));
                            cmd.Parameters.Add(":DILATASYON_KURETAJ", string.IsNullOrWhiteSpace(txtKurtaj.Text) ? (object)DBNull.Value : int.Parse(txtKurtaj.Text));
                            cmd.Parameters.Add(":TEHLIKELI_DUSUK", string.IsNullOrWhiteSpace(txtDusuk.Text) ? (object)DBNull.Value : int.Parse(txtDusuk.Text));
                            cmd.Parameters.Add(":ILERI_ADET_YASI", string.IsNullOrWhiteSpace(txtIleriAdet.Text) ? (object)DBNull.Value : int.Parse(txtIleriAdet.Text));

                            if (checkBox14.Checked)
                                cmd.Parameters.Add(":ADET_AKINTISI", "E");
                            else if (checkBox13.Checked)
                                cmd.Parameters.Add(":ADET_AKINTISI", "H");
                            else
                                cmd.Parameters.Add(":ADET_AKINTISI", DBNull.Value);

                            cmd.Parameters.Add(":AKRABALIK_DURUMU", cmbAkrabalık.SelectedItem ?? DBNull.Value);
                            cmd.Parameters.Add(":SON_ADET_TARIHI", OracleDbType.Date).Value = dateTimeSonAdet.Checked ? dateTimeSonAdet.Value : (object)DBNull.Value;
                            cmd.Parameters.Add(":SON_DOGUM_TARIHI", OracleDbType.Date).Value = dateTimeSonDogum.Checked ? dateTimeSonDogum.Value : (object)DBNull.Value;
                            cmd.Parameters.Add(":SON_DOGUM_SEKLI", cmbSonDogumSekil.SelectedItem ?? DBNull.Value);
                            cmd.Parameters.Add(":KAN_GRUBU", cmbKan.SelectedItem ?? DBNull.Value);
                            cmd.Parameters.Add(":ESININ_KAN_GRUBU", cmbKanEs.SelectedItem ?? DBNull.Value);

                            if (checkBox2.Checked)
                                cmd.Parameters.Add(":KAN_UYUSMAZLIGI", "E");
                            else if (checkBox3.Checked)
                                cmd.Parameters.Add(":KAN_UYUSMAZLIGI", "H");
                            else
                                cmd.Parameters.Add(":KAN_UYUSMAZLIGI", DBNull.Value);

                            if (checkBox1.Checked)
                                cmd.Parameters.Add(":HEPATIT", "E");
                            else if (checkBox4.Checked)
                                cmd.Parameters.Add(":HEPATIT", "H");
                            else
                                cmd.Parameters.Add(":HEPATIT", DBNull.Value);

                            if (checkBox5.Checked)
                                cmd.Parameters.Add(":DIYABET", "E");
                            else if (checkBox6.Checked)
                                cmd.Parameters.Add(":DIYABET", "H");
                            else
                                cmd.Parameters.Add(":DIYABET", DBNull.Value);

                            if (checkBox7.Checked)
                                cmd.Parameters.Add(":HIPERTANSIYON", "E");
                            else if (checkBox8.Checked)
                                cmd.Parameters.Add(":HIPERTANSIYON", "H");
                            else
                                cmd.Parameters.Add(":HIPERTANSIYON", DBNull.Value);

                            if (checkBox9.Checked)
                                cmd.Parameters.Add(":SIGARA", "E");
                            else if (checkBox10.Checked)
                                cmd.Parameters.Add(":SIGARA", "H");
                            else
                                cmd.Parameters.Add(":SIGARA", DBNull.Value);

                            if (checkBox11.Checked)
                                cmd.Parameters.Add(":ALKOL", "E");
                            else if (checkBox12.Checked)
                                cmd.Parameters.Add(":ALKOL", "H");
                            else
                                cmd.Parameters.Add(":ALKOL", DBNull.Value);

                            
                            cmd.Parameters.Add(":DOSYA_NO", OracleDbType.Int32).Value = dosyaNo;

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Veri başarıyla güncellendi.");
                        }
                    }
                    DisableControls();

                    btnGuncelle.Visible = false;
                    btnDuzenle.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void gebeGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (gebeGrid.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                
                        int izlemId = Convert.ToInt32(gebeGrid.SelectedRows[0].Cells["IZLEM_ID"].Value);

                        OracleDbHelper dbHelper = new OracleDbHelper();
                        using (OracleConnection conn = dbHelper.GetConnection())
                        {
                            conn.Open();
                            string deleteSql = "DELETE FROM HASTANE.PROJE_GEBE_TAKIP WHERE IZLEM_ID = :izlemId"; 
                            using (OracleCommand cmd = new OracleCommand(deleteSql, conn))
                            {
                                cmd.Parameters.Add(":izlemId", OracleDbType.Int32).Value = izlemId;
                                cmd.ExecuteNonQuery();
                            }
                        }


                        Yenile(protokolNo);
                        MessageBox.Show("Kayıt başarıyla silindi.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin.");
            }
        }
      }
    }



