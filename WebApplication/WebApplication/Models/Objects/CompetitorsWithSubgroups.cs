using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CompetitorsWithSubgroups
    {
        public int Id { get; set; }
        public int Subgroup { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Year { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CoachId { get; set; }

        public CompetitorsWithSubgroups()
        {

        }

        public CompetitorsWithSubgroups(Competitors competitors, int subgroup)
        {
            Id = competitors.Id;
            Subgroup = subgroup;
            Name = competitors.Name;
            Surname = competitors.Surname;
            Year = competitors.Year;
            Gender = competitors.Gender;
            City = competitors.City;
            Country = competitors.Country;
            CoachId = competitors.CoachId;
        }

        public override string ToString()
        {
            return string.Format("{0:6}  {1:6}  {2:20}  {3:20}  {4:yyyy/MM/dd}  {5:30}  {6:30}  {7:6}", Id, 
                Subgroup, Name, Surname, Year, City, Country, CoachId);
        }
    }
}