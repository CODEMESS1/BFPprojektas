using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class EventsContainer : DbContext
    {
        public EventsContainer() : base("DefaultConnection")
        {

        }

        public DbSet<Events> Events { get; set; }
        public DbSet<AgeGroupEvents> AgeGroupEvents { get; set; }

        private CompetitionEventsContainer CompetitionEventsContainer = new CompetitionEventsContainer();

        public bool AddEvent(Events events, List<string> ageGroupTypes)
        {
            if (events != null)
            {
                Events.Add(events);
                SaveChanges();
                SetEventAgeGroups(events, ageGroupTypes);
                return true;
            }
            return false;
        }

        private void SetEventAgeGroups(Events events, List<string> groups)
        {
            int id = Events.Where(e => e.Title.Equals(events.Title) && e.Type.Equals(events.Type)).ToList()[0].Id;
            for (int i = 0; i<groups.Count; i++)
            {
                AgeGroupEvents ageGroupEvent = new AgeGroupEvents(id, groups[i]);
                AgeGroupEvents.Add(ageGroupEvent);
            }
            SaveChanges();
        }

        public bool editEvent(int Id, string title, int type)
        {
            List<Events> eventsList = Events.Where(e => e.Id == Id).ToList();
            if (eventsList.Count != 0)
            {
                Events.Remove(eventsList[0]);
                Events.Add(new Models.Events(title, type));
                SaveChanges();
                return true;
            }
            return false;
        }

        public List<Events> GetSelectedEvents(string ageGroup, int competitionId)
        {
            List<Models.Events> eventsToReturn = new List<Events>();
            List<Models.CompetitionEvents> competitionEvents = CompetitionEventsContainer.CompetitionEvents.Where(e => e.CompetitionId == competitionId).ToList();
            foreach(Models.CompetitionEvents c in competitionEvents)
            {
                eventsToReturn.Add(Events.Where(ev => ev.Id == c.EventId).ToList()[0]);
            }
            return eventsToReturn;
        }
    }
}