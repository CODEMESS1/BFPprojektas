using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class AgeGroupEvents
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int AgeGroupType { get; set; }

        public AgeGroupEvents() { }

        public AgeGroupEvents(int eventId, int type)
        {
            EventId = eventId;
            AgeGroupType = type;
        }
    }
}