using NSubstitute;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Models.Containers;
using WebApplication.Models.Objects;

namespace WebApplication.Tests.Mocks
{
    public class MockOfStartCompetitionModel
    {
        public ResultsContainer ResultsContainer = Substitute.For<ResultsContainer>();

    }
}