using System;
using System.Collections.Generic;
using System.Text;


    namespace Neptuno.Models
    {
        public class CustomerModel
        {
            public int Order { get; set; }
            public string CompanyName { get; set; }
            public string ContactName { get; set; }
            public string ContactTitle { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string Phone { get; set; }
            public decimal? Amount { get; set; }

            public static void PrintHeader()
            {
                Console.WriteLine("*********************************");
                Console.WriteLine("Listado de clientes");
                Console.WriteLine("*********************************\r\n");

                Console.WriteLine("Cliente\t\tContacto\t\tCargo\t\tCiudad\t\tPaís\t\tTeléfono\t\tImporte Comprado");
                Console.WriteLine("----------------------------------------------------------------------------------");
            }

            public override string ToString()
            {
                return Order + "-" + CompanyName + "\t\t" +
                    ContactName + "\t\t" +
                    ContactTitle + "\t\t" +
                    City + "\t\t" +
                    Country + "\t\t" +
                    Phone + "\t\t " +
                    ((Amount != null) ? Amount.ToString() : "NULL");
            }
        }
    }

