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

        public void SetAgeSubgroups(int selectedCompetition, string ageGroupType, int competitionId, int subgroupsCount)
        {
            int ageGroupId = AgeGroupContainer.AgeGroups.Where(g => g.Title.Equals(ageGroupType) && g.CompetitionId == competitionId).ToList()[0].Id;

            if(CompetitionAgeSubgroups.Where(c => c.CompetitionId == selectedCompetition && c.AgeGroupId == ageGroupId).Count() > 0)
            {
                CompetitionAgeSubgroups.Remove(CompetitionAgeSubgroups.Where(s => s.CompetitionId == selectedCompetition && s.AgeGroupId == ageGroupId).Single());
            }

            CompetitionAgeSubgroups.Add(new Models.CompetitionAgeSubgroups(selectedCompetition ,ageGroupId, subgroupsCount));

            SaveChanges();
        }
    }
}