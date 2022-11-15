using System;

namespace _20221011_Varios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Coche c = new Coche() { Matricula="4334KJ",Col=Color.Blanco};
            Console.WriteLine("El coche con matricula " + c.Matricula + " es de color " + c.Col);
        }

        
    }
}
