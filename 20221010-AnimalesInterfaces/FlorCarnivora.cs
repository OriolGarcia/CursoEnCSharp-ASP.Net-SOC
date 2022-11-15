using System;
using System.Collections.Generic;
using System.Text;

namespace _20221010_AnimalesInterfaces
{
    internal class FlorCarnivora : Planta,ICarnivoro
    {
        private float velocidad = 0;

        public float Velocidad { get { return velocidad; } set { if (value > 0 && value < 100) velocidad = value; } }
        public void ComeCarne()
        {
            Console.WriteLine("Como insectos muy buenos");
        }

        public void ComeCarne(Animal a)
        {
            Console.WriteLine("Que bueno está este insecto");
        }
    }
}
