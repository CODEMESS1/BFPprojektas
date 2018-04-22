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

        public bool addEvent(Events events)
        {
            if(events != null)
            {
                Events.Add(events);
                SaveChanges();
                return true;
            }
            return false;
        }
    }
}