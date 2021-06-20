using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Lourse.Models;

namespace Lourse.Configurations
{
    public class CourseConfiguration:EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            
            Property(c => c.Description).HasMaxLength(2000).IsRequired();


            HasMany(c => c.Students).WithMany(s => s.Courses);
            HasRequired(c => c.Author).WithMany(a => a.Courses).HasForeignKey(c => c.AuthorId);

        }
    }
}