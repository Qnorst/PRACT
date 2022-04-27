using System;
using System.Collections.Generic;

namespace Pract
{
    public partial class Product
    {
        public Product()
        {
            LotsOfs = new HashSet<LotsOf>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Pay { get; set; }
        public TimeSpan Time { get; set; }

        public virtual ICollection<LotsOf> LotsOfs { get; set; }
    }
}
