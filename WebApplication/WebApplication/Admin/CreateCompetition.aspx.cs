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

        public List<Competition> Competitions { set => GridView1.DataSource = value; }
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

        bool ICreateCompetition.DeleteCompetition(Competition competition)
        {
            return presenter.DeleteCompetition(competition);
        }

        void ICreateCompetition.EditCompetition(Competition competition)
        {
            presenter.EditCompetition(competition);
        }

        protected void add_btn_Click(object sender, EventArgs e)
        {
            popupAdd.Show();
        }

        protected void submit_btn_Click(object sender, EventArgs e)
        {
            popupAdd.Show();
            Competition competition = new Competition(addName_txt.Text, addPlace_txt.Text, addAdress_txt.Text, Convert.ToDateTime(AddDate_txt.Text), (addIsRegOpen_ckbox.SelectedValue == "Open") ? true : false,
                Convert.ToDateTime(addRegStart_txt.Text), Convert.ToDateTime(addRegEnd_txt.Text));
            presenter.AddCompetition(competition);
            GridView1.DataBind();
            popupAdd.Hide();
        }

        protected void remove_btn_Click(object sender, EventArgs e)
        {
            //remove padaryti
            popupEdit.Hide();
        }

        protected void edit_btn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            Competition competition = presenter.getById(id);
            if(presenter.EditCompetition(competition) == true)
            {
                //jeipaeditino
            }
            else
            {
                //jei nepaeditino
            }
            GridView1.DataBind();
            popupEdit.Hide();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            popupEdit.Show();
        }
    }
}