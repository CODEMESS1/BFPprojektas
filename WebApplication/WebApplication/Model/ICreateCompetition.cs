using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Model
{
    public interface ICreateCompetition
    {
        List<Competition> Competitions { get; set; }
        //List<Events> GetEvents();
        bool AddCompetition(Competition competition);
        bool DeleteCompetition(Competition competition);


    }
}
