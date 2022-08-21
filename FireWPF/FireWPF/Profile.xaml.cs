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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        private DataJWT _dataJWT;
        private HTTPUser _http;
        public Profile(DataJWT dataJWT)
        {
            InitializeComponent();
            _dataJWT = dataJWT;
            _http = new HTTPUser();
            SetDateUser();
        }

        void SetDateUser()
        {
            UserViewModels userViewModels = new UserViewModels();
            userViewModels = _http.GetUserByLogin($"https://localhost:44347/user/getbylogin?Login={_dataJWT.username}", _dataJWT.access_token);
            FirstName.Text = userViewModels.firstName;
            LastName.Text = userViewModels.lastName;
            MidName.Text = userViewModels.middleName;
            Role.Text = userViewModels.role;
            Login.Text = userViewModels.login;

        }
    }
}
