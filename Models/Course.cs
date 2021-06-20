using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lourse.Models
{
    public class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }
        public int Id { get; set; }
        
        [Range(0,5)]
        public int Rating { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DatePublished { get; set; }
        public ICollection<Student> Students { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }

    }
}