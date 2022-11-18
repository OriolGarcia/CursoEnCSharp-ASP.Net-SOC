using Actividad2_OGS_MODULO2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace Actividad2_OGS_MODULO2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Actividad2();
        }

        public static void Actividad2()
        {

            while (true)
            {
                //Presentar opciones del buscador
                Console.Clear();
                Console.WriteLine("Seleccione una opción: [B]Buscador [S]Salir");
                string opcion = Console.ReadLine().ToUpper();
                if (opcion == "S") break;

                //Introducción de datos (2 fechas)
                Console.Write("ciudad: ");
                string ciudad = Console.ReadLine();
                Console.Write("Nombre Compañia: ");
                string companyName = Console.ReadLine();
                Console.Write("Contacto: ");
                string contacto= Console.ReadLine();
                //Preparación de la consulta
                var dbContext = new NeptunoContext();
                var proveedores = dbContext.Suppliers
                    .Where(s => s.City.Contains(ciudad)&&
                               s.CompanyName.Contains(companyName) && s.ContactName.Contains(contacto))
                    
                   
                    .Select(s => new
                    {
                        CompanyName = s.CompanyName,

                        ContactName = s.ContactName,
                        City=s.City,
                        Address=s.Address,
                       
                    });

                
                int elementosPP = 10;
                int actual = 0;
                int totalRegistros = proveedores.Count();

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Count\t\tCompanyName\t\tContacto\t\tCity\t\tAddress");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------");

                    //Seleccionar los elementos que hay que mostrar
                    var proveedoresAMostrar = proveedores.Skip(actual).Take(elementosPP);

                    int counter = actual;
                    foreach (var p in proveedoresAMostrar)
                    {
                        counter++;
                        Console.WriteLine(counter + "\t\t" + p.CompanyName + "\t\t" +
                           p.ContactName + "\t\t" +
                            p.City + "\t\t" +
                            p.Address + "\t\t");
                    }
                    for (int i = 0; i < elementosPP - counter + actual; i++)
                    {
                        Console.WriteLine();
                    }
                    //Opciones del paginador
                    if (actual != 0)
                    {
                        //Pintar 1 y 2
                        Console.Write("[I]<< [R]<");
                    }

                    
                    int limite = (totalRegistros % elementosPP == 0) ?
                        totalRegistros / elementosPP :
                        totalRegistros / elementosPP + 1;
                    int inicio = 0;
                    int final = 0;
                    if (totalRegistros / elementosPP <= 10)
                    {
                        //Menos o igual a 10 páginas
                        inicio = 1;
                        final = (totalRegistros % elementosPP == 0) ?
                        totalRegistros / elementosPP :
                        totalRegistros / elementosPP + 1;
                    }
                    else
                    {
                        //Más de 10 páginas
                        //Colocaremos 5 delante y 4 detrás
                        int pagina = actual / elementosPP + 1;

                        if (pagina - 5 <= 0)
                        {
                            //Empezar a colocar por delante
                            inicio = 1;

                            //Colocar por detrás
                            int porDetras = 4 + (5 - pagina + 1);
                            final = pagina + porDetras;
                        }
                        else if (pagina + 4 > limite)
                        {
                            //Empezar a colocar por detrás
                            final = limite;

                            //Colocar por delante
                            int porDelante = 5 + (4 - (limite - pagina));
                            inicio = pagina - porDelante;
                        }
                        else
                        {
                            inicio = pagina - 5;
                            final = pagina + 4;
                        }
                    }

                    for (int i = inicio; i <= final; i++)
                    {
                        if (i == actual / elementosPP + 1)
                        {
                            Console.Write(" [" + i + "]");
                        }
                        else
                        {
                            Console.Write(" " + i);
                        }
                    }





                    if (actual + elementosPP < totalRegistros)
                    {
                        //Pintar 4 y 5
                        Console.Write(" [A]> [F]>>");
                    }

                    string opcionPaginacion = Console.ReadLine().ToUpper();  //Parada pendiente una opción
                    switch (opcionPaginacion)
                    {
                        case "I":
                            actual = 0;
                            break;

                        case "R":
                            actual = actual - elementosPP;
                            if (actual < 0) actual = 0;
                            break;

                        case "A":
                            actual = actual + elementosPP;
                            if (actual > (limite - 1) * elementosPP) actual = (limite - 1) * elementosPP;
                            break;

                        case "F":
                            actual = (limite - 1) * elementosPP;
                            break;

                        default:
                            //Evaluaremos numeros de paginación
                            try
                            {
                                int numero = int.Parse(opcionPaginacion);
                                if (numero >= 1 && numero <= limite)
                                {
                                    actual = (numero - 1) * elementosPP;
                                }
                            }
                            catch { }
                            break;
                    }

                    //Salida
                    if (opcionPaginacion == "S") break;
                }

            }
        }
    }
}
