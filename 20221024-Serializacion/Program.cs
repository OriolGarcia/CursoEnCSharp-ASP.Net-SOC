using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace _20221024_Serializacion
{
    internal class Program
    {
        static void Main(string[] args)
        {
           SerializacionEstandar();
            //SerailizacionEspecifica();
            //XML
            /// ConsumoXML();
            //JSON();
        }
        private static void SerializacionEstandar() {
            var p = new Persona ("Christophe", "Mommer",32 );

            //Crear el serializador (de una clase X)
            var serializer = new XmlSerializer(typeof(Persona));

            //Preparar el stream (flujo de datos) donde se gaurdará la serialización
            var stream = new FileStream("person.xml", FileMode.Create);

            //Serializar el objeto en el stream
            serializer.Serialize(stream, p);
            stream.Close();
            stream.Dispose();

            p = null;
            //....}

            //Recuperar el stream en el que se serializó el objeto
            var stream2 = new FileStream("person.xml", FileMode.Open);

            //Crear el deserializador (de una clase X)
            var serializer2 = new XmlSerializer(typeof(Persona));

            //Deserializar el stream como el tipo de objeto original
            var p2 = (Persona)serializer2.Deserialize(stream2);

            //Usar el objeto deserializado
            System.Console.WriteLine("Hola " + p2.Nombre + " " + p2.Apellido + "  " + p2.Edad);

        }
        private static void SerailizacionEspecifica()
        {
            var p = new PersonaSerializable { Nombre = "Christophe", Apellido = "Mommer", Edad = 32,
                Titulos = new List<string> { "ASIX", "DAM" } };
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = false;
            settings.NewLineOnAttributes = false;
            settings.ConformanceLevel = ConformanceLevel.Auto;

            XmlWriter writer = XmlWriter.Create("serial.xml", settings);
            p.WriteXml(writer);
            writer.Flush();
            writer.Close();
            
            writer.Dispose();

            //Desserializacion
            PersonaSerializable p2 = new PersonaSerializable();
            XmlReader reader =  XmlReader.Create("serial.xml");


            p2.ReadXml( reader);
            Console.WriteLine(p2.Nombre + " " + p2.Apellido + " " + p2.Edad);
           foreach(var item in p2.Titulos)
            {

                Console.WriteLine(item);
            }
            
        }
        private static void ConsumoXML()
        {

                      var xml = @"<?xml version='1.0'?>
                        <PersonaXmlSerializable Edad='33'>
                            <Name>Christophe</Name>
                            <Apellido>Mommer</Apellido>
                            <Titulos>
                                <Titulo>DAM</Titulo>
                                <Titulo>ASIX</Titulo>
                                <Titulo>Ingeneieria Informatica</Titulo>
                            </Titulos>
                        </PersonaXmlSerializable>"; 
            var doc = XDocument.Parse(xml);
            var root = doc.Root;
           
            //XElement elementNombre = root.Element("Name");
            var p = new PersonaSerializable();
            p.Nombre= root.Element("Name").Value;
            p.Apellido = root.Element("Apellido").Value;
            p.Edad =int.Parse( root.Attribute("Edad").Value);
            
            
            p.Titulos= new List<string>();
            
            var titulos = doc.Descendants("Titulos");
            foreach(var titulo in titulos.Elements())
            {
                p.Titulos.Add(titulo.Value);
            }






            Console.WriteLine(p.Nombre + " " + p.Apellido + " " + p.Edad);

            foreach (var item in p.Titulos)
            {

                Console.WriteLine(item+"\r\n");
            }

            var elementoDireccion = new XElement("Direccion",
                        new XAttribute("CodigoPostal", "45600"),
                        new XAttribute("Pais", "España"),
                        "Plaza del Reloj, Talavera de la Reina");

            root.Add(elementoDireccion);
            var xmlFormato = doc.ToString();
            var xmlBruto = doc.ToString(SaveOptions.DisableFormatting);
            Console.WriteLine(xmlFormato);
            Console.WriteLine(xmlBruto);

            var doc2 = XDocument.Load("serial.xml");
            Console.WriteLine(doc2.ToString());
        }
        private static void JSON()
        {

            var json = @"{
                    ""Nombre"" : ""Christophe"",
                    ""Apellido"" : ""Mommer"",
                    ""Edad"" : 33,
                    ""Dirección"" : {
                    ""Calle"": ""Plaza del Reloj"",
                    ""Ciudad"" : ""Talavera de la Reina"",
                    ""CodigoPostal"":""08013"",
                    ""Pais"":""España""
                    }
                    }";
            byte[] bytes = Encoding.UTF8.GetBytes(json);


            var reader = new Utf8JsonReader(bytes);
            PersonaJSON p = new PersonaJSON();
            Direccion dir = new Direccion();
            p.Dir = dir;
            string nombre, apellido;
            while (reader.Read())
            {

                if (reader.TokenType == JsonTokenType.PropertyName && reader.GetString() == "Nombre")
                {
                    reader.Read();
                    p.Nombre = reader.GetString();
                }
                else if (reader.TokenType == JsonTokenType.PropertyName && reader.GetString() == "Apellido")
                {
                    reader.Read();
                    p.Apellido = reader.GetString();
                }
                else if (reader.TokenType == JsonTokenType.PropertyName && reader.GetString() == "Edad")
                {
                    reader.Read();
                    p.Edad = reader.GetInt32();
                }
                else if (reader.TokenType == JsonTokenType.PropertyName && reader.GetString() == "Calle")
                {
                    reader.Read();
                    dir.Calle = reader.GetString();
                }
                else if (reader.TokenType == JsonTokenType.PropertyName && reader.GetString() == "Ciudad")
                {
                    reader.Read();
                    dir.Ciudad = reader.GetString();
                }
                else if (reader.TokenType == JsonTokenType.PropertyName && reader.GetString() == "CodigoPostal")
                {
                    reader.Read();
                    dir.CodigoPostal = reader.GetString();
                }
                else if (reader.TokenType == JsonTokenType.PropertyName && reader.GetString() == "Pais")
                {
                    reader.Read();
                    dir.Pais = reader.GetString();
                }
            }

            Console.WriteLine(p.ToString());

            var opcs = new JsonWriterOptions
            {
                Indented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };
            using (var stream = new FileStream("person.json", FileMode.Create))
            {
                using (var writer = new Utf8JsonWriter(stream, opcs))
                {
                    writer.WriteStartObject(); // {
                    writer.WriteString("Nombre", p.Nombre);
                    // "Nombre" : "Christophe",
                    writer.WriteString("Apellido", p.Apellido); // ""Apellido" : "Mommer"
                    writer.WriteNumber("Edad", p.Edad);
                    writer.WriteStartObject("Dirección"); // "Dirección" : {
                    writer.WriteString("Calle", p.Dir.Calle);
                    // "Calle" : "Plaza del Reloj",
                    writer.WriteString("Ciudad", p.Dir.Ciudad);
                    writer.WriteString("CodigoPostal", p.Dir.CodigoPostal);
                    // "Calle" : "Plaza del Reloj",
                    writer.WriteString("Pais", p.Dir.Pais);
                    
                    // "Ciudad" : "Talavera de la Reina"
                    writer.WriteEndObject(); // fin del objeto dirección
                    writer.WriteEndObject(); // fin del objeto principal
                
           
        }
            }
        }
    }
    }
