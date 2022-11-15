using System;
using System.Collections.Generic;
using System.Text;

namespace _20221006_Animales
{
    internal class Vaca:Herbivoro
    {
        protected bool lechera = false;

        //Propiedades

        public bool Lechera
        {
            get { return lechera; }
            set
            {
                lechera = Sexo == 'F' ? true : false;
                string daLeche = Sexo == 'F' ? " y da leche" : " y no da leche";
                Console.WriteLine("La vaca es " + sexo + daLeche);
            }
        }

        // Comportamiento
        public void Ordenyando()
        {
            Console.WriteLine(Sexo != 'F' ? "No se puede ordeñar" : "La vaca se está ordeñando");
        }

        // Método override
        public override string ToString()
        {
            return base.ToString() + "\r\n" +
                    "Es una vaca lechera : " + Lechera;
        }
    }
}
