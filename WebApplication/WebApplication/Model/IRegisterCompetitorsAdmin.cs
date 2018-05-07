using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Model
{
    public interface IRegisterCompetitorsAdmin
    {
        int competitorId { get; }
        int competitionId { get; }
        List<Models.Competition> Competitions { set; }
        List<Models.Competitors> Competitors { set; }
        void GetCompetitors(string searchField);
        bool RegisterCompetitor();
        string CompetitorInfo { set; }
    }
}
