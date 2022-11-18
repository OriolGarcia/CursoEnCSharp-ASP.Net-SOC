using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using _20221109_Linq.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;

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
            //ListaPaisesCS();
            //GroupJoin();
            //Zip();
            //GroupBy();
            //OfType();
            //ToArray();
            //ToDictionary();
            //First();
            //Find();
            //Single();
            //Count();
            //Sum();
            //shippers();

            //Clientes();
            // BuscadorPedidos();
            //BuscadorPedidos2();

            //EX3Linq();
            //Ex4();
            //BuscadorproEmpleado();
            //EXAMEN_AC1_3();
            EXAMEN_AC1_4();
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
                .Select(p => p.ProductName);

            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
        }

        public static void Paginador()
        {
            NeptunoContext dbContext = new NeptunoContext();

            //Los ThenBy están a modo de ejemplo pero no tienen efecto
            var products = dbContext.Products.OrderBy(p => p.ProductName)
                .ThenBy(p => p.UnitPrice)
                .ThenByDescending(p => p.UnitsInStock);

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
                    Console.WriteLine((actual + counter) + " - " +
                        item.ToString());
                }

                //Mostrar opciones de paginación

                //Evaluar si hay que mostrar el Atras
                if (actual > 0)
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

            var pedidos = dbContext.Orders.OrderByDescending(p => p.Freight)
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
                .OrderBy(c => c.CompanyName);

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
            //Lista jerarquizada Categorías/Productos
            //Lista jerarquizada Suppliers/Productos
            //Lista jerarquizada Customers/Orders
            //Lista jerarquizada Employees/Orders

            var dbContext = new NeptunoContext();

            var listProducts = dbContext.Products.ToList();
            var listCategories = dbContext.Categories.ToList();

            var listProductsCategory = listCategories.GroupJoin(listProducts,
                    listCategories => listCategories.CategoryId,
                    listProducts => listProducts.CategoryId,
                    (listCategories, listProducts) => new
                    {
                        Category = listCategories.CategoryName,
                        Productos = listProducts
                    });

            foreach (var item in listProductsCategory)
            {
                Console.WriteLine("*********************************");
                Console.WriteLine("Categoría: " + item.Category);
                Console.WriteLine("*********************************");

                foreach (var product in item.Productos)
                {
                    Console.WriteLine(product.ProductName + "\t\t" +
                                        product.UnitPrice);
                }
            }
        }

        public static void Zip()
        {
            var enteros = new List<int> { 1, 2, 3, 4, 5 };
            var textos = new List<string> { "uno", "dos", "tres", "cuatro" };

            var resultado = enteros.Zip(textos, (e, t) => e + "=>" + t);

            foreach (var item in resultado)
            {
                Console.WriteLine(item);
            }

            //Invertir la lista
            resultado = resultado.Reverse();
            foreach (var item in resultado)
            {
                Console.WriteLine(item);
            }

        }

        public static void GroupBy()
        {
            var dbContext = new NeptunoContext();

            var listProducts = dbContext.Products.Include(c => c.Category)
                .OrderBy(p => p.Category.CategoryName)
                .Select(p => new
                {
                    Category = p.Category.CategoryName,
                    CategoryId = p.CategoryId
                })
                .ToList();

            var listGroupBy = listProducts.GroupBy(l => l.Category)
                .OrderByDescending(l => l.Count());

            foreach (var item in listGroupBy)
            {
                Console.WriteLine(item.Key + "\t\t" + item.Count());
            }
        }

        public static void OfType()
        {
            var dbContext = new NeptunoContext();

            ArrayList arrayList = new ArrayList();

            //...

            var arrayListFiltrado = arrayList.OfType<int>();


            Products p = dbContext.Products.Find(1);

            List<Object> lista = new List<Object>();
            lista.Add(1);
            lista.Add(22);
            lista.Add("pepe");
            lista.Add(p);

            var listaFiltrado = lista.OfType<int>();


        }

        public static void ToArray()
        {
            var dbContext = new NeptunoContext();

            string[] arrayCustomers = dbContext.Customers
                .Where(c => c.Country == "USA")
                .OrderBy(c => c.CompanyName)
                .Select(c => c.CompanyName)
                .ToArray();

            for (int i = 0; i < arrayCustomers.Length; i++)
            {
                Console.WriteLine(arrayCustomers[i]);
            }
        }

        public static void ToDictionary()
        {
            var dbContext = new NeptunoContext();

            var dictCategories = dbContext.Categories
                .Select(c => new
                {
                    Category = c.CategoryName,
                    TotalProducts =
                    (
                        dbContext.Products
                            .Where(p => p.CategoryId == c.CategoryId)
                            .Count()
                    )
                })
                .ToDictionary(c => c.Category, c => c.TotalProducts);

            Console.WriteLine(dictCategories["Beverages"]);

            Console.WriteLine(dictCategories["Condiments"]);

        }
        public static void First()
        {
            var dbContext = new NeptunoContext();

            var product = dbContext.Products
                            .Where(p => p.CategoryId == 25)
                            .OrderBy(p => p.ProductName)
                            .Select(p => p.ProductName)
                            .FirstOrDefault();

            Console.WriteLine(product);

            //Peligro
            try
            {
                var product1 = dbContext.Products
                            .Where(p => p.CategoryId == 1)
                            .OrderBy(p => p.ProductName)
                            .FirstOrDefault(p => p.ProductId > 1000);

                Console.WriteLine(product1.ProductName);
            }
            catch
            {
                Console.WriteLine("No existe producto");
            }

        }

        public static void Find()
        {
            var dbContext = new NeptunoContext();

            try
            {
                var pedido = dbContext.Orders.Find(10248);
                Console.WriteLine(pedido.OrderDate + "\t\t" + pedido.Freight);

                var customer = dbContext.Customers.Find("ANATR");
                Console.WriteLine(customer.CompanyName);
            }
            catch { }

        }

        public static void Single()
        {
            var dbContext = new NeptunoContext();

            var product = dbContext.Products
                .Single(p => p.ProductName == "Chai");

            Console.WriteLine(product.ProductName);

            Console.WriteLine("************************************");

            var products = dbContext.Products
                .Where(p => p.ProductName.Contains("Queso"));

            foreach (var item in products)
            {
                Console.WriteLine(item.ProductName);
            }

            Console.WriteLine("************************************");

            var product2 = dbContext.Products.OrderBy(p => p.ProductName)
                .ToList()
                .ElementAt(10);

            Console.WriteLine(product2.ProductName);

        }

        public static void Count()
        {
            var dbContext = new NeptunoContext();

            //Calcular el promedio de lineas que tienen nuestros pedidos
            var totalPedidos = dbContext.Orders.Count();
            var totalLineas = dbContext.OrderDetails.Count();

            Console.WriteLine(((decimal)totalLineas / (decimal)totalPedidos)
                .ToString("N2"));


            //Calcular de cuantos productos activos no tenemos stock
            Console.WriteLine(dbContext.Products
                .Where(p => p.UnitsInStock == 0 && p.Discontinued == false)
                .Count());


        }

        public static void Sum()
        {
            //Calcular el importe del stock valorado que tenemos
            //para productos superiores al precio medio de los productos
            var dbContext = new NeptunoContext();

            var stockValorado = dbContext.Products
                .Where(p => p.UnitPrice >
                (
                    dbContext.Products.Average(p1 => p1.UnitPrice)
                ))
                .Sum(p => p.UnitsInStock * p.UnitPrice);

            Console.WriteLine("Stock valorado=" +
                ((decimal)stockValorado).ToString("N2"));


            //Queremos saber el importe total de los costes logísticos del 
            //shipper 'Federal Shipping'
            var importeTotal = dbContext.Orders
                .Where(o => o.Shipper.CompanyName == "Federal Shipping")
                .Sum(o => o.Freight);

            Console.WriteLine("Coste logístico=" +
                ((decimal)importeTotal).ToString("N2"));

            //Total de pedidos de 'Federal Shipping'
            var importeTotalPedidos = dbContext.OrderDetails
                .Where(od => od.Order.Shipper.CompanyName == "Federal Shipping")
                .Sum(od => od.UnitPrice * od.Quantity * (1 - (decimal)od.Discount));

            Console.WriteLine("Importe total=" +
                ((decimal)importeTotalPedidos).ToString("N2"));

            //De los shippers, mostrar sus pedidos, costes logísticos y importe total
            //NombreShipper     IdPedido    Fechapedido     Coste Logistico   Importe Pedido 
            var pedidos = dbContext.Orders
                .OrderBy(o => o.Shipper.CompanyName)
                .ThenBy(o => o.OrderId)
                .Select(o => new
                {
                    Shipper = o.Shipper.CompanyName,
                    IdPedido = o.OrderId,
                    FechaPedido = o.OrderDate,
                    CosteLogistico = o.Freight,
                    Importe = (dbContext.OrderDetails
                    .Where(od => od.OrderId == o.OrderId)
                    .Sum(od => od.Quantity * od.UnitPrice * (1 - (decimal)od.Discount)))
                });

            foreach (var pedido in pedidos)
            {
                Console.WriteLine(pedido.Shipper + "\t\t" +
                                pedido.IdPedido + "\t\t" +
                                pedido.FechaPedido + "\t\t" +
                                pedido.CosteLogistico + "\t\t" +
                                pedido.Importe);
            }






            //NombreShipper     Costes logísticos totales     Importes pedidos totales
            var shippers = dbContext.Shippers
                .OrderBy(s => s.CompanyName).Select(s => new
                {
                    Shipper = s.CompanyName,
                    CosteLogistico =
                    (
                    dbContext.Orders
                    .Where(o => o.Shipper.ShipperId == s.ShipperId)
                    .Sum(o => o.Freight)
                    ),
                    Importe = (
                    dbContext.OrderDetails
                    .Where(od => od.Order.Shipper.ShipperId == s.ShipperId)
                    .Sum(od => od.Quantity * od.UnitPrice * (1 - (decimal)od.Discount)))


                });
            foreach (var ship in shippers)
            {
                Console.WriteLine(ship.Shipper + "\t\t" +
                                ship.CosteLogistico + "\t\t" +
                                    ship.Importe + "\t\t");
            }
        }

        public static void shippers()
        {
            var dbContext = new NeptunoContext();
            // NombreShipper     Costes logísticos totales Importes pedidos totales
            var shippers = dbContext.Shippers
                .OrderBy(s => s.CompanyName).Select(s => new
                {
                    Shipper = s.CompanyName,
                    CosteLogistico =
                    (
                    dbContext.Orders
                    .Where(o => o.Shipper.ShipperId == s.ShipperId)
                    .Sum(o => o.Freight)
                    ),
                    Importe = (
                    dbContext.OrderDetails
                    .Where(od => od.Order.Shipper.ShipperId == s.ShipperId)
                    .Sum(od => od.Quantity * od.UnitPrice * (1 - (decimal)od.Discount)))


                });
            foreach (var ship in shippers)
            {
                Console.WriteLine(ship.Shipper + "\t\t" +
                                ship.CosteLogistico + "\t\t" +
                                    ship.Importe + "\t\t");
            }
        }

        public static void Clientes()
        {
            var dbContext = new NeptunoContext();
            var customers = from c in dbContext.Customers
                            join o in dbContext.Orders on c.CustomerId equals o.CustomerId
                            join o2 in dbContext.OrderDetails on o.OrderId equals o2.OrderId
                            join p in dbContext.Products on o2.ProductId equals p.ProductId
                            join ca in dbContext.Categories on p.CategoryId equals ca.CategoryId
                            orderby c.CompanyName, ca.CategoryName, p.ProductName
                            group o2 by new { c.CompanyName, ca.CategoryName, p.ProductName } into g
                            select new
                            {
                                Client = g.Key.CompanyName,
                                Categoria = g.Key.CategoryName,
                                Producto = g.Key.ProductName,
                                Importe = g.Sum(
                                    d => d.Quantity * d.UnitPrice * (1 - (decimal)d.Discount)
                                    ),

                                Veces = g.Count()
                            };



            int counter = 0;
            foreach (var item in customers)
            {
                counter++;
                Console.WriteLine(item.Client + "\t\t" + item.Categoria + "\t\t" + item.Producto + "\t\t" + item.Importe + "\t\t" + item.Veces);

            }

            Console.WriteLine("Tolal:" + counter);

        }
        public static void Example03()
        {
            //Obtener un listado por clientes y productos que nos han comprado
            //Cliente   Categoría   Producto    Importe
            //Ordenado por Cliente, Categoría, Producto
            var dbContext = new NeptunoContext();

            var lista = from c in dbContext.Customers
                        join o in dbContext.Orders on c.CustomerId equals o.CustomerId
                        join od in dbContext.OrderDetails on o.OrderId equals od.OrderId
                        join p in dbContext.Products on od.ProductId equals p.ProductId
                        join ca in dbContext.Categories on p.CategoryId equals ca.CategoryId
                        orderby c.CompanyName, ca.CategoryName, p.ProductName
                        group od by new { c.CompanyName, ca.CategoryName, p.ProductName } into g
                        select new
                        {
                            Cliente = g.Key.CompanyName,
                            Categoria = g.Key.CategoryName,
                            Producto = g.Key.ProductName,
                            Importe = g.Sum
                            (
                                d => d.Quantity * d.UnitPrice * (1 - (decimal)d.Discount)
                            ),
                            Veces = g.Count()
                        };

            int counter = 0;
            foreach (var item in lista)
            {
                counter++;
                Console.WriteLine(counter + "\t\t" + item.Cliente + "\t\t" +
                    item.Categoria + "\t\t" +
                    item.Producto + "\t\t" +
                    item.Importe + "\t\t" +
                    item.Veces);
            }

        }

        public static void Example04()
        {
            //Obtener un listado por clientes y productos que nos han comprado
            //Cliente   Categoría   Producto    Importe
            //Ordenado por Cliente, Categoría, Producto
            var dbContext = new NeptunoContext();

            var lista = dbContext.OrderDetails
                .OrderBy(od => od.Order.Customer.CompanyName)
                .ThenBy(od => od.Product.Category.CategoryName)
                .ThenBy(od => od.Product.ProductName)
                .GroupBy(od => new
                {
                    CompanyName = od.Order.Customer.CompanyName,
                    CategoryName = od.Product.Category.CategoryName,
                    ProductName = od.Product.ProductName
                })
                .Select(g => new
                {
                    Cliente = g.Key.CompanyName,
                    Categoria = g.Key.CategoryName,
                    Producto = g.Key.ProductName,
                    Importe = g.Sum
                        (
                            d => d.Quantity * d.UnitPrice * (1 - (decimal)d.Discount)
                        ),
                    Veces = g.Count()
                });

            int counter = 0;
            foreach (var item in lista)
            {
                counter++;
                Console.WriteLine(counter + "\t\t" + item.Cliente + "\t\t" +
                    item.Categoria + "\t\t" +
                    item.Producto + "\t\t" +
                    item.Importe + "\t\t" +
                    item.Veces);

            }

        }

        public static void BuscadorPedidos()
        {

            while (true)
            {
                //Presentar opciones del buscador
                Console.Clear();
                Console.WriteLine("Seleccione una opción: [B]Buscador [S]Salir");
                string opcion = Console.ReadLine().ToUpper();
                if (opcion == "S") break;

                //Introducción de datos (2 fechas)
                Console.Write("Fecha inicio: ");
                string fechaInicio = Console.ReadLine();
                Console.Write("Fecha fin: ");
                string fechaFin = Console.ReadLine();

                //Preparación de la consulta
                var dbContext = new NeptunoContext();
                var pedidos = dbContext.OrderDetails
                    .Where(od => od.Order.OrderDate >= DateTime.Parse(fechaInicio) &&
                               od.Order.OrderDate <= DateTime.Parse(fechaFin))
                    .OrderBy(od => od.Order.Customer.CompanyName)
                    .ThenBy(od => od.Order.OrderDate)
                    .GroupBy(od => new
                    {
                        OrderId = od.OrderId,
                        OrderDate = od.Order.OrderDate,
                        Customer = od.Order.Customer.CompanyName,
                        Employee = od.Order.Employee.FirstName + " " +
                                    od.Order.Employee.LastName
                    })
                    .Select(g => new
                    {
                        OrderId = g.Key.OrderId,
                        OrderDate = g.Key.OrderDate,
                        Customer = g.Key.Customer,
                        Employee = g.Key.Employee,
                        Amount = g.Sum
                        (
                            d => d.Quantity * d.UnitPrice * (1 - (decimal)d.Discount)
                        )
                    });

                //Mostrar los datos
                int counter = 0;
                foreach (var pedido in pedidos)
                {
                    counter++;
                    Console.WriteLine(counter + "\t\t" + pedido.OrderId + "\t\t" +
                        ((DateTime)pedido.OrderDate).ToShortDateString() + "\t\t" +
                        pedido.Customer + "\t\t" +
                        pedido.Employee + "\t\t" +
                        ((decimal)pedido.Amount).ToString("N2"));
                }

                //Paginador
                Console.ReadLine();

            }



        }
        public static void BuscadorPedidos2()
        {

            while (true)
            {
                //Presentar opciones del buscador
                Console.Clear();
                Console.WriteLine("Seleccione una opción: [B]Buscador [S]Salir");
                string opcion = Console.ReadLine().ToUpper();
                if (opcion == "S") break;

                //Introducción de datos (2 fechas)
                Console.Write("Fecha inicio: ");
                string fechaInicio = Console.ReadLine();
                Console.Write("Fecha fin: ");
                string fechaFin = Console.ReadLine();

                //Preparación de la consulta
                var dbContext = new NeptunoContext();
                var pedidos = dbContext.OrderDetails
                    .Where(od => od.Order.OrderDate >= DateTime.Parse(fechaInicio) &&
                               od.Order.OrderDate <= DateTime.Parse(fechaFin))
                    .OrderBy(od => od.Order.Customer.CompanyName)
                    .ThenBy(od => od.Order.OrderDate)
                    .GroupBy(od => new
                    {
                        OrderId = od.OrderId,
                        OrderDate = od.Order.OrderDate,
                        Customer = od.Order.Customer.CompanyName,
                        Employee = od.Order.Employee.FirstName + " " +
                                    od.Order.Employee.LastName
                    })
                    .Select(g => new
                    {
                        OrderId = g.Key.OrderId,
                        OrderDate = g.Key.OrderDate,
                        Customer = g.Key.Customer,
                        Employee = g.Key.Employee,
                        Amount = g.Sum
                        (
                            d => d.Quantity * d.UnitPrice * (1 - (decimal)d.Discount)
                        )
                    });

                /*
                //Mostrar los datos
                Console.WriteLine("Orden\t\tOrderId\t\t" +
                        "Fecha Pedido\t\t" +
                        "Cliente\t\t" +
                        "Empleado\t\t" +
                        "Importe Pedido");
                Console.WriteLine("-------------------------------------------------------");

                
                //PAGINADOR MAS
                //Datos necesarios para cualquier paginador
                int elementosPP = 10;
                int actual = 0;
                int totalRegistros = pedidos.Count();

                while (true)
                {
                    //Seleccionar los elementos que hay que mostrar
                    var pedidosAMostrar = pedidos.Skip(actual).Take(elementosPP);

                    int counter = actual;
                    foreach (var pedido in pedidosAMostrar)
                    {
                        counter++;
                        Console.WriteLine(counter + "\t\t" + pedido.OrderId + "\t\t" +
                            ((DateTime)pedido.OrderDate).ToShortDateString() + "\t\t" +
                            pedido.Customer + "\t\t" +
                            pedido.Employee + "\t\t" +
                            ((decimal)pedido.Amount).ToString("N2"));
                    }

                    Console.ReadKey();  //Parada pendiente una tecla

                    //Más
                    actual = actual + elementosPP;

                    //Salida
                    if (actual >= totalRegistros) break;
                }
                */

                //Paginador Números
                //Datos necesarios para cualquier paginador
                int elementosPP = 10;
                int actual = 0;
                int totalRegistros = pedidos.Count();

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Orden\t\tOrderId\t\t" +
                        "Fecha Pedido\t\t" +
                        "Cliente\t\t" +
                        "Empleado\t\t" +
                        "Importe Pedido");
                    Console.WriteLine("-------------------------------------------------------");

                    //Seleccionar los elementos que hay que mostrar
                    var pedidosAMostrar = pedidos.Skip(actual).Take(elementosPP);

                    int counter = actual;
                    foreach (var pedido in pedidosAMostrar)
                    {
                        counter++;
                        Console.WriteLine(counter + "\t\t" + pedido.OrderId + "\t\t" +
                            ((DateTime)pedido.OrderDate).ToShortDateString() + "\t\t" +
                            pedido.Customer + "\t\t" +
                            pedido.Employee + "\t\t" +
                            ((decimal)pedido.Amount).ToString("N2"));
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

                    //Pintar el grupo 3
                    /*
                    int limite = (totalRegistros % elementosPP == 0) ? 
                        totalRegistros / elementosPP :
                        totalRegistros / elementosPP + 1;
                    
                    for (int i=1; i<=limite; i++)
                    {
                        if (i == actual/elementosPP+1)
                        {
                            Console.Write(" [" + i + "]");
                        }
                        else
                        {
                            Console.Write(" " + i);
                        }
                    }*/
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

        public static void SimulacroEX2()
        {

            var dbContext = new NeptunoContext();

            var lista = dbContext.OrderDetails
                .OrderBy(od => od.Order.Customer.Country)
                .ThenBy(od => od.Order)
                .ThenBy(od => od.Order.Customer)
                .GroupBy(od => new
                {
                    Country = od.Order.Customer.Country
                })
                .Select(g => new
                {
                    Country = g.Key.Country,

                    Importe = g.Sum
                        (
                            d => d.Quantity * d.UnitPrice * (1 - (decimal)d.Discount)
                        ),

                }).OrderBy(od => od.Country);


            Console.WriteLine("Country\t\t Impoorte");
            int counter = 0;
            foreach (var od in lista)
            {
                counter++;
                Console.WriteLine(od.Country + "\t\t" + od.Importe);

            }
        }
        public static void EX3Linq()
        {


            var dbContext = new NeptunoContext();
            var lista = dbContext.Products
                        .Where(p => p.Category.CategoryName == "Beverages" || p.Category.CategoryName == "Confections"
                        || p.Category.CategoryName == "Meat/Poultry")
                        .OrderBy(od => od.Category.CategoryName).OrderBy(od => od.ProductName)
                        .ThenBy(p => p.ProductName)
                        .Select(p => new
                        {
                            Categoria = p.Category.CategoryName,
                            Product = p.ProductName,
                            UnitPrice = p.UnitPrice,
                            InStock = p.UnitsInStock,
                            Discontiued = p.Discontinued,

                        });
            Console.WriteLine("Categoria\t\t Product \t\t UnitPrice\t\t InStock\t\t Discontiued");
            int count = 0;
            foreach (var od in lista)
            {

                Console.WriteLine(count + od.Categoria + "\t\t" + od.Product + "\t\t" + od.UnitPrice + "\t\t" + od.InStock + "\t\t" + od.Discontiued);
                count++;
            }



        }
        public static void EXAMEN_AC1_3()
        {


            var dbContext = new NeptunoContext();
            var lista = dbContext.Products
                        .Where(p => p.Supplier.Country == "France" || p.Supplier.Country == "Germany"
                        || p.Supplier.Country == "Italy")
                        .OrderBy(p => p.ProductName).OrderBy(p => p.Supplier.CompanyName)


                        .Select(p => new
                        {
                            Suplier= p.Supplier.CompanyName,
                            ProductName = p.ProductName,
                            UnitPrice = p.UnitPrice,
                            InStock = p.UnitsInStock,
                            Discontiued = p.Discontinued,

                        });
            Console.WriteLine("Count\t\tProveidor\t\t Product \t\t UnitPrice\t\t InStock\t\t Discontiued");
            int count = 0;
            foreach (var p in lista)
            {

                Console.WriteLine(count + "\t\t" + p.Suplier + "\t\t" + p.ProductName + "\t\t" + p.UnitPrice + "\t\t" + p.InStock + "\t\t" + p.Discontiued);
                count++;
            }



        }
        public static void EXAMEN_AC1_4()//Expressions Linq
        {
            var dbContext = new NeptunoContext();
            var lista = from od in dbContext.OrderDetails
                        join p in dbContext.Products on od.ProductId equals p.ProductId
                        join s in dbContext.Suppliers on p.SupplierId equals s.SupplierId

                        group od by new
                        {
                            Country = s.Country,
                        } into g
                        orderby g.Key.Country
                        select new
                        {
                            Country = g.Key.Country,
                            Importe = g.Sum(
                                d => d.Quantity * d.UnitPrice * (1 - (decimal)d.Discount)
                                )


                        };

            Console.WriteLine("Country\t\t Impoorte");
            int counter = 0;
            foreach (var od in lista)
            {
                counter++;
                Console.WriteLine(od.Country + "\t\t" + ((decimal)od.Importe).ToString("N2") );

            }

        }

        public static void BuscadorproEmpleado()
        {

            while (true)
            {
                //Presentar opciones del buscador
                Console.Clear();
                Console.WriteLine("Seleccione una opción: [B]Buscar  [S]Salir");
                string opcion = Console.ReadLine().ToUpper();
                if (opcion == "S") break;

                //Introducción de datos (2 fechas)
                Console.Write("Ciudad: ");
                string ciudad = Console.ReadLine();
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Cargo: ");
                string cargo = Console.ReadLine();

                //Preparación de la consulta
                var dbContext = new NeptunoContext();
                var empleados = dbContext.Employees
                    .Where(e => e.City.Contains(ciudad) && (e.FirstName.Contains(nombre) || e.LastName.Contains(nombre)) && e.Title.Contains(cargo))


                    .Select(g => new
                    {
                        FirstName = g.FirstName,
                        LastName = g.LastName,
                        City = g.City,
                        Title = g.Title,

                    });

                Console.WriteLine("FirstName\t\tLastName\t\t City,\t\t Title");
                int counter = 0;
                foreach (var e in empleados)
                {
                    counter++;
                    Console.WriteLine(e.FirstName + "\t\t" + e.LastName + "\t\t" + e.City + "\t\t" + e.Title);

                }
                Console.ReadLine();
            }
        }
    }
}