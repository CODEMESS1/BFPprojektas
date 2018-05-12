using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WebApplication.Models
{
    public class CompetitorsInCompetitionContainer: DbContext
    {
        public CompetitorsInCompetitionContainer(): base("DefaultConnection")
        {

        }

        public DbSet<CompetitorsInCompetitions> CompetitorsInCompetitions { get; set; }
        private CompetitorsContainer CompetitorsContainer = new CompetitorsContainer();

        public List<Competitors> GetCompetitorsByCompId(int competitionId)
        {
            List<CompetitorsInCompetitions> registeredCompetitorsId = CompetitorsInCompetitions.Where(c => c.CompetitionId == competitionId).ToList();
            List<Competitors> competitorsToReturn = new List<Competitors>();
            foreach (CompetitorsInCompetitions c in registeredCompetitorsId)
            {
                competitorsToReturn.Add(CompetitorsContainer.Comp.Where(comp => comp.Id == c.CompetitorId).ToList()[0]);
            }
            return competitorsToReturn;
        }

        
    }
}