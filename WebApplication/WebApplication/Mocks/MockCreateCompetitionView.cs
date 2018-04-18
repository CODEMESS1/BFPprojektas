using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Model;
using WebApplication.Models;

namespace UnitTest.Tests
{
    class MockCreateCompetitionView : ICreateCompetition
    {
        private List<Competition> competitions = new List<Competition>();
        
        public List<Competition> Competitions
        {
            get => competitions;
            set { competitions = value; }
        }

        public bool AddCompetition(Competition competition)
        {
            if (competition != null)
            {
                competitions.Add(competition);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCompetition(int Id)
        {
            List<Competition> competitions = this.competitions.Where(c => c.Id == Id).ToList();
            if (competitions.Count != 0)
            {
                competitions.Remove(competitions[0]);
                return true;
            }
            return false;
        }

        public bool EditCompetition(int Id, Competition competition)
        {
            List<Competition> competitions = this.competitions.Where(c => c.Id == competition.Id).ToList();
            if (competitions.Count != 0)
            {
                competitions[0].Name = competition.Name;
                competitions[0].Location = competition.Location;
                competitions[0].Registration = competition.Registration;
                competitions[0].RegistrationStartDate = competition.RegistrationStartDate;
                competitions[0].RegistrationEndDate = competition.RegistrationEndDate;
                competitions[0].Date = competition.Date;
                return true;
            }
            return false;

        }
    }
}
