using Autofac;
using DataAccess.EntitiesConfiguration;

namespace DataAccess.Configuration
{
    public static class ServiceResolver
    {
        public static void ResolveDataAccessServices(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CollegeManagmentContext>()
                            .As<ICollegeManagmentContext>()
                            .InstancePerLifetimeScope();
        }
    }
}
