using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using XtramileSolutionsTask2.Interfaces;
using XtramileSolutionsTask2.Models;

namespace XtramileSolutionsTask2.Services
{
    public class WeatherService : IWeatherService 
    {
        public WeatherService() { 
        }

        public IEnumerable<Country> CountriesData()
        {
            List<Country> countries = new List<Country>();

            using (StreamReader r = new StreamReader("data/countries.json"))
            {
                string json = r.ReadToEnd();
                countries = JsonSerializer.Deserialize<IList<Country>>(json).ToList();

                if (!countries.Any()) return null;
            }

            return countries;
        }

        public IEnumerable<City> CityDataByCountryCode(string code)
        {
            var cities = new List<City>();
            var minCities = new List<City>();

            using (StreamReader r = new StreamReader("data/cities.json"))
            {
                string json = r.ReadToEnd();
                cities = JsonSerializer.Deserialize<IList<City>>(json).Where(a => a.country.Equals(code)).ToList();
                
                if (cities.Any())
                {
                    if (cities.Count > 7)
                    {
                        minCities = cities.Take(7).ToList();
                    } else
                    {
                        minCities = cities;
                    }

                    if (!minCities.Any()) return new List<City>();

                    int seqNumber = 0;
                    foreach (City city in minCities)
                    {
                        seqNumber++;
                        city.Id = seqNumber;
                    }
                } else
                {
                    return new List<City>();
                }

            }

            return minCities;
        }

        public Weather WeatherDataByCity(string code, string city)
        {
            var weather = new Weather();
            using (StreamReader r = new StreamReader("data/weather.json"))
            {
                string json = r.ReadToEnd();
                weather = JsonSerializer.Deserialize<IList<Weather>>(json).FirstOrDefault(a=>a.country.Equals(code) && a.location.Equals(city));
                if (weather == null) return new Weather();
            }

            return weather;
        }
    }
}
