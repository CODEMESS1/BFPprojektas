using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;
using WebApplication.Models;
using WebApplication.Models.Objects;

namespace WebApplication.Tests.Mocks
{
    public class MockStartCompetitionView : IStartCompetition
    {
        public List<AgeGroupTypes> AgeGroupTypes { set => throw new NotImplementedException(); }

        public List<CompetitorsWithSubgroups> Competitors { set => throw new NotImplementedException(); }

        public string SelectedAgeGroup => throw new NotImplementedException();

        public int SelectedSubgroupCount => throw new NotImplementedException();

        public int SelectedCompetitionId => throw new NotImplementedException();

        public int SelectedAgeGroupForResult => throw new NotImplementedException();

        public int SelectedEventForResult => throw new NotImplementedException();

        public List<Competition> Competitions { set => CompetitionsList = value; }
        public List<Events> Events { set => throw new NotImplementedException(); }

        public LastEntries LastEntry => throw new NotImplementedException();

        public Competitors Competitor { set => CompetitorObj = value; }

        public int CompetitorId => throw new NotImplementedException();

        public string Result => throw new NotImplementedException();

        public string AgeGroupForCalculation => throw new NotImplementedException();

        public List<Results> Results { set => throw new NotImplementedException(); }

        public EventTypes GetEventType()
        {
            throw new NotImplementedException();
        }


        //fields
        private List<Competition> CompetitionsList;

        private Competitors CompetitorObj;
    }
}