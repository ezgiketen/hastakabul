namespace PROJE
{
    public partial class FormLogin : Form  // UserControl yerine Form kullanıyoruz
    {
        public bool IsAuthenticated { get; private set; } = false;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string username = txtKullaniciAdi.Text;
            string password = txtSifre.Text;

            if (username == "admin" && password == "1234")
            {
                IsAuthenticated = true;
                this.DialogResult = DialogResult.OK;  // Başarılı giriş durumunda OK döndür
                this.Close();  // Login formunu kapat
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre!", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
