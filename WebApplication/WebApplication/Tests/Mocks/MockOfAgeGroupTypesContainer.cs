using NSubstitute;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Tests.Mocks
{
    public class MockOfAgeGroupTypesContainer
    {
        public AgeGroupTypesContainer contextAgeGroupTypes { get; set; }

        public MockOfAgeGroupTypesContainer()
        {
            contextAgeGroupTypes = Substitute.For<AgeGroupTypesContainer>();

            var ageGroupTypes = new List<AgeGroupTypes>
            {
                new AgeGroupTypes { Id = 0, Type = "Vyrai"},
                new AgeGroupTypes { Id = 1, Type = "Moterys"},
                new AgeGroupTypes { Id = 2, Type = "Jauniai"},
                new AgeGroupTypes { Id = 3, Type = "Jaunės"},
                new AgeGroupTypes { Id = 4, Type = "Jaunučiai"},
                new AgeGroupTypes { Id = 5, Type = "Jaunutės"},
                new AgeGroupTypes { Id = 6, Type = "Berniukai"},
                new AgeGroupTypes { Id = 7, Type = "Mergaitės"},
                new AgeGroupTypes { Id = 8, Type = "Vaikai berniukai"},
                new AgeGroupTypes { Id = 9, Type = "Vaikai mergaitės"}
            };

            var mockAgeGroupTypes = Substitute.For<DbSet<AgeGroupTypes>, IQueryable<AgeGroupTypes>>();
            ((IQueryable<AgeGroupTypes>)mockAgeGroupTypes).Provider.Returns(ageGroupTypes.AsQueryable().Provider);
            ((IQueryable<AgeGroupTypes>)mockAgeGroupTypes).Expression.Returns(ageGroupTypes.AsQueryable().Expression);
            ((IQueryable<AgeGroupTypes>)mockAgeGroupTypes).ElementType.Returns(ageGroupTypes.AsQueryable().ElementType);
            ((IQueryable<AgeGroupTypes>)mockAgeGroupTypes).GetEnumerator().Returns(ageGroupTypes.AsQueryable().GetEnumerator());

            mockAgeGroupTypes.When(q => q.Add(Arg.Any<AgeGroupTypes>()))
                        .Do(q => ageGroupTypes.Add(q.Arg<AgeGroupTypes>()));

            mockAgeGroupTypes.When(q => q.Remove(Arg.Any<AgeGroupTypes>()))
                .Do(q => ageGroupTypes.Remove(q.Arg<AgeGroupTypes>()));

            contextAgeGroupTypes.AgeGroupTypes = mockAgeGroupTypes;
        }
    }
}