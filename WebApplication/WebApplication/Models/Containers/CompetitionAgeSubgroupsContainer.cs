using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Containers
{
    public class CompetitionAgeSubgroupsContainer : DbContext
    {
        public CompetitionAgeSubgroupsContainer() : base("DefaultConnection")
        {

        }

        public DbSet<CompetitionAgeSubgroups> CompetitionAgeSubgroups { get; set; }
    }
}