using Newtonsoft.Json;
using PhiloiWebApp.Models;
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
        
        public async Task<LocationService> GetDistance(User user1,User user2)
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponse = await client.GetAsync($"https://maps.googleapis.com/maps/api/directions/json?origin={user1.Address}&destination={user2.Address}&key={ApiKey.Key}");
            if (httpResponse.IsSuccessStatusCode)
            {
                string json = httpResponse.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<LocationService>(json);
            }
            return null;
        }

    }
}
