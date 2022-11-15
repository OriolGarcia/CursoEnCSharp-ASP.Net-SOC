

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.SqlClient;
    using System.Data;
using Neptuno.Models;
using System.Reflection.PortableExecutable;

namespace Utilidades
    {
        public static class UtilsDB
        {
            //Atributos
            private static string strConn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Neptuno;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //Métodos específicos
            public static void GetProducts(string search)
            {
                //Filtrado importante de la cadena search
                //TO_DO
                search = search.Replace("'", "''");


                //Preparación de la SQL
                string sql = "SELECT p.ProductName, c.CategoryName, p.UnitPrice, p.UnitsInStock " +
                        "FROM Categories c INNER JOIN Products p " +
                        "ON c.CategoryID = p.CategoryID " +
                        "WHERE c.CategoryName LIKE '%" + search + "%' OR " +
                        "c.Description LIKE '%" + search + "%' OR " +
                        "p.ProductName LIKE '%" + search + "%' OR " +
                        "p.QuantityPerUnit LIKE '%" + search + "%' " +
                        "ORDER BY p.ProductName";

                //Obtener los datos
                SqlDataReader reader = GetReader(sql);

                //Imprimir los datos

                Console.WriteLine("*********************************");
                Console.WriteLine("Listado de productos");
                Console.WriteLine("*********************************\r\n");

                Console.WriteLine("Producto\t\tCategoría\t\tPrecio\t\tStock");
                Console.WriteLine("--------------------------------------------");

                if (reader != null)
                {
                    int counter = 0;
                    while (reader.Read())
                    {
                        counter++;

                        string productName = reader.GetString("ProductName");
                        //string productName = reader.GetString(0);
                        string categoryName = reader.GetString("CategoryName");
                        decimal unitPrice = reader.GetDecimal("UnitPrice");
                        int unitsInStock = reader.GetInt16("UnitsInStock");

                        Console.WriteLine(productName + "\t\t" +
                                    categoryName + "\t\t" +
                                    unitPrice.ToString("N2") + "\t\t" +
                                    unitsInStock);
                    }
                    Console.WriteLine("--------------------------------------------");

                    if (counter > 0)
                    {
                        Console.WriteLine(counter + " registros");
                    }
                    else
                    {
                        Console.WriteLine("No hay registros para la búsqueda.");
                    }

                    //Cerrar el reader (y automáticamente la conexión)
                    reader.Close();
                    reader.Dispose();
                }
                else
                {
                    Console.WriteLine("No hay registros para la búsqueda.");
                }

            }

            public static void GetCustomers(string search)
            {
                //Filtrado importante de la cadena search
                //TO_DO
                search = search.Replace("'", "''");

                string sql = @$"SELECT c.CompanyName, c.ContactName, c.ContactTitle, c.City, 
	                    c.Country, c.Phone,
                    (
	                    SELECT SUM(od.Quantity * od.UnitPrice * (1 - od.Discount))
	                    FROM Orders o INNER JOIN [Order Details] od 
		                    ON o.OrderID = od.OrderID
	                    WHERE o.CustomerID = c.CustomerID
	                    GROUP BY o.CustomerID
                    ) AS Amount
                    FROM Customers c
                    WHERE c.CompanyName LIKE '%{search}%' OR 
                    c.ContactName LIKE '%{search}%' OR
                    c.City LIKE '%{search}%' OR
                    c.Country LIKE '%{search}%'
                    ORDER BY c.CompanyName";

                //Obtener los datos
                SqlDataReader reader = GetReader(sql);

                //Imprimir los datos

                //Imprimir cabecera del listado
                CustomerModel.PrintHeader();

                if (reader != null)
                {
                    int counter = 0;
                    while (reader.Read())
                    {
                        counter++;

                        CustomerModel cm = new CustomerModel
                        {
                            Order = counter,
                            CompanyName = reader.GetString("CompanyName"),
                            ContactName = reader.GetString("ContactName"),
                            ContactTitle = reader.GetString("ContactTitle"),
                            City = reader.GetString("City"),
                            Country = reader.GetString("Country"),
                            Phone = reader.GetString("Phone"),
                        };
                        try
                        {
                            cm.Amount = (decimal)reader.GetDouble("Amount");
                        }
                        catch
                        {
                            cm.Amount = null;
                        }

                        Console.WriteLine(cm.ToString());
                    }
                    Console.WriteLine("--------------------------------------------");

                    if (counter > 0)
                    {
                        Console.WriteLine(counter + " registros");
                    }
                    else
                    {
                        Console.WriteLine("No hay registros para la búsqueda.");
                    }

                    //Cerrar el reader (y automáticamente la conexión)
                    reader.Close();
                    reader.Dispose();
                }
                else
                {
                    Console.WriteLine("No hay registros para la búsqueda.");
                }
            }
        public static void GetListadoBasicoCustomers()
        {
            //Filtrado importante de la cadena search
            //TO_DO
           // search = search.Replace("'", "''");

            string sql = @$"SELECT c.CustomerId,c.CompanyName, c.ContactName, c.ContactTitle,c.Address, c.City, c.Region,
                        c.PostalCode,c.Country, c.Phone,c.Fax                  
                    FROM Customers c
                    ORDER BY c.CompanyName";

            //Obtener los datos
            SqlDataReader reader = GetReader(sql);

            //Imprimir los datos

            //Imprimir cabecera del listado
            CustomerModel.PrintHeader();

            if (reader != null)
            {
                int counter = 0;
                while (reader.Read())
                {
                    counter++;

                    Customer cm = new Customer
                    {
                        
                        CompanyName = reader.GetString("CompanyName"),
                        ContactName = reader.GetString("ContactName"),
                        ContactTitle = reader.GetString("ContactTitle"),
                        
                        Country = reader.GetString("Country"),
                       
                    };
                    

                    Console.WriteLine(cm.ToString());
                }
                Console.WriteLine("--------------------------------------------");

                if (counter > 0)
                {
                    Console.WriteLine(counter + " registros");
                }
                else
                {
                    Console.WriteLine("No hay registros para la búsqueda.");
                }

                //Cerrar el reader (y automáticamente la conexión)
                reader.Close();
                reader.Dispose();
            }
            else
            {
                Console.WriteLine("No hay registros para la búsqueda.");
            }
        }

        //Métodos generalistas
        private static SqlDataReader GetReader(string sql)
            {
                SqlDataReader reader = null;
                try
                {
                    //Protocolo de acceso a la Base de Datos
                    //Crear la conexión a la BD
                    SqlConnection conn = new SqlConnection(strConn);

                    //Crear el command para enviar la SQL a la BD a través de la conexión
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    //Abrir la conexión
                    conn.Open();

                    //Lanzar el command por la conexión para obtener respuesta de la BD
                    reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }

                return reader;
            }
        private static int ExcecuteNonQuery(string sql)
        {
            int affected = 0;
            SqlConnection conn = null;

            try {
                conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                affected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);

            }
            finally { if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }

            }


            return affected;

        }
        public static void AddCustomer()
        {
            Customer c= new Customer();
            Console.Write("CompanyName=");
           c.CompanyName = Console.ReadLine();
            Console.Write("ContactName=");
            c.ContactName = Console.ReadLine();
            Console.Write("ContactTitle =");
            c.ContactTitle = Console.ReadLine();
            Console.Write("Country=");
            c.Country = Console.ReadLine();
            Console.Write("Phone=");
            c.Phone = Console.ReadLine();
            c.CustomerID = (c.CompanyName.Length > 5) ? c.CompanyName.Substring(0, 5).ToUpper() : c.CompanyName.ToUpper();

            string sql = @"Insert into Customers(CustomerId,CompanyName,ContactName,ContactTitle,Country,Phone)
                        Values('" + c.CustomerID + "','" + c.CompanyName + "','" + c.ContactName + "','" + c.ContactTitle + "','" + c.Country + "','" +c.Phone + "')";
            int affected=ExcecuteNonQuery(sql);
            Console.WriteLine(affected+" Registros Afectados");
        }
        public static void UpdateCustomer()
        {
            Console.WriteLine("CustomerID:");
            string customerID=Console.ReadLine();
            Console.WriteLine("Campo a Actualizar");
            string campo=Console.ReadLine();
            Console.WriteLine("Valor a actualizar");
            string valor=Console.ReadLine();
            string sql="UPDATE Customers SET "+ campo+"='"+valor+"' Where CustomerID='" + customerID + "'";
            int affected = ExcecuteNonQuery(sql);
            Console.WriteLine(affected + " Registros Afectados");

        }
        }
        
    }

