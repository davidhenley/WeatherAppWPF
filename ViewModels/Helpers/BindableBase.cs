using System.ComponentModel;

namespace WeatherApp.ViewModels.Helpers
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
