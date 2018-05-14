using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;
using WebApplication.Models;

namespace WebApplication.Tests.Mocks
{
    public class CreateEventsViewMock : ICreateEvents
    {
        public List<EventTypes> EventTypes { set => throw new NotImplementedException(); }
        public List<Events> Events { set => throw new NotImplementedException(); }
        public List<AgeGroupTypes> AgeGroupTypes { set => throw new NotImplementedException(); }

        public string Title => throw new NotImplementedException();

        public int Type => throw new NotImplementedException();

        public bool AddEvent(Events eventToAdd)
        {
            throw new NotImplementedException();
        }

        public bool EditEvent(int eventIdToEdit)
        {
            throw new NotImplementedException();
        }

        public bool RemoveEvent(int eventIdToRemove)
        {
            throw new NotImplementedException();
        }
    }
}