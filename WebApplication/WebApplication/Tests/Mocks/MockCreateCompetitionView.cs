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
        private List<Competition> competitions;

        public List<Competition> Competitions
        {
            set { competitions = value; }
        }

        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public DateTime? RegistrationStartDate { get; set; }
        public DateTime? RegistrationEndDate { get; set; }
        public bool Registration { get; set; }

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

        public bool EditCompetition(int id)
        {
            List<Competition> competitions = this.competitions.Where(c => c.Id == id).ToList();
            if(competitions.Count != 0)
            {
                return true;
            }
            return false;
        }
    }
}
