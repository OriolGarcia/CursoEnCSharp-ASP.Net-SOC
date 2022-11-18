using _20221118_NeptunoMVC.Dal;
using System.Collections.Generic;
using System.Linq;

namespace _20221118_NeptunoMVC.Models
{
	public class ProductsModel
	{
		public List<ProductSlim> GetProducts(int CategoryId)
		{
            var dbContext = new cifo_OGSContext();
            var products= dbContext.Products.Where(p=>p.CategoryId == CategoryId)
				.OrderBy(p=>p.ProductName).Select(p=>new ProductSlim{
				ProductId=p.ProductId,
				ProductName=p.ProductName,
				CategoryName=p.Category.CategoryName,
				Price=p.UnitPrice,
				Stock=p.UnitsInStock,
				State=(p.Discontinued==0)?true:false,
			}).ToList();
			return products;

        }
	}
	public class ProductSlim
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public string CategoryName { get; set; }
		public decimal? Price { get; set; }
		public short? Stock { get; set; }
		public bool State { get; set; }

	}
}
