using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace _20221011_Static
{
    internal class Cuenta
    {
        //Atributos de objeto
        private string titular = "";
        private decimal saldo=0.05M;
        //Atributos de clase
        private static decimal interes = 0.03M;
        private static int contador = 0;
        //Propiedades
        public string Titular { get { return titular; } set { titular = value; } }
        public decimal Saldo { get { return saldo; } set { saldo = value; } }

        public static decimal Interes { get { return interes; } 
          //  set {interes = value; }
        }
        //Constructores
        public static int Contador { get { return contador; } }
        public static  void AjustarInteres(decimal valor)
        {
            interes = valor;
            Console.WriteLine("El interes del banco es:" + interes);

        }
        public Cuenta()
        {

            contador++;
        }
        public void AplicarInteres()
        {
            saldo = saldo + saldo * interes;

        }
        //Comportamiento
    }
}
