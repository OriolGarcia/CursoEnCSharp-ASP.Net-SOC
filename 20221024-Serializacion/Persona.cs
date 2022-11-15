using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace _20221024_Serializacion
{
    [Serializable]
    public class Persona
    {
        [XmlElement("Name")]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [XmlAttribute] 
        public int Edad { get; set; }


        public Persona() { Edad = 32; }

        public Persona(string nombre, string apellido, int edad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }
    }
}
