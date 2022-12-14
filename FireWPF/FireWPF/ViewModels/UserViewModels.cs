using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireWPF.ViewModels
{
    internal class UserViewModels
    {
        public int idUser { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public string login { get; set; }
        public string role { get; set; }
    }
}
