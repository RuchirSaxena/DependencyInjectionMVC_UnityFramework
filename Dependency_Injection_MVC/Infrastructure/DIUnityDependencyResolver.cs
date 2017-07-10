using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace Dependency_Injection_MVC.Infrastructure
{
    internal class DIUnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _unityContainer;

        public DIUnityDependencyResolver(IUnityContainer unityContainer)
        {
           _unityContainer = unityContainer;
        }

        public object GetService(Type serviceType)
        {
            try
            {

                return _unityContainer.Resolve(serviceType);
            }catch(Exception ex)
            {
                return null;
            }
            
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {

                return _unityContainer.ResolveAll(serviceType);
            }
            catch (Exception ex)
            {
                return new  List<object>();
            }

        }
    }
}