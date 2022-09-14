using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Teacher
    {
        public const int MaxLimitedYear = 1999;
        public const int MinLimitedYear = 1950;

        public int Id { get; set; }
        public string TeacherName { get; set; }
        public string TeacherLastName { get; set; }
        public DateTime Birthday { get; set; }
        public virtual List<TeacherCourse> TeachersCourses { get; set; }

    }
}
