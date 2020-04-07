namespace PhiloiWebApp.JSON_Classes
{

    public class Interest
    {
        public Interests[] Property1 { get; set; }
    }

    public class Interests
    {
        public int activityId { get; set; }
        public string name { get; set; }
    }
}


