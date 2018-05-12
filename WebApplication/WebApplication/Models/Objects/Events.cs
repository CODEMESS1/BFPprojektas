using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string Title { get; set;}
        public int Type { get; set; }

        public Events()
        {
        }

        public Events(int id, string title, int type)
        {
            Id = id;
            Title = title;
            Type = type;
        }

        public Events(string title, int type)
        {
            Title = title;
            Type = type;
        }

        public override string ToString()
        {
            return String.Format("{0}", Title);

        }


    }
}