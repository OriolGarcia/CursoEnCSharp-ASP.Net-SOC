using _20221125_ClienteNeptuno.Filters;
using _20221125_ClienteNeptuno.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _20221125_ClienteNeptuno.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
      //  [SessionFilter]
        public IActionResult Index()
        {

            
            return View();
        }
        //   [SessionFilter]
        [ResponseCache(Duration = 900)]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Mail()
        {
            //Protocolo envi emails en ASP.Core
            var email= new MimeMessage();
            email.From.Add(MailboxAddress.Parse("envios@cifo.serprisa.net"));
            email.To.Add(MailboxAddress.Parse("ogs1017@gmail.com"));
            email.Subject = "Test de Email";
            email.Body = new TextPart(TextFormat.Html)
            {
                Text="<h1> Exemple de mail</h1>  <p> paràgraf</p>"
            };


            //Envio de email

            var client =new SmtpClient();
            //Servidor que lo envia
            try
            {
                client.Connect("mail.cifo.serprisa.net", 587, SecureSocketOptions.StartTls);
                client.Authenticate("envios@cifo.serprisa.net", "Cifo2022$");
                client.Send(email);
                client.Disconnect(true);
                ViewData["Mensaje"] = "El email ha sido enviado correctamente.";

                    }
            catch (Exception err) {
                ViewData["Mensaje"] = "Ha habido un error en el envio del email." + err.Message ;
            };
            return View();
        }
    }
}
