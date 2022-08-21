using FireWPF.HTTP;
using FireWPF.Models;
using FireWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для Products.xaml
    /// </summary>
    public partial class Products : Page
    {

        private HTTPProduct _http;
        private DataJWT _dataJWT;
        public Products(DataJWT dataJWT)
        {
            InitializeComponent();
            _dataJWT = dataJWT;
            _http = new HTTPProduct(dataJWT.access_token);
            GetProduct_Click();
        }


        void GetProduct_Click()
        {
            var products = _http.GETAll("https://localhost:44347/product");
            list.ItemsSource = products;
            if (_dataJWT.role == "user")
            {
                Del.Visibility = Visibility.Hidden;
                Add.Visibility = Visibility.Hidden;
                Edit.Visibility = Visibility.Hidden;
            }
        }

        void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            try{
                InputProductViewModels product = new InputProductViewModels();
                product.name = Name.Text;
                product.price = Convert.ToDecimal(Price.Text);
                product.description = Description.Text;
                var productAdd = _http.POST(product, "https://localhost:44347/product");
                GetProduct_Click();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Введенные данные не валидны");
            }

        }

        void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {

            var productDelete = _http.DELETE($"https://localhost:44347/product/{Id.Text}");
            GetProduct_Click();
        }


        void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            EditProductViewModels product = new EditProductViewModels();
            product.name = Name.Text;
            product.price = Convert.ToDecimal(Price.Text);
            product.description = Description.Text;
            var productEdit = _http.PUT(product, $"https://localhost:44347/product/{Id.Text}");
            GetProduct_Click();

        }

        
      
    }
}
