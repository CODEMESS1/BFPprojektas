using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class EventTypesContainer : DbContext
    {
        public EventTypesContainer() : base("DefaultConnection")
        {

        }

        public DbSet<EventTypes> EventTypes { get; set; }

        public EventTypes GetEventTypes(int eventType)
        {
            return EventTypes.Where(t => t.Id == eventType).ToList()[0];
        }
    }
}