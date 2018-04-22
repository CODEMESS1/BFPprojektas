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
        private EventsContainer eventsContainer = new EventsContainer();

        public CreateCompetitionPresenter(ICreateCompetition view)
        {
            if (view == null)
                throw new ArgumentNullException("view cannot be null");

            this.View = view;
        }

        public void InitView()
        {
            View.Competitions = competitionContainer.Competitions.ToList();
            //View.Events = eventsContainer.Events.ToList();
        }

        public bool AddCompetition(Competition competition)
        {
            if (competition != null)
            {
                competitionContainer.AddCompetition(competition);
                View.Competitions = competitionContainer.Competitions.ToList();
                return true;
            }
            return false;
        }

        public bool DeleteCompetition(int Id)
        {
            bool isCompleted = competitionContainer.RemoveCompetition(Id);
            View.Competitions = competitionContainer.Competitions.ToList();
            return isCompleted;
        }

        public bool EditCompetition(int Id)
        {
            Competition competition = new Competition(View.Name, View.Location, View.Address, View.Date, View.Registration, 
                View.RegistrationStartDate, View.RegistrationEndDate);
            bool isCompleted = competitionContainer.EditCompetition(Id, competition);
            View.Competitions = competitionContainer.Competitions.ToList();
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

    }
}