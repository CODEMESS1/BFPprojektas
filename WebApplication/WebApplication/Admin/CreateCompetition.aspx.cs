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
    public partial class CreateCompetition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
        protected void GridView1_EditIndexChanged(object sender, EventArgs e)
        {
            popupEdit.Show();
        }
        protected void add_btn_Click(object sender, EventArgs e)
        {
            popupAdd.Show();
        }
        protected void submit_btn_Click(object sender, EventArgs e)
        {
            popupAdd.Show();
            createCompetition();
            popupAdd.Hide();
            GridView1.DataBind();
        }
        private void createCompetition()
        {
            using (ApplicationDbContext dbcontext = new ApplicationDbContext())
            {
                try
                { 
                    var compet = new Competition() { Name = addName_txt.Text, Location = addPlace_txt.Text, Address = addAdress_txt.Text, Date = Convert.ToDateTime(AddDate_txt.Text), RegistrationStartDate = Convert.ToDateTime(addRegStart_txt.Text), RegistrationEndDate = Convert.ToDateTime(addRegEnd_txt.Text), Registration = (addIsRegOpen_ckbox.SelectedValue == "Open") ? true : false };
                    DbContainer cp = new DbContainer();
                    List<Competition> cpList = cp.Competition.ToList();
                    cpList.Add(compet);
                    
                }
                catch(Exception ex)
                {
                    ErrorMessageEdit.Text = "Privaloma Irasyti visus laukus";
                    Trace.Write("Error occurred while deleting competition: {0}", ex.ToString());
                    
                }
            }

        }
        protected void remove_btn_Click(object sender, EventArgs e)
        {
            CompetitionContainer cp = new CompetitionContainer();
            try
            {
                using (ApplicationDbContext dbcontext = new ApplicationDbContext())
                {
                   

                    dbcontext.SaveChanges();

                    GridView1.DataBind();

                    popupEdit.Hide();
                }
            }
            catch (Exception ex)
            {
                ErrorMessageEdit.Text = "Nepavyko ištrinti varžybų";
                Trace.Write("Error occurred while deleting competition: {0}", ex.ToString());
            }

        }
        protected void edit_btn_Click(object sender, EventArgs e)
        {
            makeEdit();
            GridView1.DataBind();
            popupEdit.Hide();
        }
        private void makeEdit()
        {
            DbContainer cp = new DbContainer();
            List<Competition> cpList = cp.Competition.ToList();
            var comp = cpList.Where(c => c.Id.Equals(GridView1.SelectedRow.Cells[1].Text));
            var temp = comp.First();
            try
            {
                using (ApplicationDbContext dbcontext = new ApplicationDbContext())
                {

                    if (editName_tb.Text != null && editName_tb.Text != string.Empty)
                    {
                        temp.Name = editName_tb.Text;
                    }
                    if (editLocation_tb.Text != null && editLocation_tb.Text != string.Empty)
                    {
                        temp.Location = editLocation_tb.Text;
                    }
                    if (editAddress_tb.Text != null && editAddress_tb.Text != string.Empty)
                    {
                        temp.Address = editAddress_tb.Text;
                    }
                    if (editDate_tb.Text != null && editDate_tb.Text != string.Empty)
                    {
                        temp.Date = Convert.ToDateTime(editDate_tb.Text);
                    }
                    if (editRegistrationStartDate_tb.Text != null && editRegistrationStartDate_tb.Text != string.Empty)
                    {
                        temp.RegistrationStartDate = Convert.ToDateTime(editRegistrationStartDate_tb.Text);
                    }
                    if (editRegistrationEndDate_tb.Text != null && editRegistrationEndDate_tb.Text != string.Empty)
                    {
                        temp.RegistrationEndDate = Convert.ToDateTime(editRegistrationEndDate_tb.Text);
                    }
                    bool isChecked = false;


                    if (editisRegOpen_ckbox.SelectedValue.Equals("Open"))
                        isChecked = true;

                    else
                        isChecked = false;

                    temp.Registration = isChecked;
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ErrorMessageEdit.Text = "Nepavyko pakeisti varžybų duomenų";
                Trace.Write("Error occurred while editing competition: {0}", ex.ToString());
            }

        }
    }
}