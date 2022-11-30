using _20221125_ClienteNeptuno.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _20221125_ClienteNeptuno.Controllers
{
    public class OrdersController : Controller
    {
        private IOrdersService service;
        public OrdersController(IOrdersService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await service.GetPedidos();
            return View(orders);
        }

        //Ajax
        public async Task<string> ViewDetail(int orderId)
        {
            var orderExtended = await service.GetDetails(orderId);

            var detalles = orderExtended.Lista;
            var amount = orderExtended.Amount;

            //Montar la tabla HTML
            string tableHTML = "";
            tableHTML = @"<table class='table table-bordered'>
                            <tr>
                                <th>Cantidad</th>
                                <th>Producto</th>
                                <th>Precio</th>
                                <th>Descuento</th>
                                <th>Importe</th>
                            </tr>";

            foreach (var item in detalles)
            {
                tableHTML += "<tr>";
                tableHTML += "<td>" + item.Quantity + "</td>";

                tableHTML += "<td><span id='tooltip_"+ orderId +"_" + item.ProductId + "' title='Ficha del producto:\r\n"+ item.ProductName +
                                                                 "\r\n"+ item.CategoryName +
                                                                 "\r\n" + item.SupplierName +
                                                                 "\r\n" + item.Price +
                                                                 "\r\n" + item.Stock +
                                                                 "\r\n" + ((item.State)?"Activo":"Desactivado") +
                                                                 "' onmouseover='adjustColor("+ orderId + "," + item.ProductId + ");'>" + item.ProductName + "</span></td>";
          
                tableHTML += "<td>" + item.UnitPrice.ToString("N2") + "</td>";
                tableHTML += "<td>" + item.Discount + "</td>";
                tableHTML += "<td>" + item.Amount.ToString("N2") + "</td>";
                tableHTML += "</tr>";
            }

            //Amount
            tableHTML += "<tr>";
            tableHTML += "<td colspan='4' style='text-align:right;'>TOTAL:</td>";
            tableHTML += "<td>" + ((decimal)amount).ToString("N2") + "</td>";
            tableHTML += "</tr>";

            tableHTML += "</table>";
            
            return tableHTML;

        }

       
    }
}
