using FireWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FireWPF.HTTP
{
    internal class HTTPUser
    {
        
        public void POST(InputUserViewModels inputModel, string url)
        {
            // var url = "https://localhost:44347/user";

            var request = WebRequest.Create(url);
            request.Method = "POST";


            var json = System.Text.Json.JsonSerializer.Serialize(inputModel);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            var reqStream = request.GetRequestStream();
            reqStream.Write(byteArray, 0, byteArray.Length);

            var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            var respStream = response.GetResponseStream();

            var reader = new StreamReader(respStream);
            string data = reader.ReadToEnd();
            Console.WriteLine(data);
        }

        public List<UserViewModels> GETAll(string url)
        {
            //  var url = "https://localhost:44347/user";

            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            List<UserViewModels> userViewModel = System.Text.Json.JsonSerializer.Deserialize<List<UserViewModels>>(data);
            return userViewModel;
        }



        public UserViewModels GetUserByLogin(string url, string _token)
        {
           

            var request = WebRequest.Create(url);
            request.Method = "GET";
            request.Headers.Add("Authorization", "Bearer " + _token);
            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            UserViewModels userViewModel = System.Text.Json.JsonSerializer.Deserialize<UserViewModels>(data);
            return userViewModel;
        }
    }
}