using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Model
{
    public interface ICreateCompetition
    {
        bool Registration { get; set; }
        string Name { get; set; }
        string Location { get; set; }
        DateTime Date { get; set; }
        string Address { get; set; }
        DateTime? RegistrationStartDate { get; set; }
        DateTime? RegistrationEndDate { get; set; }
        List<Competition> Competitions { set; }
        //List<Event> Events { get; set; }
        bool AddCompetition(Competition competition);
        bool DeleteCompetition(int id);
        bool EditCompetition(int id);

    }
}
