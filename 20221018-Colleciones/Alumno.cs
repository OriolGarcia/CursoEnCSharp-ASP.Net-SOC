using System;
using System.Collections.Generic;
using System.Text;

namespace _20221018_Colleciones
{



  
    internal class Alumno
    { public string Nombre { get; set; }
    public string Dni { get; set; }

        public override string ToString()
        {
            return "nombre:" + Nombre + " dni:" + Dni;
        }

        public void ReunirseProfessor()
        {
            Console.WriteLine("El alumno " + Nombre + "se està reunindo con el profesor");



        }
        public void Salir()
        {

            Console.WriteLine("El alumno " + Nombre + "está saliendo");
        }
    }
}
