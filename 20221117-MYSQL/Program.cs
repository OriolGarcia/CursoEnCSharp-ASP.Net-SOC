using System;
using MySqlConnector;
namespace _20221117_MYSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string strConn = "Server=192.185.191.185;User ID=cifo_OGS;Password=Cifo2022$;Database=cifo_OGS";
            MySqlConnection conn= new MySqlConnection(strConn);
            string sql = "Select ProductName, UnitPrice, UnitsInStock From Products ORDER BY ProductName";
            MySqlDataReader reader = null; ;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) + "\t\t"
                        + reader.GetDecimal(1) + "\t\t"
                        + reader.GetInt16(2));

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (reader != null)
                {

                    reader.Close();
                    reader.Dispose();

                }
            }
        }
    }
}
