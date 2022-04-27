using System;
using System.Collections.Generic;

namespace Pract
{
    public partial class StatusWaiter
    {
        public StatusWaiter()
        {
            Orders = new HashSet<Order>();
        }

        public int StatusWaiterId { get; set; }
        public string StatusPaymentOrder { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
