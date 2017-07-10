using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dependency_Injection_MVC.Models;

namespace Dependency_Injection_MVC.Controllers
{
    public class HomeController : Controller
    {
        /* Promblem :
         The problem with the below approach for injecting service in the
         the home controlller is that a home controller is not responsible 
         for creating the object of WeatherForecast class as it voilates
         the concept of SRP(Single Responsibility Principle) and we should
         invert the object creation to some other class as per Inversion
         of control principle 
        */
        //private IWeatherForecastServiceProvider _weatherForecastServiceProvider; 
        //public HomeController()
        //{
        //    _weatherForecastServiceProvider = new WeatherForecast();//Dependency for our controller
        //}

        /* Solution
         The Solution to the above problem can be removing the object ceation work
         in Home Controller
        */

        private IWeatherForecastServiceProvider _weatherForecastServiceProvider;
        private IFaceBookConfigurationManager _faceBookConfigurationManager;
        public HomeController(IWeatherForecastServiceProvider weatherForecastServiceProvider,
            IFaceBookConfigurationManager faceBookConfigurationManager)
        {
            _weatherForecastServiceProvider = weatherForecastServiceProvider;
            _faceBookConfigurationManager = faceBookConfigurationManager;
        }

        /*
         The problem with the above solution is that the dependent object is not created 
         and will result in error if we execute the code AND 
         the Solution to the above problem is to use UNITY Container ,
         So after Implementing UNITY Containe the above code will work
        */



        // GET: Home
        public ActionResult Index()
        {
            if (_faceBookConfigurationManager.Authenticate())
            {
                ViewBag.Weather = _weatherForecastServiceProvider.GetForeCastByZipCode("201301");
            }
      
            return View();
        }
    }
}