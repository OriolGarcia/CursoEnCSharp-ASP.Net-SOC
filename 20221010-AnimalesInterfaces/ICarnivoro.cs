using System;
using System.Collections.Generic;
using System.Text;

namespace _20221010_AnimalesInterfaces
{
    internal interface ICarnivoro
    {

        public float Velocidad { get; set; }
       public void ComeCarne(Animal a);
          void Algo()
        {
            Console.WriteLine("El animal carnivoro está haciendo algo");
        }
    }
}
