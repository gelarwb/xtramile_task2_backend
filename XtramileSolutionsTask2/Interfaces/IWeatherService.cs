using System.Collections.Generic;
using XtramileSolutionsTask2.Models;

namespace XtramileSolutionsTask2.Interfaces
{
    public interface IWeatherService
    {
        IEnumerable<Country> CountriesData();
        IEnumerable<City> CityDataByCountryCode(string code);
        Weather WeatherDataByCity(string code, string city);
    }
}
