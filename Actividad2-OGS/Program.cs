using System;
using System.IO;

namespace Actividad2_OGS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string frase;

            Console.WriteLine("Escriu ua frase");
           frase=  Console.ReadLine();
            string majuscules = frase.ToUpper();
            Console.WriteLine(majuscules);
            string[] paraules = frase.Split(" ");
            Console.WriteLine("nombre de paraules:"+paraules.Length);
            var random = new Random();
            int r = random.Next(1,paraules.Length);
            string[] result = new string[r];
            Array.Copy(paraules, result, r);
            string fraseGenerada="";
            for (int i = 0; i < r; i++)
            {
               fraseGenerada=fraseGenerada+result[i]+"...";
                

            }
            fraseGenerada=fraseGenerada.Trim().Substring(0,fraseGenerada.Length-3);
            Console.WriteLine(fraseGenerada);


            StreamWriter writer = File.CreateText("output.txt");
            writer.WriteLine("frase=" +frase);
            writer.WriteLine("mayus=" + majuscules);
            writer.WriteLine("Total paraules=" + paraules.Length);
            writer.WriteLine("frase generada:" + fraseGenerada);
            writer.Flush();

            writer.Close();
            writer.Dispose();
        }
    }
}
