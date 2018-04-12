using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication.Coach
{
    public partial class AddCompetitors : System.Web.UI.Page
    {
        //visu sarasas
        //atifiltruotas vienam treneriui
        List<Competitors> filteredList = new List<Competitors>();
        //Objektas su kuriuo bendraujame su DB lentele
        CompetitorsContainer competitors = new CompetitorsContainer();

        protected void Page_Load(object sender, EventArgs e)
        {
            //trenerio id
            string id = GetCurrent();
            filteredList = competitors.getFilteredCompetitors(id);
            GridView1.DataSource = filteredList;
            GridView1.DataBind();
        }

        //dabartinis user, tai bus trenerio id
        public string GetCurrent()
        {
            return User.Identity.GetUserId();
        }

        protected void add_btn_Click(object sender, EventArgs e)
        {
            popupAdd.Show();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(e.Values[0]);
            filteredList = competitors.RemoveCompetitorFromCompetitors(id);

            GridView1.DataSource = filteredList;
            GridView1.DataBind();
        }

        protected void create_btn_Click(object sender, EventArgs e)
        {
            //jei jau egzistuoja negalima irasyti
            if (Page.IsValid)
            {
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                //trenerio ID
                var editUser = manager.FindById(GetCurrent());
                Competitors competitor = new Competitors(name_tb.Text, surname_tb.Text, year_tb.Text, gender_radbtn.SelectedValue, city_tb.Text, country_tb.Text, editUser.Id);
                //jei neegzistuoja - !FALSE
                if (!(competitors.CompetitorExists(competitor)))
                {
                    filteredList = competitors.AddCompetitorToCompetitors(competitor);
                    GridView1.DataSource = filteredList;
                    GridView1.DataBind();
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Toks dalyvis jau egzistuoja');", true);
                    popupAdd.Show();
                }
            }
            else
            {
                popupAdd.Show();
            }
        }

        protected void cancel_btn_Click(object sender, EventArgs e)
        {

        }

        protected void year_tb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(year_tb.Text) > DateTime.Now)
                {
                    year_tb.Text = "";
                }
            }
            catch
            {
                year_tb.Text = "";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Neteisingas datos laukas');", true);
            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
    }
}