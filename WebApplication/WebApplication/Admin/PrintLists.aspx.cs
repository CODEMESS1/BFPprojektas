using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Printing;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private PdfDocument pdfCoach = new PdfDocument();

        private DbContainer dbContainer = new DbContainer();

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
            PdfDocument pdfOfficial = new PdfDocument();
            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
            XFont font = new XFont("Times New Roman", 12, XFontStyle.Regular, options);
            PdfPage pdfPage = pdfOfficial.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);

            List<UserToPrint> users = getUsers("Official");

            //padaryti spausdinima i pdf faila


            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=teisejai.pdf");
            Response.TransmitFile(Server.MapPath("~/PDFs/official.pdf"));
            Response.End();

            pdfOfficial.Save(path + "/official.pdf");
        }

        protected void printcoach_btn_Click(object sender, EventArgs e)
        {
            string path = Page.Server.MapPath("/PDFs");
            PdfDocument pdfOfficial = new PdfDocument();
            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
            XFont font = new XFont("Times New Roman", 12, XFontStyle.Regular, options);
            PdfPage pdfPage = pdfOfficial.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);

            List<UserToPrint> users = getUsers("Coach");

            //padaryti spausdinima i pdf faila
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=treneriai.pdf");
            Response.TransmitFile(Server.MapPath("~/PDFs/coach.pdf"));
            Response.End();

            pdfOfficial.Save(path + "/coach.pdf");
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
    }
}