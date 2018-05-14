using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Model;
using WebApplication.Models;
using WebApplication.Models.Containers;
using WebApplication.Models.Objects;
using WebApplication.Presenter;
using WebApplication.Tests.Mocks;

namespace WebApplication.Tests
{
    [TestFixture]
    public class StartCompetitionTest
    {
        private MockStartCompetitionView View = new MockStartCompetitionView();
        //private MockOfStartCompetitionModel Model = new MockOfStartCompetitionModel();
        private ResultsContainer ModelMock = Substitute.For<ResultsContainer>();

        private StartCompetitionPresenter Presenter;
        public List<Results> results;

        [SetUp]
        public void Init()
        {
            var context = Substitute.For<ResultsContainer>();

            var results = new List<Results>
            {
                new Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10" },
            };

            var mockResults = Substitute.For<DbSet<Results>, IQueryable<Results>>();
            ((IQueryable<Results>)mockResults).Provider.Returns(results.AsQueryable().Provider);
            ((IQueryable<Results>)mockResults).Expression.Returns(results.AsQueryable().Expression);
            ((IQueryable<Results>)mockResults).ElementType.Returns(results.AsQueryable().ElementType);
            ((IQueryable<Results>)mockResults).GetEnumerator().Returns(results.AsQueryable().GetEnumerator());

            mockResults.When(q => q.Add(Arg.Any<Results>()))
                .Do(q => results.Add(q.Arg<Results>()));

            mockResults.When(q => q.Remove(Arg.Any<Results>()))
                .Do(q => results.Remove(q.Arg<Results>()));

            context.Results = mockResults;


            Presenter = new StartCompetitionPresenter(View, context);

            results = new List<Results>
             {
                    new Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10" },
                    new Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11" },
                    new Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10" },
                    new Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "9" },
                    new Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8" },
                    new Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8" },
                    new Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11" },
                    new Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "12" },
                    new Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "13" },

                    new Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:15:20" },
                    new Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:20:15" },
                    new Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8:30:20" },
                    new Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:10:10" },
                    new Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:20:20" },
                    new Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "15:15:30" },
                    new Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "20:5:5" },
                    new Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "25:15:5" },
                    new Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "30:25:5" },



             };

            context.Results.AddRange(results);

        }


        [TestCase]
        public void AddResult4()
        {
            results = new List<Results>
             {
                    new Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:15:20" },
                    new Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:20:15" },
                    new Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8:30:20" },
                    new Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:10:10" },
                    new Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:20:20" },
                    new Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "15:15:30" },
                    new Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "20:5:5" },
                    new Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "25:15:5" },
                    new Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "30:25:5" }
             };
            List<Results> expected2 = new List<Results>
            {
                    new Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "30:25:5", Points =1, Score = 1 },
                    new Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "25:15:5", Points =2, Score = 2 },
                    new Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "20:5:5", Points = 3, Score = 3 },
                    new Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "15:15:30", Points = 4, Score = 4 },
                    new Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:20:20", Points = 5, Score = 5 },
                    new Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:10:10", Points = 6, Score = 6 },
                    new Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8:30:20", Points = 7, Score = 7 },
                    new Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:20:15", Points = 8, Score = 8 },
                    new Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:15:20", Points = 9, Score = 9 }                
                    
                    
            };
            

            List<Results> ret = Presenter.CalculateResults(results, new EventTypes("Time", "Worst"));

            Assert.AreEqual(expected2, ret);

        }

        [TestCase]
        public void AddResult3()
        {
            results = new List<Results>
             {
                    new Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:15:20" },
                    new Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:20:15" },
                    new Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8:30:20" },
                    new Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:10:10" },
                    new Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:20:20" },
                    new Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "15:15:30" },
                    new Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "20:5:5" },
                    new Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "25:15:5" },
                    new Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "30:25:5" }
             };
            List<Results> expected2 = new List<Results>
            {
                    new Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:15:20", Points = 1, Score = 1 },
                    new Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:20:15", Points = 2, Score = 2 },
                    new Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8:30:20", Points = 3, Score = 3 },
                    new Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:10:10", Points = 4, Score = 4 },
                    new Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:20:20", Points = 5, Score = 5 },
                    new Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "15:15:30", Points = 6, Score = 6 },
                    new Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "20:5:5", Points = 7, Score = 7 },
                    new Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "25:15:5", Points =8, Score = 8 },
                    new Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "30:25:5", Points =9, Score = 9 }
            };

            List<Results> ret = Presenter.CalculateResults(results, new EventTypes("Time", "Best"));

            Assert.AreEqual(expected2, ret);

        }

        [TestCase]
        public void AddResult2()
        {
            results = new List<Results>
             {
                    new Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10" },
                    new Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11" },
                    new Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10" },
                    new Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "9" },
                    new Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8" },
                    new Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8" },
                    new Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11" },
                    new Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "12" },
                    new Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "13" }
             };
            List<Results> expected2 = new List<Results>
            {
                    new Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8", Points = 1.5, Score = 1 },
                    new Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8", Points = 1.5, Score = 1 },
                    new Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "9", Points = 3, Score = 3 },
                    new Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10", Points = 4.5, Score = 4 },
                    new Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10", Points = 4.5, Score = 4 },
                    new Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11", Points = 6.5, Score = 6 },
                    new Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11", Points = 6.5, Score = 6 },
                    new Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "12", Points =8, Score = 8 },
                    new Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "13", Points =9, Score = 8 },

            };

            List<Results> ret = Presenter.CalculateResults(results, new EventTypes("Count", "Least"));

            Assert.AreEqual(expected2, ret);

        }

        [TestCase]
        public void AddResult()
        {
            results = new List<Results>
             {
                    new Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10" },
                    new Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11" },
                    new Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10" },
                    new Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "9" },
                    new Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8" },
                    new Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8" },
                    new Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11" },
                    new Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "12" },
                    new Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "13" }
             };

            //Results expected = new Results(9, 1, 1, 1, "15", new double?(1), new int?(1));

            List<Results> expected2 = new List<Results>
            {
                    new Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "13", Points =1, Score=1 },
                    new Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "12", Points =2, Score=2 },
                    new Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11", Points = 3.5, Score=3 },
                    new Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11", Points = 3.5, Score=3 },
                    new Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10", Points = 5.5, Score=5 },
                    new Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10", Points = 5.5, Score=5 },
                    new Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "9", Points = 7, Score=7 },
                    new Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8", Points = 8.5, Score=8 },
                    new Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8", Points = 8.5, Score=8 },
                    

            };

            List<Results> ret = Presenter.CalculateResults(results ,new EventTypes("Count", "Most"));

            Assert.AreEqual(expected2, ret);
        }
    }
}