using System.Collections.Generic;

namespace DataAccess.Entities

{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public virtual List<TeacherCourse> TeachersCourses { get; set; }
    }
}
