using System;
using System.Collections.Generic;
using System.Text;

namespace Garaje
{



    internal class Vehiculo
    {
        protected string matricula;
        protected bool reparado;
        public string Matricula { get { return matricula; } set { matricula = value; } }
        public bool Reparado { get { return reparado; } set { reparado = value; } } 
    }
}
