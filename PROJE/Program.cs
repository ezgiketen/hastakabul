using OracleDatabaseConnectionExample;

namespace PROJE
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // OracleDbHelper kullanarak bağlantıyı test et
            OracleDbHelper dbHelper = new OracleDbHelper();

            // Bağlantıyı test et
            if (dbHelper.TestConnection())
            {
                Console.WriteLine("Bağlantı başarılı, sorgular çalıştırılabilir!");
            }
            else
            {
                Console.WriteLine("Bağlantı hatası, sorgular çalıştırılamaz.");
            }

            // Uygulamayı başlat
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
