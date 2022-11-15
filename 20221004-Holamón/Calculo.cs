using System;
using System.Collections.Generic;
using System.Text;

namespace _20221004_Holamón
{
    
    class Calculo
    {
        public void Circuloproc()
        {
            Console.Write("Radio:");
            string radioStr = Console.ReadLine();
        float radio;
            if(float.TryParse(radioStr, out radio))
            {

                Console.WriteLine("    AREA:" +  Math.PI* radio * radio);

                Console.WriteLine("    PERIMETRO:" +  Math.PI* radio *2);
             }
}


        public void Calculos()
        {
            Console.Write("Num1:");
            string n1Str = Console.ReadLine();
            float n1, n2;

            Console.Write("Num2:");
            string n2Str = Console.ReadLine();
            if (float.TryParse(n1Str, out n1) && float.TryParse(n2Str, out n2))
            {

                Console.WriteLine("Son iguales:" + (n1 == n2));
                Console.WriteLine("Son multiples:" + ((n2 % n1)==0));
                Console.WriteLine("Division 1:" + (n2 / n1));
                Console.WriteLine("Division 2:" + (n1 / n2));
                Console.WriteLine("Resto 1:" + (n1 % n2));
                Console.WriteLine("Resto 2:" + (n2 % n1));
            }
            else
            {
                Console.WriteLine("datos incorrectos");
            }
        }
        public void MuliplesdePi(int n)
        {
            //https://elpais.com/elpais/2015/03/14/actualidad/1426360262_743353.html#?rel=mas

            double res =  Math.PI* n+ 0.00000000000000000001;
            bool entero=true;
            char[] test = res.ToString().ToCharArray();



            double res2 = Math.PI * n - 0.00000000000000000001;
            bool entero2 = true;
            char[] test2 = res.ToString().ToCharArray();

            for (int i = 0; i < test.Length; i++)
            {
                if (test[i] == '.')
                {
                    entero = false;
                }
            }
            for (int i = 0; i < test2.Length; i++)
            {
                if (test2[i] == '.')
                {
                    entero2 = false;
                }
            }
           
                if (entero||entero2)
                {
                   
                    Console.WriteLine(res+" es un numero entero."+"n="+n);
                    Console.Write("o bien "+res2 + " es un numero entero." + "n=" + n);
                }
                else
                {
                    
                    Console.WriteLine(res +" es un numero decimal.");
                    MuliplesdePi(n + 1);
                }
            }
        }
    }

