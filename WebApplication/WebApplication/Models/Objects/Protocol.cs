using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Protocol
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
        public int OfficialId { get; set; }
        public int EventId { get; set; }
        public int SubgroupsId { get; set; }

        public Protocol()
        {

        }

        public Protocol(string name, string title, string id, string officialId, string eventId, string subgroupsId)
        {
            Name = name;
            Title = title;
            Id = Convert.ToInt32(id);
            OfficialId = Convert.ToInt32(officialId);
            EventId = Convert.ToInt32(eventId);
            SubgroupsId = Convert.ToInt32(subgroupsId);

        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", Name, Title);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object c)
        {
            Protocol protocol = (Protocol)c;
            return (Name.Equals(protocol.Name) && Title.Equals(protocol.Title));
        }

    }
}