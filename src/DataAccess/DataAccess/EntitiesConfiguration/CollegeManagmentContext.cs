using System.Data.Entity;

namespace DataAccess.EntitiesConfiguration
{
    public class CollegeManagmentContext : DbContext
    {
        private static CollegeManagmentContext _instance;

        private CollegeManagmentContext()
            : base("Server=.;Database=CollegeManagement;Trusted_Connection=True;") { }

        /// <summary>
        /// Source: https://refactoring.guru/design-patterns/singleton
        /// </summary>
        public static CollegeManagmentContext GetInstance()
        {
            if (_instance == null)
                _instance = new CollegeManagmentContext();

            return _instance;
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.CourseConfiguration();
            modelBuilder.GradeConfiguration();
            modelBuilder.StudentConfiguration();
            modelBuilder.TeacherConfiguration();
            modelBuilder.TeacherCoursesConfiguration();
        }

        public DbSet<Entities.Teacher> Teachers { get; set; }
        public DbSet<Entities.Student> Students { get; set; }
        public DbSet<Entities.Course> Courses { get; set; }
        public DbSet<Entities.Grade> Grades { get; set; }
        public DbSet<Entities.TeacherCourse> TeacherCourses { get; set; }
    }
}