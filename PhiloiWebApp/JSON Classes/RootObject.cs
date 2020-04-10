using Newtonsoft.Json;
using System.Collections.Generic;

namespace PhiloiWebApp.JSON_Classes
{

    public class Rootobject
    {
        public Activities[] Property1 { get; set; }
        public Fandoms[] Property2 { get; set; }
        public Movies[] Property3 { get; set; }
        public Music[] Property4 { get; set; }
        public Sports[] Property5 { get; set; }
    }

    public class Activities
    {
        public int activityId { get; set; }
        public string name { get; set; }
    }
    public class Fandoms
    {
        public int fandomId { get; set; }
        public string name { get; set; }
    }
    public class Movies
    {
        public int movieId { get; set; }
        public string name { get; set; }
    }
    public class Music
    {
        public int musicId { get; set; }
        public string name { get; set; }
    }
    public class Sports
    {
        public int sportId { get; set; }
        public string name { get; set; }
    }
}


