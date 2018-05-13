using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class AgeGroupTypesContainer: DbContext
    {
        public AgeGroupTypesContainer() : base("DefaultConnection")
        {

        }

        public DbSet<AgeGroupTypes> AgeGroupTypes { get; set; }
    }
}