using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace _20221125_ClienteNeptuno.Filters
{
    public class CookiesFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            Controller controller = (Controller)context.Controller;

            string userId = null;
            string nombreUsuario = null;
            try
            {
                if (context.HttpContext.Request.Cookies.ContainsKey("UserId"))
                {
                    userId = context.HttpContext.Request.Cookies["UserId"];
                }
                if (context.HttpContext.Request.Cookies.ContainsKey("UserId"))
                {
                    nombreUsuario = context.HttpContext.Request.Cookies["UserName"];
                }
            }
            catch { }
            controller.ViewData["UserId"] = userId;
            controller.ViewData["NombreUsuario"] = nombreUsuario;
        }
    }
}