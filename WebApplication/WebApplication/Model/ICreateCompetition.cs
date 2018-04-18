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
        List<Competition> Competitions { get;  set; }
        //List<Event> Events { set; }
        bool AddCompetition(Competition competition);
        bool DeleteCompetition(int id);
        bool EditCompetition(int id, Competition competition);

    }
}
