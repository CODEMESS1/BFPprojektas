using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class SubGroupsContainer : DbContext
    {
        public SubGroupsContainer() : base("DefaultConnection")
        {

        }

        public DbSet<CompetitionAgeSubgroups> CompetitionAgeSubgroups { get; set; }
        private AgeGroupContainer AgeGroupContainer = new AgeGroupContainer();

        public void SetAgeSubgroups(string ageGroupType, int competitionId, int subgroupsCount)
        {
            int ageGroupId = AgeGroupContainer.AgeGroups.Where(g => g.Title.Equals(ageGroupType) && g.CompetitionId == competitionId).ToList()[0].Id;
            CompetitionAgeSubgroups.Add(new Models.CompetitionAgeSubgroups(ageGroupId, subgroupsCount));
            SaveChanges();
        }
    }
}