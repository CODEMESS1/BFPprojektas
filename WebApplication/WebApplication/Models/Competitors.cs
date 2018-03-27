using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Competitors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Year { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CoachId { get; set; }

        public Competitors()
        {

        }

        public Competitors(string id, string name, string surname, string year, string gender, string city, string country, string coachid)
        {
            Id = Convert.ToInt32(id);
            Name = name;
            Surname = surname;
            Year = Convert.ToDateTime(year);
            Gender = gender;
            City = city;
            Country = country;
            CoachId = coachid;
        }

        public Competitors(string name, string surname, string year, string gender, string city, string country, string coachid)
        {
            Name = name;
            Surname = surname;
            Year = Convert.ToDateTime(year);
            Gender = gender;
            City = city;
            Country = country;
            CoachId = coachid;
        }

        public override bool Equals(object c)
        {
            Competitors competitor = (Competitors)c;
            return (Name.Equals(competitor.Name) && Surname.Equals(competitor.Surname) && Year.Equals(competitor.Year));
        }
    }
}