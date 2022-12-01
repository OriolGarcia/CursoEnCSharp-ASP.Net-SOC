using _20221124_APINeptuno.Dal;
using _20221125_ClienteNeptuno.Filters;
using _20221125_ClienteNeptuno.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _20221125_ClienteNeptuno.Controllers
{
    public class UsersController : Controller
    {
        private IUsersService service;
        public UsersController(IUsersService _service)
        {
            service = _service;
        }

        [HttpGet]
        [SessionFilter]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserId") != null) return RedirectToAction("Index", "Home");
            ViewData["UserId"] = null;
            string S = HttpContext.Request.Query["S"];
            if (S == "1")
            {
                ViewData["Mensaje"] = "Login erróneo";

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DoLogin(string login, string password)
        {
            //validación de si el login es correcto
            var user = await service.DoLogin(login,password);

            if (user == null) {
                //login malo
                return RedirectToAction("Login", new {s=1});
            }
            else {
                HttpContext.Session.SetString("UserName", user.Nombre);
                HttpContext.Session.SetString("UserId", user.UserId.ToString());

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
