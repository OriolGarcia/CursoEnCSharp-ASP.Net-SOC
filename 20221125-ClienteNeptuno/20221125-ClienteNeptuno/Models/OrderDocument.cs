using System.Collections.Generic;
using System;

namespace _20221125_ClienteNeptuno.Models
{
    public class OrderDocument
    {
        public CustomerDocument Customer { get; set; }
        public OrderInfo Order { get; set; }
        public List<DetailsDocument> Details { get; set; }
        public TotalDocument Totals { get; set; }
    }

    public class CustomerDocument
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
    }

    public class OrderInfo
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Vendedor { get; set; }
    }

    public class DetailsDocument
    {
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public double Descuento { get; set; }
        public decimal Importe { get; set; }
    }

    public class TotalDocument
    {
        public decimal Subtotal { get; set; }
        public decimal? CostesLogisticos { get; set; }
        public decimal? Total { get; set; }
    }

}
