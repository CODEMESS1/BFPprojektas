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

        public DbSet<Models.Objects.Results> Results { get; set; }

        public void AddResults(Models.Objects.Results result)
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

        public void UpdateResults(List<Models.Objects.Results> results)
        {
            List<Models.Objects.Results> resultsToEdit = Results.ToList();

            foreach(Models.Objects.Results result in results)
            {
                var toEdit = resultsToEdit.Where(r => r.Id == result.Id).Single();
                toEdit.Points = result.Points;
                toEdit.Result = result.Result;
                toEdit.Score = result.Score;
            }
            SaveChanges();
        }

        public List<Models.Objects.Results> GetWinnerList(int competitionId, int ageGroupType)
        {
            Results.RemoveRange(Results.Where(r => r.CompetitionId == competitionId && r.EventId == -1 && r.AgeGroupType == ageGroupType && r.Result.Equals("Final")));
            SaveChanges();
            List<Models.Objects.Results> results = Results.Where(r => r.CompetitionId == competitionId && r.AgeGroupType == ageGroupType).OrderBy(c => c.CompetitorId).ToList();
            List<Models.Objects.Results> returnList = new List<Models.Objects.Results>();

            for(int i = 0; i < results.Count; i++)
            {
                int competitor = results[i].CompetitorId;

                double? points = 0;

                while(competitor == results[i].CompetitorId)
                {
                    points += results[i].Points;
                    i++;

                    if(i == results.Count)
                    {
                        break;
                    }
                }

                i--;

                Models.Objects.Results result = new Models.Objects.Results(competitor, -1, ageGroupType, competitionId, "Final", points, null);
                Results.Add(result);
                SaveChanges();

                returnList.Add(result);
            }

            return returnList;
        }
    }
}