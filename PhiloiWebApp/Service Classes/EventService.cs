using Newtonsoft.Json;
using PhiloiWebApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhiloiWebApp.Service_Classes
{
    public class EventService : IEventService
    {
        public EventService()
        {

        }

        public async Task<EventService> GetEvents()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://www.eventbriteapi.com/v3?token={ApiKey.EventbriteKey}");
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<EventService>(json);
            }
            return null;
        }
    }
}
