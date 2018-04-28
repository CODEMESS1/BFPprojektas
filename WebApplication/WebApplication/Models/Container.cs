using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class DbContainer: DbContext
    {
        public DbContainer(): base("DefaultConnection")
        {

        }

         public DbSet<CompetitorsInCompetitions> CompetitorsInCompetitions { get; set; }

        public void Add(int competitionId, int competitorId)
        {
            Models.CompetitorsInCompetitions competitorsInCompetitions = new CompetitorsInCompetitions();
            competitorsInCompetitions.CompetitionId = competitionId;
            competitorsInCompetitions.CompetitorId = competitorId;
            CompetitorsInCompetitions.Add(competitorsInCompetitions);
            SaveChanges();
        }

        public void Remove(int competitionId, int competitorId)
        {
            CompetitorsInCompetitions competitorsInCompetitions = CompetitorsInCompetitions.Where(c => c.CompetitionId == competitionId &&
                                                                                                                                                                                 c.CompetitorId == competitorId).ToList()[0];
            CompetitorsInCompetitions.Remove(competitorsInCompetitions);
            SaveChanges();
        }
    }
}