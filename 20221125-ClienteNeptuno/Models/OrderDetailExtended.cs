

namespace APINeptuno.Models
{
    public class OrderDetailExtended
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public double Discount { get; set; }
        public decimal Amount { get; set; }
       
    }
}

