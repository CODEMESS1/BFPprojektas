using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication.Model
{
    public interface IResultsView
    {
        DataTable Results { set; }
        List<Models.AgeGroupTypes> AgeGroupTypes { set; }
        string AgeGroupSelected { get; }
        List<Models.Competition> Competitions { set; }
        int CompetitionId { get; }
        string SearchField { get; }
    }
}