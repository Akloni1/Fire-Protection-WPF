using FireWPF.HTTP;
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
    /// Логика взаимодействия для Cost.xaml
    /// </summary>
    public partial class Cost : Page
    {
        DataJWT _dataJWT;
        HTTPProduct _http;
        public Cost(DataJWT dataJWT)
        {
            InitializeComponent();
            _http = new HTTPProduct(dataJWT.access_token);
            _dataJWT = dataJWT;
        }

        private void Button_Cost(object sender, RoutedEventArgs e)
        {
            var cost = _http.GETCost($"https://localhost:44347/product/cost?id={id.Text}&km={km.Text}");
            ResCost.Text = cost.ToString()+" Руб";
            Console.WriteLine();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
