using System.Data.Entity;

namespace DataAccess.EntitiesConfiguration
{
    public static class TeachersCourses
    {
        public static void TeacherCoursesConfiguration(this DbModelBuilder modelBuilder)
        {
            var teachersCoursesEntity = modelBuilder.Entity<Entities.TeacherCourse>();

            teachersCoursesEntity.HasRequired(tc => tc.Teacher)
                                 .WithMany(t => t.TeachersCourses)
                                 .WillCascadeOnDelete(false);

            teachersCoursesEntity.HasRequired(tc => tc.Course)
                                 .WithMany(t => t.TeachersCourses)
                                 .WillCascadeOnDelete(false);
        }
    }
}