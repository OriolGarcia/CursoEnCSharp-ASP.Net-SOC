using System;
using System.Collections.Generic;
using System.Text;

namespace _20221020_Ecomerce
{
    internal class ProductoFisico : Producto
    {

        private decimal costeEnvio;
        public decimal CosteEnvio { get { return costeEnvio; } set { costeEnvio = value; } }
        public ProductoFisico(string codigo, string nombre, string descripcion, decimal precioSinIva, decimal stock, decimal costeEnvio)
            :base(codigo,nombre, descripcion,precioSinIva,  stock)
        {
            costeEnvio = costeEnvio;

        }

        public override string ToString()
        {
            return base.ToString()+", coste envio:"+costeEnvio+" €";
        }
    }
}
