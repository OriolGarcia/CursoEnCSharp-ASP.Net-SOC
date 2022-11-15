using System;
using static _20221006_Animales.León;

namespace _20221006_Animales
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TO_DO
            Animal a1 = new Animal();
            a1.Peso = 800;   //set de la propiedad
            a1.AjustarTamano("grande");
            a1.Sexo = 'F';
            Console.WriteLine(a1.Tamaño);
            Console.WriteLine(a1.ToString());

            Console.WriteLine("------------------");



            Carnivoro c1 = new Carnivoro();
            c1.Peso = 100;
            c1.AjustarTamano("mediano");
            c1.Sexo = 'M';
            c1.Cazar();
            Console.WriteLine(c1.ToString());

            Console.WriteLine("------------------");

            Herbivoro h1 = new Herbivoro();
            h1.Peso = 100;
            h1.AjustarTamano("Mediano");
            h1.Sexo = 'F';
            h1.ComeHierba = true;
            h1.ComiendoHierba();
            Console.WriteLine(h1.ToString());

            Console.WriteLine("------------------");

            Vaca v1 = new Vaca();
            v1.Peso = 120;
            v1.AjustarTamano("Mediano");
            v1.Sexo = 'M';
            v1.ComiendoHierba();
            v1.Lechera = true;
            Console.WriteLine(v1.ToString());
            v1.Ordenyando();

            Console.WriteLine("------------------");

            Leon l1 = new Leon();
            l1.Peso = 80;
            l1.AjustarTamano("Mediano");
            l1.Sexo = 'M';
            l1.Cazar();
            l1.SubEspecie = "Atlas";
            l1.Rugir();
            l1.Color = "Marrón Claro";
            Console.WriteLine(l1.ToString());
            l1.DaALuz();

            Console.WriteLine("------------------");

            SerHumano sh1 = new SerHumano();
            sh1.Peso = 80;
            sh1.AjustarTamano("Mediano");
            sh1.Sexo = 'F';
            sh1.Cazar();
            sh1.Nombre = "Pepita";
            sh1.NumDni = "45343555J";
            Console.WriteLine(sh1.ToString());
        }
    }
}
