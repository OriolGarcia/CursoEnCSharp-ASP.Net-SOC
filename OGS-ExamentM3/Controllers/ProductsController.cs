using Microsoft.AspNetCore.Mvc;
using OGS_ExamentM3.Models;

namespace OGS_ExamentM3.Controllers
{
    public class ProductsController : Controller
    {


        public IActionResult Index()
        {
            //TO_DO
            //Recoger parámetros del listado
            //Parámetro CategoryId
            //Parámetro texto libre

            //Protección
           

            ProductsModel pm = new ProductsModel();

            //Preparar los objetos del filtro
            //Desplegable categorías

            var lista = pm.GetProducts();
           
            ViewData["products"] = lista;

            return View();
        }
        }
    }
