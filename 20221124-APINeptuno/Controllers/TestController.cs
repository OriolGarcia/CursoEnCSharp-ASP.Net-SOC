using _20221124_APINeptuno.Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace _20221124_APINeptuno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet]
        [Route("list")]
      public  List<string> Test()
        {
            List<string> list = new List<string>();
           list.Add("Pedro Picapieda");
            list.Add("Pablo");
            list.Add("Maria");
            return list;
        }

        [HttpGet]
        [Route("get-products")]
        public List<ProductSlim> GetProducts(int categoryId, string search)
        {
            var dbContext = new cifo_OGSContext();

            var products = dbContext.Products
                
                .OrderBy(p => p.ProductName)
                .Select(p => new ProductSlim
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    CategoryName = p.Category.CategoryName,
                    Price = p.UnitPrice,
                    Stock = p.UnitsInStock,
                    State = (p.Discontinued == 0) ? true : false
                }).ToList();

            return products;
        }



    } public class ProductSlim
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string CategoryName { get; set; }
            public decimal? Price { get; set; }
            public short? Stock { get; set; }
            public bool State { get; set; }
        }
}
