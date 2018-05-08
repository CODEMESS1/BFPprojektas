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

        public void AddRange(int Id, List<int> startYear, List<int> endYear, List<AgeGroupTypes> types)
        {
            if (types.Count() != 0)
            {
                for (int i = 0; i < types.Count(); i++)
                {
                    AgeGroups.Add(new AgeGroups(Id, types[i].Type, startYear[i], endYear[i]));
                }
            }
            SaveChanges();
        }

        public void RemoveRange(int Id)
        {
            AgeGroups.RemoveRange(AgeGroups.Where(a => a.CompetitionId == Id));
            SaveChanges();
        }

            public void AddAgeGroup(int compId, int startYear, int endYear, string title)
        {
            AgeGroups.Add(new AgeGroups(compId, title, startYear, endYear));
            SaveChanges();
        }

        public void DeleteAgeGroup(int compId, string title)
        {
            AgeGroups ageGroupsToRemove = AgeGroups.Where(g => g.CompetitionId == compId && g.Title == title).Single();
            AgeGroups.Remove(ageGroupsToRemove);
            SaveChanges();
        }

        public void UpdateAgeGroups(int Id, List<int> startYear, List<int> endYear, List<AgeGroupTypes> types)
        {
            RemoveRange(Id);
            int index = 0;
            foreach(AgeGroupTypes type in types)
            {
                AddAgeGroup(Id, startYear[index], endYear[index], type.Type);
                index++;
            }
            SaveChanges();
        }
    }
}