using System;

namespace WebAPI.DTOs
{
    public sealed class TeacherDto
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDay { get; set; }
    }
}