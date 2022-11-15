using System;
using System.Collections.Generic;

namespace _20221108_EntityFrameworkCore.Models
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
