using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using Cafe.App;

namespace Cafe
{
    public class ApplicationViewModel : MainVM
    {
        private Visibility _waiter_visibility;
        public Visibility WaiterVisibility
        {
            get { return _waiter_visibility; }
            set
            {
                _waiter_visibility = value;
                OnPropertyChanged("WaiterVisibility");
            }
        }

        private Visibility _flunky_visibility;
        public Visibility FlunkyVisibility
        {
            get { return _flunky_visibility; }
            set
            {
                _flunky_visibility = value;
                OnPropertyChanged("WaiterVisibility");
            }
        }
        private User _user;
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }
        private Dish _selectedDish;
        public Dish SelectedDish
        {
            get => _selectedDish;
            set
            {
                _selectedDish = value;
                OnPropertyChanged("Dish");
            }
        }
        public ApplicationViewModel()
        {
            CafeContext context = new CafeContext();
            _flunky_visibility = Visibility.Visible;
            _waiter_visibility = Visibility.Visible;
            _user = new User();
            _user.Login = "";
            _user.Password = "";
            _user.FirstName = "";
            _selectedDish = new Dish();
            _orders = new ObservableCollection<Order>(context.Orders);
            _dish = new ObservableCollection<Dish>(context.Dishes);
            _dish_order = new ObservableCollection<DishOrder>(context.DishOrders);
        }

        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged("Orders");
            }
        }

        private ObservableCollection<Dish> _dish;
        public ObservableCollection<Dish> Dish
        {
            get => _dish;
            set
            {
                _dish = value;
                OnPropertyChanged("Dish");
            }
        }
        private ObservableCollection<DishOrder> _dish_order;

        public ObservableCollection<DishOrder> DishOrder
        {
            get => _dish_order;
            set
            {
                _dish_order = value;
                OnPropertyChanged("DishOrder");
            }
        }
        //
        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand ??
                (_loginCommand = new RelayCommand(password =>
                {
                    _user.Password = (password as PasswordBox).Password;

                    CafeContext context = new CafeContext();
                    var user = context.Users.SingleOrDefault(x => x.Login == _user.Login && x.Password == _user.Password);
                    if (user != null)
                    {
                        User = user;
                        if (User.Role==true)
                        {
                            FlunkyVisibility = Visibility.Collapsed;
                        }
                        else
                        {
                            WaiterVisibility = Visibility.Collapsed;
                        }
                        OrderList orderList = new OrderList(this);
                        orderList.Show();
                        foreach (Window item in Application.Current.Windows)
                        {
                            if (item.GetType() == typeof(MainWindow))
                            {
                                item.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Логин или пароль введён неверно");
                    }
                }));
            }
        }

