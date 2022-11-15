using System;
using System.IO;
using System.IO.Enumeration;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using File = System.IO.File;

namespace _20221024_ActividadArchivos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                bool sal = false;
                switch (GetOpcion())
                {

                    case "1": CrearArchivo();break;
                    case "2": AnadirTextoArchivo(); break;
                    case "3": MostrarArchivo();  break;
                    case "4": BorrarArchivo(); break;
                    case "5": ModerarArchivo(); break;
                    case "S":   sal=  Salir() ;break;

                }

                if (sal) break;
            }
        }
        private static bool Salir() { Console.WriteLine("estas seguro que quieres Salir? (S/N)");
            return (Console.ReadLine().ToUpper() == "S");
        }
        private static string GetOpcion() {
            string str = "";
            while (str != "1" && str != "2" && str != "3" && str != "4" && str != "5" && str != "S")
            {
                Console.WriteLine("[1]Crear archivo de texto");
                Console.WriteLine("[2]Añadir texto a un archivo");
                Console.WriteLine("[3]Mostrar un archivo de texto");
                Console.WriteLine("[4]Borrar un archivo de texto");
                Console.WriteLine("[5]Moderar archivo");
                Console.WriteLine("[S]Salir");
                str = Console.ReadLine().ToUpper();
            }

           
            return str;
        }
        static void listarArchivos()
        {
            try
            {
                string[] files = Directory.GetFiles(".");
                foreach (string file in files)
                    Console.WriteLine(file);

            }
            catch (Exception ex)
            {

            }
        }

        private static void CrearArchivo()
        {
            listarArchivos();
            Console.WriteLine("Nombre archivo:");
            string file = Console.ReadLine();
            if (File.Exists(file)) { Console.WriteLine("Ya existe el archivo"); return; }
            StreamWriter writer=null;


            try
            {
           writer = File.CreateText(file);
                string input = Console.ReadLine();
                while (input != "")
                {
                    writer.WriteLine(input);
                    input = Console.ReadLine();
                }

            }catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                if (writer != null)
                {
                    writer.Flush();

                    writer.Close();
                    writer.Dispose();

                }
            }

        }
        private static void AnadirTextoArchivo()
        {
            listarArchivos();
            Console.WriteLine("Nombre archivo:");
            string file = Console.ReadLine();
            
                StreamWriter w = File.AppendText(file);
                           string input = Console.ReadLine();
                        while (input != "")
                        {
                            w.WriteLine(input);
                                input = Console.ReadLine();
                            }

                    w.Flush();

                    w.Close();
                    w.Dispose();
        }
        private static void MostrarArchivo()
        {
            listarArchivos();
            Console.WriteLine("Nombre archivo:");
            string file = Console.ReadLine();
            if (File.Exists(file))
            {

                StreamReader sr = File.OpenText(file);
                Console.WriteLine(sr.ReadToEnd());
                sr.Close();
                sr.Dispose();
            }
        }
        private static void ModerarArchivo()
        {
            string[] palabrasProhibidas = { "estupid", "puta", "gilipollas" };
            Console.WriteLine("Nombre archivo:");
            string file = Console.ReadLine();
            if (File.Exists(file))
            {

                StreamReader sr = File.OpenText(file);
                string fullText=sr.ReadToEnd();
                bool prohibido = false;
                foreach(string palabra in palabrasProhibidas)
                {
                    if (fullText.Contains(palabra))
                    {
                        Console.WriteLine("palabra prohibida en el texto:" + palabra);
                        prohibido=true;
                    }

                } sr.Close();
                sr.Dispose();
                if (prohibido) { Console.WriteLine("Archivo con palabras prohibidas!");
                    string extension = Path.GetExtension(file);
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    File.Move(file, fileName+"_KO"+extension);
                }
                else { Console.WriteLine("Archivo correcto"); }
               
            }
        }
        private static void BorrarArchivo()
        {
            listarArchivos();
            string file = Console.ReadLine();
            if (File.Exists(file))
            {
                try
                {
                    File.Delete(file);
                    Console.WriteLine("Se ha borrado el archivo:" + file); ;
                }catch(Exception ex) { Console.WriteLine(ex.Message); }
            }
            else { Console.WriteLine("No existe el archivo"); }
        }


    }
}
