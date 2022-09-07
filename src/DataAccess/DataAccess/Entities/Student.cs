
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }
        public int IdNumber { get; set; }
        public virtual List<Grade> Grades { get; set; }

        public const long IdNumberLengthLimit = 10;
    }
}
