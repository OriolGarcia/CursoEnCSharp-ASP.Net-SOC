using System;
using System.Collections.Generic;
using System.Text;

namespace _20221006_Animales
{
    internal class Animal
    {
        protected int peso = 0;
        protected char sexo = ' ';//F,M,O
        protected string tamano = ""; //kg
        public int Peso
        {
            get { return peso; }
            set { peso = (value > 1000) ? 0 : value; }
        }
        public string Tamaño
        {
            get { return tamano; }
            set
            {
                tamano = (value == "pepito") ? "" : value;
            }
        }
        public char Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public void Dormir() { Console.WriteLine("El animal està durminedo");
        }
        public void Respirar() { Console.WriteLine("El animal està respirando"); }
        public void AjustarTamano(string t)
        {

            Tamaño = t;
        }
        public override string ToString()
        {
            return "***Información***\r\n"+base.ToString()+ "\r\nPeso:" + peso+ "\r\nSexo:" + sexo+ "\r\nTamaño:" + tamano;
        }
    }
}
