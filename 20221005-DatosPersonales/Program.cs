using System;
using System.IO;

namespace _20221005_DatosPersonales
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("BIENVENIDO!");
            Console.WriteLine("Cuál es tu nombre?");
            string nombre = Console.ReadLine();
            Console.WriteLine("Cuál es tu edad?");
            string edad = Console.ReadLine();        
            Console.WriteLine("Hola "+nombre+", tiene "+edad+" años");
            int edadint = int.Parse(edad);
            Console.WriteLine("Acceso area restringida:" + (edadint >= 18));
            DateTime hoy = DateTime.Today;
            int AñoNac = hoy.Year - edadint;
            Console.WriteLine("Año nacimiento" + AñoNac);
            Console.WriteLine(nombre+" ha nacido hen año de olimpiadas?" + (AñoNac % 4==0));
            

        }
    }
}
