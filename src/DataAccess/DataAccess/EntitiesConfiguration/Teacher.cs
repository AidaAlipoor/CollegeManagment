using System.Data.Entity;

namespace DataAccess.EntitiesConfiguration
{
    public static class Teacher 
    {
        public static void TeacherConfiguration(this DbModelBuilder modelBuilder)
        {
            var teacherEntity = modelBuilder.Entity<Entities.Teacher>();
            teacherEntity.HasKey(t => t.Id);
            teacherEntity.Property(t => t.TeacherName).HasMaxLength(64).IsRequired();
            teacherEntity.Property(t => t.TeacherLastName).HasMaxLength(64).IsRequired();
            teacherEntity.Property(t => t.Birthday).IsRequired();
        }
    }
}

