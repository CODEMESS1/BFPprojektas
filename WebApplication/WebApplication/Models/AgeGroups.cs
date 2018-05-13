using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class AgeGroups
    {
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public string Title { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public AgeGroups()
        {

        }

        public AgeGroups(string id, int competitionId, string title, int fromYear, int toYear)
        {
            Id = Convert.ToInt32(id);
            CompetitionId = competitionId;
            Title = title;
            StartYear = fromYear;
            EndYear = toYear;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}-{2}", Title, StartYear, EndYear);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object c)
        {
            AgeGroups subgroupsOfAge = (AgeGroups)c;
            return (subgroupsOfAge.Id == Id);
        }

    }
}