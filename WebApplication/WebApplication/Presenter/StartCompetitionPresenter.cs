using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;
using WebApplication.Models;
using WebApplication.Models.Containers;
using WebApplication.Models.Objects;

namespace WebApplication.Presenter
{
    public class StartCompetitionPresenter
    {
        IStartCompetition View;
        
        private AgeGroupTypesContainer AgeGroupTypesContainer = new AgeGroupTypesContainer();
        private AgeGroupContainer AgeGroupContainer = new AgeGroupContainer();
        private CompetitorsContainer CompetitorsContainer = new CompetitorsContainer();
        private CompetitionContainer CompetitionContainer = new CompetitionContainer();
        private SubGroupsContainer SubGroupsContainer = new SubGroupsContainer();
        private EventsContainer EventsContainer = new EventsContainer();
        private EventTypesContainer EventTypes = new EventTypesContainer();
        private ResultsContainer ResultsContainer = new ResultsContainer();
        private CompetitionEventsContainer CompetitionEvents = new CompetitionEventsContainer();

        public StartCompetitionPresenter(IStartCompetition view)
        {
            if (view == null)
                throw new ArgumentNullException("View cannot be null");

            View = view;
        }

        public void InitView()
        {
            View.AgeGroupTypes = AgeGroupTypesContainer.AgeGroupTypes.ToList();
            View.Competitions = CompetitionContainer.Competitions.ToList();
        }

        public void SetAgeGroupSubgroupsCount()
        {
            SubGroupsContainer.SetAgeSubgroups(View.SelectedAgeGroup, View.SelectedCompetitionId, View.SelectedSubgroupCount);
        }

        public void GetByGroup()
        {
            List<Competitors> competitors = CompetitorsContainer.GetAgeGroupCompetitorsInCompetition(View.SelectedCompetitionId, View.SelectedAgeGroup);
            List<CompetitorsWithSubgroups> competitorsWithSubgroups = new List<CompetitorsWithSubgroups>();
            int subgroupCount = View.SelectedSubgroupCount;
            int subgroupLength = 0;

            subgroupLength = competitors.Count / subgroupCount;

            while(subgroupLength * subgroupCount < competitors.Count)
            {
                subgroupLength++;
            }

            int subgroup = 1;
            int index = 1;

            foreach(Competitors c in competitors)
            {
                if (index > subgroupLength)
                {
                    index = 1;
                    subgroup++;
                }
     
                competitorsWithSubgroups.Add(new CompetitorsWithSubgroups(c, subgroup));
                index++;
            }
            View.Competitors = competitorsWithSubgroups;
        }

        public bool GetEvents()
        {
            List<Events> eventsList = EventsContainer.GetSelectedEvents(View.SelectedAgeGroup, View.SelectedCompetitionId);
            if (eventsList.Count != 0)
            {
                View.Events = eventsList;
                return true;
            }
            return false;
        }

        public EventTypes GetEventType()
        {
            Models.Events events = EventsContainer.Events.Where(e => e.Id == View.SelectedEventForResult).ToList()[0];
            return EventTypes.GetEventTypes(events.Type);
        }

        public Competitors CompetitorForEntry()
        {
            Competitors competitors = new Competitors();
            if((competitors = CompetitorsContainer.GetCompetitor(View.CompetitorId)) != null)
            {
                View.Competitor = competitors;
                return competitors;
            }
            return null;
        }

        public void AddResult()
        {
            Results results = new Results(View.CompetitorId, View.SelectedEventForResult, Convert.ToInt16(View.SelectedAgeGroupForResult), View.SelectedCompetitionId, View.Result);
            ResultsContainer.AddResults(results);
        }

        public void CalculateSelected()
        {
            List<CompetitionEvents> competitionEvents = CompetitionEvents.CompetitionEvents.Where(e => e.CompetitionId == View.SelectedCompetitionId).ToList();
            List<AgeGroupEvents> ageGroupEvents = EventsContainer.GetEventsInCompetition(View.AgeGroupForCalculation, View.SelectedCompetitionId);

            List<Events> events = EventsContainer.Events.ToList();
            foreach (AgeGroupEvents e in ageGroupEvents)
            {
                int eventTypeValue = events.Where(et => et.Id == e.EventId).ToList()[0].Type;
                List<Results> results = ResultsContainer.Results.Where(r => r.CompetitionId == View.SelectedCompetitionId && r.AgeGroupType == e.AgeGroupType &&
                                                                                                    r.EventId == e.EventId).ToList();
                EventTypes eventType = EventTypes.EventTypes.Where(t => t.Id == eventTypeValue).ToList()[0];
                View.Results = CalculateResults(results, eventType);
            }
        }

        private List<Results> CalculateResults(List<Results> results, EventTypes eventType)
        {
            if(eventType.Type.Equals("Count") && eventType.Method.Equals("Most"))
            {
                results = results.OrderByDescending(r => Convert.ToDouble(r.Result)).ToList();
            }
            if(results.Count != 0)
            {
                return CalculateMostCount(results);
            }
            return null;
        }

        private List<Results> CalculateMostCount(List<Results> results)
        {
            List<double> points = MakePointsList(results.Count);
            int place = 1;
            for(int i = 0; i < points.Count-1; i++)
            {
                if(Convert.ToInt16(results[i].Result) == Convert.ToInt16(results[i+1].Result))
                {
                    int startIndex = i;
                    int endIndex = 0;
                    int index = i;
                    double sum = points[i] + points[i + 1];
                    int count = 2;
                    index++;
                    if (index + 1 != results.Count - 1)
                    {
                        while (Convert.ToInt16(results[index].Result) == Convert.ToInt16(results[index + 1].Result))
                        {
                            sum += points[index + 1];
                            count++;
                            index++;
                            if (index == results.Count - 1)
                            {
                                continue;
                            }
                        }
                        endIndex = index + 1;
                        i = endIndex - 1;
                        double avg = sum / count;
                        for (int j = startIndex; j <= endIndex; j++)
                        {
                            results[j].Score = place;
                            results[j].Points = avg;
                        }
                        place += endIndex - startIndex;
                    }
                    else
                    {

                        i = index;
                    }
                }
                else
                {
                    results[i].Score = place;
                    results[i].Points = place;
                    place++;

                    if (i +1 == points.Count-1)
                    {
                        int j = i;
                        results[++j].Score = place;
                        results[j].Points = place;
                        break;
                    }
                }
            }

            //update DB
            ResultsContainer.UpdateResults(results);

            return results;
        }

        public List<double> MakePointsList(int length)
        {
            List<double> points = new List<double>();
            for(int i = 1; i <= length; i++)
            {
                points.Add(Convert.ToDouble(i));
            }
            return points;
        }
    }
}