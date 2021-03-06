﻿using System;
using System.Collections.Generic;
using System.Data;
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
        private CompetitionAgeSubgroupsContainer CompetitionAgeSubgroupsContainer = new CompetitionAgeSubgroupsContainer();
        private AspUsersContainer AspUsersContainer = new AspUsersContainer();

        public StartCompetitionPresenter(IStartCompetition view)
        {
            AgeGroupTypesContainer = new AgeGroupTypesContainer();
            AgeGroupContainer = new AgeGroupContainer();
            CompetitorsContainer = new CompetitorsContainer();
            CompetitionContainer = new CompetitionContainer();
            SubGroupsContainer = new SubGroupsContainer();
            EventsContainer = new EventsContainer();
            EventTypes = new EventTypesContainer();
            ResultsContainer = new ResultsContainer();
            CompetitionEvents = new CompetitionEventsContainer();

            if (view == null)
                throw new ArgumentNullException("View cannot be null");

            View = view;
        }

        public StartCompetitionPresenter(IStartCompetition view, ResultsContainer resultsContainer)
        {
            ResultsContainer = resultsContainer;

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
            SubGroupsContainer.SetAgeSubgroups(View.SelectedCompetitionId, View.SelectedAgeGroup, View.SelectedCompetitionId, View.SelectedSubgroupCount);
        }

        public string GetCoachFullName(string Id)
        {
            var coach = AspUsersContainer.aspNetUsers.Where(u => u.Id == Id).Single();
            return coach.Name + " " + coach.Surname; 
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

        public List<CompetitorsWithSubgroups> GetSubgroups(string ageGroup)
        {
            List<Competitors> competitors = CompetitorsContainer.GetAgeGroupCompetitorsInCompetition(View.SelectedCompetitionId, ageGroup);
            List<CompetitorsWithSubgroups> competitorsWithSubgroups = new List<CompetitorsWithSubgroups>();

            if (competitors.Count > 0)
            {
                int ageGroupId = AgeGroupContainer.AgeGroups.Where(s => s.CompetitionId == View.SelectedCompetitionId && s.Title == ageGroup).Single().Id;
                int subgroupCount = CompetitionAgeSubgroupsContainer.CompetitionAgeSubgroups.Where(s => s.AgeGroupId == ageGroupId && s.CompetitionId == View.SelectedCompetitionId).Single().SubGroupCount;
                int subgroupLength = 0;

                subgroupLength = competitors.Count / subgroupCount;

                while (subgroupLength * subgroupCount < competitors.Count)
                {
                    subgroupLength++;
                }

                int subgroup = 1;
                int index = 1;

                foreach (Competitors c in competitors)
                {
                    if (index > subgroupLength)
                    {
                        index = 1;
                        subgroup++;
                    }

                    competitorsWithSubgroups.Add(new CompetitorsWithSubgroups(c, subgroup));
                    index++;
                }
            }
            return competitorsWithSubgroups;
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
            Models.Objects.Results results = new Models.Objects.Results(View.CompetitorId, View.SelectedEventForResult, Convert.ToInt16(View.SelectedAgeGroupForResult), View.SelectedCompetitionId, View.Result);
            ResultsContainer.AddResults(results);
        }

        public void CalculateSelected()
        {
            List<CompetitionEvents> competitionEvents = CompetitionEvents.CompetitionEvents.Where(e => e.CompetitionId == View.SelectedCompetitionId).ToList();
            List<AgeGroupEvents> ageGroupEvents = EventsContainer.GetEventsInCompetition(View.AgeGroupForCalculation, View.SelectedCompetitionId);
            List<Competitors> competitors = CompetitorsContainer.GetAgeGroupCompetitorsInCompetition(View.SelectedCompetitionId, View.AgeGroupForCalculation);
            List<Models.Objects.Results> resultsList = new List<Models.Objects.Results>();

            List<Events> events = EventsContainer.Events.ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Vardas");
            dt.Columns.Add("Pavardė");

            foreach (AgeGroupEvents e in ageGroupEvents)
            {
                string eventName = EventsContainer.Events.Where(evt => evt.Id == e.EventId).Single().Title;

                int eventTypeValue = events.Where(et => et.Id == e.EventId).ToList()[0].Type;
                List<Models.Objects.Results> results = ResultsContainer.Results.Where(r => r.CompetitionId == View.SelectedCompetitionId && r.AgeGroupType == e.AgeGroupType &&
                                                                                                    r.EventId == e.EventId).ToList();
                EventTypes eventType = EventTypes.EventTypes.Where(t => t.Id == eventTypeValue).ToList()[0];
                resultsList.AddRange(CalculateResults(results, eventType));

                dt.Columns.Add(eventName);
                dt.Columns.Add(eventName + ": rezultatas");
            }

            dt.Columns.Add("Suma");

            int ageGroupId = AgeGroupTypesContainer.AgeGroupTypes.Where(t => t.Type.Equals(View.AgeGroupForCalculation)).Single().Id;
            List<Models.Objects.Results> finalResults = ResultsContainer.GetWinnerList(View.SelectedCompetitionId, ageGroupId);
            finalResults = finalResults.OrderBy(r => r.Points).ToList();

            for(int i = 0; i < finalResults.Count; i++)
            {
                string name = competitors.Where(c => c.Id == finalResults[i].CompetitorId).Single().Name;
                string surname = competitors.Where(c => c.Id == finalResults[i].CompetitorId).Single().Surname;

                List<Models.Objects.Results> eventsResultsCompetitor = resultsList.Where(r => r.CompetitorId == finalResults[i].CompetitorId).ToList();

                double? sum = finalResults[i].Points;

                int size = 4 + (eventsResultsCompetitor.Count() * 2);

                object[] values = new object[size];

                values[0] = finalResults[i].CompetitorId;
                values[1] = name;
                values[2] = surname;

                int index = 3;
                foreach(Models.Objects.Results r in eventsResultsCompetitor)
                {
                    values[index] = r.Result;
                    index++;
                    values[index] = r.Points;
                    index++;
                }

                values[index] = sum;

                dt.Rows.Add(values);
            }
            View.Results = dt;
        }

        public List<Models.Objects.Results> CalculateResults(List<Models.Objects.Results> results, EventTypes eventType)
        {
            if(eventType.Type.Equals("Count") && eventType.Method.Equals("Most"))
            {
                results = results.OrderByDescending(r => Convert.ToDouble(r.Result)).ToList();
            }
            else if (eventType.Type.Equals("Count") && eventType.Method.Equals("Least"))
            {
                results = results.OrderBy(r => Convert.ToDouble(r.Result)).ToList();
            }
            else if (eventType.Type.Equals("Time") && eventType.Method.Equals("Worst")) //ilgesnis laikas geriausias
            {
                results = SortTimeDsc(results);
            }
            else if (eventType.Type.Equals("Time") && eventType.Method.Equals("Best"))
            {
                results = SortTimeAsc(results);
            }

            if (results.Count != 0)
            {
                if(eventType.Type.Equals("Count"))
                {
                    return CalculateCount(results);
                }
                else
                {
                    return CalculateTime(results);
                }
            }
            return null;
        }

        public List<Models.Objects.Results> SortTimeAsc(List<Models.Objects.Results> results)
        {
            int n = results.Count;
            for (int i = 1; i < n; ++i)
            {
                Models.Objects.Results key = results[i];
                int j = i - 1;

                while (j >= 0 && TimeCompare(results[j].Result, key.Result) == 1)
                {
                    results[j + 1] = results[j];
                    j = j - 1;
                }
                results[j + 1] = key;
            }
            return results;
        }

        public List<Models.Objects.Results> SortTimeDsc(List<Models.Objects.Results> results)
        {
            int n = results.Count;
            for (int i = 1; i < n; ++i)
            {
                Models.Objects.Results key = results[i];
                int j = i - 1;

                while (j >= 0 && TimeCompare(results[j].Result, key.Result) == -1)
                {
                    results[j + 1] = results[j];
                    j = j - 1;
                }
                results[j + 1] = key;
            }
            return results;
        }

        public int TimeCompare(string first, string second)
        {
            string[] firstFields = first.Split(':');
            string[] secondFields = second.Split(':');

            double firstSum = Convert.ToDouble(firstFields[0]) * 60 + Convert.ToDouble(firstFields[1]) + Convert.ToDouble(firstFields[2]) / 1000;
            double secondSum = Convert.ToDouble(secondFields[0]) * 60 + Convert.ToDouble(secondFields[1]) + Convert.ToDouble(secondFields[2]) / 1000;

            if (Double.Equals(firstSum, secondSum) == true)
            {
                return 0;
            }

            if (firstSum > secondSum)
            {
                return 1;
            }
            return -1;
        }

        public List<Models.Objects.Results> CalculateCount(List<Models.Objects.Results> results)
        {
            List<double> points = MakePointsList(results.Count);
            int place = 1;
            for(int i = 0; i < points.Count-1; i++)
            {
                if (Convert.ToInt16(results[i].Result) == Convert.ToInt16(results[i + 1].Result))
                {
                    int index = i;
                    int count = 1;
                    double sum = Convert.ToDouble(points[i]);
                    double avg = 0;
                    int startIndex = i;
                    int placeToSet = place;
                    bool isEqual = true;
                    int score = Convert.ToInt32(results[index].Result);
                    int endIndex = i;
                    index++;

                    while(isEqual)
                    {
                        if(index == points.Count)
                        {
                            break;
                        }

                        if(Convert.ToInt32(results[index].Result) == score)
                        {
                            endIndex++;
                            sum += points[index];
                            count++;
                            place++;
                            i++;
                        }
                        else
                        {
                            isEqual = false;
                        }

                        index++;
                    }
                    
                    avg = sum / count;
                    for(int j = startIndex; j <= endIndex; j++)
                    {
                        results[j].Score = placeToSet;
                        results[j].Points = avg;
                    }
                    place++;
                }
                else
                {
                    if (i + 1 == points.Count - 1)
                    {
                        results[i + 1].Score = place;
                        results[i + 1].Points = points[i + 1];
                        break;
                    }

                    results[i].Score = place;
                    results[i].Points = points[i];
                    place++;
                }

                
            }

            //update DB
            ResultsContainer.UpdateResults(results);

            return results;
        }

        public List<Models.Objects.Results> CalculateTime(List<Models.Objects.Results> results)
        {
            List<double> points = MakePointsList(results.Count);
            int place = 1;
            for (int i = 0; i < points.Count - 1; i++)
            {
                if (TimeCompare(results[i].Result, results[i + 1].Result) == 0)
                {
                    int index = i;
                    int count = 1;
                    double sum = Convert.ToDouble(points[i]);
                    double avg = 0;
                    int startIndex = i;
                    int placeToSet = place;
                    bool isEqual = true;
                    string score = results[index].Result;
                    int endIndex = i;
                    index++;

                    while (isEqual)
                    {
                        if (index == points.Count)
                        {
                            break;
                        }

                        if (TimeCompare(score, results[index].Result) == 0)
                        {
                            endIndex++;
                            sum += points[index];
                            count++;
                            place++;
                            i++;
                        }
                        else
                        {
                            isEqual = false;
                        }

                        index++;
                    }

                    avg = sum / count;
                    for (int j = startIndex; j <= endIndex; j++)
                    {
                        results[j].Score = placeToSet;
                        results[j].Points = avg;
                    }
                    place++;
                }
                else
                {


                    results[i].Score = place;
                    results[i].Points = points[i];
                    place++;
                    if (i + 1 == points.Count - 1)
                    {
                        results[i + 1].Score = place;
                        results[i + 1].Points = points[i + 1];
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

        public List<CompetitorsWithSubgroups> GetStartList(string ageGroupType)
        {
            List<CompetitorsWithSubgroups> competitorsWithSubgroups = new List<CompetitorsWithSubgroups>();
            competitorsWithSubgroups.AddRange(GetSubgroups(ageGroupType));
            return competitorsWithSubgroups;
        }
    }
}