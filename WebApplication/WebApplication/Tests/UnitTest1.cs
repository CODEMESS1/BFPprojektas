using System;
using System.Collections.Generic;
using NUnit.Framework;
using WebApplication.Models;
using WebApplication.Presenter;

namespace UnitTest.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        MockCreateCompetitionView view;
        CreateCompetitionPresenter presenter;

        [SetUp]
        public void LoadObjectcs()
        {
            view = new MockCreateCompetitionView();
            presenter = new CreateCompetitionPresenter(view);

            List<Competition> competitions = new List<Competition>()
            {
                new Competition(1, "BFP", "test", "Liepu al. 6", new DateTime(2018, 04, 20), true, new DateTime(2018-04-09), new DateTime(2018-04-20)),
                new Competition(5, "BFP", "edit test", "Liepu al. 6", new DateTime(2018, 04, 20), true, new DateTime(2018-04-09), new DateTime(2018-04-20))
            };
            view.Competitions = competitions;
        }

        [TestCase]
        public void Add()
        {
            bool ret = view.AddCompetition(new Competition());
            Assert.AreEqual(ret, true);
        }

          [TestCase]
          public void Remove()
          {
              Competition test = new Competition(5, "BFP", "edit test", "Liepu al. 6", new DateTime(2018, 04, 20), true, new DateTime(2018 - 04 - 09), new DateTime(2018 - 04 - 20));
              bool ret = view.DeleteCompetition(test.Id);

              Assert.AreEqual(ret, true);
          }
    }
}
