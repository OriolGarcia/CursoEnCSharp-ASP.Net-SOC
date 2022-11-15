using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _20221010_AnimalesInterfaces
{
    internal class SerHumano : Animal,IHerbiboro,  ICarnivoro
    {

        private float velocidad = 0;

        public float Velocidad { get{ return velocidad;  } set { if (value > 0 && value < 100) velocidad = value; } }

        public void ComeCarne(Animal a)
        {
            Console.WriteLine("Como carne cocinada");
            a.destruirse();
        }

        public void ComeHierba()
        {
            Console.WriteLine("Como verdura cocinada");
        }

        public void ComeHierba(Planta p)
        {
            p.destruirse();
        }

        public override void Expresarse()
        {
            Console.WriteLine("Estoy hablando");
        }
    }
}
