using System.Data.Entity;

namespace DataAccess.EntitiesConfiguration
{
    public static class Course
    {
        public static void CourseConfiguration(this DbModelBuilder modelBuilder)
        {
            var courseEntity = modelBuilder.Entity<Entities.Course>();
            courseEntity.HasKey(c => c.Id);
            courseEntity.Property(c => c.CourseName).HasMaxLength(214).IsRequired();
        }
    }
}
