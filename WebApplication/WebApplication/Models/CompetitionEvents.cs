using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CompetitionEvents
    {
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public int EventId { get; set; }

        public CompetitionEvents()
        {

        }

        public CompetitionEvents(int competitionId, int eventId)
        {
            CompetitionId = competitionId;
            EventId = eventId;
        }

        public override bool Equals(object obj)
        {
            CompetitionEvents competitionEvents = (CompetitionEvents)obj;
            if(competitionEvents.CompetitionId == CompetitionId && competitionEvents.EventId == EventId)
            {
                return true;
            }
            return false;
        }
    }
}