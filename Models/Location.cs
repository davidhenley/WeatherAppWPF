namespace WeatherApp.Models
{
    public class LocationArea
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
    }

    public class Location
    {
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public LocationArea Country { get; set; }
        public LocationArea AdministrativeArea { get; set; }
    }
}
