using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess;
namespace OracleDatabaseConnectionExample
{
    public class OracleDbHelper
    {
        private readonly string _connectionString;

        // Constructor: Bağlantı dizesini burada tanımlıyoruz
        public OracleDbHelper()
        {
            // Oracle bağlantı dizesi
            _connectionString = "User Id=HASTANE;Password=hastane;" +
                                 "Data Source=(DESCRIPTION =(ADDRESS_LIST =" +
                                 "(ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521)))" +
                                 "(CONNECT_DATA =(SERVICE_NAME = ORCL)));";
        }

        // Bağlantıyı almak için bir metot
        public OracleConnection GetConnection()
        {
            return new OracleConnection(_connectionString);
        }

        // Örnek bir bağlantı testi metodu
        public bool TestConnection()
        {
            using (OracleConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Oracle veritabanına başarıyla bağlanıldı!");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Bağlantı hatası: {ex.Message}");
                    return false;
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }
    }
}
