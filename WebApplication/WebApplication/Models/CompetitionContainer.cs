using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CompetitionContainer : DbContext
    {
        public CompetitionContainer() : base("DefaultConnection")
        {

        }

        public DbSet<Competitors> Competitions { get; set; }
    }
}