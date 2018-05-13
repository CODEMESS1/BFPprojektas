using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CompetitionAgeSubgroups
    {
        public int Id { get; set; }
        public int AgeGroupsId { get; set; }
        public int SubGroupsCount { get; set; }

        public CompetitionAgeSubgroups()
        {

        }

        public CompetitionAgeSubgroups(int ageGroupsId, int subGroupsCount)
        {
            AgeGroupsId = ageGroupsId;
            SubGroupsCount = subGroupsCount;
        }
    }
}