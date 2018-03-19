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
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

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
          //A - admin, O - official (teisejas), C - coach (treneris)
            switch (CheckAccountType())
            {
                case "A":
                    Session["adminSession"] = username_tb.Text;
                    Response.Redirect("AdminPuslapis.aspx");
                    break;
                case "O":
                    Session["officialSession"] = username_tb.Text;
                    Response.Redirect("OfficialPage.aspx");
                    break;
                case "C":
                    Session["coachSession"] = username_tb.Text;
                    Response.Redirect("CoachPage.aspx");
                    break;
            }
        }
        else
        {
            RequiredFieldValidator1.IsValid = false;
        }
    }

    //tikrina duomenu bazeje ar admin'as - A, ar teisejas - O, ar treneris - C
    private string CheckAccountType()
    {
        string command = "SELECT role FROM VARTOTOJAS WHERE prisijungimo_vardas='" + username_tb.Text + "'";

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            try
            {
                conn.Open();

                SqlCommand command_user = new SqlCommand(command, conn);

                string response = command_user.ExecuteScalar().ToString();
                return response.Replace(" ", "");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        return null;
    }
    //tikrina ar pateikti duomenys egzistuoja duomenu bazeje, grazina true, jei egzistuoja
    private Boolean checkLogin()
    {
        Boolean isCorrect = false;
        byte[] hashedPass = sha256(password_tb.Text);

        string query = "SELECT COUNT(*) FROM VARTOTOJAS WHERE prisijungimo_vardas='" + username_tb.Text + "' and slaptazodis='" + Convert.ToBase64String(hashedPass) + "'";
        try
        {
            //db connection'as
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
            con.Open();

            //sql query parenkanti reiksmes is lenteles
            SqlCommand comm = new SqlCommand(query, con);
            //jei randa vartotojo duomenis grazina 1
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

    private byte[] sha256(string value)
    {
        SHA256 sha = SHA256Managed.Create();
        byte[] hashValue;
        UTF8Encoding objUtf8 = new UTF8Encoding();
        hashValue = sha.ComputeHash(objUtf8.GetBytes(value));
        return hashValue;
    }

    protected void forgot_btn_Click(object sender, EventArgs e)
    {
        Response.Redirect("ResetPassword/ForgotPassword.aspx");
    }
}
