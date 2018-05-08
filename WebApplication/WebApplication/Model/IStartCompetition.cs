using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models.Objects;

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
        int SelectedAgeGroupForResult { get; }
        int SelectedEventForResult { get; }
        List<Models.Competition> Competitions { set; }
        List<Models.Events> Events { set; }
        Models.Objects.LastEntries LastEntry { get; }
        Models.Competitors Competitor { set; }
        int CompetitorId { get; }
        string Result { get; }
        string AgeGroupForCalculation { get; }
        List<Results> Results { set; }
    }
}
