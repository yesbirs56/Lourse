using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Lourse.Models;

namespace Lourse.Configurations
{
    public class AuthorConfiguration : EntityTypeConfiguration<Author> 
    {
        public AuthorConfiguration()
        {
            Property(a => a.Name).IsRequired().HasMaxLength(100);

            
        }
    }
}