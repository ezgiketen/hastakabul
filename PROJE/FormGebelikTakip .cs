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


            string[] kanGrubu =
            {
                "A Rh+", "A Rh-", "B Rh+", "B Rh-", "AB Rh+", "AB Rh-", "O Rh+", "O Rh-"
            };

            cmbKan.Items.AddRange(kanGrubu);
            cmbKanEs.Items.AddRange(kanGrubu);
        }

        private void btnYeniTakip_Click(object sender, EventArgs e)
        {
            FormGebelikYeniTakip gebelikYeniTakipForm = new FormGebelikYeniTakip();

            gebelikYeniTakipForm.Show();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
