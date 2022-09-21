using Autofac;
using BusinessLogic.Repositories.Course;
using BusinessLogic.Repositories.Grade;
using BusinessLogic.Repositories.Student;
using BusinessLogic.Repositories.Teacher;
using BusinessLogic.Repositories.TeacherCourse;

namespace BusinessLogic.Configuration
{
    public static class ServiceResolver
    {
        public static void ResolveBusinessLogicServices(this ContainerBuilder containerBuilder)
        {
            containerBuilder.ResolveInstancePerLifetimeScope<TeacherRepository, ITeacherRepository>();
            containerBuilder.ResolveInstancePerLifetimeScope<StudentRepository, IStudentRepository>();
            containerBuilder.ResolveInstancePerLifetimeScope<CourseRepository, ICourseRepository>();
            containerBuilder.ResolveInstancePerLifetimeScope<TeacherCourseRepository, ITeacherCourseRepository>();
            containerBuilder.ResolveInstancePerLifetimeScope<GradeRepository, IGradeRepository>();
        }


        private static void ResolveInstancePerLifetimeScope<TImplementer, TService>(this ContainerBuilder containerBuilder)
            where TImplementer : class
            where TService : class
        {
            containerBuilder.RegisterType<TImplementer>().As<TService>().InstancePerLifetimeScope();
        }
    }
}
