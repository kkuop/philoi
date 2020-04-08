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
        public async Task<Activities[]> GetActivities()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:44376/api/activities");
            if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var listOfInterests = JsonConvert.DeserializeObject<Activities[]>(json);
                return listOfInterests;
            }
            return null;
        }
    }
}
