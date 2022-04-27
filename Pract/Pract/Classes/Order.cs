using System;
using System.Collections.Generic;

namespace Pract
{
    public partial class Order
    {
        public Order()
        {
            LotsOfs = new HashSet<LotsOf>();
        }

        public int OrderId { get; set; }
        public int LotsOfId { get; set; }
        public int WorkerId { get; set; }
        public decimal Payment { get; set; }
        public int StatusWaiterId { get; set; }
        public int StatusCookerId { get; set; }
        public DateTime Data { get; set; }

        public virtual StatusCooker StatusCooker { get; set; } 
        public virtual StatusWaiter StatusWaiter { get; set; } 
        public virtual User Worker { get; set; } = null!;
        public virtual ICollection<LotsOf> LotsOfs { get; set; }
    }
}
