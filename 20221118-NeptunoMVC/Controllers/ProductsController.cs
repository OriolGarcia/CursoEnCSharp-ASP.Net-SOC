using _20221118_NeptunoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace _20221118_NeptunoMVC.Controllers
{
	public class ProductsController : Controller
	{
		public IActionResult Index(int CategoryId=0)
		{

			ProductsModel pm = new ProductsModel();
			var lista = pm.GetProducts(CategoryId);
			ViewData["products"]=lista;

			return View();
		}
	}
}
