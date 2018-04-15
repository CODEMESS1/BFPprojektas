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
            if(competition != null)
            {
                competitionContainer.AddCompetition(competition);
                View.Competitions = competitionContainer.Competitions.ToList();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCompetition(Competition competition)
        {
            return View.DeleteCompetition(competition);
        }

        public bool EditCompetition(Competition competition)
        {
            if(competition != null)
            {
                competitionContainer.EditCompetition(competition);
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