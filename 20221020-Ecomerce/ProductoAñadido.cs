using System;
using System.Collections.Generic;
using System.Text;

namespace _20221020_Ecomerce
{
    internal  class ProductoAñadido
    {

       protected string codigo;
        string nombre;
        string descripcion;
        decimal precioSinIva;
        decimal cantidad;
        private decimal coste;
        private decimal importe;
        public string Codigo { get { return codigo; } set { codigo = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Descripcion { get { return descripcion; } set {descripcion = value; } }
        public decimal PrecioSinIva   {            get { return precioSinIva; }      set{          precioSinIva = value;}    }
        public decimal Cantidad { get { return cantidad; } set { cantidad = value; } }
        public decimal Coste { get { return coste; } set { coste = value; } }
        public decimal Importe { get { return importe; } set { importe = value; } }
        public  ProductoAñadido(string codigo, string nombre, string descripcion, decimal precioSinIva, decimal cantidad) { 
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            PrecioSinIva = precioSinIva;
            Cantidad = cantidad;
            Importe = coste * cantidad;
        }

        public override string ToString()
        {
            return "codigo producto:" + codigo + ", nombre:" + nombre + ", descripción:" + descripcion + ", precio sin iva:" + PrecioSinIva + ", Cantidad:" + cantidad;
        }
    }
}
