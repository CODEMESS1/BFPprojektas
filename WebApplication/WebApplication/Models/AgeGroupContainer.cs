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

        public void SetAgeGroups(int Id, List<int> startYear, List<int> endYear, List<AgeGroupTypes> type)
        {
            for(int i = 0; i < type.Count; i++)
            {
                AgeGroups.Add(new Models.AgeGroups(Id, type[i].Type, startYear[i], endYear[i]));   
            }
            SaveChanges();
        }

        public void DeleteAgeGroups(int compId)
        {
            List<AgeGroups> ageGroups = AgeGroups.Where(c => c.CompetitionId == compId).ToList();
            AgeGroups.RemoveRange(ageGroups);
            SaveChanges();
        }
    }
}