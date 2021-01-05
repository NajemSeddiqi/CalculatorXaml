using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.ViewModels.Helpers
{
    public class AccuWeatherHelper
    {
        private const string BASE_URL = "http://dataservice.accuweather.com/";
        private const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        private const string CURRENT_CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";
        private const string API_KEY = "hqLwbrAA1QTV6gtFVCGH56S4O95e6z10";

        public static async Task<List<City>> GetCities(string query)
        {
            var cities = new List<City>();
            var url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, query);

            using (var client = new HttpClient())
            {
                var res = await client.GetAsync(url);
                var json = await res.Content.ReadAsStringAsync();
                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }

        public static async Task<CurrentConditions> GetCurrentConditions(string cityId)
        {
            var currentConditions = new CurrentConditions();
            var url = BASE_URL + string.Format(CURRENT_CONDITIONS_ENDPOINT, cityId, API_KEY);

            using (var client = new HttpClient())
            {
                var res = await client.GetAsync(url);
                var json = await res.Content.ReadAsStringAsync();
                currentConditions = (JsonConvert.DeserializeObject<List<CurrentConditions>>(json)).FirstOrDefault();
            }

            return currentConditions;
        }
    }
}
