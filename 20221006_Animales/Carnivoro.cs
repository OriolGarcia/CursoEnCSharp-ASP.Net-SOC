using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace _20221006_Animales
{
    internal class Carnivoro : Animal
    {
        bool canival =false;

        public bool Canival { get { return canival; } private set{ canival = value;  } } 


        public void Cazar()
        {
            Console.WriteLine("El carnivoro está cazando.");
            canival = true;
        }
    public override string ToString(){
           return  base.ToString()+ "\r\nCanibal:" + canival;
       
    }


}
}
