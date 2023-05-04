using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace WpfAppAPI
{
    public class NetManager
    {
        public static String URL = "http://localhost:64096/";
        public static HttpClient httpClient = new HttpClient();


        public static async Task<T> Get<T>(String controller)
        {
            var response = await httpClient.GetAsync(URL + controller);
            var data = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            return data;
        }

        public static async Task<HttpResponseMessage> Post<T>(String controller, T data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var response = await httpClient.PostAsync(URL + controller, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            return response;
        }

        public static async Task<HttpResponseMessage> Put<T>(String controller, T data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var response = await httpClient.PutAsync(URL + controller, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            return response;

        }

        public static async Task<HttpResponseMessage> Delete<T>(String controller)
        {
            var response = await httpClient.DeleteAsync(URL + controller);
            return response;
        }
    }
}
