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
        //jei true, tai vartotojas rastas DB, toliau parenkamas vartotojo tipas
        if (checkLogin())
        {
            switch(CheckAccountType())
            {
                case "A":
                    Session["userSession"] = username_tb.Text;
                    Response.Redirect("AdminPuslapis.aspx");
                    break;
                case "O":
                    //perkelti i teisejo puslapi
                    break;
                case "C":
                    //perkelti i trenerio puslapi
                    break;
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Prisijungimas nepavyko" + "');", true);
        }
    }

    private string CheckAccountType()
    {
        //admin, coach, official
        string[] AccTypes = new string[] { "A", "C", "O" };
        string command = "SELECT prisijungimo_vardas FROM VARTOTOJAS WHERE role='";

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            try
            {
                conn.Open();

                //patikrina kokia vartotojo role ir grazina jei randa
                foreach (string type in AccTypes)
                {
                    String comm = command + type + "'";
                    SqlCommand command_user = new SqlCommand(comm, conn);

                    if (command_user.ExecuteScalar() != null)
                    {
                        return type;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        return null;
    }

    private Boolean checkLogin()
    {
        Boolean isCorrect = false;
        string response = "";
        string query = "SELECT COUNT(*) FROM VARTOTOJAS WHERE prisijungimo_vardas='" + username_tb.Text + "' and slaptazodis='" + password_tb.Text + "'";
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
            con.Open();

            SqlCommand comm = new SqlCommand(query, con);
            if(comm.ExecuteScalar().ToString().Equals("1"))
            {
                isCorrect = true;
            }
            con.Close();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.ToString());
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
