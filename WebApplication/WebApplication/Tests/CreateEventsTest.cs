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
                new Models.Events("Test1", "MoreCount"),
                new Models.Events("Test2", "LessCount")
            };

            List<Models.AgeGroupTypes> ageGroupTypes = new List<Models.AgeGroupTypes>()
            {
                new Models.AgeGroupTypes("Vyrai"),
                new Models.AgeGroupTypes("Moterys")
            };


        }
    }
}