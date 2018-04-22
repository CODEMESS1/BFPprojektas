using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;
using WebApplication.Models;

namespace WebApplication.Tests.Mocks
{
    public class MockCreateEventsView : ICreateEvents
    {
        private List<Models.Events> events;
        private List<Models.EventTypes> eventTypes;
        private List<Models.AgeGroupTypes> ageGroupTypes;

        public List<Events> Events { set => events = value; }
        public string Title { get; set; }
        public string Type { get; set; }
        public List<EventTypes> EventTypes { set => eventTypes = value; }
        public List<AgeGroupTypes> AgeGroupTypes { set => ageGroupTypes = value; }

        public bool AddEvent(Events eventToAdd)
        {
            throw new NotImplementedException();
        }

        public bool EditEvent(int eventIdToEdit)
        {
            throw new NotImplementedException();
        }

        public List<AgeGroupTypes> GetSelectedGroups()
        {
            throw new NotImplementedException();
        }

        public bool RemoveEvent(int eventIdToRemove)
        {
            throw new NotImplementedException();
        }
    }
}