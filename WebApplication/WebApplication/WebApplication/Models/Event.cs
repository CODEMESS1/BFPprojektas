using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set;}

        public Event()
        {
        }

        public Event(string id, string title)
        {
            Id = Convert.ToInt32(id);
            Title = title;
        }

        public override string ToString()
        {
            return String.Format("{0}", Title);

        }


    }
}