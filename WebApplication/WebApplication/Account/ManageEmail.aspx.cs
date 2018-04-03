using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace WebApplication.Account
{
    public partial class ManageEmail : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();


            if (!IsPostBack)
            {
                // Determine the sections to render
                if (HasPassword(manager))
                {
                    changeEmailholder.Visible = true;
                }
                else
                {
                    changeEmailholder.Visible = false;
                }

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");
                }
            }
        }

        protected void ChangeEmail_Click(object sender, EventArgs e)
        {

            if (IsValid)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                var user = manager.FindById(User.Identity.GetUserId());

                var result = manager.FindByEmail(CurrentEmail.Text);
                
                if(result == null)
                {
                    //error message i label, kad ne
                }
                else if (user.Email.Equals(result.Email))
                {
                    user.EmailConfirmed = false;
                    user.Email = NewEmail.Text;
                    user.UserName = NewEmail.Text;
                    manager.Update(user);
                    string code = manager.GenerateEmailConfirmationToken(user.Id);
                    string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                    manager.SendEmail(user.Id, "Paskyros patvirtinimas", "Norėdami patvirtinti paskyrą spauskite <a href=\"" + callbackUrl + "\">čia</a>.");

                    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
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
    }
}



