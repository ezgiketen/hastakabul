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

namespace PROJE
{
    public partial class FormTani : Form
    {
        public int dosyaNo { get; set; }
        public int protokolNo { get; set; }
        public string hastaAdi { get; set; }
        public string hastaSoyadi { get; set; }
        public long tcKimlikNo { get; set; }
        public string tema { get; set; }

        public DateTime gTarih { get; set; }



        string icdKodu;


        private DataTable taniDataTable;
        public FormTani()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;  // Tam ekran başlatma
        }

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

        private void FormTani_Load(object sender, EventArgs e)
        {

            string hastaAd = hastaAdi;
            string hastaSoyad = hastaSoyadi;
            long tc = tcKimlikNo;
            int dosya = dosyaNo;
            int protokol = protokolNo;
            string temaSec = tema;

            lblAd.Text = hastaAdi;
            lblDosyaNo.Text = dosyaNo.ToString();
            lblTc.Text = tcKimlikNo.ToString();



            // Satır seçim modunu tam satır olarak ayarla
            dataGridViewGöster.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewGöster.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#e0eee0");
            dataGridViewGöster.DefaultCellStyle.SelectionForeColor = Color.Black;


            // Satır seçim modunu tam satır olarak ayarla
            dataGridViewTani.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTani.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#008b45");
            dataGridViewTani.DefaultCellStyle.SelectionForeColor = Color.White;

            TanilariGetirVeGoster(dosyaNo);

            txtTaniAra.TextChanged += txtTaniAra_TextChanged;


            OracleDbHelper dbHelper = new OracleDbHelper();

            using (OracleConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT A_ICDADI FROM HASTANE.TANI_GRUP_ARA";

                using (OracleCommand command = new OracleCommand(sql, conn))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        cmbTani.Items.Clear();

                        while (reader.Read())
                        {
                            cmbTani.Items.Add(reader["A_ICDADI"].ToString());
                        }
                    }
                }
            }

        }

        private void cmbTani_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleDbHelper dbHelper = new OracleDbHelper();
            using (OracleConnection connection = dbHelper.GetConnection())
            {
                connection.Open();
                string taniAdi = cmbTani.SelectedItem.ToString();

                // Seçilen ICD aralığını al
                string sql1 = "SELECT A_ICD FROM HASTANE.TANI_GRUP_ARA WHERE A_ICDADI = :ADI";
                string icdAraligi = "";

                using (OracleCommand command = new OracleCommand(sql1, connection))
                {
                    command.Parameters.Add(new OracleParameter("ADI", taniAdi));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            icdAraligi = reader["A_ICD"].ToString();  // Örn: "L80 - L99" veya "L80"
                        }
                    }
                }

                if (!string.IsNullOrEmpty(icdAraligi))
                {
                    string sql2 = "";
                    OracleCommand command2 = new OracleCommand();

                    if (icdAraligi.Contains("-"))
                    {
                        // Aralığı parçala
                        string[] parts = icdAraligi.Split('-');
                        if (parts.Length == 2)
                        {
                            string icdBaslangic = parts[0].Trim();
                            string icdBitis = parts[1].Trim();
                            sql2 = "SELECT ICD, TANI FROM HASTANE.TANILAR WHERE ICD BETWEEN :ICD1 AND :ICD2";

                            command2 = new OracleCommand(sql2, connection);
                            command2.Parameters.Add(new OracleParameter("ICD1", icdBaslangic));
                            command2.Parameters.Add(new OracleParameter("ICD2", icdBitis));
                        }
                    }
                    else
                    {

                        sql2 = "SELECT ICD, TANI FROM HASTANE.TANILAR WHERE ICD = :ICD1";

                        command2 = new OracleCommand(sql2, connection);
                        command2.Parameters.Add(new OracleParameter("ICD1", icdAraligi.Trim()));
                    }

                    using (OracleDataAdapter adapter = new OracleDataAdapter(command2))
                    {
                        taniDataTable = new DataTable();
                        adapter.Fill(taniDataTable);
                        dataGridViewTani.DataSource = taniDataTable;
                    }

                    dataGridViewTani.RowHeadersVisible = false;
                    dataGridViewTani.AllowUserToAddRows = false;
                    dataGridViewTani.Columns[0].Width = 200;
                    dataGridViewTani.Columns[1].Width = 1130;



                    RenklendirGrid();
                }




            }
        }

        private void txtTaniAra_TextChanged(object sender, EventArgs e)
        {
            if (taniDataTable != null)
            {
                string filterText = txtTaniAra.Text.Trim().Replace("'", "''"); // SQL Injection önleme
                taniDataTable.DefaultView.RowFilter = $"TANI LIKE '%{filterText}%'";


                RenklendirGrid();
            }

        }

        private void RenklendirGrid()
        {
            for (int i = 0; i < dataGridViewTani.Rows.Count; i++)
            {
                if (i % 2 == 0)
                    dataGridViewTani.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fbf2fb");
                else
                    dataGridViewTani.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f8fbf2");
            }
        }


        private void btnTaniEkle_Click(object sender, EventArgs e)
        {

            // Seçili satır yoksa uyarı ver
            if (dataGridViewTani.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen eklemek istediğiniz tanıyı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OracleConnection connection = new OracleDbHelper().GetConnection())
            {
                connection.Open();

                foreach (DataGridViewRow row in dataGridViewTani.SelectedRows)
                {
                    if (row.IsNewRow) continue;

                    icdKodu = row.Cells[0].Value?.ToString();
                    string taniAdi = row.Cells[1].Value?.ToString();

                    if (!string.IsNullOrEmpty(icdKodu) && !string.IsNullOrEmpty(taniAdi))
                    {
                        string sql = "INSERT INTO HASTANE.PROJE_TANILAR (DOSYA_NO, PROTOKOL_NO, ICD, TANI, GTARIH) " +
                                     "VALUES (:DOSYA_NO, :PROTOKOL_NO, :ICD, :TANI, :GTARIH)";

                        using (OracleCommand cmd = new OracleCommand(sql, connection))
                        {
                            cmd.Parameters.Add(":DOSYA_NO", OracleDbType.Int64).Value = dosyaNo;
                            cmd.Parameters.Add(":PROTOKOL_NO", OracleDbType.Int32).Value = protokolNo;
                            cmd.Parameters.Add(":ICD", OracleDbType.Varchar2).Value = icdKodu;
                            cmd.Parameters.Add(":TANI", OracleDbType.Varchar2).Value = taniAdi;
                            cmd.Parameters.Add("GTARIH", OracleDbType.Date).Value = gTarih;

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            TanilariGetirVeGoster(dosyaNo);

            MessageBox.Show("Tanı başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void TanilariGetirVeGoster(long dosyaNo)
        {
            using (OracleConnection connection = new OracleDbHelper().GetConnection())
            {
                connection.Open();
                string sql = "SELECT  DOSYA_NO ,PROTOKOL_NO, GTARIH, ICD, TANI FROM HASTANE.PROJE_TANILAR WHERE DOSYA_NO = :DOSYA_NO";

                using (OracleCommand cmd = new OracleCommand(sql, connection))
                {
                    cmd.Parameters.Add(":DOSYA_NO", OracleDbType.Int64).Value = dosyaNo;

                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable taniTable = new DataTable();
                        adapter.Fill(taniTable);
                        dataGridViewGöster.DataSource = taniTable;
                    }
                }
            }

            dataGridViewGöster.Sort(dataGridViewGöster.Columns["GTARIH"], ListSortDirection.Descending);

            for (int i = 0; i < dataGridViewGöster.Rows.Count; i++)
            {
                if (i % 2 == 0)
                    dataGridViewGöster.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f5f5f5");
                else
                    dataGridViewGöster.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#dddddd");
            }

            dataGridViewGöster.RowHeadersVisible = false;
            dataGridViewGöster.AllowUserToAddRows = false;
            dataGridViewGöster.Columns[0].Width = 150;
            dataGridViewGöster.Columns[1].Width = 150;
            dataGridViewGöster.Columns[2].Width = 190;
            dataGridViewGöster.Columns[3].Width = 190;
            dataGridViewGöster.Columns[4].Width = 1000;
        }

        private void btnTaniSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewGöster.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewGöster.SelectedRows[0].Index;
                string kod = dataGridViewGöster.Rows[selectedIndex].Cells["ICD"].Value.ToString();

                OracleDbHelper dbHelper = new OracleDbHelper();

                using (OracleConnection conn = dbHelper.GetConnection())
                {
                    conn.Open();

                    string sql = "DELETE from HASTANE.PROJE_TANILAR WHERE ICD = :ICD";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter(":ICD", OracleDbType.Varchar2)).Value = kod;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Tanı başarıyla silindi.");
                            dataGridViewGöster.Rows.RemoveAt(selectedIndex);
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



        private void txtTaniAra_Click(object sender, EventArgs e)
        {
            txtTaniAra.Text = string.Empty;
            txtTaniAra.ForeColor = System.Drawing.Color.Black;
        }

        private void cmbTani_Click(object sender, EventArgs e)
        {
            cmbTani.ForeColor = System.Drawing.Color.Black;
        }
    }
}
