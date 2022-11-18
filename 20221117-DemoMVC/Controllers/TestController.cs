using Microsoft.AspNetCore.Mvc;

namespace _20221117_DemoMVC.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Prueba()
        {
            string resultado = "";

            //

            resultado = "Esto es una prueba de resultado2";
            ViewData["resultado"] = resultado;

            return View();
        }
    }
}
