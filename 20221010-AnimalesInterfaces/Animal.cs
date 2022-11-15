using System;
using System.Collections.Generic;
using System.Text;

namespace _20221010_AnimalesInterfaces
{
    internal abstract class Animal
    {

        public virtual void  Caminar()
        {
            Console.WriteLine("Camino tranquilamente...");
        }
        public virtual void destruirse() { Console.WriteLine("soy destruido"); }
        public virtual void Respirar()
        {

            Console.WriteLine("RESPIRO");
        }
        public virtual void Reproducirse() { Console.WriteLine("Me reproduzco"); }
        public abstract void Expresarse();
    }
}
