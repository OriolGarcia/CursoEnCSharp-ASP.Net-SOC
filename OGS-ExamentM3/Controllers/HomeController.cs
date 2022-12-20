using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OGS_ExamentM3.Dal;
using OGS_ExamentM3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OGS_ExamentM3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        public IActionResult LaEmpresa()
        {
            return View();
        }

        public string GetOrders()
        {
            var dbContext = new cifo_OGSContext();
            var total = dbContext.OrderDetails.Sum(s => s.Quantity * (double)s.UnitPrice * (1 - s.Discount)).ToString();
            string resp = "";

            resp += "<div>Total de ventas:" + total + "$ </div>";

            return resp;
        }
    }
}
