using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using XtramileSolutionsTask2.Controllers;
using XtramileSolutionsTask2.Interfaces;
using XtramileSolutionsTask2.Models;
using Xunit;

namespace xtramiletask2_web_api_test
{
    public class WeatherControllerTest
    {
        private readonly WeatherController _controller;
        private readonly IWeatherService _service;

        public WeatherControllerTest()
        {
            _service = new WeatherServiceFake();
            _controller = new WeatherController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<string>(okResult as string);
        }

        [Fact]
        public void Get_WhenCalled_Countries_ReturnsAllDataCountry()
        {
            // Act
            var okResult = _controller.GetCounties();
            // Assert
            var items = Assert.IsType<List<Country>>(okResult);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void Get_WhenCalled_Cities_ReturnsAllFilterByCountry_AU()
        {
            // Act
            var okResult = _controller.GetCitieByCountyCode("AU");
            // Assert
            var items = Assert.IsType<List<City>>(okResult);
            Assert.Equal(4, items.Count);
        }


        [Fact]
        public void Get_WhenCalled_Cities_ReturnsAllFilterByCountry_ID()
        {
            // Act
            var okResult = _controller.GetCitieByCountyCode("ID");
            // Assert
            var items = Assert.IsType<List<City>>(okResult);
            Assert.Equal(4, items.Count);
        }

        [Fact]
        public void Get_WhenCalled_Weather_ReturnsWeatherData()
        {
            // Act
            var okResult = _controller.GetCityWeather("ID", "Jakarta");
            // Assert
            var items = Assert.IsType<Weather>(okResult);
            Assert.Equal("Jakarta", items.location);
            Assert.NotNull(okResult);
        }

        [Fact]
        public void Get_WhenCalled_Weather_ReturnsNullData()
        {
            // Act
            var okResult = _controller.GetCityWeather("ID", "Malang");
            // Assert
            Assert.Null(okResult);
        }

    }
}
