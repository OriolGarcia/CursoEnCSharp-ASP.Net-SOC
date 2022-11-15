using System;
using System.Collections.Generic;
using System.Text;

namespace _20221024_Serializacion
{
    internal class PersonaJSON
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public Direccion Dir { get; set; }

        public override string ToString()
        {
            return "***********************\r\n" +

                Nombre + " " + Apellido + " (" + Edad + ") " + Dir.Calle + " " + Dir.Ciudad + " " + Dir.CodigoPostal + " " + Dir.Pais
            + "*\r\n**********************";


        }
    }
    public class Direccion
    {

        public string Calle { get; set; }
        public string Ciudad { get; set; }  
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }

    }
}
