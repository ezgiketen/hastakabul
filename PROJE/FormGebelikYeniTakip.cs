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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PROJE
{
    public partial class FormGebelikYeniTakip : Form
    {
        public int protokolNo { get; set; }
        public int dosyaNo { get; set; }


        public FormGebelikYeniTakip(int dosyaNo, int protokolNo)
        {
            InitializeComponent();
            this.dosyaNo = dosyaNo;
            this.protokolNo = protokolNo;
        }

        private void FormGebelikYeniTakip_Load(object sender, EventArgs e)

        {

          
            this.Width = 1305;
            this.Height = 621;

            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

      
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((screenWidth - this.Width) / 2, (screenHeight - this.Height) / 2);


            string[] haftalar = { "1.Dönem (0-14 HAFTA)", "2.Dönem (18-24 HAFTA)", "3.Dönem (28-32 HAFTA)", "4.Dönem (36-38 HAFTA)" };
            cmbHafta.Items.AddRange(haftalar);

            string[] demir = { "Devam Ediyor", "Yeni Başlandı", "Başlanmadı" };
            cmbDvitamini.Items.AddRange(demir);
            cmbDemir.Items.AddRange(demir);

            string[] risk = { "Risk Yok", "Riskli", "Yüksek Riskli" };
            cmbRisk.Items.AddRange(risk);

            string[] hemoglobin = {
                "≥11 g/dL (Normal)",
                "10-10.9 g/dL (Hafif Anemi)",
                "7-9.9 g/dL (Orta Anemi)",
                "<7 g/dL (Ağır Anemi)",
                "Test Yapılmadı"
            };
            cmbHemoglobin.Items.AddRange(hemoglobin);

            string[] idrardaProtein =
            {
                "Negatif (Normal)",
                "+1 (Şüpheli)",
                "+2 (Orta Düzey)",
                "+3 veya daha fazla (Yüksek)",
                "Test Yapılmadı"
            };
            cmbIdrarProtein.Items.AddRange(idrardaProtein);
        }



        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                OracleDbHelper dbHelper = new OracleDbHelper();

                using (OracleConnection conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "INSERT INTO HASTANE.PROJE_GEBE_TAKIP (" +
                        "IZLEM_ID, DOSYA_NO, PROTOKOL_NO, BAS_AGRISI, BAS_DONMESI, KILO, ODEM, KANAMA, BULANTI, " +
                        "KACINCI_HAFTA, RISK_DURUMU, DEMIR_DESTEGI, D_VITAMIN_DESTEGI, HEMOGLOBIN, IDRARDA_PROTEIN, NOTLAR) " +
                        "VALUES (IZLEM_ID_SEQ.NEXTVAL, :DOSYA_NO, :PROTOKOL_NO, :BAS_AGRISI, :BAS_DONMESI, :KILO, :ODEM, :KANAMA, :BULANTI, " +
                        ":KACINCI_HAFTA, :RISK_DURUMU, :DEMIR_DESTEGI, :D_VITAMIN_DESTEGI, :HEMOGLOBIN, :IDRARDA_PROTEIN, :NOTLAR)";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(":DOSYA_NO", dosyaNo);
                        cmd.Parameters.Add(":PROTOKOL_NO", protokolNo);

                       
                        if (checkBox2.Checked)
                        {
                            cmd.Parameters.Add(":BAS_AGRISI", "E");
                        }
                        else if (checkBox4.Checked)
                        {
                            cmd.Parameters.Add(":BAS_AGRISI", "H");
                        }
                        else
                        {
                            cmd.Parameters.Add(":BAS_AGRISI", DBNull.Value); 
                        }

                        
                        if (checkBox5.Checked)
                        {
                            cmd.Parameters.Add(":BAS_DONMESI", "E");
                        }
                        else if (checkBox3.Checked)
                        {
                            cmd.Parameters.Add(":BAS_DONMESI", "H");
                        }
                        else
                        {
                            cmd.Parameters.Add(":BAS_DONMESI", DBNull.Value); 
                        }

         
                        if (string.IsNullOrWhiteSpace(txtKilo.Text))
                        {
                            cmd.Parameters.Add(":KILO", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.Add(":KILO", txtKilo.Text);
                        }

                  
                        if (checkBox10.Checked)
                        {
                            cmd.Parameters.Add(":ODEM", "E");
                        }
                        else if (checkBox1.Checked)
                        {
                            cmd.Parameters.Add(":ODEM", "H");
                        }
                        else
                        {
                            cmd.Parameters.Add(":ODEM", DBNull.Value); 
                        }

                      
                        if (checkBox9.Checked)
                        {
                            cmd.Parameters.Add(":KANAMA", "E");
                        }
                        else if (checkBox8.Checked)
                        {
                            cmd.Parameters.Add(":KANAMA", "H");
                        }
                        else
                        {
                            cmd.Parameters.Add(":KANAMA", DBNull.Value);
                        }

                 
                        if (checkBox7.Checked)
                        {
                            cmd.Parameters.Add(":BULANTI", "E");
                        }
                        else if (checkBox6.Checked)
                        {
                            cmd.Parameters.Add(":BULANTI", "H");
                        }
                        else
                        {
                            cmd.Parameters.Add(":BULANTI", DBNull.Value); 
                        }

                     
                        cmd.Parameters.Add(":KACINCI_HAFTA", cmbHafta.SelectedItem ?? DBNull.Value);
                        cmd.Parameters.Add(":RISK_DURUMU", cmbRisk.SelectedItem ?? DBNull.Value);
                        cmd.Parameters.Add(":DEMIR_DESTEGI", cmbDemir.SelectedItem ?? DBNull.Value);
                        cmd.Parameters.Add(":D_VITAMIN_DESTEGI", cmbDvitamini.SelectedItem ?? DBNull.Value);
                        cmd.Parameters.Add(":HEMOGLOBIN", cmbHemoglobin.SelectedItem ?? DBNull.Value);
                        cmd.Parameters.Add(":IDRARDA_PROTEIN", cmbIdrarProtein.SelectedItem ?? DBNull.Value);
                        cmd.Parameters.Add(":NOTLAR", string.IsNullOrWhiteSpace(txtNotlar.Text) ? DBNull.Value : txtNotlar.Text);

                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("İzlem başarıyla kayıt edildi");

                    var formGebelikTakip = (FormGebelikTakip)Application.OpenForms["FormGebelikTakip"];
                    formGebelikTakip?.Yenile(protokolNo);  

                    this.Close(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA : " + ex.ToString());
            }
        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox4.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                checkBox3.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox5.Checked = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                checkBox6.Checked = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                checkBox7.Checked = false;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                checkBox8.Checked = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                checkBox9.Checked = false;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                checkBox1.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox10.Checked = false;
            }
        }
    }
}

