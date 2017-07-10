using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dependency_Injection_MVC.Models;
using System.Web.Mvc;

namespace Dependency_Injection_MVC.Infrastructure
{
    public static class IocConfigurator
    {
        public static void ConfigureIocUnityContainer()
        {
            IUnityContainer container = new UnityContainer();
            registerServices(container);
            DependencyResolver.SetResolver(new DIUnityDependencyResolver(container));
        }

        private static void registerServices(IUnityContainer container)
        {
            container.RegisterType<IWeatherForecastServiceProvider, WeatherForecast>();
            container.RegisterType<IFaceBookConfigurationManager, FacebookConfigurationManager>(
                new InjectionConstructor(
                    //Injecting dependencies through InjectionConstructor
                    System.Configuration.ConfigurationManager.AppSettings["Username"],
                    System.Configuration.ConfigurationManager.AppSettings["AuthenticationToken"],
                    System.Configuration.ConfigurationManager.AppSettings["FacebookUrl"]

                    )
                );
        }
    }
}