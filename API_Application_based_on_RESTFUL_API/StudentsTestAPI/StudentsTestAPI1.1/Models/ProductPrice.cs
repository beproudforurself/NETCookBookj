using System;
using System.Collections.Generic;

namespace StudentsTestAPI1._1.Models
{
    public partial class ProductPrice
    {
        public string ID { get; set; } = null!;
        public string? Product { get; set; }
        public long? Price { get; set; }
    }
}
