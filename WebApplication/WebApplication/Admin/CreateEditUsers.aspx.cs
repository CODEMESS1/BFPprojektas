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
    public partial class CreateEditUsers : Page
    {

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            popupEdit.Show();
        }

        private void makeEdit()
        { 
            ApplicationUser user = getUser();
            if (user != null)
            {
                try
                {
                    using (ApplicationDbContext dbcontext = new ApplicationDbContext())
                    {
                        string UserID = GridView1.SelectedRow.Cells[1].Text;
                        var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbcontext));
                        var editUser = manager.FindById(UserID);

                        if (editEmail_tb.Text != null && editEmail_tb.Text != string.Empty)
                        {
                            editUser.EmailConfirmed = false;
                            editUser.Email = editEmail_tb.Text;
                        }
                        if (editpass_tb.Text != null && editpass_tb.Text != string.Empty)
                        {
                            PasswordHasher passwordHasher = new PasswordHasher();
                            editUser.PasswordHash = passwordHasher.HashPassword(editpass_tb.Text);
                        }
                        if (name_tb.Text != null && name_tb.Text != string.Empty)
                        {
                            editUser.Name = name_tb.Text;
                        }
                        if (surname_tb.Text != null && surname_tb.Text != string.Empty)
                        {
                            editUser.Surname = surname_tb.Text;
                        }

                        string[] userRoles = manager.GetRoles(UserID).ToArray();
                        manager.RemoveFromRoles(UserID, userRoles);
                        manager.AddToRole(UserID, roleDropListEdit.SelectedItem.Value);
                        editUser.Role = roleDropListEdit.SelectedItem.Value;
                        
                        manager.Update(editUser);
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessageEdit.Text = "Nepavyko pakeisti vartotojo duomenų";
                    Trace.Write("Error occurred while editing user: {0}", ex.ToString());
                }
            }
        }

        private Boolean createUser(string role)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = new ApplicationUser() { UserName = email_tb.Text, Email = email_tb.Text, Role = role};

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

        protected void add_btn_Click(object sender, EventArgs e)
        {
            popupAdd.Show();
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

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void edit_btn_Click(object sender, EventArgs e)
        {
            makeEdit();
            GridView1.DataBind();
            popupEdit.Hide();
        }

        private ApplicationUser getUser()
        {
            try
            {
                using (ApplicationDbContext dbcontext = new ApplicationDbContext())
                {
                    string UserID = GridView1.SelectedRow.Cells[1].Text;
                    return dbcontext.Users.Find(UserID);
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
            ApplicationUser user = getUser();
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
    }
}