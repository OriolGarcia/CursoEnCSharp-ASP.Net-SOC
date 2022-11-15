using System;

namespace _20221020_Ecomerce
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Ecommerce e = new Ecommerce("Amazon");
            while (true)
            {
                Console.WriteLine(" Bienvenido a tus compras en " + e.NombreComercio);

                Console.WriteLine("Elige:\r\n     1- Toda la lista de productos\r\n     2- Buscar por nombre y descripcion\r\n     3- Ir a caja");
                int opcion;
                if (int.TryParse(Console.ReadLine(), out opcion)) ;

                switch (opcion)
                {
                    case 1:
                        e.listarProductos();
                        break;
                    case 2:
                        e.buscador();
                        break;
                    case 3:
                        e.caja();
                        break;




                }

            }
        }
    }
}
