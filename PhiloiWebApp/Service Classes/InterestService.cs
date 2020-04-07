﻿using Newtonsoft.Json;
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
        public async Task<InterestJson> GetActivities()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:44376/api/activities");
            if(response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<InterestJson> listOfInterests = JsonConvert.DeserializeObject<List<InterestJson>>(json);
                //return listOfInterests;
            }
            return null;
        }
    }
}
