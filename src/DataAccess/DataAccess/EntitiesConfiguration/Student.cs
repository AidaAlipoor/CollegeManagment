using System.Data.Entity;

namespace DataAccess.EntitiesConfiguration
{
    public static class Student
    {
        public static void StudentConfiguration(this DbModelBuilder modelBuilder)
        {
            var studentEntity = modelBuilder.Entity<Entities.Student>();
            studentEntity.HasKey(s => s.Id);
            studentEntity.Property(s => s.StudentName).HasMaxLength(64).IsRequired();
            studentEntity.Property(s => s.StudentLastName).HasMaxLength(128).IsRequired();
            studentEntity.Property(s => s.IdNumber).IsRequired();
            studentEntity.HasMany(s => s.Grades).WithRequired(g => g.Students);
        }
    }   
}
