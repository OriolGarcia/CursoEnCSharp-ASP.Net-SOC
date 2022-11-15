using _20221108_EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Xml.Schema;

namespace _20221108_EntityFrameworkCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PanelControl();
        }

        public static void PanelControl()
        {  //TO_DO
            while (true)
            {
                Console.WriteLine("Seleccione una opción.");
                Console.WriteLine("[C]Create [R]Select [U]Update [D]Delete [S]Salir:");
                string opcion = Console.ReadLine().ToUpper();

                if (opcion == "S")
                {
                    Console.WriteLine("¿Está seguro de querer salir [S/N]?");
                    string resp = Console.ReadLine().ToUpper();
                    if (resp == "S") break;
                }

                switch (opcion)
                {
                    case "C": Create(); break;
                    case "R": Select(); break;
                    case "U": Update(); break;
                    case "D": Delete(); break;
                }
            }
        }
        private static void Create()
        {
            Products p = new Products
            {
                ProductName = "Cocacola 2L zero zero2",
                CategoryId = 1,
                SupplierId = 1,
                UnitPrice = 12.25M,
                UnitsInStock = 100,
                Discontinued = false

            };
            
            NeptunoContext dbContext = new NeptunoContext();
            dbContext.Products.Add(p);
            dbContext.SaveChanges(); 
        }
        private static void Select()
        {
            //Añadir un cliente a la BD
            NeptunoContext dbContext = new NeptunoContext();
            var products = dbContext.Products.Include(c=>c.Category).Include(s=>s.Supplier).Where(p=>p.Category.CategoryName=="Beverages").OrderBy(p=>p.UnitPrice);
            Products.PrintHeader();
            foreach (var item in products)
            {
                Console.WriteLine(item.ProductName + "\t\t" + item.UnitPrice + "\t\t" + item.UnitsInStock + "\t\t" + item.Category.CategoryName + "\t\t" + item.Supplier.CompanyName + "\t\t");
            }

        }
        private static void Update()
        {
            //Actualizar un cliente en la BD
            
        }
        private static void Delete()
        {
            
        }
    }
}
