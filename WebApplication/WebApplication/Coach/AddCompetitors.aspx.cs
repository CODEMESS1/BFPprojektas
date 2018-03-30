using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication.Coach
{
    public partial class AddCompetitors : System.Web.UI.Page
    {
        //visu sarasas
        List<Competitors> compList = new List<Competitors>();
        //atifiltruotas vienam treneriui
        List<Competitors> filteredList = new List<Competitors>();
        //Objektas su kuriuo bendraujame su DB lentele
        ContainerCompetitors competitors = new ContainerCompetitors();

        protected void Page_Load(object sender, EventArgs e)
        {
            //grazina visus dalyvius, juos atfiltruoja pagal treneri ir ikelia i gridview
            compList = competitors.Comp.ToList();

            filteredList = filterList(compList);
            GridView1.DataSource = filteredList;
            GridView1.DataBind();
        }

        //dabartinis user, tai bus trenerio id
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

        protected void add_btn_Click(object sender, EventArgs e)
        {
            popupAdd.Show();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //delete view event objektas grazia reiksmes IOrderedDictionary
            Competitors toRemove = new Competitors(e.Values[0].ToString(), e.Values[1].ToString(), e.Values[2].ToString(), e.Values[3].ToString(), e.Values[4].ToString(), e.Values[5].ToString(), e.Values[6].ToString(), e.Values[7].ToString());
            competitors.Comp.Remove(compList[e.RowIndex]);
            competitors.SaveChanges();
            compList = competitors.Comp.ToList();
            filteredList = filterList(compList);
            GridView1.DataSource = filteredList;
            GridView1.DataBind();
        }

        protected void create_btn_Click(object sender, EventArgs e)
        {
            //jei jau egzistuoja negalima irasyti
            if (Page.IsValid)
            {
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var editUser = manager.FindById(GetCurrent());
                Competitors competitor = new Competitors(name_tb.Text, surname_tb.Text, year_tb.Text, gender_radbtn.SelectedValue, city_tb.Text, country_tb.Text, editUser.Id);
                //jei neegzistuoja - !FALSE
                if (!(checkForExisting(competitor)))
                {
                    competitors.Comp.Add(competitor);
                    competitors.SaveChanges();
                    compList = competitors.Comp.ToList();
                    filteredList = filterList(compList);
                    GridView1.DataSource = filteredList;
                    GridView1.DataBind();
                }
                else
                {
                    ErrorMessage.Text = "Toks dalyvis jau egzistuoja";
                    popupAdd.Show();
                }
            }
            else
            {
                popupAdd.Show();
            }
        }

        //jei egzistuoja toks dalyvis grazina true
        private Boolean checkForExisting(Competitors comp)
        {
            foreach(Competitors c in compList)
            {
                if(c.Equals(comp))
                {
                    return true;
                }
            }
            return false;
        }

        protected void cancel_btn_Click(object sender, EventArgs e)
        {

        }
    }
}