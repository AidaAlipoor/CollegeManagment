using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class TeacherCourse
    {
        public int Id { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Course Course { get; set; }
        public virtual List<Grade> Grades { get; set; }
    }
}
