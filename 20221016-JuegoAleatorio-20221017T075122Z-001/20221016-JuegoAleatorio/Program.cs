using System;

namespace _20221016_JuegoAleatorio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Montamos el juego
            var random = new Random();
            Console.WriteLine("Escriba un número natural:");
            int m = int.Parse(Console.ReadLine());
            
            if (m<1)
            {
                Console.WriteLine("No se ha podido jugar");
                return;
            }            

            //Jugamos
            else
            {
                int r = random.Next(0, m + 1);
                Console.WriteLine("Adivine el número aleatorio:");
                if (r!=int.Parse(Console.ReadLine()))   // Si es distinto, falla seguro.
                {
                    Console.WriteLine("Ha fallado. Deje de jugar, las adicciones son peligrosas, busque ayuda.");
                }
                else   // Si són iguales, hacemos random 0, 1 para ver si lo decimos.
                {
                    Console.WriteLine((random.Next(0, 2) == 1) ? "Ha ganado por casualidad, no vuelva a jugar." : 
                        "Ha fallado. Deje de jugar, las adicciones son peligrosas, busque ayuda.");
                }
                Console.WriteLine("El número era " + r);
            }
            
        }
    }
}
