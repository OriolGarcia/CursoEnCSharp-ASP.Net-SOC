using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;

namespace _20221109_Linq.Dal
{
    public partial class Products
    {
        public static void PrintHeader()
        {
            Console.WriteLine("***************************");
            Console.WriteLine("Listado de Productos");
            Console.WriteLine("***************************");
            Console.WriteLine("");
            Console.WriteLine("Producto\t\tPrecio\t\tStock");
            Console.WriteLine("---------------------------");
        }

        public override string ToString()
        {
            return ProductName+"\t\t"+UnitPrice+"\t\t"+UnitsInStock;
        }
    }
}
