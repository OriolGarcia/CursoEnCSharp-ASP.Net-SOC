using _20221216_Localizacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _20221216_Localizacion.Controllers
{

        public class HomeController : Controller
        {
            private readonly ILogger<HomeController> _logger;
            private readonly IStringLocalizer<HomeController> _localizer;
            public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
            {
                _logger = logger;
                _localizer = localizer;
            }

            public IActionResult Index()
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en");
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");

                ViewData["Prueba"] = _localizer["Prueba"];
                ViewData["Test"] = _localizer["Otra"];
                return View();
            }

            public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
       
    }
}
