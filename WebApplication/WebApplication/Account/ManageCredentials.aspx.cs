using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using WebApplication.Models;

namespace WebApplication.Account
{
    public partial class ManageCredentials : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());

            if (user.Name != null)
            {
                name.Text = user.Name;
                name.ReadOnly = true;
            }
            if (user.Surname != null)
            {
                SurnameText.Text = user.Surname;
                SurnameText.ReadOnly = true;
            }
            if (user.Year != null)
            {
                BirthYear.TextMode = System.Web.UI.WebControls.TextBoxMode.SingleLine;
                BirthYear.Text = user.Year.ToString();
                BirthYear.Enabled = false;
            }

            if (!IsPostBack)
            {
                // Determine the sections to render

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");
                }
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }


        protected void SetPhoneNumber_Click(object sender, EventArgs e)
        {
            //[TODO] tikrinti ar teisingas formatas
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());

            if (user.PhoneNumber == null)
            {
                user.PhoneNumber = PhoneNumberTextBox.Text;
            }
        }

        protected void Surname_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());

            if (user.Surname == null)
            {
                user.Surname = SurnameText.Text;
                manager.Update(user);
                SurnameText.ReadOnly = true;
            }
        }

        protected void Name_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());

            if (user.Name == null)
            {
                user.Name = name.Text;
                manager.Update(user);
                name.ReadOnly = true;

            }
        }

        protected void SetDate_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());

            //reik i db metus idet

            if (user.Year == null)
            {
                BirthYear.Text = user.Name;
                manager.Update(user);
                BirthYear.ReadOnly = true;
            }

        }
    }
}