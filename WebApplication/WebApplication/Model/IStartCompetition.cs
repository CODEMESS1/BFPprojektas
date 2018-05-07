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
        Models.EventTypes GetEventType();
        string SelectedAgeGroup { get; }
        int SelectedSubgroupCount { get; }
        int SelectedCompetitionId { get; }
        string SelectedAgeGroupForResult { get; }
        int SelectedEventForResult { get; }
        List<Models.Competition> Competitions { set; }
        List<Models.Events> Events { set; }
        List<Models.Objects.LastEntries> LastEntries { set; }
        Models.Objects.LastEntries LastEntry { get; }
    }
}
