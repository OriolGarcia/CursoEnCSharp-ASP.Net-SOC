using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _20221125_ClienteNeptuno.Filters
{
    public class SessionFilter:ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            Controller controller = (Controller)context.Controller;

            string userId = null;
            string nombreUsuario = null;
            try
            {
                userId = context.HttpContext.Session.GetString("UserId");
                nombreUsuario = context.HttpContext.Session.GetString("UserName");
            }
            catch { }
            controller.ViewData["UserId"] = userId;
            controller.ViewData["NombreUsuario"] = nombreUsuario;
        }
    }
}
