using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using XtramileSolutionsTask2.Models;
using XtramileSolutionsTask2.Services;
using XtramileSolutionsTask2.Interfaces;

namespace XtramileSolutionsTask2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService weatherService;
        //private readonly ILogger<WeatherController> _logger;

        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }


        [HttpGet]
        public string Get()
        {
            return "Wather API";
        }


        [HttpGet]
        [Route("countries/")]
        public IEnumerable<Country> GetCounties()
        {
            var resultList  = weatherService.CountriesData();
            return resultList;
        }


        [HttpGet]
        [Route("country/{code}")]
        public IEnumerable<City> GetCitieByCountyCode(string code)
        {
            if (string.IsNullOrEmpty(code)) return null;

            var resultCities = new List<City>();
            var result = weatherService.CityDataByCountryCode(code).ToList();
            if (result == null) return null;
            if (result.Any())
            {
                resultCities = result;
            }

            return resultCities;
        }

        [HttpGet]
        [Route("city/{code}/{city}")]
        public Weather GetCityWeather(string code, string city)
        {
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(city)) return null;
            var weatherData = new Weather();
            var result = weatherService.WeatherDataByCity(code, city);
            if (result == null) return null;
            return result;
        }
    }
}
