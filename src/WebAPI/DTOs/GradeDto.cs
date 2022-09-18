using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.DTOs
{
    public class GradeDto
    {
        public int Score { get; set; }
        public int TeacherCourseId { get; set; }
        public int StudentId { get; set; }
    }
}