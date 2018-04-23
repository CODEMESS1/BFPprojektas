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

        public List<Models.Events> Events { set => events = value; }
        public string Title { get; set; }
        public string Type { get; set; }
        public List<EventTypes> EventTypes { set => eventTypes = value; }
        public List<AgeGroupTypes> AgeGroupTypes { set => ageGroupTypes = value; }

        public bool AddEvent(Models.Events eventToAdd)
        {
            if(eventToAdd != null)
            {
                events.Add(eventToAdd);
                return true; 
            }
            return false;
        }

        public bool EditEvent(int eventIdToEdit)
        {
            List<Models.Events> eventsToEdit = events.Where(e => e.Id == eventIdToEdit).ToList();
            if(eventsToEdit.Count != 0)
            {
                int id = eventsToEdit[0].Id;
                events.Remove(eventsToEdit[0]);
                events.Add(new Models.Events(id, Title, Type));
                return true;
            }
            return false;
        }

        public bool RemoveEvent(int eventIdToRemove)
        {
            List<Models.Events> eventsToRemove = events.Where(e => e.Id == eventIdToRemove).ToList();
            if (eventsToRemove.Count != 0)
            {
                events.Remove(eventsToRemove[0]);
                return true;
            }
            return false;
        }
    }
}