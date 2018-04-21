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

        public List<Models.Competition> Competitions { set => GridView1.DataSource = value; }
        public string Name { get => editName_tb.Text;  set => editName_tb.Text = value; }
        public string Location { get => editLocation_tb.Text;  set => editLocation_tb.Text = value; }
        public DateTime Date { get => Convert.ToDateTime(Request.Form[editDate_tb.UniqueID]);  set => editDate_tb.Text = value.ToString("yyyy/MM/dd"); }
        public string Address { get => editAddress_tb.Text;  set => editAddress_tb.Text = value; }
        public DateTime? RegistrationStartDate { get => Convert.ToDateTime(Request.Form[editRegistrationStartDate_tb.UniqueID]);
                                                                    set => editRegistrationStartDate_tb.Text = value.ToString(); }
        public DateTime? RegistrationEndDate { get => Convert.ToDateTime(Request.Form[editRegistrationEndDate_tb.UniqueID]);
                                                                   set => editRegistrationEndDate_tb.Text = value.ToString(); }

        public bool Registration
        {
            get
            {
                if (editisRegOpen_ckbox.SelectedValue.Equals("Open"))
                {
                    return true;
                }
                return false;
            }
            set
            {
                if(value == true)
                {
                    editisRegOpen_ckbox.SelectedValue = "Open";
                }
                else
                {
                    editisRegOpen_ckbox.SelectedValue = "Closed";
                }
            }
        }

        //List<Event> ICreateCompetition.Events { set => ; }

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new CreateCompetitionPresenter(this);
            presenter.InitView();
            GridView1.DataBind();
        }

        protected void add_btn_Click(object sender, EventArgs e)
        {
            popupAdd.Show();
        }

        protected void submit_btn_Click(object sender, EventArgs e)
        {
            Page.Validate("popup");
            if (Page.IsValid)
            {
                Models.Competition competition;
                popupAdd.Show();
                if(addRegStart_txt.Text.Equals("") || addRegEnd_txt.Text.Equals(""))
                {
                    competition = new Models.Competition(addName_txt.Text, addPlace_txt.Text, addAdress_txt.Text, Convert.ToDateTime(Request.Form[AddDate_txt.UniqueID]), (addIsRegOpen_ckbox.SelectedValue == "Open") ? true : false);
                }
                else
                {
                    competition = new Models.Competition(addName_txt.Text, addPlace_txt.Text, addAdress_txt.Text, Convert.ToDateTime(Request.Form[AddDate_txt.UniqueID]), (addIsRegOpen_ckbox.SelectedValue == "Open") ? true : false,
                        Convert.ToDateTime(Request.Form[addRegStart_txt.UniqueID]), Convert.ToDateTime(Request.Form[addRegEnd_txt.UniqueID]));
                }
                if (presenter.AddCompetition(competition))
                {
                    GridView1.DataBind();
                    popupAdd.Hide();
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Įvyko klaida! Nepavyko pridėti varžybų');", true);
                }
            }
            else
            {
                popupAdd.Show();
            }
        }

        protected void remove_btn_Click(object sender, EventArgs e)
        {
            //remove padaryti
            int compId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            if(presenter.DeleteCompetition(compId))
            {
                GridView1.DataBind();
                popupEdit.Hide();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Įvyko klaida! Nepavyko ištrinti varžybų');", true);
            }
        }

        protected void edit_btn_Click(object sender, EventArgs e)
        {
            Page.Validate("editPopup");
            if (Page.IsValid)
            {
                int compId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
                if (EditCompetition(compId))
                {
                    GridView1.DataBind();
                    popupEdit.Hide();
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Įvyko klaida! Nepavyko pakeisti varžybų duomenų');", true);
                }
            }
            else
            {
                popupEdit.Show();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int compId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            if(presenter.PopulatePopup(compId))
            {
                popupEdit.Show();
            }
        }

        public bool AddCompetition(Models.Competition competition)
        {
            return presenter.AddCompetition(competition);
        }

        public bool DeleteCompetition(int id)
        {
            return presenter.DeleteCompetition(id);
        }

        public bool EditCompetition(int id)
        {
            return presenter.EditCompetition(id);
        }
    }
}