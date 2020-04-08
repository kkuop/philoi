using Newtonsoft.Json;
using System.Collections.Generic;

namespace PhiloiWebApp.JSON_Classes
{
    [JsonArray]
    public class RootObject
    {
        public int activityId { get; set; }
        public string name { get; set; }
    }
}


