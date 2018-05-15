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
            MockOfEventsModel context = new MockOfEventsModel();

            Presenter = new CreateEventsPresenter(View, context.contextEvents);

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

            context.contextEvents.Events.AddRange(events);
        }

        [TestCase]
        public void AddEvents()
        {
            Events events = new Events(11, "Begimas", 2);
            List<string> selectedAgeGroups = new List<string>()
            {
                "Vyrai", "Moterys"
            };

            Presenter.setSelectedGroups(selectedAgeGroups);
            bool ret = Presenter.AddNewEvent(events);

            Assert.AreEqual(ret, true);
        }
        
        [TestCase]
        public void EditExistingEvent()
        {
            List<string> selectedAgeGroups = new List<string>()
            {
                "Vyrai", "Moterys"
            };

            Presenter.setSelectedGroups(selectedAgeGroups);

            bool ret = Presenter.EditEvent(0);

            Assert.AreEqual(ret, true);
        }

        [TestCase]
        public void EditNotExistingEvent()
        {
            List<string> selectedAgeGroups = new List<string>()
            {
                "Vyrai", "Moterys"
            };

            Presenter.setSelectedGroups(selectedAgeGroups);

            bool ret = Presenter.EditEvent(50);

            Assert.AreEqual(ret, false);
        }
    }
}