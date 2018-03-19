using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AddUpdatePerson";
            cmd.Parameters.AddWithValue("@UserID", txtUserID.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Surname", txtSurname.Text);
            cmd.Parameters.AddWithValue("@Date_Of_Birth", txtBirth.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@LoginName", txtLogin.Text);
            cmd.Parameters.AddWithValue("@Password", txtPass.Text);
            cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
            cmd.Parameters.AddWithValue("@City", txtCity.Text);
            cmd.Parameters.AddWithValue("@Role", txtRole.Text);
            GridView1.DataSource = this.GetData(cmd);
            GridView1.DataBind();
        }
    }





    protected void SqlDataSource_vartotojai_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }

    protected void OnPaging(object sender, EventArgs e)
    {

    }
}