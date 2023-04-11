using DB_API.Models;
using DB_API.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace DB_API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IRepository<Coffee, int>, CoffeeRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}