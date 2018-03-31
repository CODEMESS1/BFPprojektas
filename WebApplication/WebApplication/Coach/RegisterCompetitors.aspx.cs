using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication.Coach
{
    public partial class RegisterCompetitors : System.Web.UI.Page
    {
        private List<Competitors> filteredList = new List<Competitors>();
        private List<Competitors> competitorsList = new List<Competitors>();
        private ContainerCompetitors container = new ContainerCompetitors();
        private string coachID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            coachID = GetCurrent();
            //atfiltruojam tik trenerio dalyvius
            competitorsList = container.Comp.ToList();
            filteredList = filterList(competitorsList);
            popUpRegister.Show();
            competitors_lstbox.DataSource = filteredList;
            competitors_lstbox.DataBind();
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //[TODO] pagal pasirinktas varzybas leidzia suregistruori dalyvius
        }

        protected void selectAll_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < competitors_lstbox.Items.Count; i++)
            {
                competitors_lstbox.Items[i].Selected = true;
            }
        }

        protected void registerComp_btn_Click(object sender, EventArgs e)
        {
            //[TODO]issaugo registracija ir uzdaro popup 
            popUpRegister.Hide();
        }
    }
}