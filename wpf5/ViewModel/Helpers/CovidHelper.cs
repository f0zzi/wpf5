using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using wpf5.Model;

namespace wpf5.ViewModel.Helpers
{
    class CovidHelper
    {
        public const string URL = "https://api.covid19api.com/summary";
        public static async Task<Info> GetInfo()
        {
            Info info = new Info();

            using (HttpClient http = new HttpClient())
            {
                var response = await http.GetAsync(URL);
                string json = await response.Content.ReadAsStringAsync();
                info = JsonConvert.DeserializeObject<Info>(json);
            }
            return info;
        }
    }
}
