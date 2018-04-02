using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CompetitorsInCompetitions
    {
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public int CompetitorId { get; set; }

        public override bool Equals(object obj)
        {
            CompetitorsInCompetitions competitorsInCompetitions = (CompetitorsInCompetitions)obj;
            if(CompetitorId == competitorsInCompetitions.CompetitorId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}