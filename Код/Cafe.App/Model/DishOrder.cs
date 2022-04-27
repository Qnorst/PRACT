using System;
using System.Collections.Generic;

namespace Cafe.App
{
    public partial class DishOrder
    {
        public int DishId { get; set; }
        public int OrderId { get; set; }
        public int Id { get; set; }

        public virtual Dish Dish { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
