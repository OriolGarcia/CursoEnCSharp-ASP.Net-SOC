using System;
using System.Collections.Generic;
using System.Text;

namespace Actividad1_OGS
{
    [Serializable]
    public class Automovil
    {
        
        private string marca;
        private string matricula;
        private string model;
        private int anyCompra;
        private Persona propietari;
      
        public string Marca { get { return marca; } set { marca = value; } }
        public string Matricula{ get { return matricula; }set { matricula = value; }     }
        public string Model { get { return model; } set { model = value; } }
        public int AnyCompra { get { return anyCompra; } set { anyCompra = value; } }
        public Persona Propietari { get { return propietari; } set { propietari = value; } }
        public Automovil() { }
        public Automovil(string marca, string matricula, string model, int anyCompra, Persona propietari)
        {

  
            Marca = marca;
            Matricula = matricula;
            Model = model;
            AnyCompra = anyCompra;
            Propietari = propietari;
            
        }

        public override string ToString()
        {
            return @"Automobil{" +
                    "\r\n      Marca:" + marca +
                    "\r\n      Matricula:" + matricula +
                    "\r\n      Model:" + Model +
                    "\r\n      AnyCompra:" + AnyCompra +
                    "\r\n      Propietari:" + propietari.ToString() +
                    "\r\n }";
        }
    }
}
