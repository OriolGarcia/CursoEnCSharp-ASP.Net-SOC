using static System.Net.Mime.MediaTypeNames;

namespace APINeptuno.Models
{
    public class ProductDetail
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public decimal? Price { get; set; }
        public short? Stock { get; set; }
        public bool State { get; set; }
    }
}
