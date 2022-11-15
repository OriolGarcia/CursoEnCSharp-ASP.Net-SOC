using System;
using System.Diagnostics.CodeAnalysis;

namespace _20221007_Cuenta
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DateTime fechaNacimiento = new DateTime(2000, 04, 11);
            Persona p1 = new Persona( "Gerard", "45233841F", "+34610957388",fechaNacimiento);
            Cuenta c1=CrearCuenta( p1,"ES25222222", 200);
            DateTime fechaNacimiento2 = new DateTime(1990, 04, 11);
            Persona p2= new Persona( "Oriol", "45233841F", "+34610957388", fechaNacimiento2);
            Cuenta c2=CrearCuenta(p2, "ES25222222", 300);
            p1.ToString();
            p2.ToString();
            c1.ingresar(2);
            c1.retirar(1);
            c2.ingresar(2222);
            Console.WriteLine(c1.ToString());
            Console.WriteLine("-------------------------");
            Console.WriteLine(c2.ToString());
            c2.transferir(c1,500);

            Console.WriteLine("\n\n");
            Console.WriteLine(c1.ToString());
            Console.WriteLine("-------------------------");
            Console.WriteLine(c2.ToString());
        }

        public static Cuenta CrearCuenta(Persona persona,string iBAN,decimal saldo)
        {
            if (CuentaJoven.estitularValido(persona))
            {

                return new CuentaJoven(iBAN, saldo, persona, 0.3M);
            }
            else
            {
                return new Cuenta(iBAN, saldo, persona);
            }




        }

    }
}
