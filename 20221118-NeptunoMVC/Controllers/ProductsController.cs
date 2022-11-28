using _20221118_NeptunoMVC.Dal;
using _20221118_NeptunoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
namespace _20221118_NeptunoMVC.Controllers
{
    public class ProductsController : Controller
    {
        

            public IActionResult Index(int CategoryId = 0, string search = "")
            {
                //TO_DO
                //Recoger parámetros del listado
                //Parámetro CategoryId
                //Parámetro texto libre

                //Protección
                if (search == null) search = "";

                ProductsModel pm = new ProductsModel();

                //Preparar los objetos del filtro
                //Desplegable categorías
                var categories = pm.GetCategories();
                ViewData["cmbCategorias"] = "<select id='cmbCategorias'>";
                ViewData["cmbCategorias"] += "<option value='0'>All</option>";
                foreach (var item in categories)
                {
                    ViewData["cmbCategorias"] +=
                        "<option value='" + item.CategoryId + "'" +
                        ((item.CategoryId == CategoryId) ? " selected " : "") +
                        ">" + item.CategoryName + "</option>";
                }
                ViewData["cmbCategorias"] += "</select>";


                //Caja de texto
                ViewData["txtTexto"] = "<input type='text' " +
                                    "id='txtSearch' value='" + search + "' />";


                var lista = pm.GetProducts(CategoryId, search);

                ViewData["products"] = lista;

                return View();
            }

            public IActionResult Detail(int ProductId = 0)
            {
                //TO_DO
                ProductsModel pm = new ProductsModel();
                var product = pm.GetProduct(ProductId);

                //Preparar ViewData
                ViewData["imagen"] = "";
                string nombreImagen = ProductId + "lr.jpg";
                string nombreImagenHR = ProductId + "hr.jpg";
                var path = (string)AppDomain.CurrentDomain.GetData("WebRootPath") +
                                "wwwroot\\images\\products\\" + nombreImagen;

                if (System.IO.File.Exists(path))
                {
                    ViewData["imagen"] = "<a href='/images/products/" + nombreImagenHR + "' " +
                            "data-lightbox='image-" + ProductId + "' data-title='" + product.ProductName + "'> " +
                                    "<img src='/images/products/" + nombreImagen + "' width='100%' />" +
                                "</a>";
                }
                else
                {
                    ViewData["imagen"] = "<img src='/images/sinImagen.jpg' width='100%' />";
                }

                ViewData["nombreProducto"] = product.ProductName;
                ViewData["precio"] = ((decimal)product.Price).ToString("N2") + " €";
                ViewData["descripcion"] = product.Description;
                ViewData["categoria"] = product.CategoryName;
                ViewData["ventas"] = ((decimal)product.Sales).ToString("N2") + " €";
                ViewData["ProductId"] = ProductId;

                //Stock
                int? stock = product.Stock;
                if (stock > 20)
                {
                    ViewData["stock"] = "<i class='fa fa-battery-full' aria-hidden='true' style='color:green;font-size:1.5em;' title='high'></i>";
                }
                else if (stock > 10)
                {
                    ViewData["stock"] = "<i class='fa fa-battery-2' aria-hidden='true' style='color:cyan;font-size:1.5em;' title='medium'></i>";
                }
                else if (stock > 0)
                {
                    ViewData["stock"] = "<i class='fa fa-battery-1' aria-hidden='true' style='color:orange;font-size:1.5em;' title='low'></i>";
                }
                else
                {
                    ViewData["stock"] = "<i class='fa fa-battery-empty' aria-hidden='true' style='color:red;font-size:1.5em;' title='no stock'></i>";
                }

                return View();
            }


            //Ajax
            public string ChangeState(int productId)
            {
                ProductsModel pm = new ProductsModel();
                var resp = pm.ChangeState(productId);

                return resp;
            }

            public string GetHistorico(int productId)
            {
                string result = "";

                //TO_DO
                ProductsModel pm = new ProductsModel();
                var historico = pm.GetHistorico(productId);

                result = @"<div class='table-responsive'>
                        <table class='table table-bordered table-striped'>
                        <tr>
                            <th>OrderId</th>
                            <th>Fecha</th>
                            <th>Cliente</th>
                            <th>Empleado</th>
                            <th>Cantidad</th>
                            <th>Precio</th>
                            <th>Descuento</th>
                            <th>Importe</th>
                        </tr>";

                decimal? total = 0;
                foreach (var item in historico)
                {
                    result += "<tr>";
                    result += "<td>" + item.OrderId + "</td>";
                    result += "<td>" + ((DateTime)item.OrderDate).ToShortDateString() + "</td>";
                    result += "<td><a href='/Customer/Detail?CustomerId=" + item.CustomerId + "'>" + item.CustomerName + "</a></td>";
                    result += "<td>" + item.EmployeeName + "</td>";
                    result += "<td>" + item.Quantity + "</td>";
                    result += "<td>" + ((decimal)item.Price).ToString("N2") + "</td>";
                    result += "<td>" + item.Discount + "</td>";
                    result += "<td>" + ((decimal)item.Amount).ToString("N2") + "</td>";
                    result += "</tr>";

                    total += item.Amount;
                }

                //Fila de totales
                result += "<tr>";
                result += "<td colspan='7' style='text-align:right; font-weight:bold;'>TOTAL: </td>";
                result += "<td style='font-weight:bold; font-size:1.25em;'>" + ((decimal)total).ToString("N2") + "</td>";
                result += "</tr>";

                result += "</table></div>";

                return result;
            }

            public string GetSupplier(int productId)
            {
                ProductsModel pm = new ProductsModel();
                var supplier = pm.GetSupplier(productId);

                string resp = "<table class='table'><tr><td><b>Empresa: </b></td><td>" + supplier.SupplierId + " - " + supplier.CompanyName + "</td></tr> " +
                    "<tr><td><b>Contacto: </b></td><td>" + supplier.ContactName + "</td></tr>" +
                    "<tr><td><b>Cargo: </b></td><td>" + supplier.ContactTitle +
                    "<tr><td><b>Dirección: </b></td><td>" + supplier.Address + ", (" + supplier.PostalCode + ") " + supplier.City + ", " + supplier.Country + "</td></tr>" +
                    "<tr><td><b>Contacto: </b></td><td>" + supplier.Phone + " - " + supplier.HomePage + "</td></tr></table>";

                return resp;
            }

        }
    }
