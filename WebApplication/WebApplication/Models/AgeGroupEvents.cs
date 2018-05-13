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
        public string AgeGroupType { get; set; }

        public AgeGroupEvents() { }

        public AgeGroupEvents(int eventId, string type)
        {
            EventId = eventId;
            AgeGroupType = type;
        }
    }
}