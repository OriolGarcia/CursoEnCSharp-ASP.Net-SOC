using Microsoft.AspNetCore.Mvc;

namespace _20221118_NeptunoMVC.Controllers
{
	public class ProductsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
