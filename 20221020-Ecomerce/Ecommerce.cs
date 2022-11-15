using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace _20221020_Ecomerce
{
    internal class Ecommerce
    {

        private string nombreComercio;
        private List<Producto> productosDisponibles= new List<Producto>();
        private List<ProductoAñadido> cesta = new List<ProductoAñadido>();

        public string NombreComercio { get { return nombreComercio; } }
        public Ecommerce(string nombreComercio)
        {
            this.nombreComercio = nombreComercio;
            getData();
        }
        private List<Producto> getData()
        {
            nombreComercio = "Amazon";
            ProductoFisico p1 = new ProductoFisico("SR001", "Tablet", "Samsung A2", 130.99M, 15, 5.00M);
            ProductoFisico p2 = new ProductoFisico("SW1", "Ordenador", "Lenovo 1500X", 590.99M, 5, 15.00M);
            ProductoFisico p3 = new ProductoFisico("HPEnvy", "Impresora", "Envy HP 2694", 70.99M, 11, 9.00M);
            ProductoFisico p4 = new ProductoFisico("S22", "Mobil", "Redmi 13", 190.99M,50, 11.00M);
            ProductoVirtual p5 = new ProductoVirtual("AE1", "Age of Empires 3", "Juego", 80.99M, 15,"launch.exe",22.5f);
            ProductoVirtual p6 = new ProductoVirtual("AP2", "Avast", "AAntivirus", 40.99M, 150,"avast.exe",40.5f);
            ProductoVirtual p7 = new ProductoVirtual("CS", "Photoshop", "Progrma", 180.99M, 15, "css.exe", 23.5f);
            ProductoVirtual p8 = new ProductoVirtual("WIN", "WINDOWS", "Sistema operativo Windows11", 3000.99M, 250, "windows11.exe", 500.5f);


            productosDisponibles.Add(p1);
            productosDisponibles.Add(p2);
            productosDisponibles.Add(p3);
            productosDisponibles.Add(p4);
                
            productosDisponibles.Add(p5);
            productosDisponibles.Add(p6);
                
            productosDisponibles.Add(p7);
            productosDisponibles.Add(p8);
            return productosDisponibles;
        }

        public void buscador()
        {

            while (true)
            {

                Console.Write("\r\n\r\nBUSCAR POR:     ");

                string search= Console.ReadLine();

              List<Producto> busqueda = new List<Producto>();
                busqueda=productosDisponibles.FindAll(p => p.Nombre.ToLower().Contains(search.ToLower()) ||
                                  p.Descripcion.ToLower().Contains(search.ToLower()));
               
                if (busqueda.Count == 0)
                {
                    Console.WriteLine("No se han encontrado productos");
                    continue;

                }
                
                
                for (int i = 0; i < busqueda.Count; i++)
                {
                    Console.WriteLine(i + "-  " + busqueda[i].ToString());


                }

                Console.WriteLine(" Que producto quieres comprar? [num -> añadir a la cesta, 's' salir 'c' consultar cesta");

                string op = Console.ReadLine().ToLower();
                if (op == "s") { return; }
                else if (op == "c") { consultarCesta(); }
                else if (int.TryParse(op, out int result))
                {
                    Console.WriteLine(" Que cantidad?");
                    string c= Console.ReadLine().ToLower();
                    Producto p = productosDisponibles.Find(p => p == busqueda[result]);
                    if (int.TryParse(c, out int cantidad) && (p.Stock - cantidad > 0)){

                      
                        if (p.Stock > 0)
                        {
                            p.Stock = p.Stock - cantidad;
                            ProductoAñadido pa = new ProductoAñadido(busqueda[result].Codigo, busqueda[result].Nombre, busqueda[result].Descripcion, busqueda[result].PrecioSinIva, cantidad);
                            if (cesta.Contains(pa))
                            {
                                cesta.Find(p => p == pa).Cantidad++;
                            }
                            else
                                cesta.Add(pa);
                        }
                    }
                }
            }

        }

        public void listarProductos()
        {

            while (true)
            {
                for (int i = 0; i < productosDisponibles.Count; i++)
                {
                    Console.WriteLine(i + "-  " + productosDisponibles[i].ToString());


                }

                Console.WriteLine(" Que producto quieres comprar? [num -> añadir a la cesta, 's' salir 'c' consultar cesta");

                string op = Console.ReadLine().ToLower();
                if (op == "s") { return; }
                else if (op == "c") { consultarCesta(); }
                else if (int.TryParse(op, out int result))
                {
                    
                    

                    Console.WriteLine(" Que cantidad?");
                    string c = Console.ReadLine().ToLower();
                    Producto p = productosDisponibles.Find(p => p == productosDisponibles[result]);
                    if (int.TryParse(c, out int cantidad) && (p.Stock - cantidad > 0))
                    {

                        if (p.Stock > 0)
                        {
                            p.Stock = p.Stock - cantidad;
                            ProductoAñadido pa = new ProductoAñadido(productosDisponibles[result].Codigo, productosDisponibles[result].Nombre, productosDisponibles[result].Descripcion, productosDisponibles[result].PrecioSinIva, cantidad);
                            if (cesta.Contains(pa))
                            {
                                cesta.Find(p => p == pa).Cantidad++;
                            }
                            else
                                cesta.Add(new ProductoAñadido(productosDisponibles[result].Codigo, productosDisponibles[result].Nombre, productosDisponibles[result].Descripcion, productosDisponibles[result].PrecioSinIva, cantidad));
                        }
                    }


                }
            }

        
        }
        private void consultarCesta()
        {

            
         

            Console.WriteLine("\r\n\r\n\r\nCantidad              | producto");
            foreach(ProductoAñadido productoA in cesta)
            {
               
                Console.WriteLine( productoA.Cantidad+"           "+productoA.ToString());
            }
            Console.WriteLine("\r\n\r\n");

        }
        public void caja()
        {



        }
    }
}
