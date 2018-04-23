using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication.Admin.Competition
{
    public partial class RegisterCompetitorsAdmin : System.Web.UI.Page
    {
        private List<Competitors> filteredList = new List<Competitors>();
        private List<Competitors> competitorsList = new List<Competitors>();
        private CompetitorsContainer competitorsContainer = new CompetitorsContainer();
        private CompetitionContainer container = new CompetitionContainer();
        private DbContainer dbContainer = new DbContainer();
        private List<Models.Competition> competitions = new List<Models.Competition>();
        private string coachID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            competitions = container.Competitions.Where(c => c.Registration == true).ToList();
            competitorsList = competitorsContainer.Comp.ToList();
            filteredList = filterList(competitorsList);
            if (!Page.IsPostBack)
            {
                //load varzybu listview
                competitions_gridview.DataSource = competitions;
                competitions_gridview.DataBind();

                coachID = GetCurrent();
                //atfiltruojam tik trenerio dalyvius
                GridView1.DataSource = filteredList;
                GridView1.DataBind();
            }
        }



        public string GetCurrent()
        {
            return User.Identity.GetUserId();
        }

        //grazina tik trenerio, kuris perziuri dalyviu sarasa
        public List<Competitors> filterList(List<Competitors> competitors)
        {
            string currentID = GetCurrent();
            List<Competitors> filteredList = competitors.Where(c => c.CoachId.Equals(currentID)).ToList();
            return filteredList;
        }

        //pazymi visus dalyvius (visus checkbox)
        protected void selectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GridView1.Rows[i].FindControl("checkBox");
                if (cb != null && !cb.Checked)
                {
                    cb.Checked = true;
                }
            }
        }

        //prideda pasirinktus dalyvius i DB objekta jei jie dar nera prideti
        private void addToCompetition()
        {
            int selectedCompetitionId = Convert.ToInt16(competitions_gridview.SelectedRow.Cells[3].Text);
            List<CompetitorsInCompetitions> registeredCompetitors = GetSelection(selectedCompetitionId);
            foreach(CompetitorsInCompetitions c in registeredCompetitors)
            {
                if(!dbContainer.CompetitorsInCompetitions.ToList().Contains(c))
                {
                    dbContainer.CompetitorsInCompetitions.Add(c);
                    container.SaveChanges();
                }
            }
            
        }

        //gauna list'a dalyviu, kurie pasirinkti (pazymeti checkbox prie ju)
        private List<CompetitorsInCompetitions> GetSelection(int competitionId)
        {
            List<CompetitorsInCompetitions> comp = new List<CompetitorsInCompetitions>();
            for(int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox) GridView1.Rows[i].FindControl("checkBox");
                if (cb != null && cb.Checked)
                {
                    CompetitorsInCompetitions temp = new CompetitorsInCompetitions();
                    temp.CompetitionId = competitionId;
                    temp.CompetitorId = filteredList[i].Id;
                    comp.Add(temp);
                }
            }
            return comp;
        }

        //kai varzybu gridview pasirenki varzybas ismeta registracijos popup
        protected void competitions_gridview_SelectedIndexChanged1(object sender, EventArgs e)
        {
            popUpRegister.Show();
        }

        //jei paspaudzia registruoti dalyvius
        protected void registerComp_btn_Click(object sender, EventArgs e)
        {
            addToCompetition();
            popUpRegister.Hide();
            dbContainer.CompetitorsInCompetitions.ToList();
        }

        protected void cancel_btn_Click(object sender, EventArgs e)
        {
            popUpRegister.Hide();
        }
    }
}