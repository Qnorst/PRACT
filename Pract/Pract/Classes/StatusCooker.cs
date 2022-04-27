using System;
using System.Collections.Generic;

namespace Pract
{
    public partial class StatusCooker
    {
        public StatusCooker()
        {
            Orders = new HashSet<Order>();
        }

        public int StatusCookerId { get; set; }
        public string StatusCook { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }

    }
}
