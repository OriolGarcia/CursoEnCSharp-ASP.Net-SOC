using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace _20221021_IO
{
    internal class Program
    {
        static int Type=3;

        static void Main(string[] args)
        {
           

            try
            {
                while (true)
                {
                    if (File.Exists("config.dat"))
                    {

                        StreamReader sr = File.OpenText("config.dat");
                        string s1 = sr.ReadLine();
                        string s2 = sr.ReadLine();
                        string s3 = sr.ReadLine();
                        ConfigurarColor(int.Parse(s1[^1].ToString()), int.Parse(s2[^1].ToString()), int.Parse(s3[^1].ToString()));


                        sr.Close();
                        sr.Dispose();
                    }
                    Console.WriteLine(print("back? 1-Blanco 2-negro 3- rojo"));

                    int back, front, type;
                    if (int.TryParse(Console.ReadLine(), out back))
                    {
                        Console.WriteLine(print("front? 1-Blanco 2-negro 3- rojo"));
                        if (int.TryParse(Console.ReadLine(), out front))
                        {
                            Console.WriteLine(print("type? 1-Mayuscula 2-Minuscula 3- Normal"));
                            if (int.TryParse(Console.ReadLine(), out type))
                            {
                                StreamWriter writer = File.CreateText("config.dat");
                                writer.WriteLine("back=" + back);
                                writer.WriteLine("front=" + front);
                                writer.WriteLine("type=" + type);
                                // Cerramos el archivo. Al cerrarlo, se guardará en la carpeta
                                // debug del directorio bin.
                                ConfigurarColor(back, front, type);






                                writer.Flush();

                                writer.Close();
                                writer.Dispose();
                            };

                        }
                    }

                }
            }catch(Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    
        static void ConfigurarColor(int back,int fore,int type) {

            switch (back)
            {


                case 1:
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
                case 2:
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case 3:
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;

            }
            switch (fore)
            {


                case 1:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

            }

            Type = type;
            
        }

        static private string print(string s)
        {

            if (Type == 1)
            {
                return s.ToUpper();
            }
            if (Type == 2)
            {
                return s.ToLower();
            }
            return s;
        }
    }
}
