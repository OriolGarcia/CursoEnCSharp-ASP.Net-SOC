using _20221118_NeptunoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace _20221118_NeptunoMVC.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            CategoriesModel cm = new CategoriesModel();
            var lista = cm.GetCategories();
            ViewData["categories"] = lista;
            return View();
        }
    }
}
