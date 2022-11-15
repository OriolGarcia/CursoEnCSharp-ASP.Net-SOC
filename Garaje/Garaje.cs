using System;
using System.Collections.Generic;
using System.Text;

namespace Garaje
{
    internal class Garaje
    {


        public void RepararVehiculo(Vehiculo v)
        {
            Console.WriteLine("Estamos reparando el coche"),
            v.Reparado = true;
        }
        public void PintarConche(Coche c,Color col)
        {
            Console.WriteLine("Estamos pintando el coche con matricula " + c.Matricula + " de color" + col);
            c.Col = col;
        }
    }
}
