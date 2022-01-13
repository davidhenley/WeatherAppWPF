using PropertyChanged;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WeatherApp.Models;
using WeatherApp.ViewModels.Helpers;

namespace WeatherApp.ViewModels
{
    public class WeatherVM : BindableBase
    {
        public string Query { get; set; }

        public CurrentCondition CurrentConditions { get; set; }

        public Location SelectedLocation { get; set; }

        public RelayCommand SearchCommand { get; }

        public ObservableCollection<Location> Locations { get; private set; } = new();

        public WeatherVM()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()) == true)
            {
                SelectedLocation = new Location { LocalizedName = "Nashville" };
                CurrentConditions = new CurrentCondition { WeatherText = "Overcast", Temperature = new Temperature { Imperial = new UnitData { Value = 20 } } };
            }

            SearchCommand = new RelayCommand(Search, () => !string.IsNullOrWhiteSpace(Query));
        }

        public void OnSelectedLocationChanged(Location _, Location newValue)
        {
            if (newValue != null) GetConditions(newValue.Key);
        }

        public void OnQueryChanged()
        {
            SearchCommand?.RaiseCanExecuteChanged();
        }

        public async void Search()
        {
            if (string.IsNullOrWhiteSpace(Query)) return;

            var locations = await AccuWeatherHelper.GetCitiesAsync(Query);

            Locations.Clear();
            foreach (var location in locations)
            {
                Locations.Add(location);
            }         
        }

        public async void GetConditions(string key)
        {
            Query = string.Empty;
            Locations.Clear();

            var conditions = await AccuWeatherHelper.GetCurrentConditions(key);

            CurrentConditions = conditions;
        }
    }
}
