using System;
using System.Collections.Generic;
using System.Text;

namespace _20221021_Exceptions
{
    internal class MyException : Exception
    {
        public decimal Dividendo { get; set; }
        const decimal divisorPorDefecto = 1.0M;
        public MyException(string message, decimal dividendo) : base(message)
        {
        Dividendo = dividendo;
            
        
        }
        public decimal Resolver()
        {
            Console.WriteLine("Resolviendo el problema");
            return Dividendo / divisorPorDefecto;
        }
    }
}
