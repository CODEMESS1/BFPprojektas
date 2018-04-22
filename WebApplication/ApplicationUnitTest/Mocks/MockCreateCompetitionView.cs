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

        public bool DeleteCompetition(Competition competition)
        {
            return competitions.Remove(competition);
        }

        public void EditCompetition(Competition competition)
        {
            List<Competition> competitions = this.competitions.Where(c => c.Id == competition.Id).ToList();
                competitions[0].Name = competition.Name;
                competitions[0].Location = competition.Location;
                competitions[0].Registration = competition.Registration;
                competitions[0].RegistrationStartDate = competition.RegistrationStartDate;
                competitions[0].RegistrationEndDate = competition.RegistrationEndDate;
                competitions[0].Date = competition.Date;
        }
    }
}
