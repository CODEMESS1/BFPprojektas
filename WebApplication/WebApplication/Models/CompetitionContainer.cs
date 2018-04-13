using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Model;

namespace WebApplication.Models
{
    public class CompetitionContainer : DbContext, ICreateCompetition
    {
        public CompetitionContainer() : base("DefaultConnection")
        {

        }

        public DbSet<Competitors> Competitions { get; set; }

        List<Competition> ICreateCompetition.Competitions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool AddCompetition(Competition competition)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCompetition(Competition competition)
        {
            throw new NotImplementedException();
        }

        //public List<Events> GetEvents()
        //{
        //    throw new NotImplementedException();
        //}
    }
}