using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;

namespace WebApplication.Presenter
{
    public class StartCompetitionPresenter
    {
        IStartCompetition View;

        private Models.AgeGroupTypesContainer AgeGroupTypesContainer = new Models.AgeGroupTypesContainer();
        private Models.CompetitorsContainer CompetitorsContainer = new Models.CompetitorsContainer();
        private Models.CompetitionContainer CompetitionContainer = new Models.CompetitionContainer();

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

        public void GetByGroup()
        {
            View.Competitors = CompetitorsContainer.GetAgeGroupCompetitors(View.SelectedAgeGroup);
        }
    }
}