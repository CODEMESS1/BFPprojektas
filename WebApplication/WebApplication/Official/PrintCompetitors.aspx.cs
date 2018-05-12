using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Model;
using WebApplication.Models;
using WebApplication.Presenter;

namespace WebApplication.Official
{
    public partial class PrintCompetitors : System.Web.UI.Page, IPrintOfficial
    {
        private PrintCompetitorsPresenter presenter;

        public List<Competition> CompetitionList { set => GridView1.DataSource = value; }
        public List<Competitors> CompetitorsList { set => GridView2.DataSource = value; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridView2.Visible = true;
            //CompetitionContainer comp = new CompetitionContainer();
            //var comptemp = comp.getById(GridView1.SelectedIndex);
            int compId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);

            presenter.InitCompetitorsView(compId);
            GridView1.Visible = false;
        }

    }
}