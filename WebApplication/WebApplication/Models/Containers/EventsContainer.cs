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
        private AgeGroupTypesContainer AgeGroupTypesContainer = new AgeGroupTypesContainer();

        public bool AddEvent(Events events, List<string> ageGroupTypes)
        {
            if (events != null)
            {
                Events.Add(events);
                SaveChanges();
                SetEventAgeGroups(events.Id, ageGroupTypes);
                return true;
            }
            return false;
        }

        private void AddAgeGroupEvent(int eventId, string group)
        {
            int ageGroupId = AgeGroupTypesContainer.AgeGroupTypes.Where(g => g.Type.Equals(group)).Single().Id;
            AgeGroupEvents.Add(new AgeGroupEvents(eventId, ageGroupId));
            SaveChanges();
        }

        public void RemoveAgeGroupEvent(int eventId, string group)
        {
            int ageGroupId = AgeGroupTypesContainer.AgeGroupTypes.Where(g => g.Type.Equals(group)).Single().Id;
            AgeGroupEvents.Remove(AgeGroupEvents.Where(g => g.AgeGroupType == ageGroupId && g.EventId == eventId).Single());
            SaveChanges();
        }

        public void RemoveAgeGroupsEventRange(int eventId)
        {
            AgeGroupEvents.RemoveRange(AgeGroupEvents.Where(g => g.EventId == eventId));
            SaveChanges();
        }

        private void SetEventAgeGroups(int eventId, List<string> groups)
        {
            RemoveAgeGroupsEventRange(eventId);
            for (int i = 0; i<groups.Count; i++)
            {
                string group = groups[i];
                int ageGroupId = AgeGroupTypesContainer.AgeGroupTypes.Where(g => g.Type.Equals(group)).Single().Id;
                AddAgeGroupEvent(eventId, groups[i]);
            }
            SaveChanges();
        }

        public bool editEvent(int Id, string title, int type, List<string> groups)
        {
            if (Events.Where(e => e.Id == Id).Count() != 0)
            {
                Events eventToEdit = Events.Where(e => e.Id == Id).Single();
                eventToEdit.Title = title;
                eventToEdit.Type = type;
                SetEventAgeGroups(Id, groups);
                return true;
            }
            return false;
        }

        public List<Events> GetSelectedEvents(string ageGroup, int competitionId)
        {
            List<Models.Events> eventsToReturn = new List<Events>();
            int ageGroupType = AgeGroupTypesContainer.AgeGroupTypes.Where(t => t.Type.Equals(ageGroup)).ToList()[0].Id;
            List<AgeGroupEvents> ageGroupEvents = GetEventsInCompetition(ageGroup, competitionId);
            foreach (Models.AgeGroupEvents c in ageGroupEvents)
            {
                if((Events.Where(ev => ev.Id == c.EventId).Count() != 0))
                {
                    eventsToReturn.Add(Events.Where(ev => ev.Id == c.EventId).ToList()[0]);
                }
            }
            return eventsToReturn;
        }

        public List<AgeGroupEvents> GetEventsInCompetition(string ageGroup, int competitionId)
        {
            List<CompetitionEvents> competitionEvents = CompetitionEventsContainer.CompetitionEvents.Where(ce => ce.CompetitionId == competitionId).ToList();
            List<AgeGroupEvents> ageGroupEvents = new List<AgeGroupEvents>();
            foreach (CompetitionEvents e in competitionEvents)
            {
                if (AgeGroupEvents.Where(age => age.EventId == e.EventId).Count() != 0)
                {
                    ageGroupEvents.Add(AgeGroupEvents.Where(age => age.EventId == e.EventId).ToList()[0]);
                }
            }
            return ageGroupEvents;
        }
    }
}