using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Actividad1_OGS
{
    [Serializable]
    public class Persona
    {


        private string nom;
        private string cognoms;
        private string dni;
        public string Nom { get { return nom; } set { nom = value; } }
        public string Cognoms { get { return cognoms; } set { cognoms = value; } }
        public string Dni { get { return dni; } set { dni = value; } }
        public Persona() { }
        public Persona(string nom, string cognoms, string dni)
        {
            
            Nom = nom;
            Cognoms = cognoms;
            Dni = dni;
        }

        public override string ToString()
        {
            return @"Propietari{" +
                "\r\n                  Nom:" + Nom +
                "\r\n                  Congnoms:" + cognoms+
                "\r\n                  DNI:" + Dni+
                "\r\n}";
        }
    }
}
