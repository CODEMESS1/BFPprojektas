using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class SubgroupsOfAge
    {
        public int Id { get; set; }
        public DateTime FromYear { get; set; }
        public DateTime ToYear { get; set; }

        public SubgroupsOfAge()
        {

        }

        public SubgroupsOfAge(string id, string fromYear, string toYear)
        {
            Id = Convert.ToInt32(id);
            FromYear = Convert.ToDateTime(fromYear);
            ToYear = Convert.ToDateTime(toYear);
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", FromYear, ToYear);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object c)
        {
            SubgroupsOfAge subgroupsOfAge = (SubgroupsOfAge)c;
            return (FromYear.Equals(subgroupsOfAge.FromYear) && ToYear.Equals(subgroupsOfAge.ToYear));
        }

    }
}