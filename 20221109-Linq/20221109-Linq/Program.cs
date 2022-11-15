using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using _20221109_Linq.Dal;

namespace _20221109_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TO_DO

            //Test01();
            //Test02();
            //Test03();
            //Paginador();
            //PaginadorConNumeros();
            //PaginadorMas();
            //ListaPaisesCustomers();
            //ListaPedidos();
            //ListaCustomers();
            // ListaPaisesCS();
            // GroupJoin();
            Zip();
        }

        public static void Test01()
        {
            List<int> lista = new List<int>
            {
                1,2,3,4,5,6,7,8,9
            };

            var enteros1 = lista.Where(i => i < 3);

            foreach (int i in enteros1)
            {
                Console.WriteLine(i);
            }
        }

        public static void Test02()
        {
            NeptunoContext dbContext = new NeptunoContext();

            var products = dbContext.Products.Where(p => p.UnitPrice < 10);

            foreach (var item in products)
            {
                Console.WriteLine(item.ProductName);
            }
        }

        public static void Test03()
        {
            NeptunoContext dbContext = new NeptunoContext();

            var products = dbContext.Products.Where(p => p.UnitPrice < 10)
                .Select(p=>p.ProductName);

            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
        }

        public static void Paginador()
        {
            NeptunoContext dbContext = new NeptunoContext();

            var products = dbContext.Products.OrderBy(p=>p.ProductName);

            int elementosPP = 10;
            int actual = 0;
            int total = products.Count();


            while (true)
            {
                Console.Clear();

                Products.PrintHeader();

                var lista = products.Skip(actual).Take(elementosPP);

                int counter = 0;
                foreach (var item in lista)
                {
                    counter++;
                    Console.WriteLine((actual+counter) + " - " +
                        item.ToString());
                }

                //Mostrar opciones de paginación

                //Evaluar si hay que mostrar el Atras
                if (actual>0)
                {
                    Console.Write("[-]Atras");
                }
                
                //Evaluar si hay que mostrar el Avanzar
                if (actual + elementosPP < total)
                {
                    Console.Write(" [+]Avanzar");
                }

                //Mostrar el salir
                Console.WriteLine(" [S]Salir");

                char opcion = Console.ReadKey().KeyChar;

                if (opcion == 'S')
                {
                    break;
                }
                else if (opcion == '-')
                {
                    if (actual > 0)
                    {
                        actual = actual - elementosPP;
                    }
                }
                else if (opcion == '+')
                {
                    //Actualizar
                    if (actual + elementosPP < total)
                    {
                        actual = actual + elementosPP;
                    }
                }
            }
        }

        public static void ListaPaisesCustomers()
        {
            NeptunoContext dbContext = new NeptunoContext();

            var countries = dbContext.Customers
                .Select(x => x.Country).Distinct();

            foreach (var item in countries)
            {
                Console.WriteLine(item);
            }
        }

        public static void ListaPedidos()
        {
            //OrderId, FechaPedido, Costes logísticos
            NeptunoContext dbContext = new NeptunoContext();

            var pedidos = dbContext.Orders.OrderByDescending(p=>p.Freight)
                .Select(p => new { p.OrderId, p.OrderDate, p.Freight });

            foreach (var item in pedidos)
            {
                Console.WriteLine(item.OrderId + "\t\t" +
                    DateTime.Parse(item.OrderDate.ToString()).ToShortDateString() + 
                    "\t\t" + item.Freight);
            }

        }
    
        public static void ListaCustomers()
        {
            NeptunoContext dbContext = new NeptunoContext();

            //var customersSFI = dbContext.Customers.Where(c => c.Country == "Spain"
            //        || c.Country == "France" || c.Country == "Italy").ToList();

            var customersSpain = dbContext.Customers.Where(c => c.Country == "Spain").ToList();

            var customersFrance = dbContext.Customers.Where(c => c.Country == "France").ToList();

            var customersItaly = dbContext.Customers.Where(c => c.Country == "Italy").ToList();

            var dictCustomers = new Dictionary<string, List<Customers>>();

            dictCustomers.Add("Spain", customersSpain);
            dictCustomers.Add("France", customersFrance);
            dictCustomers.Add("Italy", customersItaly);

            //...
            //...

            var allCustomers = dictCustomers.SelectMany(v => v.Value)
                .OrderBy(c=>c.CompanyName);

            foreach (var customer in allCustomers)
            {
                Console.WriteLine(customer.CompanyName + "\t\t" +
                    customer.Country);
            }




        }
    
        public static void ListaPaisesCS()
        {
            var dbContext = new NeptunoContext();

            var listaPaisesC = dbContext.Customers.Select(c => c.Country).Distinct().ToList();
            var listaPaisesS = dbContext.Suppliers.Select(c => c.Country).Distinct().ToList();
            var listaPaisesE = dbContext.Employees.Select(c => c.Country).Distinct().ToList();

            //Paises comunes entre Customers, Suppliers y Employees
            var aux = listaPaisesC.Join(listaPaisesS, c => c, s => s,
                            (c, s) => c);
            var comunes = aux.Join(listaPaisesE, c => c, e => e,
                            (c, e) => c);

            foreach (var comun in comunes)
            {
                Console.WriteLine(comun);
            }
        }
        public static void GroupJoin()
        {
            var dbContext= new NeptunoContext();
            var listProducts=dbContext.Products.ToList(); 
            var listCategories= dbContext.Categories.ToList();
            var listProductsCategories = listCategories.GroupJoin(listProducts,
                listCategories=>listCategories.CategoryId,
                listProducts=>listProducts.CategoryId,
                (listCategories,listProducts)=>new
                {Category=listCategories.CategoryName,
                Products=listProducts});

            foreach(var item in listProductsCategories)
            {
                Console.WriteLine("*********************************");
                Console.WriteLine("Categoria: " + item.Category);
                Console.WriteLine("*********************************");
                foreach(var product in item.Products)
                {
                    Console.WriteLine(product.ProductName + "\t\t" + product.UnitPrice);
                }

            }
        
        }
        public static void Zip()
        {

            var enteros = new List<int> { 1, 2, 3, 4, 5 };
            var textos = new List<string> { "uno", "dos", "tres", "cuatro" };
            var resultado= enteros.Zip(textos,(e,t)=>e+"=>"+t);
            foreach(var item in resultado)
            {
                Console.WriteLine(item);
            }
            resultado = resultado.Reverse();
            foreach (var item in resultado)
            {
                Console.WriteLine(item);
            }
        }
        public static void Count()
        {

        }
    }
}
