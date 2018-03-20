using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//test
public partial class _Default : System.Web.UI.Page
{
    private string strConnString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminSession"] == null)
        {
            Response.Redirect("LogInFrom.aspx");
        }
        if (!IsPostBack)
        {
            this.BindData();
        }
    }

    protected void logout_btn_Click(object sender, EventArgs e)
    {
        Session.Remove("adminSession");
        Response.Redirect("LogInFrom.aspx");
    }

    private void BindData()
    {
        string strQuery = "select Vartotojo_id,Vardas,Pavarde,Gimimo_metai,Elektroninis_pastas,Prisijungimo_vardas,Slaptazodis,Valstybe,Miestas,Role" +
                           " from VARTOTOJAS";
        SqlCommand cmd = new SqlCommand(strQuery);
        GridView1.DataSource = GetData(cmd);
        GridView1.DataSourceID = null;
        GridView1.DataBind();
    }

    private DataTable GetData(SqlCommand cmd)
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
        }
    }
    protected void Edit(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            txtUserID.ReadOnly = true;
            txtUserID.Text = row.Cells[0].Text;
            txtName.Text = row.Cells[1].Text;
            txtSurname.Text = row.Cells[2].Text;
            txtBirth.Text = row.Cells[3].Text;
            txtEmail.Text = row.Cells[4].Text;
            txtLogin.Text = row.Cells[5].Text;
            txtPass.Text = row.Cells[6].Text;
            txtCountry.Text = row.Cells[7].Text;
            txtCity.Text = row.Cells[8].Text;
            txtRole.Text = row.Cells[9].Text;
            popup.Show();
        }
    }
    protected void Add(object sender, EventArgs e)
    {
        txtUserID.ReadOnly = true;
        txtUserID.Text = string.Empty;
        txtName.Text = string.Empty;
        txtSurname.Text = string.Empty;
        txtBirth.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtLogin.Text = string.Empty;
        txtPass.Text = string.Empty;
        txtCountry.Text = string.Empty;
        txtCity.Text = string.Empty;
        txtRole.Text = string.Empty;
        popup.Show();
    }

    protected void Save(object sender, EventArgs e)
    {
        string CS = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        string procedure = "";
        if (txtUserID.Text.Equals(string.Empty))
        {
            procedure = "AddData";
        }
        else
        {
            procedure = "UpdateData";
        }

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand();
            con.Open();
            String pass = Convert.ToBase64String(sha256(txtPass.Text));
            if (procedure.Equals("UpdateData"))
            {
                cmd = new SqlCommand("UPDATE dbo.VARTOTOJAS SET vardas='" + txtName.Text + "', pavarde='" + txtSurname.Text + "', gimimo_metai='"+ txtBirth.Text +"', elektroninis_pastas='"+ txtEmail.Text +"', prisijungimo_vardas='"+ txtLogin.Text +"', slaptazodis='"+ pass +"', valstybe='"+txtCountry.Text+"', miestas='" + txtCity.Text + "', role='" + txtRole.Text + "' WHERE vartotojo_id='"+ txtUserID.Text +"'", con);
            }
            else
            {
                cmd = new SqlCommand("INSERT dbo.VARTOTOJAS (vardas, pavarde, gimimo_metai, elektroninis_pastas,prisijungimo_vardas, slaptazodis, valstybe, miestas, role, ep_patvirtinimas) VALUES ('"+ txtName.Text +"', '"+ txtSurname.Text + "', '"+ txtBirth.Text + "', '"+ txtEmail.Text + "', '"+ txtLogin.Text + "', '" + pass + "', '" + txtCountry.Text+ "', '" +txtCity.Text + "', '" + txtRole.Text + "', 'true')", con);
            }
            cmd.ExecuteScalar();
            GridView1.DataSource = GetData(cmd);
            GridView1.DataBind();
        }
    }

    private byte[] sha256(string value)
    {
        SHA256 sha = SHA256Managed.Create();
        byte[] hashValue;
        UTF8Encoding objUtf8 = new UTF8Encoding();
        hashValue = sha.ComputeHash(objUtf8.GetBytes(value));
        return hashValue;
    }

    protected void SqlDataSource_vartotojai_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }

    protected void OnPaging(object sender, EventArgs e)
    {

    }
}