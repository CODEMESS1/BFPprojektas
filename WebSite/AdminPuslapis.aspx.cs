using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//test
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminSession"] == null)
        {
            Response.Redirect("LogInFrom.aspx");
        }
    }

    protected void logout_btn_Click(object sender, EventArgs e)
    {
        Session.Remove("adminSession");
        Response.Redirect("LogInFrom.aspx");
    }
}