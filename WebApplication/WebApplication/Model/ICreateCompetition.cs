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
        List<Competition> Competitions { set; }
        //List<Event> Events { set; }
        bool AddCompetition(Competition competition);
        bool DeleteCompetition(Competition competition);
        void EditCompetition(Competition competition);

    }
}
