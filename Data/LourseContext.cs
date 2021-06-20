using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Lourse.Models;
using Lourse.Configurations;

namespace Lourse.Data
{
    public class LourseContext:DbContext
    {
        public LourseContext() : base("name=Lourse")
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new AuthorConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}