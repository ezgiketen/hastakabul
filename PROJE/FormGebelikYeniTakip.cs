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
    public partial class FormGebelikYeniTakip : Form
    {
        public FormGebelikYeniTakip()
        {
            InitializeComponent();
        }

        private void FormGebelikYeniTakip_Load(object sender, EventArgs e)
        {
            // Formun genişlik ve yükseklik değerleri (Örneğin: 800x600)
            this.Width = 900;
            this.Height = 600;

            // Ekran genişliği ve yüksekliği
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            // Formun ortalanması için X ve Y koordinatları
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((screenWidth - this.Width) / 2, (screenHeight - this.Height) / 2);


            string[] haftalar = { "1.Dönem (0-14 HAFTA)", "2.Dönem (18-24 HAFTA)", "3.Dönem (28-32 HAFTA)", "4.Dönem (36-38 HAFTA)" };
            cmbHafta.Items.AddRange(haftalar);

            string[] demir = { "Devam Ediyor", "Yeni Başlandı", "Başlanmadı" };
            cmbDvitamini.Items.AddRange(demir);
            cmbDemir.Items.AddRange(demir);

            string[] risk = { "Risk Yok", "Riskli", "Yüksek Riskli" };
            cmbRisk.Items.AddRange(risk);


        }

        private void cmbHafta_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtKilo_TextChanged(object sender, EventArgs e)
        {
            if (!txtKilo.Text.EndsWith(" kg"))
            {
                txtKilo.Text = txtKilo.Text.Trim() + " kg";
                txtKilo.SelectionStart = txtKilo.Text.Length - 3;
            }
        }

        private void txtBoy_TextChanged(object sender, EventArgs e)
        {
            if (!txtBoy.Text.EndsWith(" cm"))
            {
                txtBoy.Text = txtBoy.Text.Trim() + " cm";
                txtBoy.SelectionStart = txtBoy.Text.Length - 3;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
