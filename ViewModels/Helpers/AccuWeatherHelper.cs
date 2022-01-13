using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public static class AccuWeatherHelper
    {
        private const string ApiKey = "tMvLfBOiD78iSGGNhyEOv9dHVwjwGLc5";
        private const string AccuweatherBaseUrl = "http://dataservice.accuweather.com";
        private const string AutocompleteUrl = $"{AccuweatherBaseUrl}/locations/v1/cities/autocomplete";
        private const string ConditionsUrl = $"{AccuweatherBaseUrl}/currentconditions/v1";

        private static string GetAutocompleteUrl(string query) => $"{AutocompleteUrl}?apikey={ApiKey}&q={query}";
        private static string GetConditionsUrl(string cityKey) => $"{ConditionsUrl}/{cityKey}?apikey={ApiKey}";

        public static async Task<List<Location>> GetCitiesAsync(string query)
        {
            using var client = new HttpClient();

            return await client.GetFromJsonAsync<List<Location>>(GetAutocompleteUrl(query));
        }

        public static async Task<CurrentCondition> GetCurrentConditions(string cityKey)
        {
            using var client = new HttpClient();

            var conditionsList = await client.GetFromJsonAsync<List<CurrentCondition>>(GetConditionsUrl(cityKey));
            var condition = conditionsList.FirstOrDefault();

            return condition;
        }
    }
}
