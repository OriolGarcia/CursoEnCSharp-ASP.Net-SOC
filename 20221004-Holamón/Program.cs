using System;

namespace _20221004_Holamón
{
     class Program
    {
        static void Main(string[] args)
        {


            while (true) { 
            Calculo cal= new Calculo();

            Console.WriteLine("1-Helloworld\n 2-circulo \n 3-numeros   \n 4-Encontrar multiples de pi enteros");
            string res = Console.ReadLine();
                if (res == "2") {



                    cal.Circuloproc();
                } else if (res == "3")
                {
                    cal.Calculos();


                }
                else if(res=="4"){
                    cal.MuliplesdePi(113
                        );

                        }
                else
                {

                    string nombre = "Oriol";
                    Console.WriteLine("Hola Món!");
                    Console.Write("hola que tal?");
                    Console.Write($"Me llamo {nombre}\n");
                    Console.WriteLine("FIN");
                    Console.WriteLine("Hola " + 10);
                    Console.WriteLine("Un texto!{0}, {1}", "zero!", "uno");

                    bool correcto = false;

                    bool OREXCLUSIVO = true ^ true;



                    Console.WriteLine("or exclusivo == " + OREXCLUSIVO);

                    var hoy = DateTime.Today;
                    DateTime dia1 = new DateTime(hoy.Year, hoy.Month, 1).AddMonths(1);
                    Console.WriteLine("Primer dia mes sigiuiente:" + dia1 + "último dia:" + dia1.AddDays(-1));
                    
                }
            }
        }
    }
}
