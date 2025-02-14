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
            // OracleDbHelper kullanarak baðlantýyý test et
            OracleDbHelper dbHelper = new OracleDbHelper();

            // Baðlantýyý test et
            if (dbHelper.TestConnection())
            {
                Console.WriteLine("Baðlantý baþarýlý, sorgular çalýþtýrýlabilir!");
            }
            else
            {
                Console.WriteLine("Baðlantý hatasý, sorgular çalýþtýrýlamaz.");
            }

            // Uygulamayý baþlat
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
