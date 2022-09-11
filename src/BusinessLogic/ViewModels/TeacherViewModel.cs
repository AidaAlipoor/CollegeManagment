using System;

namespace BusinessLogic.ViewModels
{
    public sealed class TeacherViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
    }
}
