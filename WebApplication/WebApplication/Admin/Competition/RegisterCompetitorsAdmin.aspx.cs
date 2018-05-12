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
    public partial class RegisterCompetitorsAdmin : Page, IRegisterCompetitorsAdmin
    {
        public int competitorId => Convert.ToInt32(competitorsGridView.SelectedRow.Cells[1].Text);

        public int competitionId => Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);

        public List<Models.Competition> Competitions { set =>GridView1.DataSource = value; }
        public List<Competitors> Competitors { set => competitorsGridView.DataSource = value; }

        public string CompetitorInfo { set => Info_tb.Text = value; }

        private RegisterCompetitorsAdminPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new RegisterCompetitorsAdminPresenter(this);
            presenter.InitView();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchPopup.Show();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        public void GetCompetitors(string searchField)
        {
            presenter.CompetitorsSearch(searchField);
        }

        public bool RegisterCompetitor()
        {
            throw new NotImplementedException();
        }

        protected void competitorsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.SetCompetitorInfo();
            panelAddTo.Visible = true;
            Info_tb.DataBind();
            

        }

        protected void search_btn_Click(object sender, EventArgs e)
        {
            GetCompetitors(search_tb.Text);
            competitorsGridView.DataBind();
        }

        protected void cancel_btn_Click(object sender, EventArgs e)
        {
            searchPopup.Hide();
            competitorsGridView.DataSource = null;
            competitorsGridView.DataBind();
        }

        protected void AddToCompeition_Click(object sender, EventArgs e)
        {
            presenter.AddToCompetition();
            searchPopup.Hide();

        }

        protected void RemoveFromCompetition_Click(object sender, EventArgs e)
        {
            presenter.RemoveFromCompetition();
            searchPopup.Hide();
        }

        protected void cancelAdding_Click(object sender, EventArgs e)
        {
            panelAddTo.Visible = false;
            searchPopup.Hide();
        }
    }
}