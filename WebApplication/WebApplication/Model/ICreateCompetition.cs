using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication.Model
{
    public interface ICreateCompetition
    {
        List<int> GetSelectedEndYearAdd();
        List<int> GetSelectedEndYearEdit();
        List<int> GetSelectedStartYearAdd();
        List<int> GetSelectedStartYearEdit();
        List<string> AgeGroupTypesSelected { get; }
        List<AgeGroupTypes> ageGroupTypes { set; }
        bool Registration { get; set; }
        string Name { get; set; }
        string Location { get; set; }
        DateTime Date { get; set; }
        string Address { get; set; }
        DateTime? RegistrationStartDate { get; set; }
        DateTime? RegistrationEndDate { get; set; }
        List<Competition> Competitions { set; }
        List<Events> Events { get;  set; }
        List<Events> GetSelectedEvents(GridView gridview);
        bool AddCompetition(Competition competition);
        bool DeleteCompetition(int id);
        bool EditCompetition(int id);

    }
}
