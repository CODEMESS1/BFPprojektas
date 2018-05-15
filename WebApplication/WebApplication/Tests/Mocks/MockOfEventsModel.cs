using NSubstitute;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Models;
using WebApplication.Models.Containers;
using WebApplication.Models.Objects;

namespace WebApplication.Tests.Mocks
{
    public class MockOfEventsModel
    {
        public EventsContainer contextEvents { get; set; }
        private MockOfAgeGroupTypesContainer MockOfAgeGroupTypesContainer = new MockOfAgeGroupTypesContainer();
        private MockOfCompetitionEventsContainer MockOfCompetitionEventsContainer = new MockOfCompetitionEventsContainer();

        public MockOfEventsModel()
        {
            contextEvents = Substitute.For<EventsContainer>(MockOfCompetitionEventsContainer.contextCompetitionEvents, MockOfAgeGroupTypesContainer.contextAgeGroupTypes);

            //Events
            var events = new List<Events>
            {
                new Events { Id = 0, Title = "Begimas 1500m", Type=1}
            };

            var mockEvents = Substitute.For<DbSet<Events>, IQueryable<Events>>();
            ((IQueryable<Events>)mockEvents).Provider.Returns(events.AsQueryable().Provider);
            ((IQueryable<Events>)mockEvents).Expression.Returns(events.AsQueryable().Expression);
            ((IQueryable<Events>)mockEvents).ElementType.Returns(events.AsQueryable().ElementType);
            ((IQueryable<Events>)mockEvents).GetEnumerator().Returns(events.AsQueryable().GetEnumerator());

            mockEvents.When(q => q.Add(Arg.Any<Events>()))
                    .Do(q => events.Add(q.Arg<Events>()));

            mockEvents.When(q => q.Remove(Arg.Any<Events>()))
                .Do(q => events.Remove(q.Arg<Events>()));

            contextEvents.Events = mockEvents;

            //Age group events
            
            var ageGroupEvents = new List<AgeGroupEvents>
            {
                new AgeGroupEvents { Id = 0, AgeGroupType = 1, EventId = 0}
            };

            var mockAgeGroupEvents = Substitute.For<DbSet<AgeGroupEvents>, IQueryable<AgeGroupEvents>>();
            ((IQueryable<AgeGroupEvents>)mockAgeGroupEvents).Provider.Returns(ageGroupEvents.AsQueryable().Provider);
            ((IQueryable<AgeGroupEvents>)mockAgeGroupEvents).Expression.Returns(ageGroupEvents.AsQueryable().Expression);
            ((IQueryable<AgeGroupEvents>)mockAgeGroupEvents).ElementType.Returns(ageGroupEvents.AsQueryable().ElementType);
            ((IQueryable<AgeGroupEvents>)mockAgeGroupEvents).GetEnumerator().Returns(ageGroupEvents.AsQueryable().GetEnumerator());

            mockAgeGroupEvents.When(q => q.Add(Arg.Any<AgeGroupEvents>()))
                    .Do(q => ageGroupEvents.Add(q.Arg<AgeGroupEvents>()));

            mockAgeGroupEvents.When(q => q.Remove(Arg.Any<AgeGroupEvents>()))
                .Do(q => ageGroupEvents.Remove(q.Arg<AgeGroupEvents>()));

            contextEvents.AgeGroupEvents = mockAgeGroupEvents;
        }
    }
}