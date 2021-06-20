using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lourse.Models;

namespace Lourse.ViewModels
{
    public class CourseAuthorViewModel
    {
        public IEnumerable<Author> Authors { get; set; }
        public Course Course { get; set; }
    }
}