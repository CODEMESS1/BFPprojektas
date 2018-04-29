using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Model;
using WebApplication.Models;
using WebApplication.Presenter;

namespace WebApplication.Admin.Competition
{
    public partial class StartCompetition : Page, IStartCompetition
    {
        private StartCompetitionPresenter presenter;
        public List<AgeGroupTypes> AgeGroupTypes { set => AgeGroup_DropDownList.DataSource = value; }
        public List<Competitors> Competitors { set => CompetitorsGridView.DataSource = value; }

        public string SelectedAgeGroup => AgeGroup_DropDownList.SelectedValue;

        public List<Models.Competition> Competitions { set => CompetitorsGridView.DataSource = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new StartCompetitionPresenter(this);
            presenter.InitView();
            SelectPopup.Show();
            CompetitorsGridView.DataBind();
            AgeGroup_DropDownList.DataBind();
        }

        protected void GenerateSubGroups_Click(object sender, EventArgs e)
        {

        }

        protected void GetCompetitorsInGroup_Click(object sender, EventArgs e)
        {
            presenter.GetByGroup();
            CompetitorsGridView.DataBind();
        }

        protected void CompetitionsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPopup.Hide();
        }

        protected void CompetitionsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CompetitionsGridView.PageIndex = e.NewPageIndex;
            CompetitorsGridView.DataBind();
        }

        protected void cancel_btn_Click(object sender, EventArgs e)
        {
            SelectPopup.Hide();
        }
    }
}