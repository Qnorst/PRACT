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
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Cafe
{
    public class ApplicationViewModel : MainVM
    {
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
            _user = new User();
            _order = new Order();
            _user.Login = "";
            _user.Password = "";
            _user.Firstname = "";
            _selectedDish = new Dish();
            _orders = new ObservableCollection<Order>(context.Orders);
            _dish = new ObservableCollection<Dish>(context.Dishes);
            
        }

        private Order _order;
        public Order Order
        {
            get => _order;
            set
            {
                _order = value;
                OnPropertyChanged("Order");
            }
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

        //Авторизация
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
                          _user.Role = user.Role;
                          OrderList orderList = new OrderList(this);
                          orderList.Show();
                          foreach (Window item in App.Current.Windows)
                          {
                              if (item.GetType() == typeof(MainWindow))
                              {
                                  item.Close();
                              }
                          }
                      }
                      else
                      {
                          MessageBox.Show("Логин или пароль введён неверно!");
                      }
                  }));
            }
        }
        //Открытие окна добавления
        private RelayCommand _openAdd;
        public RelayCommand OpenAdd
        {
            get
            {
                return _openAdd ?? (_openAdd = new RelayCommand(open =>
                {
                    if (_user.Role)
                    {
                        CafeContext context = new CafeContext();

                        OrderAdd orderAdd = new OrderAdd(this);
                        orderAdd.ShowDialog();
                        Orders = new ObservableCollection<Order>(context.Orders);
                    }
                    else
                    {
                        MessageBox.Show("ВЫ НЕ ГОТОВЫ!!!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }                  
                }));

            }
        }

        //Чекбоксы
        List<Dish> _dishes = new List<Dish>();
        private RelayCommand _checkedCommand;
        public RelayCommand CheckedCommand
        {
            get
            {
                return _checkedCommand ?? (_checkedCommand = new RelayCommand(x =>
                {
                    if (SelectedDish != null)
                    {
                        SelectedDish.IsChecked = !SelectedDish.IsChecked;
                        if (SelectedDish.IsChecked == true)
                        {
                            Dish dublicate = _dishes.FirstOrDefault(x => x == SelectedDish);
                            if (dublicate == null)
                            {

                                _dishes.Add(SelectedDish);
                            }

                        }
                    }

                }));

            }
        }

        //Закрытие добавления
        private RelayCommand _closeAdd;
        public RelayCommand CloseAdd 
        {
            get
            {
                return _closeAdd ?? (_closeAdd = new RelayCommand(close =>
                {                  
                    OrderAdd orderAdd = new OrderAdd(this);
                    foreach (Window item in App.Current.Windows)
                    {
                        if (item.GetType() == typeof(OrderAdd))
                        {
                            item.Close();
                        }
                    }
                }
                ));
            }
        }

        //Добавление заказа
        private RelayCommand _addOrder;
        public RelayCommand AddOrder
        {
            get
            {
                return _addOrder ?? (_addOrder = new RelayCommand(add =>
                {                    
                        CafeContext context = new CafeContext();
                        Order neworder = new Order { CookerStatus = false, WaiterStatus = false };
                        context.Orders.Add(neworder);
                        context.SaveChanges();
                        //context.Database.ExecuteSqlRaw("INSERT INTO Order");
                        var list = context.Orders.ToList();
                        var last = list.LastOrDefault();
                        int idlast = last.Id;
                        foreach (var dish in _dishes)
                        {
                            context.Database.ExecuteSqlRaw($"INSERT INTO OrderDish Values({idlast},{dish.Id})");
                        }                                      
                                                                                
                }));
            }
        }

        //Изменение статуса заказа0
        private RelayCommand _changeorder0;
        public RelayCommand ChangeOrder0
        {
            get
            {
                return _changeorder0 ?? (_changeorder0 = new RelayCommand(open =>
                {
                    if (_user.Role)
                    {
                        CafeContext context = new CafeContext();
                        var order = context.Orders.FirstOrDefault(o => o.Id == _order.Id);
                        if (order != null)
                        {
                            order.WaiterStatus = false;
                            context.SaveChanges();
                            Orders = new ObservableCollection<Order>(context.Orders);

                        }
                    }
                    else
                    {
                        MessageBox.Show("ВЫ НЕ ГОТОВЫ!!!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }));
            }
        }

        private RelayCommand _changeorder1;
        public RelayCommand ChangeOrder1
        {
            get
            {
                return _changeorder1 ?? (_changeorder1 = new RelayCommand(open =>
                {
                    if (_user.Role)
                    {
                        CafeContext context = new CafeContext();
                        var order = context.Orders.FirstOrDefault(o => o.Id == _order.Id);
                        if (order != null)
                        {
                            Order = order;
                            order.WaiterStatus = true;
                            context.SaveChanges();
                            Orders = new ObservableCollection<Order>(context.Orders);

                        }
                    }
                    else
                    {
                        MessageBox.Show("ВЫ НЕ ГОТОВЫ!!!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }));

            }
        }

        //изменение статуса блюд      
        private RelayCommand _changedish0;
        public RelayCommand ChangeDish0
        {
            get
            {
                return _changedish0 ?? (_changedish0 = new RelayCommand(open =>
                {
                    if (_user.Role == false)
                    {
                        CafeContext context = new CafeContext();

                        var order = context.Orders.FirstOrDefault(o => o.Id == _order.Id);
                        if (order != null)
                        {
                            Order = order;
                            order.CookerStatus = false;
                            context.SaveChanges();
                            Orders = new ObservableCollection<Order>(context.Orders);

                        }                        
                    }
                    else
                    {
                        MessageBox.Show("ВЫ НЕ ГОТОВЫ!!!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }));

            }
        }
        private RelayCommand _changedish1;
        public RelayCommand ChangeDish1
        {
            get
            {
                return _changedish1 ?? (_changedish1 = new RelayCommand(open =>
                {
                    if (_user.Role == false)
                    {
                        CafeContext context = new CafeContext();

                        var order = context.Orders.FirstOrDefault(o => o.Id == _order.Id);
                        if (order != null)
                        {
                            Order = order;
                            order.CookerStatus = true;
                            context.SaveChanges();
                            Orders = new ObservableCollection<Order>(context.Orders);

                        }
                    }
                    else
                    {
                        MessageBox.Show("ВЫ НЕ ГОТОВЫ!!!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }));

            }
        }
    }
}
