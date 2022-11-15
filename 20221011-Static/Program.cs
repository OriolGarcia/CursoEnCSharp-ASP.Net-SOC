using System;

namespace _20221011_Static
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            Cuenta c1 = new Cuenta { Titular = "Oriol", Saldo = 2000.80M };
            Cuenta c2= new Cuenta { Titular = "Mercè", Saldo = 500};
           c1.Saldo= c1.Saldo * (1 + Cuenta.Interes);

            
            Cuenta.AjustarInteres(0.04M);
            c1.AplicarInteres();
            c2.AplicarInteres();
            Console.WriteLine("Saldo c1:"+c1.Saldo);
            Console.WriteLine("Saldo c2:" + c2.Saldo);
            c1.AplicarInteres();
            c2.AplicarInteres();
            Console.WriteLine("Saldo c1:" + c1.Saldo);
            Console.WriteLine("Saldo c2:" + c2.Saldo);

            Cuenta.AjustarInteres(0.1M);
            c1.AplicarInteres();
            c2.AplicarInteres();
            Console.WriteLine("Saldo c1:" + c1.Saldo);
            Console.WriteLine("Saldo c2:" + c2.Saldo);
            c1.AplicarInteres();
            c2.AplicarInteres();
            Console.WriteLine("Saldo c1:" + c1.Saldo);
            Console.WriteLine("Saldo c2:" + c2.Saldo);

            Console.WriteLine("El interes del banco es:" + Cuenta.Interes);
            Console.WriteLine("Hay " + Cuenta.Contador + " cuentas");
        }
    }
}
