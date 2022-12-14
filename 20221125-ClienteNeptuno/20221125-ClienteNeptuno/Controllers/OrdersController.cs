using _20221125_ClienteNeptuno.Filters;
using _20221125_ClienteNeptuno.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Utils;
using static System.Net.Mime.MediaTypeNames;
using ClosedXML.Excel;
using Syncfusion.XlsIO;
using Syncfusion.XlsIORenderer;
using Syncfusion.Pdf;

namespace _20221125_ClienteNeptuno.Controllers
{
    public class OrdersController : Controller
    {
        private IOrdersService service;
        public OrdersController(IOrdersService _service)
        {
            service = _service;
        }

        //[SessionFilter]
        //[ResponseCache(Duration = 120)]
        [OutputCache(Duration = 120)]
        public async Task<IActionResult> Index()
        {
            //Protección de entrada
            if (HttpContext.Session.GetString("UserId") == null)
            {
                //Logout. Invalidar session
                UtilsWeb.InvalidarSession(HttpContext);

                //Guardar la redirección
                HttpContext.Session.SetString("Redirect", "/Orders/Index");

                //Ir a login
                return RedirectToAction("Login", "Users");
            }


            //Proceso general
            var orders = await service.GetPedidos();
            return View(orders);
        }


        public async Task<IActionResult> IndexDatatable()
        {
            //Protección de entrada
            if (HttpContext.Session.GetString("UserId") == null)
            {
                //Logout. Invalidar session
                UtilsWeb.InvalidarSession(HttpContext);

                //Guardar la redirección
                HttpContext.Session.SetString("Redirect", "/Orders/IndexDatatable");

                //Ir a login
                return RedirectToAction("Login", "Users");
            }

            //Proceso general
            var orders = await service.GetPedidos();
            return View(orders);

        }

        public IActionResult IndexDatatableSS()
        {
            //Protección de entrada
            if (HttpContext.Session.GetString("UserId") == null)
            {
                //Logout. Invalidar session
                UtilsWeb.InvalidarSession(HttpContext);

                //Guardar la redirección
                HttpContext.Session.SetString("Redirect", "/Orders/IndexDatatableSS");

                //Ir a login
                return RedirectToAction("Login", "Users");
            }

            return View();
        }


        public async Task<IActionResult> LoadDataOrders()
        {
            //Recuperaremos todos los parámetros que nos pasará el datatable
            //Parámetros de: filtrado, paginado, búsqueda,...
            int skip = int.Parse(HttpContext.Request.Form["start"].ToString());   //Paginado
            int pageSize = int.Parse(HttpContext.Request.Form["length"].ToString());  //Showing

            //Captura de columna a ordenar y orden 
            string sortColumn = HttpContext.Request.Form["columns[" +
                HttpContext.Request.Form["order[0][column]"].ToString() + "][name]"].ToString();
            string sortColumnDir = HttpContext.Request.Form["order[0][dir]"].ToString();

            string search = HttpContext.Request.Form["search[value]"][0];

            //Llamada al service pasando los parámetros
            var resp = await service.GetPedidos(skip, pageSize, sortColumn, sortColumnDir, search);

            var orders = resp.Data;
            int recordsTotal = resp.RecordsCount;

            return Json(new
            {
                //...
                recordsFiltered = recordsTotal,
                recordsTotal = recordsTotal,
                data = orders
            });
        }

        //Ajax
        [ResponseCache(Duration = 120, VaryByQueryKeys = new[] { "orderId" })]
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

                tableHTML += "<td><span id='tooltip_" + orderId + "_" + item.ProductId + "' title='Ficha del producto:\r\n" + item.ProductName +
                                                                 "\r\n" + item.CategoryName +
                                                                 "\r\n" + item.SupplierName +
                                                                 "\r\n" + item.Price +
                                                                 "\r\n" + item.Stock +
                                                                 "\r\n" + ((item.State) ? "Activo" : "Desactivado") +
                                                                 "' onmouseover='adjustColor(" + orderId + "," + item.ProductId + ");'>" + item.ProductName + "</span></td>";

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
        public IActionResult EditExcel(int orderId)
        {

            if (HttpContext.Session.GetString("UserId") == null)
            {
                //Logout. Invalidar session
                UtilsWeb.InvalidarSession(HttpContext);

                //Guardar la redirección
                HttpContext.Session.SetString("Redirect", "/Orders/EditExcel?orderId="+orderId);

                //Ir a login
                return RedirectToAction("Login", "Users");
            }

            ViewData["File"] = "order-" + orderId + ".xlsx";
            return View();
        }
            public async Task<string> GetExcel(int orderId)
            {
                var pedido = await service.GetExcel(orderId);

                //Construir el Excel
                //A partir de la plantilla de pedidos (order.xslx)
                string origen = (string)AppDomain.CurrentDomain.GetData("WebRootPath")
                    + "wwwroot\\templates\\order.xlsx";
                string destino = (string)AppDomain.CurrentDomain.GetData("WebRootPath")
                    + "wwwroot\\orders\\order-" + orderId + ".xlsx";
                System.IO.File.Copy(origen, destino, true);

                //Abrir el fichero de excel generado
                var book = new XLWorkbook(destino);
                var sheet = book.Worksheet(1);

                //Customer
                sheet.Cell(3, 2).Value = pedido.Customer.Nombre;
                sheet.Cell(4, 2).Value = pedido.Customer.Direccion;
                sheet.Cell(5, 2).Value = pedido.Customer.Ciudad;
                sheet.Cell(6, 2).Value = pedido.Customer.Pais;

                //Order
                sheet.Cell(3, 7).Value = pedido.Order.OrderId;
                sheet.Cell(4, 7).Value = ((DateTime)pedido.Order.OrderDate).ToShortDateString();
                sheet.Cell(5, 7).Value = pedido.Order.Vendedor;

                //Details
                int contador = 0;
                foreach (var item in pedido.Details)
                {
                    contador++;

                    sheet.Cell(8 + contador, 1).Value = item.Cantidad;
                    sheet.Cell(8 + contador, 2).Value = item.Producto;
                    sheet.Cell(8 + contador, 6).Value = item.Precio.ToString("N2");
                    sheet.Cell(8 + contador, 7).Value = item.Descuento;
                    sheet.Cell(8 + contador, 8).Value = item.Importe.ToString("N2");
                }

                //Totals
                sheet.Cell(47, 8).Value = pedido.Totals.Subtotal.ToString("N2");
                sheet.Cell(48, 8).Value = ((decimal)pedido.Totals.CostesLogisticos).ToString("N2");
                sheet.Cell(49, 8).Value = ((decimal)pedido.Totals.Total).ToString("N2");


                //Guardar el fichero Excel
                book.Save();

                //Retornar el nombre del fichero Excel generado
                return "order-" + orderId + ".xlsx";
            }

            public async Task<string> GetPdf(int orderId)
            {
                //Generar el Excel, por si acaso no estaba generado
                string ficheroExcel = await GetExcel(orderId);
                string pathFicheroExcel = (string)AppDomain.CurrentDomain.GetData("ContentRootPath") +
                    "wwwroot\\orders\\" + ficheroExcel;

                //Nombre del PDF a generar y su path
                string ficheroPdf = "pdf-" + orderId + ".pdf";
                string pathFicheroPdf = (string)AppDomain.CurrentDomain.GetData("ContentRootPath") +
                    "wwwroot\\pdfs\\" + ficheroPdf;

                //Generación del PDF
                try
                {
                    //ConversorExcelToPDf obj = new ConversorExcelToPDf();
                    //obj.Save(pathFicheroExcel, pathFicheroPdf);

                    ExcelEngine excelEngine = new ExcelEngine();
                    IApplication application = excelEngine.Excel;
                    application.EnablePartialTrustCode = true;

                    //Renderizador del PDF a partir del Excel
                    XlsIORenderer renderer = new XlsIORenderer();

                    //Convertimos el fichero Excel en un stream a procesar
                    Stream fileStream = new FileStream(pathFicheroExcel, FileMode.Open, FileAccess.Read);
                    fileStream.Position = 0;

                    //Loads file stream into Word document
                    IWorkbook workbook = application.Workbooks.Open(fileStream);

                    //Intialize the PdfDocument Class
                    PdfDocument pdfDoc = new PdfDocument();

                    //Intialize the ExcelToPdfConverterSettings class
                    XlsIORendererSettings settings = new XlsIORendererSettings();
                    settings.IsConvertBlankPage = false;

                    //PDF sin escalar, a tamaño normal
                    settings.LayoutOptions = LayoutOptions.NoScaling;

                    //Assign the output PdfDocument to the TemplateDocument property of ExcelToPdfConverterSettings 
                    settings.TemplateDocument = pdfDoc;
                    settings.DisplayGridLines = GridLinesDisplayStyle.Invisible;

                    //Convert the Excel document to PDf
                    pdfDoc = renderer.ConvertToPDF(workbook, settings);
                    fileStream.Dispose();

                    //Cargar documento PDF generado en memoria a un stream de memoria
                    //que luego lo guardaremos a disco
                    MemoryStream stream = new MemoryStream();
                    pdfDoc.Save(stream);

                    try
                    {
                        using (FileStream file = new FileStream(pathFicheroPdf,
                            FileMode.Create, FileAccess.Write))
                        {
                            stream.Position = 0;
                            stream.CopyTo(file);

                            stream.Flush();
                            stream.Close();
                            stream.Dispose();
                        }
                    }
                    catch (Exception err)
                    {

                    }
                }
                catch (Exception err)
                {

                }

                //Retornando el nombre del fichero PDF generado
                return ficheroPdf;
            }
        }
    }



    