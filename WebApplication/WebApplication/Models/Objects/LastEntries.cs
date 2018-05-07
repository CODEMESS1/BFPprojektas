using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Objects
{
    public class LastEntries
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Event { get; set; }
        public string Result { get; set; }

        public LastEntries()
        {

        }

        public LastEntries(int id, string name, string surname, string Event, string result)
        {
            Id = id;
            Name = name;
            Surname = surname;
            this.Event = Event;
            Result = result;
        }
    }
}