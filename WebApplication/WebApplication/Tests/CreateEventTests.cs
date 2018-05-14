using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Models;
using WebApplication.Models.Objects;
using WebApplication.Presenter;
using WebApplication.Tests.Mocks;

namespace WebApplication.Tests
{
    [TestFixture]
    public class CreateEventTests
    {
        private CreateEventsViewMock View = new CreateEventsViewMock();
        private CreateEventsPresenter Presenter;

        public List<Events> events;

        [SetUp]
        public void Init()
        {
            var context = Substitute.For<EventsContainer>();

            var events = new List<Events>
            {
                new Events { Id = 0, Title = "Begimas 1500m", Type=1}
            };

            var mockResults = Substitute.For<DbSet<Events>, IQueryable<Events>>();
            ((IQueryable<Events>)mockResults).Provider.Returns(events.AsQueryable().Provider);
            ((IQueryable<Events>)mockResults).Expression.Returns(events.AsQueryable().Expression);
            ((IQueryable<Events>)mockResults).ElementType.Returns(events.AsQueryable().ElementType);
            ((IQueryable<Events>)mockResults).GetEnumerator().Returns(events.AsQueryable().GetEnumerator());

            mockResults.When(q => q.Add(Arg.Any<Events>()))
                .Do(q => events.Add(q.Arg<Events>()));

            mockResults.When(q => q.Remove(Arg.Any<Events>()))
                .Do(q => events.Remove(q.Arg<Events>()));

            context.Events = mockResults;


            Presenter = new CreateEventsPresenter(View, context);

            events = new List<Events>
             {
                    new Events { Id = 0, Title = "First" , Type=1 },
                    new Events { Id = 1, Title = "Second" , Type=1 },
                    new Events { Id = 2, Title = "Third" , Type=1 },
                    new Events { Id = 3, Title = "Fourth" , Type=1 },
                    new Events { Id = 4, Title = "Fifth" , Type=1 },
                    new Events { Id = 5, Title = "Sixth" , Type=1 },
                    new Events { Id = 6, Title = "Seventh" , Type=1 },



             };

           context.Events.AddRange(events);
        }

        [TestCase]
        public void AddEvents()
        {
            events = new List<Events>
             {
                    new Events { Id = 0, Title = "First" , Type=1 },
                    new Events { Id = 1, Title = "Second" , Type=1 },
                    new Events { Id = 2, Title = "Third" , Type=1 },
                    new Events { Id = 3, Title = "Fourth" , Type=1 },
                    new Events { Id = 4, Title = "Fifth" , Type=1 },
                    new Events { Id = 5, Title = "Sixth" , Type=1 },
                    new Events { Id = 6, Title = "Seventh" , Type=1 },
             };
            List<Events> expected2 = new List<Events>
            {
                    new Events { Id = 0, Title = "First" , Type=1 },
                    new Events { Id = 1, Title = "Second" , Type=1 },
                    new Events { Id = 2, Title = "Third" , Type=1 },
                    new Events { Id = 3, Title = "Fourth" , Type=1 },
                    new Events { Id = 4, Title = "Fifth" , Type=1 },
                    new Events { Id = 5, Title = "Sixth" , Type=1 },
                    new Events { Id = 6, Title = "Seventh" , Type=1 },
            };

            foreach (var a in events)
            List<Events> ret = Presenter.AddNewEvent(a);

            Assert.AreEqual(expected2, ret);

        }

    }
}