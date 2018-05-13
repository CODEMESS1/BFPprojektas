using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication.Admin
{
    public partial class PrintLists : System.Web.UI.Page
    {
        private iTextSharp.text.pdf.PdfDocument pdfCoach = new iTextSharp.text.pdf.PdfDocument();
        private const string FONT = "c:/windows/fonts/arial.ttf";

        private AspUsersContainer dbContainer = new AspUsersContainer();

        private struct UserToPrint
        {
            public string Name;
            public string Surname;
            public string Year;
            public string Email;

            public UserToPrint(string name, string surname, string year, string email)
            {
                Name = name;
                Surname = surname;
                Year = year;
                Email = email;
            }

            public override string ToString()
            {
                return string.Format("{0:20}  {1:20}  {2:yyyy/MM/dd}  {3:45}", Name, Surname, Year, Email);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void printofficial_btn_Click(object sender, EventArgs e)
        {
            string path = Page.Server.MapPath("/PDFs");

            DataTable dtbl = new DataTable();

            dtbl.Columns.Add("Vardas");
            dtbl.Columns.Add("Pavardė");
            dtbl.Columns.Add("Metai");
            dtbl.Columns.Add("El. paštas");

            List<UserToPrint> users = getUsers("Official");

            for (int i = 0; i < users.Count; i++)
            {
                dtbl.Rows.Add(users[i].Name, users[i].Surname, users[i].Year,
                    users[i].Email);
            }

            ExportDataTableToPdf(dtbl, path + "/official.pdf", "Teisėjų sąrašas");



            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=teisejai.pdf");
            Response.TransmitFile(Server.MapPath("~/PDFs/official.pdf"));
            Response.End();

        }

        protected void printcoach_btn_Click(object sender, EventArgs e)
        {
            string path = Page.Server.MapPath("/PDFs");

            DataTable dtbl = new DataTable();

            dtbl.Columns.Add("Vardas");
            dtbl.Columns.Add("Pavardė");
            dtbl.Columns.Add("Metai");
            dtbl.Columns.Add("El. paštas");

            List<UserToPrint> users = getUsers("Coach");

            for (int i = 0; i < users.Count; i++)
            {
                dtbl.Rows.Add(users[i].Name, users[i].Surname, users[i].Year,
                    users[i].Email);
            }

            ExportDataTableToPdf(dtbl, path + "/coach.pdf", "Trenerių sąrašas");


            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=treneriai.pdf");
            Response.TransmitFile(Server.MapPath("~/PDFs/coach.pdf"));
            Response.End();

        }

        private List<UserToPrint> getUsers(string role)
        {
            List<UserToPrint> users = new List<UserToPrint>();
            List<AspNetUsers> aspNetUsers = dbContainer.aspNetUsers.Where(usr => usr.Role.Equals(role)).ToList();
            foreach (AspNetUsers user in aspNetUsers)
            {
                UserToPrint temp = new UserToPrint(user.Name, user.Surname, user.Year.ToString(), user.Email);
                users.Add(temp);
            }
            return users;
        }

        private void ExportDataTableToPdf(DataTable dtblTable, String strPdfPath,
             string strHeader)
        {
            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();


            //ads header
            BaseFont bfntHead = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 16, 1, BaseColor.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
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

            //table header
            BaseFont bfntColumnHeader = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new Font(bfntColumnHeader, 10, 1, BaseColor.WHITE);
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
                    table.AddCell(dtblTable.Rows[i][j].ToString());
                }
            }

            document.Add(table);
            document.Close();
            writer.Close();
            fs.Close();
        }

    }
}