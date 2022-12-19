using _20221216_SimulacroExamen.Models;
using Microsoft.AspNetCore.Mvc;

namespace _20221216_SimulacroExamen.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
           EmployeeModel em = new EmployeeModel();
            var lista = em.GetEmployes();
            ViewData["employees"] = lista;
            return View();
            
        }
    }
}
