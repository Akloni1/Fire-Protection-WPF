using Amazon.S3;
using FireWPF.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Threading;
using FireWPF.HTTP;

//using static Amazon.RegionEndpoint;

namespace FireWPF
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        private InputUserViewModels _inputModel;
        private HTTPUser _http;
        public Reg()
        {
            InitializeComponent();
            _inputModel = new InputUserViewModels();
            _http = new HTTPUser();
        }

        private async void Button_Reg(object sender, RoutedEventArgs e)
        {
            try
            {
                _inputModel.FirstName = FirstName.Text;
                _inputModel.LastName = LastName.Text;
                _inputModel.MiddleName = MiddleName.Text;
                _inputModel.DateOfBirth = DateTime.ParseExact(DateOfBirth.Text, "yyyy-MM-dd",
                                           System.Globalization.CultureInfo.InvariantCulture);
                _inputModel.Login = Login.Text;
                _inputModel.Password = Password.Password.ToString();
                _inputModel.FirstName = FirstName.Text;
                _http.POST(_inputModel, "https://localhost:44347/user");   
                Frame1.Content = new InputOrReg();
                
            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }
    }
}
