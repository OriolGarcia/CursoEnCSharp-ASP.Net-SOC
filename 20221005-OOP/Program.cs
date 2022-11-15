using System;
using System.Linq;
using _20221005_OOP.Classes;
namespace _20221005_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persona p1 = new Persona();    
            Persona p2 = new Persona();
            Alumno a1 = new Alumno(); 

            Alumno a2 = new Alumno();

            a1.Estudiar();

            p1.name = "Oriol";
            p1.birthDate = new DateTime(1990, 4, 11);
            p1.lastName = "Garcia";
            p1.Estudiar();
            p1.Correr();

        }
    }
}
