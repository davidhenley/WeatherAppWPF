namespace WeatherApp.Models
{
    public class LocationArea
    {
        public string LocalizedName { get; set; }
    }

    public class Location
    {
        public string Key { get; set; }
        public string LocalizedName { get; set; }
        public LocationArea AdministrativeArea { get; set; }
    }
}
