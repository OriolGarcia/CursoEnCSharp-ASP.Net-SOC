using System;
using System.Collections.Generic;
using System.Text;

namespace _20221006_Animales
{
    internal class León : Carnivoro
    {
        internal class Leon : Carnivoro
        {
            //Datos
            protected string subEspecie = "";
            protected string color = "";

            //Propiedades
            public string SubEspecie
            {
                get { return subEspecie; }
                set { subEspecie = value; }

            }

            public string Color
            {
                get { return color; }
                set
                {
                    color = value;
                    Console.WriteLine(value == "Blanco" ? "El león es albino" : "El león no es albino");
                }
            }

            //Comportamiento
            public void Rugir()
            {
                Console.WriteLine("El León de " + subEspecie + " está rugiendo");

            }

            public void DaALuz()
            {
                Console.WriteLine((Sexo == 'F') == true ? "La leona tiene un cachorro" : "El león no puede dar a luz");
            }

            public override string ToString()
            {
                string resultado = base.ToString() + "\r\n" +
                                    "SubEspecie = " + subEspecie + "\r\n" +
                                    "Color = " + color;

                return resultado;
            }
        }
    }
}
