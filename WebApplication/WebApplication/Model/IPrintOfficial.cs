using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Model
{
    public interface IPrintOfficial
    {
        List<Competition> CompetitionList { set; }
        List<Competitors> CompetitorsList { set; }

    }
}
