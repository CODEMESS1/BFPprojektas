using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Coach
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }


        public Coach()
        {

        }

        public Coach(string name, string lastName, string id)
        {
            Name = name;
            LastName = lastName;
            Id = Convert.ToInt32(id);
            
        }

        public Coach(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", Name, LastName);

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object c)
        {
            Coach coach = (Coach)c;
            return (Name.Equals(coach.Name) && LastName.Equals(coach.LastName));
        }

    }
}