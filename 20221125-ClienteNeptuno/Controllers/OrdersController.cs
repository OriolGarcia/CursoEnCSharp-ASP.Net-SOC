using _20221125_ClienteNeptuno.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _20221125_ClienteNeptuno.Controllers
{
    public class OrdersController : Controller
    {

        private IOrdersService service;
        public OrdersController(IOrdersService _service)
        {
            this.service = _service;
        }

        public async Task<IActionResult> Index()
        {



            var orders = await service.GetPedidos();
            return View(orders);
        }

        //AJAX

        public async Task<string> ViewDetail(int orderId)
        {
            var orderExtended = await service.GetDetails(orderId);

            var detalles = orderExtended.Lista;
            var amount = orderExtended.Amount;



            string tableHTML = @"<table class ='table teble-bordered'>
                    <tr>
                         <th>Cantidad</th>
                         <th> Producto</th>
                         <th>Precio</th>
                         <th> Descuento</th>
                         <th>Importe</th>
                    </tr>";
            foreach (var detalle in detalles)
            {
                tableHTML += "<tr>";
                tableHTML += "<td>" + detalle.Quantity + "</td>";
                tableHTML += "<td>" + detalle.ProductName + "</td>";
                tableHTML += "<td>" + ((decimal)detalle.UnitPrice).ToString("N2") + "</td>";
                tableHTML += "<td>" + detalle.Discount + "</td>";
                tableHTML += "<td>" + ((decimal)detalle.Amount).ToString("N2") + "</td>";
                tableHTML += "</tr>";
            }

            tableHTML += "<tr>";
            tableHTML += "<td colspan='4' style='text-align:right;'>TOTAL:</td>";
            tableHTML += "<td>" + ((decimal)amount).ToString("N2")+ "</td>";
            tableHTML += "</tr>";
            tableHTML += "</table>";

            return tableHTML;
        }
    }
}
