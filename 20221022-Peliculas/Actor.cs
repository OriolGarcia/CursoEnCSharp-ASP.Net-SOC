using System;
using System.Collections.Generic;
using System.Text;

namespace _20221022_Peliculas
{
    internal class Actor
    {

       private  string nombre;
      private  string nacionalidad;
            public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Nacionalidad { get { return nacionalidad; } set { nacionalidad = value; } }
     public   Actor(string nombre,string nacionalidad)
        {
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;   
        }

        public override string ToString()
        {
            return "ACTOR [ nombre:"+nombre+", nacionalidad:"+Nacionalidad+"],";
        }
    }
}
