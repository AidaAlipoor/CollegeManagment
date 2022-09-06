using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public string TeacherLastName { get; set; }
        public DateTime Birthday { get; set; }
        public virtual List<TeacherCourse> TeachersCourses { get; set; }
    }
}
