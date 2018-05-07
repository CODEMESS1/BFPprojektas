using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Model;
using WebApplication.Models;
using WebApplication.Models.Objects;
using WebApplication.Presenter;

namespace WebApplication.Admin.Competition
{
    public partial class StartCompetition : Page, IStartCompetition
    {
        private StartCompetitionPresenter presenter;
        private string Result;

        public List<AgeGroupTypes> AgeGroupTypes { set => AgeGroup_DropDownList.DataSource = selectGroup_list.DataSource = value; }
        public List<CompetitorsWithSubgroups> Competitors { set => CompetitorsGridView.DataSource = value; }

        public string SelectedAgeGroup => AgeGroup_DropDownList.SelectedValue;

        public List<Models.Competition> Competitions { set => CompetitionsGridView.DataSource = value; }

        public int SelectedSubgroupCount => Convert.ToInt32(SubgroupsCount.SelectedValue);

        public int SelectedCompetitionId => Convert.ToInt32(CompetitionsGridView.SelectedRow.Cells[1].Text);

        List<Events> IStartCompetition.Events { set => selectEvent_list.DataSource = value; }

        public string SelectedAgeGroupForResult => selectGroup_list.SelectedValue;

        public int SelectedEventForResult => Convert.ToUInt16(selectEvent_list.SelectedValue);

        public List<LastEntries> LastEntries { set => LastEntries_Gridview.DataSource = value; }

        public LastEntries LastEntry {
            get {
                return new LastEntries(Convert.ToInt16(EnterId_tb.Text), "", "", selectEvent_list.SelectedItem.Text, Result);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new StartCompetitionPresenter(this);
            presenter.InitView();
            CompetitionsGridView.DataBind();
            SelectPopup.Show();
            if (!Page.IsPostBack)
            {
                ResultsUpdatePanel.Visible = false;
                time.Visible = false;
                count.Visible = false;
            }
        }

        protected void GenerateSubGroups_Click(object sender, EventArgs e)
        {
            SelectPopup.Hide();
            SelectPanel.Visible = false;
            CompetitorsGridView.DataSource = null;
            CompetitorsGridView.DataBind();
            presenter.SetAgeGroupSubgroupsCount();
            AgeGroup_DropDownList.Enabled = true;
            SubgroupsCount.Enabled = true;
            ScriptManager.RegisterStartupScript(this, GetType(), "AKey", "click();", true);
        }

        protected void GetCompetitorsInGroup_Click(object sender, EventArgs e)
        {
            presenter.GetByGroup();
            CompetitorsGridView.DataBind();
            GroupGridView(CompetitorsGridView.Rows, 0, 2);
            AgeGroup_DropDownList.Enabled = false;
            SubgroupsCount.Enabled = false;
            ScriptManager.RegisterStartupScript(this, GetType(), "AKey", "click();", true);
        }

        protected void CompetitionsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPopup.Hide();
            SelectPanel.Visible = false;
            CompetitorsGridView.DataBind();
            AgeGroup_DropDownList.DataBind();
            CompetitionPanel.Visible = true;
            ScriptManager.RegisterStartupScript(this, GetType(), "AKey", "click();", true);
        }

        protected void CompetitionsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CompetitionsGridView.PageIndex = e.NewPageIndex;
            CompetitorsGridView.DataBind();
        }

        protected void cancel_btn_Click(object sender, EventArgs e)
        {

        }


        void GroupGridView(GridViewRowCollection gvrc, int startIndex, int total)
        {
            if (total == 0) return;
            int i, count = 1;
            ArrayList lst = new ArrayList();
            lst.Add(gvrc[0]);
            var ctrl = gvrc[0].Cells[startIndex];
            for (i = 1; i < gvrc.Count; i++)
            {
                TableCell nextCell = gvrc[i].Cells[startIndex];
                if (ctrl.Text == nextCell.Text)
                {
                    count++;
                    nextCell.Visible = false;
                    lst.Add(gvrc[i]);
                }
                else
                {
                    if (count > 1)
                    {
                        ctrl.RowSpan = count;
                        GroupGridView(new GridViewRowCollection(lst), startIndex + 1, total - 1);
                    }
                    count = 1;
                    lst.Clear();
                    ctrl = gvrc[i].Cells[startIndex];
                    lst.Add(gvrc[i]);
                }
            }
            if (count > 1)
            {
                ctrl.RowSpan = count;
                GroupGridView(new GridViewRowCollection(lst), startIndex + 1, total - 1);
            }
            count = 1;
            lst.Clear();
        }

        protected void startCompetition_Click(object sender, EventArgs e)
        {
            CompetitionPanel.Visible = false;
            ResultsUpdatePanel.Visible = true;
            selectGroup_list.DataBind();
        }

        protected void saveCompetition_btn_Click(object sender, EventArgs e)
        {
            CompetitionPanel.Visible = true;
            ResultsUpdatePanel.Visible = false;
            ScriptManager.RegisterStartupScript(this, GetType(), "AKey", "click();", true);
        }

        protected void WriteResults_btn_Click(object sender, EventArgs e)
        {
            if(selectGroup_list.SelectedValue != null && selectEvent_list.SelectedValue != null)
            {
                if(GetEventType().Type.Equals("Time"))
                {
                    count.Visible = false;
                    time.Visible = true;
                }
                else
                {
                    count.Visible = true;
                    time.Visible = false;
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Pasirinkite grupę ir rungtį.');", true);
            }
        }

        protected void SelectGroup_btn_Click(object sender, EventArgs e)
        {
            if (presenter.GetEvents())
            {
                selectEvent_list.Enabled = true;
                selectEvent_list.DataBind();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Nėra sukurtų rungčių');", true);
            }
        }

        protected void EnterId_tb_TextChanged(object sender, EventArgs e)
        {

        }

        public EventTypes GetEventType()
        {
            return presenter.GetEventType();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CompetitorsGridView.DataSource = null;
            CompetitorsGridView.DataBind();
            AgeGroup_DropDownList.Enabled = true;
            SubgroupsCount.Enabled = true;
            ScriptManager.RegisterStartupScript(this, GetType(), "AKey", "click();", true);
        }

        protected void ResultsTime_btn_Click(object sender, EventArgs e)
        {
            Result = ResultsTimeMinute_TextBox.Text + ":" + ResultsTimeSeconds_TextBox.Text + "," + ResultsTimeMili_TextBox.Text;
            presenter.BindLastEntry();
            LastEntries_Gridview.DataBind();
        }

        protected void ResultsCount_btn_Click(object sender, EventArgs e)
        {
            Result = TextBox3.Text;
            presenter.BindLastEntry();
            LastEntries_Gridview.DataBind();
        }
    }
}