using System;
using System.Collections.Generic;
using System.Text;

namespace _20221005_OOP.Classes
{
    internal class Persona
    {
           public string name { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public DateTime birthDate { get; set; }
            public bool cansado = false;

        public void Estudiar() {
            Console.WriteLine("Estoy estudiando");

        }
        public void Correr()
        {
            Console.WriteLine("Estoy corriendo");
            cansado = true;
        }
    }
}
