using _20221117_Mysql_EntityFramework.dal;
using System;
using System.Linq;

namespace _20221117_Mysql_EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new cifo_OGSContext();
            var products = dbContext.Products
                .Select(p => new
                {
                    ProductnName = p.ProductName,
                    Price = p.UnitPrice,
                    Stock = p.UnitsInStock
                });
            foreach(var product in products)
            {
                Console.WriteLine(product.ProductnName+"\t\t"+product.Price+"\t\t" +product.Stock);
            }
        }
    }
}
