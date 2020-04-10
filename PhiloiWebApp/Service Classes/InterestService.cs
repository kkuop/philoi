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
        public async Task<Fandoms[]> GetFandoms()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:44376/api/fandoms");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var listOfFandoms = JsonConvert.DeserializeObject<Fandoms[]>(json);
                return listOfFandoms;
            }
            return null;
        }
        public async Task<Movies[]> GetMovies()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:44376/api/movies");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var listOfMovies = JsonConvert.DeserializeObject<Movies[]>(json);
                return listOfMovies;
            }
            return null;
        }
        public async Task<Music[]> GetMusic()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:44376/api/music");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var listOfMusic = JsonConvert.DeserializeObject<Music[]>(json);
                return listOfMusic;
            }
            return null;
        }
        public async Task<Sports[]> GetSports()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:44376/api/sports");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var listOfSports = JsonConvert.DeserializeObject<Sports[]>(json);
                return listOfSports;
            }
            return null;
        }
    }
}
