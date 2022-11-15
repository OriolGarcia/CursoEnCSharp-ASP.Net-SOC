using System;
using System.Collections.Generic;
using System.Text;

namespace _20221011_Varios
{
    public enum Color
    {
        Blanco,
        Rojo,
        Negro,
        Azul,
        Verde,
        Amarillo
   }


    internal class Coche
    {
        private Color col;
        private string marca;

        public Color Col { get; set; }
        private string matricula = "";
        public string Matricula { get { return matricula; } set { matricula = value; } }
        private void Repintar(Color col)
        {
            this.col = col;


           }
    }
}
