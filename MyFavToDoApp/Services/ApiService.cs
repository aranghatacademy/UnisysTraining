using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyFavToDoApp.Services
{
    public static class ApiService
    {
        private static readonly HttpClient _httpClient;

        public static HttpClient Http
        {
            get
            {
                return _httpClient;
            }
        }

        static ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5000/");
        }


    }
}
