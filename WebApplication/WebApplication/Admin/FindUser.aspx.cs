using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication.Admin
{
    public partial class FindUser : System.Web.UI.Page
    {
        private CompetitorsContainer competitorsContainer = new CompetitorsContainer();
        private List<Competitors> competitors = new List<Competitors>();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexInTable = GridView1.SelectedIndex;
            int compId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            Competitors competitorToEdit = competitorsContainer.GetCompetitor(compId);
            
            editName_tb.Text = competitorToEdit.Name;
            editSurname_tb.Text = competitorToEdit.Surname;
            editYear_tb.Text = competitorToEdit.Year.ToString();
            editCity_tb.Text = competitorToEdit.City;
            editCountry_tb.Text = competitorToEdit.Country;

            popupEdit.Show();
        }

        protected void FindID_Click(object sender, EventArgs e)
        {
            if (textboxvalidator.IsValid)
            {
                int id = Convert.ToInt32(IdTextBox.Text);
                List<Competitors> competitor = new List<Competitors>();
                Competitors competitorToAdd = competitorsContainer.GetCompetitor(id);

                if (competitorToAdd != null)
                {
                    competitor.Add(competitorToAdd);
                    GridView1.DataSource = competitor;
                    GridView1.DataBind();
                }
                else
                {
                    searcherror_lbl.Text = "Nepavyko rasti vartotojo";
                }
            }
        }


        protected void add_btn_Click(object sender, EventArgs e)
        {
            DropDownList1.DataValueField = "Id";
            DropDownList1.DataTextField = "FullName";
            DropDownList1.DataSource = GetCoachesList();
            DropDownList1.DataBind();
            popupAdd.Show();
        }

        private List<AspNetUsers> GetCoachesList()
        {
            AspUsersContainer Users = new AspUsersContainer();
            List<AspNetUsers> coaches = Users.aspNetUsers.Where(u => u.Role.Equals("Coach")).ToList();
            return coaches;
        }

        protected void remove_btn_Click(object sender, EventArgs e)
        {
            int compId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            competitorsContainer.RemoveCompetitorFromCompetitors(compId);
        }

        protected void submit_btn_Click(object sender, EventArgs e)
        {
            Page.Validate("addcomp");
            if (Page.IsValid)
            {
                string coachId = DropDownList1.SelectedItem.Value;
                Competitors competitor = new Competitors(name_tb.Text, surname_tb.Text, year_tb.Text, gender_radbtn.SelectedValue, city_tb.Text, country_tb.Text, coachId);
                competitorsContainer.AddCompetitorToCompetitors(competitor);
            }
            else
            {
                popupAdd.Show();
            }
        }

        protected void edit_btn_Click(object sender, EventArgs e)
        {
            makeEdit();
            popupEdit.Hide();
        }

        private void makeEdit()
        {
            Competitors toEdit = new Competitors();
            int compId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            toEdit.Id = compId;
            toEdit.Name = editName_tb.Text;
            toEdit.Surname = editSurname_tb.Text;
            toEdit.Year = Convert.ToDateTime(editYear_tb.Text);
            toEdit.City = editCity_tb.Text;
            toEdit.Country = editCountry_tb.Text;
            toEdit.Gender = GenderDropListEdit.SelectedValue;

            bool isCahnged = competitorsContainer.ChangeCompetitorValues(toEdit);
            if(isCahnged == true)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Sėkmingai pakeista');", true);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Pakeisti informacijos napavyko');", true);
            }
            GridView1.DataBind();
        }

        protected void searchsurname_btn_Click(object sender, EventArgs e)
        {
            if (SurnameValidator.IsValid)
            {
                List<Competitors> competitors = competitorsContainer.CompetitorBySurname(SurnameTextBox.Text);

                if (competitors.Count != 0)
                {
                    GridView1.DataSource = competitors;
                    GridView1.DataBind();
                }
                else
                {
                    searcherror_lbl.Text = "Nepavyko rasti vartotojo";
                }
            }
        }
    }

}