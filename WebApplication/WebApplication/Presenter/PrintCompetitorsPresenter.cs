using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;
using WebApplication.Models;

namespace WebApplication.Presenter
{
    public class PrintCompetitorsPresenter
    {

        private IPrintOfficial View;
        private CompetitionContainer competitionContainer = new CompetitionContainer();
        private CompetitionEventsContainer competitionEventsContainer = new CompetitionEventsContainer();
        private CompetitorsContainer competitorsContainer = new CompetitorsContainer();
        private CompetitorsInCompetitions competInCompetitions = new CompetitorsInCompetitions();

        public PrintCompetitorsPresenter(IPrintOfficial view)
        {
            if (view == null)
                throw new ArgumentNullException("view cannot be null");

            this.View = view;
        }

        public void InitCompetitionView()
        {
            populateCompetitionGridView();
        }

        public void populateCompetitionGridView()
        {
            View.CompetitionList = competitionContainer.Competitions.ToList();
        }

        public void InitCompetitorsView(int id)
        {
            populateCompetitorsGridView(id);
        }

        public void populateCompetitorsGridView(int id)
        {

            var temp = competitionContainer.getById(id);

        }

    }
}