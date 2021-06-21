using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lourse.Models;

namespace Lourse.ViewModels
{
    public class StudentCoursesViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}