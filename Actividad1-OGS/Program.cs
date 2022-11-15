using System;
using System.IO;
using System.Xml.Serialization;

namespace Actividad1_OGS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string marca, model, matricula, nom, cognoms, dni;
                int any = 0;
            Console.WriteLine("**Gestor de automobils**");
            Console.WriteLine("Nou automovil:\n");
            Console.Write("Marca:");
             marca= Console.ReadLine();
            Console.Write("Model:");
            model = Console.ReadLine();
            Console.Write("Matricula:");
            matricula=Console.ReadLine();
            
            do
            {
                Console.Write("Any de compra:");
            } while (!int.TryParse(Console.ReadLine(), out any));
            Console.WriteLine("Propietari:");
            Console.Write("            Nom:");
                        nom = Console.ReadLine();
            Console.Write("            Cognoms:");
            cognoms = Console.ReadLine();
            Console.Write("            DNI:");
            dni = Console.ReadLine();
            Persona propietari = new Persona(nom,cognoms,dni);
            Automovil automovil = new Automovil(marca, matricula, model, any, propietari);
            Console.WriteLine("s'han creat els objectes amb èxit");
            Console.WriteLine(automovil.ToString());

            Serialitzar(automovil);

        }
        private static void Serialitzar(Automovil auto)
        {
            //Crear el serializador (de una clase X)
            var serializer = new XmlSerializer(typeof(Automovil));

            //Preparar el stream (flujo de datos) donde se gaurdará la serialización
            var stream = new FileStream("automovil.xml", FileMode.Create);

            //Serializar el objeto en el stream
            serializer.Serialize(stream,auto);
            stream.Close();
            stream.Dispose();

         

        }
    }
}
