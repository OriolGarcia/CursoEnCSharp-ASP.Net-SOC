using System;
using System.Collections.Generic;
using System.Text;

namespace _20221006_Animales
{
    internal class Herbivoro :Animal
    {
        //Datos
        protected bool comeHierba = false;

        //Propiedades
        public bool ComeHierba
        {
            get { return comeHierba; }
            set { comeHierba = value; }
        }

        //Métodos
        public void ComiendoHierba()
        {
            Console.WriteLine("El hervíboro está comiendo hierba tranquilamente");
            ComeHierba = true;

        }

        public override string ToString()
        {
            string resultado = base.ToString() + "\r\n" +
                "Come hierba = " + comeHierba;

            return resultado;
        }
    }
}
