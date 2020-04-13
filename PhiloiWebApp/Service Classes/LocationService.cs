using Newtonsoft.Json;
using PhiloiWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PhiloiWebApp.JSON_Classes;

namespace PhiloiWebApp.Service_Classes
{
    public class LocationService
    {
        

        public LocationService()
        {
            //THis WAS For TESTING Purposes
            //User user1 = new User();
            //User user2 = new User();
            //user1.Address = "3718 n 7th st, Milwaukee, Wi";
            //user2.Address = "4845 n Sherman blvd, Milwauke, WI";
            //var range = GetDistance(user1, user2);
        }

        public async Task<DirectionsJson.Rootobject> GetDistance(User user1, User user2)
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponse = await client.GetAsync($"https://maps.googleapis.com/maps/api/directions/json?origin={user1.Address}&destination={user2.Address}&key={ApiKey.GoogleKey}");
            if (httpResponse.IsSuccessStatusCode)
            {
                string json = httpResponse.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<DirectionsJson.Rootobject>(json);
            }
            return null;
        }

        public async Task<CoordsJson> GetUserCoords(User user)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://maps.googleapis.com/maps/api/geocode/json?address={user.ZipCode},US&sensor=false&key={ApiKey.GoogleKey}");
            if(response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<CoordsJson>(json);
            }
            return null;
        }
    }
}

