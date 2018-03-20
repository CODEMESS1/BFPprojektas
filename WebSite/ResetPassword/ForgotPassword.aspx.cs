using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResetPassword_ForgotPassword : System.Web.UI.Page
{
    private const int passLength = 8;

    protected void Page_Load(object sender, EventArgs e)
    {
        //jei yra prisijungta, slaptazodzio atstatymo puslapis nepasiekiamas
        if (Session["adminSession"] != null || Session["officialSession"] != null || Session["coachSession"] != null)
        {
            Response.Redirect("/CantReachForm.aspx");
        }
    }

    protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        string CS = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spResetPassword", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramUsername = new SqlParameter("@UserName", txtUserName.Text);

            cmd.Parameters.Add(paramUsername);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (Convert.ToBoolean(rdr["ReturnCode"]))
                {
                    SendPasswordResetEmail(rdr["Email"].ToString(), txtUserName.Text);
                    lblMessage.Text = "Slaptažodis išsiųstas į jūsų elektroninį paštą";
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Vartotojas nerastas";
                }
            }
        }
    }

    private void SendPasswordResetEmail(string ToEmail, string UserName)
    {
        String randomPass = RandomString(passLength);
        if (changePasswordInDb(randomPass, UserName))
        {
            // MailMessage class is present is System.Net.Mail namespace
            MailMessage mailMessage = new MailMessage("codemess9@gmail.com", ToEmail);


            // StringBuilder class is present in System.Text namespace
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Dear " + UserName + ",<br/><br/>");
            sbEmailBody.Append("Please click on the following link to reset your password");
            sbEmailBody.Append("<br/>"); sbEmailBody.Append(randomPass);
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<b>Pragim Technologies</b>");

            mailMessage.IsBodyHtml = true;

            mailMessage.Body = sbEmailBody.ToString();
            mailMessage.Subject = "Your new Password";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "codemess9@gmail.com",
                Password = "tyu148148"
            };

            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }
    }

    private static byte[] sha256(string value)
    {
        SHA256 sha = SHA256Managed.Create();
        byte[] hashValue;
        UTF8Encoding objUtf8 = new UTF8Encoding();
        hashValue = sha.ComputeHash(objUtf8.GetBytes(value));
        return hashValue;
    }

    public static string RandomString(int length)
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public Boolean changePasswordInDb(string password, string username)
    {
        String base64string = Convert.ToBase64String(sha256(password));

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE dbo.VARTOTOJAS SET slaptazodis = + '" + base64string + "' WHERE prisijungimo_vardas='" + username + "'", conn);
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        return true;
    }

    protected void btnBackToStart_Click(object sender, EventArgs e)
    {
        Response.Redirect("/LogInFrom.aspx");
    }
}