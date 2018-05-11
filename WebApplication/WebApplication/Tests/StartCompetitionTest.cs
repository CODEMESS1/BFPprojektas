using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;
using WebApplication.Presenter;
using WebApplication.Tests.Mocks;

namespace WebApplication.Tests
{
    [TestFixture]
    public class StartCompetitionTest
    {
        private MockStartCompetitionView View;
        private StartCompetitionPresenter Presenter;

        [SetUp]
        public void Init()
        {
            Presenter = new StartCompetitionPresenter(View);
            

        }
    }
}