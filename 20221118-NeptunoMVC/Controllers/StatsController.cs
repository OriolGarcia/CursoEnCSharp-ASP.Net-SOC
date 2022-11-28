using _20221118_NeptunoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Emit;

namespace _20221118_NeptunoMVC.Controllers
{
	public class StatsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
        public IActionResult Top5()
        {
            StatsModel sm = new StatsModel();
            var top5 = sm.GetTop5();

            //Preparación de ViewData
            //TO_DO

            ViewData["Empleados"] = "[";
            ViewData["Importes"] = "[";
            foreach (var item in top5)
            {
                //ViewData["Empleados"]
                //['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange']
                ViewData["Empleados"] += "'" + item.EmployeeName + "',";

                //ViewData["Importes"]
                //[12, 19, 3, 5, 2, 3]
                ViewData["Importes"] += "" + ((decimal)item.Amount).ToString("N2")
                    .Replace(".", "").Replace(",", ".") + ",";
            }
            ViewData["Empleados"] += "]";
            ViewData["Importes"] += "]";

            ViewData["Empleados"] = ((string)ViewData["Empleados"]).Replace(",]", "]");
            ViewData["Importes"] = ((string)ViewData["Importes"]).Replace(",]", "]");

            return View();
       }
	}
}
