using System;
using System.Runtime.CompilerServices;
using Utilidades;

namespace _20221108_CRUDCustomers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true){
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("[C]Create, [R]Select, [U]Update, [D]Delete [S]Salir");
                string opcion=Console.ReadLine().ToUpper();
                if (opcion == "S")
                { Console.WriteLine("Esta seguro que quiere Salir?(S/n)");
                    string resp = Console.ReadLine().ToUpper() ;
                    if(resp == "S")
                    break;
                }
                switch (opcion)
                {
                    case "C":
                        UtilsDB.AddCustomer();
                        break;
                    case "R":
                        UtilsDB.GetListadoBasicoCustomers();
                        break;
                    case "U":
                        UtilsDB.UpdateCustomer();
                        break;
                    case "D":
                        break;
                }

            }
        }
       
    }
        
}
