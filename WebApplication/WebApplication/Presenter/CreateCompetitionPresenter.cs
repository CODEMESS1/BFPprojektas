using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;
using WebApplication.Models;

namespace WebApplication.Presenter
{
    public class CreateCompetitionPresenter
    {
        private ICreateCompetition View;
        private CompetitionContainer competitionContainer = new CompetitionContainer();
        private CompetitionEventsContainer competitionEventsContainer = new CompetitionEventsContainer();
        private AgeGroupTypesContainer ageGroupTypesContainer = new AgeGroupTypesContainer();
        private AgeGroupContainer ageGroupsContainer = new AgeGroupContainer();
        private EventsContainer eventsContainer = new EventsContainer();
        private List<Events> events = new List<Events>();

        public CreateCompetitionPresenter(ICreateCompetition view)
        {
            if (view == null)
                throw new ArgumentNullException("view cannot be null");

            this.View = view;
        }

        public void InitView()
        {
            View.Competitions = competitionContainer.Competitions.ToList();
            View.Events = eventsContainer.Events.ToList();
            View.ageGroupTypes = ageGroupTypesContainer.AgeGroupTypes.ToList();
        }

        public bool AddCompetition(Competition competition)
        {
            if (competition != null)
            {
                competitionContainer.AddCompetition(competition, events);
                int Id = competitionContainer.Competitions.ToList().Last().Id;
                ageGroupsContainer.AddRange(Id, View.GetSelectedStartYearAdd(), View.GetSelectedEndYearAdd(), ageGroupTypesContainer.AgeGroupTypes.ToList());
                View.Competitions = competitionContainer.Competitions.ToList();
                return true;
            }
            return false;
        }

        public bool DeleteCompetition(int Id)
        {
            bool isCompleted = competitionContainer.RemoveCompetition(Id, events);
            View.Competitions = competitionContainer.Competitions.ToList();
            ageGroupsContainer.RemoveRange(Id);
            return isCompleted;
        }

        public bool EditCompetition(int Id)
        {
            Competition competition = new Competition(View.Name, View.Location, View.Address, View.Date, View.Registration, 
                View.RegistrationStartDate, View.RegistrationEndDate);
            bool isCompleted = competitionContainer.EditCompetition(Id, competition, events);
            if (isCompleted)
            {
                View.Competitions = competitionContainer.Competitions.ToList();
                ageGroupsContainer.UpdateAgeGroups(Id, View.GetSelectedStartYearEdit(), View.GetSelectedEndYearEdit(), ageGroupTypesContainer.AgeGroupTypes.ToList());
            }
            return isCompleted;
        }

        public bool PopulatePopup(int compId)
        {
            List<Competition> competitionList = competitionContainer.Competitions.Where(c => c.Id == compId).ToList();
            if(competitionList.Count != 0)
            {
                Competition competition = competitionList[0];
                View.Name = competition.Name;
                View.Location = competition.Location;
                View.RegistrationStartDate = competition.RegistrationStartDate;
                View.RegistrationEndDate = competition.RegistrationEndDate;
                View.Date = competition.Date;
                View.Address = competition.Address;
                View.Registration = competition.Registration;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Competition getById(int Id)
        {
            return competitionContainer.getById(Id);
        }

        public void setSelectedEvents(List<Events> events)
        {
            this.events = events;
        }
    }
}