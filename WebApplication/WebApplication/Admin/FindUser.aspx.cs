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
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            popupEdit.Show();
        }

        protected void FindID_Click(object sender, EventArgs e)
        {
            if(PersonSurname.Text != string.Empty)
            {
                bindGridView();
            }
        }


        private void bindGridView()
        {
            //get connection string from web.config

            string strConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            DbContainer competitors = new DbContainer();
            List<Competitors> searched = competitors.Comp.ToList().Where(c => c.Surname.Equals(PersonSurname.Text)).ToList();

            try
            {
                GridView1.DataSource = searched;
                GridView1.DataBind();
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                myConnect.Close();
            }

        }


        protected void add_btn_Click(object sender, EventArgs e)
        {
            popupAdd.Show();
        }
        private ApplicationUser findUser()
        {
            try
            {
                using (ApplicationDbContext dbcontext = new ApplicationDbContext())
                {
                    return dbcontext.Users.Find(PersonSurname.Text);
                }
            }
            catch (Exception ex)
            {
                ErrorMessageEdit.Text = "Nepavyko rasti vartotojo";
                Trace.Write("Error occurred while searching for user: {0}", ex.ToString());
            }
            return null;
        }
      

        protected void remove_btn_Click(object sender, EventArgs e)
        {
            ApplicationUser user = findUser();
            if (user != null)
            {
                try
                {
                    using (ApplicationDbContext dbcontext = new ApplicationDbContext())
                    {
                        dbcontext.Users.Remove(dbcontext.Users.Where(usr => usr.Id == user.Id).Single());

                        dbcontext.SaveChanges();

                        GridView1.DataBind();

                        popupEdit.Hide();
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessageEdit.Text = "Nepavyko ištrinti vartotojo";
                    Trace.Write("Error occurred while deleting user: {0}", ex.ToString());
                }
            }
        }
        protected void submit_btn_Click(object sender, EventArgs e)
        {
            popupAdd.Show();
            if (createUser(roleDropListAdd.SelectedItem.Value))
            {
                popupAdd.Hide();
                GridView1.DataBind();
            }
        }
        private Boolean createUser(string role)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = new ApplicationUser() { UserName = email_tb.Text, Email = email_tb.Text, Role = role };

            IdentityResult result = manager.Create(user, passw_tb.Text);
            if (result.Succeeded)
            {
                manager.AddToRole(user.Id, role);
                return true;
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
                return false;
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
            DbContainer competitors = new DbContainer();
            List<Competitors> searched = competitors.Comp.ToList().Where(c => c.Surname.Equals(PersonSurname.Text)).ToList();
            Competitors toEdit = searched[GridView1.SelectedIndex];
            try
            {

                if (editName_tb.Text != null && editName_tb.Text != string.Empty)
                {
                    toEdit.Name = editName_tb.Text;
                }
                if (editSurname_tb.Text != null && editSurname_tb.Text != string.Empty)
                {
                    toEdit.Surname = editSurname_tb.Text;
                }
                if (editYear_tb.Text != null && editYear_tb.Text != string.Empty)
                {
                    toEdit.Year = Convert.ToDateTime(editYear_tb.Text);
                }
                if (editCity_tb.Text != null && editCity_tb.Text != string.Empty)
                {
                    toEdit.City = editCity_tb.Text;
                }
                if (editCity_tb.Text != null && editCity_tb.Text != string.Empty)
                {
                    toEdit.City = editCity_tb.Text;
                }
                if (editCountry_tb.Text != null && editCountry_tb.Text != string.Empty)
                {
                    toEdit.Country = editCountry_tb.Text;
                }

                toEdit.Gender = GenderDropListEdit.SelectedItem.Value;
                competitors.SaveChanges();
            }
            catch
            {

            }
        }
    }

}