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
    public partial class FormIslemTetkik : Form
    {

        public int dosyaNo { get; set; }
        public int protokolNo { get; set; }
        public string hastaAdi { get; set; }
        public string hastaSoyadi { get; set; }
        public long tcKimlikNo { get; set; }
        public string tema { get; set; }

        private DataTable tetkikDataTable;

        public FormIslemTetkik()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormIslemTetkik_Load);
            this.WindowState = FormWindowState.Maximized;

        }


        private void FormIslemTetkik_Load(object sender, EventArgs e)
        {
            lblAd.Text = hastaAdi + " " + hastaSoyadi;
            lblTc.Text = tcKimlikNo.ToString();
            lblDosyaNo.Text = dosyaNo.ToString();


            // Satır seçim modunu tam satır olarak ayarla
            dataGridTetkik.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridTetkik.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#e0eee0");
            dataGridTetkik.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridHtetkik.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridHtetkik.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#e0eee0");
            dataGridHtetkik.DefaultCellStyle.SelectionForeColor = Color.Black;

            TanilariGetirVeGoster(protokolNo);

            try
            {
                OracleDbHelper dbHelper = new OracleDbHelper();

                using (OracleConnection conn = dbHelper.GetConnection())
                {
                    conn.Open();


                    string sql = "SELECT GRUP_ADI FROM HASTANE.LABGRUP";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            cmbTetkikAra.Items.Clear();

                            while (reader.Read())
                            {
                                string grupAdi = reader["GRUP_ADI"].ToString();
                                cmbTetkikAra.Items.Add(grupAdi);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }



        private void cmbTetkikAra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTetkikAra.SelectedItem == null) return;

            string secilenGrupAdi = cmbTetkikAra.SelectedItem.ToString();
            string grupKodu = "";

            OracleDbHelper dbHelper = new OracleDbHelper();
            using (OracleConnection connection = dbHelper.GetConnection())
            {
                connection.Open();

                string sql1 = "SELECT GRUP_KODU FROM HASTANE.LABGRUP WHERE GRUP_ADI = :GRUP";

                using (OracleCommand command = new OracleCommand(sql1, connection))
                {
                    command.Parameters.Add(new OracleParameter("GRUP", secilenGrupAdi));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            grupKodu = reader["GRUP_KODU"].ToString();
                        }
                    }
                }

                if (!string.IsNullOrEmpty(grupKodu))
                {
                    string sql2 = "SELECT KODU, GRUP_KODU, ISLEM, UCRETI, DRYUZDESI FROM HASTANE.ISLEMTIPI WHERE GRUP_KODU = :GRUP";

                    using (OracleCommand command2 = new OracleCommand(sql2, connection))
                    {
                        command2.Parameters.Add(new OracleParameter("GRUP", grupKodu));

                        using (OracleDataReader reader = command2.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            tetkikDataTable = dt;


                            if (!dataGridTetkik.Columns.Contains("chkSeçim"))
                            {
                                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                                checkBoxColumn.HeaderText = "Seçim";
                                checkBoxColumn.Name = "chkSeçim";
                                dataGridTetkik.Columns.Add(checkBoxColumn);
                            }

                            dataGridTetkik.DataSource = tetkikDataTable;
                        }
                    }

                    dataGridTetkik.RowHeadersVisible = false;
                    dataGridTetkik.AllowUserToAddRows = false;
                    dataGridTetkik.Columns[0].Width = 100;
                    dataGridTetkik.Columns[1].Width = 100;
                    dataGridTetkik.Columns[2].Width = 100;
                    dataGridTetkik.Columns[3].Width = 600;
                    dataGridTetkik.Columns[4].Width = 230;
                    dataGridTetkik.Columns[5].Width = 230;

                    RenklendirGrid();
                }
            }
        }

        private void txtTetkikAra_TextChanged(object sender, EventArgs e)
        {
            if (tetkikDataTable != null)
            {
                string filterText = txtTetkikAra.Text.Trim().Replace("'", "''");
                tetkikDataTable.DefaultView.RowFilter = $"ISLEM LIKE '%{filterText}%'";

                RenklendirGrid();
            }
        }


        private void RenklendirGrid()
        {
            for (int i = 0; i < dataGridTetkik.Rows.Count; i++)
            {
                if (i % 2 == 0)
                    dataGridTetkik.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fbf2fb");
                else
                    dataGridTetkik.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f8fbf2");
            }
        }

        private void txtTetkikAra_TextChanged_1(object sender, EventArgs e)
        {
            if (tetkikDataTable != null)
            {
                string filterText = txtTetkikAra.Text.Trim().Replace("'", "''");

                // Sütun adını kullanarak filtreleme
                tetkikDataTable.DefaultView.RowFilter = $"ISLEM LIKE '%{filterText}%'"; // ISLEM sütununu doğru şekilde kullanın

                RenklendirGrid(); // Grid görünümünü güncelleyin
            }
        }


        private void txtTetkikAra_Click(object sender, EventArgs e)
        {
            txtTetkikAra.Text = string.Empty;
            txtTetkikAra.ForeColor = System.Drawing.Color.Black;
        }

        private void btnTetkikEkle_Click(object sender, EventArgs e)
        {
            if (dataGridTetkik.Rows.Cast<DataGridViewRow>().All(row => !Convert.ToBoolean(row.Cells["chkSeçim"].Value)))
            {
                MessageBox.Show("Lütfen eklemek istediğiniz işlemi seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OracleConnection connection = new OracleDbHelper().GetConnection())
            {
                connection.Open();

                foreach (DataGridViewRow row in dataGridTetkik.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (Convert.ToBoolean(row.Cells["chkSeçim"].Value))
                    {
                        string grupKodu = row.Cells[1].Value?.ToString();
                        string kodu = row.Cells[2].Value?.ToString();
                        string ıslem = row.Cells[3].Value?.ToString();
                        string ucret = row.Cells[4].Value?.ToString();
                        string drYuzde = row.Cells[5].Value?.ToString();


                        ucret = ucret?.Replace(",", ".");
                        drYuzde = drYuzde?.Replace(",", ".");


                        if (string.IsNullOrEmpty(ucret)) ucret = "0";
                        if (string.IsNullOrEmpty(drYuzde)) drYuzde = "0";


                        decimal ucretDecimal;
                        decimal drYuzdeDecimal;

                        if (!decimal.TryParse(ucret, out ucretDecimal) || !decimal.TryParse(drYuzde, out drYuzdeDecimal))
                        {
                            MessageBox.Show("Geçersiz sayı formatı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (!string.IsNullOrEmpty(kodu))
                        {
                            string sql = "INSERT INTO HASTANE.PROJE_ISLEM_TETKIK (GRUP_KODU, KODU, ISLEM, UCRETI, DR_YUZDESI, DOSYA_NO, PROTOKOL_NO) " +
                                         "VALUES (:GRUP_KODU,:KODU, :ISLEM, :UCRETI, :DR_YUZDESI, :DOSYA_NO, :PROTOKOL_NO)";

                            using (OracleCommand cmd = new OracleCommand(sql, connection))
                            {
                                cmd.Parameters.Add(":GRUP_KODU", OracleDbType.Int64).Value = grupKodu;
                                cmd.Parameters.Add(":KODU", OracleDbType.Int64).Value = kodu;
                                cmd.Parameters.Add(":ISLEM", OracleDbType.Varchar2).Value = ıslem;
                                cmd.Parameters.Add(":UCRETI", OracleDbType.Decimal).Value = ucretDecimal;
                                cmd.Parameters.Add(":DR_YUZDESI", OracleDbType.Decimal).Value = drYuzdeDecimal;
                                cmd.Parameters.Add(":DOSYA_NO", OracleDbType.Int64).Value = dosyaNo;
                                cmd.Parameters.Add(":PROTOKOL_NO", OracleDbType.Int32).Value = protokolNo;

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            TanilariGetirVeGoster(protokolNo);

            MessageBox.Show("Tetkik eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TanilariGetirVeGoster(long protokolNo)
        {
            using (OracleConnection connection = new OracleDbHelper().GetConnection())
            {
                connection.Open();

                string sql = "SELECT GRUP_KODU, KODU, ISLEM, UCRETI, DR_YUZDESI, DOSYA_NO, PROTOKOL_NO FROM HASTANE.PROJE_ISLEM_TETKIK WHERE PROTOKOL_NO = :PROTOKOL_NO";

                using (OracleCommand cmd = new OracleCommand(sql, connection))
                {
                    cmd.Parameters.Add(":PROTOKOL_NO", OracleDbType.Int64).Value = protokolNo;

                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable taniTable = new DataTable();
                        adapter.Fill(taniTable);
                        dataGridHtetkik.DataSource = taniTable;
                    }
                }
            }


            for (int i = 0; i < dataGridHtetkik.Rows.Count; i++)
            {
                if (i % 2 == 0)
                    dataGridHtetkik.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f5f5f5");
                else
                    dataGridHtetkik.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#dddddd");
            }


            dataGridHtetkik.RowHeadersVisible = false;
            dataGridHtetkik.AllowUserToAddRows = false;
            dataGridHtetkik.Columns[0].Width = 125;
            dataGridHtetkik.Columns[1].Width = 125;
            dataGridHtetkik.Columns[2].Width = 620;
            dataGridHtetkik.Columns[3].Width = 125;
            dataGridHtetkik.Columns[4].Width = 125;
            dataGridHtetkik.Columns[5].Width = 125;
            dataGridHtetkik.Columns[6].Width = 125;
        }



        private void btnTetkikSil_Click(object sender, EventArgs e)
        {
            if (dataGridHtetkik.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridHtetkik.SelectedRows[0].Index;
                string kod = dataGridHtetkik.Rows[selectedIndex].Cells["GRUP_KODU"].Value.ToString();

                OracleDbHelper dbHelper = new OracleDbHelper();

                using (OracleConnection conn = dbHelper.GetConnection())
                {
                    conn.Open();

                    string sql = "DELETE from HASTANE.PROJE_ISLEM_TETKIK WHERE GRUP_KODU = :GRUP_KODU";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter(":GRUP_KODU", OracleDbType.Varchar2)).Value = kod;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Tetkik silindi.");
                            dataGridHtetkik.Rows.RemoveAt(selectedIndex);
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

        private void cmbTetkikAra_Click(object sender, EventArgs e)
        {
            
            cmbTetkikAra.ForeColor = System.Drawing.Color.Black;
        }
    }
}








