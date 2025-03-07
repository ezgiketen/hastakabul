using Oracle.ManagedDataAccess.Client;
using OracleDatabaseConnectionExample;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace PROJE
{
    public partial class FormRecete : Form
    {

        public int dosyaNo { get; set; }
        public int protokolNo { get; set; }
        public string hastaAdi { get; set; }
        public string hastaSoyadi { get; set; }
        public long tcKimlikNo { get; set; }
        public string tema { get; set; }


        private string hastaTC;

        string selectedSekil;
        int periyotkodu;
        int kullanimSekli;
        int kullanimPeriyodu;



        public FormRecete()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;  // Tam ekran başlatma

        }

        private void FormRecete_Load(object sender, EventArgs e)
        {


            string hastaAd = hastaAdi;
            string hastaSoyad = hastaSoyadi;
            long tc = tcKimlikNo;
            int dosya = dosyaNo;
            int protokol = protokolNo;
            string temaSec = tema;

           

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


            LoadData();

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
                string sql2 = "SELECT * FROM HASTANE.SNET_ILACKULLANIMPERIYODU ";
                string sql3 = "SELECT PROTOKOL_NO FROM HASTANE.PROTOKOL WHERE DOSYA_NO = :DOSYA_NO";

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
                            cmbKullanımPeriyodu.Items.Add(reader.GetString(1));

                        }
                    }
                }


                txtKacDoz.Text = "1";
                txtKacKutu.Text = "1";
                cmbKullanımPeriyodu.SelectedItem = "Gün";
                cmbKullanımSekli.SelectedItem = "Ağızdan (Oral)";


                lblAd.Text = hastaAdi + " " + hastaSoyadi;
                lblDosyaNo.Text = dosyaNo.ToString();
                lblTcAl.Text = tcKimlikNo.ToString();
            }
        }


        private void LoadData()
        {
            OracleDbHelper dbHelper = new OracleDbHelper();

            using (OracleConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT L.ILAC_ADI , L.BARKODU , L.ODENME_DURUMU , L.AMBALAJ_MIKTARI, L.TEKDOZ_MIKTARI FROM HASTANE.MEDULA_ILAC_LISTESI L  WHERE UPPER(ILAC_ADI) LIKE UPPER(:filter)";

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

                        dataGridilacListesi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dataGridilacListesi.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#008b45");
                        dataGridilacListesi.DefaultCellStyle.SelectionForeColor = Color.White;

                        if (dataTable.Columns.Count > 0)
                        {
                            dataGridilacListesi.Columns[0].HeaderText = "ILAC ADI";
                            dataGridilacListesi.Columns[0].DataPropertyName = "ILAC_ADI";

                            dataGridilacListesi.Columns[1].HeaderText = "BARKOD";
                            dataGridilacListesi.Columns[1].DataPropertyName = "BARKODU";


                            dataGridilacListesi.Columns[2].HeaderText = "ODENME DURUMU";
                            // CellFormatting olayını kullanıyoruz
                            dataGridilacListesi.CellFormatting += (sender, e) =>
                            {
                                
                                if (e.RowIndex >= 0 && e.ColumnIndex == 2)
                                {
                                   
                                    if (dataGridilacListesi.Rows[e.RowIndex].Cells["ODENME_DURUMU"].Value.ToString() == "1")
                                    {
                                        e.Value = "SGK"; 
                                    }
                                    else
                                    {
                                        e.Value = "ÖDENMİYOR";

                                        e.CellStyle.BackColor = ColorTranslator.FromHtml("#ff6a6a");

                                    }
                                }


                                dataGridilacListesi.Columns[3].HeaderText = "AMBALAJ BIRIM";
                                dataGridilacListesi.Columns[3].DataPropertyName = "AMBALAJ_MIKTARI";

                                dataGridilacListesi.Columns[4].HeaderText = "TEK DOZ BIRIM";
                                dataGridilacListesi.Columns[4].DataPropertyName = "TEKDOZ_MIKTARI";
                            };

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


                            dataGridilacListesi.Columns[0].Width = 600;
                            dataGridilacListesi.Columns[1].Width = 130;
                            dataGridilacListesi.Columns[2].Width = 100;
                            dataGridilacListesi.Columns[3].Width = 100;
                        }
                    }
                }
            }
        }
        private void txtIlac_TextChanged(object sender, EventArgs e)
        {
            LoadData();
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

        private void btnReceteEkle_Click(object sender, EventArgs e)
        {

            OracleDbHelper dbHelper = new OracleDbHelper();

            using (OracleConnection connection = dbHelper.GetConnection())
            {
                connection.Open();

                string sql = "INSERT INTO HASTANE.RECETELER (RECETE_ID, DOSYA_NO, PROTOKOL_NO, ILAC_ADI, BARKOD, KAC_KUTU, KULLANIM_SEKLI, KULLANIM_PERIYODU, KAC_DOZ, ACIKLAMA)  " +
                                    "VALUES (ilac_seq.NEXTVAL ,:DOSYA_NO, :PROTOKOL_NO, :ILAC_ADI ,:BARKOD, :KAC_KUTU , :KULLANIM_SEKLI , :KULLANIM_PERIYODU ,:KAC_DOZ ,:ACIKLAMA)";


                using (OracleCommand command = new OracleCommand(sql, connection))
                {

                    command.Parameters.Add(":DOSYA_NO", OracleDbType.Int64).Value = dosyaNo;

                    command.Parameters.Add(":PROTOKOL_NO", OracleDbType.Int32).Value = protokolNo;

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
                        command.Parameters.Add(":BARKOD", OracleDbType.Int64).Value = txtilacBarkod.Text;
                    }


                    if (string.IsNullOrEmpty(txtKacKutu.Text))
                    {

                        MessageBox.Show("Kaç kutu olduğunu belirtin");
                        return;
                    }

                    else
                    {
                        command.Parameters.Add(":KAC_KUTU", OracleDbType.Int64).Value = txtKacKutu.Text;
                    }


                    if (string.IsNullOrEmpty(cmbKullanımSekli.Text))
                    {
                        MessageBox.Show("Kullanım şeklini belirtin");
                        return;
                    }
                    else
                    {

                        command.Parameters.Add(":KULLANIM_SEKLI", OracleDbType.Int32).Value = kullanimSekli;
                    }
                    if (string.IsNullOrEmpty(cmbKullanımPeriyodu.Text))
                    {

                        MessageBox.Show("Kullanım periyodunu belirtin");
                        return;
                    }

                    else
                    {
                        command.Parameters.Add(":KULLANIM_PERIYODU", OracleDbType.Int64).Value = kullanimPeriyodu;
                    }

                    if (string.IsNullOrEmpty(txtKacDoz.Text))
                    {

                        MessageBox.Show("Kaç doz olduğunu belirtin");
                        return;
                    }

                    else
                    {
                        command.Parameters.Add(":KAC_DOZ", OracleDbType.Int64).Value = txtKacDoz.Text;
                    }


                    command.Parameters.Add(":ACIKLAMA", OracleDbType.Varchar2).Value = txtAciklama.Text;
                    command.ExecuteNonQuery();
                    DataGrid();
                }
            }
        }

        private void cmbKullanımPeriyodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKullanımSekli.SelectedItem != null)
            {
                string selectedKullanim = cmbKullanımPeriyodu.SelectedItem.ToString();

                OracleDbHelper dbHelper = new OracleDbHelper();

                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();

                    string sql = "SELECT KODU FROM HASTANE.SNET_ILACKULLANIMPERIYODU WHERE ADI = :ADI";
                    using (OracleCommand command = new OracleCommand(sql, connection))
                    {
                        command.Parameters.Add("ADI", OracleDbType.Varchar2).Value = selectedKullanim;

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int kullanimPER = reader.GetInt32(0);
                                kullanimPeriyodu = kullanimPER;
                            }
                            else
                            {
                                MessageBox.Show("Kullanım şekli bulunamadı!");
                            }
                        }
                    }
                }
            }
        }

        private void cmbKullanımSekli_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKullanımSekli.SelectedItem != null)
            {
                string selectedSekilAdi = cmbKullanımSekli.SelectedItem.ToString();

                OracleDbHelper dbHelper = new OracleDbHelper();

                using (OracleConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();

                    string sql = "SELECT KODU FROM HASTANE.SNET_ILACKULLANIMSEKLI WHERE ADI = :ADI";
                    using (OracleCommand command = new OracleCommand(sql, connection))
                    {
                        command.Parameters.Add("ADI", OracleDbType.Varchar2).Value = selectedSekilAdi;

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int kullanimSekliKodu = reader.GetInt32(0);
                                kullanimSekli = kullanimSekliKodu;
                            }
                            else
                            {
                                MessageBox.Show("Kullanım şekli bulunamadı!");
                            }
                        }
                    }
                }
            }
        }


        public void DataGrid()
        {

            OracleDbHelper dbHelper = new OracleDbHelper();
            {
                using (OracleConnection conn = dbHelper.GetConnection())
                {
                    conn.Open();

                    string sql = "SELECT r.DOSYA_NO, r.RECETE_ID, r.ILAC_ADI, r.BARKOD, r.KAC_KUTU, " +
                               "s.ADI AS SEKIL, p.ADI AS PERIYOD, r.KAC_DOZ, r.tarih, r.ACIKLAMA " +
                               "FROM HASTANE.RECETELER r " +
                               "LEFT JOIN HASTANE.SNET_ILACKULLANIMSEKLI s ON r.KULLANIM_SEKLI = s.KODU " +
                               "LEFT JOIN HASTANE.SNET_ILACKULLANIMPERIYODU p ON r.KULLANIM_PERIYODU = p.KODU " +
                               "WHERE r.DOSYA_NO = :DOSYA_NO " +
                               "AND r.PROTOKOL_NO = :PROTOKOL_NO";


                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add("DOSYA_NO", OracleDbType.Int32).Value = dosyaNo;
                        cmd.Parameters.Add("PROTOKOL_NO", OracleDbType.Int32).Value = protokolNo;


                        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);


                            dataTable.Columns.Add("PROTOKOL", typeof(string));

                            foreach (DataRow row in dataTable.Rows)
                            {
                                row["PROTOKOL"] = protokolNo;
                            }

                            // **Sütun tekrarlarını önlemek için önce temizleyelim**
                            dataGridHastaILac.DataSource = null;
                            dataGridHastaILac.Columns.Clear();

                            dataGridHastaILac.DataSource = dataTable;
                            dataGridHastaILac.AllowUserToAddRows = false;
                            dataGridHastaILac.RowHeadersVisible = false;

                            dataGridHastaILac.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dataGridHastaILac.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#666666");
                            dataGridHastaILac.DefaultCellStyle.SelectionForeColor = Color.White;


                            for (int i = 0; i < dataGridHastaILac.Rows.Count; i++)
                            {
                                if (i % 2 == 0)
                                    dataGridHastaILac.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f2f2f2");
                                else
                                    dataGridHastaILac.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f8f8ff");

                                if (dataTable.Columns.Count > 0)
                                {

                                    dataGridHastaILac.Columns[0].HeaderText = "DOSYA NO";
                                    dataGridHastaILac.Columns[0].DataPropertyName = "DOSYA_NO";

                                    dataGridHastaILac.Columns[1].HeaderText = "PROTOKOL";
                                    dataGridHastaILac.Columns[1].DataPropertyName = "PROTOKOL";

                                    dataGridHastaILac.Columns[2].HeaderText = "RECETE ID";
                                    dataGridHastaILac.Columns[2].DataPropertyName = "RECETE_ID";

                                    dataGridHastaILac.Columns[3].HeaderText = "GELIS TARIHI";
                                    dataGridHastaILac.Columns[3].DataPropertyName = "GTARIH";
                                    dataGridHastaILac.Columns[3].DefaultCellStyle.Format = "dd-MM-yyyy";

                                    dataGridHastaILac.Columns[4].HeaderText = "ILAC ADI";
                                    dataGridHastaILac.Columns[4].DataPropertyName = "ILAC_ADI";

                                    dataGridHastaILac.Columns[5].HeaderText = "BARKOD";
                                    dataGridHastaILac.Columns[5].DataPropertyName = "BARKOD";

                                    dataGridHastaILac.Columns[6].HeaderText = "KAC KUTU";
                                    dataGridHastaILac.Columns[6].DataPropertyName = "KAC_KUTU";

                                    dataGridHastaILac.Columns[7].HeaderText = "KULLANIM SEKLI";
                                    dataGridHastaILac.Columns[7].DataPropertyName = "SEKIL";

                                    dataGridHastaILac.Columns[8].HeaderText = "KULLANIM PERIYODU";
                                    dataGridHastaILac.Columns[8].DataPropertyName = "PERIYOD";

                                    dataGridHastaILac.Columns[9].HeaderText = "KAC DOZ";
                                    dataGridHastaILac.Columns[9].DataPropertyName = "KAC_DOZ";

                                    dataGridHastaILac.Columns[10].HeaderText = "ACIKLAMA";
                                    dataGridHastaILac.Columns[10].DataPropertyName = "ACIKLAMA";


                                }
                            }
                        }
                    }


                    // Kolon sıralamalarını sabitle
                    dataGridHastaILac.Columns[0].DisplayIndex = 0;
                    dataGridHastaILac.Columns[1].DisplayIndex = 1;
                    dataGridHastaILac.Columns[2].DisplayIndex = 2;
                    dataGridHastaILac.Columns[3].DisplayIndex = 3;
                    dataGridHastaILac.Columns[4].DisplayIndex = 4;
                    dataGridHastaILac.Columns[5].DisplayIndex = 5;
                    dataGridHastaILac.Columns[6].DisplayIndex = 6;
                    dataGridHastaILac.Columns[7].DisplayIndex = 7;
                    dataGridHastaILac.Columns[8].DisplayIndex = 8;
                    dataGridHastaILac.Columns[9].DisplayIndex = 9;
                    //dataGridHastaILac.Columns[10].DisplayIndex = 10;

                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {


        }
        private void button1_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = "/c start https://recetem.enabiz.gov.tr/",
                CreateNoWindow = true,
                UseShellExecute = false
            });
        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            if (dataGridHastaILac.SelectedCells.Count > 0)
            {
                int selectedIndex = dataGridHastaILac.SelectedCells[0].RowIndex;
                int receteID = Convert.ToInt32(dataGridHastaILac.Rows[selectedIndex].Cells["RECETE_ID"].Value);

                OracleDbHelper dbHelper = new OracleDbHelper();

                using (OracleConnection conn = dbHelper.GetConnection())
                {

                    conn.Open();


                    string sql = "DELETE from HASTANE.RECETELER WHERE RECETE_ID = :RECETE_ID";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {

                        cmd.Parameters.Add(new OracleParameter(":RECETE_ID", OracleDbType.Int32)).Value = receteID;

                        int rowsAffected = cmd.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Reçete başarıyla silindi.");


                            dataGridHastaILac.Rows.RemoveAt(selectedIndex);
                        }
                        else
                        {
                            MessageBox.Show("Silme işlemi başarısız oldu.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir satır seçin.");
            }
        }

        private void dataGridHastaILac_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}














