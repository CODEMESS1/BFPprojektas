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
        private Models.AgeGroupContainer AgeGroupContainer = new Models.AgeGroupContainer();
        private Models.CompetitorsContainer CompetitorsContainer = new Models.CompetitorsContainer();
        private Models.CompetitionContainer CompetitionContainer = new Models.CompetitionContainer();
        private Models.SubGroupsContainer SubGroupsContainer = new Models.SubGroupsContainer();

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
            List<Models.Competitors> competitors = CompetitorsContainer.GetAgeGroupCompetitors(View.SelectedAgeGroup);
            List<Models.CompetitorsWithSubgroups> competitorsWithSubgroups = new List<Models.CompetitorsWithSubgroups>();
            int subgroupCount = View.SelectedSubgroupCount;
            int subgroupLength = 0;

            if(competitors.Count / subgroupCount == 0)
            {
                subgroupLength = competitors.Count;
            }
            else
            {
                subgroupLength = competitors.Count / subgroupCount;
            }

            int subgroup = 1;
            int index = 1;

            foreach(Models.Competitors c in competitors)
            {
                if (index > subgroupLength)
                {
                    index = 1;
                    subgroup++;
                }
     
                competitorsWithSubgroups.Add(new Models.CompetitorsWithSubgroups(c, subgroup));
                index++;
            }
            View.Competitors = competitorsWithSubgroups;
        }
    }
}