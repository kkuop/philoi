using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhiloiWebApp.Service_Classes
{
    public class LocationService
    {
        public LocationService() 
        {
        
        
        }
        public async Task<LocationService> GetLocation() 
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"");
            if(response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject < LocationService >(json);
            }
            return null;
        
        
        
        
        }
            public async T





    }
}
