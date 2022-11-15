using System;
using System.Collections.Generic;
using System.Text;

namespace _20221010_AnimalesInterfaces
{
    internal class Aguila : Animal ,IVolador,ICarnivoro
    {
        private float velocidad = 0;

        public float Velocidad { get { return velocidad; } set { if (value > 0 && value < 100) velocidad = value; } }
        public void aterrizar()
        {
            Console.WriteLine("ATERRIZO");
        }

        public void ComeCarne(Animal a)
        {
            a.destruirse();
        }

        public override void Expresarse()
        {
            Console.WriteLine("Estoy chillando");
        }

        public void planear()
        {
            Console.WriteLine("PLANEO!");   
        }

        public void Volar()
        {
            Console.WriteLine("VUELO!!");
        }
    }
}
