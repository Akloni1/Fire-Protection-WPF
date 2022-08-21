using FireWPF.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FireWPF
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private DataJWT _dataJWT;
        public HomePage(DataJWT dataJWT)
        {
            InitializeComponent();
            _dataJWT = dataJWT;
        }
      
        private void Button_Products(object sender, RoutedEventArgs e)
        {
            Frame1.Content = new Products(_dataJWT);
        }
        private void Button_User(object sender, RoutedEventArgs e)
        {
            Frame1.Content = new Profile(_dataJWT);
        }
        private void Button_Cost(object sender, RoutedEventArgs e)
        {
            Frame1.Content = new Cost(_dataJWT);
        }
    }
}
