using Pract;
using Pract.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Practication.Buttons
{
    public class BaseWindowViewModel : BaseViewModel
    {
        private RelayCommand _Next;

        public static string login;

        private  string _login;
        public  string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                BaseViewModel baseViewModel = new BaseViewModel();
                baseViewModel.OnPropertyChanged();
            }
        }

        public RelayCommand Next
        {

            get
            {
                return _Next ?? (_Next = new RelayCommand(x =>
                {
                    string password = ((PasswordBox)x).Password;
                    gr604_midseContext context = new gr604_midseContext();
                    User? user_ = context.User.FirstOrDefault(p => p.Login == User.Login && p.Password == password);
                    login = User.Login;
                    if (user_ != null)
                    {
                        if (user_.Position == "Официант")
                        {
                            Waiter gw = new Waiter();
                            gw.Show();
                            foreach (var win in App.Current.Windows)
                            {
                                if (win is MainWindow mainWindow)
                                {
                                    mainWindow.Close();
                                }
                            }
                        }
                        else if (user_.Position == "Повар")
                        {
                            Cooker gw = new Cooker();
                            gw.Show();
                            foreach (var win in App.Current.Windows)
                            {
                                if (win is MainWindow mainWindow)
                                {
                                    mainWindow.Close();
                                }
                            }

                        }

                    }
                }));
            }

        }
        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
        private User _user = new User();
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }



}
