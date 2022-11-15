using System;
using System.Collections.Generic;
using System.Text;

namespace _20221020_Ecomerce
{
    internal class ProductoVirtual:Producto

    {

        string fichero;
        double peso;
        public string Fichero { get { return fichero; } set { fichero = value; } }
        public double Peso { get { return peso; } set { peso = value; } 

        }

        public ProductoVirtual(string codigo, string nombre, string descripcion, decimal precioSinIva, decimal stock, string fichero,double peso)
           : base(codigo, nombre, descripcion, precioSinIva, stock)
        {
            this.peso = peso;
            this.fichero = fichero;

        }
        public override string ToString()
        {
            return base.ToString() + ", fichero:" + fichero + " , Tamaño fichero:"+peso;
        }

    }
}

