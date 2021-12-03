using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.WpfApp.Utils
{
    public class HttpClientSample
    {
        public static readonly HttpClient Client;
        static HttpClientSample()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44302/api/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
