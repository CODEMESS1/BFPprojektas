using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Model;
using WebApplication.Models;
using WebApplication.Models.Objects;
using WebApplication.Presenter;

namespace WebApplication.Results
{
    public partial class ResultsView : Page, IResultsView
    {
        private ResultsViewPresenter Presenter;

        public DataTable Results { set => ResultsGridView.DataSource = value; }

        public List<AgeGroupTypes> AgeGroupTypes { set => AgeGroup_List.DataSource = value; }

        public List<Competition> Competitions { set { CompetitionsGridView.DataSource = value; CompetitionsGridView.DataBind(); } }

        public string AgeGroupSelected => AgeGroup_List.SelectedValue;

        int IResultsView.CompetitionId => Convert.ToInt16(CompetitionsGridView.SelectedRow.Cells[1].Text);

        public string SearchField => FindResults_TextBox.Text;

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter = new ResultsViewPresenter(this);

            Presenter.Init();
        }

        protected void CompetitionsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CompetitionsGridView.PageIndex = e.NewPageIndex;
            CompetitionsGridView.DataBind();
        }

        protected void CompetitionsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompetitionsGridView.Visible = false;
            AgeGroup_List.Visible = true;
            AgeGroup_List.DataBind();
            Presenter.GetAllResults();
            ResultsGridView.DataBind();
            CompetitionSelect_Button.Visible = true;
            FindResults_Button.Visible = true;
            FindResults_TextBox.Visible = true;
        }

        protected void AgeGroup_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResultsGridView.DataSource = null;
            ResultsGridView.DataBind();
            Presenter.GetAllResults();
            ResultsGridView.DataBind();
        }

        protected void ResultsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ResultsGridView.PageIndex = e.NewPageIndex;
            ResultsGridView.DataBind();
        }

        protected void CompetitionSelect_Button_Click(object sender, EventArgs e)
        {
            ResultsGridView.DataSource = null;
            ResultsGridView.DataBind();
            AgeGroup_List.Visible = false;
            CompetitionsGridView.Visible = true;
            CompetitionSelect_Button.Visible = false;
            FindResults_Button.Visible = false;
            FindResults_TextBox.Visible = false;
        }

        protected void FindResults_Button_Click(object sender, EventArgs e)
        {
            ResultsGridView.DataSource = null;
            ResultsGridView.DataBind();
            Presenter.FindResults();
            if(ResultsGridView.DataSource != null)
            {
                ResultsGridView.DataBind();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Nerastas dalyvis.');", true);
            }
        }
    }
}