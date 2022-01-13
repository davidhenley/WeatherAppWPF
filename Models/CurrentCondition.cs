using System;

namespace WeatherApp.Models
{
    public class UnitData
    {
        public double Value { get; set; }
    }

    public class Temperature
    {
        public UnitData Imperial { get; set; }
    }

    public class CurrentCondition
    {
        public string WeatherText { get; set; }
        public bool HasPrecipitation { get; set; }
        public Temperature Temperature { get; set; }
    }
}
