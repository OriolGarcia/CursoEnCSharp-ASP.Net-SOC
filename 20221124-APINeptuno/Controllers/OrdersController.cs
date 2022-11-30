using _20221124_APINeptuno.Dal;
using APINeptuno.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _20221124_APINeptuno.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        [Route("pedidos")]
        public List<PedidoExtended> GetPedidos()
        {
            var dbContext = new cifo_OGSContext();
            var pedidos = dbContext.OrderDetails.OrderBy(o => o.Order.OrderDate)
                .GroupBy(od=> new  {
                    OrderId = od.OrderId,
                    OrderDate=od.Order.OrderDate,
                    CustomerName =od.Order.Customer.CompanyName,
                    EmployeeName = od.Order.Employee.FirstName + " " + od.Order.Employee.LastName,
                    ShipperName = od.Order.ShipViaNavigation.CompanyName,
                    Freight =od.Order.Freight
                }).Select(g=>new PedidoExtended
                {
                    OrderId = g.Key.OrderId,
                    OrderDate = g.Key.OrderDate,
                    CustomerName = g.Key.CustomerName,
                    EmployeeName = g.Key.EmployeeName,
                    ShipperName = g.Key.ShipperName,
                    Freight = g.Key.Freight,
                    Amount=g.Sum(d=>d.Quantity*d.UnitPrice+(1-(decimal)d.Discount)    )

                })
                .ToList();
            return pedidos;

        }
        [HttpGet]
        [Route("pedido")]
        public OrderExtended GetDetallePedido(int orderId)
        {
            OrderExtended oe=new OrderExtended();

            var dbContext = new cifo_OGSContext();
            List<OrderDetailExtended> orderDetails = dbContext.OrderDetails.Where(od=>od.OrderId== orderId).OrderBy(o => o.Order.OrderDate)
                .Select(od => new OrderDetailExtended
                {
                    
                    ProductId = od.ProductId,
                    ProductName=od.Product.ProductName,

                    CategoryName=od.Product.Category.CategoryName,
                    SuplierName=od.Product.Supplier.CompanyName,
                    Price=od.Product.UnitPrice,
                    Stock=od.Product.UnitsInStock,
                    State=(od.Product.Discontinued==0)?true:false,
                    Quantity=od.Quantity,
                    UnitPrice=od.UnitPrice,
                    Discount=od.Discount,
                    Amount =  od.Quantity * od.UnitPrice + (1 - (decimal)od.Discount)
                }).OrderBy(p=> p.ProductName).ToList();

            oe.Lista = orderDetails;

            var amount = dbContext.OrderDetails.Where(od => od.OrderId == orderId).Sum(d => d.Quantity * d.UnitPrice + (1 - (decimal)d.Discount));
              oe.Amount = amount;  
                
                return oe;
        }
        [HttpGet]
        [Route("producto")]
        public ProductDetail GetProducto(int productId)
        {
            var dbContext = new cifo_OGSContext();
            var product= dbContext.Products.Where(p=> p.ProductId== productId).Select(p=> new ProductDetail
            { ProductId=p.ProductId,
            ProductName= p.ProductName,
            CategoryName=p.Category.CategoryName,
            SuplierName=p.Supplier.CompanyName,
            Price=p.UnitPrice,
            Stock=p.UnitsInStock,
            State=(p.Discontinued==0)? true:false
            }).First();

            return product;

        }
    }
}
