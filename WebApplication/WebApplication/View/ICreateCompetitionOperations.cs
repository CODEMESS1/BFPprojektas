using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.View
{
    public interface ICreateCompetitionOperations : IView
    {
        List<Competition> Competitions { get; set; }

        //event EventHandler<AddCompetitionEventArgs> AddCompetition;
        //event EventHandler<GetCompetitionEventArgs> GetCompetition;
        //event EventHandler<ModifyCompetitionEventArgs> ModifyCompetition;
        //event EventHandler<DeleteCompetitionEventArgs> DeleteCompetition;
    }
}
