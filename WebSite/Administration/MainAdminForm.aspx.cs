using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_MainAdminForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminSession"] == null)
        {
            Response.Redirect("/LogInFrom.aspx");
        }
    }

    protected void logout_btn_Click(object sender, EventArgs e)
    {
        Session.Remove("adminSession");
        Response.Redirect("/LogInFrom.aspx");
    }

    protected void editusers_btn_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Administration/AdminPuslapis.aspx");
    }

    protected void changepass_btn_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ResetPassword/ChangePassword.aspx");
    }
}