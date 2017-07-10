using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dependency_Injection_MVC.Models
{
    public  interface IWeatherForecastServiceProvider
    {
        string GetForeCastByZipCode(string ZipCode);
    }
    public class WeatherForecast : IWeatherForecastServiceProvider
    {
        public string GetForeCastByZipCode(string ZipCode)
        {
            return "Current Weather in your city is Sunny with ZipCode :" + ZipCode;
        }
    }
}