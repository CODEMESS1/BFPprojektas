using NSubstitute;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Tests.Mocks
{
    public class MockOfCompetitionEventsContainer
    {
        public CompetitionEventsContainer contextCompetitionEvents { get; set; }

        public MockOfCompetitionEventsContainer()
        {
            contextCompetitionEvents = Substitute.For<CompetitionEventsContainer>();

            var competitionEvents = new List<CompetitionEvents>
            {
                new CompetitionEvents(0, 0),
                new CompetitionEvents(0, 1)
            };

            var mockCompetitionEvents = Substitute.For<DbSet<CompetitionEvents>, IQueryable<CompetitionEvents>>();
            ((IQueryable<CompetitionEvents>)mockCompetitionEvents).Provider.Returns(competitionEvents.AsQueryable().Provider);
            ((IQueryable<CompetitionEvents>)mockCompetitionEvents).Expression.Returns(competitionEvents.AsQueryable().Expression);
            ((IQueryable<CompetitionEvents>)mockCompetitionEvents).ElementType.Returns(competitionEvents.AsQueryable().ElementType);
            ((IQueryable<CompetitionEvents>)mockCompetitionEvents).GetEnumerator().Returns(competitionEvents.AsQueryable().GetEnumerator());

            mockCompetitionEvents.When(q => q.Add(Arg.Any<CompetitionEvents>()))
                        .Do(q => competitionEvents.Add(q.Arg<CompetitionEvents>()));

            mockCompetitionEvents.When(q => q.Remove(Arg.Any<CompetitionEvents>()))
                .Do(q => competitionEvents.Remove(q.Arg<CompetitionEvents>()));

            contextCompetitionEvents.CompetitionEvents = mockCompetitionEvents;
        }
    }
}