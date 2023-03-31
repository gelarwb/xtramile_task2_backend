using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XtramileSolutionsTask2.Interfaces;
using XtramileSolutionsTask2.Models;

namespace xtramiletask2_web_api_test
{
    public class WeatherServiceFake: IWeatherService
    {
        private readonly List<Country> _country;
        private readonly List<City> _city;
        private readonly List<Weather> _weather;

        public WeatherServiceFake()
        {
            _country = new List<Country>()
            {
                new Country() {name = "Indonesia", code = "ID"},
                new Country() {name = "Australia", code = "AU"},
            };

            _city = new List<City>()
            {
                new City() { country = "ID", lat="", lng="", name="Bandung"},
                new City() { country = "ID", lat="", lng="", name="jakarta"},
                new City() { country = "ID", lat="", lng="", name="Surabaya"},
                new City() { country = "ID", lat="", lng="", name="Denpasar"},
                new City() { country = "AU", lat="", lng="", name="Sydney"},
                new City() { country = "AU", lat="", lng="", name="Melbourne"},
                new City() { country = "AU", lat="", lng="", name="Brisbane"},
                new City() { country = "AU", lat="", lng="", name="Darwin"}
            };

            _weather = new List<Weather>()
            {
                new Weather() {country = "ID", location = "Jakarta", time = "Now", wind = "11", visibility = "5", sky_conditions = "cloud", temperature_celcius = "26", temperature_fahrenheit = "78", dew_point = "25", relative_humidity = "93%", pressure = "1015 mbar"},
            };

        }

        IEnumerable<Country> IWeatherService.CountriesData()
        {
            return _country;
        }

        IEnumerable<City> IWeatherService.CityDataByCountryCode(string code)
        {
            return _city.Where(a => a.country.Equals(code));
        }

        Weather IWeatherService.WeatherDataByCity(string code, string city)
        {
            return _weather.FirstOrDefault(a => a.country.Equals(code) && a.location.Equals(city));
        }
    }
}
