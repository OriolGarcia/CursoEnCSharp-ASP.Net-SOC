using System.Collections.Generic;

namespace APINeptuno.Models
{
    public class OrderExtended
    {
        public List<OrderDetailExtended> Lista { get; set; }
        public decimal? Amount { get; set; }
    }
}
