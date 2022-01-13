using System;
using System.Globalization;
using System.Windows.Data;

namespace WeatherApp.ViewModels.Helpers
{
    public class BoolToRainConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            (bool)value ? "Currently raining" : "Currently not raining";

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            (string)value == "Currently raining";
    }
}
