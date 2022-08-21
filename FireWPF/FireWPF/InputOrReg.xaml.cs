using FireWPF.ViewModels;
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

namespace FireWPF
{
    /// <summary>
    /// Логика взаимодействия для InputOrReg.xaml
    /// </summary>
    public partial class InputOrReg : Page
    {
        private LogOnViewModel _logOnViewModel;
        public InputOrReg()
        {
            InitializeComponent();
            _logOnViewModel = new LogOnViewModel();
        }

        private void Button_Click_Reg(object sender, RoutedEventArgs e)
        {
            Frame1.Content = new Reg();
        }
        private void Button_Click_Input(object sender, RoutedEventArgs e)
        {
            _logOnViewModel.login = Login.Text;
            _logOnViewModel.password = Password.Password.ToString();
             var url = "https://localhost:44347/token";

            var request = WebRequest.Create(url);
            request.Method = "POST";


            var json = System.Text.Json.JsonSerializer.Serialize(_logOnViewModel);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            request.ContentType = "application/json";
          
            request.ContentLength = byteArray.Length;

            var reqStream = request.GetRequestStream();
            reqStream.Write(byteArray, 0, byteArray.Length);
            try
            {
                var response = request.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                var respStream = response.GetResponseStream();

                var reader = new StreamReader(respStream);
                string data = reader.ReadToEnd();
                DataJWT dataJWT = System.Text.Json.JsonSerializer.Deserialize<DataJWT>(data);
                Error.Content = "";
                Frame1.Content = new HomePage(dataJWT);
            }
            catch (WebException ex)
            {
                Error.Content = "Логин или пароль не верны";
                Console.WriteLine(ex.Message);
            }
          //  Console.WriteLine(data);
        }
    }
}
