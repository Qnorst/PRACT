using System;
using System.Collections.Generic;

namespace Pract
{
    public partial class LotsOf
    {
        public int LotsOfId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
