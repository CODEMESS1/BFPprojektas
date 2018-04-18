using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using WebApplication.Model;
using WebApplication.Models;
using WebApplication.Presenter;

namespace WebApplication.Admin
{
    public partial class CreateCompetition : System.Web.UI.Page, ICreateCompetition
    {
        private CreateCompetitionPresenter presenter;

        public List<Competition> Competitions { get => Competitions; set => GridView1.DataSource = value; }
        //List<Event> ICreateCompetition.Events { set => ; }

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new CreateCompetitionPresenter(this);
            presenter.InitView();
            GridView1.DataBind();
        }

        bool ICreateCompetition.AddCompetition(Competition competition)
        {
            return presenter.AddCompetition(competition);
        }

        bool ICreateCompetition.DeleteCompetition(int Id)
        {
            return presenter.DeleteCompetition(Id);
        }

        bool ICreateCompetition.EditCompetition(int id, Competition competition)
        {
            return presenter.EditCompetition(id, competition);
        }

        protected void add_btn_Click(object sender, EventArgs e)
        {
            popupAdd.Show();
        }

        protected void submit_btn_Click(object sender, EventArgs e)
        {
            popupAdd.Show();
            //if (editName_tb.Text != string.Empty || editName_tb.Text != "")
            //{
                Competition competition = new Competition(addName_txt.Text, addPlace_txt.Text, addAdress_txt.Text, Convert.ToDateTime(AddDate_txt.Text), (addIsRegOpen_ckbox.SelectedValue == "Open") ? true : false,
                Convert.ToDateTime(addRegStart_txt.Text), Convert.ToDateTime(addRegEnd_txt.Text));
                presenter.AddCompetition(competition);
            //}

            GridView1.DataBind();
            popupAdd.Hide();
        }

        protected void remove_btn_Click(object sender, EventArgs e)
        {
            //remove padaryti
            int compId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            presenter.DeleteCompetition(compId);
            GridView1.DataBind();

            popupEdit.Hide();
        }

        protected void edit_btn_Click(object sender, EventArgs e)
        {
            int compId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            Competition competition = new Competition();
            if (editName_tb.Text != string.Empty || editName_tb.Text != "")
                competition.Name = editName_tb.Text;
            if (editLocation_tb.Text != string.Empty || editLocation_tb.Text != "")
                competition.Location = editLocation_tb.Text;
            if (editAddress_tb.Text != string.Empty || editAddress_tb.Text != "")
                competition.Address = editAddress_tb.Text;
            if (editDate_tb.Text != string.Empty || editDate_tb.Text != "")
                competition.Date = Convert.ToDateTime(editDate_tb.Text);
            if (editisRegOpen_ckbox.SelectedValue == "Open")
                competition.Registration = true;
            else
                competition.Registration = false;
            if (editRegistrationStartDate_tb.Text != string.Empty || editRegistrationStartDate_tb.Text != "")
                competition.RegistrationStartDate = Convert.ToDateTime(editRegistrationStartDate_tb.Text);
            if (editRegistrationEndDate_tb.Text != string.Empty || editRegistrationEndDate_tb.Text != "")
                competition.RegistrationEndDate = Convert.ToDateTime(editRegistrationEndDate_tb.Text);

                presenter.EditCompetition(compId, competition);
            GridView1.DataBind();
            popupEdit.Hide();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            popupEdit.Show();
        }
    }
}