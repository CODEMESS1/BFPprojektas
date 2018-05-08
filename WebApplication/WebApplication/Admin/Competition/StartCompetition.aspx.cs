﻿using System;
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

        private int IdForCalc
        {
            get
            {
                if (ViewState["Id"] != null)
                    return (int)ViewState["Id"];
                else
                    return 0;
            }
            set
            {
                ViewState["Id"] = value;
            }
        }

        private List<Models.Objects.LastEntries> LastEntries
        {
            get
            {
                if (ViewState["list"] != null)
                    return (List<Models.Objects.LastEntries>)ViewState["list"];
                else
                    return LastEntries = new List<LastEntries>();
            }
            set
            {
                ViewState["list"] = value;
            }
        }

        public List<AgeGroupTypes> AgeGroupTypes { set { CalculateResultsGroup_list.DataSource = AgeGroup_DropDownList.DataSource = selectGroup_list.DataSource = value; } } 
        public List<CompetitorsWithSubgroups> Competitors { set {
                if (value.Count != 0)
                {
                    CompetitorsGridView.DataSource = value;
                }
                else
                {
                    CompetitorsGridView.DataSource = null;
                }
                    } }

        public string SelectedAgeGroup => AgeGroup_DropDownList.SelectedValue;

        public List<Models.Competition> Competitions { set => CompetitionsGridView.DataSource = value; }

        public int SelectedSubgroupCount => Convert.ToInt32(SubgroupsCount.SelectedValue);

        public int SelectedCompetitionId => Convert.ToInt32(CompetitionsGridView.SelectedRow.Cells[1].Text);

        List<Events> IStartCompetition.Events { set => selectEvent_list.DataSource = value; }

        public int SelectedAgeGroupForResult => Convert.ToInt16(selectGroup_list.SelectedValue);

        public int SelectedEventForResult => Convert.ToUInt16(selectEvent_list.SelectedValue);

        public LastEntries LastEntry {
            get {
                return new LastEntries(Convert.ToInt16(EnterId_tb.Text), Competitor_tb.Text.Split(',')[0], Competitor_tb.Text.Split(',')[1], selectEvent_list.SelectedItem.Text, Result);
            }
        }

        public Competitors Competitor { set {
                Competitor_tb.Text = value.ToString();
            } }

        public int CompetitorId => Convert.ToInt16(EnterId_tb.Text);

        string IStartCompetition.Result => this.Result;

        public string AgeGroupForCalculation => CalculateResultsGroup_list.SelectedValue;

        public List<Results> Results { set { Results_GridView.DataSource = value; Results_GridView.DataBind(); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new StartCompetitionPresenter(this);
            presenter.InitView();
            CompetitionsGridView.DataBind();
            if (!Page.IsPostBack)
            {
                CalculateResultsGroup_list.DataBind();
                ResultsUpdatePanel.Visible = false;
                time.Visible = false;
                count.Visible = false;
            }
        }

        protected void GenerateSubGroups_Click(object sender, EventArgs e)
        {
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
            if (CompetitorsGridView.DataSource != null)
            {
                CompetitorsGridView.DataBind();
                GroupGridView(CompetitorsGridView.Rows, 0, 2);
                AgeGroup_DropDownList.Enabled = false;
                SubgroupsCount.Enabled = false;
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "AKey", "click();", true);

        }

        protected void CompetitionsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPanel.Visible = false;
            CompetitorsGridView.DataBind();
            AgeGroup_DropDownList.DataBind();
            CompetitionPanel.Visible = true;
            SelectCompetitionBtn.Visible = true;
            ScriptManager.RegisterStartupScript(this, GetType(), "AKey", "click();", true);
        }

        protected void CompetitionsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CompetitionsGridView.PageIndex = e.NewPageIndex;
            CompetitorsGridView.DataBind();
        }

        protected void SelectCompetitionBtn_Click(object sender, EventArgs e)
        {
            SelectPanel.Visible = true;
            CompetitionPanel.Visible = false;
            SelectCompetitionBtn.Visible = false;
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
            if(selectGroup_list.SelectedValue != null && selectEvent_list.SelectedItem != null)
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
            BindLastEntry();
            LastEntries_Gridview.DataBind();
            presenter.AddResult();
        }

        protected void ResultsCount_btn_Click(object sender, EventArgs e)
        {
            Result = TextBox3.Text;
            BindLastEntry();
            LastEntries_Gridview.DataBind();
            presenter.AddResult();
        }

        private void BindLastEntry()
        {
            if (LastEntries.Count == 5)
            {
                LastEntries.RemoveAt(0);
                LastEntries.Add(LastEntry);
                LastEntries_Gridview.DataSource = LastEntries;
            }
            else
            {
                LastEntries.Add(LastEntry);
                LastEntries_Gridview.DataSource = LastEntries;
            }
        }

        protected void FindById_btn_Click(object sender, EventArgs e)
        {
            if (presenter.CompetitorForEntry() != null)
            {
                Competitor_tb.DataBind();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Tokio dalyvio ID nėra');", true);
            }
        }

        protected void Calculate_btn_Click(object sender, EventArgs e)
        {
            CalculateResultsGroup_list.SelectedIndex = IdForCalc;
            Results_GridView.DataSource = null;
            Results_GridView.DataBind();
            presenter.CalculateSelected();
            if(Results_GridView.DataSource == null)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Nėra rezultatų arba dalyvių šios grupės');", true);
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "AKey", "clickPostBackStart();", true);
        }

        protected void CalculateResultsGroup_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            IdForCalc = Convert.ToInt16(CalculateResultsGroup_list.SelectedIndex);
            ScriptManager.RegisterStartupScript(this, GetType(), "AKey", "clickPostBackStart();", true);
        }
    }
}