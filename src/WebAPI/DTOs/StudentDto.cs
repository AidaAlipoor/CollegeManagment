using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.DTOs
{
    public sealed class StudentDto
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int IdNumber { get; set; }
    }
}