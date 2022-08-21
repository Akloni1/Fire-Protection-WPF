using FireWPF.Models;
using FireWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FireWPF.HTTP
{
    internal class HTTPProduct
    {
        private string _token;
        public HTTPProduct(string token)
        {

            _token = token;
        }
        public List<Product> GETAll(string url)
        {


            var request = WebRequest.Create(url);
            request.Method = "GET";
            request.Headers.Add("Authorization", "Bearer " + _token);
            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            List<Product> productViewModels = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(data);
            return productViewModels;
        }


        public decimal GETCost(string url)
        {

            try
            {
                var request = WebRequest.Create(url);
                request.Method = "GET";
                request.Headers.Add("Authorization", "Bearer " + _token);

                var webResponse = request.GetResponse();


            
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            decimal productViewModels = System.Text.Json.JsonSerializer.Deserialize<decimal>(data);
            return productViewModels;
            }
            catch (WebException ex)
            {
                MessageBox.Show("Введенные данные не валидны");
            }
            return 0;
        }

        public Product DELETE(string url)
        {
            var request = WebRequest.Create(url);
            request.Method = "DELETE";
            request.Headers.Add("Authorization", "Bearer " + _token);
            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            Product productViewModels = System.Text.Json.JsonSerializer.Deserialize<Product>(data);
            return productViewModels;
        }
        public Product POST(InputProductViewModels inputModel, string url)
        {


            var request = WebRequest.Create(url);
            request.Method = "POST";


            var json = System.Text.Json.JsonSerializer.Serialize(inputModel);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            request.ContentType = "application/json";
            request.Headers.Add("Authorization", "Bearer " + _token);

            request.ContentLength = byteArray.Length;

            var reqStream = request.GetRequestStream();
            reqStream.Write(byteArray, 0, byteArray.Length);

            var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            var respStream = response.GetResponseStream();

            var reader = new StreamReader(respStream);
            string data = reader.ReadToEnd();
            Product product = System.Text.Json.JsonSerializer.Deserialize<Product>(data);
            return product;
        }

        public Product PUT(InputProductViewModels inputModel, string url)
        {


            var request = WebRequest.Create(url);
            request.Method = "PUT";


            var json = System.Text.Json.JsonSerializer.Serialize(inputModel);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            request.ContentType = "application/json";
            request.Headers.Add("Authorization", "Bearer " + _token);
            request.ContentLength = byteArray.Length;

            var reqStream = request.GetRequestStream();
            reqStream.Write(byteArray, 0, byteArray.Length);

            var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            var respStream = response.GetResponseStream();

            var reader = new StreamReader(respStream);
            string data = reader.ReadToEnd();
            Product product = System.Text.Json.JsonSerializer.Deserialize<Product>(data);
            return product;
        }
    }
}
