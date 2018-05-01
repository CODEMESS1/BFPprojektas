using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Model
{
    public interface IStartCompetition
    {
        List<Models.AgeGroupTypes> AgeGroupTypes { set; }
        List<Models.CompetitorsWithSubgroups> Competitors { set; }
        string SelectedAgeGroup { get; }
        int SelectedSubgroupCount { get; }
        int SelectedCompetitionId { get; }
        List<Models.Competition> Competitions { set; }
    }
}
