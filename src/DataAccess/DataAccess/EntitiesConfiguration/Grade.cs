using System.Data.Entity;

namespace DataAccess.EntitiesConfiguration
{
    public static class Grade
    {
        public static void GradeConfiguration(this DbModelBuilder modelBuilder)
        {
            var gradeEntity = modelBuilder.Entity<Entities.Grade>();

            gradeEntity.HasKey(g => g.Id);

            gradeEntity.Property(g => g.Score).IsRequired();

            gradeEntity.HasRequired(g => g.TeacherCourse).WithMany(tc => tc.Grades);
        }
    }
}
