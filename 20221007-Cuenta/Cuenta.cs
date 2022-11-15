using System;
using System.Collections.Generic;
using System.Text;

namespace _20221007_Cuenta
{
    internal class Cuenta
    {

        protected string IBAN;
        protected decimal saldo;
        protected Persona titular;
        public Persona Titular
        {
            get { return titular; } 
            private set { titular = value; }    
        }
        public decimal Saldo
        {
            get { return saldo; }
        }
      public  Cuenta(string iBAN, decimal saldo, Persona titular)
        {
            IBAN = iBAN;
            this.saldo = (saldo<=0) ?  0:saldo;
            this.titular = titular;
        }
        public Cuenta( Persona titular)
        {
            this.titular = titular;
        }
        public Cuenta()
        {
            
        }

        public void retirar(decimal ret)
        {
            if (saldo > 0)
            {
                Console.WriteLine("retirando:" + ret);

                saldo = saldo - ret;

            }
        }
        public void ingresar(decimal ret)
        {
            if (saldo > 0)
            {
                Console.WriteLine("ingresando:" + ret);
                saldo = saldo + ret;
            }
        }

        public void transferir(Cuenta c,decimal importe)
        {
            if(importe > 0)
            {
                Console.WriteLine(titular.Nombre+"transfiriendo:"+importe+" a "+c.titular.Nombre);
                retirar(importe);
                c.ingresar(importe);
            }

        }
        public override string ToString()
        {
            return "**INFORMACION CUENTA**\r\n" + "Titular:" + titular.ToString() + "\r\n Saldo:" + saldo + "\r\nIBAN:" + IBAN;


        }
        
    }
}
