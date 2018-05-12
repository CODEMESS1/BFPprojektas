using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Objects
{
    public class Results
    {
        public int Id { get; set; }
        public int CompetitorId { get; set; }
        public int EventId { get; set; }
        public int AgeGroupType { get; set; }
        public int CompetitionId { get; set; }
        public string Result { get; set; }
        public double? Points { get; set; }
        public int? Score { get; set; }

        public Results()
        {

        }

        public Results(int competitorId, int eventId, int ageGroupType, int competitionId, string result)
        {
            CompetitorId = competitorId;
            EventId = eventId;
            AgeGroupType = ageGroupType;
            CompetitionId = competitionId;
            Result = result;
        }

        public Results(int competitorId, int eventId, int ageGroupType, int competitionId, string result, double? points, int? score)
        {
            CompetitorId = competitorId;
            EventId = eventId;
            AgeGroupType = ageGroupType;
            CompetitionId = competitionId;
            Result = result;
            Points = points;
            Score = score;
        }

        public override bool Equals(object obj)
        {
            Results results = (Results)obj;
            if(results.EventId == EventId && results.CompetitorId == CompetitorId &&
                results.CompetitionId == CompetitionId && results.Result.Equals(Result))
            {
                return true;
            }
            return false;
        }

        public bool IsResultEqual(string result)
        {
            return result.Equals(Result);
        }
    }
}