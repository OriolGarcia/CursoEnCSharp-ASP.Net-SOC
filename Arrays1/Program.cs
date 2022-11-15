using System;
using System.Collections.Generic;

namespace Arrays1
{
    internal class Program
    {

        static decimal[] gananciasTrimestre= new decimal[4];
        static  List<int> list = new List<int>() { 2, 3, 5 };
        static void Main(string[] args)
        {
            Console.WriteLine("Que año?");
            int año;
            if (int.TryParse(Console.ReadLine(), out año))
            {
                Console.WriteLine("ganancias 1er trimestre del "+año);
                if (decimal.TryParse(Console.ReadLine(), out gananciasTrimestre[0]))
                {
                    Console.WriteLine("gananciase 2o trimestre " + año);
                    if (decimal.TryParse(Console.ReadLine(), out gananciasTrimestre[1]))
                    {
                        Console.WriteLine("ganancias 3er trimestre " + año);
                        if (decimal.TryParse(Console.ReadLine(), out gananciasTrimestre[2]))
                        {
                            Console.WriteLine("ganancias 4o trimestre " + año);
                            if (decimal.TryParse(Console.ReadLine(), out gananciasTrimestre[3]))
                            {
                                Calculos();
                            }
                            else { Console.WriteLine("número mal puesto"); }
                        }
                        else { Console.WriteLine("número mal puesto"); }
                    }
                    else { Console.WriteLine("número mal puesto"); }

                }
                else { Console.WriteLine("número mal puesto"); }
            }

            else { Console.WriteLine("número mal puesto"); }
            list.Add(44);
            list.Insert(3,9);
            Console.WriteLine(list[list.Count-1]);
        }

        private static void Calculos()
        {


            decimal sum = gananciasTrimestre[0] + gananciasTrimestre[1] + gananciasTrimestre[2] + gananciasTrimestre[3];
            Console.WriteLine("Sumatorio=" + sum);

            Console.WriteLine("Promedio=" + sum/gananciasTrimestre.Length);
            if (gananciasTrimestre[0]<50000|| gananciasTrimestre[1] < 50000|| gananciasTrimestre[2] < 50000|| gananciasTrimestre[3] < 50000)
            {


                Console.WriteLine("hay trimestres en que no se ha llegado al objetivo");
            }
            else
            {
                Console.WriteLine("Se ha llegado siempre al objetivo");
            }



        }
    }
}
