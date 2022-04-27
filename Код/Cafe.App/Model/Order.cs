using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe.App
{
    public partial class Order
    {
        public Order()
        {
            DishOrders = new HashSet<DishOrder>();
        }

        public int Id { get; set; }
        public bool? CookerStatus { get; set; }
        public bool? WaiterStatus { get; set; }
        public int FlunkyId { get; set; }
        public int WaiterId { get; set; }

        public virtual User Flunky { get; set; } = null!;
        public virtual User Waiter { get; set; } = null!;
        public virtual ICollection<DishOrder> DishOrders { get; set; }

        [NotMapped]
        public string CookerStatusName
        {
            get
            {
                if (CookerStatus == true)
                {
                    return ("Готово");
                }
                else
                {
                    return ("Готовится");
                }
            }
        }
        public string WaiterStatusName
        {
            get
            {
                if (WaiterStatus == true)
                {
                    return ("Заказ подан");
                }
                else
                {
                    return ("Ожидает подачи");
                }
            }
        }

    }
}
