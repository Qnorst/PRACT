using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Practication;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pract.tools
{
    public class CookerViewModel : BaseViewModel
    {
        private ObservableCollection<Order> _orders;
        private StatusCooker _cook;
        private ObservableCollection<StatusCooker> _cooks;
        private RelayCommand _izmena;
        private Order _lotsof;
        public Order LotsOf
        {
            get => _lotsof; set
            {
                _lotsof = value;
                OnPropertyChanged();
            }
        }
        public StatusCooker Cook
        {
            get => _cook; set
            {
                _cook = value;
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
        public ObservableCollection<StatusCooker> Cooks
        {
            get => _cooks;
            set
            {
                _cooks = value;
                OnPropertyChanged();
            }
        }
        public new RelayCommand Izmena
        {
            get
            {
                return _izmena ?? (_izmena = new RelayCommand(
                    x =>
                    {
                        gr604_midseContext db = new gr604_midseContext();
                        var order = db.Order.FirstOrDefault(el => el.OrderId == LotsOf.OrderId);
                        var statuses = db.StatusCooker.ToList();
                        var status = statuses.FirstOrDefault(x => x.StatusCook == LotsOf.StatusCooker.StatusCook);
                        order.StatusCookerId = status.StatusCookerId;
                        db.SaveChanges();
                    }));
            }
        }

        public CookerViewModel()
        {
            gr604_midseContext gr604_MidseContext = new gr604_midseContext();
            Orders = new ObservableCollection<Order>(gr604_MidseContext.Order);
            Cooks = new ObservableCollection<StatusCooker>(gr604_MidseContext.StatusCooker);
        }
    }
}
