using System;

namespace _20221010_AnimalesInterfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SerHumano sh1 = new SerHumano();
            sh1.Respirar();
            sh1.Reproducirse();
            Leon l1 = new Leon();
            
            sh1.ComeCarne(l1);


        }
    }
}
