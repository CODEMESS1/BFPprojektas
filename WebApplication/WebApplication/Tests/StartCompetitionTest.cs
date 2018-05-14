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
                    new Results { CompetitorId = 8, EventId = 1, AgeGroupType = 1, CompetitionId = 1, Result = "13" }
             };

            context.Results.AddRange(results);

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

            Results expected = new Results(9, 1, 1, 1, "15", new double?(1), new int?(1));

            List<Results> ret = Presenter.CalculateCount(results);

            Assert.AreNotEqual(expected, ret.First());
        }
    }
}