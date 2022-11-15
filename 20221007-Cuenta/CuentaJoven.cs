using System;
using System.Collections.Generic;
using System.Text;

namespace _20221007_Cuenta
{
    internal class CuentaJoven : Cuenta
    {
        private decimal bonificacion;
        public decimal Bonificacion{
            get{ return bonificacion; }
            set{ bonificacion = value; }
            }
        public void cogerOferta()
        {
            bonificacion = 0.30M;
            Console.WriteLine("Estoy coginedo la mejor oferta para un viaje");

        }
        public CuentaJoven() { }
        public CuentaJoven(string iBAN, Decimal saldo, Persona titular,decimal bonificacion) :base(iBAN,saldo,titular)
        {
            IBAN = iBAN;
            this.saldo = saldo;
            this.titular = titular;
            this.bonificacion = bonificacion;
        }

        public static bool estitularValido(Persona p)
        {
           if((DateTime.Now-p.Fecha_Nacimiento).TotalDays/365.25>18&&(DateTime.Now - p.Fecha_Nacimiento).TotalDays / 365.25 < 25)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public override string ToString()
        {
            return base.ToString() + "\r\n Bonificación: " + bonificacion;

        }
    }
}
