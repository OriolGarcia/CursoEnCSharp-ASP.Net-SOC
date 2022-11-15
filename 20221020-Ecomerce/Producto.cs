using System;
using System.Collections.Generic;
using System.Text;

namespace _20221020_Ecomerce
{
    internal abstract class Producto
    {

       protected string codigo;
        string nombre;
        string descripcion;
        decimal precioSinIva;
        decimal stock;
        public string Codigo { get { return codigo; } set { codigo = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Descripcion { get { return descripcion; } set {descripcion = value; } }
        public decimal PrecioSinIva   {            get { return precioSinIva; }      set{          precioSinIva = value;}    }
        public decimal Stock { get { return stock; } set { stock = value; } }
        public string cantidadStock()
        {
            return stock > 10 ? stock > 100 ? "Alto" : "Medio" : "Bajo";
        }

       public  Producto(string codigo, string nombre, string descripcion, decimal precioSinIva, decimal stock) { 
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            PrecioSinIva = precioSinIva;
            Stock = stock;
            
        }

        public override string ToString()
        {
            return "codigo producto:" + codigo + ", nombre:" + nombre + ", descripción:" + descripcion + ", precio sin iva:" + PrecioSinIva + ", Stock:" + cantidadStock();
        }
    }
}
