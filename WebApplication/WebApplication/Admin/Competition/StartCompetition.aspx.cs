using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Model;
using WebApplication.Models;
using WebApplication.Models.Objects;
using WebApplication.Presenter;
using System.IO;

namespace WebApplication.Admin.Competition
{
    public partial class StartCompetition : Page, IStartCompetition
    {
        private const string FONT = "c:/windows/fonts/arial.ttf";
        private StartCompetitionPresenter presenter;
        private string Result;
        private List<AgeGroupTypes> Types = new List<AgeGroupTypes>(); //age group types local parameter

        private int IdForCalc
        {
            get
            {
                if (ViewState["Id"] != null)
                    return (int)ViewState["Id"];
                else
                    return 0;
            }
            set
            {
                ViewState["Id"] = value;
            }
        }

        private List<Models.Objects.LastEntries> LastEntries
        {
            get
            {
                if (ViewState["list"] != null)
                    return (List<Models.Objects.LastEntries>)ViewState["list"];
                else
                    return LastEntries = new List<LastEntries>();
            }
            set
            {
                ViewState["list"] = value;
            }
        }

        public List<AgeGroupTypes> AgeGroupTypes { set { CalculateResultsGroup_list.DataSource = AgeGroup_DropDownList.DataSource = selectGroup_list.DataSource = Types = value; } } 
        public List<CompetitorsWithSubgroups> Competitors { set {
                if (value.Count != 0)
                {
                    CompetitorsGridView.DataSource = value;
                }
                else
                {
                    CompetitorsGridView.DataSource = null;
                }
                    } }

        public string SelectedAgeGroup => AgeGroup_DropDownList.SelectedValue;

        public List<Models.Competition> Competitions { set => CompetitionsGridView.DataSource = value; }

        public int SelectedSubgroupCount => Convert.ToInt32(SubgroupsCount.SelectedValue);

        public int SelectedCompetitionId => Convert.ToInt32(CompetitionsGridView.SelectedRow.Cells[1].Text);

        List<Events> IStartCompetition.Events { set => selectEvent_list.DataSource = value; }

        public int SelectedAgeGroupForResult => Convert.ToInt16(selectGroup_list.SelectedValue);

        public int SelectedEventForResult => Convert.ToUInt16(selectEvent_list.SelectedValue);

        public LastEntries LastEntry {
            get {
                return new LastEntries(Convert.ToInt16(EnterId_tb.Text), Competitor_tb.Text.Split(',')[0], Competitor_tb.Text.Split(',')[1], selectEvent_list.SelectedItem.Text, Result);
            }
        }

        public Competitors Competitor { set {
                Competitor_tb.Text = value.ToString();
            } }

        public int CompetitorId => Convert.ToInt16(EnterId_tb.Text);

        string IStartCompetition.Result => this.Result;

        public string AgeGroupForCalculation => CalculateResultsGroup_list.SelectedValue;

        public DataTable Results { set { Results_GridView.DataSource = value; Results_GridView.DataBind(); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new StartCompetitionPresenter(this);
            presenter.InitView();
            CompetitionsGridView.DataBind();
            if (!Page.IsPostBack)
            {
                CalculateResultsGroup_list.DataBind();
                ResultsUpdatePanel.Visible = false;
                time.Visible = false;
                count.Visible = false;
            }
        }

        protected void GenerateSubGroups_Click(object sender, EventArgs e)
        {
            CompetitorsGridView.DataSource = null;
            CompetitorsGridView.DataBind();
            presenter.SetAgeGroupSubgroupsCount();
            AgeGroup_DropDownList.Enabled = true;
            SubgroupsCount.Enabled = true;
            ScriptManager.RegisterStartupScript(this, GetType(), "AKey", "click();", true);
        }

        protected void GetCompetitorsInGroup_Click(object sender, EventArgs e)
        {
            presenter.GetByGroup();
            if (CompetitorsGridView.DataSource != null)
            {
                CompetitorsGridView.DataBind();
                GroupGridView(CompetitorsGridView.Rows, 0, 1);
                AgeGroup_DropDownList.Enabled = false;
                SubgroupsCount.Enabled = false;
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "AKey", "click();", true);

        }

        protected void CompetitionsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPanel.Visible = false;
            CompetitorsGridView.DataBind();
            AgeGroup_DropDownList.DataBind();
            CompetitionPanel.Visible = true;
            //SelectCompetitionBtn.Visible = true;
            ScriptManager.RegisterStartupScript(this, GetType(), "AKey", "click();", true);
        }

        protected void CompetitionsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CompetitionsGridView.PageIndex = e.NewPageIndex;
            CompetitorsGridView.DataBind();
        }

        protected void SelectCompetitionBtn_Click(object sender, EventArgs e)
        {
            SelectPanel.Visible = true;
            CompetitionPanel.Visible = false;
            //SelectCompetitionBtn.Visible = false;
        }


        private void GroupGridView(GridViewRowCollection gvrc, int startIndex, int total)
        {
            if (total == 0) return;
            int i, count = 1;
            ArrayList lst = new ArrayList();
            lst.Add(gvrc[0]);
            var ctrl = gvrc[0].Cells[startIndex];
            for (i = 1; i < gvrc.Count; i++)
            {
                TableCell nextCell = gvrc[i].Cells[startIndex];
                if (ctrl.Text == nextCell.Text)
                {
                    count++;
                    nextCell.Visible = false;
                    lst.Add(gvrc[i]);
                }
                else
                {
                    if (count > 1)
                    {
                        ctrl.RowSpan = count;
                        GroupGridView(new GridViewRowCollection(lst), startIndex + 1, total - 1);
                    }
                    count = 1;
                    lst.Clear();
                    ctrl = gvrc[i].Cells[startIndex];
                    lst.Add(gvrc[i]);
                }
            }
            if (count > 1)
            {
                ctrl.RowSpan = count;
                GroupGridView(new GridViewRowCollection(lst), startIndex + 1, total - 1);
            }
            count = 1;
            lst.Clear();
        }

        protected void startCompetition_Click(object sender, EventArgs e)
        {
            CompetitionPanel.Visible = false;
            ResultsUpdatePanel.Visible = true;
            selectGroup_list.DataBind();
        }

        protected void saveCompetition_btn_Click(object sender, EventArgs e)
        {
            CompetitionPanel.Visible = true;
            ResultsUpdatePanel.Visible = false;
            ScriptManager.RegisterStartupScript(this, GetType(), "AKey", "click();", true);
        }

        protected void WriteResults_btn_Click(object sender, EventArgs e)
        {
            if(selectGroup_list.SelectedValue != null && selectEvent_list.SelectedItem != null)
            {
                if(GetEventType().Type.Equals("Time"))
                {
                    count.Visible = false;
                    time.Visible = true;
                }
                else
                {
                    count.Visible = true;
                    time.Visible = false;
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Pasirinkite grupę ir rungtį.');", true);
            }
        }

        protected void SelectGroup_btn_Click(object sender, EventArgs e)
        {
            if (presenter.GetEvents())
            {
                selectEvent_list.Enabled = true;
                selectEvent_list.DataBind();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Nėra sukurtų rungčių');", true);
            }
        }

        protected void EnterId_tb_TextChanged(object sender, EventArgs e)
        {
            
        }

        public EventTypes GetEventType()
        {
            return presenter.GetEventType();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CompetitorsGridView.DataSource = null;
            CompetitorsGridView.DataBind();
            AgeGroup_DropDownList.Enabled = true;
            SubgroupsCount.Enabled = true;
            ScriptManager.RegisterStartupScript(this, GetType(), "AKey", "click();", true);
        }

        protected void ResultsTime_btn_Click(object sender, EventArgs e)
        {
            DateTime time = new DateTime(2018, 5, 14, 12, Convert.ToInt16(ResultsTimeMinute_TextBox.Text), Convert.ToInt16(ResultsTimeSeconds_TextBox.Text),
                Convert.ToInt16(ResultsTimeMili_TextBox.Text));
            Result = time.ToString("mm:ss:fff");
            BindLastEntry();
            LastEntries_Gridview.DataBind();
            presenter.AddResult();
        }

        protected void ResultsCount_btn_Click(object sender, EventArgs e)
        {
            Result = TextBox3.Text;
            BindLastEntry();
            LastEntries_Gridview.DataBind();
            presenter.AddResult();
        }

        private void BindLastEntry()
        {
            if (LastEntries.Count == 5)
            {
                LastEntries.RemoveAt(0);
                LastEntries.Add(LastEntry);
                LastEntries_Gridview.DataSource = LastEntries;
            }
            else
            {
                LastEntries.Add(LastEntry);
                LastEntries_Gridview.DataSource = LastEntries;
            }
        }

        protected void FindById_btn_Click(object sender, EventArgs e)
        {
            if (presenter.CompetitorForEntry() != null)
            {
                Competitor_tb.DataBind();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Tokio dalyvio ID nėra');", true);
            }
        }

        protected void Calculate_btn_Click(object sender, EventArgs e)
        {
            CalculateResultsGroup_list.SelectedIndex = IdForCalc;
            Results_GridView.DataSource = null;
            Results_GridView.DataBind();
            presenter.CalculateSelected();
            if(Results_GridView.DataSource == null)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Nėra rezultatų arba dalyvių šios grupės');", true);
            }
            PrintResults((DataTable)Results_GridView.DataSource);
            ScriptManager.RegisterStartupScript(this, GetType(), "AKey", "clickPostBackStart();", true);
        }

        protected void CalculateResultsGroup_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            IdForCalc = Convert.ToInt16(CalculateResultsGroup_list.SelectedIndex);
            ScriptManager.RegisterStartupScript(this, GetType(), "AKey", "clickPostBackStart();", true);
        }

        protected void GetStartList_Btn_Click(object sender, EventArgs e)
        {
            string path = Page.Server.MapPath("/PDFs");

            using (System.IO.FileStream fs = new FileStream(path + "/subgroups.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Document document = new Document();
                document.SetPageSize(iTextSharp.text.PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();
                
                //bega per kiekviena amziausiaus grupes tipa
                foreach (AgeGroupTypes type in Types)
                {
                    //randa visus dalyvius, vienos amziaus grupes
                    List<CompetitorsWithSubgroups> allCompetitors = presenter.GetStartList(type.Type);

                    if (allCompetitors.Count > 0)
                    {
                        //gauna pogrupius 
                        List<int> subGroups = allCompetitors.Select(c => c.Subgroup).ToList();
                        subGroups = subGroups.Distinct().ToList();

                        //bega per pogrupius 1, 2, ...
                        foreach (int subgroup in subGroups)
                        {
                            //*******************************    trūksta trenerio var pav *************************

                            DataTable dtbl = new DataTable();
                            List<CompetitorsWithSubgroups> subgroupComp = allCompetitors.Where(c => c.Subgroup == subgroup).ToList();

                            dtbl.Columns.Add("ID");
                            dtbl.Columns.Add("Pogrupis");
                            dtbl.Columns.Add("Vardas");
                            dtbl.Columns.Add("Pavardė");
                            dtbl.Columns.Add("Metai");
                            dtbl.Columns.Add("Miestas");
                            dtbl.Columns.Add("Valstybė");
                            dtbl.Columns.Add("Tren. V. Pavardė");

                            for (int k = 0; k < subgroupComp.Count; k++)
                            {
                                string CoachFullName = presenter.GetCoachFullName(allCompetitors[k].CoachId);
                                dtbl.Rows.Add(subgroupComp[k].Id, subgroupComp[k].Subgroup, subgroupComp[k].Name,
                                    subgroupComp[k].Surname, subgroupComp[k].Year.ToString("yyyy/MM/dd"), subgroupComp[k].City,
                                    subgroupComp[k].Country, CoachFullName);
                            }

                            ExportDataTableToPdf(document, dtbl, type.Type + ". Pogrupio nr. " + subgroup);

                            document.NewPage();
                        }
                    }
                }

                document.Close();
                writer.Close();
            
            }


            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=pogrupiai.pdf");
            Response.TransmitFile(Server.MapPath("~/PDFs/subgroups.pdf"));
            Response.End();
        }

        protected void GetResultList_Btn_Click(object sender, EventArgs e)
        {
            string path = Page.Server.MapPath("/PDFs");

            System.IO.FileStream fs = new FileStream(path + "/results.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            //bega per kiekviena amziausiaus grupes tipa
            foreach (AgeGroupTypes type in Types)
            {
                //randa visus dalyvius, vienos amziaus grupes
                List<CompetitorsWithSubgroups> allCompetitors = presenter.GetStartList(type.Type);

                if (allCompetitors.Count > 0)
                {
                    //gauna pogrupius 
                    List<int> subGroups = allCompetitors.Select(c => c.Subgroup).ToList();
                    subGroups = subGroups.Distinct().ToList();

                    //bega per pogrupius 1, 2, ...
                    foreach (int subgroup in subGroups)
                    {
                        //*******************************    trūksta trenerio var pav *************************

                        DataTable dtbl = new DataTable();
                        List<CompetitorsWithSubgroups> subgroupComp = allCompetitors.Where(c => c.Subgroup == subgroup).ToList();

                        dtbl.Columns.Add("ID");
                        dtbl.Columns.Add("Pogrupis");
                        dtbl.Columns.Add("Vardas");
                        dtbl.Columns.Add("Pavardė");
                        dtbl.Columns.Add("Metai");
                        dtbl.Columns.Add("Miestas");
                        dtbl.Columns.Add("Rezultatas");

                        for (int k = 0; k < subgroupComp.Count; k++)
                        {
                            string CoachFullName = presenter.GetCoachFullName(allCompetitors[k].CoachId);
                            dtbl.Rows.Add(subgroupComp[k].Id, subgroupComp[k].Subgroup, subgroupComp[k].Name,
                                subgroupComp[k].Surname, subgroupComp[k].Year.ToString("yyyy/MM/dd"), subgroupComp[k].City, "");
                        }

                        ExportDataTableToPdf(document, dtbl, type.Type + ". Pogrupio nr. " + subgroup + "\n" + "Teisėjas: \n" + "Rungtis: ");

                        document.NewPage();
                    }
                }
            }

            document.Close();
            writer.Close();
            fs.Close();

            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=rezultatai.pdf");
            Response.TransmitFile(Server.MapPath("~/PDFs/results.pdf"));
            Response.End();
        }

        private void PrintResults(DataTable results)
        {
            string path = Page.Server.MapPath("/PDFs");

            System.IO.FileStream fs = new FileStream(path + "/Rez.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            ExportDataTableToPdf(document, results, "Rezultatai");

            document.Close();
            writer.Close();
            fs.Close();

            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Rez.pdf");
            Response.TransmitFile(Server.MapPath("~/PDFs/Rez.pdf"));
            Response.End();
        }

        private void ExportDataTableToPdf(Document document, DataTable dtblTable,
            string strHeader)
        {
            //ads header
            BaseFont bfntHead = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 16, 1, BaseColor.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_LEFT;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
            document.Add(prgHeading);

            //adds date
            Paragraph prgDate = new Paragraph();
            BaseFont bfntDate = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font fntDate = new Font(bfntDate, 8, 2, BaseColor.GRAY);
            prgDate.Alignment = Element.ALIGN_RIGHT;
            prgDate.Add(new Chunk("Data : " + DateTime.Now.ToShortDateString(), fntDate));
            document.Add(prgDate);

            //adds a line seperation
            Paragraph p = new Paragraph(new Chunk(new
                iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK,
                Element.ALIGN_LEFT, 0)));
            document.Add(p);

            //add a line break
            document.Add(new Chunk("\n", fntHead));

            //write the table
            PdfPTable table = new PdfPTable(dtblTable.Columns.Count);
            table.WidthPercentage = 95;

            //table header
            BaseFont bfntColumnHeader = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            Font fntColumnHeader = new Font(bfntColumnHeader, 9, 1, BaseColor.WHITE);
            Font fntCell= new Font(bfTimes, 7, 1, BaseColor.BLACK);
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = BaseColor.GRAY;
                cell.AddElement(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }

            //table data
            for (int i = 0; i < dtblTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable.Columns.Count; j++)
                {
                    table.AddCell(new Phrase(dtblTable.Rows[i][j].ToString(), fntCell));
                }
            }
            document.Add(table);
        }
    }
}