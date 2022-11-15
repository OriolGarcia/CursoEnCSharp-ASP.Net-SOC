using System;
using System.Collections.Generic;
using System.Text;

namespace _20221007_Cuenta
{
    internal class Persona
    {
        private Cuenta cuentaPersona;
        private string nombre;
        private string dni;
        private string telefono;
        private DateTime fecha_nacimiento;

       public  Cuenta CuentaPersona
        {

            get { return cuentaPersona; }
            set { cuentaPersona = value; }

        }
        public string Nombre
        {
            get { return nombre; }  
            set { nombre = value.Length>=3 ? value:""; }
        }
        public string Dni
        {
            get { return dni; } set {


                if (value.Length == 8)
                {
                    dni = value;
                }
                
                 }
        }
        public string Telefono
        {
            get { return telefono; } set { telefono = value; }  
        }

        public DateTime Fecha_Nacimiento
        {
            get { return fecha_nacimiento; }
            set { if ((DateTime.Now.Year - value.Year<110)&& (DateTime.Now.Year - value.Year>0)) { fecha_nacimiento = value; } }   
        }

        public Persona()
        {


        }
        public Persona(string nombre,DateTime fecha_Nacimiento)
        {
           Nombre = nombre; ;
            Fecha_Nacimiento=fecha_Nacimiento;
        }
        
        public Persona(string nombre, string dni, string telefono, DateTime fecha_Nacimiento)
        {
            Fecha_Nacimiento = fecha_Nacimiento;
            
            
            Nombre = nombre;
            Dni = dni;
            Telefono = telefono;
            
        }
        public override  string ToString()
        {

           return "**Información-persona**\n\rNombre:" + nombre+"\r\nEdad:" + (int)((DateTime.Now - fecha_nacimiento).TotalDays / 365.25)+"\r\nDNI:" + dni+"\r\nTelefono:" + telefono;
        }

    }
}
