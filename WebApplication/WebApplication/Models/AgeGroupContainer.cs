using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class AgeGroupContainer : DbContext
    {
        public AgeGroupContainer() : base("DefaultConnection")
        {

        }

        public DbSet<AgeGroups> AgeGroups { get; set; }
    }
}