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

namespace PROJE
{
    public partial class FormRecete : Form
    {
        private string hastaTC;
        private string hastaAdi;
        private string hastaSoyadi;


        public FormRecete(string tc, string ad, string soyad)
        {
            InitializeComponent();
            hastaTC = tc;
            hastaAdi = ad;
            hastaSoyadi = soyad;
        }

        private void FormRecete_Load(object sender, EventArgs e)
        {

            LoadData();

            lblTcAl.Text = hastaTC;
            lblAdYazdır.Text = hastaAdi + hastaSoyadi;
          
            OracleDbHelper dbHelper = new OracleDbHelper();

            using (OracleConnection connection = dbHelper.GetConnection())
            {
                connection.Open();

                //COMBOBOX KULLANIM ŞEKLİNİ DOLDURMA İŞLEMİ
                //Form ilk açıldığında verileri ComboBox’a yüklemek için burda yazdık

                // ComboBox'ı temizle
                cmbKullanımSekli.Items.Clear();
                cmbKullanımPeriyodu.Items.Clear();

                // Veritabanından veri çekmek için SQL sorgusu
                string sql = "SELECT ADI FROM HASTANE.SNET_ILACKULLANIMSEKLI";
                string sql2 = "SELECT ADI FROM HASTANE.SNET_ILACKULLANIMPERIYODU ";
                using (OracleCommand command = new OracleCommand(sql, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        // Veritabanından gelen her kaydı ComboBox'a ekle
                        while (reader.Read())
                        {
                            cmbKullanımSekli.Items.Add(reader.GetString(0));
                        }
                    }
                }
                using (OracleCommand command2 = new OracleCommand(sql2, connection))
                {
                    using (OracleDataReader reader = command2.ExecuteReader())
                    {
                        // Veritabanından gelen her kaydı ComboBox'a ekle
                        while (reader.Read())
                        {
                            cmbKullanımPeriyodu.Items.Add(reader.GetString(0));
                        }
                    }
                }

                txtKacDoz.Text = "1";
                txtKacKutu.Text = "1";
                cmbKullanımPeriyodu.SelectedItem = "Gün";
                cmbKullanımSekli.SelectedItem = "Ağızdan (Oral)";


            }
        }


        private void LoadData()
        {
            OracleDbHelper dbHelper = new OracleDbHelper();

            using (OracleConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT L.ILAC_ADI , L.BARKODU , L.ODENME_DURUMU , L.AMBALAJ_MIKTARI, L.TEKDOZ_MIKTARI FROM HASTANE.MEDULA_ILAC_LISTESI L WHERE UPPER(ILAC_ADI) LIKE UPPER(:filter)";

                using (OracleCommand command = new OracleCommand(sql, conn))
                {
                    string filterValue = "%" + txtIlac.Text + "%";

                    command.Parameters.Add(":filter", OracleDbType.Varchar2).Value = filterValue;

                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {

                        DataTable dataTable = new DataTable();
                        dataTable.Clear();
                        adapter.Fill(dataTable);
                        dataGridilacListesi.DataSource = dataTable;

                        dataGridilacListesi.AllowUserToAddRows = false;
                        dataGridilacListesi.RowHeadersVisible = false;

                        dataGridilacListesi.DefaultCellStyle.SelectionBackColor = dataGridilacListesi.DefaultCellStyle.BackColor;
                        dataGridilacListesi.DefaultCellStyle.SelectionForeColor = dataGridilacListesi.DefaultCellStyle.ForeColor;

                        if (dataTable.Columns.Count > 0)
                        {
                            dataGridilacListesi.Columns[0].HeaderText = "ILAC ADI";
                            dataGridilacListesi.Columns[0].DataPropertyName = "ILAC_ADI";

                            dataGridilacListesi.Columns[1].HeaderText = "BARKOD";
                            dataGridilacListesi.Columns[1].DataPropertyName = "BARKODU";

                            dataGridilacListesi.Columns[2].HeaderText = "ODENME DURUMU";
                            dataGridilacListesi.Columns[2].DataPropertyName = "ODENME_DURUMU";

                            dataGridilacListesi.Columns[3].HeaderText = "AMBALAJ BIRIM";
                            dataGridilacListesi.Columns[3].DataPropertyName = "AMBALAJ_MIKTARI";

                            dataGridilacListesi.Columns[4].HeaderText = "TEK DOZ BIRIM";
                            dataGridilacListesi.Columns[4].DataPropertyName = "TEKDOZ_MIKTARI";
                        }

                        for (int i = 0; i < dataGridilacListesi.Rows.Count; i++)
                        {
                            if (i % 2 == 0)
                            {
                                dataGridilacListesi.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fbf2fb");
                            }
                            else
                            {
                                dataGridilacListesi.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f8fbf2");
                            }

                        }
                    }
                }
            }
        }
        private void txtIlac_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cmbKullanımSekli_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void dataGridilacListesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridilacListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Eğer başlık satırı tıklanmadıysa
            if (e.RowIndex >= 0)
            {
                // Seçilen satırdaki verileri alıyoruz
                string barkod = dataGridilacListesi.Rows[e.RowIndex].Cells[1].Value.ToString(); // Barkod
                string ilacAdi = dataGridilacListesi.Rows[e.RowIndex].Cells[0].Value.ToString(); // İlac Adı

                // TextBox'lara yazdırıyoruz
                txtilacBarkod.Text = barkod;
                txtilacAdi.Text = ilacAdi;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


         

            if (string.IsNullOrEmpty(hastaTC))
            {
                MessageBox.Show("Lütfen önce bir hasta seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OracleDbHelper dbHelper = new OracleDbHelper();

            using (OracleConnection connection = dbHelper.GetConnection())
            {
                connection.Open();

                string sql = "INSERT INTO HASTANE.RECETELER (RECETE_ID ,TARIH, ILAC_ADI, BARKOD, KAC_KUTU, KULLANIM_SEKLI, KULLANIM_PERIYODU, KAC_DOZ, ACIKLAMA)  " +
                                    "VALUES (ilac_seq.NEXTVAL ,:TARIH, :ILAC_ADI ,:BARKOD, :KAC_KUTU , :KULLANIM_SEKLI , :KULLANIM_PERIYODU ,:KAC_DOZ ,:ACIKLAMA)";


                using (OracleCommand command = new OracleCommand(sql, connection))
                {

                    // command.Parameters.Add(":TC_KIMLIK_NO", OracleDbType.Int64).Value = tcKimlikNo;

                    if (string.IsNullOrEmpty(txtilacAdi.Text))
                    {

                        MessageBox.Show("İlaç adı boş kalamaz");
                        return;
                    }

                    else
                    {
                        command.Parameters.Add(":ILAC_ADI", OracleDbType.Varchar2).Value = txtilacAdi.Text;
                    }


                    if (string.IsNullOrEmpty(txtilacBarkod.Text))
                    {

                        MessageBox.Show("Barkod boş kalamaz");
                        return;
                    }

                    else
                    {
                        command.Parameters.Add(":BARKOD", OracleDbType.Varchar2).Value = txtilacBarkod.Text;
                    }



                    if (string.IsNullOrEmpty(txtKacKutu.Text))
                    {

                        MessageBox.Show("Kaç kutu olduğunu belirtin");
                        return;
                    }

                    else
                    {
                        command.Parameters.Add(":KAC_KUTU", OracleDbType.Varchar2).Value = txtKacKutu.Text;
                    }


                    if (string.IsNullOrEmpty(cmbKullanımPeriyodu.Text))
                    {

                        MessageBox.Show("Kullanım periyodunu belirtin");
                        return;
                    }

                    else
                    {
                        command.Parameters.Add(":KULLANIM_PERIYODU", OracleDbType.Varchar2).Value = cmbKullanımPeriyodu.Text;
                    }


                    if (string.IsNullOrEmpty(txtKacDoz.Text))
                    {

                        MessageBox.Show("Kaç doz olduğunu belirtin");
                        return;
                    }

                    else
                    {
                        command.Parameters.Add(":KAC_DOZ", OracleDbType.Varchar2).Value = txtKacDoz.Text;
                    }


                    if (string.IsNullOrEmpty(cmbKullanımSekli.Text))
                    {

                        MessageBox.Show("Kullanım şeklini belirtin");
                        return;
                    }

                    else
                    {
                        command.Parameters.Add(":KULLANIM_SEKLI", OracleDbType.Varchar2).Value = cmbKullanımSekli.Text;
                    }


                    command.Parameters.Add(":ACIKLAMA", OracleDbType.Varchar2).Value = txtAciklama.Text;



                }
            }
        }
    }
}

    
 


