
using System;
using System.Collections.Generic;

namespace _20221018_Colleciones
{
    internal class Program
    {
        static void Main(string[] args)
        {

       

            Alumno[] curso = new Alumno[15];

            Alumno a1 = new Alumno
            {
                Nombre = "Oriol",
                Dni = "319498989F"

            };
            Alumno a2 = new Alumno
            {
                Nombre = "Carlos",
               Dni = "99889999D"

            };

            Alumno a3 = new Alumno
            {
                Nombre = "Miguel",
                Dni = "112298989F"

            };

            curso[0] = a1;
            curso[1] = a2;
            curso[2] = a3;
            Console.WriteLine(curso[0].ToString());
            Console.WriteLine(curso[1].ToString());
            Console.WriteLine(curso[2].ToString());
            List<Alumno> list = new List<Alumno>();

            list.Add(a1);
            list.Add(a2);
            list.Add(a3);
            a3.Nombre = "Roberto";
            foreach(Alumno alumno in list)
            {
                Console.WriteLine(alumno.ToString());

            }
            Dictionary<string, Alumno> dic = new Dictionary<string, Alumno>();

            dic.Add(a1.Dni, a1);
            dic.Add(a2.Dni, a2);
            dic.Add(a3.Dni, a3);

            a1.Dni = "22222";
            if (dic.ContainsKey("319498989F"))
            {
                Console.WriteLine(dic["319498989F"].ToString());

            }

            Queue<Alumno> cola = new Queue<Alumno>();
            cola.Enqueue(a1);
            cola.Enqueue(a2);
            cola.Enqueue(a3);
            cola.Dequeue().ReunirseProfessor();
            cola.Dequeue().ReunirseProfessor();
            cola.Dequeue().ReunirseProfessor();
        }
    }
}
