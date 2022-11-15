using Microsoft.VisualBasic.FileIO;
using System;
using Utilidades;
namespace _22221104_Databases
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
          BuscadorProducts()
            */
            BuscadorCustomers();


        }
        private static void BuscadorProducts() {
            {
                while (true) { 
                    string search = "";
                do
                {
                    Console.WriteLine("Introduce el texto a buscar:");
                    search = Console.ReadLine();
                } while (search == "");
                if (search == "[S]") break;
                Console.Clear();
                UtilsDB.GetProducts(search);
            }
        }
    }
        private static void BuscadorCustomers() {
                    while (true)
                    {
                        string search = "";
                        do
                        {
                            Console.WriteLine("Introduce el texto a buscar:");
                            search = Console.ReadLine();
                        } while (search == "");
                        if (search == "[S]") break;
                        Console.Clear();
                        UtilsDB.GetCostumers(search);
                    }
    }
    }
}
