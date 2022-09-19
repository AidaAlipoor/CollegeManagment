using System.Data.Entity;

namespace DataAccess.EntitiesConfiguration
{
    internal class CollegeManagmentContext : DbContext, ICollegeManagmentContext
    {
        private CollegeManagmentContext()
            : base("Server=.;Database=CollegeManagement;Trusted_Connection=True;") { }


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