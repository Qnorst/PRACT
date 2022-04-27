using System;
using System.Collections.Generic;

namespace Pract
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int WorkerId { get; set; }
        public string Name { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Position { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
