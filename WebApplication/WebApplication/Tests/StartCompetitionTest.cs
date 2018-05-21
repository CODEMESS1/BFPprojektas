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
        private ResultsContainer ModelMock = Substitute.For<ResultsContainer>();

        private StartCompetitionPresenter Presenter;
        public List<Models.Objects.Results> results;

        [SetUp]
        public void Init()
        {
            var context = Substitute.For<ResultsContainer>();

            var results = new List<Models.Objects.Results>
            {
                new Models.Objects.Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10" },
            };

            var mockResults = Substitute.For<DbSet<Models.Objects.Results>, IQueryable<Models.Objects.Results>>();
            ((IQueryable<Models.Objects.Results>)mockResults).Provider.Returns(results.AsQueryable().Provider);
            ((IQueryable<Models.Objects.Results>)mockResults).Expression.Returns(results.AsQueryable().Expression);
            ((IQueryable<Models.Objects.Results>)mockResults).ElementType.Returns(results.AsQueryable().ElementType);
            ((IQueryable<Models.Objects.Results>)mockResults).GetEnumerator().Returns(results.AsQueryable().GetEnumerator());

            mockResults.When(q => q.Add(Arg.Any<Models.Objects.Results>()))
                .Do(q => results.Add(q.Arg<Models.Objects.Results>()));

            mockResults.When(q => q.Remove(Arg.Any<Models.Objects.Results>()))
                .Do(q => results.Remove(q.Arg<Models.Objects.Results>()));

            context.Results = mockResults;


            Presenter = new StartCompetitionPresenter(View, context);

            results = new List<Models.Objects.Results>
             {
                    new Models.Objects.Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10" },
                    new Models.Objects.Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11" },
                    new Models.Objects.Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10" },
                    new Models.Objects.Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "9" },
                    new Models.Objects.Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8" },
                    new Models.Objects.Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8" },
                    new Models.Objects.Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11" },
                    new Models.Objects.Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "12" },
                    new Models.Objects.Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "13" },

                    new Models.Objects.Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:15:20" },
                    new Models.Objects.Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:20:15" },
                    new Models.Objects.Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8:30:20" },
                    new Models.Objects.Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:10:10" },
                    new Models.Objects.Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:20:20" },
                    new Models.Objects.Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "15:15:30" },
                    new Models.Objects.Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "20:5:5" },
                    new Models.Objects.Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "25:15:5" },
                    new Models.Objects.Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "30:25:5" },



             };

            context.Results.AddRange(results);

        }


        [TestCase]
        public void AddResult4()
        {
            results = new List<Models.Objects.Results>
             {
                    new Models.Objects.Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:15:20" },
                    new Models.Objects.Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:20:15" },
                    new Models.Objects.Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8:30:20" },
                    new Models.Objects.Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:10:10" },
                    new Models.Objects.Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:20:20" },
                    new Models.Objects.Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "15:15:30" },
                    new Models.Objects.Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "20:5:5" },
                    new Models.Objects.Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "25:15:5" },
                    new Models.Objects.Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "30:25:5" }
             };
            List<Models.Objects.Results> expected2 = new List<Models.Objects.Results>
            {
                    new Models.Objects.Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "30:25:5", Points =1, Score = 1 },
                    new Models.Objects.Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "25:15:5", Points =2, Score = 2 },
                    new Models.Objects.Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "20:5:5", Points = 3, Score = 3 },
                    new Models.Objects.Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "15:15:30", Points = 4, Score = 4 },
                    new Models.Objects.Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:20:20", Points = 5, Score = 5 },
                    new Models.Objects.Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:10:10", Points = 6, Score = 6 },
                    new Models.Objects.Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8:30:20", Points = 7, Score = 7 },
                    new Models.Objects.Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:20:15", Points = 8, Score = 8 },
                    new Models.Objects.Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:15:20", Points = 9, Score = 9 }                
                    
                    
            };
            

            List<Models.Objects.Results> ret = Presenter.CalculateResults(results, new EventTypes("Time", "Worst"));

            Assert.AreEqual(expected2, ret);

        }

        [TestCase]
        public void AddResult3()
        {
            results = new List<Models.Objects.Results>
             {
                    new Models.Objects.Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:15:20" },
                    new Models.Objects.Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:20:15" },
                    new Models.Objects.Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8:30:20" },
                    new Models.Objects.Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:10:10" },
                    new Models.Objects.Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:20:20" },
                    new Models.Objects.Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "15:15:30" },
                    new Models.Objects.Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "20:5:5" },
                    new Models.Objects.Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "25:15:5" },
                    new Models.Objects.Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "30:25:5" }
             };
            List<Models.Objects.Results> expected2 = new List<Models.Objects.Results>
            {
                    new Models.Objects.Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:15:20", Points = 1, Score = 1 },
                    new Models.Objects.Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:20:15", Points = 2, Score = 2 },
                    new Models.Objects.Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8:30:20", Points = 3, Score = 3 },
                    new Models.Objects.Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:10:10", Points = 4, Score = 4 },
                    new Models.Objects.Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:20:20", Points = 5, Score = 5 },
                    new Models.Objects.Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "15:15:30", Points = 6, Score = 6 },
                    new Models.Objects.Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "20:5:5", Points = 7, Score = 7 },
                    new Models.Objects.Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "25:15:5", Points =8, Score = 8 },
                    new Models.Objects.Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "30:25:5", Points =9, Score = 9 }
            };

            List<Models.Objects.Results> ret = Presenter.CalculateResults(results, new EventTypes("Time", "Best"));

            Assert.AreEqual(expected2, ret);

        }

        [TestCase]
        public void AddResult2()
        {
            results = new List<Models.Objects.Results>
             {
                    new Models.Objects.Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10" },
                    new Models.Objects.Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11" },
                    new Models.Objects.Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10" },
                    new Models.Objects.Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "9" },
                    new Models.Objects.Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8" },
                    new Models.Objects.Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8" },
                    new Models.Objects.Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11" },
                    new Models.Objects.Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "12" },
                    new Models.Objects.Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "13" }
             };
            List<Models.Objects.Results> expected2 = new List<Models.Objects.Results>
            {
                    new Models.Objects.Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8", Points = 1.5, Score = 1 },
                    new Models.Objects.Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8", Points = 1.5, Score = 1 },
                    new Models.Objects.Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "9", Points = 3, Score = 3 },
                    new Models.Objects.Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10", Points = 4.5, Score = 4 },
                    new Models.Objects.Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10", Points = 4.5, Score = 4 },
                    new Models.Objects.Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11", Points = 6.5, Score = 6 },
                    new Models.Objects.Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11", Points = 6.5, Score = 6 },
                    new Models.Objects.Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "12", Points =8, Score = 8 },
                    new Models.Objects.Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "13", Points =9, Score = 8 },

            };

            List<Models.Objects.Results> ret = Presenter.CalculateResults(results, new EventTypes("Count", "Least"));

            Assert.AreEqual(expected2, ret);

        }

        [TestCase]
        public void AddResult()
        {
            results = new List<Models.Objects.Results>
             {
                    new Models.Objects.Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10" },
                    new Models.Objects.Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11" },
                    new Models.Objects.Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10" },
                    new Models.Objects.Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "9" },
                    new Models.Objects.Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8" },
                    new Models.Objects.Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8" },
                    new Models.Objects.Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11" },
                    new Models.Objects.Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "12" },
                    new Models.Objects.Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "13" }
             };
            

            List<Models.Objects.Results> expected2 = new List<Models.Objects.Results>
            {
                    new Models.Objects.Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "13", Points =1, Score=1 },
                    new Models.Objects.Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "12", Points =2, Score=2 },
                    new Models.Objects.Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11", Points = 3.5, Score=3 },
                    new Models.Objects.Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "11", Points = 3.5, Score=3 },
                    new Models.Objects.Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10", Points = 5.5, Score=5 },
                    new Models.Objects.Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10", Points = 5.5, Score=5 },
                    new Models.Objects.Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "9", Points = 7, Score=7 },
                    new Models.Objects.Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8", Points = 8.5, Score=8 },
                    new Models.Objects.Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8", Points = 8.5, Score=8 },
                    

            };

            List<Models.Objects.Results> ret = Presenter.CalculateResults(results ,new EventTypes("Count", "Most"));

            Assert.AreEqual(expected2, ret);
        }

        [TestCase]
        public void SortDesc()
        {
            results = new List<Models.Objects.Results>
             {
                    new Models.Objects.Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:15:20" },
                    new Models.Objects.Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:20:15" },
                    new Models.Objects.Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8:30:20" },
                    new Models.Objects.Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:10:10" },
                    new Models.Objects.Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:20:20" },
                    new Models.Objects.Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "15:15:30" },
                    new Models.Objects.Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "20:5:5" },
                    new Models.Objects.Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "25:15:5" },
                    new Models.Objects.Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "30:25:5" }
             };
            
            List<Models.Objects.Results> expected2 = new List<Models.Objects.Results>
            {
                    new Models.Objects.Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "30:25:5", Points =1, Score = 1 },
                    new Models.Objects.Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "25:15:5", Points =2, Score = 2 },
                    new Models.Objects.Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "20:5:5", Points = 3, Score = 3 },
                    new Models.Objects.Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "15:15:30", Points = 4, Score = 4 },
                    new Models.Objects.Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:20:20", Points = 5, Score = 5 },
                    new Models.Objects.Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:10:10", Points = 6, Score = 6 },
                    new Models.Objects.Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8:30:20", Points = 7, Score = 7 },
                    new Models.Objects.Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:20:15", Points = 8, Score = 8 },
                    new Models.Objects.Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:15:20", Points = 9, Score = 9 }


            };

            List<Models.Objects.Results> ret = Presenter.SortTimeDsc(results);

            Assert.AreEqual(expected2, ret);
        }

        [TestCase]
        public void SortAsc()
        {
            results = new List<Models.Objects.Results>
             {
                    new Models.Objects.Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "25:15:5" },
                    new Models.Objects.Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "30:25:5" },
                    new Models.Objects.Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:15:20" },
                    new Models.Objects.Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:20:15" },
                    new Models.Objects.Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8:30:20" },
                    new Models.Objects.Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:10:10" },
                    new Models.Objects.Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:20:20" },
                    new Models.Objects.Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "15:15:30" },
                    new Models.Objects.Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "20:5:5" }

             };
            List<Models.Objects.Results> expected2 = new List<Models.Objects.Results>
            {
                    new Models.Objects.Results { CompetitorId = 0, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:15:20", Points = 1, Score = 1 },
                    new Models.Objects.Results { CompetitorId = 1, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "4:20:15", Points = 2, Score = 2 },
                    new Models.Objects.Results { CompetitorId = 2, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "8:30:20", Points = 3, Score = 3 },
                    new Models.Objects.Results { CompetitorId = 3, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:10:10", Points = 4, Score = 4 },
                    new Models.Objects.Results { CompetitorId = 4, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "10:20:20", Points = 5, Score = 5 },
                    new Models.Objects.Results { CompetitorId = 5, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "15:15:30", Points = 6, Score = 6 },
                    new Models.Objects.Results { CompetitorId = 6, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "20:5:5", Points = 7, Score = 7 },
                    new Models.Objects.Results { CompetitorId = 7, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "25:15:5", Points =8, Score = 8 },
                    new Models.Objects.Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "30:25:5", Points =9, Score = 9 }


            };

            List<Models.Objects.Results> ret = Presenter.SortTimeAsc(results);

            Assert.AreEqual(expected2, ret);
        }
    }
}