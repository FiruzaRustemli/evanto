using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace Evanto.Web.Vendor.Services
{
    public static class Service
    {

        public static async Task<string> Get(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Properties.Settings.Default.baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(url);
                string data = await response.Content.ReadAsStringAsync();
                return data;
            }
        }

        public static async Task<string> Post(string url, object model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Properties.Settings.Default.baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.Unicode, "application/json");
                // HTTP POST
                var response = await client.PostAsync(url, content);
                string data = await response.Content.ReadAsStringAsync();
                return data;
            }
        }
    }
}