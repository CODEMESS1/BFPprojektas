using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Model;

namespace WebApplication.Models
{
    public class CompetitionContainer : DbContext
    {
        public CompetitionContainer() : base("DefaultConnection")
        {

        }

        public DbSet<Competition> Competitions { get; set; }

        public void RemoveCompetition(Competition competition)
        {
            Competitions.Remove(competition);
            SaveChanges();
        }

        public void AddCompetition(Competition competition)
        {
            Competitions.Add(competition);
            SaveChanges();
        }
        
        public void EditCompetition(Competition competition)
        {
            List<Competition> competitionToChange = Competitions.Where(c => c.Id == competition.Id).ToList();
            if(competitionToChange.Count != 0)
            {
                Competitions.Remove(competitionToChange[0]);
                Competitions.Add(competition);
                SaveChanges();
            }

        }

        public Competition getById(int Id)
        {
            List<Competition> competitions = Competitions.Where(c => c.Id == Id).ToList();
            if(competitions.Count != 0)
            {
                return competitions[0];
            }
            else
            {
                return null;
            }
        }
    }
}