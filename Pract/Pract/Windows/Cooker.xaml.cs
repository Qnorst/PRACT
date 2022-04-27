using Pract.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pract.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Cooker : Window
    {
        public Cooker()
        {
            InitializeComponent();
            //DataContext = new CookerViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProductItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
