using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireWPF.Models
{
    internal class Product
    {
        public int idProduct { get; set; }
        public string name { get; set; }
        public decimal? price { get; set; }
        public string description { get; set; }
        public override string ToString()
        {
            return name + "   |   "+ price +"      |    "+ description;
        }
    }
}
