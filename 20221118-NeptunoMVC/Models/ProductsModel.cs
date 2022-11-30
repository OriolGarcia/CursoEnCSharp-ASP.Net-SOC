using _20221118_NeptunoMVC.Dal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _20221118_NeptunoMVC.Models
{
	public class ProductsModel
	{
      
            public List<ProductSlim> GetProducts(int categoryId, string search)
            {
                var dbContext = new cifo_OGSContext();

                var products = dbContext.Products
                    .Where(p => (p.CategoryId == categoryId || categoryId == 0) && p.ProductName.Contains(search))
                    .OrderBy(p => p.ProductName)
                    .Select(p => new ProductSlim
                    {
                        ProductId = p.ProductId.ToString(),
                        ProductName = p.ProductName,
                        CategoryName = p.Category.CategoryName,
                        Price = p.UnitPrice,
                        Stock = p.UnitsInStock,
                        State = (p.Discontinued == 0) ? true : false
                    }).ToList();

                return products;
            }

            public string ChangeState(int productId)
            {
                var dbContext = new cifo_OGSContext();

                var product = dbContext.Products.Find(productId);
                product.Discontinued = (product.Discontinued == 0) ? (ulong)1 : (ulong)0;

                dbContext.SaveChanges();

                return (product.Discontinued == 0) ? "Active" : "Discontinued";
            }

            public List<CategorySlim> GetCategories()
            {
                var dbContext = new cifo_OGSContext();
                var categories = dbContext.Categories
                    .OrderBy(c => c.CategoryName)
                    .Select(c => new CategorySlim
                    {
                        CategoryId = c.CategoryId,
                        CategoryName = c.CategoryName,
                    }).ToList();

                return categories;
            }

            public ProductDetail GetProduct(int productId)
            {
                var dbContext = new cifo_OGSContext();

                ProductDetail p = dbContext.Products
                    .Where(p => p.ProductId == productId)
                    .Select(p => new ProductDetail
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        Description = p.QuantityPerUnit,
                        CategoryName = p.Category.CategoryName,
                        Price = p.UnitPrice,
                        Stock = p.UnitsInStock,
                        Sales =
                        (
                            dbContext.OrderDetails
                            .Where(od => od.ProductId == productId)
                            .Sum(od => od.Quantity * od.UnitPrice * (1 - (decimal)od.Discount))
                        )
                    }).First();

                return p;
            }

            public List<OrderDetailExtended> GetHistorico(int productId)
            {
                var dbContext = new cifo_OGSContext();

                var lista = dbContext.OrderDetails
                    .Where(od => od.ProductId == productId)
                    .OrderBy(od => od.OrderId)
                    .Select(od => new OrderDetailExtended
                    {
                        OrderId = od.OrderId,
                        OrderDate = od.Order.OrderDate,
                        CustomerId = od.Order.Customer.CustomerId,
                        CustomerName = od.Order.Customer.CompanyName,
                        EmployeeName = od.Order.Employee.FirstName + " " + od.Order.Employee.LastName,
                        Quantity = od.Quantity,
                        Price = od.UnitPrice,
                        Discount = od.Discount,
                        Amount = od.Quantity * od.UnitPrice * (1 - (decimal)od.Discount)
                    }).ToList();

                return lista;
            }

            public Supplier GetSupplier(int productId)
            {
                var dbContext = new cifo_OGSContext();
                var supplier = dbContext.Products
                    .Where(p => p.ProductId == productId)
                    .Select(s => new Supplier
                    {
                        SupplierId = (int)s.SupplierId,
                        CompanyName = s.Supplier.CompanyName,
                        ContactName = s.Supplier.ContactName,
                        ContactTitle = s.Supplier.ContactTitle,
                        Address = s.Supplier.Address,
                        City = s.Supplier.City,
                        Region = s.Supplier.Region,
                        PostalCode = s.Supplier.PostalCode,
                        Country = s.Supplier.Country,
                        Phone = s.Supplier.Phone,
                        Fax = s.Supplier.Fax,
                        HomePage = s.Supplier.HomePage
                    }).First();

                return supplier;

            }
        }

        public class CategorySlim
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }

        }
        public class ProductSlim
        {
            public  string ProductId { get; set; }
            public string ProductName { get; set; }
            public string CategoryName { get; set; }
            public decimal? Price { get; set; }
            public short? Stock { get; set; }
            public bool State { get; set; }
        }
        public class ProductDetail
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string Description { get; set; }
            public string CategoryName { get; set; }
            public decimal? Price { get; set; }
            public short? Stock { get; set; }
            public decimal? Sales { get; set; }

        }

        public class OrderDetailExtended
        {
            public int OrderId { get; set; }
            public DateTime? OrderDate { get; set; }
            public string CustomerId { get; set; }
            public string CustomerName { get; set; }
            public string EmployeeName { get; set; }
            public int Quantity { get; set; }
            public decimal? Price { get; set; }
            public double Discount { get; set; }
            public decimal? Amount { get; set; }
        }
    }
