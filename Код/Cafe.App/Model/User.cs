using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe.App
{
    public partial class User : MainVM
    {
        public User()
        {
            OrderFlunkies = new HashSet<Order>();
            OrderWaiters = new HashSet<Order>();
        }

        private int _id;
        public int Id { get { return _id; } set { _id = value; OnPropertyChanged("Id"); } }

        private string? _first_name;
        public string? FirstName { get { return _first_name; } set { _first_name = value; OnPropertyChanged("FirstName"); } }

        private string? _last_name;
        public string? LastName { get { return _last_name; } set { _last_name = value; OnPropertyChanged("LastName"); } }

        private string? _second_name;
        public string? SecondName { get { return _second_name; } set { _second_name = value; OnPropertyChanged("SecondName"); } }

        private string? _login;
        public string? Login { get { return _login; } set { _login = value; OnPropertyChanged("Login"); } }

        private string? _password;
        public string? Password { get { return _password; } set { _password = value; OnPropertyChanged("Password"); } }

        private bool? _role;
        public bool? Role { get { return _role; } set { _role = value; OnPropertyChanged("Role"); } }

        public virtual ICollection<Order> OrderFlunkies { get; set; }
        public virtual ICollection<Order> OrderWaiters { get; set; }

        [NotMapped]
        public string RoleName
        {
            get
            {
                if (Role == true)
                {
                    return "Официант";
                }
                else
                {
                    return "Повар";
                }
            }
        }
    }
}
