﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CompetitionEventsContainer: DbContext
    {
         public CompetitionEventsContainer() : base("DefaultConnection")
        {

        }

        public DbSet<CompetitionEvents> CompetitionEvents { get; set; }

        public bool AddEventsList(int competitionId, List<Events> events)
        {
            if (events.Count != 0)
            {
                foreach (Events e in events)
                {
                    if ((CompetitionEvents.Where(ce => ce.EventId == e.Id && ce.CompetitionId == competitionId).ToList().Count == 0))
                    {
                        CompetitionEvents.Add(new CompetitionEvents(competitionId, e.Id));
                    }
                }
                SaveChanges();
                return true;
            }
            return false;
        }

        public void DeleteRange(int Id)
        {
            List<CompetitionEvents> competitionEventsToRemove = CompetitionEvents.Where(e => e.CompetitionId == Id).ToList();
            CompetitionEvents.RemoveRange(competitionEventsToRemove);
            SaveChanges();
        }

        public void AddEvent(int compId, int eventId)
        {
            CompetitionEvents.Add(new CompetitionEvents(compId, eventId));
            SaveChanges();
        }

        public void RemoveEvent(int compId, int eventId)
        {
            CompetitionEvents eventToRemove = CompetitionEvents.Where(e => e.CompetitionId == compId && e.EventId == eventId).Single();
            CompetitionEvents.Remove(eventToRemove);
            SaveChanges();
        }

        public void RemoveRange(int compId)
        {
            CompetitionEvents.RemoveRange(CompetitionEvents.Where(e => e.CompetitionId == compId));
            SaveChanges();
        }

        public bool UpdateEventsList(int compId, List<Events> events)
        {
            if (events.Count == 0)
                return false;
            RemoveRange(compId);
            
           foreach (Events e in events)
           { 
               AddEvent(compId, e.Id);
            }
            SaveChanges();
            return true;
        }
    }
}