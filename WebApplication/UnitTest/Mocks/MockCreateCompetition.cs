using System;
using System.Collections.Generic;
using WebApplication.Model;
using WebApplication.Models;

namespace UnitTest.Mocks
{
    class MockCreateCompetition : ICreateCompetition
    {
        private List<Competition> _competitions;

        public MockCreateCompetition()
        {
            _competitions = LoadTestCompetition();
        }

        private List<Competition> LoadTestCompetition()
        {
            List<Competition> competitions = new List<Competition>()
            {
                new Competition("TEST1", "Kaunas", 1, new DateTime(2017, 10, 10), "Test gatve", false,
                    new DateTime?(new DateTime(2017, 10, 8)), new DateTime?(new DateTime(2017, 10, 9))),
                new Competition("TEST2", "Vilnius", 1, new DateTime(2017, 08, 10), "Test gatve", false,
                   new DateTime?(new DateTime(2017, 08, 8)), new DateTime?(new DateTime(2017, 08, 9)))
            };
            return competitions;
        }

        public List<Competition> Competitions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool AddCompetition(Competition competition)
        {
            if (competition != null)
            {
                _competitions.Add(competition);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCompetition(Competition competition)
        {
            if(competition != null)
            {
                return _competitions.Remove(competition);
            }
            else
            {
                return false;
            }
        }

        //public List<Events> GetEvents()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
