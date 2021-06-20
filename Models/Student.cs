using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lourse.Models
{
    public class Student
    {
        public Student()
        {
            Courses = new HashSet<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}