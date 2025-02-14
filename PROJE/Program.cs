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
            // OracleDbHelper kullanarak ba�lant�y� test et
            OracleDbHelper dbHelper = new OracleDbHelper();

            // Ba�lant�y� test et
            if (dbHelper.TestConnection())
            {
                Console.WriteLine("Ba�lant� ba�ar�l�, sorgular �al��t�r�labilir!");
            }
            else
            {
                Console.WriteLine("Ba�lant� hatas�, sorgular �al��t�r�lamaz.");
            }

            // Uygulamay� ba�lat
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
