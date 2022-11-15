using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Numerics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Utilidades
{
    public static class UtilsDB
    {
        private static string strConn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Neptuno;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static void GetProducts(string search)
        {

            search = search.Trim();
            //prep sql
            string sql = "SELECT p.ProductName,c.CategoryName,p.UnitPrice,p.UnitsInStock " +
                " FROM Categories c INNER JOIN Products p "+
                "ON c.CategoryID = p.CategoryID "
                +"WHERE c.CategoryName Like '%"+search+ "%' or c.Description Like '%"+search+ "%'"+
                " or p.ProductName Like '%"+search+"%'"+
              " or p.QuantityPerUnit Like '%" + search + "%'"
               + " ORDER BY p.ProductName";
            SqlDataReader reader = GetReader(sql);
            Console.WriteLine("****************************************");

            Console.WriteLine("       Listado de productos ");
            Console.WriteLine("****************************************");

            Console.WriteLine("    Producto     ||    Categoria     ||     Precio     ||     Stock    ");

            if (reader != null)
            {
                int count = 0;
                while (reader.Read())
                {
                    count++;
                    string product = reader.GetString("ProductName");
                    string Category = reader.GetString("CategoryName");
                    decimal precio = reader.GetDecimal("UnitPrice");
                    int unitsInStock = reader.GetInt16("UnitsInStock");
                    Console.WriteLine(product + "  " + Category + "  " + precio.ToString("N2") + "  " + unitsInStock);
                }

                if (count > 0)
                {
                    Console.WriteLine("Resultados encontrados:" + count);
                }
                else { Console.WriteLine("No hay productos para la búsqueda"); }
                reader.Close();
                reader.Dispose();
            }
            else { Console.WriteLine("No hay productos para la búsqueda"); }
        }
        public static void GetCostumers(string search)
        {

            search = search.Trim();
            //prep sql
            string sql = "SELECT  c.[CustomerID],[CompanyName],[ContactName] ,[ContactTitle],[City],[Country]" +
                ",[Phone]   , SUM([UnitPrice] *[Quantity] * (1 -[Discount]))AS 'TOTAL IMPORTE' " +
                " FROM[Neptuno].[dbo].[Customers] c left JOIN Orders o ON c.CustomerID = o.CustomerID " +
                    " left join[Order Details] od ON od.OrderID = o.OrderID " +
                    "Where [CompanyName]Like '%"+search+ "%' or [ContactName]Like '%"+search+ "%' or [Country]Like '%" + search + "%' or [City]Like '%" + search + "%'" +
                   " GROUP BY c.[CustomerID]   ,[CompanyName] ,[ContactName],[ContactTitle] ,[City]  ,[Country],[Phone],[Fax]";
            SqlDataReader reader = GetReader(sql);
            Console.WriteLine("****************************************");

            Console.WriteLine("       Listado de productos ");
            Console.WriteLine("****************************************");

            Console.WriteLine("CustomerID  ||  CompanyName  ||  ContactName  ||  ContactTitle  ||  City  ||  Country  ||  Phone  ||  Fax  ||  TOTALIMPORTE");

            if (reader != null)
            {
                int count = 0;
                while (reader.Read())
                {
                    count++;
                    string CustomerID = reader.GetString("CustomerID");
                    string CompanyName = reader.GetString("CompanyName");
                    string ContactName = reader.GetString("ContactName");
                    string ContactTitle = reader.GetString("ContactTitle");
                    string City = reader.GetString("City");
                    string Country = reader.GetString("Country");
                    string Phone = reader.GetString("Phone");
                   
                    double TOTALIMPORTE = !reader.IsDBNull("TOTAL IMPORTE") ? reader.GetDouble("TOTAL IMPORTE"):0;
                 
                    Console.WriteLine(CustomerID + "  " + CompanyName + "  " + ContactName + "  " + ContactTitle+" " + City+ " "+Country+" "+ Phone + "  "+TOTALIMPORTE);
                }

                if (count > 0)
                {
                    Console.WriteLine("Resultados encontrados:" + count);
                }
                else { Console.WriteLine("No hay productos para la búsqueda"); }
                reader.Close();
                reader.Dispose();
            }
            else { Console.WriteLine("No hay productos para la búsqueda"); }
        }
        private static SqlDataReader GetReader(string sql)
        {
            SqlDataReader reader = null;
            try
            {

               
                //protocolo acceso base de datos
                SqlConnection conn = new SqlConnection(strConn);

                //Crear el command
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Abrir la conexión
                conn.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return reader;
        }
    }
}
