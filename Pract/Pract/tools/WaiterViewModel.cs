using Microsoft.EntityFrameworkCore;
using Practication;
using Practication.Buttons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pract.tools
{
    internal class WaiterViewModel : BaseViewModel
    {
        private ObservableCollection<Order> _orders;
        private Order _order;
        private StatusCooker _waite;
        private int _count;
        private Product _producted;
        private ObservableCollection<LotsOf> _reserve = new ObservableCollection<LotsOf>();
        private ObservableCollection<StatusWaiter> _waites;
        private ObservableCollection<Product> _products;
        private ObservableCollection<Order> _payments;
        private RelayCommand _izmenik;
        private Order _lotsof;
        private RelayCommand _addposition;
        private RelayCommand _createorder;

        
        public Order Order
        {
            get => _order;
            set
            {
                _order = value;
                OnPropertyChanged();
            }
        }
        public int Count
        {
            get => _count; set
            {

                _count = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddPosition
        {
            get
            {
                return _addposition ??
                    (_addposition = new RelayCommand(x =>
                    {
                        if (_count != 0)
                        {
                            _reserve.Add(new LotsOf() { ProductId = _producted.ProductId, Product = _producted, Count = _count });
                        }
                        else
                        {
                            MessageBox.Show("укажи количество");
                        }
                    }
                    ));
            }
        }
        public RelayCommand CreateOrder
        {
            get
            {
                return _createorder ??
                    (_createorder = new RelayCommand(x =>

                    {
                        Order order = new Order();
                        foreach(var item in _reserve)
                        {
                            order.Payment += item.Product.Pay * item.Count;
                        }
                        
                        order.Data = DateTime.Now;
                        order.LotsOfs = new List<LotsOf>(_reserve.Select(x => new LotsOf() { ProductId = x.ProductId }));
                        gr604_midseContext context = new gr604_midseContext();
                        order.WorkerId = context.User.FirstOrDefault(x => x.Login == BaseWindowViewModel.login).WorkerId;
                        order.StatusWaiterId = 2;
                        order.StatusCookerId = 2;
                        order.LotsOfs = new List<LotsOf>(_reserve.Select(x => new LotsOf() { ProductId = x.ProductId, Count = x.Count })).ToList();
                        context.Order.Add(order);
                        context.SaveChanges();

                        _orders.Clear();
                        _orders = new ObservableCollection<Order>(context.Order.Include(x=>x.LotsOfs).ThenInclude(x=>x.Product));
                        OnPropertyChanged(nameof(Orders));
                        _reserve.Clear();
                    }
                    ));
            }
        }

        public Product Producted
        {
            get => _producted;
            set
            {
                _producted = value;
                OnPropertyChanged();
            }
        }
        public Order LotsOf
        {
            get => _lotsof; set
            {
                _lotsof = value;
                OnPropertyChanged();
            }
        }
        public StatusCooker Waite
        {
            get => _waite; set
            {
                _waite = value;
                OnPropertyChanged();
            }
        }
        public new RelayCommand Izmenik
        {
            get
            {
                return _izmenik ?? (_izmenik = new RelayCommand(
                    x =>
                    {
                        gr604_midseContext db = new gr604_midseContext();
                        var order = db.Order.FirstOrDefault(el => el.OrderId == LotsOf.OrderId);
                        var statuses = db.StatusWaiter.ToList();
                        var status = statuses.FirstOrDefault(x => x.StatusPaymentOrder == LotsOf.StatusWaiter.StatusPaymentOrder);
                        order.StatusWaiterId = status.StatusWaiterId;
                        db.SaveChanges();
                    }));
            }
        }
        public ObservableCollection<StatusWaiter> Waites
        {
            get => _waites;
            set
            {
                _waites = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Order> Payments
        {
            get => _payments;
            set
            {
                _payments = value;
                OnPropertyChanged();
            }
        }
        public WaiterViewModel()
        {
            gr604_midseContext gr604_MidseContext = new gr604_midseContext();
            Orders = new ObservableCollection<Order>(gr604_MidseContext.Order);
            Waites = new ObservableCollection<StatusWaiter>(gr604_MidseContext.StatusWaiter);
            Products = new ObservableCollection<Product>(gr604_MidseContext.Product);
            
        }
    }
}

