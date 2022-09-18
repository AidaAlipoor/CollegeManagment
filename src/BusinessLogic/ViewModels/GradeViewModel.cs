using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModels
{
    public sealed class GradeViewModel
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public int TeacherCourseId { get; set; }
        public int StudentId { get; set; }

    }
}

