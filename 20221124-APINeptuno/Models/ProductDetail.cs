namespace APINeptuno.Models
{
    public class ProductDetail
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string SuplierName { get; set; }
        public decimal? Price { get; set; }
        public short? Stock { get; set; }
        public bool State { get; set; }
    }
}
