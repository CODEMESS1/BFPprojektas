using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;
using System.Drawing;

public partial class LogInFrom : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void login_btn_Click(object sender, EventArgs e)
    {
        if (checkLogin())
        {
            //perkelia i admin page
            Server.Transfer("AdminPuslapis.aspx", true);
        }
    }

    private Boolean checkLogin()
    {
        Boolean isCorrect = false;
        //sql komanda parenka logina
        //string checkuser = "SELECT prisijungimo_vardas FROM VARTOTOJAS WHERE prisijungimo_vardas='" + username_tb.Text + "'";
        string checkuser = "SELECT prisijungimo_vardas FROM VARTOTOJAS WHERE prisijungimo_vardas='" + username_tb.Text + "'";
        //sql komanda slaptazodziui tikrinti
        string checkpass = "SELECT slaptazodis FROM VARTOTOJAS WHERE slaptazodis='" + password_tb.Text + "'";

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["VartotojaiConnectionString"].ConnectionString))
        {
            //grazinamai reiksmei is duomenu bazes saugoti, jei neranda grazins null
            object pass_response = new object();
            object username_response = new object();

            try
            {
                conn.Open();
                
                //iesko prisijungimo vardo iraso
                using (SqlCommand command_user = new SqlCommand(checkuser, conn))
                {
                    username_response = command_user.ExecuteScalar();
                }
                //iesko slaptazodzio iraso
                using (SqlCommand command_pass = new SqlCommand(checkpass, conn))
                {
                    pass_response = command_pass.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            //jei ne null, galima pasiversti i string ir palyginti su ivestais duomenimis i textfield'a
            if( pass_response != null && username_response != null)
            {
                //panaikina whitespace, nes DB grazina su
                string passString = pass_response.ToString().Replace(" ", "");
                string userString = pass_response.ToString().Replace(" ", "");

                if (passString.Equals(password_tb.Text) && userString.Equals(username_tb.Text))
                {
                    isCorrect = true;
                }
            }
        }
        return isCorrect;
    }

    protected void username_tb_TextChanged1(object sender, EventArgs e)
    {

    }

    protected void RememberMe_CheckedChanged(object sender, EventArgs e)
    {

    }
}
