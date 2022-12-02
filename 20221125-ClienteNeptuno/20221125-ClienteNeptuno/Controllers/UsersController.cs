using _20221124_APINeptuno.Dal;
using _20221125_ClienteNeptuno.Filters;
using _20221125_ClienteNeptuno.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using Utils;

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
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
                HttpContext.Response.Cookies.Append("UserName", user.Nombre, cookieOptions);
                HttpContext.Response.Cookies.Append("UserId", user.UserId.ToString(), cookieOptions);
                if(HttpContext.Session.GetString("Redirect")!= null)
                {
                    string redirect = HttpContext.Session.GetString("Redirect");
                    HttpContext.Session.Remove("Redirect");
                    return RedirectToAction(redirect.Split('/')[2], redirect.Split('/')[1]);

                }
                return RedirectToAction("Index", "Home");
                
            }
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            UtilsWeb.InvalidarSession(HttpContext);
           
            return RedirectToAction("Index", "Home");
        }

    }
}
