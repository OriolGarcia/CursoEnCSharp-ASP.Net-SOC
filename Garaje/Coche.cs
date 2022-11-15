using System;
using System.Collections.Generic;
using System.Text;

namespace Garaje
{
    enum Color
    {
        Blanco, Rojo, Azul, Gris


    }
    internal class Coche:Vehiculo
    {
        private string marca;
        private Color col;

        
        public Color Col { get { return col; } set { col = value; } }
    }
}
