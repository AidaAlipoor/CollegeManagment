using Autofac;
using Autofac.Integration.WebApi;
using BusinessLogic.Repositories.Course;
using BusinessLogic.Repositories.Grade;
using BusinessLogic.Repositories.Student;
using BusinessLogic.Repositories.Teacher;
using BusinessLogic.Repositories.TeacherCourse;
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


            containerBuilder.RegisterType<TeacherRepository>().As<ITeacherRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<CourseRepository>().As<ICourseRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<TeacherCourseRepository>().As<ITeacherCourseRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<GradeRepository>().As<IGradeRepository>().InstancePerLifetimeScope();

            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            return containerBuilder.Build();
        }
    }
}
