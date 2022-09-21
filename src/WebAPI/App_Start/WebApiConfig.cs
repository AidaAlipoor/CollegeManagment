using Autofac;
using Autofac.Integration.WebApi;
using BusinessLogic.Configuration;
using DataAccess.Configuration;
using System.Reflection;
using System.Web.Http;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = GetDependencyInversionContainer();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static IContainer GetDependencyInversionContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.ResolveDataAccessServices();
            containerBuilder.ResolveBusinessLogicServices();

            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            return containerBuilder.Build();
        }
    }
}
