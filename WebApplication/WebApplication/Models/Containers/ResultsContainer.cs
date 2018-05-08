using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Models.Objects;

namespace WebApplication.Models.Containers
{
    public class ResultsContainer : DbContext
    {
        public ResultsContainer() : base("DefaultConnection")
        {

        }

        public DbSet<Results> Results { get; set; }

        public void AddResults(Results result)
        {
            if ((Results.Where(r => r.AgeGroupType == result.AgeGroupType && r.EventId == result.EventId && r.CompetitionId == result.CompetitionId &&
                                        r.CompetitorId == result.CompetitorId).Count()) == 0)
            { 
                Results.Add(result);
                SaveChanges();
            }
            else
            {
                var toEdit = Results.Where(r => r.AgeGroupType == result.AgeGroupType && r.EventId == result.EventId && r.CompetitionId == result.CompetitionId &&
                                        r.CompetitorId == result.CompetitorId).Single();
                toEdit.Result = result.Result;
                toEdit.Points = null;
                toEdit.Score = null;
                SaveChanges();
            }
        }

        public void UpdateResults(List<Results> results)
        {
            List<Results> resultsToEdit = Results.ToList();
            foreach(Results result in results)
            {
                var toEdit = results.Where(r => r.Id == result.Id).Single();
                toEdit.Points = result.Points;
                toEdit.Result = result.Result;
                toEdit.Score = result.Score;
            }
            SaveChanges();
        }
    }
}