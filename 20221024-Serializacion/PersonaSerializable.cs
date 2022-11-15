using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace _20221024_Serializacion
{
    [Serializable]
    public class PersonaSerializable : IXmlSerializable
    {
        [XmlElement("Name")]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [XmlAttribute] 
        public int Edad { get; set; }
        public List<string> Titulos { get; set; }

        public PersonaSerializable() { Edad = 32; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            Edad = int.Parse(reader.GetAttribute("Age"));
            reader.ReadToDescendant("Name");
            Nombre = reader.ReadElementContentAsString("Name","");
            reader.ReadToNextSibling("Surname");
            Apellido = reader.ReadElementContentAsString("Surname", "");
            reader.ReadToNextSibling("Titles");
            reader.ReadToDescendant("Title");
            Titulos = new List<string>();
            while (true)
            {
                try
                {
                    string title = reader.ReadElementContentAsString("Title", "");
                    Titulos.Add(title);
                    reader.ReadToNextSibling("Title");
                }
                catch { break; }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("Person");

           writer.WriteAttributeString("Age",Edad.ToString());
            writer.WriteElementString("Name",Nombre);
            writer.WriteElementString("Surname", Apellido);
            writer.WriteStartElement("Titles");
            foreach(var item in Titulos)
            {
                writer.WriteElementString("Title", item);

            }
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

       
    }
}
