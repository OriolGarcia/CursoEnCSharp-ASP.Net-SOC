using Microsoft.AspNetCore.Mvc;
using OGS_ExamentM3.Dal;
using System.Collections.Generic;
using System.Linq;

namespace OGS_ExamentM3.Models
{
    public class ProductsModel { 
        

        public List<ProductSlim> GetProducts()
        {
            var dbContext = new cifo_OGSContext();

            var products = dbContext.Products
                .Where(p => (p.Discontinued==0))
                .OrderBy(p => p.ProductName)
                .Select(p => new ProductSlim
                {
                    ProductId = p.ProductId.ToString(),
                    ProductName = p.ProductName,
                    CategoryName = p.Category.CategoryName,
                    Suplier=p.Supplier.CompanyName,
                    Country=p.Supplier.Country,
                    Price = p.UnitPrice,
                    Stock = p.UnitsInStock,
                    State = (p.Discontinued == 0) ? true : false
                }).ToList();

            return products;
        }
    }
    public class ProductSlim
    {
        public string ProductId { get; set; }
        public string Country { get; set; }
        public string ProductName { get; set; }
        public string Suplier { get; set; }
        public string CategoryName { get; set; }
        public decimal? Price { get; set; }
        public short? Stock { get; set; }
        public bool State { get; set; }
    }
}
