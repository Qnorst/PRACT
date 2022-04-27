using System;
using System.Collections.Generic;

namespace Cafe.App
{
    public partial class Dish : MainVM
    {
        public Dish()
        {
            DishOrders = new HashSet<DishOrder>();
        }

        private int _id;
        public int Id { get { return _id; } set { _id = value; OnPropertyChanged("Id"); } }

        private string _name;
        public string? Title { get { return _name; } set { _name = value; OnPropertyChanged("Title"); } }

        private decimal? _price;
        public decimal? Price { get { return _price; } set { _price = value; OnPropertyChanged("Price"); } }

        private decimal? _time;
        public decimal? Time { get { return _time; } set { _time = value; OnPropertyChanged("Time"); } }

        public virtual ICollection<DishOrder> DishOrders { get; set; }
    }
}
