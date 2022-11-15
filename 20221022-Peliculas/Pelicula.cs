using System;
using System.Collections.Generic;
using System.Text;

namespace _20221022_Peliculas
{
    internal class Pelicula
    {
        string titulo;
        List<string> generos;
        private List<Actor> actores=new List<Actor>();
        private int ano;
        private string pais;
        public string Titulo { get { return titulo; } set { titulo = value; } }
        public List<string> Generos { get { return generos; } set { generos = value; } }
       public List<Actor> Actores { get { return actores; } set { actores = value; } }
        public int Ano { get { return ano; } set { ano = value; } }
        public Pelicula(string Titulo, List<string> generos, List<Actor> actores, int ano,string pais)
        {
            this.Titulo = Titulo;
            this.Generos = generos;
            this.actores = actores;
            this.ano = ano;
            this.pais = pais;
        }

        private string GetReparto()
        {


            string str = ""; ;
            str= str + " Actores {\r\n";
            foreach (Actor actor in actores)
            {
                str = str + actor.ToString();

            }
           str= str.Substring(0,str.Length-1);
            str = str + "\r\n}";
            return str;
        }

        private string GetGeneros()
        {


            string str = ""; ;
            str = str + " Generos{\r\n";
            foreach (string genero in generos)
            {
                str = str + " "+genero+",";

            }
            str = str.Substring(0, str.Length - 1);
            str = str + "\r\n}";
            return str;
        }

        public override string ToString()
        {
            string str = "Titulo: " + Titulo + "\r\n" +
                         "Genero: " + GetGeneros() + "\r\n" +
                         "Año: " + Ano + "\r\n" +
                         "Pais: " + pais + "\r\n";

            str = str + GetReparto();

  

            return str;



                }
    }
}
