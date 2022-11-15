using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace _20221022_Peliculas
{
    internal class Program
    {
        static List<Pelicula> list = new List<Pelicula>();
        static void Main(string[] args)
        {
            
            list.Add(new Pelicula("titanic", new List<string> { "Romantica", "oceano" }, new List<Actor> { new Actor("Dicaprio", "EUA"), new Actor("Rouse", "EUA") }, 2015, "EUA"));
            list.Add(new Pelicula("Spiderman", new List<string> { "Acción", "super heroes" }, new List<Actor> { new Actor("Martin", "EUA"), new Actor("Charles", "EUA") }, 2015, "EUA"));
            list.Add(new Pelicula("Batman", new List<string> { "Acción", "super heroes" }, new List<Actor> { new Actor("Mark", "EUA"), new Actor("Mark", "EUA") }, 2015, "EUA"));
            list.Add(new Pelicula("The ring", new List<string> { "Miedo", "Dark" }, new List<Actor> { new Actor("Tom Hans", "EUA"), new Actor("Bill", "EUA") }, 2015, "EUA"));
            list.Add(new Pelicula("Hallowing", new List<string> { "Miedo", "Dark" }, new List<Actor> { new Actor("Dicaprio", "EUA"), new Actor("Rouse", "EUA") }, 2015, "EUA"));
            while (true)
            {

                Console.WriteLine("Escoja [1] busqueda por titulo,[2] busqueda por genero, S para salir");

                string opcion = Console.ReadLine();
                if (opcion == "S") break;
                switch (opcion)
                {

                    case "1":
                        buscarPorTitulo();
                        break;

                    case "2":
                        buscarPorGenero();
                        break;

                }
            }
        
        
        }
        private static  void buscarPorTitulo()
        {
            Console.WriteLine("Buscar");
            string search = Console.ReadLine().ToLower();
            List<Pelicula> resultados = new List<Pelicula>();
            var peliculasSeleccionadas = list.FindAll(p => p.Titulo.ToLower().Contains( search));
            /*foreach (Pelicula p in list)
            {



                if (p.Titulo.ToLower().Contains(search))
                {
                    if (!resultados.Contains(p))
                        resultados.Add(p);
                }
                foreach (string genero in p.Generos)
                {

                    if (genero.ToLower().Contains(search))
                    {
                        if (!resultados.Contains(p))
                            resultados.Add(p);
                    }

                }
                foreach (Actor actor in p.Actores)
                {

                    if (actor.Nombre.ToLower().Contains(search))
                    {
                        if (!resultados.Contains(p))
                            resultados.Add(p);
                    }

                }
            }*/
            Console.WriteLine("Resultado de la búsqueda:\r\n");
            foreach (Pelicula p in peliculasSeleccionadas)
            {

                Console.WriteLine(p.ToString());



            }


        }
        private static void buscarPorGenero()
        {
            Console.WriteLine("Buscar");
            string search = Console.ReadLine().ToLower();
            List<Pelicula> resultados = new List<Pelicula>();

            foreach (Pelicula p in list)
            {



                foreach (string genero in p.Generos)
                {

                    if (genero.ToLower().Contains(search))
                    {
                        if (!resultados.Contains(p))
                            resultados.Add(p);
                    }

                }
                foreach (Actor actor in p.Actores)
                {

                    if (actor.Nombre.ToLower().Contains(search))
                    {
                        if (!resultados.Contains(p))
                            resultados.Add(p);
                    }

                }
            }
            Console.WriteLine("Resultado de la búsqueda:\r\n");
            foreach (Pelicula p in resultados)
            {

                Console.WriteLine(p.ToString());



            }


        }

    }
}
