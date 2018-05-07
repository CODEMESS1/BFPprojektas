using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;

namespace WebApplication.Presenter
{
    public class RegisterCompetitorsAdminPresenter
    {
        private Models.CompetitionContainer CompetitionsContainer = new Models.CompetitionContainer();
        private Models.CompetitorsContainer CompetitorsContainer = new Models.CompetitorsContainer();
        private Models.DbContainer CompetitorsInCompetitions = new Models.DbContainer();
        IRegisterCompetitorsAdmin View;

        public RegisterCompetitorsAdminPresenter(IRegisterCompetitorsAdmin view)
        {
            if (view == null)
                throw new ArgumentNullException("view cannot be null");

            this.View = view;
        }

        public void InitView() => View.Competitions = CompetitionsContainer.Competitions.ToList();

        public void CompetitorsSearch(string data)
        {
            List<Models.Competitors> CompetitorsToReturn = new List<Models.Competitors>();
            int id = 0;
            if(int.TryParse(data, out id))
            {
                Models.Competitors competitor = new Models.Competitors();
                if((competitor = CompetitorsContainer.GetCompetitor(id)) != null)
                {
                    CompetitorsToReturn.Add(competitor);
                }
            }
            else
            {
                CompetitorsToReturn = CompetitorsContainer.Search(data);
            }
            View.Competitors = CompetitorsToReturn;
        }

        public void AddToCompetition()
        {
            CompetitorsInCompetitions.Add(View.competitionId, View.competitorId);
        }

        public void RemoveFromCompetition()
        {
            CompetitorsInCompetitions.Remove(View.competitionId, View.competitorId);
        }

        public void SetCompetitorInfo()
        {
            View.CompetitorInfo = CompetitorsContainer.Comp.Where(c => c.Id == View.competitorId).ToList()[0].ToString();
        }
    }
}