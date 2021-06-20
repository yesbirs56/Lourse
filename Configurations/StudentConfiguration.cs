using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Lourse.Models;

namespace Lourse.Configurations
{
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            Property(s => s.Name).IsRequired().HasMaxLength(100);
            Property(s => s.Username).IsRequired().HasMaxLength(100);
        }
    }
}