using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Presenter;
using WebApplication.Tests.Mocks;

namespace WebApplication.Tests
{
    [TestFixture]
    public class CreateEventsTest
    {
        MockCreateEventsView view;
        CreateEventsPresenter presenter;

        [SetUp]
        public void init()
        {
            view = new MockCreateEventsView();
            presenter = new CreateEventsPresenter(view);

            List<Models.Events> events = new List<Models.Events>()
            {
                new Models.Events(1, "Test1", "MoreCount"),
                new Models.Events(2, "Test2", "LessCount")
            };

            List<Models.AgeGroupTypes> ageGroupTypes = new List<Models.AgeGroupTypes>()
            {
                new Models.AgeGroupTypes("Vyrai"),
                new Models.AgeGroupTypes("Moterys")
            };

            view.Events = events;
            view.AgeGroupTypes = ageGroupTypes;
        }

        [TestCase]
        public void AddEventTest()
        {
            bool ret = view.AddEvent(new Models.Events(5, "Test3", "BestTime"));

            Assert.AreEqual(ret, true);
        }

        [TestCase]
        public void EditEventTest()
        {
            view.Title = "New title";
            view.Type = "New type";
            bool ret = view.EditEvent(1);

            Assert.AreEqual(ret, true);
        }

        [TestCase]
        public void RemoveEventTest()
        {
            bool ret = view.RemoveEvent(2);

            Assert.AreEqual(ret, true);
        }
    }
}