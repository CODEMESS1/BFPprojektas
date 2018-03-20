using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResetPassword_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminSession"] == null && Session["officialSession"] == null && Session["coachSession"] == null)
        {
            Response.Redirect("/LogInFrom.aspx");
        }
    }

    protected void changepass_btn_Click(object sender, EventArgs e)
    {
        if (checkOldPassword() && newpass_tb.Text.Equals(newver_tb.Text))
        {
            string CS = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                String pass = Convert.ToBase64String(sha256(newpass_tb.Text));
                cmd = new SqlCommand("UPDATE dbo.VARTOTOJAS SET slaptazodis='" + pass + "' WHERE prisijungimo_vardas='" + getSessionUser() + "'", con);
                cmd.ExecuteScalar();
                message_lbl.Text = "Sėkmingai pakeistas";
            }
        }
        else
        {
            if(!checkOldPassword())
            {
                message_lbl.Text = "Neteisingas senas slaptažodis";
            }
            else if(!newpass_tb.Text.Equals(newver_tb.Text))
            {
                message_lbl.Text = "Neteisingas naujas slaptažodis";
            }
            else
            {
                message_lbl.Text = "Pakeitimas nepavyko";
            }
        }
    }

    private Boolean checkOldPassword()
    {
        string oldPass = oldpass_tb.Text;
        byte[] hashedPass = sha256(oldPass);
        Boolean isCorrect = false;
        string query = "SELECT COUNT(*) FROM VARTOTOJAS WHERE prisijungimo_vardas='" + getSessionUser() + "' and slaptazodis='" + Convert.ToBase64String(hashedPass) + "'";
        try
        {
            //db connection'as
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
            con.Open();

            //sql query parenkanti reiksmes is lenteles
            SqlCommand comm = new SqlCommand(query, con);
            //jei randa vartotojo duomenis grazina 1
            if (comm.ExecuteScalar().ToString().Equals("1"))
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

    private byte[] sha256(string value)
    {
        SHA256 sha = SHA256Managed.Create();
        byte[] hashValue;
        UTF8Encoding objUtf8 = new UTF8Encoding();
        hashValue = sha.ComputeHash(objUtf8.GetBytes(value));
        return hashValue;
    }

    //tikrina kokia sesija ir grazina sesijos username
    private string getSessionUser()
    {
        string username = "";
        if(Session["adminSession"] != null)
        {
            username = Session["adminSession"].ToString();
        }
        else if (Session["officialSession"] != null)
        {
            username = Session["officialSession"].ToString();
        }
        else if (Session["coachSession"] != null)
        {
            username = Session["coachSession"].ToString();
        }
        return username;
    }

    private void getPageBack()
    {
        if (Session["adminSession"] != null)
        {
            Response.Redirect("/Administration/MainAdminForm.aspx");
        }
        if (Session["officialSession"] != null)
        {
            Response.Redirect("/Official/OfficialPage.aspx");
        }
        if (Session["coachSession"] != null)
        {
            Response.Redirect("/Coach/CoachPage.aspx");
        }
    }

    protected void back_btn_Click(object sender, EventArgs e)
    {
        getPageBack();
    }
}