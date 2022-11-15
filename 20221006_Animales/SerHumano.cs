using System;
using System.Collections.Generic;
using System.Text;

namespace _20221006_Animales
{
    internal class SerHumano : Carnivoro
    {
        protected string nombre = "";
        protected string numDni = "";


        //Propiedades
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }

        }

        public string NumDni
        {
            get { return numDni; }
            set { numDni = value; }

        }

        public SerHumano()
        {

        }
        //Métodos-Comportamiento
        public void Hablar()
        {
            Console.WriteLine("El serHumano " + nombre + " está hablando");

        }

        public void Bailar()
        {
            Console.WriteLine("El serHumano " + nombre + " está bailando");

        }

        public override string ToString()
        {
            string resultado = base.ToString() + "\r\n" +
                                "Nombre = " + nombre + "\r\n" +
                                "DNI = " + numDni;

            return resultado;
        }
    }
}
