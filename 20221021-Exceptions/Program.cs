using System;
using System.Runtime.ConstrainedExecution;

namespace _20221021_Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Calcular();
            }
            catch (InvalidOperationException i) // con variable
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ha efectuado una operación prohibida       (división entre cero)");
            }
            catch (NullReferenceException) // sin variable
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Se ha encontrado un bug en el código");
                Console.ForegroundColor = color;
            }
            catch (MyException e)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = color;
                e.Resolver();
            }

            catch (Exception e)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = color;
            }
            finally
            {
                Console.WriteLine("Tareas fin");

            }
            Console.WriteLine("Fin del programa");

            
            Main(null);
        }
        public static void Calcular()
        {
            Console.WriteLine("Ha empezado la división");
            RecuperarEntrada();
        }
        public static void RecuperarEntrada()
        {
            Console.WriteLine("Introducir el primer número"); decimal
            one = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Introducir el segundo número"); decimal
            two = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Resultado = " + Dividir(one, two));
        }
        public static decimal Dividir(decimal a, decimal b)
        {
            if (b == 0)
            {
                try
                {
                    throw new MyException("No es posible   dividir entre 0", a);
                } catch (MyException e){ return e.Resolver(); }
            }
            return a / b;
        }
    }
}
