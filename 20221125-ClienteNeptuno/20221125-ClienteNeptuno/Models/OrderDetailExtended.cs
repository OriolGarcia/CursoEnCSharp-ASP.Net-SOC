namespace APINeptuno.Models
{
    public class OrderDetailExtended
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        //Nuevas propiedades
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public decimal? Price { get; set; }
        public short? Stock { get; set; }
        public bool State { get; set; }

        //Fin nuevas

        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public double Discount { get; set; }
        public decimal Amount { get; set; }

    }
}
