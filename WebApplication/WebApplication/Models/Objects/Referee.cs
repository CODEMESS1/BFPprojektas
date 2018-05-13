using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Referee
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public DateTime YearOfBirth { get; set; }

        public Referee()
        {

        }

        public Referee(string name, string lastName, string id, string yearOfBirth)
        {
            Name = name;
            LastName = lastName;
            Id = Convert.ToInt32(id);
            YearOfBirth = Convert.ToDateTime(yearOfBirth);
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2:yyyy-mm-dd}", Name, LastName, YearOfBirth);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object c)
        {
            Referee referee = (Referee)c;
            return (Name.Equals(referee.Name) && LastName.Equals(referee.LastName) && YearOfBirth.Equals(referee.YearOfBirth));
        }


    }
}