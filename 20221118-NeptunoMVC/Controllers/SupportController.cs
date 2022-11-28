using _20221118_NeptunoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace _20221118_NeptunoMVC.Controllers
{
	public class SupportController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SendMessage()
		{
			//Recibir datos
			string txtName = HttpContext.Request.Form["txtNombre"];
            string txtEmail = HttpContext.Request.Form["txtEmail"];
            string txtPhone = HttpContext.Request.Form["txtTelefono"];
            string txtTema = HttpContext.Request.Form["txtTema"];
            string txtMensaje = HttpContext.Request.Form["txtMensaje"];

			//validación servidor
			//TO_DO
			//Actualizar BD
			SupportModel sm = new SupportModel();
			string message = sm.AddSupport(txtName,txtEmail,txtPhone,txtTema,txtMensaje);
			//Enviar respuesta
			if (message == "OK")
			{
				ViewData["Message"] = "Mensaje enviado correctamente. En breve nos pondremos en contacto con usted";
			}
			else
            { ViewData["Message"] ="Error en el envio del mensaje"+message; }


            return View();
        }
    }
}
