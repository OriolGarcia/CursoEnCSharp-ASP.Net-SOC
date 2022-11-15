using System;
using System.Collections.Generic;

namespace _20221108_EntityFrameworkCore.Models
{
    public partial class Products
    {
        
        public static void PrintHeader()
        {
            Console.WriteLine("Nombre\t\tPrecio\t\tStock\t\tCategoria\t\tProveedor");
            Console.WriteLine("---------------------------------------------------------------------------------");


        }
    }
}
