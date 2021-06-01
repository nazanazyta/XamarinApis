using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamarinApis.Models;

namespace XamarinApis.Services
{
    public class ServiceCoches
    {
        private String url;

        public ServiceCoches()
        {
            this.url = "https://apicochespaco.azurewebsites.net/";
        }

        public async Task<List<Coche>> GetCochesAsync()
        {
            String request = "webresources/coches";
            Uri uri = new Uri(this.url + request);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                String data = await response.Content.ReadAsStringAsync();
                List<Coche> coches = JsonConvert.DeserializeObject<List<Coche>>(data);
                return coches;
            }
            else
            {
                return null;
            }
        }
    }
}
