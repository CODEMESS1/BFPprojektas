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

        public DbSet<Event> Events { get; set; }

    }
}