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
    public partial class FormVezne : Form
    {
        public int dosyaNo { get; set; }
        public int protokolNo { get; set; }
        public string hastaAdi { get; set; }
        public string hastaSoyadi { get; set; }
        public long tcKimlikNo { get; set; }
        public string tema { get; set; }


        public FormVezne()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void FormVezne_Load(object sender, EventArgs e)
        {

        }
    }
}
