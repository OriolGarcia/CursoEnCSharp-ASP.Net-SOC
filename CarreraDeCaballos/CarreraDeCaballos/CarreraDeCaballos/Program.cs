using System;
using System.Collections.Generic;

namespace CarreraDeCaballos
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int numCaballos = 0;
                do
                {
                    Console.WriteLine("Cuantos caballos?");
                } while (!int.TryParse(Console.ReadLine(), out numCaballos));
                int meta = 0;
                do
                {
                    Console.WriteLine("Cual es la meta?");
                } while (!int.TryParse(Console.ReadLine(), out meta));
                List<Caballo> caballos = new List<Caballo>();
                for (int i = 0; i < numCaballos; i++)
                {
                    Caballo c = new Caballo(meta);
                    caballos.Add(c);
                }
                int r = 0;
                var random = new Random();
                do
                {
                    r = random.Next(0, numCaballos);
                    caballos[r].correrPosicion();
                    PintarPantalla(caballos, meta);
                    Console.ReadLine();
                } while (!caballos[r].HaGanado);

                Console.WriteLine(" Ha ganado el caballo:" + r);
                Console.ReadLine();
            }
        }
        public static void PintarPantalla(List<Caballo> listaCaballos,int meta)
        {

            Console.Clear();
            string output="";
            for(int i=0; i<listaCaballos.Count; i++)
            {

                output += "Caballo " + i ;
                int ilong=  i.ToString().Length;
                Caballo c = listaCaballos[i];
                int posicion = c.Posicion;
                int plong = posicion.ToString().Length;

                for(int j=0; j < (4 - ilong); j++)
                {

                    output += " ";
                }
                output += ":  " + posicion + " metros";
                for (int j=0; j < (5 - plong); j++)
                {

                    output += " ";
                }
                output+="|";
                int x = 0;
                for(x =0; x < posicion - 1; x++)
                {
                    output += " ";
                }
                output += "*";
                for (; x < meta; x++)
                {
                    output += " ";
                }
                output += "||META||\r\n";
            }

            Console.Clear();
            Console.Write(output);
        }
    }
}
