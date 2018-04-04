using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class DbContainer: DbContext
    {
        public DbContainer(): base("DefaultConnection")
        {

        }

        public DbSet<CompetitorsInCompetitions> CompetitorsInCompetitions { get; set; }

        public DbSet<Competitors> Comp { get; set; }

        public DbSet<Competition> Competition { get; set; }

        public DbSet<AspNetUsers> aspNetUsers { get; set; } 
    }
}