﻿using Oracle.ManagedDataAccess.Client;
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

namespace PROJE
{
    public partial class FormYeniTakip : Form
    {
        private string dosyaNumarasi;

        public FormYeniTakip(string dosyaNo)
        {
            InitializeComponent();
            dosyaNumarasi = dosyaNo;

        }

        private void FormYeniTakip_Load(object sender, EventArgs e)
        {

            Console.WriteLine(dosyaNumarasi);

            OracleDbHelper dbHelper = new OracleDbHelper();

            using (OracleConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM HASTANE.KURUM";

                using (OracleCommand command = new OracleCommand(sql, conn))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        cmbKurumAdi.Items.Clear();

                        while (reader.Read())
                        {
                            string kurumAdi = reader["KURUM_ADI"].ToString();
                            cmbKurumAdi.Items.Add(kurumAdi);
                        }
                    }


                    string sql2 = "SELECT BOLUM_ADI FROM HASTANE.BOLUM";

                    using (OracleCommand command2 = new OracleCommand(sql2, conn))
                    {
                        using (OracleDataReader reader = command2.ExecuteReader())
                        {
                            cmbBolum.Items.Clear();

                            while (reader.Read())
                            {
                                string bolumAdi = reader["BOLUM_ADI"].ToString();
                                cmbBolum.Items.Add(bolumAdi);
                            }
                        }
                    }
                }
            }
        }




        private void cmbKurumAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleDbHelper dbHelper = new OracleDbHelper();

            using (OracleConnection connection = dbHelper.GetConnection())
            {
                connection.Open();
                string kurumAdi = cmbKurumAdi.SelectedItem.ToString();

                // Parametreli sorgu
                string sql = "SELECT KODU FROM HASTANE.KURUM WHERE KURUM_ADI = :KURUM";
                using (OracleCommand command = new OracleCommand(sql, connection))
                {
                    command.Parameters.Add(new OracleParameter(":KURUM", OracleDbType.Varchar2)).Value = kurumAdi;
                }
            }
        }

        private void cmbBolum_SelectedIndexChanged(object sender, EventArgs e)
        {

            OracleDbHelper dbHelper = new OracleDbHelper();

            cmbDr.Items.Clear();

            using (OracleConnection connection = dbHelper.GetConnection())
            {
                connection.Open();

                string bolum = cmbBolum.SelectedItem.ToString();
                string sql2 = "SELECT BOLUM FROM HASTANE.BOLUM WHERE BOLUM_ADI = :BOLUM_ADI";
                using (OracleCommand command = new OracleCommand(sql2, connection))
                {
                  
                    command.Parameters.Add(new OracleParameter("BOLUM_ADI", OracleDbType.Varchar2)).Value = bolum;
                  
                    using (OracleDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            int bolumKodu = Convert.ToInt32(reader["BOLUM"]);

                            string sql3 = "SELECT ADI_SOYADI FROM HASTANE.DRADI WHERE BOLUM = :BOLUM";
                            using (OracleCommand command2 = new OracleCommand(sql3, connection))
                            {
                           
                                command2.Parameters.Add(new OracleParameter("BOLUM", OracleDbType.Int32)).Value = bolumKodu;
                                using (OracleDataReader reader2 = command2.ExecuteReader())
                                {
                                    while (reader2.Read())
                                    {
                                        string drAdi = reader2["ADI_SOYADI"].ToString();

                                        cmbDr.Items.Add(drAdi);
                                    }

                                }
                            }
                        }

                    }
                }
            }
        }
        private void cmbDr_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbBolum_Click(object sender, EventArgs e)
        {
            cmbDr.Items.Clear();
        }

        private void btnHesapAc_Click(object sender, EventArgs e)
        {
            
                OracleDbHelper dbHelper = new OracleDbHelper();

            using (OracleConnection connection = dbHelper.GetConnection())
            {
                connection.Open();

                string sql = "INSERT INTO HASTANE.PROTOKOL (PROTOKOL_NO ,GTARIH, KURUM_NO, BOLUM, DR_KODU, DOSYA_NO) " +
                                    "VALUES (KIMSEQ.NEXTVAL ,:GTARIH, :KURUM_NO ,:BOLUM, :DR_KODU, :DOSYA_NO)";


                using (OracleCommand command = new OracleCommand(sql, connection))
                {

                    if (string.IsNullOrEmpty(dateTimePicker1.Text))
                    {
                        MessageBox.Show("Tarih boş kalamaz");
                        return;
                    }
                    else
                    {
                        DateTime selectedDate = dateTimePicker1.Value;
                        command.Parameters.Add(":GTARIH", OracleDbType.Date).Value = selectedDate;
                    }

                    if (string.IsNullOrEmpty(cmbKurumAdi.Text))
                    {
                        MessageBox.Show("Kurum adı boş kalamaz");
                        return;
                    }
                    else
                    {
                        command.Parameters.Add(":KURUM_NO", OracleDbType.Varchar2).Value = (cmbKurumAdi.SelectedIndex);
                    }

                    if (string.IsNullOrEmpty(cmbBolum.Text))
                    {
                        MessageBox.Show("lütfen bölüm seçin");
                        return;
                    }
                    else
                    {
                        command.Parameters.Add(":BOLUM", OracleDbType.Int32).Value = (cmbBolum.SelectedIndex);

                    }

                    if (string.IsNullOrEmpty(cmbDr.Text))
                    {
                        MessageBox.Show("lütfen doktor seçin");
                        return;
                    }
                    else
                    {
                        command.Parameters.Add(":DR_KODU", OracleDbType.Int32).Value = (cmbDr.SelectedIndex);
                    }

                    // DOSYA_NO parametresini Form1'den gelen dosya numarasına göre ekliyoruz
                    if (!string.IsNullOrEmpty(dosyaNumarasi)) // Dosya numarasının boş olmaması kontrolü
                    {
                        command.Parameters.Add(":DOSYA_NO", OracleDbType.Varchar2).Value = dosyaNumarasi; // Dosya numarasını veritabanına ekliyoruz
                    }
                    else
                    {
                        MessageBox.Show("Dosya numarası eksik!");
                        return;
                    }


                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Kişi başarıyla kaydedildi.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
              }
            }
        }
    }
