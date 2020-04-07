using Newtonsoft.Json;
using PhiloiWebApp.Contracts;
using PhiloiWebApp.JSON_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhiloiWebApp.Service_Classes
{
    public class InterestService : IInterestService
    {
        public InterestService()
        {

        }
        public async Task<Interest> GetInterest()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:44376/api/activities");
            if(response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Interest>(json);
            }
            return null;
        }
    }
}
