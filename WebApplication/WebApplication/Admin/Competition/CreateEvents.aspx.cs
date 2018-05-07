using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Model;
using WebApplication.Models;
using WebApplication.Presenter;

namespace WebApplication.Admin.Competition
{
    public partial class CreateEvents : Page, ICreateEvents
    {
        private CreateEventsPresenter presenter;
        
        public int Type { get => Convert.ToInt16(addType_dropDownList.SelectedValue); }
        List<Events> ICreateEvents.Events { set => GridView1.DataSource = value; }
        public List<EventTypes> EventTypes { set => addType_dropDownList.DataSource = value; }
        public List<AgeGroupTypes> AgeGroupTypes { set => AgeGroupsGridView.DataSource = value; }
        string ICreateEvents.Title { get => addName_tb.Text; }

        public bool AddEvent(Events eventToAdd)
        {
            return presenter.AddNewEvent(eventToAdd);
        }

        public bool EditEvent(int eventIdToEdit)
        {
            return presenter.EditEvent(eventIdToEdit);
        }

        public bool RemoveEvent(int eventIdToRemove)
        {
            throw new NotImplementedException();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new CreateEventsPresenter(this);
            presenter.InitView();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            popupAdd.Show();
            edit_btn.Visible = true;
            presenter.setEventTypes();
            addType_dropDownList.DataBind();
            presenter.setAgeGroupTypes();
            AgeGroupsGridView.DataBind();
        }

        protected void addEvent_btn_Click(object sender, EventArgs e)
        {
            popupAdd.Show();
            submit_btn.Visible = true;
            presenter.setEventTypes();
            addType_dropDownList.DataBind();
            presenter.setAgeGroupTypes();
            AgeGroupsGridView.DataBind();
        }

        protected void submit_btn_Click(object sender, EventArgs e)
        {
            presenter.setSelectedGroups(getSelectedGroups());
            Models.Events eventToAdd = new Models.Events(addName_tb.Text, Convert.ToInt16(addType_dropDownList.SelectedValue));
            if(AddEvent(eventToAdd))
            {
                popupAdd.Hide();
                submit_btn.Visible = false;
                clearPopup();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Įvyko klaida! Nepavyko pridėti rungties');", true);
            }
            presenter.populateGridView();
            GridView1.DataBind();
        }

        private List<string> getSelectedGroups()
        {
            List<string> ageGroupsSelected = new List<string>();
            for (int i = 0; i < AgeGroupsGridView.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)AgeGroupsGridView.Rows[i].FindControl("checkBox");
                if (cb != null && cb.Checked)
                {
                    string type = AgeGroupsGridView.Rows[i].Cells[1].Text;
                    ageGroupsSelected.Add(type);
                }
            }
            return ageGroupsSelected;
        }

        protected void cancel_btn_Click(object sender, EventArgs e)
        {
            popupAdd.Hide();
            submit_btn.Visible = false;
            edit_btn.Visible = false;
            clearPopup();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        private void clearPopup()
        {
            addName_tb.Text = "";
            for (int i = 0; i < AgeGroupsGridView.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)AgeGroupsGridView.Rows[i].FindControl("checkBox");
                if (cb != null && cb.Checked)
                {
                    cb.Checked = false;
                }
            }
        }

        protected void edit_btn_Click(object sender, EventArgs e)
        {
            presenter.setSelectedGroups(getSelectedGroups());
            if (EditEvent(Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text)))
            {
                popupAdd.Hide();
                edit_btn.Visible = false;
                clearPopup();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Įvyko klaida! Nepavyko pakeisti rungties');", true);
            }
            presenter.populateGridView();
            GridView1.DataBind();
        }
    }
}