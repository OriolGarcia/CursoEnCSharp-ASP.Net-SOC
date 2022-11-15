using System;
using System.Runtime.InteropServices;

namespace _20221018_Bucles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var chars = "01";
            Console.WriteLine("Cómo de larga quieres la ralla?");
            int.TryParse(Console.ReadLine(), out int num);
            var random = new Random();
            for (int i = 0; i < num; i++) {
                Console.Write(chars[random.Next(chars.Length )].ToString());
                    }


            Console.WriteLine("\nCuadrado?");
           // int.TryParse(Console.ReadLine(), out int num);
          
            for (int i = 0; i < num; i++)
            {
                for (int r = 0; r < num; r++)
                {   if(i == 0||r==0|| i == num-1 || r == num-1)
                        Console.Write(chars[random.Next(chars.Length)].ToString());
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine("");
            }

            Console.WriteLine("Triangulo?");
            //int.TryParse(Console.ReadLine(), out int num);
            int j = 1;
            for (int i = 0; i < num; i++)
            {
                for (int r = 0; r <j; r++)
                {
                    Console.Write(chars[random.Next(chars.Length)].ToString());

                }
                j++;
                Console.WriteLine("");
            }


            Console.WriteLine("TrianguloEquilatero?");
            //int.TryParse(Console.ReadLine(), out i num);
            j = 1;
            for (int i = 0; i < num; i++)
            {

                for (int r = 0; r < (num*2-j)/2; r++)
                {
                    Console.Write(" ");

                }



                for (int r = 0; r < j; r++)
                {
                    Console.Write(chars[random.Next(chars.Length)].ToString());

                }
                j+=2;
                Console.WriteLine("");
            }
            Console.WriteLine("Texto:");
            string s = Console.ReadLine();

            for(int i=0; i < s.Length; i++)
            {

                if (s[i] == 'a') break;
                Console.Write(s[i]);
            }
        

        Console.WriteLine("Texto:");
            string s2 = Console.ReadLine();

            for (int i = 0; i < s2.Length; i++)
            {

                
                Console.Write((char)(((int)s2[i]+10)*2));
            }



        }

    }
}
