using Newtonsoft.Json;
using System.Collections.Generic;

namespace PhiloiWebApp.JSON_Classes
{

    public class Rootobject
    {
        public Activities[] Property1 { get; set; }
    }

    public class Activities
    {
        public int activityId { get; set; }
        public string name { get; set; }
    }

}


